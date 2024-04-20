using Login.Data.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Data.Models
{
    public class Shop : BaseEntity
    {
        public decimal TotalSum { get; set; }
        public long ClientId { get; set; }
        public Client Client { get; set; }
        public virtual List<Cart> Carts { get; set; }
    }
}
