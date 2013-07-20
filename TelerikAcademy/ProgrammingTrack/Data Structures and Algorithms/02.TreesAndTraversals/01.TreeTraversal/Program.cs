namespace _01.TreeTraversal
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static Node<int> FindRoot(Node<int>[] nodes)
        {
            for (int i = 0; i < nodes.Length; i++)
            {
                if (!nodes[i].HasParent)
                {
                    return nodes[i];
                }
            }

            throw new ArgumentException("The three does not have a root.");
        }

        public static List<Node<int>> FindLeafs(Node<int>[] nodes)
        {
            List<Node<int>> leafs = new List<Node<int>>();

            for (int i = 0; i < nodes.Length; i++)
            {               
                if (nodes[i].Children.Count == 0)
                {
                    leafs.Add(nodes[i]);
                }
            }

            return leafs;
        }

        public static List<Node<int>> FindMiddleNodes(Node<int>[] nodes)
        {
            List<Node<int>> middleNodes = new List<Node<int>>();

            for (int i = 0; i < nodes.Length; i++)
            {
                if (nodes[i].HasParent && (nodes[i].Children.Count > 0))
                {
                    middleNodes.Add(nodes[i]);
                }
            }

            return middleNodes;
        }

        public static List<Node<int>> FindLongestPath(Node<int> node)
        {
            int maxLength = 0;

            List<Node<int>> currentLongestPath = new List<Node<int>>();

            foreach (var child in node.Children)
            {
                var intermediatePath = FindLongestPath(child);
                if (intermediatePath.Count > maxLength)
                {
                    currentLongestPath = intermediatePath;
                    maxLength = intermediatePath.Count;
                }
            }

            currentLongestPath.Add(node);
            return currentLongestPath;
        }

        public static void PrintPath(List<Node<int>> pathNodes)
        {
            for (int i = pathNodes.Count - 1; i >= 0; i--)
            {
                if (i != 0)
                {
                    Console.Write("{0} -> ", pathNodes[i].Value);
                }
                else
                {
                    Console.Write("{0}", pathNodes[i].Value);
                }
            }

            Console.WriteLine();
        }

        public static void PrintPathOfIntegers(List<int> path)
        {
            for (int i = 0; i < path.Count; i++)
            {
                if (i != path.Count - 1)
                {
                    Console.Write("{0} -> ", path[i]);
                }
                else
                {
                    Console.Write("{0}", path[i]);
                }
            }

            Console.WriteLine();
        }

        public static List<List<int>> FindPathsWithSpecificSum(Node<int> startNode, int sum, 
            List<List<int>> listofFoundPaths, List<List<int>> listofPathsInProgress)
        {
            if (listofFoundPaths == null)
            {
                listofFoundPaths = new List<List<int>>();
            }

            if (listofPathsInProgress == null)
            {
                listofPathsInProgress = new List<List<int>>();
            }

            for (int i = 0; i < listofPathsInProgress.Count; i++)
            {
                if (listofPathsInProgress[i].Sum() + startNode.Value <= sum)
                {
                    listofPathsInProgress[i].Add(startNode.Value);
                }
            }

            for (int i = 0; i < listofPathsInProgress.Count; i++)
            {
                if (listofPathsInProgress[i].Sum() == sum)
                {
                    listofFoundPaths.Add(new List<int>(listofPathsInProgress[i]));
                    foreach (var child in startNode.Children)
                    {
                        if (child.Value == 0)
                        {
                            listofPathsInProgress[i].Add(child.Value);
                            listofFoundPaths.Add(listofPathsInProgress[i]);
                            listofPathsInProgress.RemoveAt(i);
                            break;
                        }
                    }
                }
            }

            if (startNode.Value <= sum)
            {
                var newPath = new List<int>();
                newPath.Add(startNode.Value);
                listofPathsInProgress.Add(newPath);
            }

            foreach (var child in startNode.Children)
            {
                FindPathsWithSpecificSum(child, sum, listofFoundPaths, listofPathsInProgress);
                foreach (var path in listofPathsInProgress)
                {
                    path.Remove(child.Value);
                }
            }

            return listofFoundPaths;
        }

        public static List<Node<int>> FindSubtreesWithSpecificSum(Node<int> currentRoot, int sum, List<Node<int>> foundSubtrees)
        {
            int currentSum = CalculateSumOfTree(currentRoot);

            if (currentSum == sum)
            {
                foundSubtrees.Add(currentRoot);
            }

            foreach (var child in currentRoot.Children)
            {
                FindSubtreesWithSpecificSum(child, sum, foundSubtrees);
            }

            return foundSubtrees;
        }

        public static int CalculateSumOfTree(Node<int> currentNode)
        {
            int currentSum = currentNode.Value;
            foreach (var child in currentNode.Children)
            {
                currentSum += CalculateSumOfTree(child);
            }

            return currentSum;
        }

        public static void Main()
        {
            Console.WriteLine("Please enter N");
            int numberOfNodes = int.Parse(Console.ReadLine());
            var nodes = new Node<int>[numberOfNodes];

            for (int i = 0; i < numberOfNodes; i++)
            {
                nodes[i] = new Node<int>(i);
            }

            for (int i = 0; i < numberOfNodes - 1; i++)
            {
                string[] inputs = Console.ReadLine().Split(' ');
                int parent = int.Parse(inputs[0]);
                int child = int.Parse(inputs[1]);

                nodes[parent].Children.Add(nodes[child]);
                nodes[child].HasParent = true;
            }

            // Subtask 1 - finding the root
            Node<int> root = FindRoot(nodes);
            Console.WriteLine("The root of the tree is node {0}.", root.Value);

            // Subtask 2 - finding all child nodes
            List<Node<int>> leafs = FindLeafs(nodes);
            Console.Write("The leafs are the following nodes: ");
            for (int i = 0; i < leafs.Count; i++)
            {
                Console.Write("{0} ", leafs[i].Value);
            }

            Console.WriteLine();

            // Subtask 3 - finding all middle nodes.
            List<Node<int>> middleNodes = FindMiddleNodes(nodes);
            Console.Write("The middle nodes are the following nodes: ");
            for (int i = 0; i < middleNodes.Count; i++)
            {
                Console.Write("{0} ", middleNodes[i].Value);
            }

            Console.WriteLine();

            // Subtask 4 - finding the longest path. IMPORTANT: the tree nodes are conected only one way (meaning
            // the tree is connected from top to bottom. This means that the path between two nodes is possible only
            // if one is below the other and there is path through intermediate nodes between them. Thus, by necessity
            // the longest path here is one of the paths that start from the root. The longest path from node to node
            // regardless of their position in the data structure is a task that is suitable for a graph not for a 
            // one-way connected tree.
            List<Node<int>> longestPathData = FindLongestPath(root);
            Console.WriteLine("The longest path with length {0} is:", longestPathData.Count);
            PrintPath(longestPathData);

            // Subtask 5 - all paths with sum s. Again, because this is a tree connected only in one direction, a path is one-directional -
            // meaning it is only going down.
            int sumOfPath = 9;
            List<List<int>> pathsWithSpecificSum = FindPathsWithSpecificSum(root, sumOfPath, new List<List<int>>(), new List<List<int>>());
            Console.WriteLine("The paths with sum {0} are:", sumOfPath);
            foreach (var path in pathsWithSpecificSum)
            {
                PrintPathOfIntegers(path);
            }

            // Subtask 6 - all trees with sum s.
            int sumOfSubtree = 6;
            List<Node<int>> subtreesWithSpecificSum = FindSubtreesWithSpecificSum(root, sumOfSubtree, new List<Node<int>>());
            Console.WriteLine("The trees with sum {0} are:", sumOfSubtree);
            foreach (var subtree in subtreesWithSpecificSum)
            {
                // Not the optimal way to display a tree on the console (gets really complicated if the tree is bigger)
                // but could not think of anything better than this ToString implementation.
                Console.WriteLine(subtree);
            }
        }
    }
}
