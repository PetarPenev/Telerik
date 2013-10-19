using Exam.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exam.WebApp.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            if (this.HttpContext.Cache["HomePageTickets"] == null)
            {
                var tickets = this.Data.Tickets.All().OrderByDescending(ticket => ticket.Comments.Count())
                    .Select(ticket => new TicketHomePageViewModel()
                    {
                        Id = ticket.Id,
                        Title = ticket.Title,
                        CategoryName = ticket.Category.Name,
                        AuthorName = ticket.User.UserName,
                        NumberOfComments = ticket.Comments.Count()
                    }).Take(6);

                this.HttpContext.Cache.Add("HomePageTickets", tickets.ToList(), null, DateTime.Now.AddHours(1), TimeSpan.Zero, System.Web.Caching.CacheItemPriority.Default, null);
            }
            return View(this.HttpContext.Cache["HomePageTickets"]);
        }
    }
}