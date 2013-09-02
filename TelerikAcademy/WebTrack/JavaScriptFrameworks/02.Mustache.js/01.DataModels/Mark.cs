using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.DataModels
{
    public class Mark
    {
        public int Id { get; set; }

        public string Subject { get; set; }

        public int Score { get; set; }

        public virtual Student Student { get; set; }
    }
}
