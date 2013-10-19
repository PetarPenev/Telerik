using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _01.BasicRegisterValidation
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                this.LabelMessage.Text = "The page is valid!";
                // Perform some logic here
            }
            this.LabelMessage.Visible = Page.IsValid;
        }

        protected void UsernameLengthValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            var text = this.UsernameInput.Text.Length;
            args.IsValid = text >= 6;
        }

        protected void PasswordLengthValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            var text = this.PasswordInput.Text.Length;
            args.IsValid = text >= 6;
        }

        protected void RepeatPasswordLengthValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            var text = this.RepeatPasswordInput.Text.Length;
            args.IsValid = text >= 6;
        }

        protected void FirstNameLengthValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            var text = this.FirstNameInput.Text.Length;
            args.IsValid = text >= 2;
        }

        protected void LastNameLengthValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            var text = this.LastNameInput.Text.Length;
            args.IsValid = text >= 2;
        }

        protected void CustomValidatorAgreement_ServerValidate(object source, ServerValidateEventArgs args)
        {
            var isChecked = this.AcceptInput.Checked;
            args.IsValid = isChecked;
        }
    }
}