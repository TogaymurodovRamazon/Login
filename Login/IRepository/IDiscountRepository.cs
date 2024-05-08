using Login.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.IRepository
{
     public interface IDiscountRepository
    {
        public Task<List<Discount>> GetAllDiscount();
        public Task<Discount> CreateDiscount(Discount discount);
        public Task<Discount> UpdateDiscount(Discount discount);
        public Task DeleteDiscount(long id);
        public Task<Discount> GetDiscountById(long Id);
    }
}
