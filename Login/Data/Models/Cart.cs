using Login.Data.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Data.Models
{
    public class Cart :BaseEntity
    {
        public decimal ActualPrice { get; set; }
        public decimal SalePrice { get; set; }
        public decimal Count { get; set; }
        public decimal TotalSum { get; set; }

        public long? DiscountId { get; set; }
        public virtual Discount? Discount { get; set; }

        public long? ProductId { get; set; }
        public virtual Product? Product { get; set; }

        public long? ShopId { get; set; }
        public virtual Shop? Shop { get; set; }
    }
}
