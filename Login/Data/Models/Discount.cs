﻿using Login.Data.Base;
using Login.Data.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Data.Models
{
    public class Discount : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }           // 0.6 %,         1 + 1,     har biri uchun 10 000
        public DiscountType AmountType { get; set; }  // Percent,       Count,     Amount

        public virtual List<Product> Products { get; set; }

        public DiscountStatus DiscountStatus { get; set; }

        public DateTime StarDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
