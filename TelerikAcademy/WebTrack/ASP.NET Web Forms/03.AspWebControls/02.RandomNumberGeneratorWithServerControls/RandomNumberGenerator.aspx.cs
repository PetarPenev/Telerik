using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _02.RandomNumberGeneratorWithServerControls
{
    public partial class RandomNumberGenerator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GenerateRandomNumber(object sender, EventArgs e)
        {
            try
            {
                int intervalStart = (int)decimal.Parse(this.IntervalStart.Text.Replace(',', '.'));
                int intervalEnd = (int)decimal.Parse(this.IntevalEnd.Text.Replace(',', '.'));
                Random rand = new Random();
                var randomNumber = rand.Next(intervalStart, intervalEnd + 1);
                this.OutputDiv.Text = randomNumber.ToString();
                this.OutputDiv.Visible = true;
            }
            catch (Exception ex)
            {
                this.OutputDiv.Text = "Problem with generating random number: " + ex.Message;
                this.OutputDiv.Visible = true;
            }
        }
    }
}