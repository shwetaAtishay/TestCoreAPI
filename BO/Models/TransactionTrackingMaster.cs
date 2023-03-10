using System;
using System.Collections.Generic;

namespace BO.Models
{
    public partial class TransactionTrackingMaster
    {
        public int TransactionTrackingId { get; set; }
        public string PartyId { get; set; }
        public int? IsActive { get; set; }
        public int? Type { get; set; }
        public string TransferAmount { get; set; }
        public string Ipaddress { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateOn { get; set; }
        public string ModeOfTransfer { get; set; }
        public int? Commission { get; set; }
        public int? TransactionStatus { get; set; }
        public string Reason { get; set; }
        public string SessionId { get; set; }
    }
}
