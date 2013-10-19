using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _02.InformationalApp.Models;

namespace _02.InformationalApp.Controllers
{
    public class CategoriesController : Controller
    {
        public ActionResult Index(string id)
        {
            if (id == null)
            {
                return View("Categories", null);
            }

            ModelState.Clear();
            return View("Categories", Data.Categories.FirstOrDefault(c => c.Id == int.Parse(id)));
        }

        [HttpPost]
        public ActionResult Create(string categoryName)
        {
            var max = Data.Categories.OrderByDescending(c => c.Id).FirstOrDefault();
            int newId = (max == null) ? 0 : max.Id;
            Data.Categories.Add(new Category() { Id = newId + 1, Name = categoryName});
            ModelState.Clear();
            return View("Categories");
        }

        public ActionResult Edit(string categoryName, int? id)
        {
            if ((categoryName==null) || (id == null))
            {
                return RedirectToAction("Index", "Categories");
            }

            var idValue = id.Value;
            var categoryToEdit = Data.Categories.FirstOrDefault(c => c.Id == idValue);
            categoryToEdit.Name = categoryName;

            ModelState.Clear();
            return View("Categories");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Categories");
            }

            var idValue = id.Value;
            var categoryToDelete = Data.Categories.FirstOrDefault(c => c.Id == id.Value);
            Data.Categories.Remove(categoryToDelete);
            for (int i = Data.Books.Count - 1; i >= 0; i--)
            {
                if (Data.Books[i].CategoryId == idValue)
                {
                    Data.Books.RemoveAt(i);
                }
            }

            ModelState.Clear();
            return View("Categories");
        }
    }
}