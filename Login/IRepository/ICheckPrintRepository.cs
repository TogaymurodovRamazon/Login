using Login.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.IRepository
{
    public interface ICheckPrintRepository
    {
        Task<List<CheckPrintingData>> GetAllCheckPrintings();
        Task<CheckPrintingData> CreateCheckPrinting(CheckPrintingData checkPrintingData);
        Task<CheckPrintingData> UpdateCheckPrinting(CheckPrintingData checkPrintingData);
        Task DeleteCheckPrinting(CheckPrintingData checkPrintingData);
        Task<CheckPrintingData> GetCheckPrintingById(long id);
    }
}
