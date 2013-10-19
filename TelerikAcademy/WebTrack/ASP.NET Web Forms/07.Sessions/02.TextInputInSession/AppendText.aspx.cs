using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _02.TextInputInSession
{
    public partial class AppendText : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ListStrings"] == null)
            {
                Session["ListStrings"] = new List<string>();
            }
        }

        protected void AppendTextButton_Click(object sender, EventArgs e)
        {
            if (TextBoxInput.Text == string.Empty)
            {
                return;
            }

            List<string> results = (List<string>)Session["ListStrings"];
            results.Add(this.TextBoxInput.Text);
            Session["ListStrings"] = results;
            this.TextResult.Text = string.Join(Environment.NewLine, results);
        }
    }
}