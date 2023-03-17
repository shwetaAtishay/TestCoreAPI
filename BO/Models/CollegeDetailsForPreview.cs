using System;
using System.Collections.Generic;
using System.Text;

namespace BO.Models
{
    public class CollegeDetailsForPreview
    {
        public string CollegeName { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public int TrustID { get; set; }
        public string TrustName { get; set; }
        public int ClgTypeID { get; set; }
        public string CollegeType { get; set; }
        public string CollegeLevel { get; set; }
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public int DistrictID { get; set; }
        public string DistrictName { get; set; }
        public int TehsilID { get; set; }
        public string TehsilName { get; set; }
        public List<TrustMembers> TrustMembers { get; set; }

    }
    public class TrustMembers
    {
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
    }
}
