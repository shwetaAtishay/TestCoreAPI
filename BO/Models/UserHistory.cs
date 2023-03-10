using System;
using System.Collections.Generic;

namespace BO.Models
{
    public partial class UserHistory
    {
        public string PartyId { get; set; }
        public long? Mobile { get; set; }
        public string Email { get; set; }
        public byte[] Passwordhash { get; set; }
        public string CurrentAddress { get; set; }
        public string ParmentAddress { get; set; }
        public string OfficeAddress { get; set; }
        public long? PinCode { get; set; }
    }
}
