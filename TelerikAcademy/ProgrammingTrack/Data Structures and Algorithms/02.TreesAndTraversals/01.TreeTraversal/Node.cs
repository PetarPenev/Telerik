namespace _01.TreeTraversal
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Node<T>
    {
        public Node()
        {
            this.Children = new List<Node<T>>();
        }

        public Node(T value)
            : this()
        {
            this.Value = value;
        }

        public T Value { get; set; }

        public List<Node<T>> Children { get; set; }

        public bool HasParent { get; set; }

        // Unfortunately this is the best console implementation of tree visualisation that I could think about.
        // Still not quite clear but that was the best that could be done.
        public override string ToString()
        {
            StringBuilder representation = new StringBuilder();

            representation.Append(this.Value.ToString());
            representation.Append(" with children ( ");
            foreach (var child in this.Children)
            {
                representation.Append(child.ToString() + " ");
            }

            representation.Append(")");

            return representation.ToString();
        }
    }
}
