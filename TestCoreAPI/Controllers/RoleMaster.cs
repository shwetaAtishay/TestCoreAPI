using BL;
using BO;
using BO.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BO.Models.Partial;

namespace TestCoreAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoleMaster : Controller
    {
        RoleMasterBL RoleBL = new RoleMasterBL();
        [HttpPost]
        [Route("InsertMenuMaster")]
        public ResponseData InsertMenuMaster(MenuMasters obj)
        {
            ResponseData objResponseData = new ResponseData();
            objResponseData = RoleBL.InsertMenuMaster(obj);
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
        [Route("InsertSubMenuMaster")]
        public ResponseData InsertSubMenuMaster(SubMenuMaster obj)
        {
            ResponseData objResponseData = new ResponseData();
            objResponseData = RoleBL.InsertSubMenuMaster(obj);
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
        [Route("GetMenuMaster")]
        public ResponseData GetMenuMaster(int Id)
        {
            ResponseData objResponseData = new ResponseData();
            MenuMasters ListRequest = new MenuMasters();
            ListRequest = RoleBL.GetMenuMaster(Id);
            //string raw = JObject.FromObject(new { ListRequest }).ToString();
            //raw = EncryptDecrypt.EncryptRaw(raw);
            if (ListRequest != null)
            {
                objResponseData.Data = ListRequest;
                //objResponseData.Body = raw;
                objResponseData.ResponseCode = "000";
                objResponseData.Message = "Menu Data";
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
        [Route("GetMenuMasterList")]
        public ResponseData GetMenuMasterList()
        {
            ResponseData objResponseData = new ResponseData();
            List<MenuMasters> ListRequest = new List<MenuMasters>();
            ListRequest = RoleBL.GetMenuMasterList();
            //string raw = JObject.FromObject(new { ListRequest }).ToString();
            //raw = EncryptDecrypt.EncryptRaw(raw);
            if (ListRequest != null)
            {
                objResponseData.Data = ListRequest;
                //objResponseData.Body = raw;
                objResponseData.ResponseCode = "000";
                objResponseData.Message = "Menu Data list";
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
        [Route("GetSubMenuMaster")]
        public ResponseData GetSubMenuMaster(int Id)
        {
            ResponseData objResponseData = new ResponseData();
            SubMenuMaster ListRequest = new SubMenuMaster();
            ListRequest = RoleBL.GetSubMenuMaster(Id);
            //string raw = JObject.FromObject(new { ListRequest }).ToString();
            //raw = EncryptDecrypt.EncryptRaw(raw);
            if (ListRequest != null)
            {
                objResponseData.Data = ListRequest;
                //objResponseData.Body = raw;
                objResponseData.ResponseCode = "000";
                objResponseData.Message = "Sub Menu Data";
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
        [Route("GetSubMenuMasterList")]
        public ResponseData GetSubMenuMasterList()
        {
            ResponseData objResponseData = new ResponseData();
            List<SubMenuMaster> ListRequest = new List<SubMenuMaster>();
            ListRequest = RoleBL.GetSubMenuMasterList();
            //string raw = JObject.FromObject(new { ListRequest }).ToString();
            //raw = EncryptDecrypt.EncryptRaw(raw);
            if (ListRequest != null)
            {
                objResponseData.Data = ListRequest;
                //objResponseData.Body = raw;
                objResponseData.ResponseCode = "000";
                objResponseData.Message = "Sub Menu Data list";
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
        [Route("FillDepartmentandGroup")]
        public ResponseData FillDepartmentandGroup(int Id)
        {
            ResponseData objResponseData = new ResponseData();
            List<CustomList> ListRequest = new List<CustomList>();
            ListRequest = RoleBL.FillDepartmentandGroup(Id);
            //string raw = JObject.FromObject(new { ListRequest }).ToString();
            //raw = EncryptDecrypt.EncryptRaw(raw);
            if (ListRequest != null)
            {
                objResponseData.Data = ListRequest;
                //objResponseData.Body = raw;
                objResponseData.ResponseCode = "000";
                objResponseData.Message = "Department and Group list";
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
        [Route("FillDepartmentandGroupMaster")]
        public ResponseData FillDepartmentandGroupaMaster(string Type, string PartyId = null)
        {
            ResponseData objResponseData = new ResponseData();
            List<CustomList> ListRequest = new List<CustomList>();
            ListRequest = RoleBL.FillDepartmentandGroupMaster(Type, PartyId);
            //string raw = JObject.FromObject(new { ListRequest }).ToString();
            //raw = EncryptDecrypt.EncryptRaw(raw);
            if (ListRequest != null)
            {
                objResponseData.Data = ListRequest;
                //objResponseData.Body = raw;
                objResponseData.ResponseCode = "000";
                objResponseData.Message = "Department and Group list";
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
        [Route("GetSubMenu")]
        public ResponseData GetSubMenu(int Id)
        {
            ResponseData objResponseData = new ResponseData();
            List<CustomList> ListRequest = new List<CustomList>();
            ListRequest = RoleBL.GetSubMenu(Id);
            //string raw = JObject.FromObject(new { ListRequest }).ToString();
            //raw = EncryptDecrypt.EncryptRaw(raw);
            if (ListRequest != null)
            {
                objResponseData.Data = ListRequest;
                //objResponseData.Body = raw;
                objResponseData.ResponseCode = "000";
                objResponseData.Message = "Get Sub Menu list";
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
        [Route("InsertRoleInformation")]
        public ResponseData InsertRoleInformation(RoleInformation obj)
        {
            ResponseData objResponseData = new ResponseData();
            objResponseData = RoleBL.InsertRoleInformation(obj);
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
        [Route("InsertRoleMappingwithMenu")]
        public ResponseData InsertRoleMappingwithMenu(RoleMappingwithMenu obj)
        {
            ResponseData objResponseData = new ResponseData();
            objResponseData = RoleBL.InsertRoleMappingwithMenu(obj);
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
        [Route("GetRoleInformation")]
        public ResponseData GetRoleInformation()
        {
            ResponseData objResponseData = new ResponseData();
            List<RoleInformation> ListRequest = new List<RoleInformation>();
            ListRequest = RoleBL.GetRoleInformation();
            //string raw = JObject.FromObject(new { ListRequest }).ToString();
            //raw = EncryptDecrypt.EncryptRaw(raw);
            if (ListRequest != null)
            {
                objResponseData.Data = ListRequest;
                //objResponseData.Body = raw;
                objResponseData.ResponseCode = "000";
                objResponseData.Message = "Role list";
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
        [Route("GetSelectRoleInformation")]
        public ResponseData GetSelectRoleInformation(int Id)
        {
            ResponseData objResponseData = new ResponseData();
            RoleInformation ListRequest = new RoleInformation();
            ListRequest = RoleBL.GetSelectRoleInformation(Id);
            //string raw = JObject.FromObject(new { ListRequest }).ToString();
            //raw = EncryptDecrypt.EncryptRaw(raw);
            if (ListRequest != null)
            {
                objResponseData.Data = ListRequest;
                //objResponseData.Body = raw;
                objResponseData.ResponseCode = "000";
                objResponseData.Message = "Role list";
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
        [Route("GetSelectRoleWithMenu")]
        public ResponseData GetSelectRoleWithMenu(int Id)
        {
            ResponseData objResponseData = new ResponseData();
            RoleMappingwithMenu ListRequest = new RoleMappingwithMenu();
            ListRequest = RoleBL.GetSelectRoleWithMenu(Id);
            //string raw = JObject.FromObject(new { ListRequest }).ToString();
            //raw = EncryptDecrypt.EncryptRaw(raw);
            if (ListRequest != null)
            {
                objResponseData.Data = ListRequest;
                //objResponseData.Body = raw;
                objResponseData.ResponseCode = "000";
                objResponseData.Message = "Role Mapping with menu";
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
        [Route("FillDepartmentandGroupwithRole")]
        public ResponseData FillDepartmentandGroupwithRole(int DepartmentId, int GroupId)
        {
            ResponseData objResponseData = new ResponseData();
            List<CustomList> ListRequest = new List<CustomList>();
            ListRequest = RoleBL.FillDepartmentandGroupwithRole(DepartmentId, GroupId);
            //string raw = JObject.FromObject(new { ListRequest }).ToString();
            //raw = EncryptDecrypt.EncryptRaw(raw);
            if (ListRequest != null)
            {
                objResponseData.Data = ListRequest;
                //objResponseData.Body = raw;
                objResponseData.ResponseCode = "000";
                objResponseData.Message = "Department and Group list";
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
        [Route("GetRoleMappingMenuList")]
        public ResponseData GetRoleMappingMenuList()
        {
            ResponseData objResponseData = new ResponseData();
            List<RoleMappingwithMenu> ListRequest = new List<RoleMappingwithMenu>();
            ListRequest = RoleBL.GetRoleMappingMenuList();
            //string raw = JObject.FromObject(new { ListRequest }).ToString();
            //raw = EncryptDecrypt.EncryptRaw(raw);
            if (ListRequest != null)
            {
                objResponseData.Data = ListRequest;
                //objResponseData.Body = raw;
                objResponseData.ResponseCode = "000";
                objResponseData.Message = "Role Mapping Menu list";
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
        [Route("InsertRoleMappingwithSubMenu")]
        public ResponseData InsertRoleMappingwithSubMenu(MenuMappingwithSubmenu obj)
        {
            ResponseData objResponseData = new ResponseData();
            objResponseData = RoleBL.InsertRoleMappingwithSubMenu(obj);
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
        [Route("GetMappingRoleWithSubMenu")]
        public ResponseData GetMappingRoleWithSubMenu(int Id)
        {
            ResponseData objResponseData = new ResponseData();
            List<MenuMappingwithSubmenu> ListRequest = new List<MenuMappingwithSubmenu>();
            ListRequest = RoleBL.GetMappingSubMenuMasterList(Id);
            //string raw = JObject.FromObject(new { ListRequest }).ToString();
            //raw = EncryptDecrypt.EncryptRaw(raw);
            if (ListRequest != null)
            {
                objResponseData.Data = ListRequest;
                //objResponseData.Body = raw;
                objResponseData.ResponseCode = "000";
                objResponseData.Message = "Role Mapping Sub Menu list";
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
        [Route("OperationStatus")]
        public ResponseData OperationStatus(Permissionclass master)
        {
            ResponseData objResponseData = new ResponseData();
            objResponseData = RoleBL.OperationStatus(master);
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
        [Route("InsertRoleMasterCreate")]
        public ResponseData InsertRoleMasterCreate(RoleMastertable master)
        {
            ResponseData objResponseData = new ResponseData();
            objResponseData = RoleBL.InsertRoleMasterCreate(master);
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
        [Route("GetRoleMasterInformation")]
        public ResponseData GetRoleMasterInformation(int Id = 0, string PartyId = null)
        {
            ResponseData objResponseData = new ResponseData();
            List<RoleMastertable> ListRequest = new List<RoleMastertable>();
            ListRequest = RoleBL.GetRoleMasterInformation(Id, PartyId);
            //string raw = JObject.FromObject(new { ListRequest }).ToString();
            //raw = EncryptDecrypt.EncryptRaw(raw);
            if (ListRequest != null)
            {
                objResponseData.Data = ListRequest;
                //objResponseData.Body = raw;
                objResponseData.ResponseCode = "000";
                objResponseData.Message = "Role List";
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
        [Route("GetRoleMappingDepartmentandGroup")]
        public ResponseData GetRoleMappingDepartmentandGroup(string Id = null)
        {
            ResponseData objResponseData = new ResponseData();
            List<MappingRoleWithDepartmentandGroup> ListRequest = new List<MappingRoleWithDepartmentandGroup>();
            ListRequest = RoleBL.GetRoleMappingDepartmentandGroup(Id);
            //string raw = JObject.FromObject(new { ListRequest }).ToString();
            //raw = EncryptDecrypt.EncryptRaw(raw);
            if (ListRequest != null)
            {
                objResponseData.Data = ListRequest;
                //objResponseData.Body = raw;
                objResponseData.ResponseCode = "000";
                objResponseData.Message = "Role List";
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
        [Route("GetGrouplist")]
        public ResponseData GetGrouplist(int DepartmentId, int RoleId, string PartyId = null)
        {
            ResponseData objResponseData = new ResponseData();
            List<Dropdown> ListRequest = new List<Dropdown>();
            ListRequest = RoleBL.GetGrouplist(DepartmentId, RoleId, PartyId);
            //string raw = JObject.FromObject(new { ListRequest }).ToString();
            //raw = EncryptDecrypt.EncryptRaw(GetGrouplist);
            if (ListRequest != null)
            {
                objResponseData.Data = ListRequest;
                //objResponseData.Body = raw;
                objResponseData.ResponseCode = "001";
                objResponseData.Message = "Group List";
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
        [Route("InsertMappingRoleWithDepartmentandGroup")]
        public ResponseData InsertMappingRoleWithDepartmentandGroup(MappingRoleWithDepartmentandGroup master)
        {
            ResponseData objResponseData = new ResponseData();
            objResponseData = RoleBL.InsertMappingRoleWithDepartmentandGroup(master);
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
        [Route("GetUserPagingPermission")]
        public ResponseData GetUserPagingPermission(int MappingId, int GroupId)
        {
            ResponseData objResponseData = new ResponseData();
            List<UserPagingPermission> ListRequest = new List<UserPagingPermission>();
            ListRequest = RoleBL.GetUserPagingPermission(MappingId, GroupId);
            //string raw = JObject.FromObject(new { ListRequest }).ToString();
            //raw = EncryptDecrypt.EncryptRaw(raw);
            if (ListRequest != null)
            {
                objResponseData.Data = ListRequest;
                //objResponseData.Body = raw;
                objResponseData.ResponseCode = "000";
                objResponseData.Message = "Role List";
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
        [Route("GetSeletctedUserPagingPermission")]
        public ResponseData GetSeletctedUserPagingPermission(int MappingId, int GroupId, int DepartmentId, int RoleId)
        {
            ResponseData objResponseData = new ResponseData();
            List<UserPagingPermission> ListRequest = new List<UserPagingPermission>();
            ListRequest = RoleBL.GetSeletctedUserPagingPermission(MappingId, GroupId, DepartmentId, RoleId);
            //string raw = JObject.FromObject(new { ListRequest }).ToString();
            //raw = EncryptDecrypt.EncryptRaw(raw);
            if (ListRequest != null)
            {
                objResponseData.Data = ListRequest;
                //objResponseData.Body = raw;
                objResponseData.ResponseCode = "001";
                objResponseData.Message = "Role List";
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
        [Route("GetMenulist")]
        public ResponseData GetMenulist(string PartyId, string Type, int MenuId)
        {
            ResponseData objResponseData = new ResponseData();
            List<Dropdown> ListRequest = new List<Dropdown>();
            ListRequest = RoleBL.GetMenulist(PartyId, Type, MenuId);
            //string raw = JObject.FromObject(new { ListRequest }).ToString();
            //raw = EncryptDecrypt.EncryptRaw(raw);
            if (ListRequest != null)
            {
                objResponseData.Data = ListRequest;
                //objResponseData.Body = raw;
                objResponseData.ResponseCode = "001";
                objResponseData.Message = "Menu List";
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
        [Route("TreeList")]
        public ResponseData TreeList(string PartyId)
        {
            ResponseData objResponseData = new ResponseData();
            List<Tree> ListRequest = new List<Tree>();
            ListRequest = RoleBL.TreeList(PartyId);
            //string raw = JObject.FromObject(new { ListRequest }).ToString();
            //raw = EncryptDecrypt.EncryptRaw(raw);
            if (ListRequest != null)
            {
                objResponseData.Data = ListRequest;
                //objResponseData.Body = raw;
                objResponseData.ResponseCode = "001";
                objResponseData.Message = "Menu List";
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

        #region Notification Part
        [HttpPost]
        [Route("GetNotificationMaster")]
        public ResponseData GetNotificationMaster()
        {

            var objResponseData = RoleBL.GetNotificationMaster();
            return objResponseData;
        }

        [HttpPost]
        [Route("SaveNotificationMaster")]
        public ResponseData SaveNotificationMaster(NotificationMaster notification)
        {

            var objResponseData = RoleBL.SaveNotificationMaster(notification);
            return objResponseData;
        }

        [HttpPost]
        [Route("SaveNotificationTransactionAndUserList")]
        public ResponseData SaveNotificationTransactionAndUserList(NotificationTransectionUserListRequest notificationTransectionUserListRequest)
        {
            var objResponseData = RoleBL.SaveNotificationTransactionAndUserList(notificationTransectionUserListRequest);
            return objResponseData;
        }


        [HttpPost]
        [Route("NotificationOperation")]
        public ResponseData NotificationOperation(NotificationOperationRequest notificationOperation)
        {
            var objResponseData = RoleBL.NotificationOperation(notificationOperation);
            return objResponseData;
        }

        #endregion
        //[HttpGet]
        //[Route("FillDepartment")]
        //public ResponseData FillDepartment(int Id)
        //{
        //    ResponseData objResponseData = new ResponseData();
        //    List<Dropdown> ListRequest = new List<Dropdown>();
        //    ListRequest = RoleBL.FillDepartment(Id);
        //    //string raw = JObject.FromObject(new { ListRequest }).ToString();
        //    //raw = EncryptDecrypt.EncryptRaw(raw);
        //    if (ListRequest != null)
        //    {
        //        objResponseData.Data = ListRequest;
        //        //objResponseData.Body = raw;
        //        objResponseData.ResponseCode = "001";
        //        objResponseData.Message = "Department List";
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
    }
}
