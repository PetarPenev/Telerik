using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySchool
{
    // The class implements the interface ICommentable which allows comments
    public class ClassInSchool:ICommentable
    {
        // Fields and properties
        private List<Student> listOfStudents;

        public List<Student> ListOfStudents
        {
            get { return listOfStudents; }
            set { listOfStudents = value; }
        }

        private List<Teacher> listOfTeachers;

        public List<Teacher> ListOfTeachers
        {
            get { return listOfTeachers; }
            set { listOfTeachers = value; }
        }

        private string textIdentifier;

        public string TextIdentifier
        {
            get { return textIdentifier; }
            private set { textIdentifier = value; }
        }

        private List<string> comments;

        public List<string> Comments
        {
            get { return this.comments; }
            private set { comments = value; }
        }

        // Constructor
        public ClassInSchool(List<Student> listOfStudents, List<Teacher> listOfTeachers, string identifier, string comment = null)
        {
            this.ListOfStudents = listOfStudents;
            this.ListOfTeachers = listOfTeachers;
            this.TextIdentifier = identifier;
            this.Comments=new List<string>();
            if (comment!=null)
                this.Comments.Add(comment);
        }

        // Methods for adding students, teachers and comments
        public void AddStudent(Student student)
        {
            this.ListOfStudents.Add(student);
        }

        public void AddTeacher(Teacher teacher)
        {
            this.ListOfTeachers.Add(teacher);
        }

        public void AddComment(string comment)
        {
            this.Comments.Add(comment);
        }

        // Overriding ToString
        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append("The class is:" + this.TextIdentifier + Environment.NewLine);
            str.Append("Students in class:"+Environment.NewLine);
            foreach (Student c in this.ListOfStudents)
            {
                str.AppendLine(c.ToString());
            }
            str.Append("Teachers of the class:" + Environment.NewLine);
            foreach (Teacher c in this.ListOfTeachers)
            {
                str.AppendLine(c.ToString());
            }
            str.AppendLine("Comments About the Class:");
            if (this.Comments.Count == 0)
                str.AppendLine("None");
            else
            {
                foreach (string c in comments)
                {
                    str.AppendLine(c);
                }
            }
            return str.ToString();
        }
    }
}
