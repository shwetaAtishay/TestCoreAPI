using BO;
using BO.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DL
{
    public class LandDetailsDL
    {
        ResponseData objResponseData = new ResponseData();
        ErrorBO _Access = new ErrorBO();
        public static IConfiguration _configuration;
        string connectionString = DBCS.GetConnectionString();

        public ResponseData BuildingDetailConfigure(LandBuildingBO obj)
        {
            string AplcnNo = "LandandBuildingInformation";
            using (DataTable DT = new DataTable())
            {
                using (SqlConnection connect = new SqlConnection())
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "[dbo].[USP_MASTER_BuildingInfoDetails_Save]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@iFk_AplcnId", AplcnNo);
                        cmd.Parameters.AddWithValue("@iFK_ClgId", "");
                        cmd.Parameters.AddWithValue("@bLndConvert", "");
                        cmd.Parameters.AddWithValue("@sOwnrName", obj.sOwnerbuildNo);
                        cmd.Parameters.AddWithValue("@sOwnerbuildNo", obj.sOwnerbuildNo);
                        cmd.Parameters.AddWithValue("@dtOrderDt", obj.dtOrderDt);
                        cmd.Parameters.AddWithValue("@sLandDetails", obj.sLandDetails);
                        cmd.Parameters.AddWithValue("@sLndNo", obj.sLndNo);
                        cmd.Parameters.AddWithValue("@IsAnyOtherInfo", obj.IsAnyOtherInfo);
                        try
                        {
                            connect.ConnectionString = connectionString;
                            cmd.Connection = connect;
                            if (cmd.Connection.State != ConnectionState.Open)
                            {
                                cmd.Connection.Open();
                            }
                            SqlDataReader dr = cmd.ExecuteReader();
                            DT.Load(dr);
                            cmd.Connection.Close();
                            if (DT != null)
                            {
                                if (DT.Rows.Count > 0)
                                {
                                    objResponseData.statusCode = Convert.ToInt32(DT.Rows[0]["StatusCode"]);
                                    objResponseData.Message = DT.Rows[0]["Message"].ToString();

                                }
                            }
                            else
                            {
                                objResponseData.statusCode = 0;
                                objResponseData.Message = "Failed";
                            }
                        }
                        catch (Exception e)
                        {
                            objResponseData.statusCode = 0;
                            objResponseData.Message = "Failed";
                            ExceptionLogDL.SendExcepToDB(e, 0, "Class : BasicDetailsDL / Function : InsertUpdateBasickDetails");
                        }
                    }
                }
                return objResponseData;
            }
        }

        public ResponseData SaveLandInfo(List<LandInfoBO> _obj)
        {
            DataSet ds = new DataSet();
            ResponseData responseData = new ResponseData();
            try
            {
                if (_obj != null)
                {
                    SqlParameter[] paramDelete = new SqlParameter[3];
                    paramDelete[0] = new SqlParameter("@sApplGUID", _obj[0].sApplGUID);
                    paramDelete[1] = new SqlParameter("@iClgID", _obj[0].iClgID);
                    paramDelete[2] = new SqlParameter("@type", "Delete");
                    ds = BaseFunction.FillDataSet("[dbo].[USP_ADMIN_Land_BuildingInfo_Save]", paramDelete);
                    if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            responseData.statusCode = 1;
                            responseData.Message = "Details Saved Successfully";
                        }
                        else
                        {
                            responseData.statusCode = 1;
                            responseData.Message = "No Row has effacted";
                        }
                    }
                    else
                    {
                        responseData.Message = CustomMessage.NORECORDFOUND;
                        responseData.statusCode = CustomMessage.NORECORDFOUND_RESPONSECODE;
                    }

                    foreach (var item in _obj)
                    {
                        var dat = "";
                        if (string.IsNullOrEmpty(item.dtOrdrDate) || item.dtOrdrDate.Length <= 0 || item.dtOrdrDate == "NA")
                            dat = null;
                        else
                            dat = Convert.ToDateTime(item.dtOrdrDate).ToString("dd.MM.yyyy");

                        SqlParameter[] param = new SqlParameter[37];
                        param[0] = new SqlParameter("@iDeptID", item.iDeptID);
                        param[1] = new SqlParameter("@iCorsID", item.iCorsID);
                        param[2] = new SqlParameter("@iClgID", item.iClgID);
                        param[3] = new SqlParameter("@iFinyr", item.iFinyr);
                        param[4] = new SqlParameter("@iTrstID", item.iTrstID);
                        param[5] = new SqlParameter("@sApplGUID", item.sApplGUID);
                        param[6] = new SqlParameter("@sLndArea", item.sLndArea);
                        param[7] = new SqlParameter("@sLndDocType", item.sLndDocType);
                        param[8] = new SqlParameter("@sIsLndCnvrted", item.sIsLndCnvrted);
                        param[9] = new SqlParameter("@sOrdrNo", item.sOrdrNo);
                        param[10] = new SqlParameter("@dtOrdrDate", dat);
                        param[11] = new SqlParameter("@sLndTyp", item.sLndTyp);
                        param[12] = new SqlParameter("@sKhasaraNo", item.sKhasaraNo);
                        param[13] = new SqlParameter("@dLndArea", item.dLndArea);
                        param[14] = new SqlParameter("@dTotalArea", item.dTotalArea);
                        param[15] = new SqlParameter("@LandConvert", item.UploadConvertedDocument);
                        param[16] = new SqlParameter("@LandConvertExtension", item.UploadConvertedDocumentExtension);
                        param[17] = new SqlParameter("@LandConvertContentType", item.UploadConvertedDocumentContent);
                        param[18] = new SqlParameter("@LandTitle", item.UploadLandTitleDoc);
                        param[19] = new SqlParameter("@LandTitleExtension", item.UploadLandTitleDocExtension);
                        param[20] = new SqlParameter("@LandTitleContentType", item.UploadLandTitleDocContent);
                        param[21] = new SqlParameter("@LandDoc", item.UploadLandDoc);
                        param[22] = new SqlParameter("@LandDocExtension", item.UploadLandDocExtension);
                        param[23] = new SqlParameter("@LandDocContentType", item.UploadLandDocContent);
                        param[24] = new SqlParameter("@LandAccureDoc", item.UploadLandAccureTypeDoc);
                        param[25] = new SqlParameter("@LandAccureDocExtension", item.UploadLandAccureTypeDocExtension);
                        param[26] = new SqlParameter("@LandAccureDocContentType", item.UploadLandAccureTypeDocContent);

                        param[27] = new SqlParameter("@LandNotConvertDoc", item.UploadLandNotConvertDoc);
                        param[28] = new SqlParameter("@LandNotConvertDocExtension", item.UploadLandNotConvertDocExtension);
                        param[29] = new SqlParameter("@LandNotConvertDocContentType", item.UploadLandNotConvertDocContent);


                        param[30] = new SqlParameter("@slndAccureTyp", item.slndAccureTyp);
                        param[31] = new SqlParameter("@sEntryType", item.sEntryType);
                        param[32] = new SqlParameter("@sOwnerName", item.sOwnerName);

                        param[33] = new SqlParameter("@type", "Insert");
                        param[34] = new SqlParameter("@LandConvertAffidavit", item.UploadConvertedDocumentAffidavit);
                        param[35] = new SqlParameter("@LandConvertExtensionAffidavit", item.UploadConvertedDocumentExtensionAffidavit);
                        param[36] = new SqlParameter("@LandConvertContentTypeAffidavit", item.UploadConvertedDocumentContentAffidavit);

                        ds = BaseFunction.FillDataSet("[dbo].[USP_ADMIN_Land_BuildingInfo_Save]", param);
                        if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                        {
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                //_Access.Messsage = ds.Tables[0].Rows[0]["Message"].NulllToString();
                                //_Access.ResponseCode = ds.Tables[0].Rows[0]["Flag"].NulllToString();
                                responseData.statusCode = 1;
                                responseData.Message = "Details Saved Successfully";
                            }
                            else
                            {
                                //_Access.Messsage = ds.Tables[0].Rows[0]["Message"].NulllToString();
                                //_Access.ResponseCode = ds.Tables[0].Rows[0]["Flag"].NulllToString();
                                //return _Access;
                                responseData.statusCode = 1;
                                responseData.Message = "No Row has effacted";
                            }
                        }
                        else
                        {
                            responseData.Message = CustomMessage.NORECORDFOUND;
                            responseData.statusCode = CustomMessage.NORECORDFOUND_RESPONSECODE;
                        }
                    }
                }
                return responseData;
            }
            catch (Exception ex)
            {
                responseData.Message = CustomMessage.NORECORDFOUND;
                responseData.statusCode = CustomMessage.NORECORDFOUND_RESPONSECODE;
                return responseData;
            }
        }
        public ResponseData GetLandData(string APPGUID)
        {
            DataSet ds = new DataSet();
            ResponseData responseData = new ResponseData();
            try
            {

                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@appguid", APPGUID);


                ds = BaseFunction.FillDataSet("[dbo].[USP_ADMIN_Land_BuildingInfo_View]", param);
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        //_Access.Messsage = ds.Tables[0].Rows[0]["Message"].NulllToString();
                        //_Access.ResponseCode = ds.Tables[0].Rows[0]["Flag"].NulllToString();
                        responseData.statusCode = 1;
                        responseData.Message = "Details Saved Successfully";
                        responseData.Data = ds.Tables[0];
                        return responseData;
                    }
                    else
                    {
                        //_Access.Messsage = ds.Tables[0].Rows[0]["Message"].NulllToString();
                        //_Access.ResponseCode = ds.Tables[0].Rows[0]["Flag"].NulllToString();
                        //return _Access;
                        responseData.statusCode = 1;
                        responseData.Message = "No Row has effacted";

                        return responseData;
                    }
                }
                else
                {
                    responseData.Message = CustomMessage.NORECORDFOUND;
                    responseData.statusCode = CustomMessage.NORECORDFOUND_RESPONSECODE;
                    //responseData.Data = ds.Tables[0];
                    return responseData;
                }

                return responseData;
            }
            catch (Exception ex)
            {
                responseData.Message = CustomMessage.NORECORDFOUND;
                responseData.statusCode = CustomMessage.NORECORDFOUND_RESPONSECODE;
                return responseData;
            }
        }

        public ResponseData AddBuildingInfo(BuildingDetails _obj)
        {
            DataSet ds = new DataSet();
            ResponseData responseData = new ResponseData();
            try
            {

                SqlParameter[] param = new SqlParameter[22];
                param[0] = new SqlParameter("@sAppGUID", _obj.sAppGUID);
                param[1] = new SqlParameter("@sBldgntyp", _obj.sBldgntyp);
                param[2] = new SqlParameter("@sOrdNo", _obj.sOrdNo);
                param[3] = new SqlParameter("@dtOrd", _obj.dtOrd);
                param[4] = new SqlParameter("@OwnedBldgnDoc", _obj.OwnedBldgnDoc);
                param[5] = new SqlParameter("@dtAgrExp", _obj.dtAgrExp);
                param[6] = new SqlParameter("@AgrExpDoc", _obj.AgrExpDoc);
                param[7] = new SqlParameter("@dtFireFrom", _obj.dtFireFrom);
                param[8] = new SqlParameter("@dtFireTo", _obj.dtFireTo);
                param[9] = new SqlParameter("@FireNOCDoc", _obj.FireNOCDoc);
                param[10] = new SqlParameter("@dtPWDFrom", _obj.dtPWDFrom);
                param[11] = new SqlParameter("@dtPWDTo", _obj.dtPWDTo);
                param[12] = new SqlParameter("@PWDNOCDoc", _obj.PWDNOCDoc);
                param[13] = new SqlParameter("@BFrontImg", _obj.BFrontImg);
                param[14] = new SqlParameter("@BBackImg", _obj.BBackImg);
                param[15] = new SqlParameter("@BLeftImg", _obj.BLeftImg);
                param[16] = new SqlParameter("@BRightImg", _obj.BRightImg);
                param[17] = new SqlParameter("@BOtherImg", _obj.BOtherImg);
                param[18] = new SqlParameter("@dtCrtdBy", _obj.dtCrtdBy);
                param[19] = new SqlParameter("@RentOrderNo", _obj.rentedOrderNo);
                param[20] = new SqlParameter("@RentCertificateDoc", _obj.rentedCertificateDoc);
                param[21] = new SqlParameter("@PwdOrderNo", _obj.sPWDOrderNo);

                ds = BaseFunction.FillDataSet("[dbo].[USP_ADMIN_AddBuildingDetails_Insert]", param);
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        //_Access.Messsage = ds.Tables[0].Rows[0]["Message"].NulllToString();
                        //_Access.ResponseCode = ds.Tables[0].Rows[0]["Flag"].NulllToString();
                        responseData.statusCode = 1;
                        responseData.Message = "Details Saved Successfully";
                        responseData.Data = ds.Tables[0];
                        //return responseData;
                    }
                    else
                    {
                        //_Access.Messsage = ds.Tables[0].Rows[0]["Message"].NulllToString();
                        //_Access.ResponseCode = ds.Tables[0].Rows[0]["Flag"].NulllToString();
                        //return _Access;
                        responseData.statusCode = 1;
                        responseData.Message = "No Row has effacted";

                        //return responseData;
                    }
                }
                else
                {
                    responseData.Message = CustomMessage.NORECORDFOUND;
                    responseData.statusCode = CustomMessage.NORECORDFOUND_RESPONSECODE;
                    //responseData.Data = ds.Tables[0];
                    //return responseData;
                }

               // return responseData;
            }
            catch (Exception ex)
            {
                responseData.Message = CustomMessage.NORECORDFOUND;
                responseData.statusCode = CustomMessage.NORECORDFOUND_RESPONSECODE;
              
            }
            return responseData;
        }
    }
}
