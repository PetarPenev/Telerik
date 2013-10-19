using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AssemblyDisplay
{
    public partial class WriteHelloAsp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GetName(object sender, EventArgs e)
        {
            this.NameFromCodeBehind.Text = "Hello, ASP!";
        }

        protected void GetAssembly(object sender, EventArgs e)
        {
            var path = Assembly.GetExecutingAssembly().CodeBase;
            this.PathToAssembly.Text = path;
        }
    }
}