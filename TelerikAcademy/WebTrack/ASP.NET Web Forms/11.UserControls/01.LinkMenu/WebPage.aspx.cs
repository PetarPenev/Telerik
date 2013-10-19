using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _01.LinkMenu
{
    public partial class WebPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Link> links = new List<Link>();
            links.Add(new Link() { URL = "http://www.google.com", Text = "Google" });
            links.Add(new Link() { URL = "http://www.abv.bg", Text = "Abv" });
            links.Add(new Link() { URL = "http://www.gol.bg", Text = "Gol" });
            links.Add(new Link() { URL = "http://www.coursera.com", Text = "Goursera" });

            this.UrlMenu.DataSource = links;
            this.UrlMenu.DataBind();
            this.UrlMenu.Color = this.UrlMenu.Color;
        }
    }
}