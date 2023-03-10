using BO;
using BO.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Text;
using static BO.Models.Partial;
using static System.Exception;

namespace DL
{
    public class RoleMasterDL
    {
        ResponseData objResponseData = new ResponseData();
        public static IConfiguration _configuration;
        string connectionString = DBCS.GetConnectionString();

        public ResponseData InsertSubMenuMaster(SubMenuMaster obj)
        {
            try
            {

                SqlParameter[] param = new SqlParameter[6];
                param[0] = new SqlParameter("@SubMenuId", obj.SubMenuId);
                param[1] = new SqlParameter("@MenuId", obj.MenuId);
                param[2] = new SqlParameter("@SubMenuName", obj.SubMenuName);
                param[3] = new SqlParameter("@ControllerName", obj.ControllerName);
                param[4] = new SqlParameter("@ActionMethod", obj.ActionMethod);
                param[5] = new SqlParameter("@Status", obj.Status);
                DataTable DT = BaseFunction.FillDataTable("[dbo].[USP_ADMIN_ManageSubMenus_SaveUpdateView]", param);
                if (DT != null)
                {
                    if (DT.Rows.Count > 0)
                    {
                        objResponseData.statusCode = Convert.ToInt32(DT.Rows[0]["StatusCode"]);
                        objResponseData.Message = DT.Rows[0]["Message"].ToString();

                    }
                }
                else
                {
                    objResponseData.statusCode = 0;
                    objResponseData.Message = "Failed";
                }
            }
            catch (Exception e)
            {
                objResponseData.statusCode = 0;
                objResponseData.Message = "Failed";
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : InsertSubMenuMaster");
            }
            return objResponseData;
        }
        public ResponseData InsertMenuMaster(MenuMasters obj)
        {
            try
            {

                SqlParameter[] param = new SqlParameter[6];
                param[0] = new SqlParameter("@MenuId", obj.MenuId);
                param[1] = new SqlParameter("@MenuName", obj.MenuName);
                param[2] = new SqlParameter("@ControllerName", obj.ControllerName);
                param[3] = new SqlParameter("@ActionName", obj.ActionMethod);
                param[4] = new SqlParameter("@Status", obj.Status);
                param[5] = new SqlParameter("@CName", obj.CName);

                DataTable DT = BaseFunction.FillDataTable("[dbo].[USP_ADMIN_ManageMenus_SaveUpdateView]", param);
                if (DT != null)
                {
                    if (DT.Rows.Count > 0)
                    {
                        objResponseData.statusCode = Convert.ToInt32(DT.Rows[0]["StatusCode"]);
                        objResponseData.Message = DT.Rows[0]["Message"].ToString();

                    }
                }
                else
                {
                    objResponseData.statusCode = 0;
                    objResponseData.Message = "Failed";
                }
            }
            catch (Exception e)
            {
                objResponseData.statusCode = 0;
                objResponseData.Message = "Failed";
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : InsertMenuMaster");
            }
            return objResponseData;
        }

        public MenuMasters GetMenuMaster(int Id)
        {
            MenuMasters obj = new MenuMasters();
            try
            {

                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@MenuMasterId", Id);
                DataTable DT = BaseFunction.FillDataTable("[dbo].[USP_ADMIN_DisplayMenu_View]", param);
                if (DT != null)
                {
                    if (DT.Rows.Count > 0)
                    {
                        obj.MenuId = DT.Rows[0]["iPK_MenuId"].NulllToInt();
                        obj.Status = DT.Rows[0]["iStatus"].NulllToInt();
                        obj.ControllerName = DT.Rows[0]["sCntrllrNm"].NulllToString();
                        obj.ActionMethod = DT.Rows[0]["sActnMthd"].NulllToString();
                        obj.MenuName = DT.Rows[0]["sMenuName"].NulllToString();
                        obj.CName = DT.Rows[0]["sCName"].NulllToString();
                    }
                }
            }
            catch (Exception e)
            {
                obj = null;
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetMenuMaster");
            }
            return obj;
        }

