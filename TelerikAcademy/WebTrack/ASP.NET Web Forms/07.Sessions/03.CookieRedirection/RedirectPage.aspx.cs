using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _03.CookieRedirection
{
    public partial class RedirectPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["Username"] == null)
            {
                Response.Redirect("LoginPage.aspx");
            }
            else
            {
                this.StatusOfRequest.Text = "User: " + Request.Cookies["Username"].Value;
            }
        }
    }
}