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
    public class CheckPrintService : ICheckPrintService
    {
        private readonly ICheckPrintRepository _checkPrintRepository;
        public CheckPrintService(ICheckPrintRepository checkPrintRepository)
        {
            _checkPrintRepository = checkPrintRepository;
        }

        public async Task CreateCheckPrint(CheckPrintingDTO checkPrintingDTO)
        {
            if (checkPrintingDTO == null)
                throw new ArgumentNullException("CheckPrint model is null!");

            CheckPrintingData checkPrintingData = new CheckPrintingData()
            {
                Header = checkPrintingDTO.Header,
                Footer = checkPrintingDTO.Footer,
                Tara=checkPrintingDTO.Tara,
                Printer=checkPrintingDTO.Printer,
                TIN=checkPrintingDTO.TIN
            };
            await _checkPrintRepository.CreateCheckPrinting(checkPrintingData);
        }

        public async Task DeleteCheckPrint(long Id)
        {
            var delecheck = await _checkPrintRepository.GetCheckPrintingById(Id);
            if (delecheck == null)
                throw new Exception("CheckPrintData not found!");
            await _checkPrintRepository.DeleteCheckPrinting(delecheck);
        }

        public async Task<List<CheckPrintingDTO>> GetAllCheckPrint()
        {
            var check = await _checkPrintRepository.GetAllCheckPrintings();
            if (check.Any())
            {
                var allcheck = check.Select(a => new CheckPrintingDTO()
                {
                    Header = a.Header,
                    Footer = a.Footer,
                    Tara=a.Tara,
                    Printer=a.Printer,
                    TIN=a.TIN
                }).ToList();
                return allcheck;
            }
            return new List<CheckPrintingDTO>();
        }

        public async Task<CheckPrintingDTO> GetAllCheckPrintById(long Id)
        {
            var checkdata = await _checkPrintRepository.GetCheckPrintingById(Id);
            if (checkdata == null)
                throw new Exception("CheckPrint not found!");
            else
            {
                var checkprint = new CheckPrintingDTO()
                {
                    Header= checkdata.Header,
                    Footer= checkdata.Footer,
                    Tara= checkdata.Tara,
                    Printer= checkdata.Printer,
                    TIN= checkdata.TIN
                };
                return checkprint;
            }
            
        }

        public async Task UpdateCheckPrint(long Id, CheckPrintingDTO checkPrintingDTO)
        {
            var allcheck = await _checkPrintRepository.GetCheckPrintingById(Id);
            if (allcheck == null)
                throw new Exception("CheckPrintData not found!");
            allcheck.Header = checkPrintingDTO.Header;
            allcheck.Footer = checkPrintingDTO.Footer;
            allcheck.Printer = checkPrintingDTO.Printer;
            allcheck.Tara = checkPrintingDTO.Tara;
            allcheck.TIN = checkPrintingDTO.TIN;

            await _checkPrintRepository.UpdateCheckPrinting(allcheck);
        }
    }
}
