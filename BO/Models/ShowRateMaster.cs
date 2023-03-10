using System;
using System.Collections.Generic;
using System.Text;

namespace BO.Models
{
    public class ShowRateMaster
    {
        public int RateMasterId { get; set; }
        public string ServiceName { get; set; }
        public string Name { get; set; }
        public string ChargeType { get; set; }
        public string UnitType { get; set; }
        public string PaymentType { get; set; }
        public string Amount { get; set; }
        public int Isactive { get; set; }
    }
}
