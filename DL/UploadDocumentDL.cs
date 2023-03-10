using BO.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata;
using System.Text;
using System.Xml.Linq;

namespace DL
{
    public class UploadDocumentDL
    {
        ResponseData objResponseData = new ResponseData();
        //ErrorBO objResponseData = new ErrorBO();
        ErrorBO _Access = new ErrorBO();
        public static IConfiguration _configuration;
        string connectionString = DBCS.GetConnectionString();
        #region UploadDoc
        public ResponseData UploadDocDetails(AmendmentBO obj)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] param = new SqlParameter[11];
                param[0] = new SqlParameter("@Type", "Insert");
                param[1] = new SqlParameter("@TypeId", 41);
                //param[2] = new SqlParameter("@NewSocityId",0);
                //param[3] = new SqlParameter("@SocityIdOld", 0);                
                param[2] = new SqlParameter("@ConsentofManagement", obj.ConsentofManagement);
                param[3] = new SqlParameter("@ConsentofManagementExtension", obj.ConsentofManagementExtension);
                param[4] = new SqlParameter("@ConsentofManagementContenttype", obj.ConsentofManagementContenttype);
                param[5] = new SqlParameter("@DocumentConsent", obj.DocumentConsent);
                param[6] = new SqlParameter("@DocumentConsentExtension", obj.DocumentConsentExtension);
                param[7] = new SqlParameter("@DocumentConsentContenttype", obj.DocumentConsentContenttype);
                param[8] = new SqlParameter("@UserBy", "");
                param[9] = new SqlParameter("@iCollegeId", obj.iCollegeId);
                param[10] = new SqlParameter("@trusID", obj.trusID);
                ds = BaseFunction.FillDataSet("[dbo].[USP_WomenCoEducation_Save]", param);
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        objResponseData.Message = ds.Tables[0].Rows[0]["Message"].NulllToString();
                        objResponseData.statusCode = ds.Tables[0].Rows[0]["statusCode"].NulllToInt();
                        return objResponseData;
                    }
                    else
                    {
                        objResponseData.Message = ds.Tables[0].Rows[0]["Message"].NulllToString();
                        objResponseData.statusCode = ds.Tables[0].Rows[0]["statusCode"].NulllToInt();
                        return objResponseData;
                    }
                }
                else
                {
                    objResponseData.Message = CustomMessage.NORECORDFOUND;
                    objResponseData.ResponseCode = CustomMessage.NORECORDFOUND_RESPONSECODE.ToString();
                    return objResponseData;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        #endregion
        #region CollegenameChangeAttachment
        public ResponseData UploadNameCollege(AmendmentBO obj)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] param = new SqlParameter[9];
                param[0] = new SqlParameter("@Type", "Insert");
                param[1] = new SqlParameter("@TypeId", 42);
                param[2] = new SqlParameter("@sNewNameEnglish", obj.Englishname);
                param[3] = new SqlParameter("@sNewNameHindi", obj.HindiName);
                param[4] = new SqlParameter("@CollegeAttch", obj.CollegeAttch);
                param[5] = new SqlParameter("@CollegeAttchExtension", obj.CollegeAttchExtensionExtension);
                param[6] = new SqlParameter("@CollegeAttchContenttype", obj.CollegeAttchContenttype);
                param[7] = new SqlParameter("@iCollegeId", obj.iCollegeId);
                param[8] = new SqlParameter("@trusID", obj.trusID);
                ds = BaseFunction.FillDataSet("[dbo].[USP_ChangeNameofCollege_Save]", param);
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        objResponseData.Message = ds.Tables[0].Rows[0]["Message"].NulllToString();
                        objResponseData.statusCode = ds.Tables[0].Rows[0]["statusCode"].NulllToInt();
                        return objResponseData;
                    }
                    else
                    {
                        objResponseData.Message = ds.Tables[0].Rows[0]["Message"].NulllToString();
                        objResponseData.statusCode = ds.Tables[0].Rows[0]["statusCode"].NulllToInt();
                        return objResponseData;
                    }
                }
                else
                {
                    objResponseData.Message = CustomMessage.NORECORDFOUND;
                    objResponseData.ResponseCode = CustomMessage.NORECORDFOUND_RESPONSECODE.ToString();
                    return objResponseData;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        #endregion

        #region UploadDoc
        public ResponseData ManagmentDocDetails(AmendmentBO obj)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] param = new SqlParameter[11];
                param[0] = new SqlParameter("@Type", "Insert");
                param[1] = new SqlParameter("@TypeId", 43);
                param[2] = new SqlParameter("@NewSocityID", obj.NewSosityName);
                param[3] = new SqlParameter("@ResolutionMagtCommitte", obj.ResolutionMagtCommitte);
                param[4] = new SqlParameter("@ResolutionMagtCommitteExtension", obj.ResolutionMagtCommitteExtension);
                param[5] = new SqlParameter("@ResolutionMagtCommittetype", obj.ResolutionMagtCommittetype);

                param[6] = new SqlParameter("@AnnexureManagementCommitte", obj.ChangeManagement);
                param[7] = new SqlParameter("@AnnexureManagementCommitteExtension", obj.ChangeManagementExtension);
                param[8] = new SqlParameter("@AnnexureManagementCommittetype", obj.ChangeManagementtetype);

                param[9] = new SqlParameter("@iCollegeId", obj.iCollegeId);
                param[10] = new SqlParameter("@trusID", obj.trusID);
                ds = BaseFunction.FillDataSet("[dbo].[USP_ChangeCollegeManagement_Save]", param);
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        objResponseData.Message = ds.Tables[0].Rows[0]["Message"].NulllToString();
                        objResponseData.statusCode = ds.Tables[0].Rows[0]["statusCode"].NulllToInt();
                        return objResponseData;
                    }
                    else
                    {
                        objResponseData.Message = ds.Tables[0].Rows[0]["Message"].NulllToString();
                        objResponseData.statusCode = ds.Tables[0].Rows[0]["statusCode"].NulllToInt();
                        return objResponseData;
                    }
                }
                else
                {
                    objResponseData.Message = CustomMessage.NORECORDFOUND;
                    objResponseData.ResponseCode = CustomMessage.NORECORDFOUND_RESPONSECODE.ToString();
                    return objResponseData;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        #endregion

        #region UploadDoc Merger
        public ResponseData MergerDocDetails(AmendmentBO obj)
        {
            DataSet ds = new DataSet();
            try
            {

                SqlParameter[] param = new SqlParameter[40];
                param[0] = new SqlParameter("@Type", "Insert");

                param[1] = new SqlParameter("@ProposalSocietyMerger", obj.ProposalSocietyMerger);
                param[2] = new SqlParameter("@ProposalSocietyMergerExtension", obj.ProposalSocietyMergerExtension);
                param[3] = new SqlParameter("@ProposalSocietyMergerTYPEtype", obj.ProposalSocietyMergertetype);

                param[4] = new SqlParameter("@NOCsissued", obj.NOCsissued);
                param[5] = new SqlParameter("@NOCsissuedExtension", obj.NOCsissuedExtension);
                param[6] = new SqlParameter("@NOCsissuedtetype", obj.NOCsissuedtetype);

                param[7] = new SqlParameter("@LstUnivsityAffiliationCollege", obj.LstUnivsityAffiliationCollege);
                param[8] = new SqlParameter("@LstUnivsityAffiliationCollegeExtension", obj.LstUnivsityAffiliationCollegeExtension);
                param[9] = new SqlParameter("@LstUnivsityAffiliationCollegetype", obj.LstUnivsityAffiliationCollegetype);

                param[10] = new SqlParameter("@Affidavitconsent", obj.Affidavitconsent);
                param[11] = new SqlParameter("@AffidavitconsentExtension", obj.AffidavitconsentExtension);
                param[12] = new SqlParameter("@Affidavitconsenttype", obj.Affidavitconsenttype);

                param[13] = new SqlParameter("@AffidavitParents", obj.AffidavitParents);
                param[14] = new SqlParameter("@AffidavitParentsExtension", obj.AffidavitParentsExtension);
                param[15] = new SqlParameter("@AffidavitParentstype", obj.AffidavitParentstype);

                //Other 
                param[16] = new SqlParameter("@AllNOCsIssue", obj.AllNOCsIssued);
                param[17] = new SqlParameter("@AllNOCsIssuedExtension", obj.AllNOCsIssuedExtension);
                param[18] = new SqlParameter("@AllNOCsIssuedstype ", obj.AllNOCsIssuedstype);
                //universityAffliation
                param[19] = new SqlParameter("@LatestUniversityAffilliation", obj.LatestUniversityAffilliation);
                param[20] = new SqlParameter("@LatestUniversityAffilliationExtension", obj.LatestUniversityAffilliationExtension);
                param[21] = new SqlParameter("@LatestUniversityAffilliationtype", obj.LatestUniversityAffilliationtype);
                //NOCAffiliatting
                param[22] = new SqlParameter("@NOCAffiliatting", obj.NOCAffiliatting);
                param[23] = new SqlParameter("@NOCAffiliattingExtension", obj.NOCAffiliattingExtension);
                param[24] = new SqlParameter("@NOCAffiliattingtype", obj.NOCAffiliattingtype);

                //AffidavitConsentParents
                param[25] = new SqlParameter("@AffidavitConsentParents", obj.AffidavitConsentParents);
                param[26] = new SqlParameter("@AffidavitConsentParentsExtension", obj.AffidavitConsentParentsExtension);
                param[27] = new SqlParameter("@AffidavitConsentParentstype", obj.AffidavitConsentParentstype);
                ////land details
                param[28] = new SqlParameter("@LandCertificate", obj.LandCertificate);
                param[29] = new SqlParameter("@LandCertificateExtension", obj.LandCertificateExtension);
                param[30] = new SqlParameter("@LandCertificatetype", obj.LandCertificatetype);
                //BluePrintBuilding
                param[31] = new SqlParameter("@BluePrintBuilding", obj.BluePrintBuilding);
                param[32] = new SqlParameter("@BluePrintBuildingExtension", obj.BluePrintBuildingExtension);
                param[33] = new SqlParameter("@BluePrintBuildingtype", obj.BluePrintBuildingtype);
                //Staff information
                param[34] = new SqlParameter("@StaffInformation", obj.StaffInformation);
                param[35] = new SqlParameter("@StaffInformationExten", obj.StaffInformationExten);
                param[36] = new SqlParameter("@StaffInformationContenttype", obj.StaffInformationContent);
                param[37] = new SqlParameter("@TypeId", 45);
                param[38] = new SqlParameter("@iCollegeId", obj.iCollegeId);
                param[39] = new SqlParameter("@trusID", obj.trusID);
                ds = BaseFunction.FillDataSet("[dbo].[USP_MergerApplicantInformatio_Save]", param);
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        objResponseData.Message = ds.Tables[0].Rows[0]["Message"].NulllToString();
                        objResponseData.statusCode = ds.Tables[0].Rows[0]["statusCode"].NulllToInt();
                        return objResponseData;
                    }
                    else
                    {
                        objResponseData.Message = ds.Tables[0].Rows[0]["Message"].NulllToString();
                        objResponseData.statusCode = ds.Tables[0].Rows[0]["statusCode"].NulllToInt();
                        return objResponseData;
                    }
                }
                else
                {
                    objResponseData.Message = CustomMessage.NORECORDFOUND;
                    objResponseData.ResponseCode = CustomMessage.NORECORDFOUND_RESPONSECODE.ToString();
                    return objResponseData;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        #endregion

        #region  UploadDoc Place
        public ResponseData PlaceDocDetails(AmendmentBO obj)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] param = new SqlParameter[16];
                param[0] = new SqlParameter("@Type", "Insert");
                param[1] = new SqlParameter("@TypeId", 44);
                param[2] = new SqlParameter("@District", obj.District);
                param[3] = new SqlParameter("@Tehsil", obj.Tehsil);
                param[4] = new SqlParameter("@oldPlaceAddressone", obj.oldPlaceAddressone);
                param[5] = new SqlParameter("@oldPlaceAddresstwo", obj.oldPlaceAddresstwo);
                param[6] = new SqlParameter("@NewPlaceAddressone", obj.NewPlaceAddressone);
                param[7] = new SqlParameter("@NewPlaceAddresstwo", obj.NewPlaceAddresstwo);
                param[8] = new SqlParameter("@PlaceAttch", obj.PlaceAttch);
                param[9] = new SqlParameter("@PlaceAttchExtension", obj.PlaceAttchExtension);
                param[10] = new SqlParameter("@PlaceAttchContenttype", obj.PlaceAttchContenttype);
                param[11] = new SqlParameter("@ChangePlace", obj.ChangePlace);
                param[12] = new SqlParameter("@ChangeManagementPlace", obj.ChangeManagementPlace);
                param[13] = new SqlParameter("@ChangeManagementtePlace", obj.ChangeManagementtePlace);
                param[14] = new SqlParameter("@iCollegeId", obj.iCollegeId);
                param[15] = new SqlParameter("@trusID", obj.trusID);
                ds = BaseFunction.FillDataSet("[dbo].[USP_ChangeCollegePlace_Save]", param);
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        objResponseData.Message = ds.Tables[0].Rows[0]["Message"].NulllToString();
                        objResponseData.statusCode = ds.Tables[0].Rows[0]["statusCode"].NulllToInt();
                        return objResponseData;
                    }
                    else
                    {
                        objResponseData.Message = ds.Tables[0].Rows[0]["Message"].NulllToString();
                        objResponseData.statusCode = ds.Tables[0].Rows[0]["statusCode"].NulllToInt();
                        return objResponseData;
                    }
                }
                else
                {
                    objResponseData.Message = CustomMessage.NORECORDFOUND;
                    objResponseData.ResponseCode = CustomMessage.NORECORDFOUND_RESPONSECODE.ToString();
                    return objResponseData;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        #endregion  UploadDoc Place


        #region document List
        public List<AmendmentBO> AmdList(int idclgID)
        {
            List<AmendmentBO> _result = new List<AmendmentBO>();
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@Type", "GetdetailsCoEducation");
                param[1] = new SqlParameter("@idclgID", idclgID);
                ds = BaseFunction.FillDataSet("[dbo].[USP_GetAmendmentDetails]", param);
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow DR in ds.Tables[0].Rows)
                        {
                            _result.Add(new AmendmentBO
                            {
                                iPk_AplcnAttch = DR["iPk_AplcnAttch"].NulllToString(),
                                iPk_ClgAmdId = DR["iPk_ClgAmdId"].NulllToString(),
                                stypeId = DR["stypeId"].NulllToString(),
                                sNameOfClg = DR["sNameOfClg"].NulllToString(),
                                iCollegeId = DR["iCollegeId"].NulllToString(),
                                docFile = DR["docFile"].NulllToString(),
                                DocumentContent = DR["DocumentContent"].NulllToString(),
                                DocumentExtension = DR["DocumentExtension"].NulllToString(),
                                ImageTypeName = DR["sName"].NulllToString(),
                            });
                        }
                        return _result;
                    }
                    else
                    {
                        objResponseData.Message = ds.Tables[0].Rows[0]["Message"].NulllToString();
                        objResponseData.ResponseCode = ds.Tables[0].Rows[0]["Flag"].NulllToString();
                        return _result;
                    }
                }
                else
                {
                    objResponseData.Message = CustomMessage.NORECORDFOUND;
                    objResponseData.ResponseCode = CustomMessage.NORECORDFOUND_RESPONSECODE.ToString();
                    return _result;
                }
            }
            catch (Exception ex)
            {
                objResponseData.Message = CustomMessage.EXCEPTIONOCCURRED;
                objResponseData.ResponseCode = CustomMessage.EXCEPTIONOCCURRED_RESPONSECODE.ToString();
                return _result;
            }
        }

        //Name of College
        public List<AmendmentBO> NameCollegeList(int idclgID)
        {
            List<AmendmentBO> _result = new List<AmendmentBO>();
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@Type", "GetdetailsNameOfCollege");
                param[1] = new SqlParameter("@idclgID", idclgID);
                ds = BaseFunction.FillDataSet("[dbo].[USP_GetAmendmentDetails]", param);
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow DR in ds.Tables[0].Rows)
                        {
                            _result.Add(new AmendmentBO
                            {
                                iPk_AplcnAttch = DR["iPk_AplcnAttch"].NulllToString(),
                                iPk_ClgAmdId = DR["iPk_ClgAmdId"].NulllToString(),
                                stypeId = DR["stypeId"].NulllToString(),
                                sNameOfClg = DR["sNameOfClg"].NulllToString(),
                                iCollegeId = DR["iCollegeId"].NulllToString(),
                                docFile = DR["docFile"].NulllToString(),
                                DocumentContent = DR["DocumentContent"].NulllToString(),
                                DocumentExtension = DR["DocumentExtension"].NulllToString(),
                                Englishname = DR["sNewNameEnglish"].NulllToString(),
                                HindiName = DR["sNewNameHindi"].NulllToString()
                            });
                        }
                        return _result;
                    }
                    else
                    {
                        objResponseData.Message = ds.Tables[0].Rows[0]["Message"].NulllToString();
                        objResponseData.ResponseCode = ds.Tables[0].Rows[0]["Flag"].NulllToString();
                        return _result;
                    }
                }
                else
                {
                    objResponseData.Message = CustomMessage.NORECORDFOUND;
                    objResponseData.ResponseCode = CustomMessage.NORECORDFOUND_RESPONSECODE.ToString();
                    return _result;
                }
            }
            catch (Exception ex)
            {
                objResponseData.Message = CustomMessage.EXCEPTIONOCCURRED;
                objResponseData.ResponseCode = CustomMessage.EXCEPTIONOCCURRED_RESPONSECODE.ToString();
                return _result;
            }
        }
        //College place Chnage
        public List<AmendmentBO> CollegePlaceList(int idclgID)
        {
            List<AmendmentBO> _result = new List<AmendmentBO>();
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@Type", "GetCollegePlaceList");
                param[1] = new SqlParameter("@idclgID", idclgID);
                ds = BaseFunction.FillDataSet("[dbo].[USP_GetAmendmentDetails]", param);
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow DR in ds.Tables[0].Rows)
                        {
                            _result.Add(new AmendmentBO
                            {

                                iPk_ClgAmdId = DR["iPk_ClgAmdId"].NulllToString(),
                                iPk_AplcnAttch = DR["iPk_AplcnAttch"].NulllToString(),
                                iDistrictNew = DR["iDistrictNew"].NulllToString(),
                                DistName = DR["DistName"].NulllToString(),
                                tehsilName = DR["tehsilName"].NulllToString(),
                                sAddreslineoneold = DR["sAddreslineoneold"].NulllToString(),
                                sAddreslineoneNew = DR["sAddreslineoneNew"].NulllToString(),
                                sAddresslinetwoold = DR["sAddresslinetwoold"].NulllToString(),
                                sAddresslinetwoNew = DR["sAddresslinetwoNew"].NulllToString(),
                                stypeId = DR["stypeId"].NulllToString(),
                                sNameOfClg = DR["sNameOfClg"].NulllToString(),
                                iCollegeId = DR["iCollegeId"].NulllToString(),
                                docFile = DR["docFile"].NulllToString(),
                                DocumentContent = DR["DocumentContent"].NulllToString(),
                                DocumentExtension = DR["DocumentExtension"].NulllToString()
                            });
                        }
                        return _result;
                    }
                    else
                    {
                        objResponseData.Message = ds.Tables[0].Rows[0]["Message"].NulllToString();
                        objResponseData.ResponseCode = ds.Tables[0].Rows[0]["Flag"].NulllToString();
                        return _result;
                    }
                }
                else
                {
                    objResponseData.Message = CustomMessage.NORECORDFOUND;
                    objResponseData.ResponseCode = CustomMessage.NORECORDFOUND_RESPONSECODE.ToString();
                    return _result;
                }
            }
            catch (Exception ex)
            {
                objResponseData.Message = CustomMessage.EXCEPTIONOCCURRED;
                objResponseData.ResponseCode = CustomMessage.EXCEPTIONOCCURRED_RESPONSECODE.ToString();
                return _result;
            }
        }
        //ManagementCollegeList
        public List<AmendmentBO> ManagementCollegeList(int idclgID)
       {
            List<AmendmentBO> _result = new List<AmendmentBO>();
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@Type", "GetdetailsCollegeManagement");
                param[1] = new SqlParameter("@idclgID", idclgID);
                ds = BaseFunction.FillDataSet("[dbo].[USP_GetAmendmentDetails]", param);
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow DR in ds.Tables[0].Rows)
                        {
                            _result.Add(new AmendmentBO
                            {
                                iPk_AplcnAttch = DR["iPk_AplcnAttch"].NulllToString(),
                                iPk_ClgAmdId = DR["iPk_ClgAmdId"].NulllToString(),
                                stypeId = DR["stypeId"].NulllToString(),
                                sNameOfClg = DR["sNameOfClg"].NulllToString(),
                                iCollegeId = DR["iCollegeId"].NulllToString(),
                                docFile = DR["docFile"].NulllToString(),
                                DocumentContent = DR["DocumentContent"].NulllToString(),
                                DocumentExtension = DR["DocumentExtension"].NulllToString(),
                                //ImageTypeName = DR["sName"].NulllToString(),
                            });
                        }
                        return _result;
                    }
                    else
                    {
                        objResponseData.Message = ds.Tables[0].Rows[0]["Message"].NulllToString();
                        objResponseData.ResponseCode = ds.Tables[0].Rows[0]["Flag"].NulllToString();
                        return _result;
                    }
                }
                else
                {
                    objResponseData.Message = CustomMessage.NORECORDFOUND;
                    objResponseData.ResponseCode = CustomMessage.NORECORDFOUND_RESPONSECODE.ToString();
                    return _result;
                }
            }
            catch (Exception ex)
            {
                objResponseData.Message = CustomMessage.EXCEPTIONOCCURRED;
                objResponseData.ResponseCode = CustomMessage.EXCEPTIONOCCURRED_RESPONSECODE.ToString();
                return _result;
            }
        }
        //merger Details
        public List<AmendmentBO> MergerDetailsList(int idclgID)
        {
            List<AmendmentBO> _result = new List<AmendmentBO>();
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@Type", "GetdetailsMergerDetails");
                param[1] = new SqlParameter("@idclgID", idclgID);
                ds = BaseFunction.FillDataSet("[dbo].[USP_GetAmendmentDetails]", param);
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow DR in ds.Tables[0].Rows)
                        {
                            _result.Add(new AmendmentBO
                            {
                                iPk_AplcnAttch = DR["iPk_AplcnAttch"].NulllToString(),
                                iPk_ClgAmdId = DR["iPk_ClgAmdId"].NulllToString(),
                                stypeId = DR["stypeId"].NulllToString(),
                                sNameOfClg = DR["sNameOfClg"].NulllToString(),
                                iCollegeId = DR["iCollegeId"].NulllToString(),
                                docFile = DR["docFile"].NulllToString(),
                                DocumentContent = DR["DocumentContent"].NulllToString(),
                                DocumentExtension = DR["DocumentExtension"].NulllToString()
                            });
                        }
                        return _result;
                    }
                    else
                    {
                        objResponseData.Message = ds.Tables[0].Rows[0]["Message"].NulllToString();
                        objResponseData.ResponseCode = ds.Tables[0].Rows[0]["Flag"].NulllToString();
                        return _result;
                    }
                }
                else
                {
                    objResponseData.Message = CustomMessage.NORECORDFOUND;
                    objResponseData.ResponseCode = CustomMessage.NORECORDFOUND_RESPONSECODE.ToString();
                    return _result;
                }
            }
            catch (Exception ex)
            {
                objResponseData.Message = CustomMessage.EXCEPTIONOCCURRED;
                objResponseData.ResponseCode = CustomMessage.EXCEPTIONOCCURRED_RESPONSECODE.ToString();
                return _result;
            }
        }

        #endregion
        #region woman Doc
        public AmendmentBO DocumentDetail(int id)
        {
            AmendmentBO _result = new AmendmentBO();
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@Type", "DownloaddetailsCoEducation");
                param[1] = new SqlParameter("@Id", id);
                ds = BaseFunction.FillDataSet("[dbo].[USP_GetAmendmentDetails]", param);
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        objResponseData.Message = ds.Tables[1].Rows[0]["Message"].NulllToString();
                        objResponseData.ResponseCode = ds.Tables[1].Rows[0]["StatusCode"].NulllToString();

                        if (ds.Tables[0].Rows.Count > 0)
                        {

                            _result.docFile = ds.Tables[0].Rows[0]["docFile"].ToString();
                            _result.DocumentExtension = ds.Tables[0].Rows[0]["DocumentExtension"].NulllToString();
                            _result.DocumentContent = ds.Tables[0].Rows[0]["DocumentContent"].NulllToString();

                        }

                        return _result;
                    }
                    else
                    {
                        objResponseData.Message = ds.Tables[0].Rows[0]["Message"].NulllToString();
                        objResponseData.ResponseCode = ds.Tables[0].Rows[0]["StatusCode"].NulllToString();
                        return _result;
                    }
                }
                else
                {
                    objResponseData.Message = CustomMessage.NORECORDFOUND;
                    objResponseData.ResponseCode = CustomMessage.NORECORDFOUND_RESPONSECODE.ToString();
                    return _result;
                }
            }
            catch (Exception ex)
            {
                objResponseData.Message = CustomMessage.EXCEPTIONOCCURRED;
                objResponseData.ResponseCode = CustomMessage.EXCEPTIONOCCURRED_RESPONSECODE.ToString();
                ExceptionLogDL.WriteExceptionDB(ex, "NA", "api", "UploadDocumentDL:DocumentDetail", "UNOCapi", "NA");
                return _result;
            }
        }

        //NameOfCollege
        public AmendmentBO NameCollegeDetail(int id)
        {
            AmendmentBO _result = new AmendmentBO();
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@Type", "DownloaddetailsNameOfCollege");
                param[1] = new SqlParameter("@Id", id);
                ds = BaseFunction.FillDataSet("[dbo].[USP_GetAmendmentDetails]", param);
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        objResponseData.Message = ds.Tables[1].Rows[0]["Message"].NulllToString();
                        objResponseData.ResponseCode = ds.Tables[1].Rows[0]["StatusCode"].NulllToString();
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            _result.docFile = ds.Tables[0].Rows[0]["docFile"].ToString();
                            _result.DocumentExtension = ds.Tables[0].Rows[0]["DocumentExtension"].NulllToString();
                            _result.DocumentContent = ds.Tables[0].Rows[0]["DocumentContent"].NulllToString();
                        }

                        return _result;
                    }
                    else
                    {
                        objResponseData.Message = ds.Tables[0].Rows[0]["Message"].NulllToString();
                        objResponseData.ResponseCode = ds.Tables[0].Rows[0]["StatusCode"].NulllToString();
                        return _result;
                    }
                }
                else
                {
                    objResponseData.Message = CustomMessage.NORECORDFOUND;
                    objResponseData.ResponseCode = CustomMessage.NORECORDFOUND_RESPONSECODE.ToString();
                    return _result;
                }
            }
            catch (Exception ex)
            {
                objResponseData.Message = CustomMessage.EXCEPTIONOCCURRED;
                objResponseData.ResponseCode = CustomMessage.EXCEPTIONOCCURRED_RESPONSECODE.ToString();
                ExceptionLogDL.WriteExceptionDB(ex, "NA", "api", "UploadDocumentDL:DocumentDetail", "UNOCapi", "NA");
                return _result;
            }
        }
        //College Place Chnage Detail
        public AmendmentBO CollegePlaceChnageDetail(int id)
        {
            AmendmentBO _result = new AmendmentBO();
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@Type", "DownloadCollegePlaceList");
                param[1] = new SqlParameter("@Id", id);
                ds = BaseFunction.FillDataSet("[dbo].[USP_GetAmendmentDetails]", param);
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        objResponseData.Message = ds.Tables[1].Rows[0]["Message"].NulllToString();
                        objResponseData.ResponseCode = ds.Tables[1].Rows[0]["StatusCode"].NulllToString();
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            _result.docFile = ds.Tables[0].Rows[0]["docFile"].ToString();
                            _result.DocumentExtension = ds.Tables[0].Rows[0]["DocumentExtension"].NulllToString();
                            _result.DocumentContent = ds.Tables[0].Rows[0]["DocumentContent"].NulllToString();
                        }

                        return _result;
                    }
                    else
                    {
                        objResponseData.Message = ds.Tables[0].Rows[0]["Message"].NulllToString();
                        objResponseData.ResponseCode = ds.Tables[0].Rows[0]["StatusCode"].NulllToString();
                        return _result;
                    }
                }
                else
                {
                    objResponseData.Message = CustomMessage.NORECORDFOUND;
                    objResponseData.ResponseCode = CustomMessage.NORECORDFOUND_RESPONSECODE.ToString();
                    return _result;
                }
            }
            catch (Exception ex)
            {
                objResponseData.Message = CustomMessage.EXCEPTIONOCCURRED;
                objResponseData.ResponseCode = CustomMessage.EXCEPTIONOCCURRED_RESPONSECODE.ToString();
                ExceptionLogDL.WriteExceptionDB(ex, "NA", "api", "UploadDocumentDL:DocumentDetail", "UNOCapi", "NA");
                return _result;
            }
        }
        //Managment College Chnage
        public AmendmentBO ManagementCollegeDetail(int id)
        {
            AmendmentBO _result = new AmendmentBO();
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@Type", "DownloaddetailsCollegeManagement");
                param[1] = new SqlParameter("@Id", id);
                ds = BaseFunction.FillDataSet("[dbo].[USP_GetAmendmentDetails]", param);
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        objResponseData.Message = ds.Tables[1].Rows[0]["Message"].NulllToString();
                        objResponseData.ResponseCode = ds.Tables[1].Rows[0]["StatusCode"].NulllToString();
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            _result.docFile = ds.Tables[0].Rows[0]["docFile"].ToString();
                            _result.DocumentExtension = ds.Tables[0].Rows[0]["DocumentExtension"].NulllToString();
                            _result.DocumentContent = ds.Tables[0].Rows[0]["DocumentContent"].NulllToString();
                        }

                        return _result;
                    }
                    else
                    {
                        objResponseData.Message = ds.Tables[0].Rows[0]["Message"].NulllToString();
                        objResponseData.ResponseCode = ds.Tables[0].Rows[0]["StatusCode"].NulllToString();
                        return _result;
                    }
                }
                else
                {
                    objResponseData.Message = CustomMessage.NORECORDFOUND;
                    objResponseData.ResponseCode = CustomMessage.NORECORDFOUND_RESPONSECODE.ToString();
                    return _result;
                }
            }
            catch (Exception ex)
            {
                objResponseData.Message = CustomMessage.EXCEPTIONOCCURRED;
                objResponseData.ResponseCode = CustomMessage.EXCEPTIONOCCURRED_RESPONSECODE.ToString();
                ExceptionLogDL.WriteExceptionDB(ex, "NA", "api", "UploadDocumentDL:DocumentDetail", "UNOCapi", "NA");
                return _result;
            }
        }
        //Merger College Details
        public AmendmentBO MergerApplicantDetail(int id)
        {
            AmendmentBO _result = new AmendmentBO();
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@Type", "DownloadMergerDetails");
                param[1] = new SqlParameter("@Id", id);
                ds = BaseFunction.FillDataSet("[dbo].[USP_GetAmendmentDetails]", param);
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        objResponseData.Message = ds.Tables[1].Rows[0]["Message"].NulllToString();
                        objResponseData.ResponseCode = ds.Tables[1].Rows[0]["StatusCode"].NulllToString();
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            _result.docFile = ds.Tables[0].Rows[0]["docFile"].ToString();
                            _result.DocumentExtension = ds.Tables[0].Rows[0]["DocumentExtension"].NulllToString();
                            _result.DocumentContent = ds.Tables[0].Rows[0]["DocumentContent"].NulllToString();
                        }

                        return _result;
                    }
                    else
                    {
                        objResponseData.Message = ds.Tables[0].Rows[0]["Message"].NulllToString();
                        objResponseData.ResponseCode = ds.Tables[0].Rows[0]["StatusCode"].NulllToString();
                        return _result;
                    }
                }
                else
                {
                    objResponseData.Message = CustomMessage.NORECORDFOUND;
                    objResponseData.ResponseCode = CustomMessage.NORECORDFOUND_RESPONSECODE.ToString();
                    return _result;
                }
            }
            catch (Exception ex)
            {
                objResponseData.Message = CustomMessage.EXCEPTIONOCCURRED;
                objResponseData.ResponseCode = CustomMessage.EXCEPTIONOCCURRED_RESPONSECODE.ToString();
                ExceptionLogDL.WriteExceptionDB(ex, "NA", "api", "UploadDocumentDL:DocumentDetail", "UNOCapi", "NA");
                return _result;
            }
        }
        #endregion

        #region Document details
        public ResponseData DeleteApplicantDetail(AmendmentBO obj)
        {
            try
            {
                List<AmendmentBO> DocumentDetailsList = new List<AmendmentBO>();
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@Type", "UpdateDownloadDetails");
                param[1] = new SqlParameter("@Id", obj.CollegeId);
                param[2] = new SqlParameter("@idclgID", obj.iCollegeId);
                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_GetAmendmentDetails]", param);
               
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        objResponseData.Message = ds.Tables[0].Rows[0]["Message"].NulllToString();
                        objResponseData.statusCode = ds.Tables[0].Rows[0]["StatusCode"].NulllToInt();
                        return objResponseData;
                    }
                    else
                    {
                        objResponseData.Message = ds.Tables[0].Rows[0]["Message"].NulllToString();
                        objResponseData.statusCode = ds.Tables[0].Rows[0]["statusCode"].NulllToInt();
                        return objResponseData;
                    }
                }
                else
                {
                    objResponseData.Message = CustomMessage.NORECORDFOUND;
                    objResponseData.ResponseCode = CustomMessage.NORECORDFOUND_RESPONSECODE.ToString();
                    return objResponseData;
                }
            }
            catch (Exception e)
            {
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : UploadDocumentDL / Function : GetCategoryAllInformation", connectionString);
            }
            return objResponseData;
        }
        #endregion
    }
}
