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

namespace _03.WebClient.Controllers
{
    public class ArtistController : ApiController
    {
        private AlbumContext db = new AlbumContext();

        public ArtistController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }

        // GET api/Artist
        public IEnumerable<SerializableArtist> GetArtists()
        {
            var artists = from artist in db.Artists.Include("Albums").Include("Songs")
                          select artist;

            List<SerializableArtist> artistsToReturn = new List<SerializableArtist>();

            foreach (var artist in artists)
            {
                SerializableArtist newArtist = new SerializableArtist();
                newArtist.ArtistId = artist.ArtistId;
                newArtist.Country = artist.Country;
                newArtist.DateOfBirth = artist.DateOfBirth;
                newArtist.Name = artist.Name;
                var albums = new List<string>();
                foreach (var album in artist.Albums)
                {
                    albums.Add(album.Title);
                }

                newArtist.AddAlbums(albums);

                var songs = new List<string>();

                foreach (var song in artist.Songs)
                {
                    songs.Add(song.Title);
                }

                newArtist.AddSongs(songs);

                artistsToReturn.Add(newArtist);
            }

            return artistsToReturn;
        }

        // GET api/Artist/5
        public SerializableArtist GetArtist(int id)
        {
            var artists = from artist in db.Artists.Include("Albums").Include("Songs")
                            select artist;

            Artist searchedArtist = artists.FirstOrDefault(a => a.ArtistId == id);

            if (searchedArtist == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            SerializableArtist artistToReturn = new SerializableArtist();
            artistToReturn.ArtistId = searchedArtist.ArtistId;
            artistToReturn.Name = searchedArtist.Name;
            artistToReturn.DateOfBirth = searchedArtist.DateOfBirth;
            artistToReturn.Country = searchedArtist.Country;

            List<string> songs = new List<string>();
            foreach (var song in searchedArtist.Songs)
            {
                songs.Add(song.Title);
            }

            artistToReturn.AddSongs(songs);

            List<string> albums = new List<string>();
            foreach (var album in searchedArtist.Albums)
            {
                albums.Add(album.Title);
            }

            artistToReturn.AddAlbums(albums);

            return artistToReturn;
        }

        // PUT api/Artist/5
        public HttpResponseMessage PutArtist(int id, Artist artist)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != artist.ArtistId)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(artist).State = EntityState.Modified;

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

        // POST api/Artist
        public HttpResponseMessage PostArtist(Artist artist)
        {
            if (ModelState.IsValid)
            {
                db.Artists.Add(artist);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, artist);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = artist.ArtistId }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Artist/5
        public HttpResponseMessage DeleteArtist(int id)
        {
            Artist artist = db.Artists.Find(id);
            if (artist == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Artists.Remove(artist);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, artist);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}