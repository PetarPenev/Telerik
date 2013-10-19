using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.ToDoModels
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<ToDo> ToDos { get; set; }

        public Category()
        {
            this.ToDos = new HashSet<ToDo>();
        }
    }
}
