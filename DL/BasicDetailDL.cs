using BO;
using BO.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using static BO.Models.TrusteeBO;

namespace DL
{
    public class BasicDetailDL
    {
        ResponseData objResponseData = new ResponseData();
        ErrorBO _Access = new ErrorBO();
        public static IConfiguration _configuration;
        string connectionString = DBCS.GetConnectionString();

        //public ResponseData BasicDetailConfigure(BasicDetails obj)
        //{
        //    string AplcnNo = "TMP" + DateTime.Now.ToString("ddMMyyyyhhmmsssss");

        //    using (DataTable DT = new DataTable())
        //    {
        //        using (SqlConnection connect = new SqlConnection())
        //        {
        //            using (SqlCommand cmd = new SqlCommand())
        //            {
        //                cmd.CommandText = "[dbo].[USP_MASTER_BasicInfoDetails_Save]";
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                cmd.Parameters.AddWithValue("@Type", "Insert");
        //                cmd.Parameters.AddWithValue("@TrustInfoId", obj.TrustInfoId);
        //                cmd.Parameters.AddWithValue("@sNameOfClg", obj.CollegeName);
        //                cmd.Parameters.AddWithValue("@iFk_Unvrsty", obj.UniverSity);
        //                cmd.Parameters.AddWithValue("@sAplcnNo", AplcnNo);
        //                cmd.Parameters.AddWithValue("@sMobileNo", obj.MobileNumber);
        //                cmd.Parameters.AddWithValue("@sEmailId", obj.Email);
        //                cmd.Parameters.AddWithValue("@sWebsite", obj.Websiteurl);
        //                cmd.Parameters.AddWithValue("@sAddressLine1", obj.AddressLine1);
        //                cmd.Parameters.AddWithValue("@sAddressLine2", obj.AddressLine2);
        //                cmd.Parameters.AddWithValue("@sLatitude", obj.Latitudedd);
        //                cmd.Parameters.AddWithValue("@sLongutitude", obj.Longitudedd);
        //                cmd.Parameters.AddWithValue("@sAdMobileNo", obj.AddiMobileNumber);
        //                cmd.Parameters.AddWithValue("@sAdPhNo", obj.LandlineNumber);
        //                cmd.Parameters.AddWithValue("@CollageLogo", obj.CollageLogo);
        //                cmd.Parameters.AddWithValue("@CollageLogoExtension", obj.CollageLogoExtension);
        //                cmd.Parameters.AddWithValue("@CollageLogoDocumentContent", obj.CollageLogoContenttype);
        //                cmd.Parameters.AddWithValue("@collegeType", obj.CollegeType);
        //                cmd.Parameters.AddWithValue("@sCntcNo1", obj.ContactNo1);
        //                cmd.Parameters.AddWithValue("@sCntcNo2", obj.ContactNo2);
        //                cmd.Parameters.AddWithValue("@sEmailAddr1", obj.EmailAddress1);
        //                cmd.Parameters.AddWithValue("@sEmailAddr2", obj.EmailAddress2);
        //                cmd.Parameters.AddWithValue("@collegeLevel", obj.collegeLevel);
        //                cmd.Parameters.AddWithValue("@collegeMedium", obj.collegeMedium);

        //                object id = BaseFunction.ExecuteScalarFunction("[dbo].[USP_UniversityMaster_save]", Parameters);

