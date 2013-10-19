using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KendoHomework.Areas.Administration.Models
{
    public class BookGridModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Isbn { get; set; }

        public string WebSite { get; set; }

        public string Description { get; set; }

        public string CategoryName { get; set; }

        public int CategoryId { get; set; }
    }
}