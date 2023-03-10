using BO;
using BO.Models;
using DL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL
{
    public class AdminBL
    {
        AdminDL objAdminDL = new AdminDL();

        public List<setting> GetSetting()
        {
            return objAdminDL.GetSetting();
        }
        public List<CustomEnum> GetCustomEnum()
        {
            return objAdminDL.GetCustomEnum();
        }
        public int InsertNewCustomEnumRow(int Id)
        {
            return objAdminDL.InsertNewCustomEnumRow(Id);
        }
        public int DeleteCustomSentence(int Id)
        {
            return objAdminDL.DeleteCustomSentence(Id);
        }
        public int UpdateSubjectLines(int Id, string Text)
        {
            return objAdminDL.UpdateSubjectLines(Id, Text);
        }
        public List<CustomList> GetServiceByDepartmentId(int Enumno = 0)
        {
            return objAdminDL.GetCustomList(Enumno);
        }
        public List<CustomList> GetChargesType(long ServiceId = 0)
        {
            return objAdminDL.GetChargesType(ServiceId);
        }
        //public List<GSTApplicable> GetApplicableGstDetails()
        //{
        //    return objAdminDL.GetApplicableGstDetails();
        //}
        #region 2
        //public ResponseData InsertServices(CategoryMaster obj)
        //{
        //    return objAdminDL.InsertServices(obj);

        //}
        public ResponseData InsertServices(SRVCMST obj)
        {
            return objAdminDL.InsertServices(obj);

        }
        #endregion

        #region 3
        //public ResponseData InserGstApplicable(GSTApplicable obj)
        //{
        //    return objAdminDL.InserGstApplicable(obj);

        //}
        //public ResponseData InserGstApplicable(GSTApplicable obj)
        //{
        //    return objAdminDL.InserGstApplicable(obj);

        //}
        #endregion

        //public List<CategoryMaster> GetServicesDetail(int Id)
        //{
        //    return objAdminDL.GetServicesDetail(Id);
        //}

        public List<SRVCMST> GetServicesDetail(int Id)
        {
            return objAdminDL.GetServicesDetail(Id);
        }

        #region 4
        //public ResponseData InsertRateMaster(RateMaster master)
        //{
        //    return objAdminDL.InsertRateMaster(master);
        //}
        public ResponseData InsertRateMaster(RateMaster master)
        {
            return objAdminDL.InsertRateMaster(master);
        }
        #endregion
        public List<ShowRateMaster> GetRateMasterDetail()
        {
            return objAdminDL.GetRateMasterDetail();
        }
        public List<GlobalClass> GetGeographicalData(int Id, int districtId, int Type)
        {
            return objAdminDL.GetGeographicalData(Id, districtId, Type);
        }
        public ResponseData ChangeStatus(Activeclass master)
        {
            return objAdminDL.ChangeStatus(master);
        }

        //public List<PandingPaymentList> PaymentPendingList(string stringpara)
        //{
        //    return objAdminDL.PaymentPendingList(stringpara);
        //}
        //public PartyProfile GetPartyDetails(PartyProfile obj)
        //{
        //    return objAdminDL.GetPartyDetails(obj);
        //}

        //public PartyPaymentCollect GetPartyPaymentCollectionByPartyId(PandingPaymentList obj)
        //{
        //    return objAdminDL.GetPartyPaymentCollectionByPartyId(obj);
        //}
        //public ResponseData SavePaymentCollection(PaymentCollectionModel obj)
        //{
        //    return objAdminDL.SavePaymentCollection(obj);
        //}

        //public List<PandingPaymentList> ChequePendingList(string obj)
        //{
        //    return objAdminDL.ChequePendingList(obj);
        //}
        //public ResponseData ChequeClear(PaymentCollectionModel obj)
        //{
        //    return objAdminDL.ChequeClear(obj);
        //}

        //public List<PandingPaymentList> ChequeUnClearedList(string obj)
        //{
        //    return objAdminDL.ChequeUnClearedList(obj);
        //}
        //public ResponseData ChequeUnClear(PaymentCollectionModel obj)
        //{
        //    return objAdminDL.ChequeUnClear(obj);
        //}

        //public ResponseData ChequeCancel(PaymentCollectionModel obj)
        //{
        //    return objAdminDL.ChequeCancel(obj);
        //}

        #region Company Consumption AddedBy : Shipra Garg
        //public CompanyConsumptionList ServiceProviderWiseConsumptionList()
        //{
        //    return objAdminDL.ServiceProviderWiseConsumptionList();
        //}

        //public ErrorBO ConsumptionRequest(CompanyConsumption BOobj)
        //{
        //    return objAdminDL.ConsumptionRequest(BOobj);
        //}
        #endregion

        #region Change Request Approved from Admin and Setalment Process AddedBy: Shipra Garg
        public ChangeRquestDataList GetClientRequestData(string PartyId, int PartyType = 0)
        {
            return objAdminDL.ChangeRequestList(PartyId, PartyType);
        }
        public ResponseData SaveChangeRequest(string PartyId, string ParentId)
        {
            return objAdminDL.SaveChangeRequest(PartyId, ParentId);
        }

        public List<ClientRequestData> GetChangeRequestList(string PartyId)
        {
            return objAdminDL.GetChangeRequestList(PartyId);
        }

        //public List<ClientSwitchRequestData> GetChangeRequestListNew(string PartyId)
        //{
        //    return objAdminDL.GetChangeRequestListNew(PartyId);
        //}

        public ResponseData RejectChangeRequest(string PartyId, string LoginId)
        {
            return objAdminDL.RejectChangeRequest(PartyId, LoginId);
        }

        public ResponseData ApprovedChangeRequest(string PartyId, string LoginId)
        {
            return objAdminDL.ApprovedChangeRequest(PartyId, LoginId);
        }


        #endregion
        //public ClientSwitchRequestData GetChangeRequestData(string PartyId, string LoginId)
        //{
        //    return objAdminDL.GetChangeRequestData(PartyId, LoginId);
        //}

        public SelectedList SelectList(ListRequest ObjReq)
        {
            return objAdminDL.SelectList(ObjReq);
        }

        public List<AddCourseBO> FacilityDetails(string GUID)
        {
            return objAdminDL.FacilityDetails(GUID);
        }
        //public ErrorBO SwitchParent(SwitchVendor BOobj)
        //{
        //    return objAdminDL.SwitchParent(BOobj);
        //}
        public ResponseData GetFacilites()
        {
            return objAdminDL.GetFacilitesList();
        }
        public List<AddCourseBO> GetId(string GUID)
        {
            return objAdminDL.GetIdDetails(GUID);
        }
    }
}
