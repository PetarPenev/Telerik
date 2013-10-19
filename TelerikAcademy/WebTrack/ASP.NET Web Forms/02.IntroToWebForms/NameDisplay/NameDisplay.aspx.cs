using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NameDisplay
{
    public partial class NameDisplay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ShowName(object sender, EventArgs e)
        {
            string name = this.NameValue.Text;

            if (string.IsNullOrEmpty(name))
            {
                this.GreetingText.Text = "Please enter a valid name.";
            }
            else
            {
                string output = "Hello, " + name + "!";
                this.GreetingText.Text = output;
            }
        }
    }
}