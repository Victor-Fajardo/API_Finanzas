﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Finanzas.Domain.Models
{
    public class PaymentLetter
    {
        public int PaymentLetterId { get; set; }
        public int RUC { get; set; }
        public string Currency { get; set; }
        public float Amount { get; set; }
        public DateTime EmisisonDate { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
