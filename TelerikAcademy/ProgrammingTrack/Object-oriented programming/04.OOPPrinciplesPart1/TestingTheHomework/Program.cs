using System;
using System.Collections.Generic;
using LibrarySchool;
using SecondTaskLibrary;
using ThirdTaskLibrary;

namespace TestingTheHomework
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Testing Task 1");
            Test.Main();
            Console.WriteLine();
            Console.WriteLine("Testing Task 2");
            TestTaskTwo.Main();
            Console.WriteLine();
            Console.WriteLine("Testing Task 3");

            // Testing the 3 task by creating a list of different animals and then calling the already written static test methods
            List<Animal> listOfAnimals=new List<Animal>(){new Tomcat("Tom",'m',3),
            new Kitten("Tomina",'f',2),
            new Kitten("Kitty",'f',7),
            new Tomcat("Jurassic",'m',8),
            new Tomcat("Speedy",'m',7),
            new Dog("Rita",'f',11),
            new Dog("Gonzalo",'m',1),
            new Dog("Jenny",'f',1),
            new Frog("Kermit",'m',19),
            new Frog("Lucretia",'f',17)};
            CalculateAgeAndTestSounds.TestSounds(listOfAnimals);
            Console.WriteLine();
            CalculateAgeAndTestSounds.CalculateAverageAge(listOfAnimals);

        }
    }
}
