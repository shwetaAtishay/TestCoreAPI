using BO;
using BO.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Text;
using static System.Exception;

namespace DL
{
    public class TargetDL
    {
        ResponseData objResponseData = new ResponseData();
        ErrorBO _Access = new ErrorBO();
        public static IConfiguration _configuration;
        string connectionString = DBCS.GetConnectionString();

        //Insert Data
        //public List<TargetMaster> GetTarget(TargetMaster master)
        //{
        //    List<TargetMaster> objlist = new List<TargetMaster>();
        //    try
        //    {
        //        DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_MASTER_TargetDetails_View]");
        //        if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
        //        {
        //            objlist = new List<TargetMaster>();
        //            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //            {
        //                TargetMaster objdoc = new TargetMaster();
        //                objdoc.CategoryId = Convert.ToInt32(ds.Tables[0].Rows[i]["CategoryId"]);
        //                objdoc.TargetAmount = ds.Tables[0].Rows[i]["tTrgAmt"].NulllToString();
        //                objdoc.TargetPeriod = ds.Tables[0].Rows[i]["pTrgPeriode"].NulllToString();
        //                objdoc.StartingDate = ds.Tables[0].Rows[i]["sStrDate"].NulllToString();
        //                objdoc.StartTargetDate = ds.Tables[0].Rows[i]["sStrTRGDate"].NulllToString();
        //                objlist.Add(objdoc);
        //            }
        //        }
        //        else
        //        {
        //            objlist = null;
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        objlist = null;
        //        ExceptionLogDL.SendExcepToDB(e, 0, "Class : TargetDL / Function : GetTarget");
        //    }
        //    return objlist;
        //}

        //public ResponseData TargetStatus(TargetMaster obj)
        //{
        //    DataSet ds = new DataSet();
        //    try
        //    {
        //        SqlParameter[] param = new SqlParameter[6];
        //        param[0] = new SqlParameter("@CategoryId", obj.CategoryId);
        //        param[1] = new SqlParameter("@TrgAmt", obj.TargetAmount);
        //        param[2] = new SqlParameter("@TrgPeriod", obj.TargetPeriod);
        //        param[3] = new SqlParameter("@TargetType", obj.TargetType);
        //        param[4] = new SqlParameter("@StrDate", obj.StartingDate);
        //        param[5] = new SqlParameter("@StrTRGDate", obj.StartTargetDate);           
                      
        //        ds = BaseFunction.FillDataSet("[dbo].[USP_MASTER_TargetDetails_Save]", param);
        //        if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
        //        {
        //            if (ds.Tables[0].Rows.Count > 0)
        //            {
        //                objResponseData.Message = ds.Tables[0].Rows[0]["Message"].NulllToString();
        //                objResponseData.ResponseCode = ds.Tables[0].Rows[0]["Flag"].NulllToString();
        //                return objResponseData;
        //            }
        //            else
        //            {
        //                objResponseData.Message = BO.CustomMessage.NORECORDFOUND;
        //                objResponseData.ResponseCode = BO.CustomMessage.NORECORDFOUND_RESPONSECODE.ToString();
        //                return objResponseData;
        //            }
        //        }
        //        else
        //        {
        //            objResponseData.Message = BO.CustomMessage.NORECORDFOUND;
        //            objResponseData.ResponseCode = BO.CustomMessage.NORECORDFOUND_RESPONSECODE.ToString();
        //            return objResponseData;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        objResponseData.Message = BO.CustomMessage.EXCEPTIONOCCURRED;
        //        objResponseData.ResponseCode = BO.CustomMessage.EXCEPTIONOCCURRED_RESPONSECODE.ToString();
        //        return objResponseData;
        //    }
        //}


    }
}
