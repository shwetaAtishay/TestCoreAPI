using BL;
using BO;
using BO.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace TestCoreAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BasicDataDetails : Controller
    {

        BasicDetailsBL ObjRate = new BasicDetailsBL();

        [HttpPost]
        [Route("BasicDetailConfigure")]
        public ResponseData BasicDetailConfigure(BasicDetails obj)
        {
            ResponseData objResponseData = new ResponseData();
            objResponseData = ObjRate.BasicDetailConfigure(obj);
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
        [Route("GetCollageDropDownList")]
        public ResponseData GetCollageDropDownList(int TrustInfoId)
        {
            return ObjRate.GetCollageDropDownList(TrustInfoId);
        }

        [HttpGet]
        [Route("GetAdminApplication")]
        public ResponseData GetAdminApplication(string applGUID)
        {
            return ObjRate.GetAdminApplication(applGUID);
        }

        [HttpGet]
        [Route("GetDarftApplications")]
        public ResponseData GetDarftApplications(string applGUID, string trustID)
        {
            return ObjRate.GetDarftApplications(applGUID,trustID);
        }

        [HttpGet]
        [Route("GetApplicationsToUploadReceipt")]
        public ResponseData GetApplicationsToUploadReceipt(string applGUID)
        {
            return ObjRate.GetApplicationsToUploadReceipt(applGUID);
        }

        [HttpGet]
        [Route("CancleDarftApplications")]
        public ResponseData CancleDarftApplications(string applGUID, string Creason)
        {
            return ObjRate.CancleDarftApplications(applGUID,Creason);
        }

        [HttpGet]
        [Route("GetCollageDetails")]
        public BasicDetails GetCollageDetails(int Id)
        {
            return ObjRate.GetCollageDetails(Id);
        }

        [HttpPost]
        [Route("UpdateCollageDetails")]
        public ResponseData UpdateCollageDetails(BasicDetails obj)
        {
            ResponseData objResponseData = new ResponseData();
            objResponseData = ObjRate.UpdateCollageDetails(obj);
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

        //Report Details
        [HttpGet]
        [Route("GetReportApplication")]
        public ResponseData GetReportApplication(string applGUID)
        {
            return ObjRate.GetReportApplication(applGUID);
        }
        //Application tracking
        [HttpGet]
        [Route("GetApplicationtracking")]
        public ResponseData GetApplicationtracking(string applGUID)
        {
            return ObjRate.GetApplicationtracking(applGUID);
        }

        [HttpGet]
        [Route("DepartmentapplicationList")]
        public ResponseData DepartmentapplicationList(string applGUID)
        {
            return ObjRate.DepartmentapplicationList(applGUID);
        }
        [HttpGet]
        [Route("GetSUbject")]
        public ResponseData GetSUbject(int colId, int couId, string DataType, string subjectlist = null)
        {
            return ObjRate.GetSUbject(colId, couId, DataType, subjectlist);
        }
        [HttpGet]
        [Route("GetCollageDropDownListbytrustId")]
        public ResponseData GetCollageDropDownListbytrustId(int Id, string trustid)
        {
            return ObjRate.GetCollageDropDownListbytrustId(Id, trustid);
        }
    }
}
