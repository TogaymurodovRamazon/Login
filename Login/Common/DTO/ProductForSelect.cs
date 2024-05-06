using Login.Data.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Common.DTO
{
      public class ProductForSelect : BaseEntity
    {
        public bool Select { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
    }
}
