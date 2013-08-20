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
    public static class PutOperations
    {
        public static void UpdateArtist(HttpClient client, int id, string newName = null, 
            string newCountry = null, DateTime? newDateOfBirth = null)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException("Id must be a positive integer.");
            }

            HttpResponseMessage response = client.GetAsync("api/Artist/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var artist = response.Content.ReadAsAsync<SerializableArtist>().Result;

                Artist updatedArtist = new Artist();
                updatedArtist.ArtistId = id;

                if (newCountry != null)
                {
                    updatedArtist.Country = newCountry;
                }
                else
                {
                    updatedArtist.Country = artist.Country;
                }

                if (newDateOfBirth != null)
                {
                    updatedArtist.DateOfBirth = newDateOfBirth.Value;
                }
                else
                {
                    updatedArtist.DateOfBirth = artist.DateOfBirth;
                }

                if (newName != null)
                {
                    updatedArtist.Name = newName;
                }
                else
                {
                    updatedArtist.Name = artist.Name;
                }

                HttpResponseMessage innerResponse = null;

                if (client.DefaultRequestHeaders.Accept.Contains(new MediaTypeWithQualityHeaderValue("application/xml")))
                {
                    innerResponse = client.PutAsXmlAsync<Artist>("api/Artist/" + id, updatedArtist).Result;
                }
                else if (client.DefaultRequestHeaders.Accept.Contains(new MediaTypeWithQualityHeaderValue("application/json")))
                {
                    innerResponse = client.PutAsJsonAsync<Artist>("api/Artist/" + id, updatedArtist).Result;
                }

                if (innerResponse == null)
                {
                    throw new InvalidOperationException("Client must use json or xml.");
                }

                if (innerResponse.IsSuccessStatusCode)
                {
                    Console.WriteLine("Update successful.");
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)innerResponse.StatusCode, innerResponse.ReasonPhrase);
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        public static void UpdateAlbum(HttpClient client, int id, string newTitle = null,
            string newProducer = null, int? newYear = null)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException("Id must be a positive integer.");
            }

            HttpResponseMessage response = client.GetAsync("api/Album/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var album = response.Content.ReadAsAsync<SerializableAlbum>().Result;

                Album updatedAlbum = new Album();
                updatedAlbum.AlbumId = id;

                if (newTitle != null)
                {
                    updatedAlbum.Title = newTitle;
                }
                else
                {
                    updatedAlbum.Title = album.Title;
                }

                if (newProducer != null)
                {
                    updatedAlbum.Producer = newProducer;
                }
                else
                {
                    updatedAlbum.Producer = album.Producer;
                }

                if (newYear != null)
                {
                    updatedAlbum.Year = newYear.Value;
                }
                else
                {
                    updatedAlbum.Year = album.Year;
                }

                HttpResponseMessage innerResponse = null;

                if (client.DefaultRequestHeaders.Accept.Contains(new MediaTypeWithQualityHeaderValue("application/xml")))
                {
                    innerResponse = client.PutAsXmlAsync<Album>("api/Album/" + id, updatedAlbum).Result;
                }
                else if (client.DefaultRequestHeaders.Accept.Contains(new MediaTypeWithQualityHeaderValue("application/json")))
                {
                    innerResponse = client.PutAsJsonAsync<Album>("api/Album/" + id, updatedAlbum).Result;
                }

                if (innerResponse == null)
                {
                    throw new InvalidOperationException("Client must use json or xml.");
                }

                if (innerResponse.IsSuccessStatusCode)
                {
                    Console.WriteLine("Update successful.");
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)innerResponse.StatusCode, innerResponse.ReasonPhrase);
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        public static void UpdateSong(HttpClient client, int id, string newTitle = null,
            string newGenre = null, int? newYear = null)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException("Id must be a positive integer.");
            }

            HttpResponseMessage response = client.GetAsync("api/Song/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var song = response.Content.ReadAsAsync<SerializableSong>().Result;

                Song updatedSong = new Song();
                updatedSong.SongId = id;

                if (newTitle != null)
                {
                    updatedSong.Title = newTitle;
                }
                else
                {
                    updatedSong.Title = song.Title;
                }

                if (newGenre != null)
                {
                    updatedSong.Genre = newGenre;
                }
                else
                {
                    updatedSong.Genre = song.Genre;
                }

                if (newYear != null)
                {
                    updatedSong.Year = newYear.Value;
                }
                else
                {
                    updatedSong.Year = song.Year;
                }

                HttpResponseMessage innerResponse = null;

                if (client.DefaultRequestHeaders.Accept.Contains(new MediaTypeWithQualityHeaderValue("application/xml")))
                {
                    innerResponse = client.PutAsXmlAsync<Song>("api/Song/" + id, updatedSong).Result;
                }
                else if (client.DefaultRequestHeaders.Accept.Contains(new MediaTypeWithQualityHeaderValue("application/json")))
                {
                    innerResponse = client.PutAsJsonAsync<Song>("api/Song/" + id, updatedSong).Result;
                }

                if (innerResponse == null)
                {
                    throw new InvalidOperationException("Client must use json or xml.");
                }

                if (innerResponse.IsSuccessStatusCode)
                {
                    Console.WriteLine("Update successful.");
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)innerResponse.StatusCode, innerResponse.ReasonPhrase);
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }
    }
}
