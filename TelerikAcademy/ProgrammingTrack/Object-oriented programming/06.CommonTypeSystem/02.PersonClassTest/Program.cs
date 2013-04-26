using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.PersonClassTest
{
    class Program
    {
        static void Main()
        {
            // Testing Task 4
            Person personFirst = new Person("John", 5);
            Person personSecond = new Person("Tom");
            Console.WriteLine(personFirst);
            Console.WriteLine(personSecond);
        }
    }
}
