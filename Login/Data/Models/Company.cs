using Login.Data.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Data.Models
{
    public class Company : BaseEntity
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}
