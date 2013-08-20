using _01.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace _04.ConsoleApp
{
    public static class ListOperations
    {
        public static void ListArtists(HttpClient client)
        {
            HttpResponseMessage response = client.GetAsync("api/Artist").Result;
            if (response.IsSuccessStatusCode)
            {
                var artists = response.Content.ReadAsAsync<IEnumerable<SerializableArtist>>().Result;
                foreach (var a in artists)
                {
                    Console.WriteLine("{0} {1} {2}", a.Name, a.DateOfBirth, a.Country);
                    foreach (var album in a.Albums)
                    {
                        Console.WriteLine("Album name: {0}", album.Name);
                    }

                    foreach (var song in a.Songs)
                    {
                        Console.WriteLine("Song name:{0}", song.Name);
                    }

                    Console.WriteLine("-----------------------");
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        public static void ListAlbums(HttpClient client)
        {
            HttpResponseMessage response = client.GetAsync("api/Album").Result;
            if (response.IsSuccessStatusCode)
            {
                var albums = response.Content.ReadAsAsync<IEnumerable<SerializableAlbum>>().Result;
                foreach (var a in albums)
                {
                    Console.WriteLine("{0} {1} {2}", a.Title, a.Year, a.Producer);
                    foreach (var artist in a.Artists)
                    {
                        Console.WriteLine("Artist name: {0}", artist.Name);
                    }

                    foreach (var song in a.Songs)
                    {
                        Console.WriteLine("Song name:{0}", song.Name);
                    }

                    Console.WriteLine("-----------------------");
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        public static void ListSongs(HttpClient client)
        {
            HttpResponseMessage response = client.GetAsync("api/Song").Result;
            if (response.IsSuccessStatusCode)
            {
                var songs = response.Content.ReadAsAsync<IEnumerable<SerializableSong>>().Result;
                foreach (var s in songs)
                {
                    Console.WriteLine("{0} {1} {2}", s.Title, s.Year, s.Genre);
                    foreach (var artist in s.Artists)
                    {
                        Console.WriteLine("Artist name: {0}", artist.Name);
                    }

                    foreach (var album in s.Albums)
                    {
                        Console.WriteLine("Album name:{0}", album.Name);
                    }

                    Console.WriteLine("-----------------------");
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }
    }
}
