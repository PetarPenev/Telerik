using Exam.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Data
{
    public class DatabaseInitializer : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public DatabaseInitializer()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            if (context.Tickets.Count() > 0)
            {
                return;
            }

            var userAdmin = new ApplicationUser()
            {
                UserName = "admin",
                Points = 10,
                Roles = new Collection<UserRole>()
                {
                    new UserRole()
                    {
                        Role = new Role("Admin")
                    }
                }
            };

            var ordinaryUser = new ApplicationUser()
            {
                UserName = "user",
                Points = 10
            };

            context.Users.Add(userAdmin);
            context.Users.Add(ordinaryUser);
            context.SaveChanges();

            var firstCategory = new Category();
            firstCategory.Name = "Microsoft Tickets";

            var secondCategory = new Category();
            secondCategory.Name = "Telerik Tickets";
            context.Categories.Add(firstCategory);
            context.Categories.Add(secondCategory);
            context.SaveChanges();

            var firstMicrosoftTicket = new Ticket();
            firstMicrosoftTicket.Title = "VS RC 2013 Ticket";
            firstMicrosoftTicket.Priority = Priority.High;
            firstMicrosoftTicket.ScreenshotUrl = "http://www.freepasswordmanager.com/wp-content/uploads/2013/05/MicrosoftLogo.jpg";
            firstMicrosoftTicket.Description = "Visual Studio Ticket Description";
            firstMicrosoftTicket.UserId = userAdmin.Id;
            firstMicrosoftTicket.Comments.Add(new Comment() { Text = "Very urgent ticket", UserId = userAdmin.Id });
            firstMicrosoftTicket.CategoryId = firstCategory.Id;

            context.Tickets.Add(firstMicrosoftTicket);
            context.SaveChanges();

            var firstTelerikTicket = new Ticket();
            firstTelerikTicket.Title = "Kendo Ticket";
            firstTelerikTicket.Priority = Priority.Medium;
            firstTelerikTicket.ScreenshotUrl = "http://telerik-kids.com/images/default-album/kidsacademy.jpg";
            firstTelerikTicket.Description = "Kendo Multiselect Ticket Description";
            firstTelerikTicket.UserId = ordinaryUser.Id;
            firstTelerikTicket.Comments.Add(new Comment() { Text = "Cannot bind correctly.", UserId = ordinaryUser.Id });
            firstTelerikTicket.CategoryId = secondCategory.Id;

            context.Tickets.Add(firstTelerikTicket);
            context.SaveChanges();

            var secondTelerikTicket = new Ticket();
            secondTelerikTicket.Title = "Test Studio Ticket";
            secondTelerikTicket.Priority = Priority.Low;
            secondTelerikTicket.ScreenshotUrl = "http://telerik-kids.com/images/default-album/kidsacademy.jpg";
            secondTelerikTicket.Description = "Test Studio Ticket Description";
            secondTelerikTicket.UserId = ordinaryUser.Id;
            secondTelerikTicket.Comments.Add(new Comment() { Text = "Will address in the near future.", UserId = userAdmin.Id });
            secondTelerikTicket.Comments.Add(new Comment() { Text = "Thank you very much.", UserId = ordinaryUser.Id });
            secondTelerikTicket.CategoryId = secondCategory.Id;

            context.Tickets.Add(secondTelerikTicket);
            context.SaveChanges();

            var thirdTelerikTicket = new Ticket();
            thirdTelerikTicket.Title = "Sitefinity Ticket";
            thirdTelerikTicket.Priority = Priority.High;
            thirdTelerikTicket.ScreenshotUrl = "http://telerik-kids.com/images/default-album/kidsacademy.jpg";
            thirdTelerikTicket.Description = "Sitefinity Ticket Description";
            thirdTelerikTicket.UserId = ordinaryUser.Id;
            thirdTelerikTicket.Comments.Add(new Comment() { Text = "Will address shortly.", UserId = userAdmin.Id });
            thirdTelerikTicket.Comments.Add(new Comment() { Text = "Be prompt.", UserId = ordinaryUser.Id });
            thirdTelerikTicket.CategoryId = secondCategory.Id;

            context.Tickets.Add(thirdTelerikTicket);
            context.SaveChanges();
        }
    }
}
