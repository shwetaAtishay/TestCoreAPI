using System;
using System.Collections.Generic;

namespace BO.Models
{
    public class Common
    {
        public string CreatedIP { get; set; }
        public string CreatedByID { get; set; }
        public string CreatedByName { get; set; }
        public string CreatedDate { get; set; }
        public string ModifyByName { get; set; }
        public string ModifyByID { get; set; }
        public string ModifyIP { get; set; }
        public string ModifyDate { get; set; }
    }
    public partial class RateMaster: Common
    {
        public int RateMasterId { get; set; }
        public int? HardWareServicesId { get; set; }
        public int? ChargeType { get; set; }
        public int? UnitType { get; set; }
        public int? TypeId { get; set; }
        public int? PaymentType { get; set; }
        public long? Amount { get; set; }
        public int? IsActive { get; set; }
        public string Createdby { get; set; }
        public DateTime? Createdon { get; set; }

        //Emitra based get model       
        public long RateId { get; set; }
        public long MstCategoryId { get; set; }
        public long SubMstCategoryId { get; set; }
        public long ChildCateId { get; set; }
        public int DepartmentCharge { get; set; }
        public int EmitraCharge { get; set; }
        public int PrintingCharge { get; set; }
        public int HomeCharge { get; set; }
        //public int IsActive { get; set; }
        public string DepartmentName { get; set; }
        public string ServiceName { get; set; }
        public string ChildServiceName { get; set; }
        public string CollectionTime { get; set; }
        public string CollectionTotal { get; set; }
        public string Total { get; set; }
        public string DeliveryTotal { get; set; }
        public string ID { get; set; }
        public string Name { get; set; }
    }

    public class RATEMST
    {
        public int iPK_RateMstId { get; set; }
        public int? iFK_HrdWarSrvicId { get; set; }
        public int? iChngTyp { get; set; }
        public int? iUntTyp { get; set; }
        public int? iTypId { get; set; }
        public int? iPymntTyp { get; set; }
        public long? BiAmt { get; set; }
        public int? iIsActv { get; set; }
        public string dtCrtdBy { get; set; }
        public DateTime? dtCrtdDt { get; set; }
    }
    //For Emitra Releated Page model
    public class RateSpecialCategory
    {
        public int SpecialCategoryid { get; set; }
        public int RateMasterId { get; set; }
        public int SpecialMasterid { get; set; }
        public int DepartmentCharge { get; set; }
        public int EmitraCharge { get; set; }

        public int IsActive { get; set; }
    }

    public class SlotEnquiryMasterTemp
    {
        public string SlotMasterId { get; set; }
        public long ColourId { get; set; }
        public int NoofEnquiry { get; set; }
        public int Id { get; set; }
        public string ColorName { get; set; }
    }
    public class SlotMaster
    {
        public string SlotMasterId { get; set; }
        public int DistrictId { get; set; }
        public int BlockId { get; set; }
        public int AreaId { get; set; }
        public string Fromdate { get; set; }
        public string Todate { get; set; }
        public string ActivateSlot { get; set; }
        public string CreatedByID { get; set; }
        public string CreatedByName { get; set; }
        public string DistrictName { get; set; }
        public string BlockName { get; set; }
        public string AreaName { get; set; }
        public string Freedata { get; set; }
        public int IsActive { get; set; }

    }
    public class FreezeSlot
    {
        public long SlotFreezeDateId { get; set; }

        public string SlotMasterId { get; set; }
        public string FreezeDate { get; set; }
        public string Remark { get; set; }
        public string CreateById { get; set; }
        public string CreatedByName { get; set; }
    }
}
