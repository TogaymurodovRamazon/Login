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
    public class ProductRepository : IProductRepository
    {
        private readonly AppDBContext _dBContext;
        public ProductRepository(AppDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task<Product> CreateProduct(Product product)
        {
            if (product == null)
                throw new ArgumentNullException("Product model mustn't be null");
            else
            {
                var hasCopy = await _dBContext.Products.AnyAsync(a => a.Name == product.Name || a.Barcode==product.Barcode);
                if (hasCopy)
                    throw new Exception("Product alredy exist!");
                else
                {
                    await _dBContext.Products.AddAsync(product);
                    await _dBContext.SaveChangesAsync();
                }
            }
            return product;
        }

        public async Task DeleteProduct(int id)
        {
            var product = await _dBContext.Products.FirstOrDefaultAsync(a=>a.IsDeleted && a.Id == id);
            if (product == null)
                throw new Exception("Product not fount!");
            else
            {
                product.IsDeleted= true;
                //_dBContext.Products.Remove(product);
                _dBContext.Products.Update(product);
                await _dBContext.SaveChangesAsync();
            }
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _dBContext.Products.Where(a => !a.IsDeleted).ToListAsync();
        }

        public async Task<Product> GetById(int id)
        {
           return await _dBContext.Products.FirstOrDefaultAsync(a=>!a.IsDeleted && a.Id == id);
           
        }

        public async Task<List<ProductForSearchDTO>> GetProductByName(string name)
        {
            var product = _dBContext.Products.Where(a => a.Name.ToLower().Contains(name.ToLower()) || a.Barcode == name)
                .Select(a => new ProductForSearchDTO()
                {
                    Id = a.Id,
                    Name = a.Name,
                    Barcode = a.Barcode,

                }).AsSplitQuery();
           return await product.Take(10).ToListAsync();
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            _dBContext.Products.Update(product);
            await _dBContext.SaveChangesAsync();
            return product;
        }
    }
}
