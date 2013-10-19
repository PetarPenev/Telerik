using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace _04.RegistrationForm
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void VisualizeInputs(object sender, EventArgs e)
        {
            string firstNameValue = this.FirstNameInput.Text;
            string lastNameValue = this.LastNameInput.Text;
            CreateTag("h1", firstNameValue + " " + lastNameValue);

            try
            {
                int facultyNumberValue = int.Parse(this.FacultyNumberInput.Text);
                CreateTag("div", facultyNumberValue.ToString());
            }
            catch (Exception ex)
            {
                this.OutputDiv.InnerHtml = "Problem with faculty number input. Should be a valid integer number.";
                return;
            }

            string universityValue = this.UniversityInput.SelectedItem.Text;
            CreateTag("div", universityValue);

            string specialtyValue = this.SpecialtyInput.SelectedItem.Text;
            CreateTag("div", specialtyValue);

            var courseValuesArray = this.CourseInput.Items.OfType<ListItem>().Where(item => item.Selected);
            foreach (var course in courseValuesArray)
            {
                CreateTag("div", course.Text);
            }

            this.OutputDiv.Visible = true;
        }

        private void CreateTag(string tag, string content)
        {
            HtmlGenericControl divElement = new HtmlGenericControl(tag);
            divElement.InnerText = content;
            this.OutputDiv.Controls.Add(divElement);
        }
    }
}