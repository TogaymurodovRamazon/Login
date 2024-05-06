using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Common.DTO
{
    public class CompanyDTO : BaseDTO
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public List<ProductForSelect> Products { get; set; }
        public string Productnames { get; set; }
    }
}
