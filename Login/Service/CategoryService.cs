using Login.Common.DTO;
using Login.Data.Models;
using Login.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;
        public CategoryService(ICategoryRepository categoryRepository,IProductRepository productRepository)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository; 
        }

        public async Task<CategoryDTO> CreateProductCategory(CategoryDTO categoryDTO)
        {
            var product = new List<Product>();
            if(categoryDTO.Products.Any())
                product = await _productRepository.GetProductsByIds(categoryDTO.Products.Select(s=>s.Id).ToList());
            var newCategory = new ProductCategory()
            {
                Name = categoryDTO.Title,
                Description = categoryDTO.Description,
                ParentCategoryId = categoryDTO.ParentId,
                Products = product,
            };
            await _categoryRepository.CreateProductCategory(newCategory);
            return categoryDTO;
        }

        public async Task DeleteProductCategory(long Id)
        {
            await _categoryRepository.DeleteProductCategory(Id);
        }

        public async Task<List<CategoryDTO>> GetAllProductCategorys()
         {
            var category = await _categoryRepository.GetAllProductCategorys();
            if (category.Any())
            {
                return category.Select(c=> new CategoryDTO()
                {
                    Id = c.Id,
                    Description = c.Description,
                    Title = c.Name,
                    ParentName = c?.ParentCategory?.Name?? string.Empty,
                    Products = c.Products.Select(a=> new ProductForSelect()
                    {
                        Id=a.Id,
                        Name=a.Name,
                        Amount=a.Amount,
                        Select=true

                    }).ToList(),
                    
                }).ToList();
                
            }
            return new List<CategoryDTO>();
        }

        public async Task<CategoryDTO> GetById(long Id)
        {
            var category = await _categoryRepository.GetAllById(Id);
            if (category != null)
            {
                return new CategoryDTO()
                {
                    Id = category.Id,
                    Description = category.Description,
                    Title = category.Name,
                    ParentName = category?.ParentCategory.Name ?? string.Empty,
                    Products = category.Products.Select(d => new ProductForSelect()
                    {
                        Id = d.Id,
                        Name = d.Name,
                        Amount = d.Amount,
                        Select = true

                    }).ToList()
                };
            }
            else
                throw new Exception("Category not found!");
        }

        public async Task<List<SelectDTO>> GetCategoriesForSelect()
        {
            return await _categoryRepository.GetCategoriesForSelect();
        }

        public async Task<CategoryDTO> UpdateProductCategory(long Id, CategoryDTO categoryDTO)
        {
            var category= await _productRepository.GetProductsByIds(categoryDTO.Products.Select(d=>d.Id).ToList());
            var oldcate = await _categoryRepository.GetAllById(Id);

            oldcate.Name = categoryDTO.Title;
            oldcate.Description = categoryDTO.Description;
            oldcate.ParentCategoryId = categoryDTO.ParentId;
            oldcate.Products = category;

            await _categoryRepository.CreateProductCategory(oldcate);
            return categoryDTO;
        }
    }
}
