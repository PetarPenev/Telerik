using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.NullValues
{
    class Program
    {
        static void Main()
        {
            int? a = null;
            double? b = null;
            a=a + null;
            b = b + 1;
            Console.WriteLine("{0} and {1}" , a, b);
            
        }
    }
}
