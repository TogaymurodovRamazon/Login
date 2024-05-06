using Login.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.IRepository
{
     public interface ICompanyRepository
    {
        Task<List<Company>> GetAllCompanyes();
        Task<Company> CreateCompany(Company company);
        Task<Company> UpdateCompany(Company company);
        Task DeleteCompany(Company company);
        Task<Company> GetCompanyById(long Id);
    }
}
