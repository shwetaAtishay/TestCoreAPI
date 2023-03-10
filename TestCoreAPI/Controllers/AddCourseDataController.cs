using BL;
using BO;
using BO.Models;
using DL;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;
using System;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography;

namespace TestCoreAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddCourseDataController : Controller
    {
        CourseDetailsBL ObjCourse = new CourseDetailsBL();
        [HttpPost]
        [Route("CourseDetailConfigure")]
        public ResponseData CourseDetailConfigure(AddCourseBO obj)
        {
            ResponseData objResponseData = new ResponseData();
            objResponseData = ObjCourse.AddCourseDetail(obj);
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
        [Route("GetDetails")]
        public List<AddCourseBO> GetDetails(string TrustId)
        {
            return ObjCourse.ListAddCourse(TrustId);
        }

        [HttpPost]
        [Route("SubjectDetail")]
        public ResponseData SubjectDetail(AddCourseBO obj)
        {
            ResponseData objResponseData = new ResponseData();
            objResponseData = ObjCourse.SubjectNameDetail(obj);
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
        //For Page List of Subject
        [HttpGet]
        [Route("GetSubjectPageList")]
        public ResponseData GetSubjectPageList(string Guid)
        {
            ResponseData objResponseData = new ResponseData();
            List<AddCourseBO> ListRequest = new List<AddCourseBO>();
            ListRequest = ObjCourse.SubjectDetails(Guid);
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
        //For Grid
        [HttpGet]
        [Route("GetSubjectList")]
        public ResponseData GetSubjectList(string Guid)
        {
            ResponseData objResponseData = new ResponseData();
            List<AddCourseBO> ListRequest = new List<AddCourseBO>();
            ListRequest = ObjCourse.ListSubjectDetails(Guid);
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
        //By ID subject list
        [HttpGet]
        [Route("GetSubjectListById")]
        public ResponseData GetSubjectListById(string type, int iPK_SubId, string SubjectName)
        {
            var objResponseData = new ResponseData();
            var addCourseBOs = ObjCourse.ListSubjects(type, iPK_SubId, SubjectName);
            objResponseData.statusCode = 1;
            objResponseData.Message = $"{type} Course Data";
            objResponseData.Data = addCourseBOs;


            return objResponseData;
        }

        [HttpGet]
        [Route("GetCollegeList")]
        public List<CustomEnum> GetCollegeList()
        {
            return ObjCourse.ListCollegeDetails();

        }
        [HttpPost]
        [Route("ExistingNOCGetSubjectList")]
        public List<AddCourseBO> ExistingNOCGetSubjectList(ExistingNOCRequest obj)
        {
            return ObjCourse.ExistingNOCGetSubjectList(obj);
        }
        [HttpGet]
        [Route("GetSubjectCourse")]
        public List<CustomEnum> GetSubjectCourse(int id)
        {
            return ObjCourse.GetSubject(id);
        }


    }
}
