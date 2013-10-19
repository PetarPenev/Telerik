using System.Web.Mvc;

namespace _02.InformationalApp.Areas.Books
{
    public class BooksAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Books";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Books_default",
                "Books/{action}/{id}",
                new { controller = "Books", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}