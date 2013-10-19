using _02.ChatCodeFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _02.ChatApp
{
    public partial class Chat : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var context = new ChatContext();
                var messages = context.Messages.OrderByDescending(c => c.Date).Take(100).ToList();
                this.MessagesGrid.DataSource = messages;
                this.MessagesGrid.DataBind();
            }
        }

        protected void ButtonPostMessage_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(3000);
            var context = new ChatContext();
            var messageToAdd = new Message();
            if (MessageTextInput.Text == string.Empty)
            {
                return;
            }

            messageToAdd.MessageText = this.MessageTextInput.Text;
            messageToAdd.Date = DateTime.Now;
            context.Messages.Add(messageToAdd);
            context.SaveChanges();

            var messages = context.Messages.OrderByDescending(c => c.Date).Take(100).ToList();
            this.MessagesGrid.DataSource = messages;
            this.MessagesGrid.DataBind();
        }

        protected void TimerTimeRefresh_Tick(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(3000);
            var context = new ChatContext();
            var messages = context.Messages.OrderByDescending(c => c.Date).Take(100).ToList();
            this.MessagesGrid.DataSource = messages;
            this.MessagesGrid.DataBind();
        }
    }
}