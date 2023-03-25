using BO.Models;
using BO;
using System;
using System.Collections.Generic;
using System.Text;
using DL;
using System.IO;
using System.Net;
using static BO.Models.TrusteeBO;

namespace BL
{
    public class TrusteeBL
    {
        TrusteeDL objAdminDL = new TrusteeDL();
        string sResponse = string.Empty;
        public ErrorBO SaveTrustee(TrusteeBO.Trustee _obj)
        {
            return objAdminDL.SaveTrustee(_obj);
        }
        public List<TrusteeBO.Trustee> TrusteeList(string TrustId)
        {
            return objAdminDL.TrusteeList(TrustId);
        }
        public ResponseData Women(string CollegeId, string TrustId)
        {
            return objAdminDL.WomenCount(CollegeId, TrustId);
        }
        public ResponseData IsPrime(string trustId, string CollegeId, string IsPrime)
        {
            return objAdminDL.IsPrimeStatus(trustId, CollegeId, IsPrime);
           
        }
        public List<TrusteeBO.TrusteeInfo> TrustInfoList()
        {
            return objAdminDL.TrustInfoList();
        }

        public TrusteeBO.Trustee DocumentDetail(string Id)
        {
            return objAdminDL.DocumentDetail(Id);
        }

        public ErrorBO SaveTrusteeInfo(TrusteeBO.TrusteeInfo _obj)
        {
            return objAdminDL.SaveTrusteeInfo(_obj);
        }
        public List<CustomList> GetTrustDropDownList()
        {
            return objAdminDL.GetTrustDropDownList();
        }
        public List<TrusteeBO.CollageList> CollageListApply(string TrustId)
        {
            return objAdminDL.CollageListApply(TrustId);
        }

        public ErrorBO AddCollageFacility(TrusteeBO.CollageFacility _obj)
        {
            return objAdminDL.AddCollageFacility(_obj);
        }

        public TrusteeBO.CollageFeeMst GetFeeDetailsList(TrusteeBO.CollageFeeMst _obj)
        {
            return objAdminDL.GetFeeDetailsList(_obj);
        }

        public ErrorBO AddCollageFee(TrusteeBO.CollageFeeMst _obj)
        {
            return objAdminDL.AddCollageFee(_obj);
        }


        public ResponseData addApplication(TrusteeBO.SaveApplicationModal modal)
        {
            return objAdminDL.addApplication(modal);
        }

        public TrusteeBO.CollageFacility GetCollageFacilityList(TrusteeBO.CollageFacility obj)
        {
            return objAdminDL.GetCollageFacilityList(obj);
        }

        public ErrorBO AddCollageAttachements(TrusteeBO.CollageAttachment modal)
        {
            return objAdminDL.AddCollageAttachements(modal);
        }
        public ResponseData AddCollageAttachementMain(TrusteeBO.CollageattachmentAPI modal)
        {
            return objAdminDL.AddCollageAttachementMain(modal);
        }

        public ErrorBO AddCollageAttachementFiles(TrusteeBO.DocumentsDetails modal)
        {
            return objAdminDL.AddCollageAttachementFiles(modal);
        }
        public ErrorBO TrustVerification(TrusteeBO.TrusteeInfo modal)
        {
            return objAdminDL.TrustVerification(modal);
        }
        public TrusteeBO.TrusteeInfo GetTrustInfo(TrusteeBO.TrusteeInfo modal)
        {
            return objAdminDL.GetTrustInfo(modal);
        }

        public ErrorBO DeleteTrustMemeber(int Id)
        {
            return objAdminDL.DeleteTrustMemeber(Id);
        }

        public ErrorBO TrustVerificationAPI(TrustRoot modal)
        {
            return objAdminDL.TrustVerificationAPI(modal);
            //return objAdminDL.TrustVerificationAPI();
        }

