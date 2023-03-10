using System;
using System.Collections.Generic;

namespace BO.Models
{
    public partial class CategoryMaster
    {
        public int CategoryId { get; set; }
        public int? SubCategoryId { get; set; }
        public int? IsActive { get; set; }
        public string Name { get; set; }
        public int? Type { get; set; }
        public string VarificationList { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateOn { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateOn { get; set; }
        public string DocumentList { get; set; }
        public string ServicesList { get; set; }
        public string HardwareList { get; set; }
        public string ClassName { get; set; }
    }
    public class SRVCMST
    {
        public int iPK_CatId { get; set; }
        public int? iFK_SubCatId { get; set; }
        public int? iIsActv { get; set; }
        public string sName { get; set; }
        public int? iTyp { get; set; }
        public string sVrfctnLst { get; set; }
        public string sCrtdBy { get; set; }
        public DateTime? dtCrtdDt { get; set; }
        public string sUpdtBy { get; set; }
        public DateTime? dtUpdtOn { get; set; }
        public string sDcmntLst { get; set; }
        public string sSrvcLst { get; set; }
        public string sHrdwrLst { get; set; }
        public string sClsNm { get; set; }
    }
}
