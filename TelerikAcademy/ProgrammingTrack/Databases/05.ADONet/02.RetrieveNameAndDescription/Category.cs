namespace _02.RetrieveNameAndDescription
{
    using System;

    public class Category
    {
        public Category(string name, string description)
        {
            this.Name = name;
            this.Description = description;
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public override string ToString()
        {
            return this.Name + " - " + this.Description;
        }
    }
}