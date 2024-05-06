using Login.Common.DTO;
using Login.Data.Models;
using Login.IRepository;
using Login.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Service
{
     public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IProductRepository _productRepository;
        public CompanyService(ICompanyRepository companyRepository, IProductRepository productRepository)
        {
            _companyRepository = companyRepository;
            _productRepository = productRepository;

        }

        public async Task<CompanyDTO> CreateCompany(CompanyDTO companyDTO)
        {
            if (companyDTO != null)
            {
                var prod = await _productRepository.GetProductsByIds(companyDTO.Products.Select(a => a.Id).ToList());
                Company company = new Company()
                {
                    Name = companyDTO.Name,
                    PhoneNumber = companyDTO.PhoneNumber,
                    Products = prod
                };
                await _companyRepository.CreateCompany(company);
                return companyDTO;
            }
            return companyDTO;
        }

        public async Task DeleteCompany(long Id)
        { 
            if(Id > 0)
            {
                var comp = await _companyRepository.GetCompanyById(Id);
                if (comp == null)
                    throw new Exception("Company not found!");
                await _companyRepository.DeleteCompany(comp);
            }
            else
            {
                throw new Exception("Id is low from 0! ");
            }

        }

        public async Task<List<CompanyDTO>> GetAllCompanyes()
        {
            var comp = await _companyRepository.GetAllCompanyes();
            if (comp.Any())
            {
                return comp.Select(z => new CompanyDTO()
                {
                    Id = z.Id,
                    Name = z.Name,
                    PhoneNumber = z.PhoneNumber,
                    Productnames=string.Join(", ", z.Products.Select(a=>a.Name))
                    
                }).ToList();
            }
            return new List<CompanyDTO>();
        }

        public async Task<CompanyDTO> GetCompanyById(long Id)
        {
            if (Id > 0)
            {
                var company = await _companyRepository.GetCompanyById(Id);
                if (company != null)
                {
                    return new CompanyDTO()
                    {
                        Id = company.Id,
                        Name = company.Name,
                        PhoneNumber = company.PhoneNumber,
                        Products = company.Products.Select(a => new ProductForSelect()
                        {
                            Id = a.Id,
                            Name = a.Name,
                            Select = a.Selected,
                        }).ToList()

                    };

                }
                else
                {
                    throw new Exception("Company not found!");
                }
            }
            return null;
      
        }

        public async Task<CompanyDTO> UpdateCompany(long Id, CompanyDTO companyDTO)
        {
            if (Id > 0)
            {
                var comp = await _companyRepository.GetCompanyById(Id);
                if(comp!= null)
                {
                    var companys = await _productRepository.GetProductsByIds(companyDTO.Products.Select(a => a.Id).ToList());

                    comp.Name = companyDTO.Name;
                    comp.PhoneNumber = companyDTO.PhoneNumber;
                    comp.Products = companys;

                    await _companyRepository.UpdateCompany(comp);
                    return companyDTO;
                }
                else
                {
                    throw new Exception("Company not found!");
                }
            }
            return companyDTO;
        }

    }
}
