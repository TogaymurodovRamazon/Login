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
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
           this._productRepository = productRepository;
        }

        public async Task<ProductDTO> CreateProduct(ProductDTO product)
        {
            var newProduct = new Product()
            {
                Name=product.Name,
                Barcode=product.Barcode,
                AmountInPackage=product.AmountInPackage,
                Amount=product.Amount,
                ActualPrice=product.ActualPrice,
                Price=product.Price,
                PriceOfPiece=product.PriceOfPiece,
                Selected=product.Selected 
            };
            await _productRepository.CreateProduct(newProduct);
            return product;
        }

        public async Task DeleteProduct(long id)
        {
            if (id > 0)
               await _productRepository.DeleteProduct((int) id);
            
        }

        public async Task<List<ProductDTO>> GetAllProducts()
        {
            var products = await _productRepository.GetAllProducts();
            if(products != null && products.Any())
            {
                return products.Select(a=>new ProductDTO()
                {
                    Id=a.Id,
                    Name=a.Name,
                    Barcode=a.Barcode,
                    AmountInPackage=a.AmountInPackage,
                    Amount=a.Amount,
                    ActualPrice=a.ActualPrice,
                    Price=a.Price,
                    PriceOfPiece=a.PriceOfPiece,
                    Selected=a.Selected
                }).ToList();     
            }
            return new List<ProductDTO>();
        }

        public async Task<List<ProductForSelect>> GetAllProductsForDiscount()
        {
            var products = await _productRepository.GetAllProducts();
            if(products != null && products.Any())
            {
                return products.Select(a => new ProductForSelect()
                {
                    Id = a.Id,
                    Name=a.Name,
                    Amount = a.Amount,
                }).ToList();
            }
            return new List<ProductForSelect>();
        }

        public async Task<ProductDTO> GetProductById(long id)
        {
            var res = await _productRepository.GetById((int)id);
            if(res != null)
            {
                return new ProductDTO()
                {
                    Id = res.Id,
                    Name = res.Name,
                    Barcode = res.Barcode,
                    AmountInPackage=res.AmountInPackage,
                    Amount=res.Amount,
                    ActualPrice=res.ActualPrice,
                    PriceOfPiece=res.PriceOfPiece,
                    Selected=res.Selected,
                    Price = res.Price
                };
            }
            else
            {
                throw new Exception("Product not found!");
            }
        }

        public async Task<List<ProductForSearchDTO>> GetProductForSearche(string searche)
        {
            return await _productRepository.GetProductByName(searche);
        }

        public async Task<List<ProductForSelect>> GetProductsByIdsForDiscount(List<long> productIds)
        {
            var prod = await _productRepository.GetProductsByIds(productIds);
            if(prod != null && prod.Any())
            {
                return prod.Select(x => new ProductForSelect()
                {
                    Id=x.Id,
                    Name=x.Name,
                    Amount = x.Amount,
                    Select=true
                }).ToList();
            }
            return new List<ProductForSelect>();
        }

        public async Task<ProductDTO> UpdateProduct(long id, ProductDTO product)
        {
            var all = await _productRepository.GetById((int)id);
            if (all != null)
            {
                all.Name = product.Name;
                all.Barcode = product.Barcode;
                all.ActualPrice = product.ActualPrice;
                all.PriceOfPiece= product.PriceOfPiece;
                all.Selected= product.Selected;
                all.Price = product.Price;
                all.Amount = product.Amount;
                all.ActualPrice = product.ActualPrice;

                await _productRepository.UpdateProduct(all);
                return product;
            }
            else
            {
                throw new Exception("Product not found!");
            }
        }
    }
}
