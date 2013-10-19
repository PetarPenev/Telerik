using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _01.MovieApp.Models
{
    public class MovieCreateInsertModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }

        public int StudioId { get; set; }

        public int DirectorId { get; set; }

        public int MaleId { get; set; }

        public int FemaleId { get; set; }
    }
}