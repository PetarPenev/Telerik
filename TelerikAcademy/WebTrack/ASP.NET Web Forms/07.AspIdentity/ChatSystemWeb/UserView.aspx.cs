using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChatSystemWeb
{
    public partial class UserView : System.Web.UI.Page
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var context = new ChatDbEntities();
                this.MessagesGrid.DataSource = context.Messages.ToList();
                this.MessagesGrid.DataBind();
            }
        }

        protected void MessagesGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.MessagesGrid.PageIndex = e.NewPageIndex;
        }

        protected void MessagesGrid_Sorting(object sender, GridViewSortEventArgs e)
        {
            if (e.SortExpression == "Author")
            {
                var context = new ChatDbEntities();
                IQueryable<Message> data;
                if (this.MessagesGrid.Attributes["CurrentSortDirAuthor"] == "ASC")
                {
                    data = context.Messages.OrderBy(c => c.Author);
                    this.MessagesGrid.Attributes["CurrentSortDirAuthor"] = "DESC";
                }
                else
                {
                    data = context.Messages.OrderByDescending(c => c.Author);
                    this.MessagesGrid.Attributes["CurrentSortDirAuthor"] = "ASC";
                }

                this.MessagesGrid.DataSource = data.ToList();
                this.MessagesGrid.DataBind();
            }
            else if (e.SortExpression == "Text")
            {
                var context = new ChatDbEntities();
                IQueryable<Message> data;
                if (this.MessagesGrid.Attributes["CurrentSortDirText"] == "DESC")
                {
                    data = context.Messages.OrderByDescending(c => c.Text);
                    this.MessagesGrid.Attributes["CurrentSortDirText"] = "ASC";
                }
                else
                {
                    data = context.Messages.OrderBy(c => c.Text);
                    this.MessagesGrid.Attributes["CurrentSortDirText"] = "DESC";
                }

                this.MessagesGrid.DataSource = data.ToList();
                this.MessagesGrid.DataBind();
            }

        }

        protected void PostMessageBtn_Click(object sender, EventArgs e)
        {
            if (this.MessageContent.Text == string.Empty || this.MessageContent.Text.Length > 20)
            {
                this.ErrorContent.Text = "Invalid message content input.";
                return;
            }

            var context = new ChatDbEntities();
            var username = this.User.Identity.Name;
            var userPosting = context.AspNetUsers.SingleOrDefault(u => u.UserName == username);
            if (userPosting == null)
            {
                this.ErrorContent.Text = "Invalid credential information.";
                return;
            }

            var messageToPost = new Message();
            messageToPost.Text = this.MessageContent.Text;
            messageToPost.Author = userPosting.FirstName + " " + userPosting.LastName;
            messageToPost.Creator_Id = userPosting.Id;
            context.Messages.Add(messageToPost);
            context.SaveChanges();
            this.MessagesGrid.DataSource = context.Messages.ToList();
            this.MessagesGrid.DataBind();
            this.ErrorContent.Text = "Message added";
        }
    }
}