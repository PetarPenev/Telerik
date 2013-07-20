namespace _01.SortedCoursesFromFile
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using Wintellect.PowerCollections;

    public class SortedCourses
    {
        public static void Main()
        {
            // I decided to play with the data structures a bit instead of creating a new class
            // for the student that implements IComparable.
            SortedDictionary<string, SortedDictionary<string, OrderedBag<string>>> courseData =
                new SortedDictionary<string, SortedDictionary<string, OrderedBag<string>>>();
            string filePath = "courses.txt";

            using (StreamReader reader = new StreamReader(filePath))
            {
                var line = reader.ReadLine();

                while (!string.IsNullOrEmpty(line))
                {
                    var parameters = line.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        parameters[i] = parameters[i].Trim();
                    }

                    if (courseData.Keys.Contains(parameters[2]))
                    {
                        if (courseData[parameters[2]].Keys.Contains(parameters[1]))
                        {
                            courseData[parameters[2]][parameters[1]].Add(parameters[0]);
                        }
                        else
                        {
                            courseData[parameters[2]].Add(parameters[1], new OrderedBag<string>());
                            courseData[parameters[2]][parameters[1]].Add(parameters[0]);
                        }
                    }
                    else
                    {
                        courseData.Add(parameters[2], new SortedDictionary<string, OrderedBag<string>>());
                        courseData[parameters[2]].Add(parameters[1], new OrderedBag<string>());
                        courseData[parameters[2]][parameters[1]].Add(parameters[0]);
                    }

                    line = reader.ReadLine();
                }
            }

            foreach (var course in courseData.Keys)
            {
                StringBuilder courseTextRepresentation = new StringBuilder();
                courseTextRepresentation.Append(string.Format("{0} : ", course));
                foreach (var familyName in courseData[course].Keys)
                {
                    foreach (var firstName in courseData[course][familyName])
                    {
                        courseTextRepresentation.Append(string.Format("{0} {1}, ", firstName, familyName));
                    }
                }

                Console.WriteLine(courseTextRepresentation.ToString().TrimEnd(new char[] { ',', ' ' }));
            }
        }
    }
}
