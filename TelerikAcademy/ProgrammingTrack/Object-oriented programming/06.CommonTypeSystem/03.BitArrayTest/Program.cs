using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.BitArrayTest
{
    class Program
    {
        static void Main()
        {
            // Testing the class
            BitArray64 bitArr = new BitArray64(32);
            // Changing values
            Console.WriteLine(bitArr[5]);
            bitArr[5] = 0;
            Console.WriteLine(bitArr[5]);
            bitArr[5] = 1;
            BitArray64 bitArray = new BitArray64(32);
            BitArray64 bitArrayThree = new BitArray64(64);
            // Should be equal
            Console.WriteLine(bitArr.Equals(bitArray));
            // Should not be equal
            Console.WriteLine(bitArr.Equals(bitArrayThree));
            // Testing ToString
            Console.WriteLine(bitArr);
            Console.WriteLine(bitArrayThree);
        }
    }
}
