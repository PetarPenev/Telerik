using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class School
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Location { get; set; }

        public virtual ICollection<Student> Students { get; set; }

        public School()
        {
            this.Students = new HashSet<Student>();
        }
    }
}
