using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.NextDate
{
    class Program
    {
        static void Main()
        {
            ushort day, month, year;
            day = ushort.Parse(Console.ReadLine());
            month= ushort.Parse(Console.ReadLine());
            year = ushort.Parse(Console.ReadLine());
            DateTime date = new DateTime(year, month, day);
            date=date.AddDays(1);
            Console.WriteLine(date.Day+"."+date.Month+"."+date.Year);
            
        }
    }
}
