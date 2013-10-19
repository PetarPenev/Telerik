using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Summator
{
    public partial class Sum : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SumInputs(object sender, EventArgs e)
        {
            try
            {
                string firstValue = this.firstNumberInput.Text.Replace(',', '.');
                string secondValue = this.secondNumberInput.Text.Replace(',', '.');
                decimal firstNumber = decimal.Parse(firstValue);
                decimal secondNumber = decimal.Parse(secondValue);
                decimal sum = firstNumber + secondNumber;
                this.SumValue.Text = sum.ToString();
            }
            catch (Exception ex)
            {
                this.SumValue.Text = "Please enter valid inputs." + ex.Message;
            }
        }

    }
}