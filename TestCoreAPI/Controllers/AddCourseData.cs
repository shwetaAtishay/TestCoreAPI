using BL;
using BO;
using BO.Models;
using DL;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;
using System;

namespace TestCoreAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddCourseDat : Controller
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

        // Added by Anil 
        [HttpGet]
        [Route("GetEdit")]
        public ResponseData GetEdit(int id)
        {
            var objResponseData = new ResponseData();
            var EditourseBOs = ObjCourse.ListEditCourse(id);
            objResponseData.statusCode = 1;
            objResponseData.Data = EditourseBOs;
            return objResponseData;
            //return ObjCourse.ListEditCourse(id);
        }
        [HttpGet]
        [Route("DeleteCourse")]
        public ResponseData DeleteCourse(int id)
        {
            var objResponseData = new ResponseData();
            var DeleteCourseBOs = ObjCourse.ListDeleteCourse(id);
            objResponseData.statusCode = 1;
            objResponseData.Data = DeleteCourseBOs;
            return objResponseData;
        }
        [HttpPost]
        [Route("UpdateEditDetails")]
        public ResponseData UpdateEditDetails(AddCourseBO obj)
        {
            ResponseData objResponseData = new ResponseData();
            objResponseData = ObjCourse.ListEditUpdate(obj);
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
