using System;
using System.Collections.Generic;
using System.Text;


namespace LibrarySchool
{
    public class Teacher : Person
    {
        private List<Discipline> listOfDisciplines;

        public List<Discipline> ListOfDisciplines
        {
            get { return listOfDisciplines; }
            private set { listOfDisciplines = value; }
        }

        // Constructor calling the base constructor
        public Teacher(string name, List<Discipline> list, string comment = null)
            : base(name, comment)
        {
            this.ListOfDisciplines = list;
        }

        // Method for adding disciplines
        public void AddDiscipline(Discipline disc)
        {
            this.ListOfDisciplines.Add(disc);
        }

        // Overriding ToString
        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("Teacher's name: " + this.Name);
            str.AppendLine("Disciplines taught by the teacher:");
            if (this.ListOfDisciplines.Count == 0)
            {
                str.AppendLine("None");
            }
            else
            {
                foreach (Discipline disc in this.ListOfDisciplines)
                {
                    str.AppendLine(disc.ToString());
                }
            }
            str.AppendLine("Comments about the teacher:");
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
