using Login.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Service
{
    public interface IProductService
    {
        public Task<List<ProductDTO>> GetAllProducts();
        public Task<List<ProductForSearchDTO>> GetProductForSearche(string searche);
        public Task<ProductDTO> CreateProduct(ProductDTO product);
        public Task<ProductDTO> UpdateProduct(long id, ProductDTO product);
        public Task DeleteProduct(long id);
        public Task<ProductDTO> GetProductById(long id);
    }
}
