namespace _03.FileTree
{
    using System;
    using System.IO;

    public class CreateFolderTree
    {
        public static void Main()
        {
            string directoryPath = @"C:\Windows";
            DirectoryInfo directoryInfo = new DirectoryInfo(directoryPath);
            Folder folderTree = GetFolderTree(directoryInfo);

            // Caution! Because files that Windows does not allow access to cannot be build into the tree,
            // there might be differences between information from your file system and the information
            // displayed.
            Console.WriteLine("The size of {0} directory is {1} megabytes.", 
                folderTree.Name, decimal.Round(folderTree.GetTotalFolderSize(), 2, MidpointRounding.AwayFromZero));
        }

        public static Folder GetFolderTree(DirectoryInfo directoryInfo)
        {
            Folder currentFolder = new Folder(directoryInfo.Name);

            try
            {
                FileInfo[] currentFiles = directoryInfo.GetFiles();
                for (int i = 0; i < currentFiles.Length; i++)
                {
                    File nextFile = new File(currentFiles[i].Name, ((decimal)currentFiles[i].Length) / 1048576);
                    currentFolder.AddFile(nextFile);
                }

                DirectoryInfo[] currentDirectories = directoryInfo.GetDirectories();
                for (int i = 0; i < currentDirectories.Length; i++)
                {
                    Folder nextFolder = GetFolderTree(currentDirectories[i]);
                    currentFolder.AddFolder(nextFolder);
                }

                return currentFolder;
            }
            catch (UnauthorizedAccessException)
            {
                return currentFolder;
            }
        }
    }
}
