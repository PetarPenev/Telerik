namespace _02.DirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class DirectoryTraversal
    {
        private static List<string> fileNames = new List<string>() { "*.exe" };

        private static List<string> foundFiles = new List<string>();

        public static void Main()
        {
            string startingDirectory = @"C:\Windows";
            TraverseDirectory(startingDirectory);
            for (int i = 0; i < foundFiles.Count; i++)
            {
                Console.WriteLine(foundFiles[i]);
            }
        }

        public static void TraverseDirectory(string directoryPath)
        {
            foreach (var name in fileNames)
            {
                try
                {
                    string[] currentFiles = Directory.GetFiles(directoryPath, name);
                    foundFiles.AddRange(currentFiles);
                }
                catch (UnauthorizedAccessException)
                {
                    Console.WriteLine("Access to {0} is denied.", directoryPath);
                    return;
                }
            }

            string[] currentDirectories = Directory.GetDirectories(directoryPath);
            for (int i = 0; i < currentDirectories.Length; i++)
            {
                TraverseDirectory(currentDirectories[i]);
            }
        }
    }
}
