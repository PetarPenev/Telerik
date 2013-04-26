using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.StudentClassTest
{
    class Program
    {
        static void Main()
        {
            // Testing Task 1
            Student student = new Student("John", "Carmack", "Doe", 234345567, "Matilda blvd.", 
                "john@microsoft.com", "021481421", 3, Specialities.Chemistry, 
                Faculties.Chemistry, Universities.PlovdivUniversity);

            Student otherStudent = new Student("Dale", "Jahnson", "Carnegie", 211111312, "Dale Avenue",
                "dale@microsoft.com", "828424141", 2, Specialities.Economics,
                Faculties.Economics, Universities.UNSS);
            Console.WriteLine(student);
            Console.WriteLine("student equals otherStudent: {0}", student.Equals(otherStudent));

            // Testing Task 2
            Student clonedStudent = student.Clone() as Student;
            Console.WriteLine("student equals clonedStudent: {0}", student.Equals(clonedStudent));

            // Testing Task 3
            Console.WriteLine("Comparing student and clonedStudent: student {0} clonedStudent.", (student.CompareTo(clonedStudent) == 0) ? "=" : (student.CompareTo(clonedStudent) > 0) ? ">":"<");
            Console.WriteLine("Comparing student and otherStudent: student {0} otherStudent.", (student.CompareTo(otherStudent) == 0) ? "=" : (student.CompareTo(otherStudent) > 0) ? ">" : "<");
        }
    }
}
