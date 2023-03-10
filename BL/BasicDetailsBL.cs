using BO;
using BO.Models;
using DL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL
{
    public class BasicDetailsBL
    {
        BasicDetailDL objBasicDetailDL = new BasicDetailDL();

        public ResponseData BasicDetailConfigure(BasicDetails master)
        {
            return objBasicDetailDL.BasicDetailConfigure(master);
        }
        public ResponseData GetCollageDropDownList(int TrustInfoId)
        {
            return objBasicDetailDL.GetCollageDropDownList(TrustInfoId);
        }
        public ResponseData GetAdminApplication(string applGuid)
        {
            return objBasicDetailDL.GetAdminApplication(applGuid);
        }

        public ResponseData GetDarftApplications(string applGuid, string trustID)
        {
            return objBasicDetailDL.GetDarftApplications(applGuid,trustID);
        }
        public ResponseData GetApplicationsToUploadReceipt(string applGuid)
        {
            return objBasicDetailDL.GetApplicationsToUploadReceipt(applGuid);
        }
        public ResponseData CancleDarftApplications(string applGUID, string Creason)
        {
            return objBasicDetailDL.CancleDarftApplications(applGUID,Creason);
        }
        public BasicDetails GetCollageDetails(int Id)
        {
            return objBasicDetailDL.GetCollageDetails(Id);
        }
        public ResponseData UpdateCollageDetails(BasicDetails master)
        {
            return objBasicDetailDL.UpdateCollageDetails(master);
        }
        //Report BL
        public ResponseData GetReportApplication(string applGuid)
        {
            return objBasicDetailDL.GetReportApplication(applGuid);
        }
        //Application tracking
        public ResponseData GetApplicationtracking(string applGuid)
        {
            return objBasicDetailDL.GetApplicationtracking(applGuid);
        }
        public ResponseData DepartmentapplicationList(string applGuid)
        {
            return objBasicDetailDL.DepartmentapplicationList(applGuid);
        }
        public ResponseData GetSUbject(int colId, int couId, string DataType, string subjectlist = null)
        {
            return objBasicDetailDL.GetSUbject(colId, couId, DataType, subjectlist);
        }
        public ResponseData GetCollageDropDownListbytrustId(int Id, int trustid)
        {
            return objBasicDetailDL.GetCollageDropDownListbytrustId(Id, trustid);
        }
    }
}
