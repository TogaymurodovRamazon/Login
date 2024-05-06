using Login.Common.DTO;
using Login.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.IRepository
{
    public interface IProductRepository
    {
        public Task<List<Product>> GetAllProducts();
        public Task<Product> GetById(int id);
        public Task<Product> CreateProduct(Product product);
        public Task<Product> UpdateProduct(Product product);
        public Task DeleteProduct(int id);
        public Task<List<ProductForSearchDTO>> GetProductByName(string name);
        public Task<List<Product>> GetProductsByIds(List<long> Ids);
    }
}
