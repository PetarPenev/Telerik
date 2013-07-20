//-----------------------------------------------------------------------
// <copyright file="Course.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//----------------------------------------------------------------------
namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    ///     An abstract class that can serve as a basis for different sorts of educational classes.
    /// </summary>
    public abstract class Course
    {
        /// <summary>
        ///     The name of the course.
        /// </summary>
        private string name;

        /// <summary>
        ///     The name of the teacher for the course.
        /// </summary>
        private string teacherName;

        /// <summary>
        ///     The students enrolled in the course.
        /// </summary>
        private IList<string> students = new List<string>();

        /// <summary>
        ///     Initializes a new instance of the <see cref="Course" /> class.
        /// </summary>
        /// <param name="name">The name of the course/</param>
        /// <param name="teacherName">The name of the teacher.</param>
        /// <param name="students">The students that are enrolled.</param>
        protected Course(string name, string teacherName, IList<string> students)
        {
            this.Name = name;
            this.TeacherName = teacherName;
            this.Students = students;
        }

        /// <summary>
        ///     Gets or sets the name of the class.
        /// </summary>
        public string Name 
        {
            get
            {
                return string.Copy(this.name);
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be uninitialized or empty.");
                }

                this.name = value;
            }
        }

        /// <summary>
        ///     Gets or sets the name of the teacher.
        /// </summary>
        public string TeacherName
        {
            get
            {
                if (this.teacherName != null)
                {
                    return string.Copy(this.teacherName);
                }

                return null;
            }

            set
            {
                this.teacherName = value;
            }
        }

        /// <summary>
        ///  Gets or sets the list of enrolled students.
        /// </summary>
        public IList<string> Students
        {
            get
            {
                return new List<string>(this.students);
            }

            set
            {
                this.students = new List<string>();

                if (value != null)
                {
                    foreach (var student in value)
                    {
                        this.students.Add(string.Copy(student));
                    }
                }
            }
        }

        /// <summary>
        ///     A method that adds a students that is enrolled for the class.
        /// </summary>
        /// <param name="student">The student to be added.</param>
        public void AddStudent(string student)
        {
            if (string.IsNullOrWhiteSpace(student))
            {
                throw new ArgumentException("The student's name cannot be uninitialized or empty.");
            }

            this.students.Add(student);
        }

        /// <summary>
        ///     Overrides the standard ToString method.
        /// </summary>
        /// <returns>The string representation of the class.</returns>
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("LocalCourse { Name = ");
            result.Append(this.Name);
            if (this.TeacherName != null)
            {
                result.Append("; Teacher = ");
                result.Append(this.TeacherName);
            }

            result.Append("; Students = ");
            result.Append(this.GetStudentsAsString());

            return result.ToString();
        }

        /// <summary>
        ///     Converts the list of students to a string.
        /// </summary>
        /// <returns>The string representation of the enrolled students.</returns>
        private string GetStudentsAsString()
        {
            if (this.Students == null || this.Students.Count == 0)
            {
                return "{ }";
            }
            else
            {
                return "{ " + string.Join(", ", this.Students) + " }";
            }
        }
    }
}
