using System;
using System.Collections.Generic;
using System.Text;

namespace BO.Models
{
    public class MyPayment
    {
        public string OrderNo { get; set; }
        public string OrderDate { get; set; }
        public string item { get; set; }
        public string TransectionAmount { get; set; }
        public string BalanceAmount { get; set; }
        public string PaymentMode { get; set; }
        public string PaymentStatus { get; set; }
    }
}
