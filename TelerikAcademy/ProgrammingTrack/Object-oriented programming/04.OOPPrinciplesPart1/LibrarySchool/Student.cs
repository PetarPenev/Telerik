using System;
using System.Text;


namespace LibrarySchool
{
    public class Student : Person
    {
        private uint classNumber;

        public uint ClassNumber
        {
            get { return classNumber; }
            private set { classNumber = value; }
        }

        // Constructor calling the constructor of the base class
        public Student(string name, uint classNumber, string comment = null)
            : base(name,comment)
        {
            this.ClassNumber = classNumber;
        }

        // Overriding ToString
        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("Student's name: " + this.Name);
            str.AppendLine("Student's number: " + this.ClassNumber);
            str.AppendLine("Comments about the student:");
            if (this.Comments.Count == 0)
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

