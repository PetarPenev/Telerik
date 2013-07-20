namespace SchoolSystem
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class School
    {
        private List<Course> offeredCourses;

        public School()
        {
            this.OfferedCourses = new List<Course>();
        }

        public List<Course> OfferedCourses
        {
            get
            {
                return new List<Course>(this.offeredCourses);
            }

            private set
            {
                this.offeredCourses = value;
            }
        }

        public bool HasCourse(Course course)
        {
            if (course == null)
            {
                throw new ArgumentNullException("course", "The course must be initialized.");
            }

            bool hasCourse = this.OfferedCourses.Contains(course);

            return hasCourse;
        }

        public void AddCourse(Course course)
        {
            if (course == null)
            {
                throw new ArgumentNullException("course", "The course must be initialized.");
            }

            if (this.HasCourse(course))
            {
                throw new ArgumentException("Course is already offered in the school.");
            }

            this.offeredCourses.Add(course);
        }

        public void RemoveCourse(Course course)
        {
            if (course == null)
            {
                throw new ArgumentNullException("course", "The course must be initialized.");
            }

            if (!this.HasCourse(course))
            {
                throw new KeyNotFoundException("Course is not offered in the school.");
            }

            this.offeredCourses.Remove(course);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < this.OfferedCourses.Count; i++)
            {
                sb.AppendLine(this.OfferedCourses[i].ToString());
            }

            return sb.ToString().TrimEnd(Environment.NewLine.ToCharArray());
        }
    }
}
