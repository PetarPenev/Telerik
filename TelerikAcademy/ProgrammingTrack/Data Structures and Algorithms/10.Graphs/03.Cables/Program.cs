namespace _03.Cables
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            Node[] nodes = new Node[7];
            nodes[1] = new Node(1);
            nodes[2] = new Node(2);
            nodes[3] = new Node(3);
            nodes[4] = new Node(4);
            nodes[5] = new Node(5);
            nodes[6] = new Node(6);

            InitializeEdges(nodes);
            PriorityQueue<Edge> edges = new PriorityQueue<Edge>();
            bool[] usedNodes = new bool[7];
            Node startNode = nodes[1];
            usedNodes[startNode.Number] = true;
            foreach (var edge in startNode.Edges)
            {
                if (!edges.Contains(edge) && !usedNodes[edge.EndNode.Number])
                {
                    edges.Enqueue(edge);
                }
            }

            List<Edge> traversedEdges = new List<Edge>();

            while (edges.Count != 0)
            {
                Edge currentEdge = edges.Dequeue();
                if (!usedNodes[currentEdge.EndNode.Number])
                {
                    usedNodes[currentEdge.EndNode.Number] = true;
                    traversedEdges.Add(currentEdge);
                    foreach (var edge in currentEdge.EndNode.Edges)
                    {
                        if (!edges.Contains(edge) && !usedNodes[edge.EndNode.Number])
                        {
                            edges.Enqueue(edge);
                        }
                    }
                }
            }

            foreach (var edge in traversedEdges)
            {
                Console.WriteLine(edge);
            }
        }

        private static void InitializeEdges(Node[] nodes)
        {
            nodes[1].AddEdge(nodes[3], 5);
            nodes[3].AddEdge(nodes[1], 5);
            nodes[1].AddEdge(nodes[2], 4);
            nodes[2].AddEdge(nodes[1], 4);
            nodes[1].AddEdge(nodes[4], 9);
            nodes[4].AddEdge(nodes[1], 9);
            nodes[2].AddEdge(nodes[4], 2);
            nodes[4].AddEdge(nodes[2], 2);
            nodes[3].AddEdge(nodes[4], 20);
            nodes[4].AddEdge(nodes[3], 20);
            nodes[3].AddEdge(nodes[5], 7);
            nodes[5].AddEdge(nodes[3], 7);
            nodes[4].AddEdge(nodes[5], 8);
            nodes[5].AddEdge(nodes[4], 8);
            nodes[5].AddEdge(nodes[6], 12);
            nodes[6].AddEdge(nodes[5], 12);
        }
    }
}
