using Login.Common.DTO;
using Login.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
           this._productRepository = productRepository;
        }
        public Task<ProductDTO> CreateProduct(ProductDTO product)
        {
            throw new NotImplementedException();
        }

        public Task DeleteProduct(long id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductDTO>> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public Task<ProductDTO> GetProductById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductForSearchDTO>> GetProductForSearche(string searche)
        {
            throw new NotImplementedException();
        }

        public Task<ProductDTO> UpdateProduct(long id, ProductDTO product)
        {
            throw new NotImplementedException();
        }
    }
}
