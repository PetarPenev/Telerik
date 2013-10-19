using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _06.ToDoApp
{
    public partial class ToDoApp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Page_SaveStateComplete(object sender, EventArgs e)
        {
            this.EditCategoryNameBox.Text = this.DropDownListCategories.SelectedItem.Text;
        }

        protected void DeleteCategoryButton_Click(object sender, EventArgs e)
        {
            var context = new ListDBEntities();
            var idValue = int.Parse(this.DropDownListCategories.SelectedValue);
            var categoryToRemove = context.Categories.SingleOrDefault(c => c.Id == idValue);
            if (categoryToRemove == null)
            {
                this.MessagesTextbox.Text = "Category does not exist.";
                return;
            }

            context.Categories.Remove(categoryToRemove);
            context.SaveChanges();
            this.DropDownListCategories.DataBind();
            context.Dispose();
        }

        protected void CreateCategoryButton_Click(object sender, EventArgs e)
        {
            if (this.NewCategoryNameBox.Text == string.Empty || this.NewCategoryNameBox.Text.Length > 30)
            {
                this.MessagesTextbox.Text = "Invalid category input data.";
                return;
            }

            var context = new ListDBEntities();
            var newCategory = new Category();
            newCategory.Name = this.NewCategoryNameBox.Text;
            context.Categories.Add(newCategory);
            context.SaveChanges();
            this.DropDownListCategories.DataBind();
            context.Dispose();
        }

        protected void EditCategoryButton_Click(object sender, EventArgs e)
        {
            if (this.EditCategoryNameBox.Text == string.Empty || this.EditCategoryNameBox.Text.Length > 30)
            {
                this.MessagesTextbox.Text = "Invalid category input data.";
                return;
            }

            var context = new ListDBEntities();
            var idValue = int.Parse(this.DropDownListCategories.SelectedValue);
            var editedCategory = context.Categories.SingleOrDefault(c=> c.Id == idValue);
            if (editedCategory == null)
            {
                this.MessagesTextbox.Text = "Invalid category input data.";
                return;
            }

            editedCategory.Name = this.EditCategoryNameBox.Text;
            context.SaveChanges();
            this.DropDownListCategories.DataBind();
            context.Dispose();
        }

        protected void DropDownListCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.EditCategoryNameBox.Text = this.DropDownListCategories.SelectedItem.Text;
        }

        protected void ListView1_ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            e.NewValues["LastChangedDate"] = DateTime.Now;
        }

        protected void ListViewTodos_ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            e.Values["LastChangedDate"] = DateTime.Now;
            e.Values["CategoryId"] = this.DropDownListCategories.SelectedValue;
        }
    }
}