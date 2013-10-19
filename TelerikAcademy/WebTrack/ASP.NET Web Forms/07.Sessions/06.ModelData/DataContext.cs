using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.ModelData
{
    public class DataContext :DbContext
    {
        public DataContext()
            : base("VisitorDb")
        {
        }

        public DbSet<VisitorData> Data { get; set; }
    }
}
