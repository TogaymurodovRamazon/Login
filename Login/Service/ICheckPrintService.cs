using Login.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Service
{
    public interface ICheckPrintService
    {
        public Task CreateCheckPrint(CheckPrintingDTO checkPrintingDTO);
        public Task UpdateCheckPrint(long Id , CheckPrintingDTO checkPrintingDTO);
        public Task DeleteCheckPrint(long Id);
        public Task<List<CheckPrintingDTO>> GetAllCheckPrint();
        public Task<CheckPrintingDTO> GetAllCheckPrintById(long Id);
    }
}
