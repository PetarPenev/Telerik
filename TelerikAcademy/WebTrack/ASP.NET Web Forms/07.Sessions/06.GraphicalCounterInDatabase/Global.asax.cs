using _06.ModelData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace _06.GraphicalCounterInDatabase
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            var context = new DataContext();
            var data = context.Data.SingleOrDefault();
            if (data == null)
            {
                var visitorData = new VisitorData();
                context.Data.Add(visitorData);
                context.SaveChanges();
                return;
            }
            else
            {
                data.Number = 0;
                context.SaveChanges();
            }
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}