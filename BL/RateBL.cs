using BO;
using BO.Models;
using DL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL
{
   public class RateBL
    {
        RateDL objRaterMasterDA = new RateDL();
        public List<RateMaster> GetRateMasterDetail(string ID = "")
        {
            return objRaterMasterDA.GetRateMasterDetail(ID);
        }
        public List<SlotMaster> GetSlotMasterDetail(string ID, int Type)
        {
            return objRaterMasterDA.GetSlotMasterDetail(ID, Type);
        }

        public ResponseData InsertUpdateRate(RateMaster obj)
        {
            return objRaterMasterDA.InsertUpdateRate(obj);

        }
        public ResponseData InsertUpdateSpecialCategory(RateSpecialCategory obj)
        {
            return objRaterMasterDA.InsertUpdateSpecialCategory(obj);
        }
        public ResponseData InsertUpdateSlot(SlotMaster obj)
        {
            return objRaterMasterDA.InsertUpdateSlot(obj);
        }

        public ResponseData ChangeStatus(RateMaster obj)
        {
            return objRaterMasterDA.ChangeStatus(obj);
        }

        public ResponseData SlotChangeStatus(SlotMaster obj)
        {
            return objRaterMasterDA.SlotChangeStatus(obj);
        }
        public List<RateSpecialCategory> GetSpecialCategoryWiseRate(RateSpecialCategory obj)
        {
            return objRaterMasterDA.GetSpecialCategoryWiseRate(obj);
        }
        //For DropDown male Female Rate
        public List<RateSpecialCategory> GetSpecialCategoryWise(RateSpecialCategory obj)
        {
            return objRaterMasterDA.GetSpecialCategoryWise(obj);
        }
        public ResponseData InsertUpdateSlotEnquiryMaster(SlotEnquiryMasterTemp obj)
        {
            return objRaterMasterDA.InsertUpdateSlotEnquiryMaster(obj);
        }
        public ResponseData InsertFreezeDate(FreezeSlot obj)
        {
            return objRaterMasterDA.InsertFreezeDate(obj);
        }
        public List<SlotEnquiryMasterTemp> GetAllSlotColor(string ID = "")
        {

            return objRaterMasterDA.GetAllSlotColor(ID);
        }
        public List<FreezeSlot> GetFreezeSlotDetail(string ID = "")
        {

            return objRaterMasterDA.GetFreezeSlotDetail(ID);
        }

        public ResponseData DeleteSlotEnquiry(long Id)
        {
            return objRaterMasterDA.DeleteSlotEnquiry(Id);
        }
        public ResponseData DeleteFreezeDate(long Id)
        {
            return objRaterMasterDA.DeleteFreezeDate(Id);
        }
    }
}
