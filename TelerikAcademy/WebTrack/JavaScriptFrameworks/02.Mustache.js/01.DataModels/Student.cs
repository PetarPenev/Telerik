using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.DataModels
{
    public class Student
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Grade { get; set; }

        public int Age { get; set; }

        public virtual ICollection<Mark> Marks { get; set; }

        public Student()
        {
            this.Marks = new HashSet<Mark>();
        }
    }
}
