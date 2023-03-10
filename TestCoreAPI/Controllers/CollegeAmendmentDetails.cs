using BL;
using BO.Models;
using DL;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace TestCoreAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CollegeAmendmentDetails : Controller
    {
        UploadDocumentBL ObjRate = new UploadDocumentBL();

        [HttpPost]
        [Route("UploadDoc")]
        public ResponseData UploadDoc(AmendmentBO obj)
        {
            ResponseData objResponseData = new ResponseData();
            objResponseData = ObjRate.UploadDocDetails(obj);
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
        [Route("UploadNameCollege")]
        public ResponseData UploadNameCollege(AmendmentBO obj)
        {
            ResponseData objResponseData = new ResponseData();
            objResponseData = ObjRate.UploadNameCollege(obj);
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
        [Route("ManagmentDocDetails")]
        public ResponseData ManagmentDocDetails(AmendmentBO obj)
        {
            ResponseData objResponseData = new ResponseData();
            objResponseData = ObjRate.ManagmentDocDetails(obj);
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
        [Route("MergerDocPlace")]
        public ResponseData MergerDocPlace(AmendmentBO obj)
        {
            ResponseData objResponseData = new ResponseData();
            objResponseData = ObjRate.MergerDocPlaceInfo(obj);
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
        [Route("MergerDocDetails")]
        public ResponseData MergerDocDetails(AmendmentBO obj)
        {
            ResponseData objResponseData = new ResponseData();
            objResponseData = ObjRate.MergerDocDetails(obj);
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

        #region Co-education
        [HttpGet]
        [Route("AmdList")]
        public List<AmendmentBO> AmdList(int idclgID)
        {
            return ObjRate.AmdList(idclgID);
        }
        //NameOfCollege
        [HttpGet]
        [Route("NameCollegeList")]
        public List<AmendmentBO> NameCollegeList(int idclgID)
        {
            return ObjRate.NameCollegeList(idclgID);
        }
        //College Place Chnage
        [HttpGet]
        [Route("CollegePlaceList")]
        public List<AmendmentBO> CollegePlaceList(int idclgID)
        {
            return ObjRate.CollegePlaceList(idclgID);
        }
        //ManagementCollegeDetail
        [HttpGet]
        [Route("ManagementCollegeList")]
        public List<AmendmentBO> ManagementCollegeList(int idclgID)
        {
            return ObjRate.ManagementCollegeList(idclgID);
        }
        //MergerDetails information
        [HttpGet]
        [Route("MergerDetailsList")]
        public List<AmendmentBO> MergerDetailsList(int idclgID)
        {
            return ObjRate.MergerDetailsList(idclgID);
        }
        #endregion

        #region Woman DocDownload
        [HttpPost]
        [Route("DocumentDetail")]
        public AmendmentBO DocumentDetail(int id)
        {
            //TrusteeBO.Trustee _result = new TrusteeBO.Trustee();
            return ObjRate.DocumentDetail(id);
        }
        //NameofCollege
        [HttpPost]
        [Route("NameCollegeDetail")]
        public AmendmentBO NameCollegeDetail(int id)
        {
            //TrusteeBO.Trustee _result = new TrusteeBO.Trustee();
            return ObjRate.CollegeDetail(id);
        }
        //NameofCollege
        [HttpPost]
        [Route("CollegePlaceChnageDetail")]
        public AmendmentBO CollegePlaceChnageDetail(int id)
        {
            //TrusteeBO.Trustee _result = new TrusteeBO.Trustee();
            return ObjRate.CollegePlaceChnageDetail(id);
        }
        //Change in College Management
        [HttpPost]
        [Route("ManagementCollegeDetail")]
        public AmendmentBO ManagementCollegeDetail(int id)
        {
            return ObjRate.ManagementCollegeDetail(id);
        }
        //Merger College 
        [HttpPost]
        [Route("MergerApplicantDetail")]
        public AmendmentBO MergerApplicantDetail(int id)
        {
            return ObjRate.MergerApplicantDetail(id);
        }
        #endregion

        #region updateDoc

        [HttpPost]
        [Route("UpdateDocDetail")]
        public ResponseData UpdateDocDetail(AmendmentBO obj)
        {
            return ObjRate.DeleteApplicantDetail(obj);
        }
        #endregion
    }
}
