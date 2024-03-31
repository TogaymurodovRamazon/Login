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

        public long? DiscountId { get; set; }
        public virtual Discount Discount { get; set; }

        // public string MxikCode { get; set; }
        //public int GroupId { get; set; }
        //public int MeasuredId { get; set; }
        public string Barcode { get; set; }
        // public string VendorCode { get; set; }
        //public string Tin { get; set; }
        //public int TaxType { get; set; }
        public int AmountInPackage { get; set; }
        //public bool Marker { get; set; }
        public int CompanyId { get; set; }
        //public string Sku { get; set; }
        public int Amount { get; set; }
        public int ActualPrice { get; set; }
        public int Price { get; set; }
        public int PriceOfPiece { get; set; }
        public bool Selected { get; set; }

    }
}
