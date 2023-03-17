using BL;
using BO;
using BO.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BO.Models.TrusteeBO;

namespace TestCoreAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TrusteeController : Controller
    {
        TrusteeBL _objTrusteeBL = new TrusteeBL();

        #region Trustee
        [HttpPost]
        [Route("AddTrustee")]
        public ErrorBO AddTrustee(TrusteeBO.Trustee _obj)
        {
            //TrusteeBO.Trustee _result = new TrusteeBO.Trustee();
            return _objTrusteeBL.SaveTrustee(_obj);
        }

        [HttpGet]
        [Route("TrusteeList")]
        public List<TrusteeBO.Trustee> TrusteeList(string TrustId)
        {
            //TrusteeBO.Trustee _result = new TrusteeBO.Trustee();
            return _objTrusteeBL.TrusteeList(TrustId);
        }
        [HttpGet]
        [Route("WomenCount")]
        public ResponseData WomenCount(string CollegeId, string TrustId)
        {
            //TrusteeBO.Trustee _result = new TrusteeBO.Trustee();
            return _objTrusteeBL.Women(CollegeId, TrustId);
        }
        [HttpGet]
        [Route("chkIsPrime")]
        public ResponseData chkIsPrime(string trustId, string CollegeId,string IsPrime)
        {
            //TrusteeBO.Trustee _result = new TrusteeBO.Trustee();
            return _objTrusteeBL.IsPrime(trustId, CollegeId, IsPrime);
        }

        [HttpPost]
        [Route("DocumentDetail")]
        public TrusteeBO.Trustee DocumentDetail(string Id)
        {
            //TrusteeBO.Trustee _result = new TrusteeBO.Trustee();
            return _objTrusteeBL.DocumentDetail(Id);
        }
        #endregion'

        #region Trustee Info
        [HttpPost]
        [Route("AddTrusteeInfo")]
        public ErrorBO AddTrusteeInfo(TrusteeBO.TrusteeInfo _obj)
        {
            //TrusteeBO.Trustee _result = new TrusteeBO.Trustee();
            return _objTrusteeBL.SaveTrusteeInfo(_obj);
        }

        [HttpGet]
        [Route("GetTrustDropDownList")]
        public ResponseData GetTrustDropDownList()
        {
            ResponseData objResponseData = new ResponseData();
            List<CustomList> ListRequest = new List<CustomList>();
            ListRequest = _objTrusteeBL.GetTrustDropDownList();
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
        [Route("TrustInfoList")]
        public List<TrusteeBO.TrusteeInfo> TrustInfoList()
        {
            //TrusteeBO.Trustee _result = new TrusteeBO.Trustee();
            return _objTrusteeBL.TrustInfoList();
        }
        #endregion

        [HttpGet]
        [Route("CollageListApply")]
        public List<TrusteeBO.CollageList> CollageListApply(string TrustId)
        {
            return _objTrusteeBL.CollageListApply(TrustId);
        }

        [HttpPost]
        [Route("AddCollageFacility")]
        public ErrorBO AddCollageFacility(TrusteeBO.CollageFacility _obj)
        {
            return _objTrusteeBL.AddCollageFacility(_obj);
        }


        [HttpPost]
        [Route("GetFeeDetailsList")]
        public TrusteeBO.CollageFeeMst GetFeeDetailsList(TrusteeBO.CollageFeeMst _obj)
        {
            return _objTrusteeBL.GetFeeDetailsList(_obj);
        }

        [HttpPost]
        [Route("AddCollageFee")]
        public ErrorBO AddCollageFee(TrusteeBO.CollageFeeMst _obj)
        {
            return _objTrusteeBL.AddCollageFee(_obj);
        }

        [HttpPost]
        [Route("SaveApplication")]
        public ResponseData addApplication(TrusteeBO.SaveApplicationModal modal)
        {
            //TrusteeBO.Trustee _result = new TrusteeBO.Trustee();
            return _objTrusteeBL.addApplication(modal);
        }

        [HttpPost]
        [Route("GetCollageFacilityList")]
        public TrusteeBO.CollageFacility GetCollageFacilityList(TrusteeBO.CollageFacility _obj)
        {
            return _objTrusteeBL.GetCollageFacilityList(_obj);
        }

        [HttpPost]
        [Route("AddCollageAttachements")]
        public ErrorBO AddCollageAttachements(TrusteeBO.CollageAttachment modal)
        {
            return _objTrusteeBL.AddCollageAttachements(modal);
        }

        [HttpPost]
        [Route("AddCollageAttachementMain")]
        public ResponseData AddCollageAttachementMain(TrusteeBO.CollageattachmentAPI modal)
        {
            return _objTrusteeBL.AddCollageAttachementMain(modal);
        }

        [HttpPost]
        [Route("AddCollageAttachementFiles")]
        public ErrorBO AddCollageAttachementFiles(TrusteeBO.DocumentsDetails modal)
        {
            return _objTrusteeBL.AddCollageAttachementFiles(modal);
        }

        [HttpPost]
        [Route("TrustVerification")]
        public ErrorBO TrustVerification(TrusteeBO.TrusteeInfo modal)
        {
            return _objTrusteeBL.TrustVerification(modal);
        }


        [HttpGet]
        [Route("GetTrustInfo")]
        public TrusteeBO.TrusteeInfo GetTrustInfo(string TrustId)
        {
            TrusteeBO.TrusteeInfo modal = new TrusteeBO.TrusteeInfo();
            modal.RegistrationNo = TrustId;

            //TrusteeBO.Trustee _result = new TrusteeBO.Trustee();
            return _objTrusteeBL.GetTrustInfo(modal);
        }

        [HttpPost]
        [Route("TrustVerificationAPI")]
        public ErrorBO TrustVerificationAPI(TrustRoot modal)
        {
            return _objTrusteeBL.TrustVerificationAPI(modal);
        }

        [HttpPost]
        [Route("DeleteTrustMemeber")]
        public ErrorBO DeleteTrustMemeber(int Id)
        {
            return _objTrusteeBL.DeleteTrustMemeber(Id);
        }

        [HttpGet]
        [Route("TrustVerificationAPIRequest")]
        public TrustRoot TrustAPI(string RegNo)
        {
            return _objTrusteeBL.TrustAPI(RegNo);
        }


        [HttpGet]
        [Route("GETNOCApplicationList")]
        public ResponseData GETNOCApplicationList(int deptID)
        {
            return _objTrusteeBL.GETNOCApplicationList(deptID);
        }

        [HttpGet]
        [Route("GETNOCApplicationClgList")]
        public ResponseData GETNOCApplicationClgList(int deptID)
        {
            return _objTrusteeBL.GETNOCApplicationClgList(deptID);
        }


        #region AddComments by Vivek
        [HttpPost]
        [Route("AddComments")]
        public ResponseData AddComments(InspectionComments comments)
        {
            return _objTrusteeBL.AddComments(comments);
        }
        #endregion

        #region OldNOC by Vivek
        [HttpPost]
        [Route("AddOldNOC")]
        public ResponseData AddOldNOC(List<TrusteeBO.OldNOCData> oldNOCData)
        {
            return _objTrusteeBL.AddOldNOC(oldNOCData);
        }

        [HttpPost]
        [Route("SaveMultipleNOC")]
        public ResponseData SaveMultipleNOC(TrusteeBO.SaveApplicationModal model)
        {
            return _objTrusteeBL.SaveMultipleNOC(model);
        }
        #endregion

        [HttpPost]
        [Route("SaveOtherTrustDetails")]
        public ErrorBO SaveOtherTrustDetails(TrusteeBO.TrusteeInfo _obj)
        {
            return _objTrusteeBL.SaveOtherTrustDetails(_obj);
        }
        [HttpGet]
        [Route("AmendmentCollege")]
        public List<CollegeAmendmentList> AmendmentCollege(string GUID)
        {
            return _objTrusteeBL.AmendmentCollege(GUID);
        }
        [HttpGet]
        [Route("GetEdit")]
        public List<CollegeAmendmentListEdit> GetEdit(int id)
        {
            return _objTrusteeBL.ListEditCourse(id);

        }

        [HttpGet]
        [Route("GetSubjectList")]
        public ResponseData GetSubjectList(string Guid, string CourseId)
        {
            ResponseData objResponseData = new ResponseData();
            List<CustomList> ListRequest = new List<CustomList>();
            ListRequest = _objTrusteeBL.GetSubjectList(Guid, CourseId);
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
        [Route("GetCourseList")]
        public ResponseData GetCourseList(string Guid)
        {
            ResponseData objResponseData = new ResponseData();
            List<CustomList> ListRequest = new List<CustomList>();
            ListRequest = _objTrusteeBL.GetCourseList(Guid);
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
        //[HttpPost]
        //[Route("InsertArchitechDetaile")]
        //public ResponseData InsertArchitechDetaile(List<Architecturesave> Mst)
        //{
        //    ResponseData objResponseData = new ResponseData();
        //    objResponseData = _objTrusteeBL.InsertArchitechDetaile(Mst);
        //    if (objResponseData.statusCode == 1 || objResponseData.statusCode == 0)
        //    {

        //        objResponseData.ResponseCode = "000";
        //        objResponseData.Message = objResponseData.Message;
        //    }
        //    else
        //    {
        //        objResponseData.Data = null;
        //        objResponseData.ResponseCode = "001";

        //    }


        //    return objResponseData;
        //}

        [HttpPost]
        [Route("UpdateFeeForApplication")]
        public ResponseData UpdateFeeForApplication(string applicationNumber, decimal totalFee)
        {
            var objResponseData = _objTrusteeBL.UpdateFeeForApplication(applicationNumber, totalFee);

            return objResponseData;
        }

        [HttpGet]
        [Route("GetCollageAttachment")]
        public List<CollageAttachment> GetCollageAttachment(string Guid)
        {
            return _objTrusteeBL.GetCollageAttachment(Guid);
        }

        [HttpGet]
        [Route("GetGUID")]
        public string GetGUID(string Type, string TrustId, string ColgId, string DeptId, string CourseId = null)
        {
            return _objTrusteeBL.GetGUID(Type, TrustId, ColgId, DeptId, CourseId);
        }
        [HttpPost]
        [Route("InsertArchitechDetaile")]
        public ResponseData InsertArchitechDetaile(List<Architecturesave> Mst)
        {
            ResponseData objResponseData = new ResponseData();
            objResponseData = _objTrusteeBL.InsertArchitechDetaile(Mst);
            if (objResponseData.statusCode == 1 || objResponseData.statusCode == 0)
            {

                objResponseData.ResponseCode = "000";
                objResponseData.Message = objResponseData.Message;
            }
            else
            {
                objResponseData.Data = null;
                objResponseData.ResponseCode = "001";

            }


            return objResponseData;
        }

        [HttpGet]
        [Route("GetArchitectureData")]
        public ResponseData GetArchitectureData(string AppGuid, int Type)
        {
            ResponseData objResponseData = new ResponseData();
            List<Architecturesave> ListRequest = new List<Architecturesave>();
            ListRequest = _objTrusteeBL.GetArchitectureData(AppGuid, Type);
            string raw = JObject.FromObject(new { ListRequest }).NulllToString();
            raw = EncryptDecrypt.EncryptRaw(raw);
            if (ListRequest != null)
            {
                objResponseData.Data = ListRequest; ;
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
        [Route("DeleteFacilityCourse")]
        public ResponseData DeleteFacilityCourse(int id)
        {
            var objResponseData = new ResponseData();
            var DeleteCourseBOs = _objTrusteeBL.ListDeleteCourse(id);
            objResponseData.statusCode = 1;
            objResponseData.Data = DeleteCourseBOs;
            return objResponseData;
        }

        [HttpPost]
        [Route("DocumentFacilityDetail")]
        public TrusteeBO.Trustee DocumentFacilityDetail(string GUID, int Identity)
        {
            return _objTrusteeBL.GetFacilites(GUID, Identity);

        }

        
        [HttpPost]
        [Route("CheckDraftValidationForEntry")]
        public ResponseData CheckDraftValidationForEntry(int clgID, string courses, string subjects)
        {
            return _objTrusteeBL.CheckDraftValidationForEntry(clgID, courses, subjects);

        }

    }
}

