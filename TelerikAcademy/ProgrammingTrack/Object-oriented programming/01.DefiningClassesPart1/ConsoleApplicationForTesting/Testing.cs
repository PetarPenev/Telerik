using System;
using System.Text;
using Library;
using System.Threading;
using System.Globalization;

namespace ConsoleApplicationForTesting
{
    class Testing
    {
        static void Main()
        {
            // This is a console application to test our classes.
            try
            {
                Console.OutputEncoding = Encoding.UTF8;
                Thread.CurrentThread.CurrentCulture = new CultureInfo("de");
                GSMTest firstTest = new GSMTest();
                firstTest.ArrayDisplay();
                GSMCallHistoryTest secondTest = new GSMCallHistoryTest();
                secondTest.Test();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
