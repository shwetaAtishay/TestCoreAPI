using Microsoft.AspNetCore.Mvc;
using static TestCoreAPI.Controllers.User;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime;
using System.Security.Cryptography;
using System.Text.Json.Serialization;
using System;
using BL;
using BO.Models;
using Newtonsoft.Json;
using RestSharp;
using static BO.Models.Partial;
using TestCoreAPI.Helper;
using Microsoft.AspNetCore.Cors;
using DL;

namespace TestCoreAPI.Controllers
{
        //[EnableCors("ApiCorsPolicy")]
        [ApiController]
        [Route("[controller]")]
        public class User : Controller
        {
          UserBL objAdminBL = new UserBL();
       
        #region vivek
        GetSettings jWT = new GetSettings();
        //LogWriter obj = new LogWriter("");
        [HttpPost]
        [Route("Login")]
        public ResponseData Login(Login login)
        {
            var objResponseData = objAdminBL.Login(login);

            if (objResponseData.Data != null)
            {
                var objModel = JsonConvert.DeserializeObject<UserModelSession>(objResponseData.Data.NulllToString());

                var jwtstring = jWT.JWT_GetToken(objModel.Username);

                objResponseData.JWT = jwtstring;
            }
            return objResponseData;

        }
        [HttpPost]
        [Route("Reset")]
        public ResponseData Reset(ResetPassword reset)
        {
            var objResponseData = objAdminBL.ResetPassword(reset);
            return objResponseData;
        }

        #endregion
        #region get details
        [HttpGet]
        [Route("GetServicesDetails")]
        public ResponseData GetServicesDetails()
        {
            var objResponseData = objAdminBL.GetServicesDetails();
            return objResponseData;
        }
        #endregion
        #region Pravin Pawar
        [HttpPost]
        [Route("GetDept")]
        public ResponseData GetDept()
        {
            try
            {
                var objResponseData = objAdminBL.GetDept();
                return objResponseData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        [Route("GetCourses")]
        public ResponseData GetCourses(int Id)
        {
            try
            {
                var objResponseData = objAdminBL.GetCourses(Id);
                return objResponseData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        [Route("SaveDeptCourseMap")]
        public ResponseData SaveDeptCourseMap(DeptCourseMap Map)
        {
            try
            {
                var objResponseData = objAdminBL.SaveDeptCourseMap(Map);
                return objResponseData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        [Route("GetDeptMappingData")]
        public ResponseData GetDeptMappingData()
        {
            try
            {
                var objResponseData = objAdminBL.GetDeptMappingData();
                return objResponseData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //For Academic Master
        [HttpPost]
        [Route("GetYear")]
        public ResponseData GetYear()
        {
            try
            {
                var objResponseData = objAdminBL.GetYear();
                return objResponseData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        [Route("GetResult")]
        public ResponseData GetResult()
        {
            try
            {
                var objResponseData = objAdminBL.GetResult();
                return objResponseData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("SaveAcdmcMst")]
        public ResponseData SaveAcdmcMst(AcdmcMst Map)
        {
            try
            {
                var objResponseData = objAdminBL.SaveAcdmcMst(Map);
                return objResponseData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("GetAcdmcData")]
        public ResponseData GetAcdmcData(string GUIID, int clgID)
        {
            try
            {
                var objResponseData = objAdminBL.GetAcdmcData(GUIID,clgID);
                return objResponseData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("GetModule")]
        public ResponseData GetModule()
        {
            var objResponseData = objAdminBL.GetModule();
            return objResponseData;
        }

        [HttpPost]
        [Route("GetFunctionality")]
        public ResponseData GetFunctionality()
        {
            var objResponseData = objAdminBL.GetFunctionality();
            return objResponseData;
        }

        [HttpPost]
        [Route("SaveSupportTicket")]
        public ResponseData SaveSupportTicket(SupportTicket Ticket)
        {
            var objResponseData = objAdminBL.SaveSupportTicket(Ticket);
            return objResponseData;
        }

        [HttpPost]
        [Route("GetSubjects")]
        public ResponseData GetSubjects()
        {
            try
            {
                var objResponseData = objAdminBL.GetSubjects();
                return objResponseData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        [Route("GetUniversities")]
        public ResponseData GetUniversities()
        {
            try
            {
                var objResponseData = objAdminBL.GetUniversities();
                return objResponseData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpPost]
        [Route("SaveUniversitesDeptMap")]
        public ResponseData SaveUniversitesDeptMap(UniversitiesDept Map)
        {
            try
            {
                var objResponseData = objAdminBL.SaveUniversitesDeptMap(Map);
                return objResponseData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpPost]
        [Route("GetUniversitiesData")]
        public ResponseData GetUniversitiesData()
        {
            try
            {
                var objResponseData = objAdminBL.GetUniversitiesData();
                return objResponseData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion
        #region sso
        [HttpPost]
        [Route("AddUpdateSSO")]
        public ResponseData AddUpdateSSO(SSOUserDetail userDetail)
        {
            try
            {
                var objResponseData = objAdminBL.AddUpdateSSO(userDetail);
                return objResponseData;
            }
            catch (Exception ex)
            {
                LogWriter.LogWrite(ex.Message);
                throw ex;
            }
        }

        [HttpPost]
        [Route("GetPermissionDetails")]
        public ResponseData GetPermissionDetails(int RoleId, int DepartmentId)
        {
            try
            {
                var objResponseData = objAdminBL.GetPermissionDetails(RoleId, DepartmentId);
                return objResponseData;
            }
            catch (Exception ex)
            {
                LogWriter.LogWrite(ex.Message);
                throw ex;
            }
        }
        #endregion

        [HttpPost]
        [Route("GetGeoGraphicalData")]
        public ResponseData GetGeoGraphicalData(GeoLocationMaster graphical)
        {
            try
            {
                var objResponseData = objAdminBL.GetGeoGraphicalData(graphical);
                return objResponseData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("GetData")]
        public ResponseData GetMenusAndSubmenus(string Type, string MenuId, string PartyId = null)
        {
            try
            {
                var objResponseData = objAdminBL.GetMenusAndSubmenus(Type, MenuId, PartyId);
                return objResponseData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("AddDepartment")]
        public ResponseData AddDepartment(AddDepartment department)
        {
            try
            {
                var objResponseData = objAdminBL.AddDepartment(department);
                return objResponseData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("AddSystemUserDetails")]
        public ResponseData AddSystemUserDetails(PartyMaster party)
        {
            try
            {
                var objResponseData = objAdminBL.AddSystemUserDetails(party);
                return objResponseData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("AddGroup")]
        public ResponseData AddGroup(AddGroup group)
        {
            try
            {
                var objResponseData = objAdminBL.AddGroup(group);
                return objResponseData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        [HttpPost]
        [Route("GetACDMCDataEdit")]
        public ResponseData GetACDMCDataEdit(int AcdmcId)
        {
            try
            {
                var objResponseData = objAdminBL.GetACDMCDataEdit(AcdmcId);
                return objResponseData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("GetACDMCDataDelete")]
        public ResponseData GetACDMCDataDelete(int AcdmcId)
        {
            try
            {
                var objResponseData = objAdminBL.GetACDMCDataDelete(AcdmcId);
                return objResponseData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }

}
