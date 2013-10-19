using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exam.WebApp.Models
{
    public class TicketHomePageViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string CategoryName { get; set; }

        public string AuthorName { get; set; }

        public int NumberOfComments { get; set; }
    }
}