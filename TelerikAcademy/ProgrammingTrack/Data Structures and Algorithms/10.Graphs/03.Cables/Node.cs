namespace _03.Cables
{
    using System;
    using System.Collections.Generic;

    public class Node
    {
        public Node(int number)
        {
            this.Number = number;
            this.Edges = new List<Edge>();
        }

        public int Number { get; set; }

        public List<Edge> Edges { get; set; }

        public void AddEdge(Node node, int distance)
        {
            this.Edges.Add(new Edge(this, node, distance));
        }
    }
}
