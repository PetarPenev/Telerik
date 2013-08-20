using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using _01.Classes;
using _02.Context;

namespace _03.WebApiClient.Controllers
{
    public class SongController : ApiController
    {
        private AlbumContext db = new AlbumContext();

        public SongController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }

        // GET api/Song
        public IEnumerable<SerializableSong> GetSongs()
        {
            var songs = from artist in db.Songs.Include("Albums").Include("Artists")
                        select artist;

            List<SerializableSong> songsToReturn = new List<SerializableSong>();

            foreach (var song in songs)
            {
                SerializableSong newSong = new SerializableSong();
                newSong.SongId = song.SongId;
                newSong.Year = song.Year;
                newSong.Title = song.Title;
                newSong.Genre = song.Genre;

                var albums = new List<string>();
                foreach (var album in song.Albums)
                {
                    albums.Add(album.Title);
                }

                newSong.AddAlbums(albums);

                var artists = new List<string>();

                foreach (var artist in song.Artists)
                {
                    artists.Add(artist.Name);
                }

                newSong.AddArtists(artists);

                songsToReturn.Add(newSong);
            }

            return songsToReturn;
        }

        // GET api/Song/5
        public SerializableSong GetSong(int id)
        {
            var songs = from song in db.Songs.Include("Albums").Include("Artists")
                        select song;

            Song searchedSong = songs.FirstOrDefault(a => a.SongId == id);

            if (searchedSong == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            SerializableSong songToReturn = new SerializableSong();
            songToReturn.SongId = searchedSong.SongId;
            songToReturn.Year = searchedSong.Year;
            songToReturn.Title = searchedSong.Title;
            songToReturn.Genre = searchedSong.Genre;

            var albums = new List<string>();
            foreach (var album in searchedSong.Albums)
            {
                albums.Add(album.Title);
            }

            songToReturn.AddAlbums(albums);

            var artists = new List<string>();

            foreach (var artist in searchedSong.Artists)
            {
                artists.Add(artist.Name);
            }

            songToReturn.AddArtists(artists);

            return songToReturn;
        }

        // PUT api/Song/5
        public HttpResponseMessage PutSong(int id, Song song)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != song.SongId)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(song).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/Song
        public HttpResponseMessage PostSong(Song song)
        {
            if (ModelState.IsValid)
            {
                Song songToAdd = new Song();
                songToAdd.SongId = song.SongId;
                songToAdd.Title = song.Title;
                songToAdd.Year = song.Year;
                songToAdd.Genre = song.Genre;

                foreach (var artist in song.Artists)
                {
                    var searchedArtist = db.Artists.FirstOrDefault(a => a.Country == artist.Country &&
                        a.DateOfBirth == artist.DateOfBirth && a.Name == artist.Name);

                    if (searchedArtist != null)
                    {
                        songToAdd.Artists.Add(searchedArtist);
                    }
                    else
                    {
                        songToAdd.Artists.Add(new Artist()
                        {
                            Country = artist.Country,
                            Name = artist.Name,
                            DateOfBirth =artist.DateOfBirth
                        });
                    }
                }

                foreach (var album in song.Albums)
                {
                    var searchedAlbum = db.Albums.FirstOrDefault(a => a.Producer == album.Producer && a.Title == album.Title
                        && a.Year == album.Year);

                    if (searchedAlbum != null)
                    {
                        songToAdd.Albums.Add(searchedAlbum);
                    }
                    else
                    {
                        songToAdd.Albums.Add(new Album()
                        {
                            Title = album.Title,
                            Year = album.Year,
                            Producer = album.Producer
                        });
                    }
                }

                db.Songs.Add(songToAdd);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, song);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = song.SongId }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Song/5
        public HttpResponseMessage DeleteSong(int id)
        {
            Song song = db.Songs.Find(id);
            if (song == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Songs.Remove(song);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, song);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}