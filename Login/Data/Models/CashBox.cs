﻿using Login.Data.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Data.Models
{
     public class CashBox :BaseEntity
    {
        public string Title { get; set; }
        public string IPAddress { get; set; }
    }
}
