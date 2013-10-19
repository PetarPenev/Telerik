using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Exam.Models;
using Exam.Data;
using Exam.WebApp.Controllers;
using Exam.WebApp.Models;

namespace Exam.WebApp.Areas.Administration.Controllers
{
    public class CommentsAdminController : BaseController
    {

        // GET: /Administration/CommentsAdmin/
        public ActionResult Index()
        {
            var comments = this.Data.Comments.All().Include(c => c.Ticket).Include(c => c.User);
            return View(comments.ToList());
        }

        // GET: /Administration/CommentsAdmin/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Comment comment = this.Data.Comments.GetById(id.Value);
            if (comment == null)
            {
                return HttpNotFound();
            }

            return View(comment);
        }

        // GET: /Administration/CommentsAdmin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Comment comment = this.Data.Comments.All().FirstOrDefault(c => c.Id == id.Value);
            CommentEditModel model = new CommentEditModel()
            {
                Text = comment.Text,
                Id = comment.Id
            };

            if (comment == null)
            {
                return HttpNotFound();
            }

            return View(model);
        }

        // POST: /Administration/CommentsAdmin/Edit/5
		// To protect from over posting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		// 
		// Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Comment comment)
        {
            if (ModelState.IsValid)
            {
                var commentToEdit = this.Data.Comments.GetById(comment.Id);
                commentToEdit.Text = comment.Text;
                this.Data.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(comment);
        }

        // GET: /Administration/CommentsAdmin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = this.Data.Comments.GetById(id.Value);
            if (comment == null)
            {
                return HttpNotFound();
            }

            return View(comment);
        }

        // POST: /Administration/CommentsAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comment comment = this.Data.Comments.GetById(id);
            this.Data.Comments.Delete(comment);
            this.Data.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
