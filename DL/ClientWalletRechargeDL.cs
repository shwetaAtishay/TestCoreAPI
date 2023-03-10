using BO;
using BO.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Text;

namespace DL
{
    public class ClientWalletRechargeDL
    {
        ErrorBO _Access = new ErrorBO();             
        //#region WRHistory:Added By Shipra Garg
        //public ErrorBO ClientWalletRequest(ClientWalletRecharge partyDet)
        //{
        //    try
        //    {
        //        byte[] UpdateloadData = Convert.FromBase64String("0X00");
        //        if (partyDet.Receiptbase64 != null)
        //        {
        //            UpdateloadData = Convert.FromBase64String(partyDet.Receiptbase64);
        //        }
        //        partyDet.OrderId = partyDet.PartyId + "-" + DateTime.Now.Date.ToString("dd-MM-yyyy").Replace("-", "") + "-" + Guid.NewGuid().ToString().Substring(Guid.NewGuid().ToString().Length - 6, 5);

                
        //        SqlParameter[] param = new SqlParameter[15];
        //        param[0] = new SqlParameter("@PartyID", partyDet.PartyId);
        //        param[1] = new SqlParameter("@OrderId", partyDet.OrderId);
        //        param[2] = new SqlParameter("@Mode", partyDet.Mode);
        //        param[3] = new SqlParameter("@PaymentMode", partyDet.PaymentMode);
        //        param[4] = new SqlParameter("@ToBankAccount", partyDet.ToBankAccount);
        //        param[5] = new SqlParameter("@TransactionDate", partyDet.TransactionDate);
        //        param[6] = new SqlParameter("@Type", "WalletRequest");
        //        param[7] = new SqlParameter("@BankName", partyDet.BankName);
        //        param[8] = new SqlParameter("@UTRNo", partyDet.UTRNo);
        //        param[9] = new SqlParameter("@UPI", partyDet.UPI);
        //        param[10] = new SqlParameter("@AccountNo", partyDet.AccountNo);
        //        param[11] = new SqlParameter("@Amount", partyDet.Amount);
        //        param[12] = new SqlParameter("@DocumentId", partyDet.DocumentId);
        //        param[13] = new SqlParameter("@DocumentURL", partyDet.DocumentURL);
        //        param[14] = new SqlParameter("@Note", partyDet.Note);
        //        DataTable DT = BaseFunction.FillDataTable("[dbo].[USP_OPERATION_UserWalletRechargeRqst_SaveUpdate]", param);

        //        if (DT != null)
        //        {
        //            if (DT.Rows.Count > 0)
        //            {
        //                foreach (DataRow oRow in DT.Rows)
        //                {
        //                    _Access.Messsage = oRow["Message"].NulllToString();
        //                    _Access.ResponseCode = oRow["Flag"].NulllToString();
        //                }
        //            }
        //            else
        //            {
        //                _Access.Messsage = "Data Not Found";
        //                _Access.ResponseCode = "0";
        //            }
        //        }
        //        else
        //        {
        //            _Access.Messsage = "Data Not Found";
        //            _Access.ResponseCode = "0";
        //        }

        //        return _Access;
        //    }
        //    catch (Exception ex)
        //    {
        //        ExceptionLogDL.SendExcepToDB(ex, 0, "ClientWalletRechargeDL:ClientWalletRequest");
        //        _Access.ResponseCode = "5";
        //        _Access.Messsage = "Details Not Found-Ex!Please Contact Support.";
        //        return _Access;
        //    }
        //}

        //public ErrorBO RequestAcceptReject(ClientWalletRecharge partyDet)
        //{
        //    try
        //    {
                
        //        SqlParameter[] param = new SqlParameter[6];
        //        param[0] = new SqlParameter("@Type", "RequestAcceptReject");
        //        param[1] = new SqlParameter("@LoginId", partyDet.ParentId);
        //        param[2] = new SqlParameter("@Note", partyDet.Note);
        //        param[3] = new SqlParameter("@PartyID", partyDet.PartyId);
        //        param[4] = new SqlParameter("@UserWalletRequestID", partyDet.WalletRechargeId);
        //        param[5] = new SqlParameter("@Status", partyDet.Status);

