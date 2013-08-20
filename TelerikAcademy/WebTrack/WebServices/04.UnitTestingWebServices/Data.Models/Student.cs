using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public int Age { get; set; }

        public int Grade { get; set; }

        public School School { get; set; }

        public virtual ICollection<Mark> Marks { get; set; }

        public Student()
        {
            this.Marks = new HashSet<Mark>();
        }
    }
}
