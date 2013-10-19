using _02.InformationalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _02.InformationalApp.Areas.Books.Controllers
{
    public class BooksController : Controller
    {
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return View("Books", null);
            }

            return View("Books", Data.Books.FirstOrDefault(b => b.Id == id.Value));
        }

        [HttpPost]
        public ActionResult Create(string bookName, string categoryName, string authorName)
        {
            if ((bookName == null))
            {
                return RedirectToAction("Index", "Books");
            }

            var max = Data.Books.OrderByDescending(c => c.Id).FirstOrDefault();
            int newId = (max == null) ? 0 : max.Id;
            int catId = Data.Categories.FirstOrDefault(c => c.Name == categoryName).Id;
            var authId = Data.Authors.FirstOrDefault(a => a.Name == authorName).Id;

            Data.Books.Add(new Book() { Id = newId + 1, Name = bookName, CategoryId = catId, AuthorId = authId });
            ModelState.Clear();
            return View("Books", null);
        }

        public ActionResult Edit(string bookName, string categoryName, string authorName, int? id)
        {
            if ((bookName == null) || (id==null))
            {
                return RedirectToAction("Index", "Books");
            }

            var bookToEdit = Data.Books.FirstOrDefault(c => c.Id == id.Value);
            bookToEdit.Name = bookName;
            int catId = Data.Categories.FirstOrDefault(c => c.Name == categoryName).Id;
            var authId = Data.Authors.FirstOrDefault(a => a.Name == authorName).Id;
            bookToEdit.CategoryId = catId;
            bookToEdit.AuthorId = authId;

            ModelState.Clear();
            return View("Books");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Books");
            }

            var idValue = id.Value;
            var bookToDelete = Data.Books.FirstOrDefault(c => c.Id == id.Value);
            Data.Books.Remove(bookToDelete);

            ModelState.Clear();
            return View("Books");
        }
    }
}