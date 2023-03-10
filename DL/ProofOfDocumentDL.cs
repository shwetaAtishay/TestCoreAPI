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
    public class ProofOfDocumentDL
    {
        //ResponseData objResponseData = new ResponseData();
        ErrorBO objResponseData = new ErrorBO();
        public static IConfiguration _configuration;
        string connectionString = DBCS.GetConnectionString();

        public ErrorBO DocumentDetail(ProofOfDocumentBO obj)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] param = new SqlParameter[32];
                param[0] = new SqlParameter("@Type", "Insert");
                param[1] = new SqlParameter("@iFk_TrstId", obj.iFk_TrstId);
                param[2] = new SqlParameter("@iFk_ClgId", obj.iFk_ClgId);
                param[3] = new SqlParameter("@sSSOID", obj.sSSOID);
                param[4] = new SqlParameter("@sCrtdBy", obj.sCrtdBy);
                param[5] = new SqlParameter("@dtCrtdDt", obj.dtCrtdDt);
                param[6] = new SqlParameter("@sUpdtBy", obj.sUpdtBy);
                param[7] = new SqlParameter("@dtUpdDt", obj.dtUpdDt);
                param[8] = new SqlParameter("@certifiedcopy", obj.certifiedcopy);
                param[9] = new SqlParameter("@certifiedcopyExtension", obj.certifiedcopyExtension);
                param[10] = new SqlParameter("@certifiedcopyContenttype", obj.certifiedcopyContenttype);
                param[11] = new SqlParameter("@AimsandObjective", obj.AimsandObjective);
                param[12] = new SqlParameter("@AimsandObjectiveExtension", obj.AimsandObjectiveExtension);
                param[13] = new SqlParameter("@AimsandObjectiveContenttype", obj.AimsandObjectiveContenttype);

                param[14] = new SqlParameter("@ProjectmapandRoad", obj.ProjectmapandRoad);
                param[15] = new SqlParameter("@ProjectmapandRoadExtension", obj.ProjectmapandRoadExtension);
                param[16] = new SqlParameter("@ProjectmapandRoadContenttype", obj.ProjectmapandRoadContenttype);

                param[17] = new SqlParameter("@ProofofOwnership", obj.ProofofOwnership);
                param[18] = new SqlParameter("@ProofofOwnershipExtension", obj.ProofofOwnershipExtension);
                param[19] = new SqlParameter("@ProofofOwnershipContenttype", obj.ProofofOwnershipContenttype);

                param[20] = new SqlParameter("@Authorizationletters", obj.Authorizationletters);
                param[21] = new SqlParameter("@AuthorizationlettersExtension", obj.AuthorizationlettersExtension);
                param[22] = new SqlParameter("@AuthorizationlettersContenttype", obj.AuthorizationlettersContenttype);

                param[23] = new SqlParameter("@ProjectReport", obj.ProjectReport);
                param[24] = new SqlParameter("@ProjectReportExtension", obj.ProjectReportExtension);
                param[25] = new SqlParameter("@ProjectReportContenttype", obj.ProjectReportContenttype);

                param[26] = new SqlParameter("@BalanceSheet", obj.BalanceSheet);
                param[27] = new SqlParameter("@BalanceSheetExtension", obj.BalanceSheetExtension);
                param[28] = new SqlParameter("@BalanceSheetContenttype", obj.BalanceSheetContenttype);

                param[29] = new SqlParameter("@ESI", obj.ESI);
                param[30] = new SqlParameter("@ESIExtension", obj.ESIExtension);
                param[31] = new SqlParameter("@ESIContenttype", obj.ESIContenttype);

                ds = BaseFunction.FillDataSet("[dbo].[USP_DocumentUploadDetails_save]", param);
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
                throw ex;
            }

            // string AplcnNo = "TMP" + DateTime.Now.ToString("ddMMyyyyhhmmsssss");
            //using (DataTable DT = new DataTable())
            //{
            //    using (SqlConnection connect = new SqlConnection())
            //    {
            //        using (SqlCommand cmd = new SqlCommand())
            //        {
            //            cmd.CommandText = "[dbo].[USP_DocumentUploadDetails_save]";
            //            cmd.CommandType = CommandType.StoredProcedure;
            //            cmd.Parameters.AddWithValue("@Type", "Insert");
            //            cmd.Parameters.AddWithValue("@iFk_TrstId", obj.iFk_TrstId);
            //            cmd.Parameters.AddWithValue("@iFk_ClgId", obj.iFk_ClgId);
            //            cmd.Parameters.AddWithValue("@sSSOID", obj.sSSOID);
            //            cmd.Parameters.AddWithValue("@sCrtdBy", obj.sCrtdBy);
            //            cmd.Parameters.AddWithValue("@dtCrtdDt", obj.dtCrtdDt);
            //            cmd.Parameters.AddWithValue("@sUpdtBy", obj.sUpdtBy);
            //            cmd.Parameters.AddWithValue("@dtUpdDt", obj.dtUpdDt);
            //            cmd.Parameters.AddWithValue("@certifiedcopy", obj.certifiedcopy);
            //            cmd.Parameters.AddWithValue("@certifiedcopyExtension", obj.certifiedcopyExtension);
            //            cmd.Parameters.AddWithValue("@certifiedcopyContenttype", obj.certifiedcopyContenttype);

            //            cmd.Parameters.AddWithValue("@AimsandObjective", obj.AimsandObjective);
            //            cmd.Parameters.AddWithValue("@AimsandObjectiveExtension", obj.AimsandObjectiveExtension);
            //            cmd.Parameters.AddWithValue("@AimsandObjectiveContenttype", obj.AimsandObjectiveContenttype);

            //            cmd.Parameters.AddWithValue("@ProjectmapandRoad", obj.ProjectmapandRoad);
            //            cmd.Parameters.AddWithValue("@ProjectmapandRoadExtension", obj.ProjectmapandRoadExtension);
            //            cmd.Parameters.AddWithValue("@ProjectmapandRoadContenttype", obj.ProjectmapandRoadContenttype);

            //            cmd.Parameters.AddWithValue("@ProofofOwnership", obj.ProofofOwnership);
            //            cmd.Parameters.AddWithValue("@ProofofOwnershipExtension", obj.ProofofOwnershipExtension);
            //            cmd.Parameters.AddWithValue("@ProofofOwnershipContenttype", obj.ProofofOwnershipContenttype);

            //            cmd.Parameters.AddWithValue("@Authorizationletters", obj.Authorizationletters);
            //            cmd.Parameters.AddWithValue("@AuthorizationlettersExtension", obj.AuthorizationlettersExtension);
            //            cmd.Parameters.AddWithValue("@AuthorizationlettersContenttype", obj.AuthorizationlettersContenttype);

            //            cmd.Parameters.AddWithValue("@ProjectReport", obj.ProjectReport);
            //            cmd.Parameters.AddWithValue("@ProjectReportExtension", obj.ProjectReportExtension);
            //            cmd.Parameters.AddWithValue("@ProjectReportContenttype", obj.ProjectReportContenttype);

            //            cmd.Parameters.AddWithValue("@BalanceSheet", obj.BalanceSheet);
            //            cmd.Parameters.AddWithValue("@BalanceSheetExtension", obj.BalanceSheetExtension);
            //            cmd.Parameters.AddWithValue("@BalanceSheetContenttype", obj.BalanceSheetContenttype);

            //            cmd.Parameters.AddWithValue("@ESI", obj.ESI);
            //            cmd.Parameters.AddWithValue("@ESIExtension", obj.ESIExtension);
            //            cmd.Parameters.AddWithValue("@ESIContenttype", obj.ESIContenttype);

            //            //try
            //            //{
            //            //    connect.ConnectionString = connectionString;
            //            //    cmd.Connection = connect;
            //            //    if (cmd.Connection.State != ConnectionState.Open)
            //            //    {
            //            //        cmd.Connection.Open();
            //            //    }
            //            //    SqlDataReader dr = cmd.ExecuteReader();
            //            //    DT.Load(dr);
            //            //    cmd.Connection.Close();
            //            //    if (DT != null)
            //            //    {
            //            //        if (DT.Rows.Count > 0)
            //            //        {
            //            //            objResponseData.statusCode = Convert.ToInt32(DT.Rows[0]["StatusCode"]);
            //            //            objResponseData.Message = DT.Rows[0]["Message"].ToString();

            //            //        }
            //            //    }
            //            //    else
            //            //    {
            //            //        objResponseData.statusCode = 0;
            //            //        objResponseData.Message = "Failed";
            //            //    }
            //            //}
            //            //catch (Exception e)
            //            //{
            //            //    objResponseData.statusCode = 0;
            //            //    objResponseData.Message = "Failed";
            //            //    ExceptionLogDL.SendExcepToDB(e, 0, "Class : BasicDetailsDL / Function : InsertUpdateBasickDetails");
            //            //}
            //        }
            //    }
            //    return objResponseData;
            //}
        }

    }
}
