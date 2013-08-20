using _01.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace _04.ConsoleApp
{
    public static class GetByIdOperations
    {
        public static void GetAlbumById(HttpClient client, int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException("Id must be a positive integer.");
            }

            HttpResponseMessage response = client.GetAsync("api/Album/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var album = response.Content.ReadAsAsync<SerializableAlbum>().Result;

                Console.WriteLine("{0} {1} {2}", album.Title, album.Year, album.Producer);
                foreach (var artist in album.Artists)
                {
                    Console.WriteLine("Artist name: {0}", artist.Name);
                }

                foreach (var song in album.Songs)
                {
                    Console.WriteLine("Song name:{0}", song.Name);
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        public static void GetSongById(HttpClient client, int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException("Id must be a positive integer.");
            }

            HttpResponseMessage response = client.GetAsync("api/Song/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var song = response.Content.ReadAsAsync<SerializableSong>().Result;

                Console.WriteLine("{0} {1} {2}", song.Title, song.Year, song.Genre);
                foreach (var artist in song.Artists)
                {
                    Console.WriteLine("Artist name: {0}", artist.Name);
                }

                foreach (var album in song.Albums)
                {
                    Console.WriteLine("Album name:{0}", album.Name);
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        public static void GetArtistById(HttpClient client, int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException("Id must be a positive integer.");
            }

            HttpResponseMessage response = client.GetAsync("api/Artist/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var artist = response.Content.ReadAsAsync<SerializableArtist>().Result;

                Console.WriteLine("{0} {1} {2}", artist.Name, artist.Country, artist.DateOfBirth);
                foreach (var album in artist.Albums)
                {
                    Console.WriteLine("Album name: {0}", album.Name);
                }

                foreach (var song in artist.Songs)
                {
                    Console.WriteLine("Song name:{0}", song.Name);
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }
    }
}
