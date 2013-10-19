using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatSystemWeb.Models
{
    public class Message
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public string Author { get; set; }

        public virtual ApplicationUser Creator { get; set; }
    }
}