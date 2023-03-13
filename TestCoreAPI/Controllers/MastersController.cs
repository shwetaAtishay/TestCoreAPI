using BL;
using BO;
using BO.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace TestCoreAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MastersController : ControllerBase
    {
        MasterBL _MasterBL = new MasterBL();
        [HttpPost]
        [Route("SaveNocDepartmentMapping")]
        public ResponseData SaveNocDepartmentMapping(NOCDEPMAP obj)
        {
            ResponseData objResponseData = new ResponseData();
            objResponseData = _MasterBL.SaveNOCDepartMapping(obj);
            if (objResponseData.statusCode == 1 || objResponseData.statusCode == 0)
            {

                objResponseData.ResponseCode = "000";

            }
            else
            {
                objResponseData.Data = null;
                objResponseData.ResponseCode = "001";

            }


            return objResponseData;

        }

        [HttpGet]
        [Route("GetNOCDepartmentsName")]
        public ResponseData GetNOCDepartmentsName(int Type)
        {
            ResponseData objResponseData = new ResponseData();
            List<Dropdown> ListRequest = new List<Dropdown>();
            ListRequest = _MasterBL.GetNOCDepartmentsName(Type);
            //string raw = JObject.FromObject(new { ListRequest }).ToString();
            //raw = EncryptDecrypt.EncryptRaw(raw);
            if (ListRequest != null)
            {
                objResponseData.Data = ListRequest; ;
                //objResponseData.Body = raw;
                objResponseData.ResponseCode = "000";
                objResponseData.Message = "Party List";
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
        [Route("GetNOCDepartMaplst")]
        public ResponseData GetNOCDepartMaplst(int Departid)
        {
            ResponseData objResponseData = new ResponseData();
            List<NOCDEPMAP> ListRequest = new List<NOCDEPMAP>();
            ListRequest = _MasterBL.GetNOCDepartMaplst(Departid);
            //string raw = JObject.FromObject(new { ListRequest }).ToString();
            //raw = EncryptDecrypt.EncryptRaw(raw);
            if (ListRequest != null)
            {
                objResponseData.Data = ListRequest; ;
                //objResponseData.Body = raw;
                objResponseData.ResponseCode = "000";
                objResponseData.Message = "Party List";
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
        [Route("InsertParameterCategoryMapping")]
        public ResponseData InsertParameterCategoryMapping(PARAMCAT Master)
        {
            ResponseData objResponseData = new ResponseData();
            objResponseData = _MasterBL.InsertParameterCategoryMapping(Master);
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
        [Route("GetPerameterCategoryList")]
        public ResponseData GetPerameterCategoryList(int Type, int Deptid, int iFk_SelfId, int EnumId)
        {
            ResponseData objResponseData = new ResponseData();
            List<Dropdown> ListRequest = new List<Dropdown>();
            ListRequest = _MasterBL.GetPerameterCategoryList(Type, Deptid, iFk_SelfId, EnumId);
            //string raw = JObject.FromObject(new { ListRequest }).ToString();
            //raw = EncryptDecrypt.EncryptRaw(raw);
            if (ListRequest != null)
            {
                objResponseData.Data = ListRequest; ;
                //objResponseData.Body = raw;
                objResponseData.ResponseCode = "000";
                objResponseData.Message = "List";
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
        [Route("GetPerameterTableList")]
        public ResponseData GetPerameterTableList(int Type, int Deptid, int iFk_SelfId, int EnumId)
        {
            ResponseData objResponseData = new ResponseData();
            List<PARAMCAT> ListRequest = new List<PARAMCAT>();
            ListRequest = _MasterBL.GetPerameterTableList(Type, Deptid, iFk_SelfId, EnumId);
            //string raw = JObject.FromObject(new { ListRequest }).ToString();
            //raw = EncryptDecrypt.EncryptRaw(raw);
            if (ListRequest != null)
            {
                objResponseData.Data = ListRequest; ;
                //objResponseData.Body = raw;
                objResponseData.ResponseCode = "000";
                objResponseData.Message = "List";
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
        [Route("GetCategorySubUOM")]
        public ResponseData GetCategorySubUOM(int Deptid, int Category, int SubCategory, string Table = "UOM")
        {
            ResponseData objResponseData = new ResponseData();
            List<Dropdown> ListRequest = new List<Dropdown>();
            ListRequest = _MasterBL.GetCategorySubUOM(Deptid, Category, SubCategory, Table);
            //string raw = JObject.FromObject(new { ListRequest }).ToString();
            //raw = EncryptDecrypt.EncryptRaw(raw);
            if (ListRequest != null)
            {
                objResponseData.Data = ListRequest; ;
                //objResponseData.Body = raw;
                objResponseData.ResponseCode = "000";
                objResponseData.Message = "List category and Sub";
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
        [Route("InsertParameterValueConfiguration")]
        public ResponseData InsertParameterValueConfiguration(PARMTVALUCONFMST Master)
        {
            ResponseData objResponseData = new ResponseData();
            objResponseData = _MasterBL.InsertParameterValueConfiguration(Master);
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
        [Route("SelectParameterValueConfiguration")]
        public ResponseData SelectParameterValueConfiguration(int Id, int EnumId, int CourseEnumId, string Appid = null)
        {
            ResponseData objResponseData = new ResponseData();
            List<PARMTVALUCONFMSTView> ListRequest = new List<PARMTVALUCONFMSTView>();
            ListRequest = _MasterBL.SelectParameterValueConfiguration(Id, EnumId, CourseEnumId, Appid);
            //string raw = JObject.FromObject(new { ListRequest }).ToString();
            //raw = EncryptDecrypt.EncryptRaw(raw);
            if (ListRequest != null)
            {
                objResponseData.Data = ListRequest; ;
                //objResponseData.Body = raw;
                objResponseData.ResponseCode = "000";
                objResponseData.Message = "List category and Sub";
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
        [Route("InsertArchitectureDetail")]
        public ResponseData InsertArchitectureDetail(ArchiMstDetail Master)
        {
            ResponseData objResponseData = new ResponseData();
            objResponseData = _MasterBL.InsertArchitectureDetail(Master);
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
        [Route("GenerateArchtable")]
        public ResponseData GenerateArchtable(int iParamId, int iSubCatId, int iUomId, string sAppId)
        {
            ResponseData objResponseData = new ResponseData();
            List<ArchiMstDetail> ListRequest = new List<ArchiMstDetail>();
            ListRequest = _MasterBL.GenerateArchtable(iParamId, iSubCatId, iUomId, sAppId);
            //string raw = JObject.FromObject(new { ListRequest }).ToString();
            //raw = EncryptDecrypt.EncryptRaw(raw);
            if (ListRequest != null)
            {
                objResponseData.Data = ListRequest; ;
                //objResponseData.Body = raw;
                objResponseData.ResponseCode = "000";
                objResponseData.Message = "List";
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
        [Route("BuildalltabelArchitecture")]
        public ResponseData BuildalltabelArchitecture(string sAppId)
        {
            ResponseData objResponseData = new ResponseData();
            List<ArchiMstDetail> ListRequest = new List<ArchiMstDetail>();
            ListRequest = _MasterBL.BuildalltabelArchitecture(sAppId);
            //string raw = JObject.FromObject(new { ListRequest }).ToString();
            //raw = EncryptDecrypt.EncryptRaw(raw);
            if (ListRequest != null)
            {
                objResponseData.Data = ListRequest; ;
                //objResponseData.Body = raw;
                objResponseData.ResponseCode = "000";
                objResponseData.Message = "List";
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
        [Route("DeleteArchiMstDet")]
        public ResponseData DeleteArchiMstDet(int Id)
        {
            ResponseData objResponseData = new ResponseData();
            objResponseData = _MasterBL.DeleteArchiMstDet(Id);
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

        [HttpPost]
        [Route("InsertArchitectureMst")]
        public ResponseData InsertArchitectureMst(ArchitectureMst Mst)
        {
            ResponseData objResponseData = new ResponseData();
            objResponseData = _MasterBL.InsertArchitectureMst(Mst);
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

        [HttpPost]
        [Route("InsertArchupload")]
        public ResponseData InsertArchupload(ArchUpload Mst)
        {
            ResponseData objResponseData = new ResponseData();
            objResponseData = _MasterBL.InsertArchupload(Mst);
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
        [Route("AllGenerateArchtable")]
        public ResponseData AllGenerateArchtable(string sAppId)
        {
            ResponseData objResponseData = new ResponseData();
            List<ArchiMstDetail> ListRequest = new List<ArchiMstDetail>();
            ListRequest = _MasterBL.AllGenerateArchtable(sAppId);
            //string raw = JObject.FromObject(new { ListRequest }).ToString();
            //raw = EncryptDecrypt.EncryptRaw(raw);
            if (ListRequest != null)
            {
                objResponseData.Data = ListRequest; ;
                //objResponseData.Body = raw;
                objResponseData.ResponseCode = "000";
                objResponseData.Message = "List";
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
        [Route("UploadReceipt")]
        public ResponseData UploadReceipt(UploadReceipt receipt)
        {
            ResponseData objResponseData = new ResponseData();
            objResponseData = _MasterBL.UploadReceipt(receipt);
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
        [Route("GetFinYearList")]
        public ResponseData GetFinYearList()
        {
            ResponseData objResponseData = new ResponseData();
            objResponseData = _MasterBL.GetFinYearList();
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

        [HttpPost]
        [Route("InsertFinYear")]
        public ResponseData InsertFinYear(FinYear obj)
        {
            ResponseData objResponseData = new ResponseData();
            objResponseData = _MasterBL.InsertFinYear(obj);
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
        [Route("Event_View")]
        public ResponseData Event_View(int iFk_DeptId)
        {
            ResponseData objResponseData = new ResponseData();
            List<EVNTMST> ListRequest = new List<EVNTMST>();
            ListRequest = _MasterBL.Event_View(iFk_DeptId);
            //string raw = JObject.FromObject(new { ListRequest }).ToString();
            //raw = EncryptDecrypt.EncryptRaw(raw);
            if (ListRequest != null)
            {
                objResponseData.Data = ListRequest; ;
                //objResponseData.Body = raw;
                objResponseData.ResponseCode = "000";
                objResponseData.Message = "List";
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
        [Route("FillDropDown")]
        public ResponseData FillDropDown(int Id, string Type, string PartyId = null)
        {
            ResponseData objResponseData = new ResponseData();
            List<Dropdown> ListRequest = new List<Dropdown>();
            ListRequest = _MasterBL.FillDropDown(Id, Type, PartyId);
            //string raw = JObject.FromObject(new { ListRequest }).ToString();
            //raw = EncryptDecrypt.EncryptRaw(raw);
            if (ListRequest != null)
            {
                objResponseData.Data = ListRequest; ;
                //objResponseData.Body = raw;
                objResponseData.ResponseCode = "000";
                objResponseData.Message = "List";
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
        [Route("AllCommiteeSaveView")]
        public ResponseData AllCommiteeSaveView(CommiteeMaster Mst)
        {
            ResponseData objResponseData = new ResponseData();
            objResponseData = _MasterBL.InsertCommiteeMster(Mst);
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

        [HttpPost]
        [Route("InsertEvent")]
        public ResponseData InsertEvent(EventMstSave Mst)
        {
            ResponseData objResponseData = new ResponseData();
            objResponseData = _MasterBL.InsertEvent(Mst);

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
        [Route("GetCommiteeList")]
        public ResponseData GetCommiteeList(int Id)
        {
            ResponseData objResponseData = new ResponseData();
            List<CommiteeMaster> ListRequest = new List<CommiteeMaster>();
            ListRequest = _MasterBL.GetCommiteeList(Id);
            //string raw = JObject.FromObject(new { ListRequest }).ToString();
            //raw = EncryptDecrypt.EncryptRaw(raw);
            if (ListRequest != null)
            {
                objResponseData.Data = ListRequest; ;
                //objResponseData.Body = raw;
                objResponseData.ResponseCode = "000";
                objResponseData.Message = "Party List";
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
        [Route("GetCommentTable")]
        public ResponseData GetCommentTable(InspectionComments Master)
        {
            ResponseData objResponseData = new ResponseData();
            List<CommitedMstview> ListRequest = new List<CommitedMstview>();
            ListRequest = _MasterBL.GetCommentTable(Master);
            //string raw = JObject.FromObject(new { ListRequest }).ToString();
            //raw = EncryptDecrypt.EncryptRaw(raw);
            if (ListRequest != null)
            {
                objResponseData.Data = ListRequest; ;
                //objResponseData.Body = raw;
                objResponseData.ResponseCode = "000";
                objResponseData.Message = "Party List";
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
        [Route("SaveComment")]
        public ResponseData SaveComment(InspectionComments Master)
        {
            ResponseData objResponseData = new ResponseData();
            objResponseData = _MasterBL.SaveComment(Master);
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
        [Route("GetApplicationData")]
        public ResponseData GetApplicationData(int Deptid, int ApplicationId ,int NOCDeptId)
        {
            ResponseData objResponseData = new ResponseData();
            List<Dropdown> ListRequest = new List<Dropdown>();
            ListRequest = _MasterBL.GetApplicationData(Deptid, ApplicationId, NOCDeptId);
            //string raw = JObject.FromObject(new { ListRequest }).ToString();
            //raw = EncryptDecrypt.EncryptRaw(raw);
            if (ListRequest != null)
            {
                objResponseData.Data = ListRequest; ;
                //objResponseData.Body = raw;
                objResponseData.ResponseCode = "000";
                objResponseData.Message = "List category and Sub";
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
        [Route("InsertFee")]
        public ResponseData InsertFee(CompleteFeeMaster Mst)
        {
            ResponseData objResponseData = new ResponseData();
            objResponseData = _MasterBL.InsertFee(Mst);
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

        [HttpPost]
        [Route("AddTrackingData")]
        public ResponseData AddTrackingData(TrackingData track)
        {
            ResponseData objResponseData = new ResponseData();
            objResponseData = _MasterBL.AddTrackingData(track);
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

        //Added For Saving the Darft application by Vivek 10.02.2023
        #region Save Department Master data
        [HttpPost]
        [Route("AddDeptMSTAppData")]
        public ResponseData AddDeptMSTAppData(List<TrusteeBO.DeptMasterApp> deptMasters)
        {
            ResponseData objResponseData = new ResponseData();
            objResponseData = _MasterBL.AddDeptMSTAppData(deptMasters);
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


        [HttpPost]
        [Route("AddDeptMSTAppDataNewCollege")]
        public ResponseData AddDeptMSTAppDataNewCollege(int clgID, string clgName, string appType)
        {
            ResponseData objResponseData = new ResponseData();
            objResponseData = _MasterBL.AddDeptMSTAppDataNewCollege(clgID, clgName, appType);
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
        [Route("GetApplicationCourse")]
        public ResponseData GetApplicationCourse(string AppGuid, int Courseid = 0)
        {
            ResponseData objResponseData = new ResponseData();
            List<CourserBind> ListRequest = new List<CourserBind>();
            ListRequest = _MasterBL.GetApplicationCourse(AppGuid, Courseid);
            //string raw = JObject.FromObject(new { ListRequest }).ToString();
            //raw = EncryptDecrypt.EncryptRaw(raw);
            if (ListRequest != null)
            {
                objResponseData.Data = ListRequest; ;
                //objResponseData.Body = raw;
                objResponseData.ResponseCode = "000";
                objResponseData.Message = "List Course and Subject";
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
        [Route("GetNewCollegeDetails")]
        public ResponseData GetNewCollegeDetails(int clgID)
        {
            ResponseData objResponseData = new ResponseData();
            objResponseData = _MasterBL.GetNewCollegeDetails(clgID);
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
        [Route("GetOtherBind")]
        public ResponseData GetOtherBind(string AppGuid)
        {
            ResponseData objResponseData = new ResponseData();
            List<CourserBind> ListRequest = new List<CourserBind>();
            ListRequest = _MasterBL.GetOtherBind(AppGuid);
            //string raw = JObject.FromObject(new { ListRequest }).ToString();
            //raw = EncryptDecrypt.EncryptRaw(raw);
            if (ListRequest != null)
            {
                objResponseData.Data = ListRequest; ;
                //objResponseData.Body = raw;
                objResponseData.ResponseCode = "000";
                objResponseData.Message = "List Course and Subject";
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

        [Route("UploadMasterPaymentReceipt")]
        public ResponseData UploadMasterPaymentReceipt(UploadMasterReceipt receipt)
        {
            ResponseData objResponseData = new ResponseData();
            objResponseData = _MasterBL.UploadMasterPaymentReceipt(receipt);
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
        #endregion

        #region abhishek(03/03/2023)
        [HttpGet]
        [Route("GetFeeMstList")]
        public ResponseData GetFeeMstList(int Id)
        {
            ResponseData objResponseData = new ResponseData();
            List<FeeMst> ListRequest = new List<FeeMst>();
            ListRequest = _MasterBL.GetFeeMstList(Id);
            //string raw = JObject.FromObject(new { ListRequest }).ToString();
            //raw = EncryptDecrypt.EncryptRaw(raw);
            if (ListRequest != null)
            {
                objResponseData.Data = ListRequest; ;
                //objResponseData.Body = raw;
                objResponseData.ResponseCode = "000";
                objResponseData.Message = "List FeeMster List";
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
        [Route("GetFeeTRNList")]
        public ResponseData GetFeeTRNList(int Id)
        {
            ResponseData objResponseData = new ResponseData();
            List<FeeTRN> ListRequest = new List<FeeTRN>();
            ListRequest = _MasterBL.GetFeeTRNList(Id);
            //string raw = JObject.FromObject(new { ListRequest }).ToString();
            //raw = EncryptDecrypt.EncryptRaw(raw);
            if (ListRequest != null)
            {
                objResponseData.Data = ListRequest; ;
                //objResponseData.Body = raw;
                objResponseData.ResponseCode = "000";
                objResponseData.Message = "List FeeTRN List";
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
    }
}