        public TrustRoot TrustAPI(string RegNo)
        {
            StreamReader readStream;
            TrustRoot _trustapi = new TrustRoot();
            string strAPI = "https://rajsahakarapp.rajasthan.gov.in/api/EntireSocietyDetail/GetSocietyDetailsByRegistrationNO?Reg_no=" + RegNo;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(strAPI);
            request.MaximumAutomaticRedirections = 4; // Set some reasonable limits on resources used by this request
            request.MaximumResponseHeadersLength = 4;
            //request.Credentials = CredentialCache.DefaultCredentials; // Set credentials to use for this request.
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream receiveStream = response.GetResponseStream(); // Get the stream associated with the response.
            readStream = new StreamReader(receiveStream, Encoding.UTF8); // Pipes the stream to a higher level stream reader with the required encoding format.
            sResponse = readStream.ReadToEnd();
            response.Close();
            //JavaScriptSerializer JsonSerializer = new JavaScriptSerializer();
            //AepsTransferBO.BankiINNoAEPS 
            _trustapi = System.Text.Json.JsonSerializer.Deserialize<TrustRoot>(sResponse);
            return _trustapi;
        }

        public ResponseData GETNOCApplicationList(int deptID)
        {
            return objAdminDL.GETNOCApplicationList(deptID);
            //return objAdminDL.TrustVerificationAPI();
        }

        public ResponseData GETNOCApplicationClgList(int deptID)
        {
            return objAdminDL.GETNOCApplicationClgList(deptID);
            //return objAdminDL.TrustVerificationAPI();
        }
        #region AddComments by Vivek
        public ResponseData AddComments(InspectionComments comments)
        {
            return objAdminDL.AddComments(comments);
        }
        #endregion

        public ErrorBO SaveOtherTrustDetails(TrusteeBO.TrusteeInfo _obj)
        {
            return objAdminDL.SaveOtherTrustDetails(_obj);
        }
        public List<CollegeAmendmentList> AmendmentCollege(string GUID)
        {
            return objAdminDL.CollageAmendment(GUID);
        }
        public List<CollegeAmendmentListEdit> ListEditCourse(int id)
        {
            return objAdminDL.GetEditData(id);
        }
        public ResponseData AddOldNOC(List<TrusteeBO.OldNOCData> oldNOCData)
        {
            return objAdminDL.AddOldNOC(oldNOCData);
        }

        public ResponseData SaveMultipleNOC(TrusteeBO.SaveApplicationModal model)
        {
            return objAdminDL.SaveMultipleNOC(model);
        }

        public List<CustomList> GetSubjectList(string sGUID, string CourseId)
        {
            return objAdminDL.GetSubjectList(sGUID, CourseId);
        }
        public List<CustomList> GetCourseList(string sGUID)
        {
            return objAdminDL.GetCourseList(sGUID);
        }
        public ResponseData InsertArchitechDetaile(List<Architecturesave> Mst)
        {
            return objAdminDL.InsertArchitechDetaile(Mst);
        }
        public ResponseData UpdateFeeForApplication(string applicationNumber, decimal totalFee)
        {
            return objAdminDL.UpdateFeeForApplication(applicationNumber, totalFee);
        }

        public List<CollageAttachment> GetCollageAttachment(string Guid)
        {
            return objAdminDL.GetCollageAttachment(Guid);
        }

        public string GetGUID(string Type, string TrustId, string ColgId, string DeptId, string CourseId = null)
        {
            return objAdminDL.GetGUID(Type, TrustId, ColgId, DeptId, CourseId);
        }
       
        public List<Architecturesave> GetArchitectureData(string sAppId, int Type)
        {

            return objAdminDL.GetArchitectureData(sAppId, Type);
        }
        public ResponseData ListDeleteCourse(int id)
        {
            return objAdminDL.RemoveData(id);
        }
        public TrusteeBO.Trustee GetFacilites(string GUID, int Identity)
        {
            return objAdminDL.GetFacilitesImagesList(GUID, Identity);

        }

        
        public ResponseData CheckDraftValidationForEntry(int clgID, string courses, string subjects)
        {
            return objAdminDL.CheckDraftValidationForEntry(clgID, courses, subjects);

        }
      
        public ResponseData GetCollegeDetailsForPreview(int clgID)
        {
            return objAdminDL.GetCollegeDetailsForPreview(clgID);

        }
    }
}
