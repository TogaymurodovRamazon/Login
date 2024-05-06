using Login.Data.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Data.Models
{
    public class ProductCategory :BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual List<Product> Products { get; set; }
        public long? ParentCategoryId { get; set; }
        public ProductCategory? ParentCategory { get; set; }
        public virtual List<ProductCategory>? ChildCategories {  get; set; }
    }
}
