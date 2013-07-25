using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01.TelerikAcademyModel;
using System.Diagnostics;

namespace _02.PerformanceSelectQueries
{
    public class Program
    {
        public static void SlowEmployeeQuery()
        {
            using (TelerikAcademyEntities context = new TelerikAcademyEntities())
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var employees = from employee in context.Employees
                                select new
                                {
                                    Name = employee.LastName,
                                    Department = employee.Department.Name,
                                    Town = employee.Address.Town.Name
                                };

                /*foreach (var employee in employees)
                {
                    Console.WriteLine("{0} from department {1} lives in {2}.", employee.Name, employee.Department, employee.Town);
                }*/

                watch.Stop();
                Console.WriteLine("Slow operations executed in {0} milliseconds.", watch.Elapsed.Milliseconds);
            }
        }

        public static void FastEmployeeQuery()
        {
            using (TelerikAcademyEntities context = new TelerikAcademyEntities())
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var employees = from employee in context.Employees.Include("Department").Include("Address").Include("Town")
                                select new
                                {
                                    Name = employee.LastName,
                                    Department = employee.Department.Name,
                                    Town = employee.Address.Town.Name
                                };

                /*foreach (var employee in employees)
                {
                    Console.WriteLine("{0} from department {1} lives in {2}.", employee.Name, employee.Department, employee.Town);
                }*/

                watch.Stop();
                Console.WriteLine("Fast operations executed in {0} milliseconds.", watch.Elapsed.Milliseconds);
            }
        }

        public static void Main()
        {
            SlowEmployeeQuery();
            FastEmployeeQuery();
        }
    }
}