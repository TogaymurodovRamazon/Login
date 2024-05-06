using Login.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Service
{
     public interface IDiscountService
    {
        public Task<DiscountDTO>  CreateDiscount(DiscountDTO discountDTO);
        public Task<DiscountDTO> UpdateDiscount(long Id, DiscountDTO discountDTO);
        public Task DeleteDiscount(long Id);
        public Task<DiscountDTO> GetAllById(long Id);
        public Task<List<DiscountDTO>> GetAllDiscount();
    }
}
