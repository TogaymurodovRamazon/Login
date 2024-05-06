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
     public class CompanyRepository : ICompanyRepository
    {
        private readonly AppDBContext _appDBContext;
        public CompanyRepository(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        public async Task<Company> CreateCompany(Company company)
        {
            if (company == null)
                throw new ArgumentNullException("Company model mustn't be null");
            else
            {
                var hasCopy = await _appDBContext.Companies.AnyAsync(a => !a.IsDeleted || a.Name == company.Name);
                if (hasCopy)
                    throw new Exception("Company already exist!");
                else
                {
                    await _appDBContext.Companies.AddAsync(company);
                    await _appDBContext.SaveChangesAsync();
                }
               
            }
            return company;
        }

        public async Task DeleteCompany(Company company)
        {
            company.IsDeleted = true;
            _appDBContext.Companies.Update(company);
            await _appDBContext.SaveChangesAsync();
        }

        public async Task<List<Company>> GetAllCompanyes()
        {
            return await _appDBContext.Companies.Where(a => !a.IsDeleted).ToListAsync();
        }

        public async Task<Company> GetCompanyById(long Id)
        {
            if (Id < 0) 
                throw new Exception("Id is low from 0!");
            return await _appDBContext.Companies.FirstOrDefaultAsync(a => !a.IsDeleted && a.Id == Id);
            
        }

        public async Task<Company> UpdateCompany(Company company)
        {
            _appDBContext.Companies.Update(company);
            await _appDBContext.SaveChangesAsync();
            return company;
        }
    }
}
