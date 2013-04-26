using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    // 5 Task - Implement the generic list class
    // We impose a restriction on T - to implement the IComparable and IComparable<T> interfaces so that
    // the operation "CompareTo" is defined.
    public class MyGenericList<T> where T:IComparable, IComparable<T>
    {
        // Fields
        private T[] arr;

        private int currentIndex;

        private int capacity;
        
        public T[] Arr
        {
            get { return arr; }
            private set { arr = value; }
        }

        public T this[int index]
        {
            get {
                if ((index < 0) || (index >= this.Arr.Length))
                    throw new IndexOutOfRangeException("Specified index is outside the boundaries of the list.");
                return this.Arr[index];
            }
            private set {
                if ((index < 0) || (index >= this.Arr.Length))
                    throw new IndexOutOfRangeException("Specified index is outside the boundaries of the list.");
                this.Arr[index] = value;
            }
        }

       

        public int CurrentIndex
        {
            get { return currentIndex; }
            private set { currentIndex = value; }
        }

       

        public int Capacity
        {
            get { return capacity; }
            private set { capacity = value; }
        }

        public MyGenericList(int capacity)
        {
            if (capacity <= 0)
                throw new ArgumentException("Capacity must be a positive integer number");
            this.Arr = new T[capacity];
            this.CurrentIndex = 0;
            this.Capacity = capacity;
        }

        public void AddElement(T element)
        {
            if (currentIndex == this.Arr.Length - 1)
                AutoGrow();
            this.Arr[currentIndex] = element;
            currentIndex++;
        }

        // 6 Task - The AutoGrow functionality plus the other methods required.
        private void AutoGrow()
        {
            T[] tempArr = new T[this.Arr.Length * 2];
            Array.Copy(this.Arr, tempArr, this.Arr.Length);
            this.Arr = tempArr;
        }

        public void RemoveElement(int index)
        {
            if ((index >= this.Arr.Length) || (index < 0))
                throw new ArgumentOutOfRangeException("Index out of range");
            T[] arrCopy = new T[this.Arr.Length-1];
            for (int i = 0; i < index; i++)
                arrCopy[i] = this.Arr[i];
            for (int i = index; i < this.Arr.Length - 1; i++)
                arrCopy[i] = this.Arr[i + 1];
            this.Arr = arrCopy;
            this.CurrentIndex--;
        }

        public void InsertElement(T element, int position)
        {
            if ((position < 0) || (position >= this.Arr.Length))
                throw new ArgumentOutOfRangeException("Position for insertion out of range.");
            T[] arrCopy = new T[this.Arr.Length + 1];
            for (int i = 0; i < position; i++)
                arrCopy[i] = this.Arr[i];
            arrCopy[position] = element;
            for (int i = position + 1; i < this.Arr.Length + 1; i++)
                arrCopy[i] = this.Arr[i - 1];
            this.Arr = arrCopy;
            this.CurrentIndex = this.Arr.Length;
        }

        // Here we initialize new array with default capacity and set the current index to 0.
        public void ClearList()
        {
            this.Arr = new T[this.Capacity];
            this.CurrentIndex = 0;
        }

        public int FindIndex(T element)
        {
            return Array.IndexOf(arr, element);
        }

        public override string ToString()
        {
            return String.Join(" ; ", this.Arr.Take<T>(this.currentIndex));
        }
        

        // 7 Task -Implement Min and Max methods

        // When the array is empty, the Min method returns (besides notifying the user that the array is empty) the default
        // value for the type.
        public T Min()
        {
            if (this.Arr.Length==0)
            {
                Console.WriteLine("The list is empty!");
                return default(T);
            }
            T minimum = this.Arr[0];
            for (int i = 1; i < currentIndex; i++)
                if (minimum.CompareTo(this.Arr[i]) > 0)
                    minimum = this.Arr[i];
            return minimum;
        }

        // When the array is empty, the Max method returns (besides notifying the user that the array is empty) the default
        // value for the type.
        public T Max()
        {
            if (this.Arr.Length == 0)
            {
                Console.WriteLine("The list is empty!");
                return default(T);
            }
            T maximum = this.Arr[0];
            for (int i = 1; i < currentIndex; i++)
                if (maximum.CompareTo(this.Arr[i])<0)
                    maximum = this.Arr[i];
            return maximum;
        }
    }
}
