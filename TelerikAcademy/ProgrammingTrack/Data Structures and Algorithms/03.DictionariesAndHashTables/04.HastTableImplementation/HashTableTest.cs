namespace _04.HashTableImplementation
{
    using System;
    using System.Collections.Generic;

    public class HashTableTest
    {
        public static void Main()
        {
            NewHashTable<string, int> table = new NewHashTable<string, int>();

            table.Add("Anna-Maria", 1);
            table.Add("Kristina", 2);
            table.Add("Ivena", 3);
            table.Add("Boyan", 4);
            table.Add("Zvezdomir", 5);
            table.Add("Gloria", 6);
            table.Add("Ana", 7);
            table.Add("Galina", 8);
            table.Add("Stoyanka", 9);
            table.Add("Yavor", 10);
            table.Add("Adam", 11);
            table.Add("Asen", 12);
            table.Add("Todor", 13);
            table.Add("Yana", 14);
            table.Add("Martin", 15);
            table.Add("Damyan", 16);
            table.Add("Vladimir", 17);
            table.Add("Elica", 18);

            // The array is already doubled. Let us check that adding duplicate keys still throws an exception.
            try
            {
                table.Add("Vladimir", 17);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Success!");
            }

            Console.WriteLine();

            // Let us check if find and remove work correctly.
            Console.WriteLine(table.Find("Damyan"));
            table.Remove("Damyan");
            try
            {
                table.Find("Damyan");
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Success!");
            }

            Console.WriteLine();

            // Let's check indexing.
            Console.WriteLine(11 == table["Adam"]);
            table["Adam"] = 14;
            Console.WriteLine(14 == table["Adam"]);

            // Foreaching test.
            foreach (var pair in table)
            {
                Console.WriteLine("{0} -> {1}", pair.Key, pair.Value);
            }

            Console.WriteLine();

            // Finally let us clear.
            table.Clear();
            Console.WriteLine(table.Count == 0);        
        }
    }
}
