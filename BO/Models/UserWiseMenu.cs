using System;
using System.Collections.Generic;

namespace BO.Models
{
    public partial class UserWiseMenu
    {
        public int UserWiseId { get; set; }
        public int? MenuMasterId { get; set; }
        public int? IsActive { get; set; }
        public string PermissionApplyid { get; set; }
        public int? LevelId { get; set; }
        public string PartyId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
