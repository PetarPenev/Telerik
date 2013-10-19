using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RandomNumberGenerator
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
                int intervalStart = (int)decimal.Parse(this.IntervalStart.Value.Replace(',', '.'));
                int intervalEnd = (int)decimal.Parse(this.IntevalEnd.Value.Replace(',', '.'));
                Random rand = new Random();
                var randomNumber = rand.Next(intervalStart, intervalEnd + 1);
                this.OutputDiv.InnerText = randomNumber.ToString();
                this.OutputDiv.Visible = true;
            }
            catch (Exception ex)
            {
                this.OutputDiv.InnerText = "Problem with generating random number: " + ex.Message;
                this.OutputDiv.Visible = true;
            }
        }
    }
}