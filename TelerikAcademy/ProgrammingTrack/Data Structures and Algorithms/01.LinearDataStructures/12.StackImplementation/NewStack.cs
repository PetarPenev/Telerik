namespace _12.StackImplementation
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Text;

    public class NewStack<T>
    {
        private T[] stackArray;

        private int topPointer;

        public NewStack(uint initialArraySize)
        {
            this.stackArray = new T[initialArraySize];
            this.topPointer = -1;
        }

        public int Count
        {
            get
            {
                return this.topPointer + 1;
            }
        }

        public void Push(T itemToPush)
        {
            Debug.Assert(this.topPointer < this.stackArray.Length, "The pointer incorrectly points outside the array.");

            if (this.topPointer == this.stackArray.Length - 1)
            {
                this.ResizeStackArray();
            }

            this.topPointer++;
            this.stackArray[this.topPointer] = itemToPush;
        }

        public T Pop()
        {
            Debug.Assert(this.topPointer < this.stackArray.Length, "The pointer incorrectly points outside the array.");

            if (this.Count == 0)
            {
                throw new ArgumentOutOfRangeException("There are no elements in the stack.");
            }

            T itemToReturn = this.stackArray[this.topPointer];
            this.topPointer--;
            return itemToReturn;
        }

        public T Peek()
        {
            Debug.Assert(this.topPointer < this.stackArray.Length, "The pointer incorrectly points outside the array.");

            if (this.Count == 0)
            {
                throw new ArgumentOutOfRangeException("There are no elements in the stack.");
            }

            T itemToReturn = this.stackArray[this.topPointer];
            return itemToReturn;
        }

        public void Clear()
        {
            // We are not resizing the stack array because that will require additional processor time and its only
            // benefit will be saving some memory but, since we assume that the stack will be used with constant
            // flow of elements in it, it will be better to save the future need to double it to its current size again.
            this.topPointer = -1;
        }

        public bool Contains(T elementToFind)
        {
            bool containsElement = false;

            for (int i = 0; i <= this.topPointer; i++)
            {
                if (this.stackArray[i].Equals(elementToFind))
                {
                    containsElement = true;
                    break;
                }
            }

            return containsElement;
        }

        public T[] ToArray()
        {
            T[] arrayToReturn = new T[this.Count];
            for (int i = 0; i < this.Count; i++)
            {
                arrayToReturn[i] = this.stackArray[i];
            }

            return arrayToReturn;
        }

        public void TrimExcess()
        {
            T[] newArray = new T[this.Count];

            for (int i = 0; i < this.Count; i++)
            {
                newArray[i] = this.stackArray[i];
            }

            this.stackArray = newArray;
        }

        public override string ToString()
        {
            StringBuilder representation = new StringBuilder("From top to bottom:" + Environment.NewLine);

            if (this.Count == 0)
            {
                representation.Append("Empty");
            }

            for (int i = this.topPointer; i >= 0; i--)
            {
                representation.Append(string.Format("{0} -> ", this.stackArray[i]));
            }

            return representation.ToString().TrimEnd(new char[] { ' ', '-', '>' });
        }

        private void ResizeStackArray()
        {
            T[] newArray = new T[this.stackArray.Length * 2];
            Array.Copy(this.stackArray, newArray, this.stackArray.Length);
            this.stackArray = newArray;
        }
    }
}
