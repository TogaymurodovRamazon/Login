using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Common.DTO
{
    public class CategoryDTO : BaseDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public long? ParentId { get; set; }
        public string? ParentName { get; set; }
        public List<ProductForSelect>? Products { get; set; }
    }
}
