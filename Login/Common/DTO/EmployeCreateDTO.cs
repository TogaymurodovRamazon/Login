using Login.Data.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Common.DTO
{
    public class EmployeCreateDTO : BaseDTO
    {
        public string UserName { get; set; }
        public string PIN { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string PhoneNumber { get; set; }
        public string Addres { get; set; }
        public string JobTitle { get; set; }
        public long EnrollNumber { get; set; }
        public DateTime BornDate { get; set; }
        public DateTime HireDate { get; set; }
        public EmployePole EmployeRole { get; set; }


    }
}
