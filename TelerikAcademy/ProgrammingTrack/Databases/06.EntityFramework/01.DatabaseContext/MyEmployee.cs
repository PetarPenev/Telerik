using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;

namespace _01.DatabaseContext
{
    partial class Employee
    {
        public virtual EntitySet<Territory> TerritoriesEntitySet
        {
            get
            {
                EntitySet<Territory> set = new EntitySet<Territory>();
                foreach (var ter in this.Territories)
                {
                    set.Add(ter);
                }

                return set;
            }
        }

    }
}