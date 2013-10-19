using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _01.NorthwindGrids
{
    public partial class Grids : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var context = new NorthwindEntities();
                var employees = context.Employees.ToList();
                this.EmployeesGrid.DataSource = employees;
                this.EmployeesGrid.DataBind();
            }
        }

        protected void EmployeesGrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(3000);
            var context = new NorthwindEntities();
            try
            {
                var empId = int.Parse(this.EmployeesGrid.SelectedRow.Cells[1].Text);
                var orders = context.Orders.Where(o => o.EmployeeID == empId).ToList();
                this.OrdersGrid.DataSource = orders;
                this.OrdersGrid.DataBind();
            }
            catch (Exception ex)
            {
                Console.WriteLine();
            }
        }
    }
}