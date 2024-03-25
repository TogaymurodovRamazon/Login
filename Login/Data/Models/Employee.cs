using Login.Data.Base;
using Login.Data.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Data.Models
{
    public class Employee :BaseEntity
    {
        public string Title { get; set; }
        public long EnrollNumber { get; set; }
        public DateTime HireDate { get; set; }
        public EmployePole EmployeRole { get; set; }

        public long UserId { get; set; }
        public virtual User User { get; set; }
    }
}
