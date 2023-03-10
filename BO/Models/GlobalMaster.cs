using System;
using System.Collections.Generic;

namespace BO.Models
{
    public partial class GlobalMaster
    {
        public int GlobalId { get; set; }
        public string Name { get; set; }
        public int? IsActive { get; set; }
        public int? EnumNo { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateOn { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateOn { get; set; }
        public string PartyId { get; set; }
    }
    public partial class GlobalClass
    {

        public int Id { get; set; }
        public string strId { get; set; }
        public string value { get; set; }
        public string label { get; set; }
        public string graphbackcolor { get; set; }
        public string Text { get; set; }
        public int RecordCount { get; set; }
        public string Pincode { get; set; }
    }
}
