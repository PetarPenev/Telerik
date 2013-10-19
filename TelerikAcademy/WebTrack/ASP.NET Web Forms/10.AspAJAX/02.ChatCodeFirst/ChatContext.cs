using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.ChatCodeFirst
{
    public class ChatContext : DbContext
    {
        public ChatContext()
            : base("SimpleChatDb")
        {
        }

        public DbSet<Message> Messages { get; set; }
    }

    public class Message
    {
        public int Id { get; set; }

        public string MessageText { get; set; }

        public DateTime Date { get; set; }
    }
}
