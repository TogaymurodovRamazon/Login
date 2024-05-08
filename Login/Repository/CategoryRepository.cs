using Login.Common.DTO;
using Login.Data;
using Login.Data.Models;
using Login.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDBContext _dbContext;
        public CategoryRepository(AppDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        public async Task<ProductCategory> CreateProductCategory(ProductCategory category)
        {
           await _dbContext.ProductCategories.AddAsync(category);
            await _dbContext.SaveChangesAsync();
            return category;
        }

        public async Task DeleteProductCategory(long Id)
        {
            var category = await _dbContext.ProductCategories.Where(a => a.Id == Id).FirstOrDefaultAsync();
            if (category == null)
                throw new Exception("Product category not found!");
            _dbContext.ProductCategories.Remove(category);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<ProductCategory> GetAllById(long Id)
        {
            var res= await _dbContext.ProductCategories.Where(a => a.Id == Id).FirstOrDefaultAsync();
            return res;
        }

        public async Task<List<ProductCategory>> GetAllProductCategorys()
        {
           return await _dbContext.ProductCategories.Where(a=> ! a.IsDeleted).Include(a=>a.Products).
                Include(a=>a.ParentCategory).ToListAsync();
        }

        public async Task<List<SelectDTO>> GetCategoriesForSelect(long? parentId)
        {
            var category = await _dbContext.ProductCategories.Where(a=>parentId != null? (parentId==0 ? a.ParentCategoryId==0 : 
            a.ParentCategoryId==parentId) : true).Select(a=> new SelectDTO()
            {
                Id = a.Id,
                Name = a.Name,
            }).AsSplitQuery().ToListAsync();
            return category;
        }

        public async Task<bool> HasChildCategory(long categoryId)
        {
            var category = await _dbContext.ProductCategories.Include(s => s.ChildCategories).FirstOrDefaultAsync(s => s.Id == categoryId);
            if (category is not null)
            {
                if (category.ChildCategories != null && category.ChildCategories.Any())
                    return true;
                else
                    return false;
            }
            else
            {
                throw new Exception("Category not found!");
            }


        }

        public async Task<ProductCategory> UpdateProductCategory(ProductCategory category)
        {
            _dbContext.ProductCategories.Update(category);
            await _dbContext.SaveChangesAsync();
            return category;
        }
    }
}
