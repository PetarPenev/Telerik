using System;
using System.Collections.Generic;



namespace LibrarySchool
{
    public class Test
    {
        public static void Main()
        {
            List<Student> listOfStudents = new List<Student>();
            listOfStudents.Add(new Student("Georgi", 1));
            listOfStudents.Add(new Student("Kalina", 2));
            listOfStudents.Add(new Student("Sandy", 3));

            List<Teacher> listOfTeachers = new List<Teacher>();
            listOfTeachers.Add(new Teacher("Ivanov", new List<Discipline>()));
            listOfTeachers.Add(new Teacher("Hristova", new List<Discipline>()));
            listOfTeachers[0].AddDiscipline(new Discipline("Maths",4,2));
            listOfTeachers[0].AddDiscipline(new Discipline("Physics",3,2));
            listOfTeachers[0].AddComment("Substitute Physics Teacher");
            listOfTeachers[0].AddComment("Graduated from Plovdiv University");
            listOfTeachers[1].AddDiscipline(new Discipline("Arts",4,2,"Art is cool...sometimes"));

            ClassInSchool cl = new ClassInSchool(listOfStudents, listOfTeachers,"first class", "The only class");
            School theSchool = new School(new List<ClassInSchool>());
            theSchool.AddClass(cl);
            Console.WriteLine(theSchool);
        }
    }
}
