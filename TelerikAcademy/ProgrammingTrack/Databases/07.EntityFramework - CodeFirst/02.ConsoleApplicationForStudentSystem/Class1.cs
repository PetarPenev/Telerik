using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01.StudentSystem.Data;
using _01StudentSystem.Model;
using _01.StudentSystem.Data.Migrations;
using System.Data.Entity;

namespace _02.ConsoleApplicationForStudentSystem
{
    public class Program
    {
        public static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentSystemContext, Configuration>());           

            // Database is seeded immediately after opening.
            using (StudentSystemContext context = new StudentSystemContext())
            {       
                foreach (var student in context.Students)
                {
                    Console.WriteLine("Student #" + student.FacultyNumber + " is enrolled in " + student.Courses.Count + " courses");
                }

                foreach (var selectedCourse in context.Courses)
                {
                    Console.WriteLine(selectedCourse.Name + " has " + selectedCourse.Students.Count + " students enrolled.");
                }
            }            
        }
    }
}