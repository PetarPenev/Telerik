using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Mark
    {
        [Key]
        public int Id { get; set; }

        public Subject Subject { get; set; }

        [Required]
        public int Value { get; set; }
    }
}
