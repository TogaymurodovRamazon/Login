using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Common.DTO
{
    public class ProductDTO : BaseDTO
    {
        public string Name { get; set; }
        public long DiscountId { get; set; }
        public string Barcode { get; set; }
        public decimal AmountInPackage { get; set; }
        public decimal Amount { get; set; }
        public decimal ActualPrice { get; set; }
        public decimal Price { get; set; }
        public decimal PriceOfPiece { get; set; }
        public bool Selected { get; set; }
    }
}
