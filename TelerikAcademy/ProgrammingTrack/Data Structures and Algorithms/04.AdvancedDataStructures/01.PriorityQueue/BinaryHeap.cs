namespace _01.PriorityQueue
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class BinaryHeap<T> where T : IComparable
    {
        private List<T> listOfItems;

        public BinaryHeap()
        {
            this.listOfItems = new List<T>(0);
        }

        public int Count
        {
            get
            {
                return this.listOfItems.Count;
            }
        }

        public T Peek
        {
            get
            {
                if (this.listOfItems.Count == 0)
                {
                    throw new ArgumentOutOfRangeException("No items in the heap.");
                }

                return this.listOfItems[0];
            }
        }

        public void Add(T element)
        {
            this.listOfItems.Add(element);
            int index = this.listOfItems.Count - 1;
            while ((index > 0) && (this.listOfItems[index].CompareTo(this.listOfItems[(index - 1) / 2]) > 0))
            {
                var intermediateValue = this.listOfItems[index];
                this.listOfItems[index] = this.listOfItems[(index - 1) / 2];
                this.listOfItems[(index - 1) / 2] = intermediateValue;
                index = index / 2;
            }
        }

        public T Pop()
        {
            if (this.listOfItems.Count == 0)
            {
                throw new ArgumentOutOfRangeException("No items in the heap.");
            }

            T elementToReturn = this.listOfItems[0];
            bool isInCorrectPosition = false;

            this.listOfItems[0] = this.listOfItems[this.listOfItems.Count - 1];
            this.listOfItems.RemoveAt(this.listOfItems.Count - 1);
            int currentIndex = 0;
            int indexToMove = 0;

            while (!isInCorrectPosition)
            {
                indexToMove = currentIndex;

                if ((currentIndex * 2 + 1 < this.listOfItems.Count) &&
                    (this.listOfItems[currentIndex].CompareTo(this.listOfItems[currentIndex * 2 + 1]) < 0))
                {
                    indexToMove = currentIndex * 2 + 1;
                }

                if ((currentIndex * 2 + 2 < this.listOfItems.Count) &&
                   (this.listOfItems[currentIndex].CompareTo(this.listOfItems[currentIndex * 2 + 2]) < 0))
                {
                    if ((indexToMove != currentIndex) && 
                        (this.listOfItems[currentIndex * 2 + 1].CompareTo(this.listOfItems[currentIndex * 2 + 2]) > 0))
                    {
                        indexToMove = currentIndex * 2 + 2;
                    }
                    else if (indexToMove == currentIndex)
                    {
                        indexToMove = currentIndex * 2 + 2;
                    }
                }

                if (indexToMove == currentIndex)
                {
                    isInCorrectPosition = true;
                }
                else
                {
                    var intermediateValue = this.listOfItems[currentIndex];
                    this.listOfItems[currentIndex] = this.listOfItems[indexToMove];
                    this.listOfItems[indexToMove] = intermediateValue;
                }
            }

            return elementToReturn;
        }

        public override string ToString()
        {
            StringBuilder representation = new StringBuilder("{");
            representation.Append(string.Join(",", this.listOfItems));
            representation.Append("}");

            return representation.ToString();
        }
    }
}
