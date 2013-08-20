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

            //Album updAlbum = db.Albums.FirstOrDefault(a => a.AlbumId == album.AlbumId);

            //updAlbum = album;

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
                db.Albums.Add(album);
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