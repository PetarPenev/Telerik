using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _02.ConsoleClient.DayService;

namespace _02.ConsoleClient
{
    class Program
    {
        static void Main()
        {
            // Start the 01.DayReturnerService project in order for this to work.
            DayServiceClient client = new DayServiceClient();
            string dayName = client.GetDate(DateTime.Now);
            Console.WriteLine(dayName);
        }
    }
}
