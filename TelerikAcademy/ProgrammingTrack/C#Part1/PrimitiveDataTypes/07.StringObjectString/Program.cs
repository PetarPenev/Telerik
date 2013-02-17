using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.StringObjectString
{
    class Program
    {
        static void Main()
        {
            string string1, string2, string3;
            object object1;
            string1 = "Hello";
            string2 = "World";
            object1 = string1 + " " + string2;
            string3 = (string)object1;
            Console.WriteLine(string3);
        }
    }
}
