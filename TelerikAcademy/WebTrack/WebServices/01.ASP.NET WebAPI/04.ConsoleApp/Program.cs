using _01.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace _04.ConsoleApp
{
    class Program
    {
        private static readonly HttpClient Client = new HttpClient { BaseAddress = new Uri("http://localhost:1289/") };

        // All packages are removed because otherwise the solution is too big to be archived properly.
        // Please add them on your own.
        static void Main()
        {
            // All methods work with both JSON and XML. Just change the type and they should work fine.
            Client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            // I have commented all the methods so you can test them individually.
            // When testing, please check that the input parameters are correct for 
            // your database (some of them may not exist as I have used manually filled
            // database for testing while writing the application.
            ListOperations.ListArtists(Client);
            //ListOperations.ListAlbums(Client);
            //ListOperations.ListSongs(Client);

            //GetByIdOperations.GetAlbumById(Client, 1);
            //GetByIdOperations.GetSongById(Client, 1);
            //GetByIdOperations.GetArtistById(Client, 1);

            //PutOperations.UpdateArtist(Client, 1, "newName");
            //PutOperations.UpdateAlbum(Client, 1, "newTitle");
            //PutOperations.UpdateSong(Client, 1, "newTitle", "newGenre", 2010);

            /*Album album = new Album();
            album.Title = "addedTitle";
            album.Producer = "addedProducer";
            album.Year = 2010;

            Song song = new Song();
            song.Title = "Blues song";
            song.Year = 2010;
            song.Genre = "blues";
            album.Songs.Add(song);

            Artist artist = new Artist();
            artist.Name = "addedName";
            artist.DateOfBirth = DateTime.Now;
            artist.Country = "addedCountry";
            album.Artists.Add(artist);
            PostOperations.AddAlbum(Client, album);*/

            /*Artist artist = new Artist();
            artist.Name = "addedName";
            artist.Country = "addedCountry";
            artist.DateOfBirth = DateTime.Now;

            Album album = new Album();
            album.Title = "Jack Flakes' album";
            album.Producer = "Jack Flakes' producer";
            album.Year = 2010;
            artist.Albums.Add(album);

            Song song = new Song();
            song.Title = "addedTitle";
            song.Genre = "addedGenre";
            song.Year = 2010;
            artist.Songs.Add(song);

            PostOperations.AddArtist(Client, artist);*/

            /*Song song = new Song();
            song.Title = "addedTitle";
            song.Year = 2010;
            song.Genre = "addedGenre";

            Album album = new Album();
            album.Title = "Jack Flakes' album";
            album.Producer = "Jack Flakes' producer";
            album.Year = 2010;
            song.Albums.Add(album);

            Artist artist = new Artist();
            artist.Name = "addedName";
            artist.DateOfBirth = DateTime.Now;
            artist.Country = "addedCountry";
            song.Artists.Add(artist);

            PostOperations.AddSong(Client, song);*/

            //DeleteOperations.DeleteArtist(Client, 10);

            //DeleteOperations.DeleteAlbum(Client, 10);

            //DeleteOperations.DeleteSong(Client, 10);
        }
    }
}
