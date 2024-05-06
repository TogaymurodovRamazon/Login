using Login.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Service
{
     public interface ICompanyService
    {
        public Task<CompanyDTO> CreateCompany(CompanyDTO companyDTO);
        public Task<CompanyDTO> UpdateCompany(long Id, CompanyDTO companyDTO);
        public Task DeleteCompany(long Id);
        public Task<List<CompanyDTO>> GetAllCompanyes();
        public Task<CompanyDTO> GetCompanyById(long Id);
    }
}
