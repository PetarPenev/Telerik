using System;
using Library;

namespace Library
{
    // 7 Task - create a class GSM Test
    public class GSMTest
    {
        static GSM[] array = new GSM[3] {
        new GSM("Samsung", "Galaxy S"),
        new GSM("Nokia", "Lumia", "Pesho", 300),
        new GSM("Siemens", "AX72", "Gosho", 100, new Battery("101",220,5, BatteryType.LiIon), new Display(3.2m, 65000))
        };

        public void ArrayDisplay()
        {
            foreach (var c in array)
            {
                Console.WriteLine(c);
            }
            Console.WriteLine(GSM.IPhone4S);
        }

    }
}
