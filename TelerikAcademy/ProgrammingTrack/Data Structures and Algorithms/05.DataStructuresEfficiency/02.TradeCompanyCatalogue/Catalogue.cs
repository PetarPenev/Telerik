namespace _02.TradeCompanyCatalogue
{
    using System;
    using System.Diagnostics;
    using System.Text;
    using Wintellect.PowerCollections;

    public class Catalogue
    {
        public static void Main()
        {
            OrderedMultiDictionary<decimal, Article> catalogue = new OrderedMultiDictionary<decimal, Article>(true);
            Random randomGenerator = new Random();
            Stopwatch watch = new Stopwatch();

            watch.Start();
            for (int i = 0; i < 10000; i++)
            {
                Article newArticle = new Article(string.Empty + randomGenerator.Next(10000000, 99999999), "Soap" + i % 100,
                    (decimal)(randomGenerator.NextDouble() * randomGenerator.Next(1, 100)), "Shop" + i % 10);
                catalogue[newArticle.Price].Add(newArticle);
            }

            var collection = catalogue.Range(20, true, 30, true);
            watch.Stop();
            Console.WriteLine("Time to execute query: {0}", watch.Elapsed);

            StringBuilder resultTestRepresentation = new StringBuilder();
            foreach (var item in collection.Values)
            {
                resultTestRepresentation.AppendLine(item.ToString());
            }

            Console.WriteLine(resultTestRepresentation);
        }
    }
}
