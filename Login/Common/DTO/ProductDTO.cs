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
        public int AmountInPackage { get; set; }
        public int Amount { get; set; }
        public int ActualPrice { get; set; }
        public int Price { get; set; }
        public int PriceOfPiece { get; set; }
        public bool Selected { get; set; }
    }
}
