using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _03.Web
{
    public partial class Main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.ListBoxContinents.SelectedValue == string.Empty)
            {
                this.ContainerAddCountry.Attributes.CssStyle.Add(HtmlTextWriterStyle.Display, "none");
            }
        }

        protected void SaveCountryButton_Click(object sender, EventArgs e)
        {
            var context = new WorldDBEntities();
            long population;
            if (this.CountryName.Text == string.Empty || this.CountryName.Text.Length > 50 ||
                this.CountryLanguage.Text == string.Empty || this.CountryLanguage.MaxLength > 50
                || this.CountryPopulation.Text == string.Empty || !long.TryParse(this.CountryPopulation.Text, out population))
            {
                this.ResultCountryAdd.Text = "Invalid input parameters.";
                return;
            }

            if (population < 0)
            {
                this.ResultCountryAdd.Text = "Invalid input parameters.";
                return;
            }
            
            var country = new Country();
            country.Name = this.CountryName.Text;
            country.Language = this.CountryLanguage.Text;
            country.Population = population;
            country.ContinentId = int.Parse(this.ListBoxContinents.SelectedValue);

            FileUpload fileUploader = this.NewFlagUploader;
            if (fileUploader.HasFile)
            {
                Byte[] imgByte = null;
                HttpPostedFile File = fileUploader.PostedFile;
                imgByte = new Byte[File.ContentLength];
                File.InputStream.Read(imgByte, 0, File.ContentLength);
                country.Flag = imgByte;
            }

            context.Countries.Add(country);
            context.SaveChanges();
            this.GridViewCountries.DataBind();

            context.Dispose();
        }

        protected void ListBoxContinents_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ContainerAddCountry.Attributes.CssStyle.Add(HtmlTextWriterStyle.Display, "block");
            this.ContinentEditNameBox.Text = this.ListBoxContinents.SelectedItem.Text;
        }

        protected void ListViewTowns_ItemInserted(object sender, ListViewInsertedEventArgs e)
        {

        }

        protected void AddContinentButton_Click(object sender, EventArgs e)
        {
            if (this.ContinentNameBox.Text == string.Empty || this.ContinentNameBox.Text.Length > 20)
            {
                this.ResultContinentAdd.Text = "Invalid input parameters.";
            }

            var context = new WorldDBEntities();
            var cont = new Continent();
            cont.Name = this.ContinentNameBox.Text;
            context.Continents.Add(cont);
            context.SaveChanges();
            this.ListBoxContinents.DataBind();
        }

        protected void EditContinentButton_Click(object sender, EventArgs e)
        {
            if (this.ContinentEditNameBox.Text == string.Empty || this.ContinentNameBox.Text.Length > 20
                || this.ListBoxContinents.SelectedItem ==null)
            {
                this.ResultContinentUpdate.Text = "Invalid input parameters.";
                return;
            }

            var context = new WorldDBEntities();
            var idNumber = int.Parse(this.ListBoxContinents.SelectedItem.Value);
            var cont = context.Continents.SingleOrDefault(c => c.Id == idNumber);
            if (cont == null)
            {
                this.ResultContinentUpdate.Text = "Invalid input parameters.";
                return;
            }

            cont.Name = this.ContinentEditNameBox.Text;
            context.SaveChanges();
            this.ListBoxContinents.DataBind();
        }

        protected void GridViewCountries_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ListViewTowns.InsertItemPosition = InsertItemPosition.LastItem;
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            var context = new WorldDBEntities();
            var idNumber = int.Parse(this.ListBoxContinents.SelectedItem.Value);
            var cont = context.Continents.SingleOrDefault(c => c.Id == idNumber);
            context.Continents.Remove(cont);
            context.SaveChanges();
            this.ListBoxContinents.DataBind();
            this.ListViewTowns.DataBind();
        }

        protected string GenerateImageStringFromDb(object val)
        {
            if (val == null)
            {
                return string.Empty;
            }

            var arr = (byte[])val;

            return "data:image;base64," + Convert.ToBase64String(arr);
        }

        protected void GridViewCountries_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            FileUpload fileUploader = (FileUpload)this.GridViewCountries.Rows[e.RowIndex].FindControl("FileUploaded");
            if (fileUploader.HasFile)
            {
               // e.NewValues["Flag"] = fileUploader.PostedFile.
                Byte[] imgByte = null;
                HttpPostedFile File = fileUploader.PostedFile;
                imgByte = new Byte[File.ContentLength];
                File.InputStream.Read(imgByte, 0, File.ContentLength);
                e.NewValues["Flag"] = imgByte;
            }
        }
    }
}