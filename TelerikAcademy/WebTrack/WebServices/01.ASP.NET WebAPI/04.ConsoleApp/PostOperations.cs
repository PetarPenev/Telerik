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
    public static class PostOperations
    {
        public static void AddAlbum(HttpClient client, Album album)
        {
            HttpResponseMessage response = null;

            if (client.DefaultRequestHeaders.Accept.Contains(new MediaTypeWithQualityHeaderValue("application/xml")))
            {
                response = client.PostAsXmlAsync<Album>("api/Album/", album).Result;
            }
            else if (client.DefaultRequestHeaders.Accept.Contains(new MediaTypeWithQualityHeaderValue("application/json")))
            {
                response = client.PostAsJsonAsync<Album>("api/Album/", album).Result;
            }

            if (response == null)
            {
                throw new InvalidOperationException("Client must use json or xml.");
            }

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Album added.");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        public static void AddArtist(HttpClient client, Artist artist)
        {
            HttpResponseMessage response = null;

            if (client.DefaultRequestHeaders.Accept.Contains(new MediaTypeWithQualityHeaderValue("application/xml")))
            {
                response = client.PostAsXmlAsync<Artist>("api/Artist", artist).Result;
            }
            else if (client.DefaultRequestHeaders.Accept.Contains(new MediaTypeWithQualityHeaderValue("application/json")))
            {
                response = client.PostAsJsonAsync<Artist>("api/Artist", artist).Result;
            }

            if (response == null)
            {
                throw new InvalidOperationException("Client must use json or xml.");
            }

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Artist added.");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        public static void AddSong(HttpClient client, Song song)
        {
            HttpResponseMessage response = null;

            if (client.DefaultRequestHeaders.Accept.Contains(new MediaTypeWithQualityHeaderValue("application/xml")))
            {
                response = client.PostAsXmlAsync<Song>("api/Song", song).Result;
            }
            else if (client.DefaultRequestHeaders.Accept.Contains(new MediaTypeWithQualityHeaderValue("application/json")))
            {
                response = client.PostAsJsonAsync<Song>("api/Song", song).Result;
            }

            if (response == null)
            {
                throw new InvalidOperationException("Client must use json or xml.");
            }

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Song added.");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }
    }
}
