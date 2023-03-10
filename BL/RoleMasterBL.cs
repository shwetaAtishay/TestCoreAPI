using BO;
using BO.Models;
using DL;
using System;
using System.Collections.Generic;
using System.Text;
using static BO.Models.Partial;

namespace BL
{
    public class RoleMasterBL
    {
        RoleMasterDL objRoleDL = new RoleMasterDL();
        public ResponseData InsertMenuMaster(MenuMasters obj)
        {
            return objRoleDL.InsertMenuMaster(obj);
        }
        public ResponseData InsertSubMenuMaster(SubMenuMaster obj)
        {
            return objRoleDL.InsertSubMenuMaster(obj);
        }
        public MenuMasters GetMenuMaster(int Id)
        {
            return objRoleDL.GetMenuMaster(Id);
        }
        public SubMenuMaster GetSubMenuMaster(int Id)
        {
            return objRoleDL.GetSubMenuMaster(Id);
        }
        public List<MenuMasters> GetMenuMasterList()
        {
            return objRoleDL.GetMenuMasterList();
        }
        public List<SubMenuMaster> GetSubMenuMasterList()
        {
            return objRoleDL.GetSubMenuMasterList();
        }
        public List<CustomList> FillDepartmentandGroup(int Id)
        {
            return objRoleDL.FillDepartmentandGroup(Id);
        }

        public List<CustomList> FillDepartmentandGroupMaster(string Type, string PartyId)
        {
            return objRoleDL.FillDepartmentandGroupMaster(Type, PartyId);
        }
        public List<CustomList> GetSubMenu(int Id)
        {
            return objRoleDL.GetSubMenu(Id);
        }

        public List<CustomList> FillDepartmentandGroupwithRole(int DepartmentId, int GroupId)
        {
            return objRoleDL.FillDepartmentandGroupwithRole(DepartmentId, GroupId);
        }
        public ResponseData InsertRoleInformation(RoleInformation obj)
        {
            return objRoleDL.InsertRoleInformation(obj);
        }
        public ResponseData InsertRoleMappingwithMenu(RoleMappingwithMenu obj)
        {
            return objRoleDL.InsertRoleMappingwithMenu(obj);
        }
        public ResponseData InsertRoleMappingwithSubMenu(MenuMappingwithSubmenu obj)
        {
            return objRoleDL.InsertRoleMappingwithSubMenu(obj);
        }
        public List<RoleInformation> GetRoleInformation()
        {
            return objRoleDL.GetRoleInformation();

        }
        public RoleInformation GetSelectRoleInformation(int Id)
        {
            return objRoleDL.GetSelectRoleInformation(Id);

        }
        public RoleMappingwithMenu GetSelectRoleWithMenu(int Id)
        {
            return objRoleDL.GetSelectRoleWithMenu(Id);
        }
        public List<RoleMappingwithMenu> GetRoleMappingMenuList()
        {
            return objRoleDL.GetRoleMappingMenuList();
        }
        public List<MenuMappingwithSubmenu> GetMappingSubMenuMasterList(int Id)
        {
            return objRoleDL.GetMappingSubMenuMasterList(Id);
        }
        public ResponseData OperationStatus(Permissionclass Master)
        {
            return objRoleDL.OperationStatus(Master);
        }
        public ResponseData InsertRoleMasterCreate(RoleMastertable Master)
        {
            return objRoleDL.InsertRoleMasterCreate(Master);
        }

        public List<RoleMastertable> GetRoleMasterInformation(int Id, string PartyId)
        {
            return objRoleDL.GetRoleMasterInformation(Id, PartyId);
        }
        public List<MappingRoleWithDepartmentandGroup> GetRoleMappingDepartmentandGroup(string Id)
        {
            return objRoleDL.GetRoleMappingDepartmentandGroup(Id);
        }
        public List<UserPagingPermission> GetUserPagingPermission(int MappingId, int GroupId)
        {
            return objRoleDL.GetUserPagingPermission(MappingId, GroupId);
        }
        public List<UserPagingPermission> GetSeletctedUserPagingPermission(int MappingId, int GroupId, int DepartmentId, int RoleId)
        {
            return objRoleDL.GetSeletctedUserPagingPermission(MappingId, GroupId, DepartmentId, RoleId);
        }
        public List<Dropdown> GetMenulist(string PartyId, string Type, int MenuId)
        {
            return objRoleDL.GetMenulist(PartyId, Type, MenuId);
        }
        public ResponseData InsertMappingRoleWithDepartmentandGroup(MappingRoleWithDepartmentandGroup Master)
        {
            return objRoleDL.InsertMappingRoleWithDepartmentandGroup(Master);
        }
        public List<Dropdown> GetGrouplist(int DepartmentId, int RoleId, string PartyId = null)
        {
            return objRoleDL.GetGrouplist(DepartmentId, RoleId, PartyId);
        }

        public List<Tree> TreeList(string partyId)
        {
            return objRoleDL.TreeList(partyId);
        }

        #region Notification Part
        public ResponseData GetNotificationMaster()
        {
            return objRoleDL.GetNotificationMaster();
        }

        public ResponseData SaveNotificationMaster(NotificationMaster notification)
        {
            return objRoleDL.SaveNotificationMaster(notification);
        }

        public ResponseData SaveNotificationTransactionAndUserList(NotificationTransectionUserListRequest notificationTransectionUserListRequest)
        {
            return objRoleDL.SaveNotificationTransactionAndUserList(notificationTransectionUserListRequest);
        }
        public ResponseData NotificationOperation(NotificationOperationRequest notificationOperation)
        {
            return objRoleDL.NotificationOperation(notificationOperation);
        }

        #endregion



    }
}

