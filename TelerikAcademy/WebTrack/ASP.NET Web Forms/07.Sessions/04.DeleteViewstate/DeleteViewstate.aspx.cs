using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _04.DeleteViewstate
{
    public partial class DeleteViewstate : System.Web.UI.Page
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (ViewState["result"] == null)
            {
                ViewState["result"] = string.Empty;
            }
            else
            {
                this.Text.Text = (string)ViewState["result"];
            }
        }

        protected void ButtonSaveText_Click(object sender, EventArgs e)
        {
            ViewState["result"] = this.Text.Text;
        }
    }
}