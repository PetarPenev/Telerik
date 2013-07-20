namespace _02.ProductsInPriceRange
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class Program
    {
        public static void Main()
        {
            OrderedBag<Product> bag = new OrderedBag<Product>();
            Random randomGenerator = new Random();

            for (int i = 0; i < 500000; i++)
            {
                string name = string.Empty;
                if (i % 3 == 0)
                {
                    name = "brush";
                }
                else if (i % 3 == 1)
                {
                    name = "banana";
                }
                else
                {
                    name = "shoes";
                }

                decimal price = 0.75m * randomGenerator.Next(1, 1000000);

                Product newProduct = new Product(name, price);
                bag.Add(newProduct);
            }

            Stopwatch watch = new Stopwatch();
            for (int i = 0; i < 100000; i++)
            {
                int start = randomGenerator.Next(1, 1000000);
                int finish = randomGenerator.Next(start, 1000000);

                watch.Start();
                var result = SearchRange(bag, start, finish);
                watch.Stop();
            }

            Console.WriteLine(watch.Elapsed);

            List<int> list = new List<int>();
            for (int i = 0; i < 10000; i++)
            {
                list.Add(i);
            }

            var resulta = list.Take(20);
            Console.WriteLine(resulta);
        }

        public static IEnumerable<Product> SearchRange(OrderedBag<Product> bag, int start, int end)
        {
            var collection = bag.Range(new Product("test", start), true, new Product("test", end), true);

            // For some (unknown) reason while debugging the "count" property of list will always be 0. However,
            // if you click on Results View in the debugger you will see that it contains the right number of elements.
            var list = collection.Take(20);

            return list;
        }
    }
}
