using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _02.InformationalApp.Models
{
    public class Book
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CategoryId { get; set; }

        public int AuthorId { get; set; }
    }
}