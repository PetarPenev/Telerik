namespace _11.LinkedListImplementation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class NewLinkedList<T>
    {
        private ListItem<T> firstElement;

        private int count;

        public NewLinkedList()
        {
            this.firstElement = null;
            this.count = 0;
        }

        public int Count
        {
            get { return this.count; }
        }

        public ListItem<T> First
        {
            get
            {
                return this.firstElement.Clone();
            }
        }

        public ListItem<T> Last
        {
            get
            {
                var currentElement = this.firstElement;
                while (currentElement.NextItem != null)
                {
                    currentElement = currentElement.NextItem;
                }

                return currentElement;
            }
        }

        public void AddFirst(ListItem<T> item)
        {
            ListItem<T> itemToAdd = item.Clone();

            if (this.firstElement == null)
            {
                this.firstElement = itemToAdd;
            }
            else
            {
                itemToAdd.NextItem = this.firstElement;
                this.firstElement = itemToAdd;
            }

            this.count++;
        }

        public void AddFirst(T value)
        {
            ListItem<T> itemToAdd = new ListItem<T>(value);
            this.AddFirst(itemToAdd);
        }

        public void AddLast(ListItem<T> item)
        {
            ListItem<T> itemToAdd = item.Clone();
            ListItem<T> traversalNode = this.firstElement;

            if (traversalNode == null)
            {
                this.AddFirst(itemToAdd);
                return;
            }

            while (traversalNode.NextItem != null)
            {
                traversalNode = traversalNode.NextItem;
            }

            traversalNode.NextItem = itemToAdd;
            this.count++;
        }

        public void AddLast(T value)
        {
            ListItem<T> itemToAdd = new ListItem<T>(value);
            this.AddLast(itemToAdd);
        }

        public void AddBefore(ListItem<T> itemToAddBefore, ListItem<T> item)
        {
            ListItem<T> itemToAdd = item.Clone();

            var currentNode = this.firstElement;
            if (currentNode.Equals(itemToAddBefore))
            {
                this.AddFirst(itemToAdd);
                this.count++;
                return;
            }

            while (currentNode.NextItem != null)
            {
                if (currentNode.NextItem.Equals(itemToAddBefore))
                {
                    itemToAdd.NextItem = currentNode.NextItem;
                    currentNode.NextItem = itemToAdd;
                    this.count++;
                    return;
                }

                currentNode = currentNode.NextItem;
            }

            throw new ArgumentOutOfRangeException("There is no such node in the linked list to add before it.");
        }

        public void AddBefore(ListItem<T> itemToAddBefore, T valueToAdd)
        {
            ListItem<T> itemToAdd = new ListItem<T>(valueToAdd);
            this.AddBefore(itemToAddBefore, itemToAdd);
        }

        public void AddAfter(ListItem<T> itemToAddAfter, ListItem<T> item)
        {
            ListItem<T> itemToAdd = item.Clone();
            var currentNode = this.firstElement;

            while (currentNode != null)
            {
                if (currentNode.Equals(itemToAddAfter))
                {
                    itemToAdd.NextItem = currentNode.NextItem;
                    currentNode.NextItem = itemToAdd;
                    this.count++;
                    return;
                }

                currentNode = currentNode.NextItem;
            }

            throw new ArgumentOutOfRangeException("There is no such node in the linked list to add after it.");
        }

        public void AddAfter(ListItem<T> itemToAddAfter, T valueToAdd)
        {
            ListItem<T> itemToAdd = new ListItem<T>(valueToAdd);
            this.AddAfter(itemToAddAfter, itemToAdd);
        }

        public void Clear()
        {
            this.firstElement = null;
            this.count = 0;
        }

        public bool Contains(T value)
        {
            ListItem<T> currentNode = this.firstElement;
            while (currentNode != null)
            {
                if (currentNode.Value.Equals(value))
                {
                    return true;
                }

                currentNode = currentNode.NextItem;
            }

            return false;
        }

        public override string ToString()
        {
            StringBuilder representation = new StringBuilder();
            ListItem<T> currentItem = this.firstElement;

            while (currentItem != null)
            {
                representation.Append(string.Format("{0} -> ", currentItem.Value));
                currentItem = currentItem.NextItem;
            }

            return representation.ToString().TrimEnd(new char[] { ' ', '-', '>' });
        }

        public ListItem<T> Find(T value)
        {
            ListItem<T> currentNode = this.firstElement;
            while (currentNode != null)
            {
                if (currentNode.Value.Equals(value))
                {
                    return currentNode;
                }

                currentNode = currentNode.NextItem;
            }

            return null;
        }

        public ListItem<T> FindLast(T value)
        {
            ListItem<T> currentNode = this.firstElement;
            ListItem<T> nodeToReturn = null;

            while (currentNode != null)
            {
                if (currentNode.Value.Equals(value))
                {
                    nodeToReturn = currentNode;
                }

                currentNode = currentNode.NextItem;
            }

            return nodeToReturn;
        }

        public T RemoveFirst()
        {
            T valueToReturn = this.firstElement.Value;

            if (this.firstElement != null)
            {
                this.firstElement = this.firstElement.NextItem;
            }

            this.count--;
            return valueToReturn;
        }

        public T RemoveLast()
        {
            ListItem<T> currentNode = this.firstElement;

            if (currentNode == null)
            {
                throw new ArgumentOutOfRangeException("The list is empty.");
            }

            if (currentNode.NextItem == null)
            {
                return this.RemoveFirst();
            }

            while (currentNode.NextItem.NextItem != null)
            {
                currentNode = currentNode.NextItem;
            }

            T valueToReturn = currentNode.NextItem.Value;
            currentNode.NextItem = null;

            this.count--;
            return valueToReturn;
        }

        public void Remove(ListItem<T> itemToRemove)
        {
            ListItem<T> currentNode = this.firstElement;

            if (currentNode == null)
            {
                return;
            }

            if (currentNode.Equals(itemToRemove))
            {
                this.RemoveFirst();
                return;
            }

            while (currentNode.NextItem != null)
            {
                if (currentNode.NextItem.Equals(itemToRemove))
                {
                    currentNode.NextItem = currentNode.NextItem.NextItem;
                    this.count--;
                    return;
                }

                currentNode = currentNode.NextItem;
            }
        }

        public bool Remove(T valueToRemove)
        {
            ListItem<T> currentNode = this.firstElement;
            while (currentNode != null)
            {
                if (currentNode.Value.Equals(valueToRemove))
                {
                    this.Remove(currentNode);
                    return true;
                }

                currentNode = currentNode.NextItem;
            }

            return false;
        }
    }
}
