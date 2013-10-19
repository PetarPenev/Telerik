using _02.InformationalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _02.InformationalApp.Controllers
{
    public class AuthorsController : Controller
    {
        public ActionResult Index(string id)
        {
            if (id == null)
            {
                return View("Authors", null);
            }

            ModelState.Clear();
            return View("Authors", Data.Authors.FirstOrDefault(c => c.Id == int.Parse(id)));
        }

        [HttpPost]
        public ActionResult Create(string authorName)
        {
            var max = Data.Authors.OrderByDescending(c => c.Id).FirstOrDefault();
            int newId = (max == null) ? 0 : max.Id;
            Data.Authors.Add(new Author() { Id = newId + 1, Name = authorName });
            ModelState.Clear();
            return View("Authors");
        }

        public ActionResult Edit(string authorName, int? id)
        {
            if ((authorName == null) || (id == null))
            {
                return RedirectToAction("Index", "Authors");
            }

            var authorToEdit = Data.Authors.FirstOrDefault(c => c.Id == id.Value);
            authorToEdit.Name = authorName;

            ModelState.Clear();
            return View("Authors");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Authors");
            }

            var idValue = id.Value;
            var authorToDelete = Data.Authors.FirstOrDefault(c => c.Id == id.Value);
            Data.Authors.Remove(authorToDelete);
            for (int i = Data.Books.Count - 1; i >= 0; i--)
            {
                if (Data.Books[i].AuthorId == idValue)
                {
                    Data.Books.RemoveAt(i);
                }
            }

            ModelState.Clear();
            return View("Authors");
        }
    }
}