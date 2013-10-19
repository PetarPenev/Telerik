using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exam.WebApp.Models
{
    public class CommentCreateModel
    {
        [Required]
        public int TicketId { get; set; }

        [Required]
        public string CommentText { get; set; }
    }
}