        //                for (int i = 0; i <= uniContactsTable.Rows.Count - 1; i++)
        //                {
        //                    SqlParameter[] param1 = new SqlParameter[5];
        //                    param1[0] = new SqlParameter("@Type", "InsertContacts");
        //                    param1[1] = new SqlParameter("@Name", uniContactsTable.Rows[i]["Name"].ToString());
        //                    param1[2] = new SqlParameter("@Fk_UniId", id);
        //                    param1[3] = new SqlParameter("@Number", uniContactsTable.Rows[i]["Number"].ToString());
        //                    param1[4] = new SqlParameter("@Email", uniContactsTable.Rows[i]["Email"].ToString());
        //                    ds = BaseFunction.FillDataSet("[dbo].[USP_UniversityMaster_save]", param1);
        //                    // result.Rows[i]["Fk_UniId"].ToString()
        //                }
        //                try
        //                {
        //                    connect.ConnectionString = connectionString;
        //                    cmd.Connection = connect;
        //                    if (cmd.Connection.State != ConnectionState.Open)
        //                    {
        //                        cmd.Connection.Open();
        //                    }
        //                    SqlDataReader dr = cmd.ExecuteReader();
        //                    DT.Load(dr);
        //                    cmd.Connection.Close();
        //                    if (DT != null)
        //                    {
        //                        if (DT.Rows.Count > 0)
        //                        {
        //                            objResponseData.statusCode = Convert.ToInt32(DT.Rows[0]["StatusCode"]);
        //                            objResponseData.Message = DT.Rows[0]["Message"].ToString();

        //                        }
        //                    }
        //                    else
        //                    {
        //                        objResponseData.statusCode = 0;
        //                        objResponseData.Message = "Failed";
        //                    }
        //                }
        //                catch (Exception e)
        //                {
        //                    objResponseData.statusCode = 0;
        //                    objResponseData.Message = "Failed";
        //                    ExceptionLogDL.SendExcepToDB(e, 0, "Class : BasicDetailsDL / Function : InsertUpdateBasickDetails");
        //                }
        //            }
        //        }
        //        return objResponseData;
        //    }
        //}

