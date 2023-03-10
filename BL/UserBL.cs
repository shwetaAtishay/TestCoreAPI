using BO;
using BO.Models;
using DL;
using System;
using System.Collections.Generic;
using System.Text;
using static BO.Models.Partial;

namespace BL
{
    public class UserBL
    {
        UserDL objUserDL = new UserDL();
        #region abhishek
        public List<PartyMaster> GetPartyDetail(string Id)
        {
            return objUserDL.GetPartyDetail(Id);
        }
        public ResponseData UpdatePartyMaster(PartyMaster master)
        {
            return objUserDL.UpdatePartyMaster(master);
        }
        public List<Documentlist> GetUploadDocumentlist(string Id)
        {
            return objUserDL.GetUploadDocumentlist(Id);
        }
        public List<RegistratedUser> GetRegistratedUsers()
        {
            return objUserDL.GetRegistratedUsers();
        }
        public List<ACtivedServicesHardwarelist> GetActivedServicesandHardwareList(string Id)
        {
            return objUserDL.GetActivedServicesandHardwareList(Id);
        }
        public List<PayTracking> GetPayTrackings(string Id)
        {
            return objUserDL.GetPayTrackings(Id);
        }
        #endregion
        #region vivek
        public List<CustomList> GetServiceByDepartmentId(int Enumno = 0)
        {
            return objUserDL.GetCustomList(Enumno);
        }



       
        public ResponseData Login(Login login)
        {
            return objUserDL.Login(login);
        }

        public ResponseData ResetPassword(ResetPassword reset)
        {
            return objUserDL.ResetPassword(reset);
        }
        public ResponseData GetServicesDetails()
        {
            return objUserDL.GetServicesDetails();
        }

        public ResponseData GetServicesDetailsAndroid()
        {
            return objUserDL.GetServicesDetailsAndroid();
        }
        public ResponseData GetServices()
        {
            return objUserDL.GetServices();
        }

        //public ResponseData GethardwareForService(string services)
        //{
        //    return objUserDL.GethardwareForService(services);
        //}

        public ResponseData GetdetailsForUser(string email)
        {
            return objUserDL.GetdetailsForUser(email);
        }

        public ResponseData RegisteredUserData()
        {
            return objUserDL.RegisteredUserData();
        }

        public ResponseData ActiveInactiveUser(string PartyId, string status)
        {
            return objUserDL.ActiveInactiveUser(PartyId, status);
        }
        public ResponseData UpdateVerificationStatus(string PartyId, string colName, string colValue, int status)
        {
            return objUserDL.UpdateVerificationStatus(PartyId, colName, colValue, status);
        }

        
        
        public ResponseData SaveAadhaarData(AadharWithPartyId aadhar)
        {
            return objUserDL.SaveAadhaarData(aadhar);
        }

        public ResponseData SavePurchaseData(AddPurchase purchase)
        {
            return objUserDL.SavePurchaseData(purchase);
        }

        public ResponseData SaveContentData(ContentPage content)
        {
            return objUserDL.SaveContentData(content);
        }
        public ResponseData EditContentData(ContentPage content)
        {
            return objUserDL.EditContentData(content);
        }


        //public ResponseData MyPayment(string PartyId)
        //{
        //    return objUserDL.MyPayment(PartyId);
        //}
        public ResponseData MyPaymentOnScroll(int pageNumber, int pageSize, string PartyId)
        {
            return objUserDL.MyPaymentOnScroll(pageNumber, pageSize, PartyId);
        }

        public ResponseData GetCategoryAllInformation(string Type)
        {
            return objUserDL.GetCategoryAllInformation(Type);
        }
        public ResponseData GetUserType()
        {
            return objUserDL.GetUserType();
        }
        public ResponseData SaveGeographical(GeographicalMaster graphical)
        {
            return objUserDL.SaveGeoGraphical(graphical);
        }
        public ResponseData GetGeographical(GeographicalMaster graphical)
        {
            return objUserDL.GetGeoGraphical(graphical);
        }

        public ResponseData GetDocumentLibraryData(string Type, int companyId)
        {
            return objUserDL.GetDocumentLibraryData(Type, companyId);
        }

        public ResponseData SaveDocumentList(List<DocumentLibraryMaster> documents)
        {
            return objUserDL.SaveDocumentList(documents);
        }
        public ResponseData GetGeoGraphicalList()
        {
            return objUserDL.GetGeoGraphicalList();
        }

        public UploadDoc UploadRequiredDocuments(UploadDoc doc)
        {
            return objUserDL.UploadRequiredDocuments(doc);
        }


        public ResponseData GetAllSettings(string Id = null)
        {
            return objUserDL.GetAllSettings(Id);
        }

        public ResponseData UpdateSetting(Settings settings)
        {
            return objUserDL.UpdateSetting(settings);
        }

