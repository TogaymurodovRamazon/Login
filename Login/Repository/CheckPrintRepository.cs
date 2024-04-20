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
    public class CheckPrintRepository : ICheckPrintRepository
    {
        private readonly AppDBContext _appDBContext;
        public CheckPrintRepository(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext; 
        }

        public async Task<CheckPrintingData> CreateCheckPrinting(CheckPrintingData checkPrintingData)
        {
            
            await _appDBContext.CheckPrintingDatas.AddAsync(checkPrintingData);
            await _appDBContext.SaveChangesAsync();
            return checkPrintingData;

        }

        public async Task DeleteCheckPrinting(CheckPrintingData checkPrintingData)
        {
            checkPrintingData.IsDeleted = true;
            _appDBContext.CheckPrintingDatas.Update(checkPrintingData);
            await _appDBContext.SaveChangesAsync();
        }

        public async Task<List<CheckPrintingData>> GetAllCheckPrintings()
        {
            return await _appDBContext.CheckPrintingDatas.Where(a => !a.IsDeleted).ToListAsync();
        }

        public async Task<CheckPrintingData> GetCheckPrintingById(long id)
        {
            if (id < 0)
                throw new Exception("Id is low from 0 !");
            var res= await _appDBContext.CheckPrintingDatas.FirstOrDefaultAsync(a => !a.IsDeleted && a.Id == id);
            return res;
        }

        public async Task<CheckPrintingData> UpdateCheckPrinting(CheckPrintingData checkPrintingData)
        {
            _appDBContext.CheckPrintingDatas.Update(checkPrintingData);
            await _appDBContext.SaveChangesAsync();
            return checkPrintingData;
        }
    }
}
