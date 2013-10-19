using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _01.PrintIp
{
    public partial class PrintIp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.BrowserLiteral.Text = Request.Browser.Type;
            // This is working with appharbor deployment. Under localhost, depending on you settings, you may
            // get your IPv6 address which will be ::1.
            string visitorIPAddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];


            if (String.IsNullOrEmpty(visitorIPAddress))
            {
                visitorIPAddress = Request.ServerVariables["REMOTE_ADDR"];
            }

            if (string.IsNullOrEmpty(visitorIPAddress))
            {
                visitorIPAddress = Request.UserHostAddress;
            }

            this.IpLiteral.Text = visitorIPAddress;
        }
    }
}