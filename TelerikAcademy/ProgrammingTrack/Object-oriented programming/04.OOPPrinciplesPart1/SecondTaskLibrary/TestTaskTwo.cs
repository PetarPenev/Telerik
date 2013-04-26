using System;
using System.Collections.Generic;
using System.Linq;


namespace SecondTaskLibrary
{
    public class TestTaskTwo
    {
        public static void Main()
        {
            // Sorting a list of 10 students by grade
            List<Student> listOfStudents = new List<Student>();
            listOfStudents.Add(new Student("Ivo", "Karamfilov", 5));
            listOfStudents.Add(new Student("Acho", "Georgiev", 3.22m));
            listOfStudents.Add(new Student("Ivelina", "Zamfirova", 6));
            listOfStudents.Add(new Student("Larry", "Paige", 5.88m));
            listOfStudents.Add(new Student("Sergey", "Brin", 5.99m));
            listOfStudents.Add(new Student("Larry", "Elison", 4.01m));
            listOfStudents.Add(new Student("Jack", "Dorsey", 5.11m));
            listOfStudents.Add(new Student("Strahil", "Chavadarov", 5));
            listOfStudents.Add(new Student("Strahil", "Chavdaronov", 4.99m));
            listOfStudents.Add(new Student("Lilia", "Ivanova", 3.66m));
            var sortedByGrade = listOfStudents.OrderBy(student => student.Grade);
            Console.WriteLine("Order Students by grade:");
            foreach (Student c in sortedByGrade)
                Console.WriteLine(c);

            // Sorting a list of 10 workers by money per hour in descendng order
            Console.WriteLine();
            List<Worker> listOfWorkers = new List<Worker>();
            listOfWorkers.Add(new Worker("Spas", "Trayanov", 2000, 6));
            listOfWorkers.Add(new Worker("Zamfir", "Iliev", 150, 8));
            listOfWorkers.Add(new Worker("Tihomir", "Karagiozov", 220, 8));
            listOfWorkers.Add(new Worker("Stashil", "Nunev", 100, 7));
            listOfWorkers.Add(new Worker("Ivan", "Iliev", 80, 8));
            listOfWorkers.Add(new Worker("Nevenka", "Kirova", 400, 5));
            listOfWorkers.Add(new Worker("Svastimira", "Ilieva", 150, 11));
            listOfWorkers.Add(new Worker("Svetlin", "Hristov", 500, 8));
            listOfWorkers.Add(new Worker("Petia", "Svetoslavova", 500, 8));
            listOfWorkers.Add(new Worker("Hristivan", "Despotov", 700, 10));
            var sortedByMoneyPerHour = listOfWorkers.OrderByDescending(worker => worker.MoneyPerHour());
            Console.WriteLine("Order workers by hourly pay:");
            foreach (Worker w in sortedByMoneyPerHour)
                Console.WriteLine(w);
            Console.WriteLine();

            // Merging the lists and ordering them by name
            List<Human> listOfWorkersToMerge = new List<Human>(listOfWorkers);
            List<Human> listOfStudentsToMerge = new List<Human>(listOfStudents);
            var mergedList = listOfStudentsToMerge.Union(listOfWorkersToMerge).OrderBy(human => human.FirstName).ThenBy(human => human.LastName);
            Console.WriteLine("Order everybody by name:");
            foreach (Human c in mergedList)
                Console.WriteLine(c);
        }
    }
}
