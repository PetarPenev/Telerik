namespace _11.LinkedListImplementation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ListItem<T>
    {
        private T value;

        private ListItem<T> nextItem;

        public ListItem(T value, ListItem<T> nextItem = null)
        {
            this.Value = value;
            this.NextItem = nextItem;
        }

        public T Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        public ListItem<T> NextItem
        {
            get { return this.nextItem; }
            set { this.nextItem = value; }
        }

        public ListItem<T> Clone()
        {
            return new ListItem<T>(this.Value, this.nextItem);
        }

        public override bool Equals(object obj)
        {
            ListItem<T> listItem = obj as ListItem<T>;
            if (listItem == null)
            {
                return false;
            }

            if (this.NextItem == null)
            {
                return this.value.Equals(listItem.value);
            }

            return this.value.Equals(listItem.value) && this.NextItem.Equals(listItem.NextItem);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("{0} -> {1}...", this.Value, (this.NextItem != null) ? this.NextItem.Value.ToString() : "none");
        }
    }
}
