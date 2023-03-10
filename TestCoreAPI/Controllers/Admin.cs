using BL;
using BO;
using BO.Models;
using DL;
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
    public class Admin : Controller
    {
        AdminBL objAdminBL = new AdminBL();
        ErrorBO _Result = new ErrorBO();
        [HttpGet]
        [Route("GetCustomList")]
        public ResponseData GetCustomList(int EnumNo)
        {
            ResponseData objResponseData = new ResponseData();
            List<CustomList> ListRequest = new List<CustomList>();
            ListRequest = objAdminBL.GetServiceByDepartmentId(EnumNo);
            string raw = JObject.FromObject(new { ListRequest }).NulllToString();
            raw = EncryptDecrypt.EncryptRaw(raw);
            if (ListRequest != null)
            {
                objResponseData.Data = JObject.FromObject(new { ListRequest }); ;
                objResponseData.Body = raw;
                objResponseData.ResponseCode = "000";
                objResponseData.Message = "Custom Data List";
                objResponseData.statusCode = 1;
            }
            else
            {

                objResponseData.Data = null;
                objResponseData.ResponseCode = "000";
                objResponseData.Message = "Data Not Available";
                objResponseData.statusCode = 0;

            }

            return objResponseData;
        }
        [HttpGet]
        [Route("GetChargesType")]
        public ResponseData GetChargesType(long ServiceId)
        {
            ResponseData objResponseData = new ResponseData();
            List<CustomList> ListRequest = new List<CustomList>();
            ListRequest = objAdminBL.GetChargesType(ServiceId);
            string raw = JObject.FromObject(new { ListRequest }).NulllToString();
            raw = EncryptDecrypt.EncryptRaw(raw);
            if (ListRequest != null)
            {
                objResponseData.Data = JObject.FromObject(new { ListRequest }); ;
                objResponseData.Body = raw;
                objResponseData.ResponseCode = "000";
                objResponseData.Message = "Custom Data List";
                objResponseData.statusCode = 1;
            }
            else
            {

                objResponseData.Data = null;
                objResponseData.ResponseCode = "000";
                objResponseData.Message = "Data Not Available";
                objResponseData.statusCode = 0;

            }

            return objResponseData;
        }
      
        #region 2
        //[HttpPost]
        //[Route("InsertServices")]
        //public ResponseData InsertServices(CategoryMaster obj)
        //{
        //    ResponseData objResponseData = new ResponseData();
        //    objResponseData = objAdminBL.InsertServices(obj);
        //    if (objResponseData.statusCode == 1 || objResponseData.statusCode == 0)
        //    {

        //        objResponseData.ResponseCode = "000";
        //    }
        //    else
        //    {
        //        objResponseData.ResponseCode = "001";
        //    }


        //    return objResponseData;

        //}

        [HttpPost]
        [Route("InsertServices")]
        public ResponseData InsertServices(SRVCMST obj)
        {
            ResponseData objResponseData = new ResponseData();
            objResponseData = objAdminBL.InsertServices(obj);
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
        #endregion

        #region 3
        //[HttpPost]
        //[Route("InserGstApplicable")]
        //public ResponseData InserGstApplicable(GSTApplicable applicable)
        //{
        //    ResponseData objResponseData = new ResponseData();
        //    objResponseData = objAdminBL.InserGstApplicable(applicable);
        //    if (objResponseData.statusCode == 1 || objResponseData.statusCode == 0)
        //    {

        //        objResponseData.ResponseCode = "000";
        //    }
        //    else
        //    {
        //        objResponseData.ResponseCode = "001";
        //    }


        //    return objResponseData;

        //}
        #endregion

        #region 1
        //[HttpGet]
        //[Route("GetServicesDetail")]
        //public ResponseData GetServicesDetail(int Id=0)
        //{
        //    ResponseData objResponseData = new ResponseData();
        //    List<CategoryMaster> ListRequest = new List<CategoryMaster>();
        //    ListRequest = objAdminBL.GetServicesDetail(Id);       
        //    string raw = JObject.FromObject(new { ListRequest }).NulllToString();
        //    raw = EncryptDecrypt.EncryptRaw(raw);
        //    if (ListRequest != null)
        //    {
        //        objResponseData.Data = JObject.FromObject(new { ListRequest }); ;
        //        objResponseData.Body = raw;
        //        objResponseData.ResponseCode = "000";
        //        objResponseData.Message = "Service List";
        //        objResponseData.statusCode = 1;
        //    }
        //    else
        //    {

        //        objResponseData.Data = null;
        //        objResponseData.ResponseCode = "000";
        //        objResponseData.Message = "Data Not Available";
        //        objResponseData.statusCode = 0;

        //    }

        //    return objResponseData;
        //}


        [HttpGet]
        [Route("GetServicesDetail")]
        public ResponseData GetServicesDetail(int Id = 0)
        {
            ResponseData objResponseData = new ResponseData();
            List<SRVCMST> ListRequest = new List<SRVCMST>();
            ListRequest = objAdminBL.GetServicesDetail(Id);
            string raw = JObject.FromObject(new { ListRequest }).NulllToString();
            raw = EncryptDecrypt.EncryptRaw(raw);
            if (ListRequest != null)
            {
                objResponseData.Data = JObject.FromObject(new { ListRequest }); ;
                objResponseData.Body = raw;
                objResponseData.ResponseCode = "000";
                objResponseData.Message = "Service List";
                objResponseData.statusCode = 1;
            }
            else
            {

                objResponseData.Data = null;
                objResponseData.ResponseCode = "000";
                objResponseData.Message = "Data Not Available";
                objResponseData.statusCode = 0;

            }

            return objResponseData;
        }
        #endregion

        #region 4
        //[HttpPost]
        //[Route("InsertRateMaster")]
        //public ResponseData InsertRateMaster(RateMaster master)
        //{
        //    ResponseData objResponseData = new ResponseData();
        //    objResponseData = objAdminBL.InsertRateMaster(master);
        //    if (objResponseData.statusCode == 1 || objResponseData.statusCode == 0)
        //    {

        //        objResponseData.ResponseCode = "000";
        //    }
        //    else
        //    {
        //        objResponseData.ResponseCode = "001";
        //    }
        //    return objResponseData;
        //}

        [HttpPost]
        [Route("InsertRateMaster")]
        public ResponseData InsertRateMaster(RateMaster master)
        {
            ResponseData objResponseData = new ResponseData();
            objResponseData = objAdminBL.InsertRateMaster(master);
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
        #endregion


        [HttpGet]
        [Route("GetRateMasterDetail")]
        public ResponseData GetRateMasterDetail()
        {
            ResponseData objResponseData = new ResponseData();
            List<ShowRateMaster> ListRequest = new List<ShowRateMaster>();
            ListRequest = objAdminBL.GetRateMasterDetail();
            //string raw = JObject.FromObject(new { ListRequest }).ToString();
            //raw = EncryptDecrypt.EncryptRaw(raw);
            if (ListRequest != null)
            {
                objResponseData.Data = ListRequest;
                //objResponseData.Body = raw;
                objResponseData.ResponseCode = "000";
                objResponseData.Message = "Service List";
                objResponseData.statusCode = 1;
            }
            else
            {

                objResponseData.Data = null;
                objResponseData.ResponseCode = "000";
                objResponseData.Message = "Data Not Available";
                objResponseData.statusCode = 0;

            }

            return objResponseData;
        }
        #region Common function
        [HttpGet]
        [Route("GetGeographicalData")]
        public ResponseData GetGeographicalData(int Id, int districtId, int Type)
        {
            ResponseData objResponseData = new ResponseData();
            List<GlobalClass> ListRequest = new List<GlobalClass>();
            ListRequest = objAdminBL.GetGeographicalData(Id, districtId, Type);
            //string raw = JObject.FromObject(new { ListRequest }).ToString();
            //raw = EncryptDecrypt.EncryptRaw(raw);
            if (ListRequest != null)
            {
                objResponseData.Data = ListRequest;
                //objResponseData.Body = raw;
                objResponseData.ResponseCode = "000";
                objResponseData.Message = "Service List";
                objResponseData.statusCode = 1;
            }
            else
            {

                objResponseData.Data = null;
                objResponseData.ResponseCode = "000";
                objResponseData.Message = "Data Not Available";
                objResponseData.statusCode = 0;

            }

            return objResponseData;
        }
        #endregion

        [HttpPost]
        [Route("ChangeStatus")]
        public ResponseData ChangeStatus(Activeclass master)
        {
            ResponseData objResponseData = new ResponseData();
            objResponseData = objAdminBL.ChangeStatus(master);
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
      

        //[HttpGet]
        //[Route("GetPartDetails")]
        //public PartyProfile GetPartyDetails(PartyProfile obj)
        //{
        //    obj.StringType = "SelectSingleParty";
        //    return objAdminBL.GetPartyDetails(obj);
        //}


        #region created by abhishek Method Name:GetSetting create date:27/05/2022
        [HttpGet]
        [Route("GetSetting")]
        public ResponseData GetSetting()
        {
            ResponseData objResponseData = new ResponseData();
            List<setting> ListRequest = new List<setting>();
            ListRequest = objAdminBL.GetSetting();
            //string raw = JObject.FromObject(new { ListRequest }).ToString();
            //raw = EncryptDecrypt.EncryptRaw(raw);
            if (ListRequest != null)
            {
                objResponseData.Data = ListRequest;
                //objResponseData.Body = raw;
                objResponseData.ResponseCode = "000";
                objResponseData.Message = "Setting  List";
                objResponseData.statusCode = 1;
            }
            else
            {

                objResponseData.Data = null;
                objResponseData.ResponseCode = "000";
                objResponseData.Message = "Data Not Available";
                objResponseData.statusCode = 0;

            }

            return objResponseData;
        }

        [HttpGet]
        [Route("GetCustomEnum")]
        public ResponseData GetCustomEnum()
        {
            ResponseData objResponseData = new ResponseData();
            List<CustomEnum> ListRequest = new List<CustomEnum>();
            ListRequest = objAdminBL.GetCustomEnum();
            //string raw = JObject.FromObject(new { ListRequest }).ToString();
            //raw = EncryptDecrypt.EncryptRaw(raw);
            if (ListRequest != null)
            {
                objResponseData.Data = ListRequest;
                //objResponseData.Body = raw;
                objResponseData.ResponseCode = "000";
                objResponseData.Message = "Custom Enum List";
                objResponseData.statusCode = 1;
            }
            else
            {

                objResponseData.Data = null;
                objResponseData.ResponseCode = "000";
                objResponseData.Message = "Data Not Available";
                objResponseData.statusCode = 0;

            }

            return objResponseData;
        }
        [HttpPost]
        [Route("InsertNewCustomEnumRow")]
        public ResponseData InsertNewCustomEnumRow(int Id)
        {
            ResponseData objResponseData = new ResponseData();
            int CustomEnumId = objAdminBL.InsertNewCustomEnumRow(Id);

            if (CustomEnumId != 0)
            {

                objResponseData.ResponseCode = "001";
                objResponseData.ID = CustomEnumId;
            }
            else
            {
                objResponseData.ResponseCode = "000";
            }


            return objResponseData;


        }
        [HttpPost]
        [Route("DeleteCustomSentence")]
        public ResponseData DeleteCustomSentence(int Id)
        {
            ResponseData objResponseData = new ResponseData();
            int CustomEnumId = objAdminBL.DeleteCustomSentence(Id);

            if (CustomEnumId != 0)
            {

                objResponseData.ResponseCode = "001";

            }
            else
            {
                objResponseData.ResponseCode = "000";
            }


            return objResponseData;


        }
        [HttpPost]
        [Route("UpdateSubjectLines")]
        public ResponseData UpdateSubjectLines(int Id, string Text)
        {
            ResponseData objResponseData = new ResponseData();
            int CustomEnumId = objAdminBL.UpdateSubjectLines(Id, Text);

            if (CustomEnumId != 0)
            {

                objResponseData.ResponseCode = "001";

            }
            else
            {
                objResponseData.ResponseCode = "000";
            }


            return objResponseData;


        }
        #endregion

        

        #region ChangeRequest From Admin : Added By shipra
        [HttpPost]
        [Route("ChangeRequestList")]
        public ChangeRquestDataList GetClientRequestData(string PartyId, int PartyType = 0)
        {
            return objAdminBL.GetClientRequestData(PartyId, PartyType);
        }
        [HttpPost]
        [Route("SaveChangeRequest")]
        public ResponseData SaveChangeRequest(string PartyId, string ParentId)
        {
            return objAdminBL.SaveChangeRequest(PartyId, ParentId);
        }

        [HttpPost]
        [Route("GetChangeRequestList")]
        public List<ClientRequestData> GetChangeRequestList(string PartyId)
        {
            return objAdminBL.GetChangeRequestList(PartyId);
        }

       [HttpPost]
        [Route("RejectClientRequest")]
        public ResponseData RejectChangeRequest(string PartyId)
        {
            Request.Headers.TryGetValue("LoginID", out var LoginId);
            return objAdminBL.RejectChangeRequest(PartyId, LoginId);
        }
        [HttpPost]
        [Route("ApprovedChangeRequest")]
        public ResponseData ApprovedChangeRequest(string PartyId)
        {
            Request.Headers.TryGetValue("LoginID", out var LoginId);
            return objAdminBL.ApprovedChangeRequest(PartyId, LoginId);
        }
        #endregion


        [HttpPost]
        [Route("GetActivePartyList")]
        public SelectedList GetActivePartyList(ListRequest req)
        {
            Request.Headers.TryGetValue("LoginID", out var LoginID);
            req.LoginID = LoginID;
            req.Type = "GetActivePartyList_ForChange";
            if (req.Type != "" && req.Type != null)
            {
                return objAdminBL.SelectList(req);
            }
            else
            {
                SelectedList lst = new SelectedList();
                lst.Data = null;
                lst.Messsage = "Invalid Request!";
                lst.ResponseCode = "0";
                return lst;
            }
        }

        [HttpGet]
        [Route("GetFacilityDetails")]
        public List<AddCourseBO> GetFacilityDetails(string GUID)
        {

            return objAdminBL.FacilityDetails(GUID);
        }
        [HttpPost]
        [Route("Facilites")]
        public ResponseData Facilites()
        {
            try
            {
                var objResponseData = objAdminBL.GetFacilites();
                return objResponseData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet]
        [Route("GetDetailsId")]
        public List<AddCourseBO> GetDetailsId(string GUID)
        {

            return objAdminBL.GetId(GUID);
        }

    }
}
