using BO.Models;
using BO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using static BO.Models.TrusteeBO;
using System.Linq;

namespace DL
{
    public class TrusteeDL
    {
        ErrorBO objResponseData = new ErrorBO();
        ResponseData objResponseData1 = new ResponseData();
        public ErrorBO SaveTrustee(TrusteeBO.Trustee _obj)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] param = new SqlParameter[35];
                param[0] = new SqlParameter("@Type", "Insert");
                param[1] = new SqlParameter("@Name", _obj.Name);
                param[2] = new SqlParameter("@Email", _obj.Email);
                param[3] = new SqlParameter("@Mobile", _obj.Mobile);
                param[4] = new SqlParameter("@RoleId", _obj.RoleId.NulllToInt());
                param[5] = new SqlParameter("@Aadhaar", _obj.Aadhaar);
                param[6] = new SqlParameter("@Pan", _obj.Pan);
                param[7] = new SqlParameter("@Profile", _obj.ProfileImg);
                param[8] = new SqlParameter("@AadharExtension", _obj.AadhaarExtension);
                param[9] = new SqlParameter("@AadharDocumentContent", _obj.AadhaarContentType);
                param[10] = new SqlParameter("@PanExtension", _obj.PanExtension);
                param[11] = new SqlParameter("@PanDocumentContent", _obj.PanContentType);
                param[12] = new SqlParameter("@ProfileExtension", _obj.ProfileExtension);
                param[13] = new SqlParameter("@ProfileDocumentContent", _obj.ProfileContentType);
                param[14] = new SqlParameter("@AadhaarNo", _obj.AadhaarNo);
                param[15] = new SqlParameter("@PanNo", _obj.PanNo);
                param[16] = new SqlParameter("@TrustInfoId", _obj.TrustInfoId);
                param[17] = new SqlParameter("@isPrimary", _obj.isPrimary);
                param[18] = new SqlParameter("@isAuthorize", _obj.isAuthorize);

                param[19] = new SqlParameter("@AuthorizedExtension", _obj.AuthorizedExtension);
                param[20] = new SqlParameter("@AuthorizedDocumentContent", _obj.AuthorizedContentType);
                param[21] = new SqlParameter("@Authorized", _obj.Authorized);

                param[22] = new SqlParameter("@OccupationId", _obj.OccupationId);
                param[23] = new SqlParameter("@GenderId", _obj.GenderId);
                param[24] = new SqlParameter("@FatherName", _obj.FatherName);
                param[25] = new SqlParameter("@CollageId", _obj.CollageId);
                param[26] = new SqlParameter("@Educationfile", _obj.Educationfile);
                param[27] = new SqlParameter("@EducationfileExtension", _obj.EducationfileExtension);
                param[28] = new SqlParameter("@EducationfileContentType", _obj.EducationfileContentType);

                param[29] = new SqlParameter("@Letterfile", _obj.Letterfile);
                param[30] = new SqlParameter("@LetterfileExtension", _obj.LetterfileExtension);
                param[31] = new SqlParameter("@LetterfileContentType", _obj.LetterfileContentType);

                param[32] = new SqlParameter("@signaturefile", _obj.signaturefile);
                param[33] = new SqlParameter("@signaturefileExtension", _obj.signaturefileExtension);
                param[34] = new SqlParameter("@signaturefileContentType", _obj.signaturefileContentType);