        //        DataTable DT = BaseFunction.FillDataTable("[dbo].[USP_OPERATION_UserWalletRechargeRqst_SaveUpdate]", param);
        //        if (DT != null)
        //        {
        //            if (DT.Rows.Count > 0)
        //            {
        //                foreach (DataRow oRow in DT.Rows)
        //                {
        //                    _Access.Messsage = oRow["Message"].NulllToString();
        //                    _Access.ResponseCode = oRow["Flag"].NulllToString();
        //                }
        //            }
        //            else
        //            {
        //                _Access.Messsage = "Data Not Found";
        //                _Access.ResponseCode = "0";
        //            }
        //        }
        //        else
        //        {
        //            _Access.Messsage = "Data Not Found";
        //            _Access.ResponseCode = "0";
        //        }
        //        return _Access;
        //    }
        //    catch (Exception ex)
        //    {
        //        ExceptionLogDL.SendExcepToDB(ex, 0, "ClientWalletRechargeDA:RequestAcceptReject");
        //        //ExceptionLog.SendExcepToDB(ex, "NA", "ClientWalletRechargeDA:RequestAcceptReject", ex.Message.ToString());
        //        _Access.ResponseCode = "5";
        //        _Access.Messsage = "Details Not Found-Ex!Please Contact Support.";
        //        return _Access;
        //    }
        //}
        //public WalletRechargeReqList GetClientRequestDetails(WalletRechargeHistory partyDet)
        //{
        //    WalletRechargeReqList rechargetList = new WalletRechargeReqList();
        //    //var newbase64 = "";
        //    try
        //    {
                
        //        SqlParameter[] param = new SqlParameter[4];
        //        param[0] = new SqlParameter("@Type", "ClientRechargeRequestDetails");
        //        param[1] = new SqlParameter("@LoginId", partyDet.ParentId);
        //        param[2] = new SqlParameter("@FROMDATE", partyDet.FromDate);
        //        param[3] = new SqlParameter("@TODATE", partyDet.ToDate);
        //        DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_OPERATION_UserWalletRechargeRqst_SaveUpdate]", param);

        //        rechargetList.WalletRechargeLst = new List<ClientWalletRecharge>();
        //        if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
        //        {
        //            if (ds.Tables[0].Rows.Count > 0 && ds.Tables.Count > 1)
        //            {
        //                rechargetList.ResponseCode = ds.Tables[0].Rows[0]["Flag"].NulllToString();
        //                rechargetList.Messsage = ds.Tables[0].Rows[0]["Message"].NulllToString();
        //                foreach (DataRow DR in ds.Tables[1].Rows)
        //                {
        //                    //if (!string.IsNullOrEmpty(DR["Receiptbase64"].ToString()))
        //                    //{
        //                    //    newbase64 = Convert.ToBase64String((byte[])DR["Receiptbase64"]);
        //                    //}
        //                    rechargetList.WalletRechargeLst.Add(
        //                   new ClientWalletRecharge
        //                   {
        //                       PartyId = DR["sFK_PrtyCode"].ToString(),
        //                       PartyName = DR["FullName"].ToString(),
        //                       Mode = DR["Mode"].ToString(),
        //                       BankName = DR["sBnkName"].ToString(),
        //                       UTRNo = DR["sUtrNo"].ToString(),
        //                       UPI = DR["sUpi"].ToString(),
        //                       AccountNo = DR["sAccountNo"].ToString(),
        //                       ToBankAccount = DR["iToBnkAccount"].ToString(),
        //                       Amount = DR["dAmt"].ToString(),
        //                       EntryDate = DR["dtCrtdDt"].ToString(),
        //                       ParentId = DR["sFK_PrntId"].ToString(),
        //                       Status = DR["Status"].ToString(),
        //                       WalletRechargeId = DR["lPK_UsrWalltReqstId"].ToString(),
        //                       DocumentURL = DR["DocumentURL"].ToString(),
        //                       State = DR["States"].ToString(),
        //                       //FileType = DR["FileType"].ToString(),
        //                       //AmountWord = DR["AmountWord"].ToString(),
        //                   }
        //              );

        //                }
        //            }
        //            else
        //            {
        //                rechargetList.ResponseCode = ds.Tables[0].Rows[0]["Flag"].NulllToString();
        //                rechargetList.Messsage = ds.Tables[0].Rows[0]["Message"].NulllToString();
        //            }
        //        }
        //        else
        //        {
        //            rechargetList.ResponseCode = "0";
        //            rechargetList.Messsage = "Data Not Found";
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        ExceptionLogDL.SendExcepToDB(ex, 0, "ClientWalletRechargeDA:GetClientRequestDetails");
        //        rechargetList.ResponseCode = "5";
        //        rechargetList.Messsage = "Invalid Request! Please contact Support...";
        //    }
        //    return rechargetList;
        //}
        
        //public WalletRechargeReqList WRHistory(WalletRechargeHistory partyDet)
        //{
        //    WalletRechargeReqList rechargetList = new WalletRechargeReqList();
        //    try
        //    {
                
        //        SqlParameter[] param = new SqlParameter[4];
        //        param[0] = new SqlParameter("@Type", partyDet.Type);
        //        param[1] = new SqlParameter("@LoginId", partyDet.ParentId);
        //        param[2] = new SqlParameter("@FROMDATE", partyDet.FromDate);
        //        param[3] = new SqlParameter("@TODATE", partyDet.ToDate);
        //        DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_OPERATION_UserWalletRechargeRqst_SaveUpdate]", param);

