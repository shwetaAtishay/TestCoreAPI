using BO;
using BO.Models;
using DL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL
{
    public class ServiceConfigBL
    {
        ServiceConfigDL objAdminDL = new ServiceConfigDL();
        public List<DepartmentTypeDocumentBO> GetServiceList()
        {
            return objAdminDL.GetServiceList();
        }
        public List<DepartmentTypeDocumentBO> GetDepartmentServiceList()
        {
            return objAdminDL.GetDepartmentServiceList();
        }
        public List<DepartmentTypeDocumentBO> GetDepartmentWiseServiceList(string district)
        {
            return objAdminDL.GetDepartmentWiseServiceList(district);
        }

        public List<setting> GetSetting()
        {
            return objAdminDL.GetSetting();
        }
        public List<CustomEnum> GetCustomEnum()
        {
            return objAdminDL.GetCustomEnum();
        }
        public List<ServiceTypeDocument> GetServiceByDepartmentId(int ID = 0, bool ActiveOnly = false, string SortBy = null, string SearchText = null)
        {
            return objAdminDL.GetServiceByDepartmentId(ID, ActiveOnly, SortBy, SearchText);
        }
        public List<ServiceTypeDocument> GetChildSubCategory(int ID = 0, bool ActiveOnly = false, string SortBy = null, string SearchText = null)
        {
            return objAdminDL.GetChildSubCategory(ID, ActiveOnly, SortBy, SearchText);
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
        public ResponseData InsertServices(CategoryMaster obj)
        {
            return objAdminDL.InsertServices(obj);

        }
        //public ResponseData InserGstApplicable(GSTApplicable obj)
        //{
        //    return objAdminDL.InserGstApplicable(obj);

        //}

        public List<CategoryMaster> GetServicesDetail(int Id)
        {
            return objAdminDL.GetServicesDetail(Id);
        }
        public ResponseData InsertRateMaster(RateMaster master)
        {
            return objAdminDL.InsertRateMaster(master);
        }

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
        public ChangeRquestDataList GetClientRequestData(string PartyId)
        {
            return objAdminDL.ChangeRequestList(PartyId);
        }
        public ResponseData SaveChangeRequest(string PartyId, string ParentId)
        {
            return objAdminDL.SaveChangeRequest(PartyId, ParentId);
        }

        public List<ClientRequestData> GetChangeRequestList(string PartyId)
        {
            return objAdminDL.GetChangeRequestList(PartyId);
        }

        public ResponseData RejectChangeRequest(string PartyId, string LoginId)
        {
            return objAdminDL.RejectChangeRequest(PartyId, LoginId);
        }

        public ResponseData ApprovedChangeRequest(string PartyId, string LoginId)
        {
            return objAdminDL.ApprovedChangeRequest(PartyId, LoginId);
        }

        #region AddNewServiceType

        public ResponseData InsertServiceType(ServiceTypeDocument obj)
        {
            return objAdminDL.InsertServiceType(obj);

        }
        public ResponseData UpdateChildServices(ServiceTypeDocument obj)
        {
            return objAdminDL.UpdateChildServices(obj);

        }
        public ResponseData InsertServicedepartMapping(ServiceTypeDocument obj)
        {
            return objAdminDL.InsertServicedepartMapping(obj);

        }
        public ResponseData InsertServiceDocument(ServiceTypeDocument obj)
        {
            return objAdminDL.InsertServiceDocument(obj);

        }
        public List<ServiceTypeDocument> GetServiceTypeDocument(string ID = "", bool ActiveOnly = false, string SortBy = null, string SearchText = null)
        {
            return objAdminDL.GetServiceTypeDocument(ID, ActiveOnly, SortBy, SearchText);
        }

        public List<ServiceTypeDocument> GetDocumentList(string ID = "", string ChildId = "", bool ActiveOnly = false, string SortBy = null, string SearchText = null)
        {
            return objAdminDL.GetDocumentList(ID, ChildId, ActiveOnly, SortBy, SearchText);
        }

        #endregion
        #region RateList
        public List<RateMaster> GetRateMasterList(int MstCategoryId, int SubMstCategoryId, int ChildCateId)
        {
            return objAdminDL.GetRateMasterList(MstCategoryId, SubMstCategoryId, ChildCateId);
        }
        #endregion
        #region
        public ResponseData UpdateColorServices(ServiceTypeDocument obj)
        {
            return objAdminDL.UpdateColorServices(obj);

        }
        #endregion
        #region DataServicelist
        public List<ServiceTypeDocument> GetDataServiceList(string ID = "")
        {
            return objAdminDL.GetDataServiceList(ID);
        }
        #endregion
        public List<ServiceTypeDocument> GetServiceListNew(string ID = "", bool ActiveOnly = false, string SortBy = null, string SearchText = null)
        {
            return objAdminDL.GetServiceListNew(ID, ActiveOnly, SortBy, SearchText);
        }
    }
}
