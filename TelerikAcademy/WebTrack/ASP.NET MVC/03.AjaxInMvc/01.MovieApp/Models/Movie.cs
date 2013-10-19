using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _01.MovieApp.Models
{
    public class Movie
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }

        public virtual Studio Studio { get; set; }

        public virtual Person Director { get; set; }

        public virtual Person LeadMaleActor { get; set; }

        public virtual Person LeadFemaleActress { get; set; }

    }
}