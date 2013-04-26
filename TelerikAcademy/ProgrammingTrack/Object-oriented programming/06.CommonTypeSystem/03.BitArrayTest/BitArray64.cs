using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.BitArrayTest
{
    // Task 5 - representing an array of 0s and 1s as a ulong variable in the class
    public class BitArray64 :IEnumerable<int>
    {
        // Fields and properties
        private ulong number;

        public ulong Number
        {
            get { return number; }
            private set { number = value; }
        }
        

        // Constructor
        public BitArray64(ulong number)
        {
            this.Number = number;
        }

        // Indexer - getting the values with bitwise operations
        public int this[int index]
        {
            get
            {
                if ((index < 0) || (index > 63))
                    throw new ArgumentException("Index out of ulong's range.");
                return (int)(this.Number >> index) & 1; 
            }
            set
            {
                if ((index < 0) || (index > 63))
                    throw new ArgumentException("Index out of ulong's range.");
                if (value == 0)
                {
                    this.Number = this.Number & (~((ulong)1 << index));
                }
                else if (value == 1)
                {
                    this.Number = this.Number | ((ulong)(1 << index));
                }
                else
                {
                    throw new ArgumentException("Can only assign 0 or 1 to a position in the ulong variable.");
                }
            }
        }

        // Implementing IEnumerable<int>
        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 63; i >= 0; i--)
            {
                yield return this[i];
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        // Overriding Equals
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            BitArray64 comparer = obj as BitArray64;
            if (comparer == null)
                return false;
            if (comparer.Number != this.Number)
                return false;
            return true;
        }

        public override int GetHashCode()
        {
            return this.Number.GetHashCode();
        }

        // Overriding the operators
        public static bool operator ==(BitArray64 one, BitArray64 two)
        {
            return one.Equals(two);
        }

        public static bool operator !=(BitArray64 one, BitArray64 two)
        {
            return !one.Equals(two);
        }

        // Overriding ToString
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(String.Format("The BitArray is: "+ Environment.NewLine));
            foreach (var c in this)
            {
                sb.Append(c+" ");
            }
            return sb.ToString();
        }
    }
}
