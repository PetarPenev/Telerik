using System;
using System.Collections.Generic;


namespace LibrarySchool
{
    // Defining an abstract class Person that serves as a base for teachers and students
    public abstract class Person:ICommentable
    {
        // Fields and properties
        private string name;

        private List<string> comments;

        public List<string> Comments
        {
            get { return comments; }
            private set { comments = value; }
        }

        public string Name
        {
            get { return name; }
            private set { name = value; }
        }

        // A protected constructor for the abstract class
        protected Person(string name, string comment = null)
        {
            this.Name = name;
            this.Comments = new List<string>();
            if (comment!=null)
                this.Comments.Add(comment);
        }

        // Method for adding comments
        public void AddComment(string comment)
        {
            if (comment!=null)
             this.Comments.Add(comment);
        }
    }
}
