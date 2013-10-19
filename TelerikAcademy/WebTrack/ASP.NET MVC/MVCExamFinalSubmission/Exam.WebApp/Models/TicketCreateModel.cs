using Exam.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exam.WebApp.Models
{
    public class TicketCreateModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        [Required]
        [StringDoesNotContainAttribute("bug", ErrorMessage = "Title should not contain the word bug.")]
        public string Title { get; set; }

        [Required]
        public Priority Priority { get; set; }

        public string ScreenshotUrl { get; set; }

        public string Description { get; set; }
    }
}