using BO;
using BO.Models;
using DL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL
{
    public class MasterBL
    {
        MasterDL objMasterDL = new MasterDL();
        public ResponseData SaveNOCDepartMapping(NOCDEPMAP master)
        {
            return objMasterDL.UpdateNocDepartmentMapping(master);
        }
        public List<Dropdown> GetNOCDepartmentsName(int Type)
        {
            return objMasterDL.GetNOCDepartmentsName(Type);
        }
        public List<NOCDEPMAP> GetNOCDepartMaplst(int Departid)
        {
            return objMasterDL.GetNOCDepartMaplst(Departid);
        }
        public ResponseData InsertParameterCategoryMapping(PARAMCAT master)
        {
            return objMasterDL.InsertParameterCategoryMapping(master);
        }
        public List<Dropdown> GetPerameterCategoryList(int Type, int Deptid, int iFk_SelfId, int EnumId)
        {
            return objMasterDL.GetPerameterCategoryList(Type, Deptid, iFk_SelfId, EnumId);
        }
        public List<PARAMCAT> GetPerameterTableList(int Type, int Deptid, int iFk_SelfId, int EnumId)
        {
            return objMasterDL.GetPerameterTableList(Type, Deptid, iFk_SelfId, EnumId);
        }
        public List<Dropdown> GetCategorySubUOM(int Deptid, int Category, int SubCategory, string Table)
        {
            return objMasterDL.GetCategorySubUOM(Deptid, Category, SubCategory, Table);
        }
        public ResponseData InsertParameterValueConfiguration(PARMTVALUCONFMST Master)
        {
            return objMasterDL.InsertParameterValueConfiguration(Master);
        }
        public List<PARMTVALUCONFMSTView> SelectParameterValueConfiguration(int Id, int EnumId, int CourseEnumId, string Appid)
        {
            return objMasterDL.SelectParameterValueConfiguration(Id, EnumId, CourseEnumId, Appid);
        }
        public ResponseData InsertArchitectureDetail(ArchiMstDetail Master)
        {
            return objMasterDL.InsertArchitectureDetail(Master);
        }
        public List<ArchiMstDetail> GenerateArchtable(int iParamId, int iSubCatId, int iUomId, string sAppId)
        {
            return objMasterDL.GenerateArchtable(iParamId, iSubCatId, iUomId, sAppId);
        }
        public List<ArchiMstDetail> BuildalltabelArchitecture(string sAppId)
        {
            return objMasterDL.BuildalltabelArchitecture(sAppId);
        }
        public ResponseData DeleteArchiMstDet(int Id)
        {
            return objMasterDL.DeleteArchiMstDet(Id);
        }
        public ResponseData InsertArchitectureMst(ArchitectureMst Mst)
        {
            return objMasterDL.InsertArchitectureMst(Mst);
        }
        public ResponseData InsertArchupload(ArchUpload Mst)
        {
            return objMasterDL.InsertArchupload(Mst);
        }
        public List<ArchiMstDetail> AllGenerateArchtable(string sAppId)
        {
            return objMasterDL.AllGenerateArchtable(sAppId);
        }
        public ResponseData UploadReceipt(UploadReceipt receipt)
        {
            return objMasterDL.UploadReceipt(receipt);
        }

        public ResponseData GetFinYearList()
        {
            return objMasterDL.GetFinYearList();
        }

        public ResponseData InsertFinYear(FinYear obj)
        {
            return objMasterDL.InsertFinYear(obj);
        }
        public ResponseData InsertEvent(EventMstSave Mst)
        {
            return objMasterDL.InsertEvent(Mst);
        }
        public List<EVNTMST> Event_View(int iFk_DeptId)
        {
            return objMasterDL.Event_View(iFk_DeptId);
        }
        public List<Dropdown> FillDropDown(int Id, string Type, string PartyId)
        {
            return objMasterDL.FillDropDown(Id, Type, PartyId);
        }
        public ResponseData InsertCommiteeMster(CommiteeMaster Mst)
        {

            return objMasterDL.InsertCommiteeMster(Mst);
        }
        public List<CommiteeMaster> GetCommiteeList(int Id)
        {
            return objMasterDL.GetCommiteeList(Id);
        }

        public List<CommitedMstview> GetCommentTable(InspectionComments Mst)
        {
            return objMasterDL.GetCommentTable(Mst);
        }
        public ResponseData SaveComment(InspectionComments Mst)
        {

            return objMasterDL.SaveComment(Mst);
        }
        public List<Dropdown> GetApplicationData(int Deptid, int ApplicationId,int NOCDeptId)
        {
            return objMasterDL.GetApplicationData(Deptid, ApplicationId, NOCDeptId);
        }
        public ResponseData InsertFee(CompleteFeeMaster Mst)
        {
            return objMasterDL.InsertFee(Mst);
        }
        public ResponseData AddTrackingData(TrackingData track)
        {

            return objMasterDL.AddTrackingData(track);
        }

        //Added For Saving the Darft application by Vivek 10.02.2023
        public ResponseData AddDeptMSTAppData(List<TrusteeBO.DeptMasterApp> deptMasters)
        {

            return objMasterDL.AddDeptMSTAppData(deptMasters);
        }

        public ResponseData AddDeptMSTAppDataNewCollege(int clgID, string clgName, string appType)
        {

            return objMasterDL.AddDeptMSTAppDataNewCollege(clgID, clgName, appType);
        }
     
        public ResponseData GetNewCollegeDetails(int clgID)
        {

            return objMasterDL.GetNewCollegeDetails(clgID);
        }
        public List<CourserBind> GetApplicationCourse(string sGuid, int Courseid)
        {
            return objMasterDL.GetApplicationCourse(sGuid, Courseid);
        }
      
        public List<CourserBind> GetOtherBind(string sGuid)
        {
            return objMasterDL.GetOtherBind(sGuid);
        }

        public ResponseData UploadMasterPaymentReceipt(UploadMasterReceipt receipt)
        {
            return objMasterDL.UploadMasterPaymentReceipt(receipt);
        }
        public List<FeeMst> GetFeeMstList(int Id)
        {
            return objMasterDL.GetFeeMstList(Id);
        }
        public List<FeeTRN> GetFeeTRNList(int Id)
        {
            return objMasterDL.GetFeeTRNList(Id);
        }
    }
}
