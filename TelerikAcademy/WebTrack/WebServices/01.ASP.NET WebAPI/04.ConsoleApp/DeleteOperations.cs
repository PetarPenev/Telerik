using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace _04.ConsoleApp
{
    public static class DeleteOperations
    {
        public static void DeleteArtist(HttpClient client, int id)
        {
            HttpResponseMessage response = client.DeleteAsync("api/Artist/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Artist deleted.");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        public static void DeleteAlbum(HttpClient client, int id)
        {
            HttpResponseMessage response = client.DeleteAsync("api/Album/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Album deleted.");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        public static void DeleteSong(HttpClient client, int id)
        {
            HttpResponseMessage response = client.DeleteAsync("api/Song/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Song deleted.");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }
    }
}
