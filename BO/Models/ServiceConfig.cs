using System;
using System.Collections.Generic;

namespace BO.Models
{
    public partial class ServiceConfig
    {
        public int ServiceConfMtrId { get; set; }
        public long? ServiceId { get; set; }
        public int? MappingTypeId { get; set; }
        public string ServiceHardwareId { get; set; }
        public int? IsActive { get; set; }
    }
    public class ServiceTypeDocument
    {
        public List<ServiceTypeDocument> ServiceList { get; set; }
        public int MstCategoryID { get; set; }
        public int MstServiceTypeID { get; set; }
        public int MstServiceTypeDocumentID { get; set; }
        public string ServiceName { get; set; }
        public string ServiceTypeCode { get; set; }
        public string DocumentName { get; set; }
        public string SubServiceType { get; set; }
        public string DocumentName_Hindi { get; set; }
        public int Fromdays { get; set; }
        public int Todays { get; set; }
        public string Required { get; set; }
        public int SrNo { get; set; }
        public string CreatedByID { get; set; }
        public string CreatedByName { get; set; }
        public string CreatedIP { get; set; }
        public string CreatedDate { get; set; }
        public string ModifyByName { get; set; }
        public string ModifyByID { get; set; }
        public string ModifyIP { get; set; }
        public string ModifyDate { get; set; }
        public bool IsActive { get; set; }
        public int PrintingCharge { get; set; }
        public int Type { get; set; }
        public string InputString { get; set; }
        public int ChildSubCategory { get; set; }

        public string ID { get; set; }
        public string Name { get; set; }
        public int CollectionID { get; set; }


    }
}
