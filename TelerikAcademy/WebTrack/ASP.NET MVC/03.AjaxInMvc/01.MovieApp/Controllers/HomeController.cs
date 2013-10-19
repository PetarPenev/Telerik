using _01.MovieApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _01.MovieApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var context = new MovieContext();
            return View(context.Movies.Include("Studio").Include("LeadMaleActor").
                Include("LeadFemaleActress").ToList());
        }
    }
}