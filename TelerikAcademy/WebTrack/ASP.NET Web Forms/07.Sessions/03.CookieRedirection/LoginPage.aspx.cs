using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _03.CookieRedirection
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["Username"] == null)
            {
                this.UserStatus.Text = "Not logged in.";
            }
            else
            {
                this.UserStatus.Text = "User: " + Request.Cookies["Username"].Value;
            }
        }

        protected void RedirectButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("RedirectPage.aspx", false);
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            if (this.UsernameInput.Text == string.Empty)
            {
                this.UserStatus.Text = "Username must be at least 1 character.";
                return;
            }

            HttpCookie cookie = new HttpCookie("Username", this.UsernameInput.Text);
            cookie.Expires = DateTime.Now.AddMinutes(1);

            Response.Cookies.Add(cookie);
            this.UserStatus.Text = "User: " + Response.Cookies["Username"].Value;
        }
    }
}