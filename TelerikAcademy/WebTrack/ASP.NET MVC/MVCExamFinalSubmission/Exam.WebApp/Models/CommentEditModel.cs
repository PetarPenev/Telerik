using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exam.WebApp.Models
{
    public class CommentEditModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }
    }
}