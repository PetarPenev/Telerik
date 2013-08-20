using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace _01.FeedzillaApp
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Please enter the query string.");
            string query = Console.ReadLine();
            Console.WriteLine("Please enter the count of the articles.");
            int count = int.MinValue;
            bool isNumber = int.TryParse(Console.ReadLine(), out count);
            while ((!isNumber) || (count <= 0))
            {
                Console.WriteLine("Please enter a positive integer number.");
                isNumber = int.TryParse(Console.ReadLine(), out count);
            }

            string queryUrl = "http://api.feedzilla.com/v1/articles/search.json?q=" + query + "&count=" + count;
            string mediaType = "application/json";

            var articles = GetArticles(queryUrl, mediaType, query, count);

            foreach (var article in articles)
            {
                Console.WriteLine("Title: {0}, Url: {1}", article.Title, article.Url);
            }
        }

        private static IEnumerable<Article> GetArticles(string queryUrl, string mediaType, string query, int count)
        {
            HttpClient client = new HttpClient();

            HttpRequestMessage request = new HttpRequestMessage();
            request.RequestUri = new Uri(queryUrl);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType));
            request.Method = HttpMethod.Get;

            var response = client.SendAsync(request).Result;
            var result = response.Content.ReadAsStringAsync().Result;
            Wrapper answerClass = JsonConvert.DeserializeObject<Wrapper>(result);

            return answerClass.Articles;
        }
    }
}