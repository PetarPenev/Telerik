using System;
using System.Collections.Generic;
using System.Linq;


namespace ThirdTaskLibrary
{
    public static class CalculateAgeAndTestSounds
    {
        // A static class that test a list of animals for the sounds they make and the average age by type
        public static void TestSounds(List<Animal> listOfAnimals)
        {
            foreach (Animal c in listOfAnimals)
            {
                Console.Write("{0}:", c.Name);
                c.MakeSound();
            }

        }

        public static void CalculateAverageAge(List<Animal> listOfAnimals)
        {
            var averageAges = 
                from animal in listOfAnimals
                group animal by animal.GetType() into animalsByType
                select new Tuple<string,decimal>(animalsByType.Key.Name, (decimal)animalsByType.Average(x=>x.Age));
            foreach (var c in averageAges)
                Console.WriteLine("{0}:{1}",c.Item1,c.Item2);
        }
    }
}
