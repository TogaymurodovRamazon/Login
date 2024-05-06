using Login.Data.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Data.Models
{
    public class Product :BaseEntity
    {
        public string Name { get; set; }
        public string Barcode { get; set; }
        public decimal AmountInPackage { get; set; }
        
        public decimal Amount { get; set; }
        public decimal ActualPrice { get; set; }
        public decimal Price { get; set; }
        public decimal PriceOfPiece { get; set; }
        public bool Selected { get; set; }

        public long? CompanyId { get; set; }
        public virtual Company? Company { get; set; }

        public long? DiscountId { get; set; }
        public virtual Discount? Discount { get; set; }

        public long? CategoryId { get; set; }
        public virtual ProductCategory? Category { get; set; }

        // public string MxikCode { get; set; }
        //public int GroupId { get; set; }
        //public int MeasuredId { get; set; }
        // public string VendorCode { get; set; }
        //public string Tin { get; set; }
        //public int TaxType { get; set; }
        //public bool Marker { get; set; }
        //public string Sku { get; set; }
    }
}
