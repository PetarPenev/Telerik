using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Model.Classes
{
    public class CardAccount
    {
        public int Id { get; set; }

        [StringLength(10)]
        public string CardNumber { get; set; }

        [StringLength(4)]
        public string CardPin { get; set; }

        public decimal CardCash { get; set; }
    }
}
