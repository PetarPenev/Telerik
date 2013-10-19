using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace PageLifecycle
{
    public partial class PageLifecycle : System.Web.UI.Page
    {
        private void CreateDiv(string content)
        {
            HtmlGenericControl divElement = new HtmlGenericControl("div");
            divElement.InnerText = content;
            this.DivContainer.Controls.Add(divElement);
        }

        protected void Page_PreInit(object sender, EventArgs e)
        {
            CreateDiv("Page_PreInit invoked");
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            CreateDiv("Page_Init invoked");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            CreateDiv("Page_Load invoked");
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            CreateDiv("Page_PreRender invoked");
        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            // Response is unavailable at page unload
            // Response.Write("Page_Unload invoked" + "<br/>");
        }

        protected void ButtonOK_Init(object sender, EventArgs e)
        {
            CreateDiv("ButtonOK_Init invoked");
        }

        protected void ButtonOK_Load(object sender, EventArgs e)
        {
            CreateDiv("ButtonOK_Load invoked");
        }

        protected void ButtonOK_Click(object sender, EventArgs e)
        {
            CreateDiv("ButtonOK_Click invoked");
        }

        protected void ButtonOK_PreRender(object sender, EventArgs e)
        {
            CreateDiv("ButtonOK_PreRender invoked");
        }

        protected void ButtonOK_Unload(object sender, EventArgs e)
        {
            // Response is unavailable at control unload
            // Response.Write("ButtonOK_Unload invoked" + "<br/>");
        }
    }
}