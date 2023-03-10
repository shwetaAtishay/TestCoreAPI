using System;
using System.Collections.Generic;
using System.Text;

namespace BO.Models
{
    public class CollegeAmendmentList
    {
        public int iPk_ClgID { get; set; }
        public string PartyId { get; set; }
        public string NameOfClg { get; set; }
    }
    public class CollegeAmendmentListEdit
    {
        public int iPk_ClgID { get; set; }
        public int iFk_DistId { get; set; }
        public int iFk_ThslId { get; set; }
        public int iFk_TrstInfoId { get; set; }
        public string Addressoneold { get; set; }
        public string Addresstwoold { get; set; }
        
    }
}
