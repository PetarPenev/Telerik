namespace _03.Cables
{
    using System;

    public class Edge : IComparable<Edge>
    {
        public Edge(Node start, Node end, int distance)
        {
            this.StartNode = start;
            this.EndNode = end;
            this.Distance = distance;
        }

        public Node StartNode { get; set; }

        public Node EndNode { get; set; }

        public int Distance { get; set; }

        int IComparable<Edge>.CompareTo(Edge other)
        {
            return this.Distance.CompareTo(other.Distance);
        }

        public override string ToString()
        {
            return this.StartNode.Number + " -> " + this.EndNode.Number + " with weight " + this.Distance;
        }
    }
}