        public ResponseData BasicDetailConfigure(BasicDetails obj)
        {
            DataSet ds = new DataSet();
            string AplcnNo = "TMP" + DateTime.Now.ToString("ddMMyyyyhhmmsssss");
            try
            {
                SqlParameter[] param = new SqlParameter[36];
                param[0] = new SqlParameter("@Type", "Insert");
                param[1] = new SqlParameter("@TrustInfoId", obj.TrustInfoId);
                param[2] = new SqlParameter("@CollageName", obj.CollegeName);
                param[3] = new SqlParameter("@UniverCityType", obj.UniverSity);
                param[4] = new SqlParameter("@sAplcnNo", AplcnNo);
                param[5] = new SqlParameter("@MobileNo", obj.MobileNumber);
                param[6] = new SqlParameter("@Email", obj.Email);
                param[7] = new SqlParameter("@sWebsite", obj.Websiteurl);
                param[8] = new SqlParameter("@AddressLine1", obj.AddressLine1);
                param[9] = new SqlParameter("@AddressLine2", obj.AddressLine2);
                param[10] = new SqlParameter("@sLatitude", obj.Latitudedd);
                param[11] = new SqlParameter("@sLongutitude", obj.Longitudedd);
                param[12] = new SqlParameter("@sAdMobileNo", obj.AddiMobileNumber);
                param[13] = new SqlParameter("@LandLineNo", obj.LandlineNumber);
                param[14] = new SqlParameter("@CollageLogo", obj.CollageLogo);
                param[15] = new SqlParameter("@CollageLogoExtension", obj.CollageLogoExtension);
                param[16] = new SqlParameter("@CollageLogoDocumentContent", obj.CollageLogoContenttype);
                param[17] = new SqlParameter("@CollageType", obj.CollageType);
                param[18] = new SqlParameter("@LoactionType", obj.LocationType);
                param[19] = new SqlParameter("@District", obj.DistrictId);
                param[20] = new SqlParameter("@Tehsil", obj.TehsilId);
                param[21] = new SqlParameter("@Block", obj.BlockId);
                param[22] = new SqlParameter("@City", obj.CityId);
                param[23] = new SqlParameter("@WardNo", obj.WardNo);

                param[24] = new SqlParameter("@CollageLevel", obj.collegeLevel);
                param[25] = new SqlParameter("@CollageMedium", obj.collegeMedium);

                param[26] = new SqlParameter("@CollageCategory", obj.CollageCategory);
                param[27] = new SqlParameter("@AIESHCodeStats", obj.AISHECodeStatus);
                param[28] = new SqlParameter("@AIESHCode", obj.AIESHCode);
                param[29] = new SqlParameter("@iFk_ParlmntId", obj.PaliamentAreaName);
                param[30] = new SqlParameter("@iFk_AsmblId", obj.LegislativeAreaName);
                param[31] = new SqlParameter("@CollageNamehindi", obj.CollageNamehindi);
                param[32] = new SqlParameter("@CollegeTypeId", obj.CollegeTypeId);
                param[33] = new SqlParameter("@TagDegrees", obj.TagDegrees);
                param[34] = new SqlParameter("@iFk_DivId", obj.DivisionId);
                param[35] = new SqlParameter("@iFK_SubDivId", obj.SubDivisionId);
                DataTable dt = BaseFunction.FillDataTable("[dbo].[USP_MASTER_BasicInfoDetails_Save]", param);

                for (int i = 0; i <= obj.ContactDetails.Count - 1; i++) //Rows.Count - 1; i++
                {
                    SqlParameter[] param1 = new SqlParameter[5];
                    param1[0] = new SqlParameter("@Type", "InsertContacts");
                    param1[1] = new SqlParameter("@ConactName", obj.ContactDetails[i].Name);
                    param1[2] = new SqlParameter("@IdentityId", dt.Rows[0]["Id"].ToString());
                    param1[3] = new SqlParameter("@ConactNummber", obj.ContactDetails[i].Number);  //uniContactsTable.Rows[i]["Number"].ToString());
                    param1[4] = new SqlParameter("@ContactEmail", obj.ContactDetails[i].Email); //uniContactsTable.Rows[i]["Email"].ToString());
                    ds = BaseFunction.FillDataSet("[dbo].[USP_MASTER_BasicInfoDetails_Save]", param1);

                }

                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        objResponseData.statusCode = ds.Tables[0].Rows[0]["StatusCode"].NulllToInt();
                        objResponseData.Message = ds.Tables[0].Rows[0]["Message"].NulllToString();
                        return objResponseData;
                    }
                    else
                    {
                        objResponseData.statusCode = ds.Tables[0].Rows[0]["StatusCode"].NulllToInt();
                        objResponseData.Message = ds.Tables[0].Rows[0]["Message"].NulllToString();
                        return objResponseData;
                    }
                }
                else
                {
                    objResponseData.Message = BO.Models.CustomMessage.NORECORDFOUND;
                    objResponseData.ResponseCode = BO.Models.CustomMessage.NORECORDFOUND_RESPONSECODE.ToString();
                    return objResponseData;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ResponseData GetCollageDropDownList(int TrustInfoId)
        {
            ResponseData responseData = new ResponseData();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@Type", "GetCollageDropDown");
                param[1] = new SqlParameter("@TrustInfoId", TrustInfoId.NulllToInt());
                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_MASTER_BasicInfoDetails_Save]", param);
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    responseData.Message = "Data Fetched...";
                    responseData.statusCode = 1;
                    responseData.ResponseCode = "001";
                    responseData.Data = ds.Tables[0];
                    //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    //{
                    //    objdoc.Id = ds.Tables[0].Rows[i]["Id"].NulllToInt();
                    //    objdoc.text = ds.Tables[0].Rows[i]["CustomName"].NulllToString();
                    //    objListdoc.Add(objdoc);
                    //}
                }

            }
            catch (Exception e)
            {
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : TrusteeDL / Function : GetTrustDropDownList");
            }
            return responseData;
        }
        public ResponseData GetAdminApplication(string applGUID)
        {
            ResponseData responseData = new ResponseData();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@applGUID", applGUID);
                param[1] = new SqlParameter("@type", "AdminView");
                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_MASTER_DraftApplication_List]", param);
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    responseData.Message = "Data Fetched...";
                    responseData.statusCode = 1;
                    responseData.ResponseCode = "001";
                    responseData.Data = ds.Tables[0];
                    //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    //{
                    //    objdoc.Id = ds.Tables[0].Rows[i]["Id"].NulllToInt();
                    //    objdoc.text = ds.Tables[0].Rows[i]["CustomName"].NulllToString();
                    //    objListdoc.Add(objdoc);
                    //}
                }

            }
            catch (Exception e)
            {
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : TrusteeDL / Function : GetAdminApplication");
            }
            return responseData;
        }
        //Updated For Saving the Darft application by Vivek 10.02.2023
        public ResponseData GetDarftApplications(string applGUID,string trustID)
        {
            ResponseData responseData = new ResponseData();
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@applGUID", applGUID);
                param[1] = new SqlParameter("@type", "Draft");
                param[2] = new SqlParameter("@trustID", trustID);
                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_MASTER_DraftApplication_ListNew]", param);
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    responseData.Message = "Data Fetched...";
                    responseData.statusCode = 1;
                    responseData.ResponseCode = "001";
                    responseData.Data = ds.Tables[0];
                    //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    //{
                    //    objdoc.Id = ds.Tables[0].Rows[i]["Id"].NulllToInt();
                    //    objdoc.text = ds.Tables[0].Rows[i]["CustomName"].NulllToString();
                    //    objListdoc.Add(objdoc);
                    //}
                }

            }
            catch (Exception e)
            {
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : TrusteeDL / Function : GetDarftApplications");
            }
            return responseData;
        }
        public ResponseData GetApplicationsToUploadReceipt(string applGUID)
        {
            ResponseData responseData = new ResponseData();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@applGUID", applGUID);
                param[1] = new SqlParameter("@type", "UploadReceipt");
                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_MASTER_DraftApplication_List]", param);
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    responseData.Message = "Data Fetched...";
                    responseData.statusCode = 1;
                    responseData.ResponseCode = "001";
                    responseData.Data = ds.Tables[0];
                    //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    //{
                    //    objdoc.Id = ds.Tables[0].Rows[i]["Id"].NulllToInt();
                    //    objdoc.text = ds.Tables[0].Rows[i]["CustomName"].NulllToString();
                    //    objListdoc.Add(objdoc);
                    //}
                }

            }
            catch (Exception e)
            {
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : TrusteeDL / Function : GetDarftApplications");
            }
            return responseData;
        }
        public ResponseData CancleDarftApplications(string applGUID, string Creason)
        {
            ResponseData responseData = new ResponseData();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@applGUID", applGUID);
                param[1] = new SqlParameter("@reason", Creason);
                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_OPERATION_CancleDraftApplication_Update]", param);
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    responseData.Message = ds.Tables[0].Rows[0]["Message"].ToString();
                    responseData.statusCode = 1;
                    responseData.ResponseCode = "001";
                    responseData.Data = ds.Tables[0];
                }
            }
            catch (Exception e)
            {
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : TrusteeDL / Function : CancleDarftApplications");
            }
            return responseData;
        }
        public ResponseData UpdateCollageDetails(BasicDetails obj)
        {
            DataSet ds = new DataSet();
            string AplcnNo = "TMP" + DateTime.Now.ToString("ddMMyyyyhhmmsssss");
            try
            {
                SqlParameter[] param = new SqlParameter[37];
                param[0] = new SqlParameter("@Type", "Update");
                param[1] = new SqlParameter("@TrustInfoId", obj.TrustInfoId);
                param[2] = new SqlParameter("@CollageName", obj.CollegeName);
                param[3] = new SqlParameter("@UniverCityType", obj.UniverSity);
                param[4] = new SqlParameter("@sAplcnNo", AplcnNo);
                param[5] = new SqlParameter("@MobileNo", obj.MobileNumber);
                param[6] = new SqlParameter("@Email", obj.Email);
                param[7] = new SqlParameter("@sWebsite", obj.Websiteurl);
                param[8] = new SqlParameter("@AddressLine1", obj.AddressLine1);
                param[9] = new SqlParameter("@AddressLine2", obj.AddressLine2);
                param[10] = new SqlParameter("@sLatitude", obj.Latitudedd);
                param[11] = new SqlParameter("@sLongutitude", obj.Longitudedd);
                param[12] = new SqlParameter("@sAdMobileNo", obj.AddiMobileNumber);
                param[13] = new SqlParameter("@LandLineNo", obj.LandlineNumber);
                param[14] = new SqlParameter("@CollageLogo", obj.CollageLogo);
                param[15] = new SqlParameter("@CollageLogoExtension", obj.CollageLogoExtension);
                param[16] = new SqlParameter("@CollageLogoDocumentContent", obj.CollageLogoContenttype);
                param[17] = new SqlParameter("@CollageType", obj.CollageType);
                param[18] = new SqlParameter("@LoactionType", obj.LocationType);
                param[19] = new SqlParameter("@District", obj.DistrictId);
                param[20] = new SqlParameter("@Tehsil", obj.TehsilId);
                param[21] = new SqlParameter("@Block", obj.BlockId);
                param[22] = new SqlParameter("@City", obj.CityId);
                param[23] = new SqlParameter("@WardNo", obj.WardNo);

                param[24] = new SqlParameter("@CollageLevel", obj.collegeLevel);
                param[25] = new SqlParameter("@CollageMedium", obj.collegeMedium);
                param[26] = new SqlParameter("@IdentityId", obj.Id);

                param[27] = new SqlParameter("@CollageCategory", obj.CollageCategory);
                param[28] = new SqlParameter("@AIESHCodeStats", obj.AISHECodeStatus);
                param[29] = new SqlParameter("@AIESHCode", obj.AIESHCode);
                param[30] = new SqlParameter("@iFk_ParlmntId", obj.PaliamentAreaName);
                param[31] = new SqlParameter("@iFk_AsmblId", obj.LegislativeAreaName);
                param[32] = new SqlParameter("@CollageNamehindi", obj.CollageNamehindi);
                param[33] = new SqlParameter("@CollegeTypeId", obj.CollegeTypeId);
                param[34] = new SqlParameter("@TagDegrees", obj.TagDegrees);
                param[35] = new SqlParameter("@iFk_DivId", obj.DivisionId);
                param[36] = new SqlParameter("@iFK_SubDivId", obj.SubDivisionId);

                DataTable dt = BaseFunction.FillDataTable("[dbo].[USP_MASTER_BasicInfoDetails_Save]", param);

                for (int i = 0; i <= obj.ContactDetails.Count - 1; i++) //Rows.Count - 1; i++
                {
                    SqlParameter[] param1 = new SqlParameter[5];
                    param1[0] = new SqlParameter("@Type", "InsertContacts");
                    param1[1] = new SqlParameter("@ConactName", obj.ContactDetails[i].Name);
                    param1[2] = new SqlParameter("@IdentityId", dt.Rows[0]["Id"].ToString());
                    param1[3] = new SqlParameter("@ConactNummber", obj.ContactDetails[i].Number);  //uniContactsTable.Rows[i]["Number"].ToString());
                    param1[4] = new SqlParameter("@ContactEmail", obj.ContactDetails[i].Email); //uniContactsTable.Rows[i]["Email"].ToString());
                    ds = BaseFunction.FillDataSet("[dbo].[USP_MASTER_BasicInfoDetails_Save]", param1);

                }

                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        objResponseData.statusCode = ds.Tables[0].Rows[0]["StatusCode"].NulllToInt();
                        objResponseData.Message = ds.Tables[0].Rows[0]["Message"].NulllToString();
                        return objResponseData;
                    }
                    else
                    {
                        objResponseData.statusCode = ds.Tables[0].Rows[0]["StatusCode"].NulllToInt();
                        objResponseData.Message = ds.Tables[0].Rows[0]["Message"].NulllToString();
                        return objResponseData;
                    }
                }
                else
                {
                    objResponseData.Message = BO.Models.CustomMessage.NORECORDFOUND;
                    objResponseData.ResponseCode = BO.Models.CustomMessage.NORECORDFOUND_RESPONSECODE.ToString();
                    return objResponseData;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BasicDetails GetCollageDetails(int Id)
        {
            BasicDetails _Details = new BasicDetails();
            List<ContactDetails> _contactDet = new List<ContactDetails>();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@Type", "GetDetailsForUpdate");
                param[1] = new SqlParameter("@IdentityId", Id);
                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_MASTER_BasicInfoDetails_Save]", param);
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        _Details.Id = ds.Tables[0].Rows[0]["iPk_ClgID"].NulllToInt();
                        _Details.CollegeName = ds.Tables[0].Rows[0]["CollageName"].ToString();
                        _Details.UniverSity = ds.Tables[0].Rows[0]["UnivercityType"].NulllToInt();
                        _Details.MobileNumber = ds.Tables[0].Rows[0]["MobileNo"].ToString();
                        _Details.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                        _Details.DistrictId = ds.Tables[0].Rows[0]["DistrictId"].NulllToInt();
                        _Details.TehsilId = ds.Tables[0].Rows[0]["TehsilId"].NulllToInt();
                        _Details.CityId = ds.Tables[0].Rows[0]["CityId"].NulllToInt();
                        _Details.BlockId = ds.Tables[0].Rows[0]["BlockId"].NulllToInt();
                        _Details.WardNo = ds.Tables[0].Rows[0]["WardNo"].ToString();
                        _Details.LocationType = ds.Tables[0].Rows[0]["LocationType"].ToString();
                        _Details.AddressLine1 = ds.Tables[0].Rows[0]["AddressLine1"].ToString();
                        _Details.AddressLine2 = ds.Tables[0].Rows[0]["AddressLine2"].ToString();
                        _Details.AddiMobileNumber = ds.Tables[0].Rows[0]["addMobileNo"].ToString();
                        _Details.LandlineNumber = ds.Tables[0].Rows[0]["addPhoneNo"].ToString();
                        _Details.CollageType = ds.Tables[0].Rows[0]["CollageType"].ToString();
                        _Details.collegeLevel = ds.Tables[0].Rows[0]["CollageLevel"].ToString();
                        _Details.collegeMedium = ds.Tables[0].Rows[0]["CollegeMedium"].ToString();
                        _Details.CollageLogo = ds.Tables[0].Rows[0]["CollageLogo"].ToString();
                        _Details.CollageLogoContenttype = ds.Tables[0].Rows[0]["CollageLogoContenttype"].ToString();

                        _Details.CollageCategory = ds.Tables[0].Rows[0]["CollageCategory"].ToString();
                        _Details.AISHECodeStatus = ds.Tables[0].Rows[0]["AISHECodeStatus"].ToString();
                        _Details.AIESHCode = ds.Tables[0].Rows[0]["AIESHCode"].ToString();
                        _Details.PaliamentAreaName = ds.Tables[0].Rows[0]["iFk_ParlmntId"].NulllToInt();
                        _Details.LegislativeAreaName = ds.Tables[0].Rows[0]["iFk_AsmblId"].NulllToInt();
                        _Details.CollageNamehindi = ds.Tables[0].Rows[0]["CollageNamehindi"].NulllToString();
                        _Details.DivisionId = ds.Tables[0].Rows[0]["iFk_DivId"].NulllToInt();
                        _Details.SubDivisionId = ds.Tables[0].Rows[0]["iFK_SubDivId"].NulllToInt();
                        _Details.TagDegrees = ds.Tables[0].Rows[0]["iDepartment"].NulllToString();
                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        foreach (DataRow DR in ds.Tables[1].Rows)
                        {
                            _contactDet.Add(new ContactDetails
                            {
                                Name = DR["sName"].ToString(),
                                Email = DR["sEmailNo"].ToString(),
                                Number = DR["sCntcNo"].ToString()
                            });
                        }
                    }
                    _Details.ContactDetails = _contactDet;
                }
            }
            catch (Exception ex)
            {
                ExceptionLogDL.WriteExceptionDB(ex, "NA", "api", "BasicDetails:GetCollageDetails", "UNOCapi", "NA");
            }
            return _Details;
        }

        //Report details
        public ResponseData GetReportApplication(string applGUID)
        {
            ResponseData responseData = new ResponseData();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@applGUID", applGUID);
                param[1] = new SqlParameter("@type", "UserView");
                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_MASTER_DraftApplication_List]", param);
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    responseData.Message = "Data Fetched...";
                    responseData.statusCode = 1;
                    responseData.ResponseCode = "001";
                    responseData.Data = ds.Tables[0];
                    //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    //{
                    //    objdoc.Id = ds.Tables[0].Rows[i]["Id"].NulllToInt();
                    //    objdoc.text = ds.Tables[0].Rows[i]["CustomName"].NulllToString();
                    //    objListdoc.Add(objdoc);
                    //}
                }

            }
            catch (Exception e)
            {
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : BasicDetailsDL / Function : GetReportApplication");
            }
            return responseData;
        }
        //Application Tracking details
        public ResponseData GetApplicationtracking(string applGUID)
        {
            ResponseData responseData = new ResponseData();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@applGUID", applGUID);
                //param[1] = new SqlParameter("@type", "UserView");
                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_ApplicationTracking_List]", param);
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    responseData.Message = "Data Fetched...";
                    responseData.statusCode = 1;
                    responseData.ResponseCode = "001";
                    responseData.Data = ds.Tables[0];
                    //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    //{
                    //    objdoc.Id = ds.Tables[0].Rows[i]["Id"].NulllToInt();
                    //    objdoc.text = ds.Tables[0].Rows[i]["CustomName"].NulllToString();
                    //    objListdoc.Add(objdoc);
                    //}
                }

            }
            catch (Exception e)
            {
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : BasicDetailsDL / Function : GetReportApplication");
            }
            return responseData;
        }

        public ResponseData DepartmentapplicationList(string applGUID)
        {
            ResponseData responseData = new ResponseData();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@applGUID", applGUID);
                param[1] = new SqlParameter("@type", "DepartmentapplicationList");
                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_MASTER_DraftApplication_List]", param);
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    responseData.Message = "Data Fetched...";
                    responseData.statusCode = 1;
                    responseData.ResponseCode = "001";
                    responseData.Data = ds.Tables[0];
                }

            }
            catch (Exception e)
            {
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : TrusteeDL / Function : GetDarftApplications");
            }
            return responseData;
        }
        public ResponseData GetSUbject(int colId, int couId, string DataType, string subjectlist = null)
        {
            ResponseData responseData = new ResponseData();
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@ClgId", colId);
                param[1] = new SqlParameter("@CourserId", couId);
                param[2] = new SqlParameter("@Sublist ", subjectlist);
                param[3] = new SqlParameter("@Type", DataType);
                DataSet ds = BaseFunction.FillDataSet("[dbo].[Usp_Admin_UnSelect_Subject]", param);
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    responseData.Message = "Data Fetched...";
                    responseData.statusCode = 1;
                    responseData.ResponseCode = "001";
                    responseData.Data = ds.Tables[0];
                }

            }
            catch (Exception e)
            {
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : TrusteeDL / Function : GetDarftApplications");
            }
            return responseData;
        }
        public ResponseData GetCollageDropDownListbytrustId(int Id, int trustid)
        {
            ResponseData responseData = new ResponseData();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@Id", Id);
                param[1] = new SqlParameter("@trustid", trustid);
                DataSet ds = BaseFunction.FillDataSet("[dbo].[Usp_Admin_Get_College_TrstId]", param);
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    responseData.Message = "Data Fetched...";
                    responseData.statusCode = 1;
                    responseData.ResponseCode = "001";
                    responseData.Data = ds.Tables[0];
                    //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    //{
                    //    objdoc.Id = ds.Tables[0].Rows[i]["Id"].NulllToInt();
                    //    objdoc.text = ds.Tables[0].Rows[i]["CustomName"].NulllToString();
                    //    objListdoc.Add(objdoc);
                    //}
                }

            }
            catch (Exception e)
            {
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : TrusteeDL / Function : GetTrustDropDownList");
            }
            return responseData;
        }
    }
}