        public List<MenuMasters> GetMenuMasterList()
        {
            List<MenuMasters> menulist = new List<MenuMasters>();
            try
            {

                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_ADMIN_DisplayMenu_View]");
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    menulist = new List<MenuMasters>();

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        MenuMasters obj = new MenuMasters();

                        obj.MenuId = ds.Tables[0].Rows[i]["iPK_MenuId"].NulllToInt();
                        obj.Status = ds.Tables[0].Rows[i]["iStatus"].NulllToInt();
                        obj.ControllerName = ds.Tables[0].Rows[i]["sCntrllrNm"].NulllToString();
                        obj.ActionMethod = ds.Tables[0].Rows[i]["sActnMthd"].NulllToString();
                        obj.MenuName = ds.Tables[0].Rows[i]["sMenuName"].NulllToString();
                        obj.CName = ds.Tables[0].Rows[i]["sCName"].NulllToString();
                        menulist.Add(obj);

                    }

                }
                else
                {
                    menulist = null;
                }
            }
            catch (Exception e)
            {
                menulist = null;
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetMenuMasterList");
            }
            return menulist;
        }

        public SubMenuMaster GetSubMenuMaster(int Id)
        {
            SubMenuMaster obj = new SubMenuMaster();
            try
            {

                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@SubMenuId", Id);
                DataTable DT = BaseFunction.FillDataTable("[dbo].[USP_ADMIN_GetSystemSubmenu_View]", param);
                if (DT != null)
                {
                    if (DT.Rows.Count > 0)
                    {
                        obj.MenuId = DT.Rows[0]["iFK_MnuId"].NulllToInt();
                        obj.Status = DT.Rows[0]["iStatus"].NulllToInt();
                        obj.ControllerName = DT.Rows[0]["sCntrolName"].NulllToString();
                        obj.ActionMethod = DT.Rows[0]["sActnMthd"].NulllToString();
                        obj.SubMenuName = DT.Rows[0]["sSubMnuName"].NulllToString();
                        obj.SubMenuId = DT.Rows[0]["iSubMnuId"].NulllToInt();
                        obj.MenuName = DT.Rows[0]["MenuName"].NulllToString();
                    }
                }
            }
            catch (Exception e)
            {
                obj = null;
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetSubMenuMaster");
            }
            return obj;
        }

        public List<MenuMappingwithSubmenu> GetMappingSubMenuMasterList(int Id)
        {
            List<MenuMappingwithSubmenu> menulist = new List<MenuMappingwithSubmenu>();
            DataSet ds = new DataSet();
            try
            {

                SqlParameter[] param = null;
                if (Id > 0)
                {
                    param = new SqlParameter[1];
                    param[0] = new SqlParameter("@MenuMappingwithSubmenuId", Id);
                    ds = BaseFunction.FillDataSet("[dbo].[USP_ADMIN_GetMenuSubmenuMapping_Select]", param);
                }
                else
                {
                    ds = BaseFunction.FillDataSet("[dbo].[USP_ADMIN_GetMenuSubmenuMapping_Select]");
                }
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    menulist = new List<MenuMappingwithSubmenu>();

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        MenuMappingwithSubmenu obj = new MenuMappingwithSubmenu();

                        obj.MenuMappingwithSubmenuId = ds.Tables[0].Rows[i]["MenuMappingwithSubmenuId"].NulllToInt();
                        obj.SubMenuId = ds.Tables[0].Rows[i]["iSubMnuId"].NulllToInt();
                        obj.MenuId = ds.Tables[0].Rows[i]["iFK_MnuId"].NulllToInt();
                        obj.Status = ds.Tables[0].Rows[i]["iStatus"].NulllToInt();
                        obj.SubMenuName = ds.Tables[0].Rows[i]["SubMenuName"].NulllToString();
                        obj.MenuName = ds.Tables[0].Rows[i]["MenuName"].NulllToString();
                        obj.InsertOperation = ds.Tables[0].Rows[i]["iInsrtOprtn"].NulllToInt();
                        obj.UpdateOpertaion = ds.Tables[0].Rows[i]["iUpdtOprtn"].NulllToInt();
                        obj.DeleteOperation = ds.Tables[0].Rows[i]["iDeltOprtn"].NulllToInt();
                        obj.ViewOperation = ds.Tables[0].Rows[i]["iVwOprtn"].NulllToInt();
                        obj.DepartmentId = ds.Tables[0].Rows[i]["iDeptId"].NulllToInt();
                        obj.GroupId = ds.Tables[0].Rows[i]["iFK_GrupId"].NulllToInt();
                        obj.RoleId = ds.Tables[0].Rows[i]["iRoleId"].NulllToInt();
                        obj.DepartmentName = ds.Tables[0].Rows[i]["DepartmentName"].NulllToString();
                        obj.GroupName = ds.Tables[0].Rows[i]["GroupName"].NulllToString();
                        obj.RoleName = ds.Tables[0].Rows[i]["RoleName"].NulllToString();
                        menulist.Add(obj);

                    }

                }
                else
                {
                    menulist = null;
                }
            }
            catch (Exception e)
            {
                menulist = null;
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetSubMenuMasterList");
            }
            return menulist;
        }
        public List<SubMenuMaster> GetSubMenuMasterList()
        {
            List<SubMenuMaster> menulist = new List<SubMenuMaster>();
            try
            {

                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_ADMIN_GetSystemSubmenu_View]");
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    menulist = new List<SubMenuMaster>();

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        SubMenuMaster obj = new SubMenuMaster();

                        obj.MenuId = ds.Tables[0].Rows[i]["iFK_MnuId"].NulllToInt();
                        obj.Status = ds.Tables[0].Rows[i]["iStatus"].NulllToInt();
                        obj.ControllerName = ds.Tables[0].Rows[i]["sCntrolName"].NulllToString();
                        obj.ActionMethod = ds.Tables[0].Rows[i]["sActnMthd"].NulllToString();
                        obj.SubMenuName = ds.Tables[0].Rows[i]["sSubMnuName"].NulllToString();
                        obj.SubMenuId = ds.Tables[0].Rows[i]["iSubMnuId"].NulllToInt();
                        obj.MenuName = ds.Tables[0].Rows[i]["sMenuName"].NulllToString();
                        menulist.Add(obj);

                    }

                }
                else
                {
                    menulist = null;
                }
            }
            catch (Exception e)
            {
                menulist = null;
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetMenuMasterList");
            }
            return menulist;
        }
        public List<CustomList> FillDepartmentandGroup(int Id)
        {
            List<CustomList> menulist = new List<CustomList>();
            try
            {

                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@DepartmentId", Id);
                DataSet ds = BaseFunction.FillDataSet("[dbo].[FillDropDownDepartmentandGroup]", param);
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    menulist = new List<CustomList>();

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        CustomList obj = new CustomList();

                        obj.Id = ds.Tables[0].Rows[i]["Id"].NulllToInt();

                        obj.text = ds.Tables[0].Rows[i]["text"].NulllToString();

                        menulist.Add(obj);

                    }

                }
                else
                {
                    menulist = null;
                }
            }
            catch (Exception e)
            {
                menulist = null;
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : FillDepartmentandGroup");
            }
            return menulist;
        }

        public List<CustomList> FillDepartmentandGroupMaster(string Type, string PartyId)
        {
            List<CustomList> menulist = new List<CustomList>();
            try
            {

                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@type", Type);
                param[1] = new SqlParameter("@PartyId", PartyId);

                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_ADMIN_GetMasterDataForDropdown_View]", param);
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    menulist = new List<CustomList>();

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        CustomList obj = new CustomList();

                        obj.Id = ds.Tables[0].Rows[i]["Id"].NulllToInt();

                        obj.text = ds.Tables[0].Rows[i]["text"].NulllToString();

                        menulist.Add(obj);

                    }
                }
                else
                {
                    menulist = null;
                }
            }
            catch (Exception e)
            {
                menulist = null;
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : FillDepartmentandGroupMaster");
            }
            return menulist;
        }

        public List<CustomList> GetSubMenu(int Id)
        {
            List<CustomList> menulist = new List<CustomList>();
            try
            {

                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@MenuId", Id);

                DataSet ds = BaseFunction.FillDataSet("[dbo].[usp_GetSubMenubyMenuId]", param);
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    menulist = new List<CustomList>();
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        CustomList obj = new CustomList();
                        obj.Id = ds.Tables[0].Rows[i]["Id"].NulllToInt();
                        obj.text = ds.Tables[0].Rows[i]["text"].NulllToString();
                        menulist.Add(obj);
                    }
                }
                else
                {
                    menulist = null;
                }
            }
            catch (Exception e)
            {
                menulist = null;
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetSubMenu");
            }
            return menulist;
        }
        public List<CustomList> FillDepartmentandGroupwithRole(int DepartmentId, int GroupId)
        {
            List<CustomList> menulist = new List<CustomList>();
            try
            {

                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@DepartmentId", DepartmentId);
                param[1] = new SqlParameter("@GroupId", GroupId);
                DataSet ds = BaseFunction.FillDataSet("[dbo].[FillDepartmentandGroupwithRole]", param);
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    menulist = new List<CustomList>();

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        CustomList obj = new CustomList();

                        obj.Id = ds.Tables[0].Rows[i]["Id"].NulllToInt();

                        obj.text = ds.Tables[0].Rows[i]["text"].NulllToString();

                        menulist.Add(obj);

                    }

                }
                else
                {
                    menulist = null;
                }
            }
            catch (Exception e)
            {
                menulist = null;
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : FillDepartmentandGroupwithRole");
            }
            return menulist;
        }
        public ResponseData InsertRoleInformation(RoleInformation obj)
        {
            try
            {

                SqlParameter[] param = new SqlParameter[6];
                param[0] = new SqlParameter("@RoleinformationId", obj.RoleinformationId);
                param[1] = new SqlParameter("@DepartmentId", obj.DepartmentId);
                param[2] = new SqlParameter("@GroupId", obj.GroupId);
                param[3] = new SqlParameter("@Name", obj.Name);
                param[4] = new SqlParameter("@TypeId", obj.Type);
                param[5] = new SqlParameter("@Status", obj.Status);
                DataTable DT = BaseFunction.FillDataTable("[dbo].[USP_MASTER_ManageRoleInformation_SaveUpdateView]", param);
                if (DT != null)
                {
                    if (DT.Rows.Count > 0)
                    {
                        objResponseData.statusCode = Convert.ToInt32(DT.Rows[0]["StatusCode"]);
                        objResponseData.Message = DT.Rows[0]["Message"].ToString();

                    }
                }
                else
                {
                    objResponseData.statusCode = 0;
                    objResponseData.Message = "Failed";
                }
            }
            catch (Exception e)
            {
                objResponseData.statusCode = 0;
                objResponseData.Message = "Failed";
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : InsertRoleInformation");
            }
            return objResponseData;
        }

        public ResponseData InsertRoleMappingwithMenu(RoleMappingwithMenu obj)
        {
            try
            {

                SqlParameter[] param = new SqlParameter[6];
                param[0] = new SqlParameter("@RoleMappingwithMenuid", obj.RoleMappingwithMenuid);
                param[1] = new SqlParameter("@DepartmentId", obj.DepartmentId);
                param[2] = new SqlParameter("@GroupId", obj.GroupId);
                param[3] = new SqlParameter("@RoleId", obj.RoleId);
                param[4] = new SqlParameter("@MenuId", obj.MenuId);
                param[5] = new SqlParameter("@Status", obj.Status);
                DataTable DT = BaseFunction.FillDataTable("[dbo].[Usp_InsertRoleMappingwithMenu]", param);
                if (DT != null)
                {
                    if (DT.Rows.Count > 0)
                    {
                        objResponseData.statusCode = Convert.ToInt32(DT.Rows[0]["StatusCode"]);
                        objResponseData.Message = DT.Rows[0]["Message"].ToString();

                    }
                }
                else
                {
                    objResponseData.statusCode = 0;
                    objResponseData.Message = "Failed";
                }
            }
            catch (Exception e)
            {
                objResponseData.statusCode = 0;
                objResponseData.Message = "Failed";
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : InsertRoleMappingwithMenu");
            }
            return objResponseData;
        }
        public ResponseData InsertRoleMappingwithSubMenu(MenuMappingwithSubmenu obj)
        {
            try
            {

                SqlParameter[] param = new SqlParameter[7];
                param[0] = new SqlParameter("@MenuMappingwithSubmenuId", obj.MenuMappingwithSubmenuId);
                param[1] = new SqlParameter("@DepartmentId", obj.DepartmentId);
                param[2] = new SqlParameter("@GroupId", obj.GroupId);
                param[3] = new SqlParameter("@RoleId", obj.RoleId);
                param[4] = new SqlParameter("@MenuId", obj.MenuId);
                param[5] = new SqlParameter("@SubMenuId", obj.SubMenuId);
                param[6] = new SqlParameter("@StatusId", obj.Status);
                DataTable DT = BaseFunction.FillDataTable("[dbo].[USP_ADMIN_MapRolesandSubmenus_Save]", param);
                if (DT != null)
                {
                    if (DT.Rows.Count > 0)
                    {
                        objResponseData.statusCode = Convert.ToInt32(DT.Rows[0]["StatusCode"]);
                        objResponseData.Message = DT.Rows[0]["Message"].ToString();

                    }
                }
                else
                {
                    objResponseData.statusCode = 0;
                    objResponseData.Message = "Failed";
                }
            }
            catch (Exception e)
            {
                objResponseData.statusCode = 0;
                objResponseData.Message = "Failed";
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : InsertRoleMappingwithMenu");
            }
            return objResponseData;
        }
        public List<RoleInformation> GetRoleInformation()
        {
            List<RoleInformation> Rolelist = new List<RoleInformation>();
            try
            {

                DataSet ds = BaseFunction.FillDataSet("[dbo].[GetRoleInformation]");
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    Rolelist = new List<RoleInformation>();

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        RoleInformation obj = new RoleInformation();

                        obj.RoleinformationId = ds.Tables[0].Rows[i]["RoleinformationId"].NulllToInt();
                        obj.DepartmentId = ds.Tables[0].Rows[i]["DepartmentId"].NulllToInt();
                        obj.GroupId = ds.Tables[0].Rows[i]["GroupId"].NulllToInt();
                        obj.RoleId = ds.Tables[0].Rows[i]["RoleId"].NulllToInt();
                        obj.Type = ds.Tables[0].Rows[i]["Type"].NulllToInt();
                        obj.Status = ds.Tables[0].Rows[i]["Status"].NulllToInt();
                        obj.Name = ds.Tables[0].Rows[i]["Name"].NulllToString();

                        Rolelist.Add(obj);

                    }

                }
                else
                {
                    Rolelist = null;
                }
            }
            catch (Exception e)
            {
                Rolelist = null;
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetRoleInformation");
            }
            return Rolelist;
        }
        public List<RoleMappingwithMenu> GetRoleMappingMenuList()
        {
            List<RoleMappingwithMenu> Rolelist = new List<RoleMappingwithMenu>();
            try
            {

                DataSet ds = BaseFunction.FillDataSet("[dbo].[Usp_GetRoleMappingwithMenu]");
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    Rolelist = new List<RoleMappingwithMenu>();

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        RoleMappingwithMenu obj = new RoleMappingwithMenu();

                        obj.RoleMappingwithMenuid = ds.Tables[0].Rows[i]["RoleMappingwithMenuid"].NulllToInt();
                        obj.DepartmentName = ds.Tables[0].Rows[i]["DepartmentName"].NulllToString();
                        obj.GroupName = ds.Tables[0].Rows[i]["GroupName"].NulllToString();
                        obj.RoleName = ds.Tables[0].Rows[i]["RoleName"].NulllToString();
                        obj.MenuName = ds.Tables[0].Rows[i]["MenuName"].NulllToString();
                        obj.Status = ds.Tables[0].Rows[i]["Status"].NulllToInt();
                        Rolelist.Add(obj);
                    }

                }
                else
                {
                    Rolelist = null;
                }
            }
            catch (Exception e)
            {
                Rolelist = null;
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetRoleMappingMenuList");
            }
            return Rolelist;
        }
        public RoleInformation GetSelectRoleInformation(int Id)
        {
            RoleInformation obj = new RoleInformation();
            try
            {

                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@RoleInformationId", Id);
                DataTable DT = BaseFunction.FillDataTable("[dbo].[GetRoleInformation]", param);
                if (DT != null)
                {
                    if (DT.Rows.Count > 0)
                    {
                        obj.DepartmentId = DT.Rows[0]["DepartmentId"].NulllToInt();
                        obj.Status = DT.Rows[0]["Status"].NulllToInt();
                        obj.Name = DT.Rows[0]["Name"].NulllToString();
                        obj.GroupId = DT.Rows[0]["GroupId"].NulllToInt();
                        obj.RoleinformationId = DT.Rows[0]["RoleinformationId"].NulllToInt();
                        obj.Type = DT.Rows[0]["Type"].NulllToInt();

                    }
                }
            }
            catch (Exception e)
            {
                obj = null;
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetSubMenuMaster");
            }
            return obj;

        }
        public RoleMappingwithMenu GetSelectRoleWithMenu(int Id)
        {
            RoleMappingwithMenu obj = new RoleMappingwithMenu();
            try
            {

                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@RoleMappingwithMenuId", Id);
                DataTable DT = BaseFunction.FillDataTable("[dbo].[Usp_Select_RoleMappingMenuWithId]", param);
                if (DT != null)
                {
                    if (DT.Rows.Count > 0)
                    {
                        obj.DepartmentId = DT.Rows[0]["DepartmentId"].NulllToInt();
                        obj.Status = DT.Rows[0]["Status"].NulllToInt();
                        obj.RoleMappingwithMenuid = DT.Rows[0]["RoleMappingwithMenuid"].NulllToInt();
                        obj.GroupId = DT.Rows[0]["groupId"].NulllToInt();
                        obj.RoleId = DT.Rows[0]["RoleId"].NulllToInt();
                        obj.MenuId = DT.Rows[0]["MenuId"].NulllToInt();

                    }
                }
            }
            catch (Exception e)
            {
                obj = null;
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetSelectRoleWithMenu");

            }
            return obj;
        }

        public ResponseData OperationStatus(Permissionclass obj)
        {
            try
            {

                SqlParameter[] param = new SqlParameter[5];
                param[0] = new SqlParameter("@Type", obj.Type);
                param[1] = new SqlParameter("@MappingId", obj.MappingId);
                param[2] = new SqlParameter("@PermissionId", obj.PermissionId);
                param[3] = new SqlParameter("@MstGroupID", obj.MstGroupId);
                param[4] = new SqlParameter("@status", obj.status);
                //param[5] = new SqlParameter("@PartyId", obj.PartyId);

                DataTable DT = BaseFunction.FillDataTable("[dbo].[USP_ADMIN_UserwiseRoleAccessRights_Save]", param);
                if (DT != null)
                {
                    if (DT.Rows.Count > 0)
                    {
                        objResponseData.statusCode = Convert.ToInt32(DT.Rows[0]["StatusCode"]);
                        objResponseData.Message = DT.Rows[0]["Message"].ToString();

                    }
                }
                else
                {
                    objResponseData.statusCode = 0;
                    objResponseData.Message = "Failed";
                }
            }
            catch (Exception e)
            {
                objResponseData.statusCode = 0;
                objResponseData.Message = "Failed";
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : InsertServices");
            }
            return objResponseData;

        }
        public ResponseData InsertRoleMasterCreate(RoleMastertable obj)
        {
            try
            {

                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@RoleId", obj.RoleId);
                param[1] = new SqlParameter("@RoleName", obj.RoleName);
                param[2] = new SqlParameter("@Status", obj.Status);
                param[3] = new SqlParameter("@PartyId", obj.PartyId);

                DataTable DT = BaseFunction.FillDataTable("[dbo].[USP_ADMIN_NewRole_SaveUpdate]", param);
                if (DT != null)
                {
                    if (DT.Rows.Count > 0)
                    {
                        objResponseData.statusCode = Convert.ToInt32(DT.Rows[0]["StatusCode"]);
                        objResponseData.Message = DT.Rows[0]["Message"].ToString();

                    }
                }
                else
                {
                    objResponseData.statusCode = 0;
                    objResponseData.Message = "Failed";
                }
            }
            catch (Exception e)
            {
                objResponseData.statusCode = 0;
                objResponseData.Message = "Failed";
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : InsertServices");
            }
            return objResponseData;
        }


        public List<RoleMastertable> GetRoleMasterInformation(int Id, string PartyId)
        {

            List<RoleMastertable> rolelist = new List<RoleMastertable>();
            try
            {

                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@Id", Id);
                param[1] = new SqlParameter("@PartyId", PartyId);

                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_ADMIN_GetUserwiseRole_Select]", param);
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    rolelist = new List<RoleMastertable>();
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        RoleMastertable obj = new RoleMastertable();
                        obj.RoleId = ds.Tables[0].Rows[i]["iPk_RolId"].NulllToInt();
                        obj.RoleName = ds.Tables[0].Rows[i]["sRolName"].NulllToString();
                        obj.Status = ds.Tables[0].Rows[i]["iStatus"].NulllToInt();
                        rolelist.Add(obj);
                    }
                }
                else
                {
                    rolelist = null;
                }
            }
            catch (Exception e)
            {
                rolelist = null;
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetRoleMasterInformation");
            }
            return rolelist;
        }
        public List<Dropdown> GetGrouplist(int DepartmentId, int RoleId, string PartyId = null)
        {
            List<Dropdown> Grouplist = new List<Dropdown>();
            try
            {

                SqlParameter[] param = null;
                if (!string.IsNullOrEmpty(PartyId))
                {
                    param = new SqlParameter[3];
                    param[0] = new SqlParameter("@DepartmentId", DepartmentId);
                    param[1] = new SqlParameter("@RoleId", RoleId);
                    param[2] = new SqlParameter("@PartyId", PartyId);
                }
                else
                {
                    param = new SqlParameter[2];
                    param[0] = new SqlParameter("@DepartmentId", DepartmentId);
                    param[1] = new SqlParameter("@RoleId", RoleId);
                }

                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_ADMIN_GetGroupRoleandDepartment_View]", param);
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    Grouplist = new List<Dropdown>();
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        Dropdown obj = new Dropdown();
                        obj.Id = ds.Tables[0].Rows[i]["Id"].NulllToString();
                        obj.Text = ds.Tables[0].Rows[i]["Text"].NulllToString();
                        Grouplist.Add(obj);

                    }
                }
                else
                {
                    Grouplist = null;
                }
            }
            catch (Exception e)
            {
                Grouplist = null;
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetGrouplist");
            }
            return Grouplist;
        }
        public List<MappingRoleWithDepartmentandGroup> GetRoleMappingDepartmentandGroup(string Id)
        {

            List<MappingRoleWithDepartmentandGroup> rolelist = new List<MappingRoleWithDepartmentandGroup>();
            DataSet ds = new DataSet();
            try
            {

                SqlParameter[] param = null;

                if (!string.IsNullOrEmpty(Id))
                {
                    param = new SqlParameter[1];
                    param[0] = new SqlParameter("@Id", Id);
                    ds = BaseFunction.FillDataSet("[dbo].[USP_ADMIN_GetDepartmentGroupRolesMapping_Select]", param);
                }
                else
                {
                    ds = BaseFunction.FillDataSet("[dbo].[USP_ADMIN_GetDepartmentGroupRolesMapping_Select]");
                }
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    rolelist = new List<MappingRoleWithDepartmentandGroup>();

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        MappingRoleWithDepartmentandGroup obj = new MappingRoleWithDepartmentandGroup();

                        obj.RoleId = ds.Tables[0].Rows[i]["iRoleId"].NulllToInt();
                        obj.Id = ds.Tables[0].Rows[i]["iPK_RoleDeptId"].NulllToInt();
                        obj.DepartmentId = ds.Tables[0].Rows[i]["iDeptId"].NulllToInt();
                        obj.GroupId = ds.Tables[0].Rows[i]["iGrpId"].NulllToInt();
                        obj.Status = ds.Tables[0].Rows[i]["iStatus"].NulllToInt();
                        obj.DepartmentName = ds.Tables[0].Rows[i]["DepartmentName"].NulllToString();
                        obj.GroupName = ds.Tables[0].Rows[i]["GroupName"].NulllToString();
                        obj.RoleName = ds.Tables[0].Rows[i]["RoleName"].NulllToString();
                        obj.PartyId = ds.Tables[0].Rows[i]["sPartyId"].NulllToString();
                        obj.levelId = ds.Tables[0].Rows[i]["iLevelId"].NulllToInt();
                        rolelist.Add(obj);

                    }

                }
                else
                {
                    rolelist = null;
                }
            }
            catch (Exception e)
            {
                rolelist = null;
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetRoleMappingDepartmentandGroup");
            }
            return rolelist;
        }
        //        public List<Dropdown> FillDepartment(int Id)
        //        {
        //            List<Dropdown> Departmentlist = new List<Dropdown>();
        //            try
        //            {

        //                string queryString = "[dbo].[GetRoleMappingDepartmentandGroup]";
        //                using (SqlConnection connect = new SqlConnection())
        //                {
        //                    SqlCommand cmd = new SqlCommand(queryString, connect);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //                    if (Id > 0)
        //                    {
        //                        cmd.Parameters.AddWithValue("@Id", Id);
        //                    }


        //connect.ConnectionString = connectionString;
        //cmd.Connection = connect;
        //if (connect.State != ConnectionState.Open)
        //{
        //    connect.Open();
        //}
        //SqlDataAdapter da = new SqlDataAdapter(cmd);
        //DataSet ds = new DataSet();
        //da.Fill(ds);
        //if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
        //{
        //    rolelist = new List<MappingRoleWithDepartmentandGroup>();

        //    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //    {
        //        MappingRoleWithDepartmentandGroup obj = new MappingRoleWithDepartmentandGroup();

        //        obj.RoleId = ds.Tables[0].Rows[i]["RoleId"].NulllToInt();
        //        obj.Id = ds.Tables[0].Rows[i]["Id"].NulllToInt();
        //        obj.DepartmentId = ds.Tables[0].Rows[i]["DepartmentId"].NulllToInt();
        //        obj.GroupId = ds.Tables[0].Rows[i]["GroupId"].NulllToInt();
        //        obj.Status = ds.Tables[0].Rows[i]["Status"].NulllToInt();
        //        obj.DepartmentName = ds.Tables[0].Rows[i]["DepartmentName"].NulllToString();
        //        obj.GroupName = ds.Tables[0].Rows[i]["GroupName"].NulllToString();
        //        obj.RoleName = ds.Tables[0].Rows[i]["RoleName"].NulllToString();
        //        rolelist.Add(obj);

        //    }

        //}
        //else
        //{
        //    rolelist = null;
        //}
        //                }
        //            }
        //            catch (Exception e)
        //{
        //    rolelist = null;
        //    ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetRoleMappingDepartmentandGroup");
        //}
        //return rolelist;
        //        }

        public List<Dropdown> GetMenulist(string PartyId, string Type, int MenuId)
        {
            List<Dropdown> Grouplist = new List<Dropdown>();
            try
            {

                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@partyId", PartyId);
                param[1] = new SqlParameter("@Type", Type);
                param[2] = new SqlParameter("@MenuId", MenuId);
                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_ADMIN_GetUserwiseMenu_Select]", param);
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    Grouplist = new List<Dropdown>();

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        Dropdown obj = new Dropdown();

                        obj.Id = ds.Tables[0].Rows[i]["Id"].NulllToString();


                        obj.Text = ds.Tables[0].Rows[i]["Text"].NulllToString();

                        Grouplist.Add(obj);

                    }

                }
                else
                {
                    Grouplist = null;
                }
            }
            catch (Exception e)
            {
                Grouplist = null;
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetMenulist");
            }
            return Grouplist;

        }

        public List<UserPagingPermission> GetUserPagingPermission(int MappingId, int GroupId)
        {
            List<UserPagingPermission> rolelist = new List<UserPagingPermission>();
            try
            {

                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@MappingId", MappingId);
                param[1] = new SqlParameter("@GroupId", GroupId);

                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_ADMIN_PageAccessRightsUserwise_View]", param);
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    rolelist = new List<UserPagingPermission>();

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        UserPagingPermission obj = new UserPagingPermission();

                        obj.ID = ds.Tables[0].Rows[i]["biPK_MSTId"].NulllToInt();
                        obj.perDelete = ds.Tables[0].Rows[i]["perDelete"].NulllToInt();
                        obj.perEdit = ds.Tables[0].Rows[i]["perEdit"].NulllToInt();
                        obj.perInsert = ds.Tables[0].Rows[i]["perInsert"].NulllToInt();
                        obj.perView = ds.Tables[0].Rows[i]["perView"].NulllToInt();
                        obj.UserID = ds.Tables[0].Rows[i]["UserID"].NulllToInt();
                        obj.GroupID = ds.Tables[0].Rows[i]["iPK_GrpId"].NulllToInt();
                        obj.perStatus = ds.Tables[0].Rows[i]["perStatus"].NulllToInt();
                        obj.MenuName = ds.Tables[0].Rows[i]["sMenuName"].NulllToString();
                        obj.SubMenuName = ds.Tables[0].Rows[i]["sSubMnuName"].NulllToString();

                        rolelist.Add(obj);

                    }

                }
                else
                {
                    rolelist = null;
                }
            }
            catch (Exception e)
            {
                rolelist = null;
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetUserPagingPermission");
            }
            return rolelist;
        }

        public List<UserPagingPermission> GetSeletctedUserPagingPermission(int MappingId, int GroupId, int DepartmentId, int RoleId)
        {
            List<UserPagingPermission> rolelist = new List<UserPagingPermission>();
            try
            {

                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@MappingId", MappingId);
                param[1] = new SqlParameter("@GroupId", GroupId);
                param[2] = new SqlParameter("@DepartmentId", DepartmentId);
                param[3] = new SqlParameter("@RoleId", RoleId);
                DataSet ds = BaseFunction.FillDataSet("[dbo].[InsertUserRights]", param);
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    rolelist = new List<UserPagingPermission>();

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        UserPagingPermission obj = new UserPagingPermission();

                        obj.ID = ds.Tables[0].Rows[i]["MstGroupId"].NulllToInt();
                        obj.perDelete = ds.Tables[0].Rows[i]["perDelete"].NulllToInt();
                        obj.perEdit = ds.Tables[0].Rows[i]["perEdit"].NulllToInt();
                        obj.perInsert = ds.Tables[0].Rows[i]["perInsert"].NulllToInt();
                        obj.perView = ds.Tables[0].Rows[i]["perView"].NulllToInt();
                        obj.UserID = ds.Tables[0].Rows[i]["UserID"].NulllToInt();
                        obj.GroupID = ds.Tables[0].Rows[i]["GroupID"].NulllToInt();
                        obj.perStatus = ds.Tables[0].Rows[i]["perStatus"].NulllToInt();
                        obj.MenuName = ds.Tables[0].Rows[i]["MenuName"].NulllToString();
                        obj.SubMenuName = ds.Tables[0].Rows[i]["SubMenuName"].NulllToString();
                        obj.Inserting = ds.Tables[0].Rows[i]["Inserting"].NulllToInt();
                        obj.Deleting = ds.Tables[0].Rows[i]["Deleting"].NulllToInt();
                        obj.Editing = ds.Tables[0].Rows[i]["Editing"].NulllToInt();
                        obj.Viewing = ds.Tables[0].Rows[i]["Viewing"].NulllToInt();
                        obj.Status = ds.Tables[0].Rows[i]["Status"].NulllToInt();
                        rolelist.Add(obj);

                    }

                }
                else
                {
                    rolelist = null;
                }
            }
            catch (Exception e)
            {
                rolelist = null;
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetSeletctedUserPagingPermission");
            }
            return rolelist;
        }

        // done by shipra
        public ResponseData InsertMappingRoleWithDepartmentandGroup(MappingRoleWithDepartmentandGroup obj)
        {
            try
            {

                SqlParameter[] param = new SqlParameter[7];
                param[0] = new SqlParameter("@Id", obj.Id);
                param[1] = new SqlParameter("@DepartmentId", obj.DepartmentId);
                param[2] = new SqlParameter("@GroupId", obj.GroupId);
                param[3] = new SqlParameter("@RoleId", obj.RoleId);
                param[4] = new SqlParameter("@partyId", obj.PartyId);
                param[5] = new SqlParameter("@Status", obj.Status);
                param[6] = new SqlParameter("@LevelId", obj.levelId);

                DataTable DT = BaseFunction.FillDataTable("[dbo].[USP_ADMIN_MapRoleDepartmentGroup_SaveUpdate]", param);
                if (DT != null)
                {
                    if (DT.Rows.Count > 0)
                    {
                        objResponseData.statusCode = Convert.ToInt32(DT.Rows[0]["StatusCode"]);
                        objResponseData.Message = DT.Rows[0]["Message"].ToString();
                    }
                }
                else
                {
                    objResponseData.statusCode = 0;
                    objResponseData.Message = "Failed";
                }
            }
            catch (Exception e)
            {
                objResponseData.statusCode = 0;
                objResponseData.Message = "Failed";
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : InsertRoleInformation");
            }
            return objResponseData;
        }

        public List<Tree> TreeList(string partyId)
        {
            List<Tree> Treelist = new List<Tree>();
            try
            {

                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@PartyId", partyId);
                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_REPORT_GetUserHierarchy_Select]", param);
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    Treelist = new List<Tree>();

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        Tree obj = new Tree();

                        obj.PartyId = ds.Tables[0].Rows[i]["PartyId"].NulllToString();
                        obj.ParentId = ds.Tables[0].Rows[i]["ParentId"].NulllToString();
                        obj.IsActive = ds.Tables[0].Rows[i]["IsActive"].NulllToInt();

                        obj.FirstName = ds.Tables[0].Rows[i]["FirstName"].NulllToString();
                        obj.LastName = ds.Tables[0].Rows[i]["LastName"].NulllToString();
                        obj.EmailId = ds.Tables[0].Rows[i]["EmailId"].NulllToString();

                        Treelist.Add(obj);

                    }

                }
                else
                {
                    Treelist = null;
                }
            }
            catch (Exception e)
            {
                Treelist = null;
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : TreeList");
            }
            return Treelist;
        }


        #region Notification Part

        public ResponseData GetNotificationMaster()
        {
            try
            {

                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_ADMIN_NotificationConfiguration_View]");
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    objResponseData.ResponseCode = "000";
                    objResponseData.Message = "Notification Configuration List...";
                    objResponseData.statusCode = 1;
                    objResponseData.Data = ds.Tables[0];
                }
                else
                {
                    objResponseData.ResponseCode = "001";
                    objResponseData.Message = "No Data Available...";
                    objResponseData.statusCode = -1;
                    objResponseData.Data = null;
                }
            }
            catch (Exception e)
            {
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetNotificationMaster", connectionString);
            }
            return objResponseData;
        }

        public ResponseData SaveNotificationMaster(NotificationMaster notification)
        {
            try
            {

                SqlParameter[] param = new SqlParameter[6];
                param[0] = new SqlParameter("@MenuId", notification.MenuId);
                param[1] = new SqlParameter("@SubMenuId", notification.SubMenuId);
                param[2] = new SqlParameter("@Message", notification.Message);
                param[3] = new SqlParameter("@SendtoFlow", notification.SendtoFlow);
                param[4] = new SqlParameter("@Event", notification.Event);
                param[5] = new SqlParameter("@CreatedBy", notification.CreatedBy);
                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_ADMIN_NotificationConfiguration_Save]");
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    objResponseData.ResponseCode = "000";
                    objResponseData.Message = ds.Tables[0].Rows[0]["Message"].ToString();
                    objResponseData.statusCode = ds.Tables[0].Rows[0]["StatusCode"].NulllToInt();
                }
                else
                {
                    objResponseData.ResponseCode = "001";
                    objResponseData.Message = ds.Tables[0].Rows[0]["Message"].ToString();
                    objResponseData.statusCode = ds.Tables[0].Rows[0]["StatusCode"].NulllToInt();
                }
            }
            catch (Exception e)
            {
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : SaveNotificationMaster", connectionString);
            }
            return objResponseData;
        }
        public ResponseData SaveNotificationTransactionAndUserList(NotificationTransectionUserListRequest notificationTransectionUserListRequest)
        {
            try
            {

                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@PartyID", notificationTransectionUserListRequest.PartyID);
                param[1] = new SqlParameter("@FlowDirection", notificationTransectionUserListRequest.FlowDirection);
                param[2] = new SqlParameter("@configId", notificationTransectionUserListRequest.configId);
                param[3] = new SqlParameter("@specificUser", notificationTransectionUserListRequest.specificUser);

                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_ADMIN_NotificationTransactionDetails_Save]");
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    objResponseData.ResponseCode = "000";
                    objResponseData.Message = ds.Tables[0].Rows[0]["Message"].ToString();
                    objResponseData.statusCode = ds.Tables[0].Rows[0]["StatusCode"].NulllToInt();
                }
                else
                {
                    objResponseData.ResponseCode = "001";
                    objResponseData.Message = ds.Tables[0].Rows[0]["Message"].ToString();
                    objResponseData.statusCode = ds.Tables[0].Rows[0]["StatusCode"].NulllToInt();
                }

            }
            catch (Exception e)
            {
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : SaveNotificationTransactionAndUserList", connectionString);
            }
            return objResponseData;
        }

        public ResponseData NotificationOperation(NotificationOperationRequest notificationOperation)
        {
            try
            {

                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@PartyId", notificationOperation.PartyId);
                param[1] = new SqlParameter("@RowID", notificationOperation.RowID);
                param[2] = new SqlParameter("@Type", notificationOperation.Type);


                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_ADMIN_NotificationOperation_ViewUpdate]");
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    objResponseData.ResponseCode = "000";
                    objResponseData.Message = "Notification Data";
                    objResponseData.statusCode = 1;
                    objResponseData.Data = ds.Tables[0];
                }
                else
                {
                    objResponseData.ResponseCode = "001";
                    objResponseData.Message = "";
                    objResponseData.statusCode = 0;
                    objResponseData.Data = null;
                }
            }
            catch (Exception e)
            {
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : NotificationOperation", connectionString);
            }
            return objResponseData;
        }
        #endregion



    }

}
