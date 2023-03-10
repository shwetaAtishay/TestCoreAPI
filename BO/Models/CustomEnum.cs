using System;
using System.Collections.Generic;

namespace BO.Models
{
    public partial class CustomEnum
    {
        public int CustomEnumId { get; set; }
        public int? EnumNo { get; set; }
        public string Name { get; set; }
        public string text { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string PartyId { get; set; }
        public int? Id { get; set; }
        public int? IsActive { get; set; }
    }
    public class ExistingNOCRequest
    {
        public string Type { get; set; }
        public string TrustId { get; set; }
        public string CollageId { get; set; }
        public string DepartmentId { get; set; }
        public string CourseId { get; set; }
    }
}
