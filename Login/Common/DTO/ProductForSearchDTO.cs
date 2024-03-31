using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Common.DTO
{
    public class ProductForSearchDTO : BaseDTO
    {
        public string Name {  get; set; }
        public string Barcode { get; set; }
    }
}
