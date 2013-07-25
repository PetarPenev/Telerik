using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace _01StudentSystem.Model
{
    public class Course
    {
        private ICollection<Homework> homeworks;

        private ICollection<Student> students;

        public Course()
        {
            this.homeworks = new HashSet<Homework>();
            this.students = new HashSet<Student>();
        }

        [Key]
        public int CourseId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Materials { get; set; }

        public virtual ICollection<Homework> Homeworks
        {
            get
            {
                return this.homeworks;
            }

            set
            {
                this.homeworks = value;
            }
        }

        public virtual ICollection<Student> Students
        {
            get
            {
                return this.students;
            }

            set
            {
                this.students = value;
            }
        }
    }
}
