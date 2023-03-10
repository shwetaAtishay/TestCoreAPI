using System;
using System.Collections.Generic;
using System.Text;

namespace BO.Models
{
    public class ChargeMasterBO
    {
        public int MstChargeID { get; set; }
        public int MstCategoryID { get; set; }
        public int SubMstCategoryID { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }

        public bool IsActive { get; set; }
        public int CategoryLevel { get; set; }
        public int DocumentProcessingFees { get; set; }
        public int DisplayMenuLevel { get; set; }
        public bool EndMenu { get; set; }
        public int Ordering { get; set; }
        public bool DisplayDisable { get; set; }
        public bool PermissionView { get; set; }
        public bool PermissionEdit { get; set; }
        public bool PermissionDelete { get; set; }
        public int RelationShipOrgnizationID { get; set; }
        public bool PermissionNew { get; set; }
        public string AliesName { get; set; }
        public string ControllerName { get; set; }
        public string ControllerFunction { get; set; }
        public string DisplayType { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string CreatedByName { get; set; }
        public string CreatedByID { get; set; }
        public string CreatedIP { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifyByName { get; set; }
        public string ModifyByID { get; set; }
        public string ModifyIP { get; set; }
        public DateTime ModifyDate { get; set; }
        public bool IsDeleted { get; set; }
        public int PrintingCharge { get; set; }
        public int RegistrationFee { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int UpperLimit { get; set; }
        public int LowerLimit { get; set; }
        public int Quantity { get; set; }

    }

    public class ResourceType
    {
        public int MstCategoryID { get; set; }
        public string Category { get; set; }
    }
    public class DepartmentTypeDocumentBO
    {
        public int MstCategoryID { get; set; }
        public string Category { get; set; }
    }
}
