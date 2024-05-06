using Login.Common.DTO;
using Login.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.IRepository
{
    public interface ICategoryRepository
    {
        public Task<List<SelectDTO>> GetCategoriesForSelect();
        public Task<List<ProductCategory>> GetAllProductCategorys();
        public Task<ProductCategory> GetAllById(long Id);
        public Task<ProductCategory> CreateProductCategory(ProductCategory category);
        public Task<ProductCategory> UpdateProductCategory(ProductCategory category);
        public Task DeleteProductCategory(long Id);
    }
}
