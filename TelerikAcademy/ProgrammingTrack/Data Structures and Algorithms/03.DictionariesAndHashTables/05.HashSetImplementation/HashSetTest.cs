namespace _05.HashSetImplementation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class HashSetTest
    {
        public static void Main()
        {
            NewHashSet<string> hashSet = new NewHashSet<string>();

            hashSet.Add("Anna");
            hashSet.Add("Maria");
            hashSet.Add("Irina");
            hashSet.Add("Hristina");
            hashSet.Add("Stoyanka");

            Console.WriteLine(hashSet.Find("Irina"));
            Console.WriteLine(hashSet.Find("Tutmanik"));
            Console.WriteLine();

            Console.WriteLine(hashSet.Find("Maria"));
            hashSet.Remove("Maria");
            Console.WriteLine(hashSet.Find("Maria"));
            Console.WriteLine();

            NewHashSet<string> otherHashSet = new NewHashSet<string>();
            otherHashSet.Add("Velichka");
            otherHashSet.Add("Irina");
            otherHashSet.Add("Anna");
            otherHashSet.Add("Tutmanik");

            Console.WriteLine("Testing Union and foreach");
            NewHashSet<string> unionSet = hashSet.Union(otherHashSet);

            // Note: the hashSet contains 4 elements - Maria is already removed. So the unionSet contains all the 6 elements
            // that should be in it.
            foreach (var element in unionSet)
            {
                Console.WriteLine(element);
            }

            Console.WriteLine();

            Console.WriteLine("Testing Intersect");
            NewHashSet<string> intersectSet = hashSet.Intersect(otherHashSet);
            foreach (var element in intersectSet)
            {
                Console.WriteLine(element);
            }
        }
    }
}
