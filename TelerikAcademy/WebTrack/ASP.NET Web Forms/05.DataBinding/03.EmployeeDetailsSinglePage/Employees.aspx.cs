using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _03.EmployeeDetailsSinglePage
{
    public partial class Employees : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Visualize(Object sender, CommandEventArgs e)
        {
            this.EmployeeDetals.SelectParameters["empId"].DefaultValue = e.CommandArgument.ToString();
            this.FormViewEmployee.DataSourceID = "EmployeeDetals";
            this.FormViewEmployee.DataBind();
        }
    }
}