                ds = BaseFunction.FillDataSet("[dbo].[USP_ADMIN_Trustee_SaveView]", param);
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        objResponseData.Messsage = ds.Tables[0].Rows[0]["Message"].NulllToString();
                        objResponseData.ResponseCode = ds.Tables[0].Rows[0]["Flag"].NulllToString();
                        return objResponseData;
                    }
                    else
                    {
                        objResponseData.Messsage = ds.Tables[0].Rows[0]["Message"].NulllToString();
                        objResponseData.ResponseCode = ds.Tables[0].Rows[0]["Flag"].NulllToString();
                        return objResponseData;
                    }
                }
                else
                {
                    objResponseData.Messsage = CustomMessage.NORECORDFOUND;
                    objResponseData.ResponseCode = CustomMessage.NORECORDFOUND_RESPONSECODE.ToString();
                    return objResponseData;
                }
            }
            catch (Exception ex)
            {
                objResponseData.Messsage = CustomMessage.EXCEPTIONOCCURRED;
                objResponseData.ResponseCode = CustomMessage.EXCEPTIONOCCURRED_RESPONSECODE.ToString();
                ExceptionLogDL.WriteExceptionDB(ex, "NA", "api", "TrusteeDL:SaveTrustee", "UNOCapi", "NA");
                return objResponseData;
            }
        }

        public List<TrusteeBO.Trustee> TrusteeList(string TrustId)
        {
            List<TrusteeBO.Trustee> _result = new List<TrusteeBO.Trustee>();
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@Type", "Details");
                param[1] = new SqlParameter("@TrustInfoId", TrustId);
                ds = BaseFunction.FillDataSet("[dbo].[USP_ADMIN_Trustee_SaveView]", param);
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        objResponseData.Messsage = ds.Tables[1].Rows[0]["Message"].NulllToString();
                        objResponseData.ResponseCode = ds.Tables[1].Rows[0]["Flag"].NulllToString();

                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow DR in ds.Tables[0].Rows)
                            {
                                _result.Add(new TrusteeBO.Trustee
                                {
                                    Id = DR["Id"].NulllToString(),
                                    Name = DR["Name"].NulllToString(),
                                    trustName = DR["TrustName"].NulllToString(),
                                    Email = DR["Email"].NulllToString(),
                                    RoleId = DR["Role"].NulllToString(),
                                    Mobile = DR["Mobile"].NulllToString(),
                                    Aadhaar = DR["Aadhaar"].NulllToString(),
                                    Pan = DR["Pan"].NulllToString(),
                                    ProfileImg = DR["Profile"].NulllToString(),
                                    ProfileExtension = DR["ProfileExtension"].NulllToString(),
                                    ProfileContentType = DR["ProfileContentType"].NulllToString(),
                                    Profilefile = DR["Profilefile"].ToString(),
                                    AadhaarNo = DR["AadhaarNo"].NulllToString(),
                                    PanNo = DR["PanNo"].NulllToString(),
                                    isPrimary = DR["iIsPrimary"].NulllToString(),
                                    isAuthorize = DR["iIsAuthorize"].NulllToString(),
                                    OccupationId = DR["OccupationId"].NulllToString(),
                                    GenderId = DR["GenderId"].NulllToString(),
                                    FatherName = DR["FatherName"].NulllToString(),
                                    CollageId = DR["CollageId"].NulllToString(),
                                    Educationfile = DR["Educationfile"].NulllToString(),
                                    signaturefile = DR["signaturefile"].NulllToString(),

                                });
                            }
                        }

                        return _result;
                    }
                    else
                    {
                        objResponseData.Messsage = ds.Tables[0].Rows[0]["Message"].NulllToString();
                        objResponseData.ResponseCode = ds.Tables[0].Rows[0]["Flag"].NulllToString();
                        return _result;
                    }
                }
                else
                {
                    objResponseData.Messsage = CustomMessage.NORECORDFOUND;
                    objResponseData.ResponseCode = CustomMessage.NORECORDFOUND_RESPONSECODE.ToString();
                    return _result;
                }
            }
            catch (Exception ex)
            {
                objResponseData.Messsage = CustomMessage.EXCEPTIONOCCURRED;
                objResponseData.ResponseCode = CustomMessage.EXCEPTIONOCCURRED_RESPONSECODE.ToString();
                ExceptionLogDL.WriteExceptionDB(ex, "NA", "api", "TrusteeDL:TrusteeList", "UNOCapi", "NA");
                return _result;
            }
        }

        public TrusteeBO.Trustee DocumentDetail(string Id)
        {
            TrusteeBO.Trustee _result = new TrusteeBO.Trustee();
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@Type", "DocumentDetails");
                param[1] = new SqlParameter("@IdentityId", Id.NulllToInt());
                ds = BaseFunction.FillDataSet("[dbo].[USP_ADMIN_Trustee_SaveView]", param);
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        objResponseData.Messsage = ds.Tables[1].Rows[0]["Message"].NulllToString();
                        objResponseData.ResponseCode = ds.Tables[1].Rows[0]["Flag"].NulllToString();

                        if (ds.Tables[0].Rows.Count > 0)
                        {

                            _result.Aadhaar = ds.Tables[0].Rows[0]["Filestring"].ToString();
                            _result.AadhaarExtension = ds.Tables[0].Rows[0]["DocumentExtension"].NulllToString();
                            _result.AadhaarContentType = ds.Tables[0].Rows[0]["DocumentContent"].NulllToString();

                        }

                        return _result;
                    }
                    else
                    {
                        objResponseData.Messsage = ds.Tables[0].Rows[0]["Message"].NulllToString();
                        objResponseData.ResponseCode = ds.Tables[0].Rows[0]["Flag"].NulllToString();
                        return _result;
                    }
                }
                else
                {
                    objResponseData.Messsage = CustomMessage.NORECORDFOUND;
                    objResponseData.ResponseCode = CustomMessage.NORECORDFOUND_RESPONSECODE.ToString();
                    return _result;
                }
            }
            catch (Exception ex)
            {
                objResponseData.Messsage = CustomMessage.EXCEPTIONOCCURRED;
                objResponseData.ResponseCode = CustomMessage.EXCEPTIONOCCURRED_RESPONSECODE.ToString();
                ExceptionLogDL.WriteExceptionDB(ex, "NA", "api", "TrusteeDL:DocumentDetail", "UNOCapi", "NA");
                return _result;
            }
        }

        public ErrorBO SaveTrusteeInfo(TrusteeBO.TrusteeInfo _obj)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] param = new SqlParameter[18];
                param[0] = new SqlParameter("@Type", "Insert");

                param[1] = new SqlParameter("@Certified", _obj.Certified);
                param[2] = new SqlParameter("@CeritifiedExtension", _obj.CeritifiedExtension);
                param[3] = new SqlParameter("@CeritifiedbyContenttype", _obj.CeritifiedbyContenttype);

                param[4] = new SqlParameter("@Registration", _obj.Registration);
                param[5] = new SqlParameter("@RegistrationExtension", _obj.RegistrationExtension);
                param[6] = new SqlParameter("@RegistrationContenttype", _obj.RegistrationContenttype);

                param[7] = new SqlParameter("@TrusteeLogo", _obj.TrusteeLogo);
                param[8] = new SqlParameter("@TrusteeExtension", _obj.TrusteeExtension);
                param[9] = new SqlParameter("@TrusteeContenttype", _obj.TrusteeContentType);

                param[10] = new SqlParameter("@TrusteeMemberProof", _obj.TRMP);
                param[11] = new SqlParameter("@TrusteeMemberProofExtension", _obj.TRMPExtension);
                param[12] = new SqlParameter("@TrusteeMemberProofContentType", _obj.TRMPContenttype);
                param[13] = new SqlParameter("@IdentityId", _obj.TrusteeInfoId.NulllToInt());

                param[14] = new SqlParameter("@ElectionDate", _obj.ElectionDate);
                param[15] = new SqlParameter("@MemberofMngCommtee", _obj.MemberofMngCommtee.NulllToInt());
                param[16] = new SqlParameter("@Morethentree", _obj.Morethentree.NulllToInt());
                param[17] = new SqlParameter("@OtherInstitute", _obj.OtherInstitute.NulllToInt());

                DataTable dt = BaseFunction.FillDataTable("[dbo].[USP_ADMIN_TrusteeInfo_SaveView]", param);
                if (_obj.InstituteDetails != null)
                {
                    for (int i = 0; i <= _obj.InstituteDetails.Count - 1; i++) //Rows.Count - 1; i++
                    {
                        SqlParameter[] param1 = new SqlParameter[5];
                        param1[0] = new SqlParameter("@Type", "InsertInstitute");
                        param1[1] = new SqlParameter("@InstituteName", _obj.InstituteDetails[i].InstituteName);
                        param1[2] = new SqlParameter("@IdentityId", _obj.TrusteeInfoId.NulllToInt());
                        param1[3] = new SqlParameter("@ContactPerson", _obj.InstituteDetails[i].ContactPerson);  //uniContactsTable.Rows[i]["Number"].ToString());
                        param1[4] = new SqlParameter("@Number", _obj.InstituteDetails[i].Number); //uniContactsTable.Rows[i]["Email"].ToString());
                        ds = BaseFunction.FillDataSet("[dbo].[USP_ADMIN_TrusteeInfo_SaveView]", param1);

                    }
                }
                if (dt != null && dt.Rows.Count > 0)
                {
                    if (dt.Rows.Count > 0)
                    {
                        objResponseData.Messsage = dt.Rows[0]["Message"].NulllToString();
                        objResponseData.ResponseCode = dt.Rows[0]["Flag"].NulllToString();
                        return objResponseData;
                    }
                    else
                    {
                        objResponseData.Messsage = dt.Rows[0]["Message"].NulllToString();
                        objResponseData.ResponseCode = dt.Rows[0]["Flag"].NulllToString();
                        return objResponseData;
                    }
                }
                else
                {
                    objResponseData.Messsage = CustomMessage.NORECORDFOUND;
                    objResponseData.ResponseCode = CustomMessage.NORECORDFOUND_RESPONSECODE.ToString();
                    return objResponseData;
                }
            }
            catch (Exception ex)
            {
                objResponseData.Messsage = CustomMessage.EXCEPTIONOCCURRED;
                objResponseData.ResponseCode = CustomMessage.EXCEPTIONOCCURRED_RESPONSECODE.ToString();
                ExceptionLogDL.WriteExceptionDB(ex, "NA", "api", "TrusteeDL:SaveTrusteeInfo", "UNOCapi", "NA");
                return objResponseData;
            }
        }

        public List<CustomList> GetTrustDropDownList()
        {
            List<CustomList> objListdoc = new List<CustomList>();
            try
            {

                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@Type", "TrustInfoDropDown");
                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_ADMIN_TrusteeInfo_SaveView]", param);
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    objListdoc = new List<CustomList>();

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        CustomList objdoc = new CustomList();
                        objdoc.Id = ds.Tables[0].Rows[i]["Id"].NulllToInt();
                        objdoc.text = ds.Tables[0].Rows[i]["CustomName"].NulllToString();
                        objListdoc.Add(objdoc);
                    }
                }
                else
                {
                    objListdoc = null;
                }
            }
            catch (Exception ex)
            {
                objListdoc = null;
                ExceptionLogDL.WriteExceptionDB(ex, "NA", "api", "TrusteeDL:GetTrustDropDownList", "UNOCapi", "NA");                
            }
            return objListdoc;
        }

        public List<TrusteeBO.TrusteeInfo> TrustInfoList()
        {
            List<TrusteeBO.TrusteeInfo> _result = new List<TrusteeBO.TrusteeInfo>();
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@Type", "Details");
                ds = BaseFunction.FillDataSet("[dbo].[USP_ADMIN_TrusteeInfo_SaveView]", param);
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        objResponseData.Messsage = ds.Tables[1].Rows[0]["Message"].NulllToString();
                        objResponseData.ResponseCode = ds.Tables[1].Rows[0]["Flag"].NulllToString();

                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow DR in ds.Tables[0].Rows)
                            {
                                _result.Add(new TrusteeBO.TrusteeInfo
                                {
                                    Name = DR["Name"].NulllToString(),
                                    RegistrationNo = DR["sRgstrnNo"].NulllToString(),
                                    CertiFiedBy = DR["sCertifiedBy"].NulllToString(),
                                    TrustType = DR["TrustType"].NulllToString(),
                                    RegistrationDate = DR["dtRegstrnDt"].NulllToString(),
                                    ElectionDate = DR["dtElectionDt"].NulllToString(),
                                    Certified = DR["Certified"].NulllToString(),
                                    Registration = DR["Registration"].NulllToString(),
                                    TrusteeExtension = DR["TrustExtension"].NulllToString(),
                                    TrusteeContentType = DR["TrustContentType"].ToString(),
                                    TrusteeLogo = DR["TrustLogo"].ToString()
                                });
                            }
                        }

                        return _result;
                    }
                    else
                    {
                        objResponseData.Messsage = ds.Tables[0].Rows[0]["Message"].NulllToString();
                        objResponseData.ResponseCode = ds.Tables[0].Rows[0]["Flag"].NulllToString();
                        return _result;
                    }
                }
                else
                {
                    objResponseData.Messsage = CustomMessage.NORECORDFOUND;
                    objResponseData.ResponseCode = CustomMessage.NORECORDFOUND_RESPONSECODE.ToString();
                    return _result;
                }
            }
            catch (Exception ex)
            {
                objResponseData.Messsage = CustomMessage.EXCEPTIONOCCURRED;
                objResponseData.ResponseCode =CustomMessage.EXCEPTIONOCCURRED_RESPONSECODE.ToString();
                ExceptionLogDL.WriteExceptionDB(ex, "NA", "api", "TrusteeDL:TrustInfoList", "UNOCapi", "NA");
                return _result;
            }
        }

        public List<TrusteeBO.CollageList> CollageListApply(string TrustId)
        {
            List<TrusteeBO.CollageList> _result = new List<TrusteeBO.CollageList>();
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@Type", "GetCollageDetailsForApply");
                param[1] = new SqlParameter("@TrustId", TrustId);
                ds = BaseFunction.FillDataSet("[dbo].[USP_OPERATION_ApplyForNOC_View]", param);
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        objResponseData.Messsage = ds.Tables[1].Rows[0]["Message"].NulllToString();
                        objResponseData.ResponseCode = ds.Tables[1].Rows[0]["Flag"].NulllToString();

                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow DR in ds.Tables[0].Rows)
                            {
                                _result.Add(new TrusteeBO.CollageList
                                {
                                    TrustInfoId = DR["TrustInfoId"].NulllToString(),
                                    CollageId = DR["CollageId"].NulllToString(),
                                    TrustName = DR["TrustName"].NulllToString(),
                                    TrustRegistrationNo = DR["RegistrationNo"].NulllToString(),
                                    CollageName = DR["CollageName"].NulllToString(),
                                    Email = DR["Email"].NulllToString(),
                                    MobileNo = DR["Mobile"].NulllToString(),
                                    AddMobileNo = DR["AddMobileNo"].NulllToString(),
                                    AddPhoneNo = DR["AddPhoneNo"].NulllToString(),
                                    CollageLogo = DR["CollageLogo"].NulllToString(),
                                    CollageContectType = DR["DocumentContent"].NulllToString(),
                                    //Degree = DR["Deegree"].NulllToString(),
                                    //Courses = DR["courses"].NulllToString(),
                                    //CoursesID = DR["iFK_CourseId"].NulllToInt(),
                                    //DegreeID = DR["iFK_DeptId"].NulllToInt(),
                                    //IsDraft = DR["iIsDrafted"].NulllToInt(),
                                    //IsPNOC = DR["bIsPNOC"].NulllToInt(),
                                    //IsTNOC = DR["bIsTNOC"].NulllToInt(),
                                });
                            }
                        }

                        return _result;
                    }
                    else
                    {
                        objResponseData.Messsage = ds.Tables[0].Rows[0]["Message"].NulllToString();
                        objResponseData.ResponseCode = ds.Tables[0].Rows[0]["Flag"].NulllToString();
                        return _result;
                    }
                }
                else
                {
                    objResponseData.Messsage = CustomMessage.NORECORDFOUND;
                    objResponseData.ResponseCode = CustomMessage.NORECORDFOUND_RESPONSECODE.ToString();
                    return _result;
                }
            }
            catch (Exception ex)
            {
                objResponseData.Messsage = CustomMessage.EXCEPTIONOCCURRED;
                objResponseData.ResponseCode = CustomMessage.EXCEPTIONOCCURRED_RESPONSECODE.ToString();
                return _result;
            }
        }

        public ErrorBO AddCollageFacility(TrusteeBO.CollageFacility _obj)
        {
            DataSet ds = new DataSet();
            ErrorBO _res = new ErrorBO();
            List<TrusteeBO.FaciltyAdd> _List = new List<TrusteeBO.FaciltyAdd>();
            foreach (var item in _obj.list)
            {
                try
                {

                    //string file = string.Empty;
                    //string extension = string.Empty;
                    //string contenttype = string.Empty;
                    //if (item.uploadFile != null)
                    //{
                    //    string[] t = item.uploadFile.Split(";");
                    //    file = t[1].Split(",")[1];
                    //    contenttype = t[0].Split(":")[1];
                    //    extension = t[0].Split("/")[1];
                    //}
                    ds = new DataSet();
                    SqlParameter[] param = new SqlParameter[8];
                    param[0] = new SqlParameter("@Type", "Insert");
                    //param[1] = new SqlParameter("@TrustId", _obj.TrustId);
                    //param[2] = new SqlParameter("@CollageId", _obj.CollageId);
                    param[1] = new SqlParameter("@Guid", _obj.Guid);
                    param[2] = new SqlParameter("@FacilityId", item.FacilityId);
                    param[3] = new SqlParameter("@CreatedBy", "");
                    param[4] = new SqlParameter("@File", item.uploadFile);
                    param[5] = new SqlParameter("@Extension", item.Extension);
                    param[6] = new SqlParameter("@ContentType", item.ContentType);
                    param[7] = new SqlParameter("@IsActive", item.IsSelect);
                    ds = BaseFunction.FillDataSet("[dbo].[USP_ApplcantCollageFacility_SaveView]", param);

                    //if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                    //{
                    //    if (ds.Tables[0].Rows.Count > 0)
                    //    {
                    //        objResponseData.Messsage = ds.Tables[0].Rows[0]["Message"].NulllToString();
                    //        objResponseData.ResponseCode = ds.Tables[0].Rows[0]["Flag"].NulllToString();
                    //        return objResponseData;
                    //    }
                    //    else
                    //    {
                    //        objResponseData.Messsage = ds.Tables[0].Rows[0]["Message"].NulllToString();
                    //        objResponseData.ResponseCode = ds.Tables[0].Rows[0]["Flag"].NulllToString();
                    //        return objResponseData;
                    //    }
                    //}
                }
                catch (Exception ex)
                {

                }

            }
            try
            {

                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        objResponseData.Messsage = ds.Tables[0].Rows[0]["Message"].NulllToString();
                        objResponseData.ResponseCode = ds.Tables[0].Rows[0]["Flag"].NulllToString();
                        return objResponseData;
                    }
                    else
                    {
                        objResponseData.Messsage = ds.Tables[0].Rows[0]["Message"].NulllToString();
                        objResponseData.ResponseCode = ds.Tables[0].Rows[0]["Flag"].NulllToString();
                        return objResponseData;
                    }
                }
                //SqlParameter[] param = new SqlParameter[17];
                //param[0] = new SqlParameter("@Type", "Insert");
                //param[1] = new SqlParameter("@Name", _obj.TrustId);
                //param[2] = new SqlParameter("@Email", _obj.CollageId);
                //param[3] = new SqlParameter("@Mobile", _obj.Mobile);
                //param[4] = new SqlParameter("@RoleId", _obj.RoleId.NulllToInt());
                //param[5] = new SqlParameter("@Aadhaar", _obj.Aadhaar);
                //param[6] = new SqlParameter("@Pan", _obj.Pan);
                //param[7] = new SqlParameter("@Profile", _obj.ProfileImg);
                //param[8] = new SqlParameter("@AadharExtension", _obj.AadhaarExtension);
                //param[9] = new SqlParameter("@AadharDocumentContent", _obj.AadhaarContentType);
                //param[10] = new SqlParameter("@PanExtension", _obj.PanExtension);
                //param[11] = new SqlParameter("@PanDocumentContent", _obj.PanContentType);
                //param[12] = new SqlParameter("@ProfileExtension", _obj.ProfileExtension);
                //param[13] = new SqlParameter("@ProfileDocumentContent", _obj.ProfileContentType);
                //param[14] = new SqlParameter("@AadhaarNo", _obj.AadhaarNo);
                //param[15] = new SqlParameter("@PanNo", _obj.PanNo);
                //param[16] = new SqlParameter("@TrustInfoId", _obj.TrustInfoId);

                //ds = BaseFunction.FillDataSet("[dbo].[USP_ADMIN_Trustee_SaveView]", param);
                //if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                //{
                //    if (ds.Tables[0].Rows.Count > 0)
                //    {
                //        objResponseData.Messsage = ds.Tables[0].Rows[0]["Message"].NulllToString();
                //        objResponseData.ResponseCode = ds.Tables[0].Rows[0]["Flag"].NulllToString();
                //        return objResponseData;
                //    }
                //    else
                //    {
                //        objResponseData.Messsage = ds.Tables[0].Rows[0]["Message"].NulllToString();
                //        objResponseData.ResponseCode = ds.Tables[0].Rows[0]["Flag"].NulllToString();
                //        return objResponseData;
                //    }
                //}
                //else
                //{
                //    objResponseData.Messsage = BO.CustomMessage.NORECORDFOUND;
                //    objResponseData.ResponseCode = BO.CustomMessage.NORECORDFOUND_RESPONSECODE.ToString();
                //    return objResponseData;
                //}
            }
            catch (Exception ex)
            {
                objResponseData.Messsage = CustomMessage.EXCEPTIONOCCURRED;
                objResponseData.ResponseCode = CustomMessage.EXCEPTIONOCCURRED_RESPONSECODE.ToString();
                ExceptionLogDL.WriteExceptionDB(ex, "NA", "api", "TrusteeDL:AddCollegeFacility", "UNOCapi", "NA");
                return objResponseData;
            }

            return _res;
        }

        public TrusteeBO.CollageFeeMst GetFeeDetailsList(TrusteeBO.CollageFeeMst obj)
        {
            TrusteeBO.CollageFeeMst _result = new TrusteeBO.CollageFeeMst();
            List<TrusteeBO.RateList> _rateList = new List<TrusteeBO.RateList>();
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@Type", "Select");
                param[1] = new SqlParameter("@Guid", obj.Guid);
                ds = BaseFunction.FillDataSet("[dbo].[USP_CollageFee_SaveView]", param);
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        objResponseData.Messsage = ds.Tables[1].Rows[0]["Message"].NulllToString();
                        objResponseData.ResponseCode = ds.Tables[1].Rows[0]["Flag"].NulllToString();

                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow DR in ds.Tables[0].Rows)
                            {
                                _rateList.Add(new TrusteeBO.RateList
                                {
                                    RateId = DR["iPK_CustEnum"].NulllToString(),
                                    RateName = DR["sName"].NulllToString(),
                                    Rate = DR["Rate"].NulllToDecimal(),
                                    IsSelect = DR["iIsActive"].NulllToString() == "0" ? false : true,
                                });
                            }
                        }
                        _result.rateLists = _rateList;
                        return _result;
                    }
                    else
                    {
                        objResponseData.Messsage = ds.Tables[0].Rows[0]["Message"].NulllToString();
                        objResponseData.ResponseCode = ds.Tables[0].Rows[0]["Flag"].NulllToString();
                        return _result;
                    }
                }
                else
                {
                    objResponseData.Messsage = CustomMessage.NORECORDFOUND;
                    objResponseData.ResponseCode = CustomMessage.NORECORDFOUND_RESPONSECODE.ToString();
                    return _result;
                }
            }
            catch (Exception ex)
            {
                objResponseData.Messsage = CustomMessage.EXCEPTIONOCCURRED;
                objResponseData.ResponseCode = CustomMessage.EXCEPTIONOCCURRED_RESPONSECODE.ToString();
                ExceptionLogDL.WriteExceptionDB(ex, "NA", "api", "TrusteeDL:GetFeeDetailsList", "UNOCapi", "NA");
                return _result;
            }
        }

        public List<CustomList> GetDepartment(long ServiceId)
        {
            List<CustomList> objListdoc = new List<CustomList>();
            try
            {

                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@type", "ChargeType");
                param[0] = new SqlParameter("@Id", ServiceId);
                DataSet ds = BaseFunction.FillDataSet("[mst].[USP_ADMIN_GetMasterDataForDropdown_View]", param);
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    objListdoc = new List<CustomList>();

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        CustomList objdoc = new CustomList();
                        objdoc.Id = ds.Tables[0].Rows[i]["Id"].NulllToInt();
                        objdoc.text = ds.Tables[0].Rows[i]["text"].NulllToString();
                        objListdoc.Add(objdoc);
                    }
                }
                else
                {
                    objListdoc = null;
                }
            }
            catch (Exception ex)
            {
                objListdoc = null;
                ExceptionLogDL.WriteExceptionDB(ex, "NA", "api", "TrusteeDL:GetDepartment", "UNOCapi", "NA");
                
            }
            return objListdoc;
        }

        public ErrorBO AddCollageFee(TrusteeBO.CollageFeeMst _obj)
        {
            DataSet ds = new DataSet();
            ErrorBO _res = new ErrorBO();
            List<TrusteeBO.FaciltyAdd> _List = new List<TrusteeBO.FaciltyAdd>();
            foreach (var item in _obj.rateLists)
            {
                try
                {
                    //if (item.IsSelect == true)
                    //{
                    ds = new DataSet();
                    SqlParameter[] param = new SqlParameter[5];
                    param[0] = new SqlParameter("@Type", "Insert");
                    param[1] = new SqlParameter("@RateId", item.RateId);
                    param[2] = new SqlParameter("@Rate", item.Rate);
                    param[3] = new SqlParameter("@IsSelect", item.IsSelect);
                    param[4] = new SqlParameter("@Guid", _obj.Guid);
                    ds = BaseFunction.FillDataSet("[dbo].[USP_CollageFee_SaveView]", param);
                    //}
                }
                catch (Exception ex)
                {
                    ExceptionLogDL.WriteExceptionDB(ex, "NA", "api", "TrusteeDL:AddCollageFee", "UNOCapi", "NA");
                }
            }
            try
            {

                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        objResponseData.Messsage = ds.Tables[0].Rows[0]["Message"].NulllToString();
                        objResponseData.ResponseCode = ds.Tables[0].Rows[0]["Flag"].NulllToString();
                        return objResponseData;
                    }
                    else
                    {
                        objResponseData.Messsage = ds.Tables[0].Rows[0]["Message"].NulllToString();
                        objResponseData.ResponseCode = ds.Tables[0].Rows[0]["Flag"].NulllToString();
                        return objResponseData;
                    }
                }
            }
            catch (Exception ex)
            {
                objResponseData.Messsage = CustomMessage.EXCEPTIONOCCURRED;
                objResponseData.ResponseCode = CustomMessage.EXCEPTIONOCCURRED_RESPONSECODE.ToString();
                ExceptionLogDL.WriteExceptionDB(ex, "NA", "api", "TrusteeDL:AddCollageFee", "UNOCapi", "NA");
                return objResponseData;
            }
            return _res;
        }
        public TrusteeBO.CollageFacility GetCollageFacilityList(TrusteeBO.CollageFacility obj)
        {
            TrusteeBO.CollageFacility _result = new TrusteeBO.CollageFacility();
            List<TrusteeBO.Facilty> _rateList = new List<TrusteeBO.Facilty>();
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@Type", "Select");
                param[1] = new SqlParameter("@Guid", obj.Guid);
                //param[1] = new SqlParameter("@TrustId", obj.TrustId);
                //param[2] = new SqlParameter("@CollageId", obj.CollageId);
                ds = BaseFunction.FillDataSet("[dbo].[USP_ApplcantCollageFacility_SaveView]", param);
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        objResponseData.Messsage = ds.Tables[1].Rows[0]["Message"].NulllToString();
                        objResponseData.ResponseCode = ds.Tables[1].Rows[0]["Flag"].NulllToString();

                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow DR in ds.Tables[0].Rows)
                            {
                                _rateList.Add(new TrusteeBO.Facilty
                                {
                                    FacilityId = DR["iFacilityId"].NulllToString(),
                                    FacilityName = DR["sName"].NulllToString(),
                                    uploadFile = DR["File"].NulllToString(),
                                    Extension = DR["DocumentExtension"].NulllToString(),
                                    ContentType = DR["DocumentContent"].NulllToString(),
                                    IsSelect = DR["bIsActive"].NulllToString() == "0" ? false : true,
                                });
                            }
                        }
                        _result.list = _rateList;
                        return _result;
                    }
                    else
                    {
                        objResponseData.Messsage = ds.Tables[0].Rows[0]["Message"].NulllToString();
                        objResponseData.ResponseCode = ds.Tables[0].Rows[0]["Flag"].NulllToString();
                        return _result;
                    }
                }
                else
                {
                    objResponseData.Messsage = CustomMessage.NORECORDFOUND;
                    objResponseData.ResponseCode = CustomMessage.NORECORDFOUND_RESPONSECODE.ToString();
                    return _result;
                }
            }
            catch (Exception ex)
            {
                objResponseData.Messsage = CustomMessage.EXCEPTIONOCCURRED;
                objResponseData.ResponseCode = CustomMessage.EXCEPTIONOCCURRED_RESPONSECODE.ToString();
                ExceptionLogDL.WriteExceptionDB(ex, "NA", "api", "TrusteeDL:GetCollageFacilityList", "UNOCapi", "NA");
                return _result;
            }
        }
        public ResponseData addApplication(TrusteeBO.SaveApplicationModal modal)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] param = new SqlParameter[6];
                param[0] = new SqlParameter("@iFKTst_ID", modal.iFKTst_ID);
                param[1] = new SqlParameter("@iFKCLG_ID", modal.iFKCLG_ID);
                param[2] = new SqlParameter("@iFKDEPT_ID", modal.iFKDEPT_ID);
                param[3] = new SqlParameter("@iFK_CORS_ID", modal.iFK_CORS_ID);
                param[4] = new SqlParameter("@guid", Guid.NewGuid().ToString());
                param[5] = new SqlParameter("@formTypeID", modal.iFK_FormType_ID);

                ds = BaseFunction.FillDataSet("[dbo].[USP_OPERATION_SaveApplication_View]", param);

                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        objResponseData1.Message = ds.Tables[0].Rows[0]["Message"].NulllToString();
                        objResponseData1.ResponseCode = "0";
                        objResponseData1.statusCode = 1;
                        return objResponseData1;
                    }
                    else
                    {
                        objResponseData1.Message = CustomMessage.NORECORDFOUND;
                        objResponseData1.ResponseCode = CustomMessage.NORECORDFOUND_RESPONSECODE.ToString();
                        objResponseData1.statusCode = 0;
                        return objResponseData1;
                    }
                }
                else
                {
                    objResponseData1.Message = CustomMessage.NORECORDFOUND;
                    objResponseData1.ResponseCode = CustomMessage.NORECORDFOUND_RESPONSECODE.ToString();
                    objResponseData1.statusCode = 0;
                    return objResponseData1;
                }
            }
            catch (Exception ex)
            {
                //objResponseData.Message = BO.CustomMessage.EXCEPTIONOCCURRED;
                //objResponseData.ResponseCode = BO.CustomMessage.EXCEPTIONOCCURRED_RESPONSECODE.ToString();
                return objResponseData1;
            }
        }


        public ErrorBO AddCollageAttachements(TrusteeBO.CollageAttachment modal)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] param = new SqlParameter[43];
                param[0] = new SqlParameter("@Type", "Insert");
                param[1] = new SqlParameter("@iFk_TrstId", modal.iFk_TrstId);
                param[2] = new SqlParameter("@iFk_ClgId", modal.iFk_ClgId);
                param[3] = new SqlParameter("@iFk_CourseId", modal.CourseId);
                param[4] = new SqlParameter("@sSSOID", modal.sSSOID);
                param[5] = new SqlParameter("@bIsCnnctUnvrctyDrctn", modal.bIsCnnctUnvrctyDrctn);
                param[6] = new SqlParameter("@bIsTimeFrm", modal.bIsTimeFrm);
                param[7] = new SqlParameter("@bIsLadDwn", modal.bIsLadDwn);
                param[8] = new SqlParameter("@bIsSffcentLand", modal.bIsSffcentLand);
                param[9] = new SqlParameter("@bIsAffidvtAsprGuid", modal.bIsAffidvtAsprGuid);
                param[10] = new SqlParameter("@bIsOtherDoc", modal.bIsOtherDoc);


                param[11] = new SqlParameter("@bIsCnnctUnvrctyDrctfile", modal.bIsCnnctUnvrctyDrctfiles);
                param[12] = new SqlParameter("@bIsCnnctUnvrctyDrctExtension", modal.bIsCnnctUnvrctyDrctExtension);
                param[13] = new SqlParameter("@bIsCnnctUnvrctyDrctContent", modal.bIsCnnctUnvrctyDrctContent);

                param[14] = new SqlParameter("@bIsTimeFrmfile", modal.bIsTimeFrmfiles);
                param[15] = new SqlParameter("@bIsTimeFrmExtension", modal.bIsTimeFrmExtension);
                param[16] = new SqlParameter("@bIsLadDwnContent", modal.bIsTimeFrmContent);


                param[17] = new SqlParameter("@bIsSffcentLandfile", modal.bIsSffcentLandfiles);
                param[18] = new SqlParameter("@bIsSffcentExtension", modal.bIsSffcentLandExtension);
                param[19] = new SqlParameter("@bIsSffcentContent", modal.bIsSffcentLandContent);

                param[20] = new SqlParameter("@bIsAffidvtAsprGuidfile", modal.bIsAffidvtAsprGuidfiles);
                param[21] = new SqlParameter("@bIsAffidvtAsprGuidExtension", modal.bIsAffidvtAsprGuidExtension);
                param[23] = new SqlParameter("@bIsAffidvtAsprGuidContent", modal.bIsAffidvtAsprGuidContent);

                param[24] = new SqlParameter("@bIsOtherDocfile", modal.bIsOtherDocfiles);
                param[25] = new SqlParameter("@bIsOtherDocExtension", modal.bIsOtherDocExtension);
                param[26] = new SqlParameter("@bIsOtherDocContent", modal.bIsOtherDocfileContent);

                param[27] = new SqlParameter("@affidavitfile", modal.affidavitfile);
                param[28] = new SqlParameter("@affidavitExtension", modal.affidavitExtension);
                param[29] = new SqlParameter("@affidavitContent", modal.affidavitContent);

                param[30] = new SqlParameter("@SalaryPaymentfile", modal.SalaryPaymentfile);
                param[31] = new SqlParameter("@SalaryPaymentExtension", modal.SalaryPaymentExtension);
                param[32] = new SqlParameter("@SalaryPaymentContent", modal.SalaryPaymentContent);

                param[32] = new SqlParameter("@Bankstatementfile", modal.Bankstatementfile);
                param[34] = new SqlParameter("@BankstatementExtension", modal.BankstatementExtension);
                param[35] = new SqlParameter("@BankstatementContent", modal.BankstatementfileContent);

                param[36] = new SqlParameter("@Annexurefile", modal.Annexurefile);
                param[37] = new SqlParameter("@AnnexureExtension", modal.AnnexureExtension);
                param[38] = new SqlParameter("@AnnexureContent", modal.AnnexureContent);

                param[39] = new SqlParameter("@EsiDocfile", modal.EsiDocfile);
                param[40] = new SqlParameter("@EsiDocExtension", modal.EsiDocExtension);
                param[41] = new SqlParameter("@EsiDocContent", modal.EsiDocContent);

                param[42] = new SqlParameter("@EnumNumber", modal.EnumNo);

                ds = BaseFunction.FillDataSet("[dbo].[USP_ApplcantCollageAttachments_SaveView]", param);
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        objResponseData.Messsage = ds.Tables[0].Rows[0]["Message"].NulllToString();
                        objResponseData.ResponseCode = ds.Tables[0].Rows[0]["Flag"].NulllToString();
                        return objResponseData;
                    }
                    else
                    {
                        objResponseData.Messsage = ds.Tables[0].Rows[0]["Message"].NulllToString();
                        objResponseData.ResponseCode = ds.Tables[0].Rows[0]["Flag"].NulllToString();
                        return objResponseData;
                    }
                }
                else
                {
                    objResponseData.Messsage = CustomMessage.NORECORDFOUND;
                    objResponseData.ResponseCode = CustomMessage.NORECORDFOUND_RESPONSECODE.ToString();
                    
                    return objResponseData;
                }


                //param[7] = new SqlParameter("@Certified", modal.Certified);
                //param[8] = new SqlParameter("@CeritifiedExtension", modal.CeritifiedExtension);
                //param[9] = new SqlParameter("@CeritifiedbyContenttype", modal.CeritifiedbyContenttype);

            }
            catch (Exception ex)
            {
                ExceptionLogDL.WriteExceptionDB(ex, "NA", "api", "TrusteeDL:AddCollageAttachemnts", "UNOCapi", "NA");
            }
            return objResponseData;
        }

        public ResponseData AddCollageAttachementMain(TrusteeBO.CollageattachmentAPI modal)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] param = new SqlParameter[10];
                param[0] = new SqlParameter("@Type", "Insert main");
                //param[1] = new SqlParameter("@iFk_TrstId", modal.iFk_TrstId);
                //param[2] = new SqlParameter("@iFk_ClgId", modal.iFk_ClgId);
                param[1] = new SqlParameter("@iFk_CourseId", modal.iFk_CourseId);
                param[2] = new SqlParameter("@sSSOID", modal.sSSOID);
                param[3] = new SqlParameter("@bIsCnnctUnvrctyDrct", modal.bIsCnnctUnvrctyDrctn);
                param[4] = new SqlParameter("@bIsTimeFrm", modal.bIsTimeFrm);
                param[5] = new SqlParameter("@bIsLadDwn", modal.bIsLadDwn);
                param[6] = new SqlParameter("@bIsSffcentLand", modal.bIsSffcentLand);
                param[7] = new SqlParameter("@bIsAffidvtAsprGuid", modal.bIsAffidvtAsprGuid);
                param[8] = new SqlParameter("@bIsOtherDoc", modal.bIsOtherDoc);
                param[9] = new SqlParameter("@Guid", modal.Guid);
                ds = BaseFunction.FillDataSet("[dbo].[USP_ApplcantCollageAttachments_SaveView]", param);
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        objResponseData1.Message = ds.Tables[0].Rows[0]["Message"].NulllToString();
                        objResponseData1.ResponseCode = ds.Tables[0].Rows[0]["Flag"].NulllToString();
                        objResponseData1.ID = ds.Tables[0].Rows[0]["InsertId"].NulllToInt();
                        return objResponseData1;
                    }
                    else
                    {
                        objResponseData1.Message = ds.Tables[0].Rows[0]["Message"].NulllToString();
                        objResponseData1.ResponseCode = ds.Tables[0].Rows[0]["Flag"].NulllToString();
                        return objResponseData1;
                    }
                }
                else
                {
                    objResponseData1.Message = CustomMessage.NORECORDFOUND;
                    objResponseData1.ResponseCode = CustomMessage.NORECORDFOUND_RESPONSECODE.ToString();
                    return objResponseData1;
                }

            }
            catch (Exception ex)
            {
                ExceptionLogDL.WriteExceptionDB(ex, "NA", "api", "TrusteeDL:AddCollageAttachemntsMain", "UNOCapi", "NA");
                return objResponseData1;
            }
        }

        public ErrorBO AddCollageAttachementFiles(TrusteeBO.DocumentsDetails modal)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] param = new SqlParameter[11];
                param[0] = new SqlParameter("@Type", "Insert File");
                param[1] = new SqlParameter("@iFk_TrstId", modal.TrustId);
                param[2] = new SqlParameter("@iFk_ClgId", modal.CollageId);
                param[3] = new SqlParameter("@iFk_CourseId", modal.CourseId);
                param[4] = new SqlParameter("@Filetype", modal.Filetype);
                param[5] = new SqlParameter("@File", modal.file);
                param[6] = new SqlParameter("@Extension", modal.Extension);
                param[7] = new SqlParameter("@ContentType", modal.Contenttype);
                param[8] = new SqlParameter("@EnumNo", modal.EnumNo);
                param[9] = new SqlParameter("@InsertId", modal.Id);
                param[10] = new SqlParameter("@IsYes", modal.Isyes);
                ds = BaseFunction.FillDataSet("[dbo].[USP_ApplcantCollageAttachments_SaveView]", param);

                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        objResponseData.Messsage = ds.Tables[0].Rows[0]["Message"].NulllToString();
                        objResponseData.ResponseCode = ds.Tables[0].Rows[0]["Flag"].NulllToString();
                        return objResponseData;
                    }
                    else
                    {
                        objResponseData.Messsage = ds.Tables[0].Rows[0]["Message"].NulllToString();
                        objResponseData.ResponseCode = ds.Tables[0].Rows[0]["Flag"].NulllToString();
                        return objResponseData;
                    }
                }
                else
                {
                    objResponseData.Messsage = CustomMessage.NORECORDFOUND;
                    objResponseData.ResponseCode = CustomMessage.NORECORDFOUND_RESPONSECODE.ToString();
                    return objResponseData;
                }
            }
            catch (Exception ex)
            {
                ExceptionLogDL.WriteExceptionDB(ex, "NA", "api", "TrusteeDL:AddCollageAttachementFiles", "UNOCapi", "NA");
                return objResponseData;
            }
        }
        
        public ErrorBO TrustVerification(TrusteeBO.TrusteeInfo modal)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] param = new SqlParameter[8];
                param[0] = new SqlParameter("@Type", "TrustVerification");
                param[1] = new SqlParameter("@Name", modal.Name);
                param[2] = new SqlParameter("@RegistrationNo", modal.RegistrationNo);
                param[3] = new SqlParameter("@EmailId", modal.Email);
                param[4] = new SqlParameter("@MobileNo", modal.Email);
                param[5] = new SqlParameter("@AadhaarNo", modal.AadhaarNo);
                param[6] = new SqlParameter("@JanAadhaarNo", modal.JanAadhaarNo);
                param[7] = new SqlParameter("@PanNo", modal.PAN);

                ds = BaseFunction.FillDataSet("[dbo].[USP_ADMIN_TrusteeInfo_SaveView]", param);
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        objResponseData.Messsage = ds.Tables[0].Rows[0]["Message"].NulllToString();
                        objResponseData.ResponseCode = ds.Tables[0].Rows[0]["Flag"].NulllToString();
                        objResponseData.Id = ds.Tables[0].Rows[0]["InsertId"].NulllToString();
                        return objResponseData;
                    }
                    else
                    {
                        objResponseData.Messsage = ds.Tables[0].Rows[0]["Message"].NulllToString();
                        objResponseData.ResponseCode = ds.Tables[0].Rows[0]["Flag"].NulllToString();
                        objResponseData.Id = ds.Tables[0].Rows[0]["InsertId"].NulllToString();
                        return objResponseData;
                    }
                }
                else
                {
                    objResponseData.Messsage = CustomMessage.NORECORDFOUND;
                    objResponseData.ResponseCode = CustomMessage.NORECORDFOUND_RESPONSECODE.ToString();
                    objResponseData.Id = "0";
                    return objResponseData;
                }


                //param[7] = new SqlParameter("@Certified", modal.Certified);
                //param[8] = new SqlParameter("@CeritifiedExtension", modal.CeritifiedExtension);
                //param[9] = new SqlParameter("@CeritifiedbyContenttype", modal.CeritifiedbyContenttype);

            }
            catch (Exception ex)
            {
                ExceptionLogDL.WriteExceptionDB(ex, "NA", "api", "TrusteeDL:TrustVerification", "UNOCapi", "NA");
            }
            return objResponseData;
        }

        public TrusteeBO.TrusteeInfo GetTrustInfo(TrusteeBO.TrusteeInfo _Obj)
        {
            TrusteeBO.TrusteeInfo _result = new TrusteeBO.TrusteeInfo();
            _result.AdminList = new List<AdministrativeDatum>();
            _result.InstituteDetails = new List<TrusteeBO.InstituteDetails>();
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@Type", "GetTrustInfoSingleDetails");
                param[1] = new SqlParameter("@RegistrationNo", _Obj.RegistrationNo);
                ds = BaseFunction.FillDataSet("[dbo].[USP_ADMIN_TrusteeInfo_SaveView]", param);
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[3].Rows.Count > 0)
                    {
                        objResponseData.Messsage = ds.Tables[3].Rows[0]["Message"].NulllToString();
                        objResponseData.ResponseCode = ds.Tables[3].Rows[0]["Flag"].NulllToString();

                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow DR in ds.Tables[0].Rows)
                            {

                                _result.Name = DR["Name"].NulllToString();
                                _result.RegistrationNo = DR["sRgstrnNo"].NulllToString();
                                _result.Act = DR["sAct"].ToString();
                                _result.SSOID = DR["sSSOID"].ToString();
                                _result.Status = DR["sStatus"].ToString();
                                _result.TotalNumberOfMembers = DR["iTotalNumberOfMembers"].ToString();
                                _result.BRN = DR["sBRN"].ToString();
                                _result.District = DR["District"].ToString();
                                _result.TrusteeInfoId = DR["Id"].ToString();
                                _result.TrustType = DR["TrustType"].NulllToString();

                                _result.CertiFiedBy = DR["sCertifiedBy"].NulllToString();
                                _result.RegistrationDate = DR["dtRegstrnDt"].NulllToString();

                                _result.Certified = DR["Certified"].NulllToString();
                                _result.Registration = DR["Registration"].NulllToString();
                                _result.TRMP = DR["TMP"].NulllToString();
                                //_result.TrusteeContentType = DR["TrustContentType"].ToString();
                                _result.TrusteeLogo = DR["TrustLogo"].ToString();
                                _result.Id = DR["Id"].ToString();
                                _result.MemberofMngCommtee = DR["MemberofMngCommtee"].ToString();
                                _result.Morethentree = DR["Morethenthree"].ToString();
                                _result.OtherInstitute = DR["otherIns"].ToString();
                                _result.ElectionDate = DR["ElectionDate"].ToString();
                                _result.LogoCreateDated = DR["LogoCreateDated"].ToString();
                                _result.TrustMembercreatedate = DR["TrustMembercreatedate"].ToString();
                                _result.Mobile = DR["MobileNo"].ToString();
                                _result.Email = DR["Email"].ToString();

                            }
                        }

                        if (ds.Tables[1].Rows.Count > 0)
                        {
                            foreach (DataRow DR in ds.Tables[1].Rows)
                            {

                                _result.AdminList.Add(new AdministrativeDatum
                                {
                                    Occupation = DR["sOccupation"].NulllToString(),
                                    PostName = DR["sPostName"].NulllToString(),
                                    Address = DR["sAddress"].NulllToString(),
                                    ContactNo = DR["sContactNo"].NulllToString(),
                                    Name = DR["sName"].NulllToString(),
                                });
                            }
                        }

                        if (ds.Tables[2].Rows.Count > 0)
                        {
                            foreach (DataRow DR1 in ds.Tables[2].Rows)
                            {

                                _result.InstituteDetails.Add(new TrusteeBO.InstituteDetails
                                {
                                    InstituteName = DR1["sInstudName"].NulllToString(),
                                    ContactPerson = DR1["sCntcPrsn"].NulllToString(),
                                    Number = DR1["sCntcNo"].NulllToString(),
                                });
                            }
                        }

                        return _result;
                    }
                    else
                    {
                        objResponseData.Messsage = ds.Tables[0].Rows[0]["Message"].NulllToString();
                        objResponseData.ResponseCode = ds.Tables[0].Rows[0]["Flag"].NulllToString();
                        return _result;
                    }
                }
                else
                {
                    objResponseData.Messsage = CustomMessage.NORECORDFOUND;
                    objResponseData.ResponseCode = CustomMessage.NORECORDFOUND_RESPONSECODE.ToString();
                    return _result;
                }
            }
            catch (Exception ex)
            {
                objResponseData.Messsage = CustomMessage.EXCEPTIONOCCURRED;
                objResponseData.ResponseCode = CustomMessage.EXCEPTIONOCCURRED_RESPONSECODE.ToString();
                ExceptionLogDL.WriteExceptionDB(ex, "NA", "api", "TrusteeDL:GetTrustInfo", "UNOCapi", "NA");
                return _result;
            }
        }

        public ErrorBO DeleteTrustMemeber(int Id)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@Type", "Delete");
                param[1] = new SqlParameter("@IdentityId", Id);

                ds = BaseFunction.FillDataSet("[dbo].[USP_ADMIN_Trustee_SaveView]", param);
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        objResponseData.Messsage = ds.Tables[0].Rows[0]["Message"].NulllToString();
                        objResponseData.ResponseCode = ds.Tables[0].Rows[0]["Flag"].NulllToString();
                        return objResponseData;
                    }
                    else
                    {
                        objResponseData.Messsage = ds.Tables[0].Rows[0]["Message"].NulllToString();
                        objResponseData.ResponseCode = ds.Tables[0].Rows[0]["Flag"].NulllToString();
                        return objResponseData;
                    }
                }
                else
                {
                    objResponseData.Messsage = CustomMessage.NORECORDFOUND;
                    objResponseData.ResponseCode = CustomMessage.NORECORDFOUND_RESPONSECODE.ToString();
                    return objResponseData;
                }
            }
            catch (Exception ex)
            {
                objResponseData.Messsage = CustomMessage.EXCEPTIONOCCURRED;
                objResponseData.ResponseCode = CustomMessage.EXCEPTIONOCCURRED_RESPONSECODE.ToString();
                ExceptionLogDL.WriteExceptionDB(ex, "NA", "api", "TrusteeDL:DeleteTrustMember", "UNOCapi", "NA");
                return objResponseData;
            }
        }
        
        public ErrorBO TrustVerificationAPI(TrustRoot _obj)
        {
            #region Save Trust Detail
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] param = new SqlParameter[11];
                param[0] = new SqlParameter("@Type", "Insert");
                param[1] = new SqlParameter("@Name", _obj.Data.SocietyName);
                param[2] = new SqlParameter("@TrustType", _obj.Data.Type);
                param[3] = new SqlParameter("@RegistrationNo", _obj.Data.RegistrationNo);
                param[4] = new SqlParameter("@BAR", _obj.Data.BRN);
                param[5] = new SqlParameter("@RegistrationDate", _obj.Data.RegistrationDate);
                param[6] = new SqlParameter("@SSOID", _obj.Data.SSOID);
                param[7] = new SqlParameter("@TotalNumberOfMembers", _obj.Data.TotalNumberOfMembers.NulllToInt());
                param[8] = new SqlParameter("@District", _obj.Data.District);
                param[9] = new SqlParameter("@Act", _obj.Data.Act);
                param[10] = new SqlParameter("@Status", _obj.Data.Status);
                ds = BaseFunction.FillDataSet("[dbo].[USP_ADMIN_TrusteeInfor_SaveView]", param);
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        objResponseData.ResponseCode = ds.Tables[0].Rows[0]["Flag"].NulllToString();
                        if (objResponseData.ResponseCode == "1")
                        {
                            foreach (var itemAdd in _obj.Data.Address)
                            {
                                param = new SqlParameter[7];
                                param[0] = new SqlParameter("@Type", "InsertAddress");
                                param[1] = new SqlParameter("@Block", itemAdd.Block);
                                param[2] = new SqlParameter("@City", itemAdd.City);
                                param[3] = new SqlParameter("@Village", itemAdd.Village);
                                param[4] = new SqlParameter("@GramPanchyat", itemAdd.GramPanchayat);
                                param[5] = new SqlParameter("@PinCode", itemAdd.PinCode);
                                param[6] = new SqlParameter("@RegistrationNo", _obj.Data.RegistrationNo);
                                ds = BaseFunction.FillDataSet("[dbo].[USP_ADMIN_TrusteeInfor_SaveView]", param);
                                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                                {
                                    if (ds.Tables[0].Rows.Count > 0)
                                    {
                                        objResponseData.ResponseCode = ds.Tables[0].Rows[0]["Flag"].NulllToString();
                                        if (objResponseData.ResponseCode == "1")
                                        {

                                        }
                                    }
                                    else
                                    {
                                        //objResponseData.Messsage = ds.Tables[0].Rows[0]["Message"].NulllToString();
                                        //objResponseData.ResponseCode = ds.Tables[0].Rows[0]["Flag"].NulllToString();
                                        //return objResponseData;
                                    }
                                }
                            }
                            foreach (var itemaddmin in _obj.Data.AdministrativeData)
                            {
                                param = new SqlParameter[7];
                                param[0] = new SqlParameter("@Type", "AdministrativData");
                                param[1] = new SqlParameter("@Address", itemaddmin.Address);
                                param[2] = new SqlParameter("@ContactNo", itemaddmin.ContactNo);
                                param[3] = new SqlParameter("@AdminName", itemaddmin.Name);
                                param[4] = new SqlParameter("@Occupation", itemaddmin.Occupation);
                                param[5] = new SqlParameter("@PostName", itemaddmin.PostName);
                                param[6] = new SqlParameter("@RegistrationNo", _obj.Data.RegistrationNo);
                                ds = BaseFunction.FillDataSet("[dbo].[USP_ADMIN_TrusteeInfor_SaveView]", param);
                                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                                {
                                    if (ds.Tables[0].Rows.Count > 0)
                                    {
                                        //objResponseData.Messsage = ds.Tables[0].Rows[0]["Message"].NulllToString();
                                        //objResponseData.ResponseCode = ds.Tables[0].Rows[0]["Flag"].NulllToString();
                                        //return objResponseData;
                                    }
                                    else
                                    {
                                        //    objResponseData.Messsage = ds.Tables[0].Rows[0]["Message"].NulllToString();
                                        //    objResponseData.ResponseCode = ds.Tables[0].Rows[0]["Flag"].NulllToString();
                                        //    return objResponseData;
                                        //}
                                    }
                                }
                            }

                            objResponseData.Messsage = ds.Tables[0].Rows[0]["Message"].NulllToString();
                            objResponseData.ResponseCode = ds.Tables[0].Rows[0]["Flag"].NulllToString();
                            return objResponseData;
                        }
                        else
                        {
                            objResponseData.Messsage = ds.Tables[0].Rows[0]["Message"].NulllToString();
                            objResponseData.ResponseCode = ds.Tables[0].Rows[0]["Flag"].NulllToString();
                            return objResponseData;
                        }
                    }
                    else
                    {
                        objResponseData.Messsage = CustomMessage.NORECORDFOUND;
                        objResponseData.ResponseCode = CustomMessage.NORECORDFOUND_RESPONSECODE.ToString();
                        return objResponseData;
                    }
                }
            }
            catch (Exception ex)
            {
                objResponseData.Messsage = CustomMessage.EXCEPTIONOCCURRED;
                objResponseData.ResponseCode = CustomMessage.EXCEPTIONOCCURRED_RESPONSECODE.ToString();
                ExceptionLogDL.WriteExceptionDB(ex, "NA", "api", "TrusteeDL:TrustVerificationAPI", "UNOCapi", "NA");
                return objResponseData;
            }
            return objResponseData;
            #endregion
        }

        //public ResponseData getDraftApplication(TrusteeBO.SaveApplicationModal modal)
        //{
        //    DataSet ds = new DataSet();
        //    try
        //    {
        //        SqlParameter[] param = new SqlParameter[4];
        //        param[0] = new SqlParameter("@iFKTst_ID", modal.iFKTst_ID);
        //        param[1] = new SqlParameter("@iFKCLG_ID", modal.iFKCLG_ID);
        //        param[2] = new SqlParameter("@iFKDEPT_ID", modal.iFKDEPT_ID);
        //        param[3] = new SqlParameter("@iFK_CORS_ID", modal.iFK_CORS_ID);

        //        ds = BaseFunction.FillDataSet("[dbo].[USP_OPERATION_SaveApplication_View]", param);

        //        if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
        //        {
        //            if (ds.Tables[0].Rows.Count > 0)
        //            {
        //                objResponseData1.Message = ds.Tables[0].Rows[0]["Message"].NulllToString();
        //                objResponseData1.ResponseCode = "0";
        //                objResponseData1.statusCode = 1;
        //                return objResponseData1;
        //            }
        //            else
        //            {
        //                objResponseData1.Message = BO.CustomMessage.NORECORDFOUND;
        //                objResponseData1.ResponseCode = BO.CustomMessage.NORECORDFOUND_RESPONSECODE.ToString();
        //                objResponseData1.statusCode = 0;
        //                return objResponseData1;
        //            }
        //        }
        //        else
        //        {
        //            objResponseData1.Message = BO.CustomMessage.NORECORDFOUND;
        //            objResponseData1.ResponseCode = BO.CustomMessage.NORECORDFOUND_RESPONSECODE.ToString();
        //            objResponseData1.statusCode = 0;
        //            return objResponseData1;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        //objResponseData.Message = BO.CustomMessage.EXCEPTIONOCCURRED;
        //        //objResponseData.ResponseCode = BO.CustomMessage.EXCEPTIONOCCURRED_RESPONSECODE.ToString();
        //        return objResponseData1;
        //    }
        //}


        public ResponseData GETNOCApplicationList(int deptID)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@deptID", deptID);

                ds = BaseFunction.FillDataSet("[dbo].[USP_ADMIN_GETNOCAPPLICATION_Select]", param);

                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        objResponseData1.Message = "NOC Data";
                        objResponseData1.ResponseCode = "0";
                        objResponseData1.statusCode = 1;
                        objResponseData1.Data = ds.Tables[0];
                        return objResponseData1;
                    }
                    else
                    {
                        objResponseData1.Message = "No Record Found";
                        objResponseData1.ResponseCode = "001";
                        objResponseData1.statusCode = 0;
                        return objResponseData1;
                    }
                }
                else
                {
                    objResponseData1.Message = "No Record Found";
                    objResponseData1.ResponseCode = "001";
                    objResponseData1.statusCode = 0;
                    return objResponseData1;
                }
            }
            catch (Exception ex)
            {
                objResponseData1.Message = "Facing Some Internal Issue";
                objResponseData1.ResponseCode = "001";
                objResponseData1.statusCode = 0;
                return objResponseData1;
            }
        }

        public ResponseData GETNOCApplicationClgList(int deptID)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@deptId", deptID);

                ds = BaseFunction.FillDataSet("[dbo].[USP_ADMIN_GETNOCAPPLICATIONCollege_Select]", param);

                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        objResponseData1.Message = "NOC College Data";
                        objResponseData1.ResponseCode = "0";
                        objResponseData1.statusCode = 1;
                        objResponseData1.Data = ds.Tables[0];
                        return objResponseData1;
                    }
                    else
                    {
                        objResponseData1.Message = "No Record Found";
                        objResponseData1.ResponseCode = "001";
                        objResponseData1.statusCode = 0;
                        return objResponseData1;
                    }
                }
                else
                {
                    objResponseData1.Message = "No Record Found";
                    objResponseData1.ResponseCode = "001";
                    objResponseData1.statusCode = 0;
                    return objResponseData1;
                }
            }
            catch (Exception ex)
            {
                objResponseData1.Message = "Facing Some Internal Issue";
                objResponseData1.ResponseCode = "001";
                objResponseData1.statusCode = 0;
                return objResponseData1;
            }
        }


        #region AddComments by Vivek

        public ResponseData AddComments(InspectionComments comments)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] param = new SqlParameter[8];
                param[0] = new SqlParameter("@sUsrId", comments.sUsrId);
                param[1] = new SqlParameter("@sDiscription", comments.sDiscription);
                param[2] = new SqlParameter("@sUpdimg", comments.sUpdimg);
                param[3] = new SqlParameter("@sAppid", comments.sAppid);
                param[4] = new SqlParameter("@sPageName", comments.sPageName);
                param[5] = new SqlParameter("@iFK_FieldId", comments.iFK_FieldId);
                param[6] = new SqlParameter("@iVal", comments.iVal);
                param[7] = new SqlParameter("@type", comments.type);

                ds = BaseFunction.FillDataSet("[dbo].[USP_OPERATION_AddComments_Insert]", param);

                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    //if (ds.Tables[0].Rows.Count > 0)
                    //{
                    objResponseData1.Message = "Comments Data";
                    objResponseData1.ResponseCode = "0";
                    objResponseData1.statusCode = 1;
                    if (comments.type == "Select")
                        objResponseData1.Data = ds.Tables[0];
                    else
                        objResponseData1.Data = null;

                    return objResponseData1;
                    //}
                    //else
                    //{
                    //    objResponseData1.Message = "No Record Found";
                    //    objResponseData1.ResponseCode = "001";
                    //    objResponseData1.statusCode = 0;
                    //    return objResponseData1;
                    //}
                }
                else
                {
                    objResponseData1.Message = "No Record Found";
                    objResponseData1.ResponseCode = "001";
                    objResponseData1.statusCode = 0;
                    return objResponseData1;
                }
            }
            catch (Exception ex)
            {
                objResponseData1.Message = "Facing Some Internal Issue";
                objResponseData1.ResponseCode = "001";
                objResponseData1.statusCode = 0;
                return objResponseData1;
            }
        }
        public ResponseData AddOldNOC(List<TrusteeBO.OldNOCData> oldNOCData)
        {
            DataSet ds = new DataSet();
            try
            {
                if (oldNOCData != null && oldNOCData.Count > 0)
                {
                    foreach (var item in oldNOCData)
                    {
                        var subjectIDCollection = "";
                        var subjectListID = item.subjectIDList.Split(',');
                        foreach (var j in subjectListID)
                        {
                            subjectIDCollection = j.Split('-')[1];

                            SqlParameter[] param = new SqlParameter[14];
                            param[0] = new SqlParameter("@iFk_ClgID", item.iFk_ClgID);
                            param[1] = new SqlParameter("@iFk_CORSID", item.iFk_CORSID);
                            param[2] = new SqlParameter("@iNocTypID", item.iNocTypID);
                            param[3] = new SqlParameter("@iFk_SYID", item.iFk_SYID);
                            param[4] = new SqlParameter("@sNOCNo", item.sNOCNo);
                            param[5] = new SqlParameter("@dtNOCRcvdOn", item.dtNOCRcvdOn);
                            param[6] = new SqlParameter("@dtNOCExprOn", item.dtNOCExprOn);
                            param[7] = new SqlParameter("@sRemrk", item.sRemrk);
                            param[8] = new SqlParameter("@OldNOCData", item.NocDoc);
                            param[9] = new SqlParameter("@OldNOCDataExtension", item.NocDocExtension);
                            param[10] = new SqlParameter("@OldNOCDataContentType", item.NocDocContent);
                            param[11] = new SqlParameter("@ifk_subjId", subjectIDCollection);
                            param[12] = new SqlParameter("@issFyr", item.issuedForYear);
                            param[13] = new SqlParameter("@guid", item.appGUID);


                            ds = BaseFunction.FillDataSet("[dbo].[USP_ADMIN_AddOLDNOCData_Insert]", param);

                            if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                            {
                                //if (ds.Tables[0].Rows.Count > 0)
                                //{
                                objResponseData1.Message = ds.Tables[0].Rows[0]["Message"].ToString();
                                objResponseData1.ResponseCode = "0";
                                objResponseData1.statusCode = 1;
                                //}
                                //else
                                //{
                                //    objResponseData1.Message = "No Record Found";
                                //    objResponseData1.ResponseCode = "001";
                                //    objResponseData1.statusCode = 0;
                                //    return objResponseData1;
                                //}
                            }
                            else
                            {
                                objResponseData1.Message = "No Record Found";
                                objResponseData1.ResponseCode = "001";
                                objResponseData1.statusCode = 0;

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                objResponseData1.Message = "Facing Some Internal Issue";
                objResponseData1.ResponseCode = "001";
                objResponseData1.statusCode = 0;
                // return objResponseData1;
            }
            return objResponseData1;
        }

        public ResponseData SaveMultipleNOC(TrusteeBO.SaveApplicationModal model)
        {
            DataSet ds = new DataSet();
            var applicationNumber = "";
            try
            {

                if (model.type == "NOC")
                {

                    SqlParameter[] param = new SqlParameter[3];
                    param[0] = new SqlParameter("@stypeID", model.stypeID);
                    param[1] = new SqlParameter("@iFK_ClgID", model.iFKCLG_ID);
                    param[2] = new SqlParameter("@iFK_DeptID", model.iFKDEPT_ID);

                    ds = BaseFunction.FillDataSet("[dbo].[USP_ADMIN_AddMultipleNOC_Insert]", param);
                }
                else
                {
                    SqlParameter[] param = new SqlParameter[3];
                    param[0] = new SqlParameter("@stypeID", model.type);
                    param[1] = new SqlParameter("@iFK_ClgID", model.iFKCLG_ID);
                    param[2] = new SqlParameter("@iFK_DeptID", model.iFKDEPT_ID);
                    ds = BaseFunction.FillDataSet("[dbo].[USP_ADMIN_AddMultipleNOC_Insert]", param);
                }

                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    //if (ds.Tables[0].Rows.Count > 0)
                    //{
                    objResponseData1.Message = ds.Tables[0].Rows[0]["Message"].ToString();
                    applicationNumber = ds.Tables[0].Rows[0]["ApplicationNumber"].ToString();
                    objResponseData1.ResponseCode = "0";
                    objResponseData1.UserID = applicationNumber;
                    objResponseData1.statusCode = 1;
                    //}
                    //else
                    //{
                    //    objResponseData1.Message = "No Record Found";
                    //    objResponseData1.ResponseCode = "001";
                    //    objResponseData1.statusCode = 0;
                    //    return objResponseData1;
                    //}


                    if (applicationNumber != null || !string.IsNullOrEmpty(applicationNumber))
                    {
                        if (model.courseData.Count > 0 && model.courseData != null)
                        {
                            foreach (var item in model.courseData)
                            {
                                SaveTransationData(applicationNumber, item);
                            }
                        }
                        
                        if (model.subjData.Count > 0 && model.subjData != null)
                        {
                            foreach (var item in model.subjData)
                            {
                                SaveTransationData(applicationNumber, new CourseDataForNOC { courseID = item.courseID, pkId = item.pkId, subjectIdList = item.subjectIdList, TypeId = item.TypeId });
                            }
                        }

                        if (model.TnocData.Count > 0 && model.TnocData != null)
                        {
                            foreach (var item in model.TnocData)
                            {
                                SaveTransationData(applicationNumber, new CourseDataForNOC { courseID = item.courseID, pkId = item.pkId, subjectIdList = item.subID.ToString(), TypeId = item.typeID });
                            }
                        }

                        if (model.PnocData.Count > 0 && model.PnocData != null)
                        {
                            foreach (var item in model.PnocData)
                            {
                                SaveTransationData(applicationNumber, new CourseDataForNOC { courseID = item.courseID, pkId = item.pkId, subjectIdList = item.subID.ToString(), TypeId = item.typeID });
                            }
                        }

                    }
                }
                else
                {
                    objResponseData1.Message = "No Record Found";
                    objResponseData1.ResponseCode = "001";
                    objResponseData1.statusCode = 0;
                    objResponseData1.UserID = applicationNumber;
                }
            }
            catch (Exception ex)
            {
                objResponseData1.Message = "Facing Some Internal Issue";
                objResponseData1.ResponseCode = "001";
                objResponseData1.statusCode = 0;
                objResponseData1.UserID = applicationNumber;
                // return objResponseData1;
            }
            return objResponseData1;
        }


        public ResponseData SaveTransationData(string applicationNumber, CourseDataForNOC model)
        {
            var ds = new DataSet();
            var draftid = "";
            if (model.pkId == "" || !string.IsNullOrEmpty(model.pkId))
            {
                draftid = model.courseID.ToString();
            }
            else
            {
                draftid = model.pkId;
            }
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@sFKDeptApplID", applicationNumber);
            param[1] = new SqlParameter("@iTypeID", model.TypeId);
            param[2] = new SqlParameter("@iCorsID", model.courseID);
            param[3] = new SqlParameter("@sSubID", model.subjectIdList);
            param[4] = new SqlParameter("@sDraftAppID", draftid);

            ds = BaseFunction.FillDataSet("[dbo].[USP_ADMIN_AddMultipleNOCTransection_Insert]", param);

            if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
            {
                //if (ds.Tables[0].Rows.Count > 0)
                //{
                objResponseData1.Message = ds.Tables[0].Rows[0]["Message"].ToString();
                objResponseData1.ResponseCode = "0";
                objResponseData1.statusCode = 1;
                //}
                //else
                //{
                //    objResponseData1.Message = "No Record Found";
                //    objResponseData1.ResponseCode = "001";
                //    objResponseData1.statusCode = 0;
                //    return objResponseData1;
                //}

            }
            else
            {
                objResponseData1.Message = "No Record Found";
                objResponseData1.ResponseCode = "001";
                objResponseData1.statusCode = 0;

            }


            return objResponseData1;
        }
        #endregion

        public ErrorBO SaveOtherTrustDetails(TrusteeBO.TrusteeInfo _obj)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] param = new SqlParameter[38];
                param[0] = new SqlParameter("@Type", "Insert");

                param[1] = new SqlParameter("@Certified", _obj.Certified);
                param[2] = new SqlParameter("@CeritifiedExtension", _obj.CeritifiedExtension);
                param[3] = new SqlParameter("@CeritifiedbyContenttype", _obj.CeritifiedbyContenttype);

                param[4] = new SqlParameter("@Registration", _obj.Registration);
                param[5] = new SqlParameter("@RegistrationExtension", _obj.RegistrationExtension);
                param[6] = new SqlParameter("@RegistrationContenttype", _obj.RegistrationContenttype);

                param[7] = new SqlParameter("@TrusteeLogo", _obj.TrusteeLogo);
                param[8] = new SqlParameter("@TrusteeExtension", _obj.TrusteeExtension);
                param[9] = new SqlParameter("@TrusteeContenttype", _obj.TrusteeContentType);

                param[10] = new SqlParameter("@TrusteeMemberProof", _obj.TRMP);
                param[11] = new SqlParameter("@TrusteeMemberProofExtension", _obj.TRMPExtension);
                param[12] = new SqlParameter("@TrusteeMemberProofContentType", _obj.TRMPContenttype);
                param[13] = new SqlParameter("@IdentityId", _obj.TrusteeInfoId.NulllToInt());

                param[14] = new SqlParameter("@ElectionDate", _obj.ElectionDate);
                param[15] = new SqlParameter("@MemberofMngCommtee", _obj.MemberofMngCommtee.NulllToInt());
                param[16] = new SqlParameter("@Morethentree", _obj.Morethentree.NulllToInt());
                param[17] = new SqlParameter("@OtherInstitute", _obj.OtherInstitute.NulllToInt());

                param[18] = new SqlParameter("@TrustType", _obj.TrustType);
                param[19] = new SqlParameter("@Name", _obj.Name);
                param[20] = new SqlParameter("@RegistrationNo", _obj.RegistrationNo);
                param[21] = new SqlParameter("@Status", _obj.Status);

                param[22] = new SqlParameter("@Act", _obj.Act);
                param[23] = new SqlParameter("@District", _obj.District);
                param[24] = new SqlParameter("@RegistrationDate", _obj.RegistrationDate);
                param[25] = new SqlParameter("@MobileNo", _obj.Mobile);

                param[26] = new SqlParameter("@EmailId", _obj.Email);
                param[27] = new SqlParameter("@PAN", _obj.PAN);
                param[28] = new SqlParameter("@Aadhaarfile", _obj.Aadhaarfile);
                param[29] = new SqlParameter("@AadhaarExtension", _obj.AadhaarExtension);
                param[30] = new SqlParameter("@AadhaarContenttype", _obj.AadhaarContenttype);

                param[31] = new SqlParameter("@Panfile", _obj.Panfile);
                param[32] = new SqlParameter("@PanExtension", _obj.PanExtension);
                param[33] = new SqlParameter("@PanContenttype", _obj.PanContenttype);
                param[34] = new SqlParameter("@Address", _obj.Address);
                param[35] = new SqlParameter("@Tan", _obj.TAN);
                param[36] = new SqlParameter("@CertiFiedBy", _obj.CertiFiedBy);
                param[37] = new SqlParameter("@AadhaarNo", _obj.AadhaarNo);

                DataTable dt = BaseFunction.FillDataTable("[dbo].[USP_ADMIN_OtherTrustDetail_SaveUpdate]", param);

                if (_obj.InstituteDetails != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["Id"] != null)
                        {
                            for (int i = 0; i <= _obj.InstituteDetails.Count - 1; i++) //Rows.Count - 1; i++
                            {
                                SqlParameter[] param1 = new SqlParameter[5];
                                param1[0] = new SqlParameter("@Type", "InsertInstitute");
                                param1[1] = new SqlParameter("@InstituteName", _obj.InstituteDetails[i].InstituteName);
                                param1[2] = new SqlParameter("@IdentityId", _obj.TrusteeInfoId.NulllToInt());
                                param1[3] = new SqlParameter("@ContactPerson", _obj.InstituteDetails[i].ContactPerson);  //uniContactsTable.Rows[i]["Number"].ToString());
                                param1[4] = new SqlParameter("@Number", _obj.InstituteDetails[i].Number); //uniContactsTable.Rows[i]["Email"].ToString());
                                ds = BaseFunction.FillDataSet("[dbo].[USP_ADMIN_TrusteeInfo_SaveView]", param1);

                            }
                        }
                    }
                }

                if (dt != null && dt.Rows.Count > 0)
                {
                    if (dt.Rows.Count > 0)
                    {
                        objResponseData.Messsage = dt.Rows[0]["Message"].NulllToString();
                        objResponseData.ResponseCode = dt.Rows[0]["Flag"].NulllToString();
                        objResponseData.Id = dt.Rows[0]["Id"].NulllToString();
                        objResponseData.Name = dt.Rows[0]["TrustName"].NulllToString();
                        return objResponseData;
                    }
                    else
                    {
                        objResponseData.Messsage = dt.Rows[0]["Message"].NulllToString();
                        objResponseData.ResponseCode = dt.Rows[0]["Flag"].NulllToString();
                        objResponseData.Id = dt.Rows[0]["Id"].NulllToString();
                        objResponseData.Name = dt.Rows[0]["TrustName"].NulllToString();
                        return objResponseData;
                    }
                }
                else
                {
                    objResponseData.Messsage = CustomMessage.NORECORDFOUND;
                    objResponseData.ResponseCode = CustomMessage.NORECORDFOUND_RESPONSECODE.ToString();
                    return objResponseData;
                }
            }
            catch (Exception ex)
            {
                objResponseData.Messsage = CustomMessage.EXCEPTIONOCCURRED;
                objResponseData.ResponseCode = CustomMessage.EXCEPTIONOCCURRED_RESPONSECODE.ToString();
                ExceptionLogDL.WriteExceptionDB(ex, "NA", "api", "TrusteeDL:SaveTrusteeInfo", "UNOCapi", "NA");
                return objResponseData;
            }
        }

        public List<CollegeAmendmentList> CollageAmendment(string GUID)
        {
            List<CollegeAmendmentList> _result = new List<CollegeAmendmentList>();
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@Type", "GetBasicInfo");
                param[1] = new SqlParameter("@GUID", GUID);

                ds = BaseFunction.FillDataSet("[dbo].[USP_MASTER_BasicInfo]", param);
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        objResponseData.Messsage = ds.Tables[1].Rows[0]["Message"].NulllToString();
                        objResponseData.ResponseCode = ds.Tables[1].Rows[0]["StatusCode"].NulllToString();

                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow DR in ds.Tables[0].Rows)
                            {
                                _result.Add(new CollegeAmendmentList
                                {
                                    iPk_ClgID = DR["iPk_ClgID"].NulllToInt(),
                                    NameOfClg = DR["sNameOfClg"].NulllToString(),


                                });
                            }
                        }

                        return _result;
                    }
                    else
                    {
                        objResponseData.Messsage = ds.Tables[0].Rows[0]["Message"].NulllToString();
                        objResponseData.ResponseCode = ds.Tables[0].Rows[0]["Flag"].NulllToString();
                        return _result;
                    }
                }
                else
                {
                    objResponseData.Messsage = CustomMessage.NORECORDFOUND;
                    objResponseData.ResponseCode = CustomMessage.NORECORDFOUND_RESPONSECODE.ToString();
                    return _result;
                }
            }
            catch (Exception ex)
            {
                objResponseData.Messsage = CustomMessage.EXCEPTIONOCCURRED;
                objResponseData.ResponseCode = CustomMessage.EXCEPTIONOCCURRED_RESPONSECODE.ToString();
                ExceptionLogDL.WriteExceptionDB(ex, "NA", "api", "TrusteeDL:CollageListApply", "UNOCapi", "NA");
                return _result;
            }
        }

        public List<CollegeAmendmentListEdit> GetEditData(int id)
        {
            List<CollegeAmendmentListEdit> _result = new List<CollegeAmendmentListEdit>();
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@Type", "GetBasicInfoEdit");
                param[1] = new SqlParameter("@GUID", id);

                ds = BaseFunction.FillDataSet("[dbo].[USP_MASTER_BasicInfo]", param);
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        objResponseData.Messsage = ds.Tables[1].Rows[0]["Message"].NulllToString();
                        objResponseData.ResponseCode = ds.Tables[1].Rows[0]["StatusCode"].NulllToString();

                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow DR in ds.Tables[0].Rows)
                            {
                                _result.Add(new CollegeAmendmentListEdit
                                {


                                    iPk_ClgID = DR["iPk_ClgID"].NulllToInt(),
                                    iFk_DistId = DR["iFk_DistId"].NulllToInt(),
                                    iFk_ThslId = DR["iFk_ThslId"].NulllToInt(),
                                    Addressoneold = DR["sAddressLine1"].NulllToString(),
                                    Addresstwoold = DR["sAddressLine2"].NulllToString(),
                                    iFk_TrstInfoId = DR["iFk_TrstInfoId"].NulllToInt()

                                });
                            }
                        }

                        return _result;
                    }
                    else
                    {
                        objResponseData.Messsage = ds.Tables[0].Rows[0]["Message"].NulllToString();
                        objResponseData.ResponseCode = ds.Tables[0].Rows[0]["Flag"].NulllToString();
                        return _result;
                    }
                }
                else
                {
                    objResponseData.Messsage = CustomMessage.NORECORDFOUND;
                    objResponseData.ResponseCode = CustomMessage.NORECORDFOUND_RESPONSECODE.ToString();
                    return _result;
                }
            }
            catch (Exception ex)
            {
                objResponseData.Messsage = CustomMessage.EXCEPTIONOCCURRED;
                objResponseData.ResponseCode = CustomMessage.EXCEPTIONOCCURRED_RESPONSECODE.ToString();
                ExceptionLogDL.WriteExceptionDB(ex, "NA", "api", "TrusteeDL:CollageListApply", "UNOCapi", "NA");
                return _result;
            }
        }

        public List<CustomList> GetSubjectList(string sGUID, string CourseId)
        {
            List<CustomList> objListdoc = new List<CustomList>();
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@Type", "SubjectListDropDown");
                param[1] = new SqlParameter("@sGUID", sGUID);
                param[2] = new SqlParameter("@CourseId", CourseId.NulllToInt());
                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_ADMIN_SubjectListDropDown]", param);
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    objListdoc = new List<CustomList>();

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        CustomList objdoc = new CustomList();
                        objdoc.Id = ds.Tables[0].Rows[i]["Id"].NulllToInt();
                        objdoc.text = ds.Tables[0].Rows[i]["CustomName"].NulllToString();
                        objListdoc.Add(objdoc);
                    }
                }
                else
                {
                    objListdoc = null;
                }
            }
            catch (Exception ex)
            {
                objListdoc = null;
                ExceptionLogDL.WriteExceptionDB(ex, "NA", "api", "TrusteeDL:GetTrustDropDownList", "UNOCapi", "NA");
            }
            return objListdoc;
        }

        public List<CustomList> GetCourseList(string sGUID)
        {
            List<CustomList> objListdoc = new List<CustomList>();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@Type", "CourseListDropDown");
                param[1] = new SqlParameter("@sGUID", sGUID);
                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_ADMIN_SubjectListDropDown]", param);
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    objListdoc = new List<CustomList>();

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        CustomList objdoc = new CustomList();
                        objdoc.Id = ds.Tables[0].Rows[i]["Id"].NulllToInt();
                        objdoc.text = ds.Tables[0].Rows[i]["CustomName"].NulllToString();
                        objListdoc.Add(objdoc);
                    }
                }
                else
                {
                    objListdoc = null;
                }
            }
            catch (Exception ex)
            {
                objListdoc = null;
                ExceptionLogDL.WriteExceptionDB(ex, "NA", "api", "TrusteeDL:GetTrustDropDownList", "UNOCapi", "NA");
            }
            return objListdoc;
        }

        //public ResponseData InsertArchitechDetaile(List<Architecturesave> Mst)
        //{
        //    DataSet ds = new DataSet();
        //    var applicationNumber = "";
        //    try
        //    {
        //        foreach (var item in Mst)
        //        {

        //            SqlParameter[] param = new SqlParameter[8];
        //            param[0] = new SqlParameter("@Guid", item.Guid);
        //            param[1] = new SqlParameter("@sGuidid", item.sGuidid);
        //            param[2] = new SqlParameter("@course", item.course);
        //            param[3] = new SqlParameter("@coursetext", item.coursetext);
        //            param[4] = new SqlParameter("@Width", item.Width);
        //            param[5] = new SqlParameter("@length", item.length);
        //            param[6] = new SqlParameter("@Qty", item.Qty);
        //            param[7] = new SqlParameter("@istts", item.iStts);
        //            DataTable DT = BaseFunction.FillDataTable("[dbo].[USP_Admin_ArchitectureDetail_Insert]", param);
        //            if (DT != null)
        //            {
        //                if (DT.Rows.Count > 0)
        //                {
        //                    objResponseData1.statusCode = Convert.ToInt32(DT.Rows[0]["StatusCode"]);
        //                    objResponseData1.Message = DT.Rows[0]["Message"].ToString();
        //                }
        //            }

        //            else
        //            {
        //                objResponseData1.Message = "No Record Found";
        //                objResponseData1.ResponseCode = "001";
        //                objResponseData1.statusCode = 0;
        //                objResponseData1.UserID = applicationNumber;
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        objResponseData1.Message = "Facing Some Internal Issue";
        //        objResponseData1.ResponseCode = "001";
        //        objResponseData1.statusCode = 0;
        //        objResponseData1.UserID = applicationNumber;
        //        // return objResponseData1;
        //    }
        //    return objResponseData1;
        //}

        public ResponseData UpdateFeeForApplication(string applicationNumber, decimal totalFee)
        {
            DataSet ds = new DataSet();
            try
            {

                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@appNO", applicationNumber);
                param[1] = new SqlParameter("@fee", totalFee);

                DataTable DT = BaseFunction.FillDataTable("[dbo].[USP_OPERATION_UPDATETotalFeeForApplication_Update]", param);
                if (DT != null)
                {
                    if (DT.Rows.Count > 0)
                    {
                        objResponseData1.statusCode = Convert.ToInt32(DT.Rows[0]["StatusCode"]);
                        objResponseData1.Message = DT.Rows[0]["Message"].ToString();
                    }
                }

                else
                {
                    objResponseData1.Message = "No Record Found";
                    objResponseData1.ResponseCode = "001";
                    objResponseData1.statusCode = 0;
                    objResponseData1.UserID = applicationNumber;
                }

            }
            catch (Exception ex)
            {
                objResponseData1.Message = "Facing Some Internal Issue";
                objResponseData1.ResponseCode = "001";
                objResponseData1.statusCode = 0;
                // return objResponseData1;
            }
            return objResponseData1;
        }

        public List<CollageAttachment> GetCollageAttachment(string Guid)
        {
            DataSet ds = new DataSet();
            List<CollageAttachment> _result = new List<CollageAttachment>();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@Type", "Detail");
                param[1] = new SqlParameter("@Guid", Guid);
                ds = BaseFunction.FillDataSet("[dbo].[USP_ApplcantCollageAttachments_SaveView]", param);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow DR in ds.Tables[0].Rows)
                        {
                            _result.Add(new CollageAttachment
                            {
                                affidavitfile = DR["f11"].NulllToString(),
                                SalaryPaymentfile = DR["f1"].NulllToString(),
                                Bankstatementfile = DR["f2"].NulllToString(),
                                Annexurefile = DR["f3"].NulllToString(),
                                EsiDocfile = DR["f4"].NulllToString(),

                                bIsCnnctUnvrctyDrctn = DR["bIsCnnctUnvrctyDrctn"].NulllToInt(),
                                bIsCnnctUnvrctyDrctfiles = DR["f5"].NulllToString(),

                                bIsTimeFrm = DR["bIsTimeFrm"].NulllToInt(),
                                bIsTimeFrmfiles = DR["f6"].NulllToString(),

                                bIsLadDwn = DR["bIsLadDwn"].NulllToInt(),
                                bIsLadDwnfiles = DR["f7"].NulllToString(),

                                bIsSffcentLand = DR["bIsSffcentLand"].NulllToInt(),
                                bIsSffcentLandfiles = DR["f8"].NulllToString(),

                                bIsAffidvtAsprGuid = DR["bIsAffidvtAsprGuid"].NulllToInt(),
                                bIsAffidvtAsprGuidfiles = DR["f9"].NulllToString(),


                                bIsOtherDoc = DR["bIsOtherDoc"].NulllToInt(),
                                bIsOtherDocfiles = DR["f10"].NulllToString(),

                                Course = DR["Course"].NulllToString(),
                            });
                        }
                    }
                }
                return _result;
            }
            catch (Exception ex)
            {

            }
            return _result;
        }

        public string GetGUID(string Type, string TrustId, string ColgId, string DeptId, string CourseId = null)
        {
            string Guid = string.Empty;
            try
            {
                SqlParameter[] param = new SqlParameter[5];
                param[0] = new SqlParameter("@TrustId", TrustId);
                param[1] = new SqlParameter("@ColgId", ColgId);
                param[2] = new SqlParameter("@DeptId", DeptId);
                param[3] = new SqlParameter("@CourseId", CourseId);
                param[4] = new SqlParameter("@Type", Type);
                DataTable DT = BaseFunction.FillDataTable("[dbo].[USP_OPERATION_GetGuidByTrustDeptCol]", param);
                if (DT != null)
                {
                    if (DT.Rows.Count > 0)
                    {
                        Guid = DT.Rows[0]["sGuid"].NulllToString();
                    }
                }
                return Guid;
            }
            catch (Exception ex)
            {

            }
            return Guid;
        }
        public ResponseData InsertArchitechDetaile(List<Architecturesave> Mst)
        {
            DataSet ds = new DataSet();
            var applicationNumber = "";
            var type = 0;
            try
            {
                foreach (var item in Mst)
                {

                    SqlParameter[] param = new SqlParameter[11];
                    param[0] = new SqlParameter("@Guid", item.Guid);
                    param[1] = new SqlParameter("@sGuidid", item.sGuidid);
                    param[2] = new SqlParameter("@course", item.courseId);
                    param[3] = new SqlParameter("@coursetext", item.coursetext);
                    param[4] = new SqlParameter("@Width", item.Width);
                    param[5] = new SqlParameter("@length", item.length);
                    param[6] = new SqlParameter("@Qty", item.Qty);
                    param[7] = new SqlParameter("@istts", item.iStts);
                    param[8] = new SqlParameter("@filedata", item.filedata);
                    param[9] = new SqlParameter("@sProfileExtension", item.sProfileExtension);
                    param[10] = new SqlParameter("@Type", item.Type);

                    DataTable DT = BaseFunction.FillDataTable("[dbo].[USP_Admin_ArchitectureDetail_Insert]", param);

                    if (DT != null)
                    {
                        if (DT.Rows.Count > 0)
                        {
                            objResponseData1.statusCode = Convert.ToInt32(DT.Rows[0]["StatusCode"]);
                            objResponseData1.Message = DT.Rows[0]["Message"].ToString();
                        }
                    }

                    else
                    {
                        objResponseData1.Message = "No Record Found";
                        objResponseData1.ResponseCode = "001";
                        objResponseData1.statusCode = 0;
                        objResponseData1.UserID = applicationNumber;
                    }
                }
                type = Mst.FirstOrDefault().Type.Value;
                applicationNumber = Mst.FirstOrDefault().Guid;
                SqlParameter[] param1 = new SqlParameter[2];
                param1[0] = new SqlParameter("@Guid", applicationNumber);
                param1[1] = new SqlParameter("@type", type);
                DataTable DT1 = BaseFunction.FillDataTable("[dbo].[USP_Admin_Arch_MST_Apln_Update]", param1);
                if (DT1 != null)
                {
                    if (DT1.Rows.Count > 0)
                    {
                        objResponseData1.statusCode = Convert.ToInt32(DT1.Rows[0]["StatusCode"]);
                        objResponseData1.Message = DT1.Rows[0]["Message"].ToString();
                    }
                }

                else
                {
                    objResponseData1.Message = "No Record Found";
                    objResponseData1.ResponseCode = "001";
                    objResponseData1.statusCode = 0;
                    objResponseData1.UserID = applicationNumber;
                }
            }
            catch (Exception ex)
            {
                objResponseData1.Message = "Facing Some Internal Issue";
                objResponseData1.ResponseCode = "001";
                objResponseData1.statusCode = 0;
                objResponseData1.UserID = applicationNumber;
                // return objResponseData1;
            }
            return objResponseData1;
        }


        public List<Architecturesave> GetArchitectureData(string sAppId, int Type)
        {
            List<Architecturesave> objListdoc = new List<Architecturesave>();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@sApplication", sAppId);
                param[1] = new SqlParameter("@Type", Type);
                DataSet ds = BaseFunction.FillDataSet("[dbo].[Usp_Architecture_Details_View]", param);
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    objListdoc = new List<Architecturesave>();

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        Architecturesave objdoc = new Architecturesave();
                        objdoc.Guid = ds.Tables[0].Rows[i]["sApplNo"].NulllToString();
                        objdoc.courseId = ds.Tables[0].Rows[i]["iFK_CORS_ID"].NulllToInt();
                        objdoc.coursetext = ds.Tables[0].Rows[i]["coursetext"].NulllToString();
                        objdoc.sGuidid = ds.Tables[0].Rows[i]["Guid"].NulllToString();
                        objdoc.iStts = ds.Tables[0].Rows[i]["iStts"].NulllToInt();
                        objdoc.Width = ds.Tables[0].Rows[i]["Width"].NulllToInt();
                        objdoc.length = ds.Tables[0].Rows[i]["length"].NulllToInt();
                        objdoc.Qty = ds.Tables[0].Rows[i]["Qty"].NulllToInt();
                        objdoc.filedata = ds.Tables[0].Rows[i]["filedata"].NulllToString();
                        objdoc.sProfileExtension = ds.Tables[0].Rows[i]["sProfileExtension"].NulllToString();
                        objdoc.Type = ds.Tables[0].Rows[i]["iType"].NulllToInt();
                        objListdoc.Add(objdoc);
                    }
                }
                else
                {
                    objListdoc = null;
                }
            }
            catch (Exception ex)
            {
                objListdoc = null;
                ExceptionLogDL.WriteExceptionDB(ex, "NA", "api", "TrusteeDL:GetTrustDropDownList", "UNOCapi", "NA");
            }
            return objListdoc;
        }

        public ResponseData RemoveData(int id)
        {
            ResponseData objlist = new ResponseData();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@Id", id);

                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_MASTER_FacilityCourse_RemoveData]", param);
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    objlist.statusCode = Convert.ToInt32(ds.Tables[0].Rows[0]["StatusCode"]);
                    objlist.Message = ds.Tables[0].Rows[0]["Message"].ToString();

                }
                else
                {
                    objlist.statusCode = 0;
                    objlist.Message = "Failed";
                }
            }
            catch (Exception e)
            {
                objlist = null;
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : TargetDL / Function : GetTarget");
            }
            return objlist;
        }

        public TrusteeBO.Trustee GetFacilitesImagesList(string GUID, int Identity)
        {
            TrusteeBO.Trustee _result = new TrusteeBO.Trustee();
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@Type", "DocumentDetails");
                param[1] = new SqlParameter("@GUID", GUID);
                param[2] = new SqlParameter("@IdentityId", Identity);
                ds = BaseFunction.FillDataSet("[dbo].[USP_Facility_List]", param);
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        objResponseData.Messsage = ds.Tables[1].Rows[0]["Message"].NulllToString();
                        objResponseData.ResponseCode = ds.Tables[1].Rows[0]["Flag"].NulllToString();

                        if (ds.Tables[0].Rows.Count > 0)
                        {

                            _result.Aadhaar = ds.Tables[0].Rows[0]["ImagesDowload"].ToString();
                            _result.AadhaarExtension = ds.Tables[0].Rows[0]["DocumentExtension"].NulllToString();
                            _result.AadhaarContentType = ds.Tables[0].Rows[0]["DocumentContent"].NulllToString();

                        }

                        return _result;
                    }
                    else
                    {
                        objResponseData.Messsage = ds.Tables[0].Rows[0]["Message"].NulllToString();
                        objResponseData.ResponseCode = ds.Tables[0].Rows[0]["Flag"].NulllToString();
                        return _result;
                    }
                }
                else
                {
                    objResponseData.Messsage = CustomMessage.NORECORDFOUND;
                    objResponseData.ResponseCode = CustomMessage.NORECORDFOUND_RESPONSECODE.ToString();
                    return _result;
                }
            }
            catch (Exception ex)
            {
                objResponseData.Messsage = CustomMessage.EXCEPTIONOCCURRED;
                objResponseData.ResponseCode = CustomMessage.EXCEPTIONOCCURRED_RESPONSECODE.ToString();
                ExceptionLogDL.WriteExceptionDB(ex, "NA", "api", "TrusteeDL:DocumentDetail", "UNOCapi", "NA");
                return _result;
            }
        }
    }
}
