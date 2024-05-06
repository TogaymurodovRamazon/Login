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
     public class DiscountRepository : IDiscountRepository
    {
        private readonly AppDBContext _dbContext;
        public DiscountRepository(AppDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        public async Task<Discount> CreateDiscount(Discount discount)
        {
            if (discount == null)
                throw new ArgumentNullException("Discount model mustn't be null");
            else
            {
                var hascopy = await _dbContext.Discounts.AnyAsync(a => !a.IsDeleted || a.Title == discount.Title);
                if (hascopy)
                    throw new Exception("Discount alredy exits!");
                else
                {
                    await _dbContext.Discounts.AddAsync(discount);
                    await _dbContext.SaveChangesAsync();
                }
            }
                return discount;
        }

        public async Task DeleteDiscount(Discount discount)
        {
           discount.IsDeleted = true;
            _dbContext.Discounts.Update(discount);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Discount>> GetAllDiscount()
        {
            return await _dbContext.Discounts.Where(a => !a.IsDeleted).ToListAsync();
        }

        public async Task<Discount> GetDiscountById(long Id)
        {
            if (Id < 0)
                throw new Exception("Id is low from 0!");
            return await _dbContext.Discounts.FirstOrDefaultAsync(a=>!a.IsDeleted && a.Id == Id);
        }

        public async Task<Discount> UpdateDiscount(Discount discount)
        {
             _dbContext.Discounts.Update(discount);
            await _dbContext.SaveChangesAsync();
            return discount;
        }
    }
}
