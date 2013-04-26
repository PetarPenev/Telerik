using System;
using System.Collections.Generic;

namespace LibrarySchool
{
    public class School
    {
        private List<ClassInSchool> listOfClasses;

        public List<ClassInSchool> ListOfClasses
        {
            get { return listOfClasses; }
            private set { listOfClasses = value; }
        }

        // Constructor
        public School(List<ClassInSchool> list)
        {
            this.ListOfClasses = list;
        }

        // Metod for adding a class
        public void AddClass(ClassInSchool classInSchool)
        {
            this.ListOfClasses.Add(classInSchool);
        }

        // Overriding ToString
        public override string ToString()
        {
            foreach (ClassInSchool cl in this.ListOfClasses)
            {
                return cl.ToString()+Environment.NewLine;
            }
            return Environment.NewLine;
        }

    }
}
