namespace _03.FileTree
{
    using System;
    using System.Collections.Generic;

    public class Folder
    {
        private string name;

        private List<File> files;

        private List<Folder> folders;

        public Folder(string name)
        {
            this.Name = name;
            this.folders = new List<Folder>();
            this.files = new List<File>();
        }

        public Folder(string name, List<Folder> folders)
            : this(name)
        {
            this.folders = folders;
        }

        public Folder(string name, List<File> files)
            : this(name)
        {
            this.files = files;
        }

        public Folder(string name, List<File> files, List<Folder> folders)
            : this(name, files)
        {
            this.folders = folders;
        }

        public string Name
        {
            get
            {
                return string.Copy(this.name);
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Folder name cannot be empty, null or containing only white spaces.");
                }

                this.name = value;
            }
        }

        public File[] Files
        {
            get
            {
                // This is done so that a new copy of the array is returned.
                return this.files.ToArray();
            }
        }

        public Folder[] Folders
        {
            get
            {
                // This is done so that a new copy of the array is returned.
                return this.folders.ToArray();
            }
        }

        public void AddFile(File fileToAdd)
        {
            this.files.Add(fileToAdd);
        }

        public void AddFolder(Folder folderToAdd)
        {
            this.folders.Add(folderToAdd);
        }

        public decimal GetTotalFolderSize()
        {
            decimal currentSize = 0;

            for (int i = 0; i < this.Folders.Length; i++)
            {
                currentSize += this.Folders[i].GetTotalFolderSize();
            }

            for (int i = 0; i < this.Files.Length; i++)
            {
                currentSize += this.Files[i].FileSize;
            }

            return currentSize;
        }
    }
}
