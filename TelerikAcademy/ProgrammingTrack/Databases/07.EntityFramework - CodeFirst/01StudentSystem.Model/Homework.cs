using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace _01StudentSystem.Model
{
    public class Homework
    {
        [Key]
        public int HomeworkId { get; set; }

        public string Content { get; set; }

        public DateTime TimeSent { get; set; }

        public Course Course { get; set; }

        public Student Student { get; set; }
    }
}
