using Exam.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exam.WebApp.Models
{
    public class TicketFullViewModel
    {
        [Key]
        public int Id { get; set; }

        public string CategoryName { get; set; }

        public string AuthorName { get; set; }

        public string Title { get; set; }

        public Priority Priority { get; set; }

        public string ScreenshotUrl { get; set; }

        public string Description { get; set; }

        public IEnumerable<CommentModel> Comments { get; set; }
    }
}