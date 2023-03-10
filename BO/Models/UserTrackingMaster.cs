using System;
using System.Collections.Generic;

namespace BO.Models
{
    public partial class UserTrackingMaster
    {
        public int UserTrackingId { get; set; }
        public string Ipaddress { get; set; }
        public DateTime? TimeIn { get; set; }
        public DateTime? TimeOut { get; set; }
        public string OperationName { get; set; }
        public int? UserId { get; set; }
        public string OperationId { get; set; }
        public string Reason { get; set; }
        public int? EntityId { get; set; }
        public string SessionId { get; set; }
    }
}
