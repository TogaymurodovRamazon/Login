using Login.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Service
{
    public interface ICategoryService
    {
        public Task<List<SelectDTO>> GetCategoriesForSelect();
        public Task<List<CategoryDTO>> GetAllProductCategorys();
        public Task<CategoryDTO> GetById(long Id);
        public Task<CategoryDTO> CreateProductCategory(CategoryDTO categoryDTO);
        public Task<CategoryDTO> UpdateProductCategory(long Id, CategoryDTO categoryDTO);
        public Task DeleteProductCategory(long Id);
    }
}
