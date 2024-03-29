﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BO.Models
{
    public class Master
    {
    }
    public class FinYear
    {
        public int iPk_Id { get; set; }
        public string sName { get; set; }
        public string dtInsertStrDt { get; set; }
        public string dtInsertEndDt { get; set; }
        public int iStts { get; set; }
    }
    public class FinYearView : FinYear
    {
        public DateTime? dtStrdate { get; set; }
        public DateTime? dtEnddate { get; set; }

        public string StartDate
        {
            get
            {
                if (!string.IsNullOrEmpty(dtStrdate.ToString()))
                {
                    return dtStrdate.Value.ToString("ddd dd MMM yyyy");
                }
                else
                {
                    return null;
                }
            }
        }
        public string EndDate
        {
            get
            {
                if (!string.IsNullOrEmpty(dtEnddate.ToString()))
                {
                    return dtEnddate.Value.ToString("ddd dd MMM yyyy");
                }
                else
                {
                    return null;
                }
            }
        }

    }
    public class NOCDEPMAP
    {
        public int iPk_DeptMapId { get; set; }
        public int? iFk_DeptId { get; set; }
        public string iFk_NOCDeptId { get; set; }
        public string iFk_NOCTyp { get; set; }
        public int? iStts { get; set; }
        public int? iMode { get; set; }
        public string NewGuid { get; set; }
        public string NocDepartmentName { get; set; }
        public string NocDepartmenttype { get; set; }
        public string DepartName { get; set; }
        public int? NocSpecialId { get; set; }
        public string iFk_NocSpecialId { get; set; }
        public int? iSpecialStatus { get; set; }
    }
    public class PARAMCAT
    {
        public int? iPk_ParmCateId { get; set; }
        public string sParmetNam { get; set; }
        public string iParCatId { get; set; }
        public string iParCatSubId { get; set; }
        public string iParUomid { get; set; }
        public int? iStts { get; set; }
        public string sParCatName { get; set; }
        public string sParCatSubName { get; set; }
        public string sParUomName { get; set; }
        public int? iFk_Deptid { get; set; }
        public string sDeptName { get; set; }
    }
    public class PARMTVALUCONFMST
    {
        public int? iPK_ParValId { get; set; }
        public int? iFk_Deptid { get; set; }
        public int? iCourseId { get; set; }
        public int? iParCatId { get; set; }
        public int? iParCatSubId { get; set; }
        public int? iParUomid { get; set; }
        public int? iMin { get; set; }
        public int? iMax { get; set; }
        public int? iField { get; set; }
        public int? iValue { get; set; }
        public int? iminlength { get; set; }
        public int? iminwidth { get; set; }
        public long? iminval { get; set; }
        public int? imaxlength { get; set; }
        public int? imaxwidth { get; set; }
        public long? imaxval { get; set; }
        public int? iStts { get; set; }
        public int? iFix { get; set; }
    }
    public class PARMTVALUCONFMSTView : PARMTVALUCONFMST
    {
        public string sDeptName { get; set; }
        public string sCateName { get; set; }
        public string sCateSubName { get; set; }
        public string UomName { get; set; }
        public string CourseName { get; set; }
        public string InsertValue { get; set; }
        public string UploadUrl { get; set; }
    }
    public class ArchiMstDetail
    {
        public int ipk_ArchiMstDetId { get; set; }
        public int iParamId { get; set; }
        public int iSubCatId { get; set; }
        public int iUomId { get; set; }
        public int iWid { get; set; }
        public int iLen { get; set; }
        public int iQty { get; set; }
        public string sAppId { get; set; }

        public string bAttachFile { get; set; }
        public string sProfileExtension { get; set; }
        public string ProfileContentType { get; set; }


    }
    public class ArchitectureMst
    {
        public int iPk_MasterId { get; set; }
        public string iFK_AppId { get; set; }
        public int iTrustId { get; set; }
        public int iCollId { get; set; }
        public int iParamId { get; set; }
        public int iSubCatId { get; set; }
        public string Value { get; set; }
        public int iUom { get; set; }
    }
    public class ArchUpload
    {
        public int iParamId { get; set; }
        public int iSubCatId { get; set; }
        public int iUomId { get; set; }
        public string sFK_AppId { get; set; }
        public string Type { get; set; }
        public string UploadUrl { get; set; }
    }

    public class EventMstSave
    {
        public string sNewGuid { get; set; }
        public int iFk_DeptId { get; set; }
        public int iFk_NOCDeptId { get; set; }
        public int iMode { get; set; }
        public int iFk_NOCTyp { get; set; }

        public string dtFormdate { get; set; }
        public string dtTodate { get; set; }
    }
    public class EVNTMST
    {
        public int iPk_EventId { get; set; }
        public int? iFk_DeptId { get; set; }
        public string iFk_NOCDeptId { get; set; }
        public string iFk_NOCTyp { get; set; }
        public int? iStts { get; set; }
        public int? iMode { get; set; }
        public string NocDepartmentName { get; set; }
        public string NocDepartmenttype { get; set; }
        public string DepartName { get; set; }
        public string dtFormdate { get; set; }
        public string dtTodate { get; set; }
        public string sNewGuid { get; set; }
    }
    public class CommiteeMaster
    {
        public int? iPk_CommiteeId { get; set; }
        public int? iComtTypid { get; set; }
        public string sComtMemLst { get; set; }
        public string sComtNam { get; set; }
        public int? iStts { get; set; }
        public int? iDeptId { get; set; }
        public string sCtrby { get; set; }
        public string CommiteeMember { get; set; }
        public string filedata { get; set; }
        public string sSubj { get; set; }
        public int distID { get; set; }
        public int tehID { get; set; }
    }

    public class FeeMstField
    {
        public string DepartmentName { get; set; }
        public string ApplicationType { get; set; }
        public string Casetext { get; set; }
    }
    public class FeeTRN : FeeMstField
    {
        public int iFk_DeptID { get; set; }
        public int iFK_AppTypID { get; set; }
        public int iFK_FrmID { get; set; }
        public int iFK_FeeMstID { get; set; }
        public string sFrmName { get; set; }
        public decimal dCharges { get; set; }
        public string sGuidid { get; set; }
        public string FormName { get; set; }
        public int CaseId { get; set; }
        public string type { get; set; }
    }
    public class FeeMst : FeeMstField
    {
        public int? iPK_ID { get; set; }
        public string dtStartdate1 { get; set; }
        public string dtEnddate1 { get; set; }
        public string dtStartdate2 { get; set; }
        public string dtEnddate2 { get; set; }
        public string dtStartdate3 { get; set; }
        public string dtEnddate3 { get; set; }
        public string dtExtendDate { get; set; }
        public string dtSubmitDate { get; set; }
        public int? DeptID { get; set; }
        public int? NOCApplID { get; set; }
        public int? iFyID { get; set; }
        public decimal? dCoEdu_BR { get; set; }
        public decimal? dGirls { get; set; }
        public decimal? dCoEdu { get; set; }
        public decimal? dGirls_BR { get; set; }
        public decimal? dUGFee { get; set; }
        public decimal? dPGFee { get; set; }
        public decimal? dLateFee { get; set; }
        public decimal? dAddiLateFee { get; set; }
        public int? iStatus { get; set; }
    }
    public class CompleteFeeMaster
    {
        public FeeMst feeMst { get; set; }
        public List<FeeTRN> feeTrn { get; set; }
    }
    public class CourserBind
    {
        public int Id { get; set; }
        public string text { get; set; }

        public int? RoomNo { get; set; }
        public int? RoomNorequired { get; set; }
        public int? Roomlength { get; set; }
        public int? Roomwidth { get; set; }
        public int? RoomCapacity { get; set; }
    }
}
