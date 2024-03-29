﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BO.Models
{
    public class TrusteeBO
    {
        public class TrusteeInfo : ErrorBO
        {
            public string TrusteeInfoId { get; set; }
            public string ApplicantId { get; set; }
            public string Name { get; set; }
            public string TrustType { get; set; }
            public string CertiFiedBy { get; set; }
            public string RegistrationNo { get; set; }
            public string RegistrationDate { get; set; }
            public string ElectionDate { get; set; }
            public string Certified { get; set; }
            public string CeritifiedExtension { get; set; }
            public string CeritifiedbyContenttype { get; set; }
            public string Registration { get; set; }
            public string RegistrationExtension { get; set; }
            public string RegistrationContenttype { get; set; }
            public string TrusteeLogo { get; set; }
            public string TrusteeExtension { get; set; }
            public string TrusteeContentType { get; set; }
            public string TRMP { get; set; }
            public string TRMPExtension { get; set; }
            public string TRMPContenttype { get; set; }
            public string Email { get; set; }
            public string Mobile { get; set; }
            public string AadhaarNo { get; set; }
            public string JanAadhaarNo { get; set; }
            public string PAN { get; set; }


            public string SocietyName { get; set; }
            public object BRN { get; set; }
            public string SSOID { get; set; }
            public string TotalNumberOfMembers { get; set; }
            public string District { get; set; }
            public string Act { get; set; }
            public string Status { get; set; }
            public List<AdministrativeDatum> AdminList { get; set; }
            public string MemberofMngCommtee { get; set; }
            public string Morethentree { get; set; }
            public string OtherInstitute { get; set; }
            public List<InstituteDetails> InstituteDetails { get; set; }

            public string TAN { get; set; }
            public string Address { get; set; }
            public string Panfile { get; set; }
            public string PanExtension { get; set; }
            public string PanContenttype { get; set; }
            public string Aadhaarfile { get; set; }
            public string AadhaarExtension { get; set; }
            public string AadhaarContenttype { get; set; }
            public string LogoCreateDated { get; set; }
            public string TrustMembercreatedate { get; set; }

        }
        public class InstituteDetails
        {
            public string InstituteName { get; set; }
            public string Number { get; set; }
            public string ContactPerson { get; set; }
        }
        public class Trustee : ErrorBO
        {
            public string Id { get; set; }
            public string TrustInfoId { get; set; }
            public string trustName { get; set; }
            public string Name { get; set; }
            public string RoleId { get; set; }
            public string Mobile { get; set; }
            public string Email { get; set; }
            public string AadhaarNo { get; set; }
            public string PanNo { get; set; }
            public string Aadhaar { get; set; }

            public string AadhaarExtension { get; set; }
            public string AadhaarContentType { get; set; }
            public string Pan { get; set; }
            public string PanExtension { get; set; }
            public string PanContentType { get; set; }
            public string ProfileImg { get; set; }
            public string ProfileExtension { get; set; }
            public string ProfileContentType { get; set; }
            public byte[] DocumentByte { get; set; }
            public string Profilefile { get; set; }
            public string isPrimary { get; set; }
            public string isAuthorize { get; set; }
            public string Authorized { get; set; }
            public string AuthorizedExtension { get; set; }
            public string AuthorizedContentType { get; set; }
            
            //Add new Param11 march
            public string OccupationId { get; set; }
            public string GenderId { get; set; }
            public string FatherName { get; set; }
            public string CollageId { get; set; }
            public string CollageName { get; set; }
            public string Educationfile { get; set; }
            public string EducationfileExtension { get; set; }
            public string EducationfileContentType { get; set; }

            public string Letterfile { get; set; }
            public string LetterfileExtension { get; set; }
            public string LetterfileContentType { get; set; }

            public string signaturefile { get; set; }
            public string signaturefileExtension { get; set; }
            public string signaturefileContentType { get; set; }
            public decimal FemaleCota { get; set; }

        }

        public class CollageList : ErrorBO
        {
            public string CollageId { get; set; }
            public string TrustInfoId { get; set; }
            public string TrustName { get; set; }
            public string TrustRegistrationNo { get; set; }
            public string CollageName { get; set; }
            public string MobileNo { get; set; }
            public string Email { get; set; }
            public string CollageLogo { get; set; }
            public string CollageContectType { get; set; }
            public string AddMobileNo { get; set; }
            public string AddPhoneNo { get; set; }
            public string WebsiteURL { get; set; }
            public string Degree { get; set; }
            public int DegreeID { get; set; }
            public string Courses { get; set; }
            public int CoursesID { get; set; }
            public string CollegeMedium { get; set; }
            public string CollegeLevel { get; set; }
            public string AddressLineOne { get; set; }
            public string AddressLineTwo { get; set; }
            public string DistrictName { get; set; }
            public string TehsilName { get; set; }
            public string BlockName { get; set; }
            public string CityName { get; set; }
            //public int CoursesID { get; set; }
            public int RuralType { get; set; }
            public string AreaType { get; set; }
            public string CollegeType { get; set; }
            public int IsDraft { get; set; }
            public int IsTNOC { get; set; }
            public int IsPNOC { get; set; }
        }

        public class CollageFacility
        {
            public int? TrustId { get; set; }
            public int? CollageId { get; set; }
            public string Guid { get; set; }
            public List<Facilty> list { get; set; }
        }

        public class Facilty
        {
            public string FacilityId { get; set; }
            public string FacilityName { get; set; }
            public bool IsSelect { get; set; }
            public string uploadFile { get; set; }
            public string Extension { get; set; }
            public string ContentType { get; set; }
        }

        public class FaciltyAdd
        {
            public string TrustId { get; set; }
            public string CollageId { get; set; }
            public string FacilityId { get; set; }
            public bool IsSelect { get; set; }
            public string uploadFile { get; set; }
            public string Extension { get; set; }
            public string ContentType { get; set; }
        }

        public class CollageFeeMst
        {
            public string TrustId { get; set; }
            public string CollageId { get; set; }
            public string DepartmentId { get; set; }
            public string CourseId { get; set; }
            public string FinancialYear { get; set; }
            public string ApplicationNumber { get; set; }
            public string Guid { get; set; }
            public List<RateList> rateLists { get; set; }
            //public string Id { get; set; }
            //public decimal Rate { get; set; }
            //public string RateName { get; set; }
            //public int IsActive { get; set; }
        }

        public class RateList
        {
            public string RateId { get; set; }
            public string RateName { get; set; }
            public bool IsSelect { get; set; }
            public decimal Rate { get; set; }
        }

        public class CollageAttachment
        {
            public int iPk_Id { get; set; }
            public int iFk_TrstId { get; set; }
            public int iFk_ClgId { get; set; }
            public string sSSOID { get; set; }
            public int CourseId { get; set; }
            public int bIsCnnctUnvrctyDrctn { get; set; }
            //public HttpPostedFileBase bIsCnnctUnvrctyDrctnfile { get; set; }
            public int bIsTimeFrm { get; set; }
            //public HttpPostedFileBase bIsTimeFrmfile { get; set; }
            public int bIsLadDwn { get; set; }
            //public HttpPostedFileBase bIsLadDwnfile { get; set; }
            public int bIsSffcentLand { get; set; }
            //public HttpPostedFileBase bIsSffcentLandfile { get; set; }
            public int bIsAffidvtAsprGuid { get; set; }
            //public HttpPostedFileBase bIsAffidvtAsprGuidfile { get; set; }
            public int bIsOtherDoc { get; set; }
            //public HttpPostedFileBase bIsOtherDocfile { get; set; }
            public string sCrtdBy { get; set; }
            public DateTime? dtCrtdDt { get; set; }
            public string sUpdtBy { get; set; }
            public DateTime? dtUpdDt { get; set; }
            public string iFk_sAplcnNo { get; set; }

            public string EnumNo { get; set; }
            //public HttpPostedFileBase affidavit { get; set; }
            //public HttpPostedFileBase SalaryPayment { get; set; }
            //public HttpPostedFileBase Bankstatement { get; set; }
            //public HttpPostedFileBase Annexure { get; set; }
            //public HttpPostedFileBase EsiDoc { get; set; }


            public string bIsCnnctUnvrctyDrctfiles { get; set; }
            public string bIsCnnctUnvrctyDrctExtension { get; set; }
            public string bIsCnnctUnvrctyDrctContent { get; set; }

            public string bIsTimeFrmfiles { get; set; }
            public string bIsTimeFrmExtension { get; set; }
            public string bIsTimeFrmContent { get; set; }

            public string bIsLadDwnfiles { get; set; }
            public string bIsLadDwnExtension { get; set; }
            public string bIsLadDwnContent { get; set; }

            public string bIsSffcentLandfiles { get; set; }
            public string bIsSffcentLandExtension { get; set; }
            public string bIsSffcentLandContent { get; set; }

            public string bIsAffidvtAsprGuidfiles { get; set; }
            public string bIsAffidvtAsprGuidExtension { get; set; }
            public string bIsAffidvtAsprGuidContent { get; set; }

            public string bIsOtherDocfiles { get; set; }
            public string bIsOtherDocExtension { get; set; }
            public string bIsOtherDocfileContent { get; set; }

            public string affidavitfile { get; set; }
            public string affidavitExtension { get; set; }
            public string affidavitContent { get; set; }

            public string SalaryPaymentfile { get; set; }
            public string SalaryPaymentExtension { get; set; }
            public string SalaryPaymentContent { get; set; }


            public string Bankstatementfile { get; set; }
            public string BankstatementExtension { get; set; }
            public string BankstatementfileContent { get; set; }

            public string Annexurefile { get; set; }
            public string AnnexureExtension { get; set; }
            public string AnnexureContent { get; set; }

            public string EsiDocfile { get; set; }
            public string EsiDocExtension { get; set; }
            public string EsiDocContent { get; set; }

            public string Course { get; set; }

            //public List<DocumentsDetails> doclist { get; set; }

        }

        public class DocumentsDetails
        {
            public int TrustId { get; set; }
            public int CollageId { get; set; }
            public int CourseId { get; set; }
            public int Isyes { get; set; }
            public int Id { get; set; }
            public string Filetype { get; set; }
            public string file { get; set; }
            public string Extension { get; set; }
            public string Contenttype { get; set; }
            public int EnumNo { get; set; }
        }

        public class CollageattachmentAPI
        {
            public int iPk_Id { get; set; }
            public int iFk_TrstId { get; set; }
            public int iFk_ClgId { get; set; }
            public int iFk_CourseId { get; set; }
            public string sSSOID { get; set; }
            public int bIsCnnctUnvrctyDrctn { get; set; }

            public int bIsTimeFrm { get; set; }

            public int bIsLadDwn { get; set; }

            public int bIsSffcentLand { get; set; }

            public int bIsAffidvtAsprGuid { get; set; }

            public int bIsOtherDoc { get; set; }

            public string sCrtdBy { get; set; }
            public DateTime? dtCrtdDt { get; set; }
            public string sUpdtBy { get; set; }
            public DateTime? dtUpdDt { get; set; }
            public string iFk_sAplcnNo { get; set; }
            public string Guid { get; set; }
        }


        #region Vivek Add Application Modal

        public class SaveApplicationModal
        {
            public int iPK_ID { get; set; }
            public string sGUID { get; set; }
            public string sApplNo { get; set; }
            public string iFK_Finyr { get; set; }
            public int iFKTst_ID { get; set; }
            public int iFKCLG_ID { get; set; }
            public int iFKDEPT_ID { get; set; }
            public int iFK_CORS_ID { get; set; }
            public string stypeID { get; set; }
            public int iFK_FormType_ID { get; set; }
            public int sSSO_ID { get; set; }
            public DateTime? dtCRT_On { get; set; }
            public DateTime? dtSubOn { get; set; }
            public string iSts { get; set; }
            public string type { get; set; }

            public List<CourseDataForNOC> courseData { get; set; }
            public List<SubjectDataForNOC> subjData { get; set; }
            public List<TNOCDataForNOC> TnocData { get; set; }
            public List<PNOCDataForNOC> PnocData { get; set; }
        }
        public class CourseDataForNOC
        {
            public int TypeId { get; set; }
            public int courseID { get; set; }
            public string CourseType { get; set; }
            public string pkId { get; set; }
            public string subjectIdList { get; set; }
        }
        public class SubjectDataForNOC
        {
            public int TypeId { get; set; }
            public int courseID { get; set; }
            public string CourseType { get; set; }
            public string pkId { get; set; }
            public string subjectIdList { get; set; }
        }
        public class TNOCDataForNOC
        {
            public int typeID { get; set; }
            public string pkId { get; set; }
            public string CourseType { get; set; }
            public int courseID { get; set; }
            public int subID { get; set; }
        }
        public class PNOCDataForNOC
        {
            public int typeID { get; set; }
            public string pkId { get; set; }
            public string CourseType { get; set; }
            public int courseID { get; set; }
            public int subID { get; set; }
        }

        public class OldNOCData
        {
            public int iPK_Id { get; set; }
            public int iFk_ClgID { get; set; }
            public string collegeName { get; set; }
            public int iFk_CORSID { get; set; }
            public string courseName { get; set; }
            public int iFk_SubjectID { get; set; }
            public string subjectName { get; set; }
            public string subjectIDList { get; set; }
            public string appGUID { get; set; }
            public int iNocTypID { get; set; }
            public string nocTypeName { get; set; }
            public int iFk_SYID { get; set; }
            public string sessionYear { get; set; }
            public string sNOCNo { get; set; }
            public string dtNOCRcvdOn { get; set; }
            public string dtNOCExprOn { get; set; }
            public string sRemrk { get; set; }
            public string dtCrtedOn { get; set; }
            public string issuedForYear { get; set; }
            //image
            public string NocDoc { get; set; }
            public string NocDocExtension { get; set; }
            public string NocDocContent { get; set; }

        }

        //Added For Saving the Darft application by Vivek 10.02.2023
        public class DeptMasterApp
        {
            public string CollegeID { get; set; }
            public string college { get; set; }
            public string appType { get; set; }
            public string trustID { get; set; }
            public string trustName { get; set; }
            public string deptID { get; set; } = "8";
            public string deptName { get; set; } = "College Education";
            public string CourseID { get; set; }
            public string SubjectID { get; set; }
            public string Course { get; set; }
            public string Subject { get; set; }

        }

        #endregion



    }
}
