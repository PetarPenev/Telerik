using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.ConsoleClient
{
    class Program
    {
        static void Main()
        {
            // In order for this to work, you have to start the 03.StringCountConsoleHost project.
            // If it throws an error, make sure you are running VisualStudio as administrator, otherwise it will not work.
            StringCountClient client = new StringCountClient();
            Console.WriteLine("The number of occurances here is {0}", client.GetStringCount("ba", "badaba"));
        }
    }
}
