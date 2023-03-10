using BL;
using BO;
using BO.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestCoreAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RateMasterController : Controller
    {
        // GET: Rate
        RateBL _ObjRate = new RateBL();
        #region User Details
        [HttpGet]
        [Route("GetRateDetail")]
        public ResponseData GetRateDetail(string ID = "")
        {
            ResponseData objResponseData = new ResponseData();
            List<RateMaster> ListRequest = new List<RateMaster>();
            ListRequest = _ObjRate.GetRateMasterDetail(ID);
            string raw = JObject.FromObject(new { ListRequest }).NulllToString();
            raw = EncryptDecrypt.EncryptRaw(raw);
            if (ListRequest != null)
            {
                objResponseData.Data = JObject.FromObject(new { ListRequest });
                objResponseData.Body = raw;
                objResponseData.ResponseCode = "000";
                objResponseData.Message = "Rate Details";
                objResponseData.statusCode = 1;
            }
            return objResponseData;
        }
        [HttpGet]
        [Route("GetSlotMasterDetail")]
        public ResponseData GetSlotMasterDetail(string ID = null, int Type = 0)
        {
            ResponseData objResponseData = new ResponseData();

            List<SlotMaster> ListRequest = new List<SlotMaster>();
            ListRequest = _ObjRate.GetSlotMasterDetail(ID, Type);
            string raw = JObject.FromObject(new { ListRequest }).NulllToString();
            raw = EncryptDecrypt.EncryptRaw(raw);
            if (ListRequest != null)
            {
                objResponseData.Data = JObject.FromObject(new { ListRequest });
                objResponseData.Body = raw;
                objResponseData.ResponseCode = "000";
                objResponseData.Message = "Rate Details";
                objResponseData.statusCode = 1;
            }
            return objResponseData;
        }
        [HttpGet]
        [Route("FillSpecialCategoryWiseRate")]
        public ResponseData FillSpecialCategoryWiseRate(int ID, long RateMasterId)
        {
            ResponseData objResponseData = new ResponseData();
            RateSpecialCategory specialCategory = new RateSpecialCategory();
            specialCategory.RateMasterId = (Int32)RateMasterId;
            specialCategory.SpecialMasterid = ID;
            List<RateSpecialCategory> ListRequest = new List<RateSpecialCategory>();
            ListRequest = _ObjRate.GetSpecialCategoryWiseRate(specialCategory);
            string raw = JObject.FromObject(new { ListRequest }).NulllToString();
            raw = EncryptDecrypt.EncryptRaw(raw);
            if (ListRequest != null)
            {
                objResponseData.Data = JObject.FromObject(new { ListRequest });
                objResponseData.Body = raw;
                objResponseData.ResponseCode = "000";
                objResponseData.Message = "Rate Details";
                objResponseData.statusCode = 1;
            }
            return objResponseData;
        }

        //For DropDown Rate price
        [HttpGet]
        [Route("GetSpecialCategoryWiseRate")]
        public ResponseData GetSpecialCategoryWiseRate(string RateMasterId)
        {
            ResponseData objResponseData = new ResponseData();
            RateSpecialCategory specialCategory = new RateSpecialCategory();
            specialCategory.RateMasterId = Convert.ToInt32(RateMasterId);
            //specialCategory.SpecialMasterid = ID;
            List<RateSpecialCategory> ListRequest = new List<RateSpecialCategory>();
            ListRequest = _ObjRate.GetSpecialCategoryWise(specialCategory);
            string raw = JObject.FromObject(new { ListRequest }).NulllToString();
            raw = EncryptDecrypt.EncryptRaw(raw);
            if (ListRequest != null)
            {
                objResponseData.Data = JObject.FromObject(new { ListRequest });
                objResponseData.Body = raw;
                objResponseData.ResponseCode = "000";
                objResponseData.Message = "Rate Details";
                objResponseData.statusCode = 1;
            }
            return objResponseData;
        }
        #endregion

        [HttpPost]
        [Route("InsertUpdateRate")]
        public ResponseData InsertUpdateRate(RateMaster obj)
        {
            ResponseData objResponseData = new ResponseData();
            objResponseData = _ObjRate.InsertUpdateRate(obj);
            if (objResponseData.statusCode == 1 || objResponseData.statusCode == 0)
            {

                objResponseData.ResponseCode = "000";
            }
            else
            {
                objResponseData.ResponseCode = "001";
            }


            return objResponseData;

        }
        [HttpPost]
        [Route("InsertUpdateSlot")]
        public ResponseData InsertUpdateSlot(SlotMaster Obj)
        {
            ResponseData objResponseData = new ResponseData();
            objResponseData = _ObjRate.InsertUpdateSlot(Obj);
            if (objResponseData.statusCode == 1 || objResponseData.statusCode == 0)
            {

                objResponseData.ResponseCode = "000";
            }
            else
            {
                objResponseData.ResponseCode = "001";
            }


            return objResponseData;

        }
        [HttpPost]
        [Route("InsertUpdateSpecialCategory")]
        public ResponseData InsertUpdateSpecialCategory(RateSpecialCategory obj)
        {
            ResponseData objResponseData = new ResponseData();
            objResponseData = _ObjRate.InsertUpdateSpecialCategory(obj);
            if (objResponseData.statusCode == 1 || objResponseData.statusCode == 0)
            {

                objResponseData.ResponseCode = "000";
            }
            else
            {
                objResponseData.ResponseCode = "001";
            }


            return objResponseData;

        }
        [HttpPost]
        [Route("ChangeStatus")]
        public ResponseData ChangeStatus(RateMaster obj)
        {
            ResponseData objResponseData = new ResponseData();
            objResponseData = _ObjRate.ChangeStatus(obj);
            if (objResponseData.statusCode == 1 || objResponseData.statusCode == 0)
            {

                objResponseData.ResponseCode = "000";
            }
            else
            {
                objResponseData.ResponseCode = "001";
            }


            return objResponseData;

        }
        [HttpPost]
        [Route("SlotChangeStatus")]
        public ResponseData SlotChangeStatus(SlotMaster obj)
        {
            ResponseData objResponseData = new ResponseData();
            objResponseData = _ObjRate.SlotChangeStatus(obj);
            if (objResponseData.statusCode == 1 || objResponseData.statusCode == 0)
            {

                objResponseData.ResponseCode = "000";
            }
            else
            {
                objResponseData.ResponseCode = "001";
            }


            return objResponseData;

        }
        [HttpPost]
        [Route("InsertFreezeDate")]
        public ResponseData InsertFreezeDate(FreezeSlot temp)
        {
            ResponseData objResponseData = new ResponseData();
            objResponseData = _ObjRate.InsertFreezeDate(temp);
            if (objResponseData.statusCode == 1 || objResponseData.statusCode == 0)
            {

                objResponseData.ResponseCode = "000";
            }
            else
            {
                objResponseData.ResponseCode = "001";
            }


            return objResponseData;
        }
        [HttpPost]
        [Route("InsertUpdateSlotEnquiryMaster")]
        public ResponseData InsertUpdateSlotEnquiryMaster(SlotEnquiryMasterTemp temp)
        {
            ResponseData objResponseData = new ResponseData();
            objResponseData = _ObjRate.InsertUpdateSlotEnquiryMaster(temp);
            if (objResponseData.statusCode == 1 || objResponseData.statusCode == 0)
            {

                objResponseData.ResponseCode = "000";
            }
            else
            {
                objResponseData.ResponseCode = "001";
            }


            return objResponseData;
        }

        [HttpGet]
        [Route("GetAllSlotColor")]
        public ResponseData GetAllSlotColor(string ID = "")
        {
            ResponseData objResponseData = new ResponseData();

            List<SlotEnquiryMasterTemp> ListRequest = new List<SlotEnquiryMasterTemp>();
            ListRequest = _ObjRate.GetAllSlotColor(ID);
            string raw = JObject.FromObject(new { ListRequest }).NulllToString();
            raw = EncryptDecrypt.EncryptRaw(raw);
            if (ListRequest != null)
            {
                objResponseData.Data = JObject.FromObject(new { ListRequest });
                objResponseData.Body = raw;
                objResponseData.ResponseCode = "000";
                objResponseData.Message = "Rate Details";
                objResponseData.statusCode = 1;
            }
            return objResponseData;
        }
        [HttpGet]
        [Route("GetFreezeSlotDetail")]
        public ResponseData GetFreezeSlotDetail(string ID = "")
        {
            ResponseData objResponseData = new ResponseData();

            List<FreezeSlot> ListRequest = new List<FreezeSlot>();
            ListRequest = _ObjRate.GetFreezeSlotDetail(ID);
            string raw = JObject.FromObject(new { ListRequest }).NulllToString();
            raw = EncryptDecrypt.EncryptRaw(raw);
            if (ListRequest != null)
            {
                objResponseData.Data = JObject.FromObject(new { ListRequest });
                objResponseData.Body = raw;
                objResponseData.ResponseCode = "000";
                objResponseData.Message = "Rate Details";
                objResponseData.statusCode = 1;
            }
            return objResponseData;
        }
        [HttpPost]
        [Route("DeleteSlotEnquiry")]
        public ResponseData DeleteSlotEnquiry(long Id)
        {
            ResponseData objResponseData = new ResponseData();
            objResponseData = _ObjRate.DeleteSlotEnquiry(Id);
            if (objResponseData.statusCode == 1 || objResponseData.statusCode == 0)
            {

                objResponseData.ResponseCode = "000";
            }
            else
            {
                objResponseData.ResponseCode = "001";
            }


            return objResponseData;
        }

        [HttpPost]
        [Route("DeleteFreezeDate")]
        public ResponseData DeleteFreezeDate(long Id)
        {
            ResponseData objResponseData = new ResponseData();
            objResponseData = _ObjRate.DeleteFreezeDate(Id);
            if (objResponseData.statusCode == 1 || objResponseData.statusCode == 0)
            {

                objResponseData.ResponseCode = "000";
            }
            else
            {
                objResponseData.ResponseCode = "001";
            }


            return objResponseData;
        }
    }
}
