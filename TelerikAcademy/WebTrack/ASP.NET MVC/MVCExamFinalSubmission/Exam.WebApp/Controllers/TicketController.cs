using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Exam.WebApp.Models;
using Exam.Data;
using Exam.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

namespace Exam.WebApp.Controllers
{
    public class TicketController : BaseController
    {
        [Authorize]
        // GET: /Ticket/
        public ActionResult Index()
        {
            return View();
        }

        // GET: /Ticket/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }

            var ticketToDisplay = this.Data.Tickets.All().Where(ticket => ticket.Id == id.Value).FirstOrDefault();
            var ticketModel = new TicketFullViewModel()
            {
                Id = ticketToDisplay.Id,
                Title = ticketToDisplay.Title,
                AuthorName = ticketToDisplay.User.UserName,
                CategoryName = ticketToDisplay.Category.Name,
                Description = ticketToDisplay.Description,
                Priority = ticketToDisplay.Priority,
                ScreenshotUrl = ticketToDisplay.ScreenshotUrl,
                Comments = ticketToDisplay.Comments.Select(c => new CommentModel()
                {
                    Text = c.Text,
                    Username = c.User.UserName
                })
            };

            return View(ticketModel);
        }

         [Authorize]
        // GET: /Ticket/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(this.Data.Categories.All(), "Id", "Name");
            List<PriorityModel> priorities = new List<PriorityModel>();
            priorities.Add(new PriorityModel() { Text = "High", Value = "High" });
            priorities.Add(new PriorityModel() { Text = "Medium", Value = "Medium" });
            priorities.Add(new PriorityModel() { Text = "Low", Value = "Low" });

            ViewBag.Priority = new SelectList(priorities, "Value", "Text");
            return View();
        }

        // POST: /Ticket/Create
		// To protect from over posting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		// 
		// Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TicketCreateModel ticketToCreate)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId(); ;
                Ticket ticket = new Ticket();
                ticket.Title = ticketToCreate.Title;
                ticket.Priority = ticketToCreate.Priority;
                ticket.ScreenshotUrl = ticketToCreate.ScreenshotUrl;
                ticket.CategoryId = ticketToCreate.CategoryId;
                ticket.UserId = userId;
                ticket.Description = ticketToCreate.Description;

                this.Data.Tickets.Add(ticket);
                var user = this.Data.Users.All().Where(u => u.Id == userId).FirstOrDefault();
                user.Points += 1;

                this.Data.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(this.Data.Categories.All(), "Id", "Name", ticketToCreate.CategoryId);
            List<PriorityModel> priorities = new List<PriorityModel>();
            priorities.Add(new PriorityModel() { Text = "High", Value = "High" });
            priorities.Add(new PriorityModel() { Text = "Medium", Value = "Medium" });
            priorities.Add(new PriorityModel() { Text = "Low", Value = "Low" });

            ViewBag.Priority = new SelectList(priorities, "Value", "Text");

            return View(ticketToCreate);
        }

        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult PostComment(CommentCreateModel commentModel)
        {
            if (!ModelState.IsValid)
            {
                return HttpNotFound();
            }
            //string data = new System.IO.StreamReader(Request.InputStream).ReadToEnd();
            var ticket = this.Data.Tickets.GetById(commentModel.TicketId);
            var user = User.Identity.GetUserId();
            ticket.Comments.Add(new Comment()
            {
                Text = commentModel.CommentText,
                UserId = user
            });
            this.Data.SaveChanges();
            var data = this.Data.Comments.All().Where(c => c.TicketId == commentModel.TicketId)
                .Select(commentToSelect => new CommentModel()
                {
                    Text = commentToSelect.Text,
                    Username = commentToSelect.User.UserName
                });

            return PartialView("_CommentsPartial", data);
        }

        [Authorize]
        public JsonResult GetTickets([DataSourceRequest] DataSourceRequest request)
        {
            var data = this.Data.Tickets.All().ToList()
                    .Select(ticket => new TicketListViewModel()
                    {
                        Id = ticket.Id,
                        AuthorName = ticket.User.UserName,
                        CategoryName = ticket.Category.Name,
                        Title = ticket.Title,
                        Priority = ticket.Priority.ToString()
                    });

            return Json(data.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        public JsonResult GetCategoryData()
        {
            var result = this.Data.Categories
                .All()
                .Select(x => new CategoryModel
                {
                    Name = x.Name,
                    Id = x.Id
                }).ToList();

            result.Insert(0, new CategoryModel { Name = "Select category", Id = -1 });

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        public ActionResult Search(int categoryId)
        {

            var result = this.Data.Tickets.All().Where(t => t.CategoryId == categoryId).ToList();

            if (categoryId == -1)
            {
                result = this.Data.Tickets.All().ToList();
            }

            var searchResult = result.Select(x => new TicketListViewModel
            {
                Id = x.Id,
                AuthorName = x.User.UserName,
                CategoryName = x.Category.Name,
                Priority = x.Priority.ToString(),
                Title = x.Title
            }).ToList();

            return View("_searchResult", searchResult);
        }

        // GET: /Ticket/Edit/5
        /*public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TicketCreateModel ticketcreatemodel = db.TicketCreateModels.Find(id);
            if (ticketcreatemodel == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", ticketcreatemodel.CategoryId);
            return View(ticketcreatemodel);
        }

        // POST: /Ticket/Edit/5
		// To protect from over posting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		// 
		// Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TicketCreateModel ticketcreatemodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ticketcreatemodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", ticketcreatemodel.CategoryId);
            return View(ticketcreatemodel);
        }

        // GET: /Ticket/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TicketCreateModel ticketcreatemodel = db.TicketCreateModels.Find(id);
            if (ticketcreatemodel == null)
            {
                return HttpNotFound();
            }
            return View(ticketcreatemodel);
        }

        // POST: /Ticket/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TicketCreateModel ticketcreatemodel = db.TicketCreateModels.Find(id);
            db.TicketCreateModels.Remove(ticketcreatemodel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }*/
    }
}
