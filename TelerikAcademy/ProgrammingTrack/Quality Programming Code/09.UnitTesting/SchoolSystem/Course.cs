// My edition of VS is VS Professional and I do not have the code coverage capabilities build in the
// Ultimate version of Visual Studio. I have installed a tool - Dotcover - that has such functionality -
// and it points to 93% code coverage by unit tests. However, I am not sure what percentage will
// the VS tool give to my code.
namespace SchoolSystem
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Course
    {
        private const int MaxNumberOfStudents = 29;

        private string name;

        private List<Student> enrolledStudents;

        public Course(string name)
        {
            this.Name = name;
            this.EnrolledStudents = new List<Student>();
        }

        public string Name
        {
            get 
            { 
                return this.name;
            }

            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name of the course must be meaningful");
                }

                this.name = value; 
            }
        }

        public List<Student> EnrolledStudents
        {
            // We are returning a copy of the list so that it cannot be modified by users (this is needed
            // because lists are passed by reference).
            get 
            { 
                return new List<Student>(this.enrolledStudents);
            }

            private set 
            { 
                this.enrolledStudents = value;
            }
        }

        public bool HasStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException("student", "The student must be initialized.");
            }

            bool hasStudent = this.EnrolledStudents.Contains(student);

            return hasStudent;
        }

        public void AddStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException("student", "The student must be initialized.");
            }

            if (this.HasStudent(student))
            {
                throw new ArgumentException("Student is already enrolled in the course.");
            }

            if (this.EnrolledStudents.Count <= MaxNumberOfStudents - 1)
            {
                this.enrolledStudents.Add(student);
            }
            else
            {
                throw new ArgumentOutOfRangeException("student", "The course is full and no more students can be enrolled.");
            }
        }

        public void RemoveStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException("student", "The student must be initialized.");
            }

            if (!this.HasStudent(student))
            {
                throw new KeyNotFoundException("Student is not enrolled in the course.");
            }

            this.enrolledStudents.Remove(student);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Course name: " + this.Name);
            for (int i = 0; i < this.EnrolledStudents.Count; i++)
            {
                sb.AppendLine(this.EnrolledStudents[i].ToString());
            }

            return sb.ToString().TrimEnd(Environment.NewLine.ToCharArray());
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("Comparison not initialized.");
            }

            Course other = obj as Course;

            if (other == null)
            {
                throw new ArgumentException("Cannot compare Course with different types.");
            }

            if (this.Name.Equals(other.Name, StringComparison.InvariantCultureIgnoreCase))
            {
                return true;
            }

            return false;
        }
    }
}
