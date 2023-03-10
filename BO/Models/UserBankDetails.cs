using System;
using System.Collections.Generic;

namespace BO.Models
{
    public partial class UserBankDetails
    {
        public int UserBankId { get; set; }
        public string PartyId { get; set; }
        public string BankAccountNo { get; set; }
        public string Ifscno { get; set; }
        public int? GlobalId { get; set; }
        public string Branch { get; set; }
        public bool? IsPrimary { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
