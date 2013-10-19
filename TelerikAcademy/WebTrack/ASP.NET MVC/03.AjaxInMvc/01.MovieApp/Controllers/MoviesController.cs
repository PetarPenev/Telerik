using _01.MovieApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _01.MovieApp.Controllers
{
    public class MoviesController : Controller
    {
        public ActionResult Index()
        {
            var context = new MovieContext();
            return View(context.Movies.Include("Studio").Include("LeadMaleActor").
                Include("LeadFemaleActress").ToList());
        }

        public ActionResult Success()
        {
            return View();
        }

        public ActionResult GetEditView(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var context = new MovieContext();
            var movie = context.Movies.Include("Studio").Include("LeadMaleActor").
                Include("LeadFemaleActress").FirstOrDefault(m => m.Id == id.Value);

            return PartialView("_EditMovie", movie);
        }

        public ActionResult GetDeleteView(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var context = new MovieContext();
            var movie = context.Movies.Include("Studio").Include("LeadMaleActor").
                Include("LeadFemaleActress").FirstOrDefault(m => m.Id == id.Value);

            return PartialView("_DeleteMovie", movie);
        }

        public ActionResult GetCreateView()
        {
            return PartialView("_CreateMovie", new MovieCreateViewModel());
        }

        public ActionResult DeleteMovie(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var context = new MovieContext();
            var movie = context.Movies.FirstOrDefault(m => m.Id == id.Value);
            context.Movies.Remove(movie);
            context.SaveChanges();

            return RedirectToAction("Success");
        }

        public ActionResult CreateMovie(MovieCreateInsertModel mov)
        {
            var context = new MovieContext();
            var leadMale = context.People.FirstOrDefault(p => p.Id == mov.MaleId);
            var leadFemale = context.People.FirstOrDefault(p => p.Id == mov.FemaleId);
            var director = context.People.FirstOrDefault(p => p.Id == mov.DirectorId);
            var studio = context.Studios.FirstOrDefault(s => s.Id == mov.StudioId);

            context.Movies.Add(new Movie()
            {
                Title = mov.Title,
                Year = mov.Year,
                Director = director,
                LeadFemaleActress = leadFemale,
                LeadMaleActor = leadMale,
                Studio = studio
            });

            context.SaveChanges();

            return RedirectToAction("Success");
        }

        public ActionResult EditMovie(Movie mov)
        {
            if (ModelState.IsValid)
            {
                var context = new MovieContext();
                var movieToUpdate = context.Movies.Include("Studio").Include("LeadMaleActor").
                Include("LeadFemaleActress").FirstOrDefault(m => m.Id == mov.Id);
                UpdateValues(mov, movieToUpdate);
                context.SaveChanges();
            }

            return RedirectToAction("Success");
        }

        private void UpdateValues(Movie newMovie, Movie oldMovie)
        {
            oldMovie.Title = newMovie.Title;
            oldMovie.Year = newMovie.Year;
            oldMovie.Studio.Name = newMovie.Studio.Name;
            oldMovie.Studio.Address = newMovie.Studio.Name;
            oldMovie.LeadMaleActor.Name = newMovie.LeadMaleActor.Name;
            oldMovie.LeadMaleActor.Age = newMovie.LeadMaleActor.Age;
            oldMovie.LeadFemaleActress.Name = newMovie.LeadFemaleActress.Name;
            oldMovie.LeadFemaleActress.Age = newMovie.LeadFemaleActress.Age;
            oldMovie.Director.Name = newMovie.Director.Name;
            oldMovie.Director.Age = newMovie.Director.Age;
        }
    }
}