using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01.TelerikAcademyModel;
using System.Diagnostics;

namespace _03.PerformanceToList
{
    public class Program
    {
        public static void SlowToListOperation()
        {
            using (TelerikAcademyEntities context = new TelerikAcademyEntities())
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();

                var sofiaEmployees = context.Employees.Select(e => e).ToList().Select(e => e.Address).ToList().Select(a => a.Town).
                    ToList().Where(t => t.Name.ToLower() == "sofia");

                Console.WriteLine("Sofia employee count = {0}.", sofiaEmployees.Count());
                watch.Stop();
                Console.WriteLine("Slow operations executed in {0} milliseconds.", watch.Elapsed.Milliseconds);
            }
        }

        public static void FastToListOperation()
        {
            using (TelerikAcademyEntities context = new TelerikAcademyEntities())
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();

                var sofiaEmployees = context.Employees.Select(e => e).Select(e => e.Address).Select(a => a.Town)
                    .Where(t => t.Name.ToLower() == "sofia");

                Console.WriteLine("Sofia employee count = {0}.", sofiaEmployees.Count());
                watch.Stop();
                Console.WriteLine("Fast operations executed in {0} milliseconds.", watch.Elapsed.Milliseconds);
            }
        }

        public static void Main()
        {
            SlowToListOperation();
            FastToListOperation();
        }
    }
}