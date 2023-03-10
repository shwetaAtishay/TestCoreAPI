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
    public class ReportsDL
    {
        RequestData _result = new RequestData();
        ErrorBO _result1 = new ErrorBO();
        public static IConfiguration _configuration;
        string connectionString = DBCS.GetConnectionString();

        //public LedgerReportDetails GetLedgerReport(LedgerReport objReport)
        //{            
        //    LedgerReportDetails cliData = new LedgerReportDetails();
        //    try
        //    {
        //        List<ALLLedgerReport> returnModel = new List<ALLLedgerReport>();

        //        SqlParameter[] param = new SqlParameter[3];
        //        param[0] = new SqlParameter("@PartyId", objReport.LoginID);
        //        param[1] = new SqlParameter("@FromDate", objReport.FromDate);
        //        param[2] = new SqlParameter("@ToDate", objReport.ToDate); 
        //        DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_REPORT_LedgerDetails_Select]", param);
        //        if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
        //        {
        //            if (ds.Tables[0].Rows.Count > 0 && ds.Tables.Count > 1)
        //            {
        //                cliData.ResponseCode = ds.Tables[0].Rows[0]["Flag"].NulllToString();
        //                cliData.Messsage = ds.Tables[0].Rows[0]["Message"].NulllToString();
        //                int i = 0;
        //                foreach (DataRow dr in ds.Tables[1].Rows)
        //                {
        //                    i = i + 1;
        //                    returnModel.Add(new ALLLedgerReport()
        //                    {
        //                        LedgerID = i
        //                        ,
        //                        OpeningBalance = dr["dOPBlnce"].NulllToDecimal()
        //                         ,
        //                        Credit = dr["dCr"].NulllToDecimal()
        //                        ,
        //                        Debit = dr["dDr"].NulllToDecimal()
        //                        ,
        //                        ClosingBalance = dr["dCL"].NulllToDecimal()
        //                        ,
        //                        TransactionDate = dr["dtTrnsctnDt"].NulllToString()
        //                         ,
        //                        Narration = dr["sNarration"].NulllToString()
        //                        ,
        //                        TransactionID = dr["sTrnsctnId"].NulllToString()
        //                    });
        //                }
        //                cliData.Data = returnModel;
        //            }
        //            else
        //            {
        //                cliData.ResponseCode = "0";
        //                cliData.Messsage = "No Data Found-Un!";
        //                cliData.Data = null;
        //            }

        //        }
        //        else
        //        {
        //            cliData.ResponseCode = "0";
        //            cliData.Messsage = "No Data Found-Un!";
        //            cliData.Data = null;
        //        }



        //    }
        //    catch (Exception ex)
        //    {
        //        cliData.ResponseCode = "5";
        //        cliData.Messsage = "No Data Found-Un!";
        //        cliData.Data = null;
        //        ExceptionLogDL.SendExcepToDB(ex, 0, "ReportDL:GetLedgerReport");
        //        return cliData;
        //    }
        //    return cliData;

        //}

        public List<AllReportBO> GetReportDetail(string iFKTst_ID)
        {
            List<AllReportBO> objListdoc = new List<AllReportBO>();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@Type", "FormsStatus");
                param[1] = new SqlParameter("@iFKTst_ID", iFKTst_ID);
                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_Dashboard_Forms_Status]", param);
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    objListdoc = new List<AllReportBO>();


                    AllReportBO cService = new AllReportBO();
                    cService.DraftApplcn = ds.Tables[0].Rows[0]["DraftApplcn"].NulllToString();
                    cService.FormSubmtOn = ds.Tables[1].Rows[0]["FormSubmtOn"].NulllToString();
                    cService.PendingForm = ds.Tables[2].Rows[0]["PendingForm"].NulllToString();
                    cService.CancelForm = ds.Tables[3].Rows[0]["CancelForm"].NulllToString();
                    cService.RejectForm = ds.Tables[4].Rows[0]["RejectForm"].NulllToString();
                    cService.InprocessForm = ds.Tables[5].Rows[0]["InprocessForm"].NulllToString();
                    objListdoc.Add(cService);

                }
                else
                {
                    objListdoc = null;
                }
            }
            catch (Exception e)
            {
                objListdoc = null;
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AllReportDL / Function : GetUSerwisePartnerCountDetail");
            }
            return objListdoc;
        }

    }
}
