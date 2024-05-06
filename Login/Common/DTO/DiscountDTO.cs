using Login.Data.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Common.DTO
{
     public class DiscountDTO :BaseDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }           
        public DiscountType AmountType { get; set; }
        public DiscountStatus DiscountStatus { get; set; }
        public DateTime StarDate { get; set; }
        public DateTime EndDate { get; set; }

        public List<ProductForSelect> ProductsDTO { get; set; }
        public string ProductName { get; set; }

    }
}