        //        rechargetList.WalletRechargeLst = new List<ClientWalletRecharge>();
        //        if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
        //        {
        //            if (ds.Tables[0].Rows.Count > 0 && ds.Tables.Count > 1)
        //            {
        //                rechargetList.ResponseCode = ds.Tables[0].Rows[0]["Flag"].NulllToString();
        //                rechargetList.Messsage = ds.Tables[0].Rows[0]["Message"].NulllToString();
        //                foreach (DataRow DR in ds.Tables[1].Rows)
        //                {
        //                    rechargetList.WalletRechargeLst.Add(
        //                    new ClientWalletRecharge
        //                    {
        //                        PartyId = DR["sFK_PrtyCode"].ToString(),
        //                        PartyName = DR["FullName"].ToString(),
        //                        Mode = DR["Mode"].ToString(),
        //                        BankName = DR["sBnkName"].ToString(),
        //                        UTRNo = DR["sUtrNo"].ToString(),
        //                        UPI = DR["sUpi"].ToString(),
        //                        AccountNo = DR["sAccountNo"].ToString(),
        //                        ToBankAccount = DR["ToBankAccount"].ToString(),
        //                        Amount = DR["dAmt"].ToString(),
        //                        EntryDate = DR["dtCrtdDt"].ToString(),
        //                        ApproveRejectDate = DR["dtApprovRejDt"].ToString(),
        //                        Note = DR["sNote"].ToString(),
        //                        Status = DR["Status"].ToString(),
        //                        ParentId = DR["CreatedBy"].ToString(),
        //                        MobileNo = DR["sMobileNo"].ToString(),
        //                        //PANNumber = DR["PANNumber"].ToString(),
        //                        //GSTNumber = DR["GSTNumber"].ToString(),
        //                        State = DR["States"].ToString(),
        //                        OrderId = DR["sFK_OrdrId"].ToString(),
        //                        Message = DR["sApprovRejCmnt"].ToString(),
        //                    }
        //                 );

        //                }
        //            }
        //            else
        //            {
        //                rechargetList.ResponseCode = ds.Tables[0].Rows[0]["Flag"].NulllToString();
        //                rechargetList.Messsage = ds.Tables[0].Rows[0]["Message"].NulllToString();
        //            }
        //        }
        //        else
        //        {
        //            rechargetList.ResponseCode = "0";
        //            rechargetList.Messsage = "Data Not Found";
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        rechargetList.ResponseCode = "5";
        //        rechargetList.Messsage = "Invalid Request! Please contact Support...";
        //        ExceptionLogDL.SendExcepToDB(ex, 0, "ClientWalletRechargeDL:ClientWalletRequest");
        //        //ExceptionLog.SendExcepToDB(e, "NA", "ClientWalletRechargeDA:WRHistory", "Invalid Request! Please contact Support...");
        //    }
        //    return rechargetList;
        //}        

        //public WalletRechargeReqList GetWalletRechargeReceipt(WalletRechargeHistory vendDet)
        //{

        //    WalletRechargeReqList cliData = new WalletRechargeReqList();
        //    try
        //    {
        //        List<ClientWalletRecharge> returnModel = new List<ClientWalletRecharge>();
                
        //        SqlParameter[] param = new SqlParameter[2];
        //        param[0] = new SqlParameter("@Type", "GetReceiptbase64");
        //        param[1] = new SqlParameter("@UserWalletRequestID", Convert.ToInt32(vendDet.WalletRechargeId));

        //        DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_OPERATION_UserWalletRechargeRqst_SaveUpdate]", param);

        //        if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
        //        {
        //            if (ds.Tables[0].Rows.Count > 0 && ds.Tables.Count > 1)
        //            {
        //                cliData.ResponseCode = ds.Tables[0].Rows[0]["Flag"].NulllToString();
        //                cliData.Messsage = ds.Tables[0].Rows[0]["Message"].NulllToString();

        //                foreach (DataRow dr in ds.Tables[1].Rows)
        //                {
        //                    returnModel.Add(new ClientWalletRecharge()
        //                    {
        //                        WalletRechargeId = dr["UserWalletRequestID"].NulllToString(),
        //                        DocumentURL = dr["sUplodDcumntUrl"].NulllToString(),
        //                        //FileType = dr["FileType"].NulllToString()

        //                    });
        //                }
        //                cliData.WalletRechargeLst = returnModel;
        //            }
        //            else
        //            {
        //                cliData.ResponseCode = "0";
        //                cliData.Messsage = "No Data Found-Un!";
        //                cliData.WalletRechargeLst = null;
        //            }

        //        }
        //        else
        //        {
        //            cliData.ResponseCode = "0";
        //            cliData.Messsage = "No Data Found-Un!";
        //            cliData.WalletRechargeLst = null;
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        cliData.ResponseCode = "5";
        //        cliData.Messsage = "No Data Found-Un!";
        //        cliData.WalletRechargeLst = null;
        //        //ExceptionLog.SendExcepToDB(ex, "NA", "ClientWalletRechargeDA:GetWalletRechargeReceipt", ex.Message.ToString());
        //        return cliData;
        //    }
        //    return cliData;
        //}

        //#endregion
    }
}
