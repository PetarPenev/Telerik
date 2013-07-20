namespace _02.Friends
{
    using System;

    public class Node : IComparable<Node>
    {
        public Node(int vertex, int disntace)
        {
            this.Vertex = vertex;
            this.Disntace = disntace;
        }

        public int Vertex { get; set; }

        public int Disntace { get; set; }

        public int CompareTo(Node other)
        {
            return this.Disntace.CompareTo(other.Disntace);
        }
    }
}