        public ResponseData GetPermissionDetails(int RoleId, int DepartmentId)
        {
            return objUserDL.GetPermissionDetails(RoleId, DepartmentId);
        }
        public ResponseData GetMenusAndSubmenus(string Type, string MenuId, string PartyId)
        {
            return objUserDL.GetMenusAndSubmenus(Type, MenuId, PartyId);
        }
        public ResponseData UpdateDisplayID(string ID)
        {
            return objUserDL.UpdateDisplayID(ID);
        }

        public ResponseData AddGroup(AddGroup group)
        {
            return objUserDL.AddGroup(group);
        }

        public ResponseData AddDepartment(AddDepartment department)
        {
            return objUserDL.AddDepartment(department);
        }
        public ResponseData GetAadhaarData(string partyID)
        {
            return objUserDL.GetAadhaarData(partyID);
        }

        public ResponseData AddPartnerDetails(PartyMaster party)
        {
            return objUserDL.AddPartnerDetails(party);
        }
        public ResponseData AddSystemUserDetails(PartyMaster party)
        {
            return objUserDL.AddSystemUserDetails(party);
        }
        public ResponseData AddAPIReqRes(APIReqResModal aPIReqRes)
        {
            return objUserDL.AddAPIReqRes(aPIReqRes);
        }
        public ResponseData SaveTransection(TransectionMasterRequest transectionMasterRequest)
        {
            return objUserDL.SaveTransection(transectionMasterRequest);
        }

        public ResponseData UpdateSoldPriceForTransection(string transectionId, decimal rechargePrice)
        {
            return objUserDL.UpdateSoldPriceForTransection(transectionId, rechargePrice);
        }

        public ResponseData GetCommissionRate(string partyID, int PartyType, int operatorId, int serviceId, int serviceProviderId)
        {
            return objUserDL.GetCommissionRate(partyID, PartyType, operatorId, serviceId, serviceProviderId);
        }

        public ResponseData GetCommissionDistribution()
        {
            return objUserDL.GetCommissionDistribution();
        }

        public ResponseData GetTransections()
        {
            return objUserDL.GetTransections();
        }
        public ResponseData AddUpdateSSO(SSOUserDetail userDetail)
        {
            return objUserDL.AddUpdateSSO(userDetail);
        }
        #endregion

        #region Pravin Pawar
        public ResponseData GetDept()
        {
            return objUserDL.GetDept();
        }
        public ResponseData GetCourses(int Id)
        {
            return objUserDL.GetCourses(Id);
        }
        public ResponseData SaveDeptCourseMap(DeptCourseMap mapping)
        {
            return objUserDL.SaveDeptCourseMap(mapping);
        }
        public ResponseData GetDeptMappingData()
        {
            return objUserDL.GetDeptMappingData();
        }


        // For Academic master

        public ResponseData GetYear()
        {
            return objUserDL.GetYear();
        }
        public ResponseData GetResult()
        {
            return objUserDL.GetResult();
        }

        public ResponseData SaveAcdmcMst(AcdmcMst mapping)
        {
            return objUserDL.SaveAcdmcMst(mapping);
        }
        public ResponseData GetAcdmcData(string GUIID, int clgID)
        {
            return objUserDL.GetAcdmcData(GUIID,clgID);
        }

        public ResponseData GetModule()
        {
            return objUserDL.GetModule();
        }
        public ResponseData GetFunctionality()
        {
            return objUserDL.GetFunctionality();
        }

        public ResponseData SaveSupportTicket(SupportTicket ticket)
        {
            return objUserDL.SaveSupportTicket(ticket);
        }

        public ResponseData GetUniversities()
        {
            return objUserDL.GetUniversities();
        }

        public ResponseData SaveUniversitesDeptMap(UniversitiesDept mapping)
        {
            return objUserDL.SaveUniversitesDeptMap(mapping);
        }
        public ResponseData GetUniversitiesData()
        {
            return objUserDL.GetUniversitiesData();
        }



        #endregion


        public ResponseData GetGeoGraphicalData(GeoLocationMaster graphical)
        {
            return objUserDL.GetGeoGraphicalData(graphical);
        }

        public ResponseData GetUserSendbackForward(string MenuId, string PartyId)
        {
            return objUserDL.GetUserSendbackForward(MenuId, PartyId);
        }
        public ResponseData GetCourseData()
        {
            return objUserDL.GetCourseData();
        }
        public ResponseData GetSubjects()
        {
            return objUserDL.GetSubjects();
        }

        public ResponseData GetACDMCDataEdit(int AcdmcId)
        {
            return objUserDL.GetACDMCDataEdit(AcdmcId);
        }
        public ResponseData GetACDMCDataDelete(int AcdmcId)
        {
            return objUserDL.GetACDMCDataDelete(AcdmcId);
        }
        
        public ResponseData CheckSSO(string sso)
        {
            return objUserDL.CheckSSO(sso);
        }
    }
}
