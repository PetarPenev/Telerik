using System;


namespace SecondTaskLibrary
{
    public class Student:Human
    {
        private decimal grade;

        public decimal Grade
        {
            get { return grade; }
            private set {
                if ((value < 2) || (value > 6))
                    throw new ArgumentException("Grade not in the correct range.");
                else
                    grade = value; 
            }
        }

        public Student(string firstName, string lastName, decimal grade)
            : base(firstName, lastName)
        {
            this.Grade = grade;
        }

        // Method for changing the student's grade
        public void ChangeGrade(decimal newGrade)
        {
            this.Grade = newGrade;
        }

        public override string ToString()
        {
            return this.FirstName + " " + this.LastName + " Grade: " + this.Grade;
        }
    }
}
