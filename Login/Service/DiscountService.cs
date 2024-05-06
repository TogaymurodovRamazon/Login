﻿using Login.Common.DTO;
using Login.Data.Models;
using Login.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Service
{
     public class DiscountService : IDiscountService
    {
        private readonly IDiscountRepository _discountRepository;
        private readonly IProductRepository _productRepository;
        public DiscountService(IDiscountRepository discountRepository, IProductRepository productRepository)
        {
            _discountRepository = discountRepository;
            _productRepository = productRepository;
        }

        public async Task<DiscountDTO> CreateDiscount(DiscountDTO discountDTO)
        {
            if(discountDTO != null)
            {
                var product = await _productRepository.GetProductsByIds(discountDTO.ProductsDTO.Select(s => s.Id).ToList());

                Discount newdiscount = new Discount()
                {
                    Title = discountDTO.Title,
                    Description = discountDTO.Description,
                    Amount = discountDTO.Amount,
                    AmountType = discountDTO.AmountType,
                    DiscountStatus = discountDTO.DiscountStatus,
                    StarDate = discountDTO.StarDate,
                    EndDate = discountDTO.EndDate,
                    Products = product
                };
                await _discountRepository.CreateDiscount(newdiscount);
                return discountDTO;
           
            }
            return discountDTO;
        }
        
       

        public async Task DeleteDiscount(long Id)
        {
            var discount = await _discountRepository.GetDiscountById(Id);
            if (discount == null)
                throw new Exception("Discount not found!");
            await _discountRepository.DeleteDiscount(discount);
        }

        public async Task<DiscountDTO> GetAllById(long Id)
        {
            var dis = await _discountRepository.GetDiscountById(Id);
            if (dis == null) 
                throw new Exception("Discount not found!");
            else
            {
                var discount = new DiscountDTO()
                {
                    Id = dis.Id,
                    Title = dis.Title,
                    Description = dis.Description,
                    Amount = dis.Amount,
                    AmountType= dis.AmountType,
                    StarDate = dis.StarDate,
                    EndDate = dis.EndDate,
                    DiscountStatus = dis.DiscountStatus,

                };
                return discount;
            }
        }

        public async Task<List<DiscountDTO>> GetAllDiscount()
        {
            var dis = await _discountRepository.GetAllDiscount();
            if (dis.Any())
            {
                var allDis = dis.Select(a => new DiscountDTO()
                {
                    Id = a.Id,
                    Title = a.Title,
                    Description = a.Description,
                    Amount = a.Amount,
                    AmountType= a.AmountType,
                    StarDate = a.StarDate,
                    EndDate = a.EndDate,
                    DiscountStatus = a.DiscountStatus,
                }).ToList();
            }
            else
            {
                return new List<DiscountDTO>();
            }
        }

        public async Task<DiscountDTO> UpdateDiscount(long Id, DiscountDTO discountDTO)
        {
            if (Id > 0)
            {
               var discount=await _discountRepository.GetDiscountById(Id);
                if (discount != null)
                {
                    var discounts = await _productRepository.GetProductsByIds(discountDTO.ProductsDTO.Select(a => a.Id).ToList());
                    discount.Title = discountDTO.Title;
                    discount.Description = discountDTO.Description;
                    discount.Amount = discountDTO.Amount;
                    discount.AmountType = discountDTO.AmountType;
                    discount.DiscountStatus = discountDTO.DiscountStatus;

                    discount.StarDate = discountDTO.StarDate;
                    discount.EndDate = discountDTO.EndDate;

                    discount.Products = new List<Product>();
                    discount.Products = discounts;


                    await _discountRepository.UpdateDiscount(discount);
                    return discountDTO;
                }
                else
                {
                    throw new Exception("Discount not found!");
                }
            }
            return discountDTO;
        }
    }
}
