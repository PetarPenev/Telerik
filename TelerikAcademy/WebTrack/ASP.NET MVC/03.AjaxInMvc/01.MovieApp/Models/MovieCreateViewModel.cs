using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _01.MovieApp.Models
{
    public class MovieCreateViewModel
    {
        public MovieCreateViewModel()
        {
            var context = new MovieContext();
            this.Studios = context.Studios.ToList();
            this.Directors = context.People.ToList();
            this.MaleLeads = context.People.ToList();
            this.FemaleLeads = context.People.ToList();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }

        public IEnumerable<Studio> Studios { get; set; }

        public IEnumerable<Person> Directors { get; set; }

        public IEnumerable<Person> MaleLeads { get; set; }

        public IEnumerable<Person> FemaleLeads { get; set; }
    }
}