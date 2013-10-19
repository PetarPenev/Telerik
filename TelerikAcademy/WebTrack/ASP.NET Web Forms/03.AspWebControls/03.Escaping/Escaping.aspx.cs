using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _03.Escaping
{
    public partial class Escaping : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DisplayText(object sender, EventArgs e)
        {
            string textToEscape = this.TextToBeEscaped.Text;
            string escapedText = Server.HtmlEncode(textToEscape);

            this.OutputTextBox.Text = escapedText;
            this.OutputTextBox.Visible = true;

            this.LabelOutput.Text = escapedText;
            this.LabelOutput.Visible = true;
        }
    }
}