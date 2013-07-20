namespace _02.Friends
{
    using System;
    using System.Collections.Generic;

    public class Graph
    {
        private List<Node>[] vertices;

        private HashSet<int> hospitals;

        private PriorityQueue<Node> queue;

        private HashSet<int> used;

        private int[] distances;

        public Graph(int n)
        {
            this.vertices = new List<Node>[n];
            this.hospitals = new HashSet<int>();
        }

        public void AddEdge(int from, int to, int distance)
        {
            this.AddDirectedEdge(from - 1, to - 1, distance);
            this.AddDirectedEdge(to - 1, from - 1, distance);
        }

        public void AddHospital(int hospital)
        {
            this.hospitals.Add(hospital - 1);
        }

        public int GetBestHospital()
        {
            int bestDistance = int.MaxValue;

            foreach (int hospital in this.hospitals)
            {
                int[] distances = this.Dijkstra(hospital);
                int distance = this.Sum(distances);
                if (distance < bestDistance)
                {
                    bestDistance = distance;
                }
            }

            return bestDistance;
        }

        private void AddDirectedEdge(int from, int to, int distance)
        {
            if (this.vertices[from] == null)
            {
                this.vertices[from] = new List<Node>();
            }

            var newNode = new Node(to, distance);
            this.vertices[from].Add(newNode);
        }

        private int Sum(int[] distances)
        {
            int sum = 0;
            for (int vertex = 0; vertex < distances.Length; vertex++)
            {
                if (!this.hospitals.Contains(vertex))
                {
                    sum += distances[vertex];
                }
            }

            return sum;
        }

        private int[] Dijkstra(int hospital)
        {
            this.InitializeQueue();
            this.InitializeUsed();
            this.InitializeDistances(hospital);
            this.used.Add(hospital);
            Node startNode = new Node(hospital, 0);

            this.queue.Enqueue(startNode);
            Node best;
            while (this.queue.Count > 0)
            {
                best = this.queue.Dequeue();
                this.used.Add(best.Vertex);
                foreach (var nextNode in this.vertices[best.Vertex])
                {
                    int newDistance = this.distances[best.Vertex] + nextNode.Disntace;
                    if (this.distances[nextNode.Vertex] > newDistance)
                    {
                        this.distances[nextNode.Vertex] = newDistance;
                        Node next = new Node(nextNode.Vertex, newDistance);
                        this.queue.Enqueue(next);
                    }
                }

                this.ClearUsedVerticesFromQueue();
            }

            return this.distances;
        }

        private void InitializeDistances(int hospital)
        {
            if (this.distances == null)
            {
                this.distances = new int[this.vertices.Length];
            }

            for (int i = 0; i < this.distances.Length; i++)
            {
                this.distances[i] = int.MaxValue;
            }

            this.distances[hospital] = 0;
        }

        private void ClearUsedVerticesFromQueue()
        {
            while (this.queue.Count > 0 && this.used.Contains(this.queue.Peek().Vertex))
            {
                this.queue.Dequeue();
            }
        }

        private void InitializeUsed()
        {
            if (this.used == null)
            {
                this.used = new HashSet<int>();
            }
            else
            {
                this.used.Clear();
            }
        }

        private void InitializeQueue()
        {
            if (this.queue == null)
            {
                this.queue = new PriorityQueue<Node>();
            }
            else
            {
                this.queue.Clear();
            }
        }
    }
}
