using BO;
using BO.Models;
using DL;
using System;
using System.Collections.Generic;
using System.Text;
using static BO.Models.Partial;

namespace BL
{
    public class CommissionMasterBL
    {
        CommissionMasterDL objDL = new CommissionMasterDL();
        //public ResponseData InsertServiceProvider(Serviceprovider obj)
        //{
        //    return objDL.InsertServiceProvider(obj);
        //}
        //public List<Serviceprovider> GetServiceProvider(int Id)
        //{
        //    return objDL.GetServiceProvider(Id);
        //}
        //public ResponseData InsertServiceProviderrate(ServiceProviderRateconfiguration obj)
        //{
        //    return objDL.InsertServiceProviderrate(obj);
        //}
        //public List<ServiceProviderRateconfiguration> GetServiceProviderRate(int Id)
        //{
        //    return objDL.GetServiceProviderRate(Id);
        //}
        //public ResponseData InsertCommissionInformation(tbl_CommissionMaster obj)
        //{
        //    return objDL.InsertCommissionInformation(obj);
        //}
        //public List<tbl_CommissionMaster> GetCommissionMaster(int Id, string PartyId = null, int SpecialId = 1)
        //{
        //    return objDL.GetCommissionMaster(Id, PartyId, SpecialId);
        //}
        //public List<UserCommission> GetRechargeData(int OperaterId, int UserType, int OperaterNameEnum, int ServiceProviderEnum, int ServiceId, string PartyId, int Id)
        //{
        //    return objDL.GetRechargeData(OperaterId, UserType, OperaterNameEnum, ServiceProviderEnum, ServiceId, PartyId, Id);
        //}
        //public List<UserCommission> GenerateRechargesUserWise(int OperaterId, int UserType, int OperaterNameEnum, int ServiceProviderEnum, int ServiceId, string PartyId, int Id)
        //{
        //    return objDL.GenerateRechargesUserWise(OperaterId, UserType, OperaterNameEnum, ServiceProviderEnum, ServiceId, PartyId, Id);
        //}

        public ResponseData InsertRechargeData(int OperaterId, int UserType, int ServiceId, string PartyId, int Id, string IsdefaultPartyId)
        {
            return objDL.InsertRechargeData(OperaterId, UserType, ServiceId, PartyId, Id, IsdefaultPartyId);
        }
        public ResponseData InsertUserRechargeData(int OperaterId, int UserType, int ServiceId, string PartyId, int Id, string IsdefaultPartyId)
        {
            return objDL.InsertUserRechargeData(OperaterId, UserType, ServiceId, PartyId, Id, IsdefaultPartyId);
        }
        public List<Dropdown> GetPartyInformationBasedonParentId(int Type, string PartyId)
        {
            return objDL.GetPartyInformationBasedonParentId(Type, PartyId);
        }
        public ResponseData Changestatus(Commisssiondata Master)
        {
            return objDL.Changestatus(Master);
        }

        public ResponseData ServiceProviderChangeStatus(string TableId, int Id, int Type)
        {
            return objDL.ServiceProviderChangeStatus(TableId, Id, Type);
        }
        public ResponseData Admin_SlabData_Mst_Save(SLBMST master)
        {
            return objDL.Admin_SlabData_Mst_Save(master);
        }
        public List<SLBMST> Admin_SlabData_Mst_Show(int Id)
        {
            return objDL.Admin_SlabData_Mst_Show(Id);
        }
        public ResponseData Admin_SlabData_Mst_Update(string Type, int Id, int status)
        {
            return objDL.Admin_SlabData_Mst_Update(Type, Id, status);
        }
        public List<CustomList> GetServiceProviderBaseonServiceId(int ServiceId)
        {
            return objDL.GetServiceProviderBaseonServiceId(ServiceId);
        }
        //public ResponseData Admin_AEPS_Commission_Save(UserCommission master)
        //{
        //    return objDL.Admin_AEPS_Commission_Save(master);
        //}
        //public List<UserCommission> Admin_AEPS_Commission_Show(int ServiceProviderid, int CommissionMasterId)
        //{
        //    return objDL.Admin_AEPS_Commission_Show(ServiceProviderid, CommissionMasterId);
        //}
        //public List<ApesSetCommission> Admin_Set_APesCommission_All_Show(string PartyId, int ServiceId, string DefaultParty)
        //{
        //    return objDL.Admin_Set_APesCommission_All_Show(PartyId, ServiceId, DefaultParty);
        //}
        public List<Dropdown> USP_List_ClientInfo_Of_Admin()
        {
            return objDL.USP_List_ClientInfo_Of_Admin();
        }

        //Announcement
        public ResponseData Admin_News_Announcement_Save(NEWANNMST master)
        {
            return objDL.Admin_News_Announcement_Save(master);
        }
        public List<NEWANNMST> Admin_News_Announcement_Show(int Type, int ShowType)
        {
            return objDL.Admin_News_Announcement_Show(Type, ShowType);
        }
    }
}
