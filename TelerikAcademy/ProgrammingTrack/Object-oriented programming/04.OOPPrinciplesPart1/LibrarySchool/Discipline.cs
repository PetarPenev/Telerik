using System;
using System.Collections.Generic;
using System.Text;


namespace LibrarySchool
{
    // Implements the ICommentable interface
    public class Discipline:ICommentable
    {
        //Fields and properties
        private string name;

        public string Name
        {
            get { return name; }
            private set { name = value; }
        }

        private uint numberOfLectures;

        public uint NumberOfLectures
        {
            get { return numberOfLectures; }
            private set { numberOfLectures = value; }
        }

        private uint numberOfExercises;

        public uint NumberOfExercises
        {
            get { return numberOfExercises; }
            private set { numberOfExercises = value; }
        }

        private List<string> comments;

        public List<string> Comments
        {
            get { return comments; }
            set { this.comments = value; }
        }

        // Constructor
        public Discipline(string name, uint numberOfLectures, uint numberOfExercises, string comment = null)
        {
            this.Name = name;
            this.NumberOfLectures = numberOfLectures;
            this.NumberOfExercises = numberOfExercises;
            this.Comments = new List<string>();
            if (comment!=null)
                this.Comments.Add(comment);
        }

        // Method for adding comments
        public void AddComment(string comment)
        {
            this.Comments.Add(comment);
        }

        // Overriding to string
        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("Name of discipline: " + this.Name);
            str.AppendLine("Number of lectures: " + this.NumberOfLectures);
            str.AppendLine("Number of exercises" + this.NumberOfExercises);
            str.AppendLine("Comments about the discipline:");
            if (this.Comments==null)
            {
                str.AppendLine("None");
            }
            else
            {
                foreach (string c in this.Comments)
                {
                    str.AppendLine(c);
                }
            }
            return str.ToString();
            
        }

    }
}
