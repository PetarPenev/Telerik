namespace _03.FileTree
{
    using System;

    public class File
    {
        private string name;

        private decimal fileSize;

        public File(string name, decimal fileSize)
        {
            this.Name = name;
            this.FileSize = fileSize;
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
                    throw new ArgumentException("File name cannot be null, empty or containing only white spaces.");
                }

                this.name = value;
            }
        }

        public decimal FileSize
        {
            get
            {
                return this.fileSize;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("File size must be a non-negative number.");
                }

                this.fileSize = value;
            }
        }
    }
}
