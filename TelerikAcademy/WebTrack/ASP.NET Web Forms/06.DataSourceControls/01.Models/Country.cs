using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Models
{
    public class Country
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Language { get; set; }

        public long Population { get; set; }

        public int? ContinentId { get; set; }

        [ForeignKey("ContinentId")]
        public virtual Continent Continent { get; set; }

        public virtual ICollection<Town> Towns { get; set; }

        public byte[] Flag { get; set; }

        public Country()
        {
            this.Towns = new HashSet<Town>();
        }
    }
}
