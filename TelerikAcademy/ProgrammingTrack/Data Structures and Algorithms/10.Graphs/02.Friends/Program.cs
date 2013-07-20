namespace _02.Friends
{
    using System;
    using Wintellect.PowerCollections;

    public class Program
    {
        public static void Main()
        {
            string[] nMH = ReadConsoleLine();
            int n = int.Parse(nMH[0]);
            int m = int.Parse(nMH[1]);
            int h = int.Parse(nMH[2]);

            Graph graph = new Graph(n);
            string[] hospitals = ReadConsoleLine();
            AddHospitalsToGraph(graph, hospitals);
            ReadEdges(m, graph);

            int sum = graph.GetBestHospital();
            Console.WriteLine(sum);
        }

        private static string[] ReadConsoleLine()
        {
            string inputLine = Console.ReadLine();
            string[] hospitals = inputLine.Split(' ');
            return hospitals;
        }

        private static void ReadEdges(int m, Graph graph)
        {
            for (int i = 0; i < m; i++)
            {
                string[] edgeArguments = ReadConsoleLine();
                int from = int.Parse(edgeArguments[0]);
                int to = int.Parse(edgeArguments[1]);
                int distance = int.Parse(edgeArguments[2]);
                graph.AddEdge(from, to, distance);
            }
        }

        private static void AddHospitalsToGraph(Graph graph, string[] hospitals)
        {
            foreach (var hospitalAsString in hospitals)
            {
                int hospital = int.Parse(hospitalAsString);
                graph.AddHospital(hospital);
            }
        }
    }
}