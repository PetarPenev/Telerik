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
    public class AlbumController : ApiController
    {
        private AlbumContext db = new AlbumContext();

        public AlbumController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }

        // GET api/Default1
        public IEnumerable<SerializableAlbum> GetAlbums()
        {
            var albums = from album in db.Albums.Include("Artists").Include("Songs")
                         select album;

            List<SerializableAlbum> albumsToReturn = new List<SerializableAlbum>();

            foreach (var album in albums)
            {
                SerializableAlbum newAlbum = new SerializableAlbum();
                newAlbum.AlbumId = album.AlbumId;
                newAlbum.Producer = album.Producer;
                newAlbum.Title = album.Title;
                newAlbum.Year = album.Year;
                var artists = new List<string>();
                foreach (var artist in album.Artists)
                {
                    artists.Add(artist.Name);
                }

                newAlbum.AddArtists(artists);

                var songs = new List<string>();

                foreach (var song in album.Songs)
                {
                    songs.Add(song.Title);
                }

                newAlbum.AddSongs(songs);

                albumsToReturn.Add(newAlbum);
            }

            return albumsToReturn;
        }

        // GET api/Default1/5
        public SerializableAlbum GetAlbum(int id)
        {
            var albums = from album in db.Albums.Include("Artists").Include("Songs")
                         select album;

            Album searchedAlbum = albums.FirstOrDefault(a => a.AlbumId == id);

            if (searchedAlbum == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            SerializableAlbum albumToReturn = new SerializableAlbum();

            albumToReturn.AlbumId = searchedAlbum.AlbumId;
            albumToReturn.Title = searchedAlbum.Title;
            albumToReturn.Year = searchedAlbum.Year;
            albumToReturn.Producer = searchedAlbum.Producer;

            List<string> songs = new List<string>();
            foreach (var song in searchedAlbum.Songs)
            {
                songs.Add(song.Title);
            }

            albumToReturn.AddSongs(songs);

            List<string> artists = new List<string>();
            foreach (var artist in searchedAlbum.Artists)
            {
                artists.Add(artist.Name);
            }

            albumToReturn.AddArtists(artists);

            return albumToReturn;
        }

        // PUT api/Default1/5
        public HttpResponseMessage PutAlbum(int id, Album album)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != album.AlbumId)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(album).State = EntityState.Modified;

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

        // POST api/Default1
        public HttpResponseMessage PostAlbum(Album album)
        {
            if (ModelState.IsValid)
            {
                Album albumToAdd = new Album();
                albumToAdd.AlbumId = album.AlbumId;
                albumToAdd.Producer = album.Producer;
                albumToAdd.Title = album.Title;
                albumToAdd.Year = album.Year;
                foreach (var song in album.Songs)
                {
                    var searchedSong = db.Songs.FirstOrDefault(s => s.Title == song.Title && s.Genre == song.Genre
                        && s.Year == song.Year);

                    if (searchedSong != null)
                    {
                        albumToAdd.Songs.Add(searchedSong);
                    }
                    else
                    {
                        albumToAdd.Songs.Add(new Song()
                        {
                            Title = song.Title,
                            Year = song.Year,
                            Genre = song.Genre
                        });
                    }
                }

                foreach (var artist in album.Artists)
                {
                    var searchedArtist = db.Artists.FirstOrDefault(a => a.Name == artist.Name && a.Country == artist.Country
                        && a.DateOfBirth == artist.DateOfBirth);

                    if (searchedArtist != null)
                    {
                        albumToAdd.Artists.Add(searchedArtist);
                    }
                    else
                    {
                        albumToAdd.Artists.Add(new Artist()
                            {
                                Name = artist.Name,
                                Country = artist.Country,
                                DateOfBirth = artist.DateOfBirth
                            });
                    }
                }

                db.Albums.Add(albumToAdd);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, album);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = album.AlbumId }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Default1/5
        public HttpResponseMessage DeleteAlbum(int id)
        {
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Albums.Remove(album);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, album);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}