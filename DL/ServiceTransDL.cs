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
    public class ServiceTransDL
    {
        ResponseData objResponseData = new ResponseData();
        public static IConfiguration _configuration;
        string connectionString = DBCS.GetConnectionString();
        string BaseURL = DBCS.GetBaseURL();
        //Service Wise Transation
        public List<ServiceTransationBO> GetServicesTransation(int fk_SrvTyp, string PartyId)
        {
            List<ServiceTransationBO> objListdoc = new List<ServiceTransationBO>();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@fk_SrvTyp", fk_SrvTyp);
                param[1] = new SqlParameter("@PrntId", PartyId);
                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_Servicewise_Transctions]", param);
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    objListdoc = new List<ServiceTransationBO>();

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        ServiceTransationBO service = new ServiceTransationBO();
                        service.UserType = ds.Tables[0].Rows[i]["UserType"].NulllToString();
                        service.Partyname = ds.Tables[0].Rows[i]["Partyname"].NulllToString();
                        service.ParentName = ds.Tables[0].Rows[i]["ParentName"].NulllToString();
                        service.RefId = ds.Tables[0].Rows[i]["RefId"].NulllToString();
                        service.TxnId = ds.Tables[0].Rows[i]["TxnId"].NulllToString();
                        service.TrnsDate = ds.Tables[0].Rows[i]["TrnsDate"].NulllToString();
                        service.ServiceProvider = ds.Tables[0].Rows[i]["ServiceProvider"].NulllToString();
                        service.OperatorId = ds.Tables[0].Rows[i]["OperatorId"].NulllToString();
                        service.TransactionAmnt = ds.Tables[0].Rows[i]["TransactionAmnt"].NulllToString();
                        service.CommissonAmnt = ds.Tables[0].Rows[i]["CommissonAmnt"].NulllToString();
                        service.SoldPrice = ds.Tables[0].Rows[i]["SoldPrice"].NulllToString();
                        service.MobileNo = ds.Tables[0].Rows[i]["MobileNo"].NulllToString();
                        service.CardNo = ds.Tables[0].Rows[i]["CardNo"].NulllToString();
                        service.Latitude = ds.Tables[0].Rows[i]["Latitude"].NulllToString();
                        service.Longitude = ds.Tables[0].Rows[i]["Longitude"].NulllToString();
                        service.IPAddress = ds.Tables[0].Rows[i]["IPAddress"].NulllToString();
                        service.AccountNumber = ds.Tables[0].Rows[i]["AccountNumber"].NulllToString();
                        service.BankName = ds.Tables[0].Rows[i]["BankName"].NulllToString();
                        service.IFSCCode = ds.Tables[0].Rows[i]["IFSCCode"].NulllToString();
                        service.BranchName = ds.Tables[0].Rows[i]["BranchName"].NulllToString();
                        objListdoc.Add(service);

                    }
                }
                else
                {
                    objListdoc = new List<ServiceTransationBO>();
                }
            }
            catch (Exception e)
            {
                objListdoc = new List<ServiceTransationBO>();
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AllReportDL / Function : GetPartyDetail");
            }
            return objListdoc;
        }
        //Servicer wise partner Count
        //public List<ServiceWisePartCountBO> GetSerwisePartnerCount(string PartyId)
        //{
        //    List<ServiceWisePartCountBO> objListdoc = new List<ServiceWisePartCountBO>();
        //    try
        //    {
        //        SqlParameter[] param = new SqlParameter[1];
        //        param[0] = new SqlParameter("@PrntId", PartyId);
        //        DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_USerwise_Partner_Count]", param);
        //        if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
        //        {
        //            objListdoc = new List<ServiceWisePartCountBO>();


        //            ServiceWisePartCountBO cService = new ServiceWisePartCountBO();
        //            cService.WhiteLabel = ds.Tables[0].Rows[0]["WhiteLabel"].NulllToInt();
        //            cService.Stockist = ds.Tables[1].Rows[0]["Stockist"].NulllToInt();
        //            cService.Distributer = ds.Tables[2].Rows[0]["Distributer"].NulllToInt();
        //            cService.Retailer = ds.Tables[3].Rows[0]["Retailer"].NulllToInt();
        //            objListdoc.Add(cService);

        //        }
        //        else
        //        {
        //            objListdoc = null;
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        objListdoc = null;
        //        ExceptionLogDL.SendExcepToDB(e, 0, "Class : AllReportDL / Function : GetUSerwisePartnerCountDetail");
        //    }
        //    return objListdoc;
        //}
        //User Profile Count
        public List<UserProfileDetailsBO> GetUserProfileDetails(string PartyId)
        {
            List<UserProfileDetailsBO> objListdoc = new List<UserProfileDetailsBO>();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@PrntId", PartyId);
                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_User_Profile_Report]", param);
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    objListdoc = new List<UserProfileDetailsBO>();
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        UserProfileDetailsBO cService = new UserProfileDetailsBO();
                        cService.Name = ds.Tables[0].Rows[i]["Name"].NulllToString();
                        cService.sEmailId = ds.Tables[0].Rows[i]["sEmailId"].NulllToString();
                        cService.sMobileNo = ds.Tables[0].Rows[i]["sMobileNo"].NulllToString();
                        cService.GSTNumber = ds.Tables[0].Rows[i]["GSTNumber"].NulllToString();
                        cService.PanNumber = ds.Tables[0].Rows[i]["PanNumber"].NulllToString();
                        cService.NameOnPancard = ds.Tables[0].Rows[i]["NameOnPancard"].NulllToString();
                        cService.CompanyTypeNeedtocorrect = ds.Tables[0].Rows[i]["CompanyTypeNeedtocorrect"].NulllToString();
                        cService.Address = ds.Tables[0].Rows[i]["Address"].NulllToString();
                        cService.CompanyName = ds.Tables[0].Rows[i]["CompanyName"].NulllToString();
                        cService.CmpnyMobileNo = ds.Tables[0].Rows[i]["CmpnyMobileNo"].NulllToString();
                        cService.CmpnyEmailId = ds.Tables[0].Rows[i]["CmpnyEmailId"].NulllToString();
                        cService.CompanyAddress = ds.Tables[0].Rows[i]["CompanyAddress"].NulllToString();
                        cService.PanVerified = ds.Tables[0].Rows[i]["PanVerified"].NulllToString();
                        cService.AdharVerified = ds.Tables[0].Rows[i]["AdharVerified"].NulllToString();
                        cService.EmailVerified = ds.Tables[0].Rows[i]["EmailVerified"].NulllToString();
                        cService.MobileVerified = ds.Tables[0].Rows[i]["MobileVerified"].NulllToString();
                        objListdoc.Add(cService);
                    }

                }
                else
                {
                    objListdoc = null;
                }
            }
            catch (Exception e)
            {
                objListdoc = null;
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AllReportDL / Function : GetUserProfileDetails");
            }
            return objListdoc;
        }

        //Pertner Wise View Statement
        public List<PartwiseStatementBO> PartwiseViewStatementDetails(string PartyId)
        {
            List<PartwiseStatementBO> objListdoc = new List<PartwiseStatementBO>();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@PartyId", PartyId);
                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_Partwise_View_Statement]", param);
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    objListdoc = new List<PartwiseStatementBO>();
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        PartwiseStatementBO cService = new PartwiseStatementBO();
                        cService.PartyName = ds.Tables[0].Rows[i]["PartyName"].NulllToString();
                        cService.TxnId = ds.Tables[0].Rows[i]["TxnId"].NulllToString();
                        cService.TxnDate = ds.Tables[0].Rows[i]["TxnDate"].NulllToString();
                        cService.OpAmnt = ds.Tables[0].Rows[i]["OpAmnt"].NulllToString();
                        cService.CreditAmnt = ds.Tables[0].Rows[i]["CreditAmnt"].NulllToString();
                        cService.DebitAmnt = ds.Tables[0].Rows[i]["DebitAmnt"].NulllToString();
                        cService.ClosingAmnt = ds.Tables[0].Rows[i]["ClosingAmnt"].NulllToString();
                        cService.Narration = ds.Tables[0].Rows[i]["Narration"].NulllToString();
                        objListdoc.Add(cService);
                    }

                }
                else
                {
                    objListdoc = null;
                }
            }
            catch (Exception e)
            {
                objListdoc = null;
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AllReportDL / Function : PartwiseViewStatementDetails");
            }
            return objListdoc;
        }

        //USP_User_Partywise_Profile_Report--------
        public List<UserPartywiseProfileBO> UserPartywiseProfileReport(string PartyId)
        {
            List<UserPartywiseProfileBO> objListdoc = new List<UserPartywiseProfileBO>();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@PrntId", PartyId);
                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_User_Partywise_Profile_Report]", param);
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    objListdoc = new List<UserPartywiseProfileBO>();
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        UserPartywiseProfileBO cService = new UserPartywiseProfileBO();
                        cService.Name = ds.Tables[0].Rows[i]["Name"].NulllToString();
                        cService.sEmailId = ds.Tables[0].Rows[i]["sEmailId"].NulllToString();
                        cService.sMobileNo = ds.Tables[0].Rows[i]["sMobileNo"].NulllToString();
                        cService.GSTNumber = ds.Tables[0].Rows[i]["GSTNumber"].NulllToString();
                        cService.PanNumber = ds.Tables[0].Rows[i]["PanNumber"].NulllToString();
                        cService.NameOnPancard = ds.Tables[0].Rows[i]["NameOnPancard"].NulllToString();
                        cService.CompanyTypeNeedtocorrect = ds.Tables[0].Rows[i]["CompanyType Need to correct"].NulllToString();
                        cService.Address = ds.Tables[0].Rows[i]["Address"].NulllToString();
                        cService.CompanyName = ds.Tables[0].Rows[i]["Company Name"].NulllToString();
                        cService.CmpnyMobileNo = ds.Tables[0].Rows[i]["Cmpny Mobile No"].NulllToString();
                        cService.CmpnyEmailId = ds.Tables[0].Rows[i]["Cmpny Email Id"].NulllToString();
                        cService.CompanyAddress = ds.Tables[0].Rows[i]["Company Address"].NulllToString();
                        cService.PanVerified = ds.Tables[0].Rows[i]["Pan Verified"].NulllToString();
                        cService.AdharVerified = ds.Tables[0].Rows[i]["Adhar Verified"].NulllToString();
                        cService.EmailVerified = ds.Tables[0].Rows[i]["Email Verified"].NulllToString();
                        cService.MobileVerified = ds.Tables[0].Rows[i]["Mobile Verified"].NulllToString();
                        objListdoc.Add(cService);
                    }

                }
                else
                {
                    objListdoc = null;
                }
            }
            catch (Exception e)
            {
                objListdoc = null;
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AllReportDL / Function : UserPartywiseProfileReport");
            }
            return objListdoc;
        }

        //USP_DashBoard_UserTypewise_Profit Report--------
        public List<DashBoardUserTypewiseProfitBO> GetDashBoardUserTypewiseProfit(string PartyId)
        {
            List<DashBoardUserTypewiseProfitBO> objListdoc = new List<DashBoardUserTypewiseProfitBO>();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@PrntId", PartyId);
                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_DashBoard_UserTypewise_Profit]", param);
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    objListdoc = new List<DashBoardUserTypewiseProfitBO>();
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        DashBoardUserTypewiseProfitBO cService = new DashBoardUserTypewiseProfitBO();
                        cService.labels = ds.Tables[0].Rows[i]["labels"].NulllToString();
                        cService.series = ds.Tables[0].Rows[i]["series"].NulllToDecimal();
                        cService.Profit = ds.Tables[0].Rows[i]["Profit"].NulllToDecimal();
                        objListdoc.Add(cService);
                    }

                }
                else
                {
                    objListdoc = null;
                }
            }
            catch (Exception e)
            {
                objListdoc = null;
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AllReportDL / Function : GetDashBoardUserTypewiseProfit");
            }
            return objListdoc;
        }
        ////Wallet Amount Show in Dashboard
        //public List<WalletAMTBO> GetWalletAMT(string PartyId)
        //{
        //    List<WalletAMTBO> objListdoc = new List<WalletAMTBO>();
        //    try
        //    {
        //        SqlParameter[] param = new SqlParameter[1];
        //        param[0] = new SqlParameter("@PartyId", PartyId);
        //        DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_ADMIN_WalletBalance]", param);
        //        if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
        //        {
        //            objListdoc = new List<WalletAMTBO>();
        //            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //            {
        //                WalletAMTBO cService = new WalletAMTBO();
        //                cService.CIW = ds.Tables[0].Rows[i]["CIW"].NulllToDecimal();
        //                cService.COW = ds.Tables[0].Rows[i]["COW"].NulllToDecimal();
        //                cService.PWA = ds.Tables[0].Rows[i]["PWA"].NulllToDecimal();
        //                cService.UWA = ds.Tables[0].Rows[i]["UWA"].NulllToDecimal();
        //                objListdoc.Add(cService);
        //            }

        //        }
        //        else
        //        {
        //            objListdoc = null;
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        objListdoc = null;
        //        ExceptionLogDL.SendExcepToDB(e, 0, "Class : AllReportDL / Function : GetDashBoardUserTypewiseProfit");
        //    }
        //    return objListdoc;
        //}
        ////Pending transaction Show in Dashboard
        //public List<WalletAMTBO> GetDashboardPendingTransactions(string PartyId)
        //{
        //    List<WalletAMTBO> objListdoc = new List<WalletAMTBO>();
        //    try
        //    {
        //        SqlParameter[] param = new SqlParameter[1];
        //        param[0] = new SqlParameter("@PrtyId", PartyId);
        //        DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_Dashboard_Pending_Transactions]", param);
        //        if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
        //        {
        //            objListdoc = new List<WalletAMTBO>();
        //            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //            {
        //                WalletAMTBO cService = new WalletAMTBO();
        //                cService.PartyName = ds.Tables[0].Rows[i]["Party Name"].NulllToString();
        //                cService.MobileNo = ds.Tables[0].Rows[i]["sMobileNo"].NulllToString();
        //                cService.TxnDate = ds.Tables[0].Rows[i]["Txn Date"].NulllToString();
        //                cService.TxnId = ds.Tables[0].Rows[i]["TxnId"].NulllToString();
        //                cService.Amount = ds.Tables[0].Rows[i]["Amount"].NulllToString();
        //                cService.PendingSinceInHr = ds.Tables[0].Rows[i]["Pending Since(In Hr)"].NulllToString();
        //                cService.SumAmount = ds.Tables[1].Rows[0]["Sum Amount"].NulllToString();
        //                objListdoc.Add(cService);
        //            }

        //        }
        //        else
        //        {
        //            objListdoc = null;
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        objListdoc = null;
        //        ExceptionLogDL.SendExcepToDB(e, 0, "Class : AllReportDL / Function : GetDashBoardUserTypewiseProfit");
        //    }
        //    return objListdoc;
        //}

        ////Get Dashboard Top Business Makers
        //public List<WalletAMTBO> GetDashboardTopBusinessMakers(string PartyId)
        //{
        //    List<WalletAMTBO> objListdoc = new List<WalletAMTBO>();
        //    try
        //    {
        //        SqlParameter[] param = new SqlParameter[1];
        //        param[0] = new SqlParameter("@PrtyId", PartyId);
        //        DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_Dashboard_Top_BusinessMakers]", param);
        //        if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
        //        {
        //            objListdoc = new List<WalletAMTBO>();
        //            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //            {
        //                WalletAMTBO cService = new WalletAMTBO();
        //                cService.PartyName = ds.Tables[0].Rows[i]["Party Name"].NulllToString();
        //                cService.TxnAmnt = ds.Tables[0].Rows[i]["TxnAmnt"].NulllToDecimal();
        //                objListdoc.Add(cService);
        //            }

        //        }
        //        else
        //        {
        //            objListdoc = null;
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        objListdoc = null;
        //        ExceptionLogDL.SendExcepToDB(e, 0, "Class : AllReportDL / Function : GetDashBoardUserTypewiseProfit");
        //    }
        //    return objListdoc;
        //}

        ////Get Dashboard StateWise Collection
        //public List<WalletAMTBO> GetDashboardStateWiseCollection(string PartyId)
        //{
        //    List<WalletAMTBO> objListdoc = new List<WalletAMTBO>();
        //    try
        //    {
        //        SqlParameter[] param = new SqlParameter[1];
        //        param[0] = new SqlParameter("@PrtyId", PartyId);
        //        DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_Dashboard_StateWise_Collection]", param);
        //        if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
        //        {
        //            objListdoc = new List<WalletAMTBO>();
        //            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //            {
        //                WalletAMTBO cService = new WalletAMTBO();
        //                cService.SName = ds.Tables[0].Rows[i]["sName"].NulllToString();
        //                cService.TxnAmnt = ds.Tables[0].Rows[i]["TxnAmnt"].NulllToDecimal();
        //                cService.StateName = ds.Tables[0].Rows[i]["StateName"].NulllToString();
        //                objListdoc.Add(cService);
        //            }

        //        }
        //        else
        //        {
        //            objListdoc = null;
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        objListdoc = null;
        //        ExceptionLogDL.SendExcepToDB(e, 0, "Class : AllReportDL / Function : GetDashBoardUserTypewiseProfit");
        //    }
        //    return objListdoc;
        //}

        ////Get Dashboard Target vs Actual
        //public List<WalletAMTBO> GetDashboardTargetvsActual()
        //{
        //    List<WalletAMTBO> objListdoc = new List<WalletAMTBO>();
        //    try
        //    {
        //        //SqlParameter[] param = new SqlParameter[];
        //        // param[0] = new SqlParameter("@PrtyId", PartyId);
        //        DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_Dashboard_TargetvsActual]");
        //        if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
        //        {
        //            objListdoc = new List<WalletAMTBO>();
        //            for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
        //            {
        //                WalletAMTBO cService = new WalletAMTBO();
        //                cService.AcheiveAmnt = ds.Tables[0].Rows[i]["Acheive Amnt"].NulllToDecimal();
        //                cService.TargetAmount = ds.Tables[0].Rows[i]["Target Amount"].NulllToDecimal();
        //                cService.TxnAmnt = ds.Tables[0].Rows[i]["Txn Amnt"].NulllToDecimal();
        //                cService.ServiceName = ds.Tables[1].Rows[i]["Service Name"].NulllToString();
        //                cService.TargetAmount1 = ds.Tables[1].Rows[i]["Target Amount"].NulllToDecimal();
        //                cService.AcheiveAmnt = ds.Tables[1].Rows[i]["Acheive Amnt"].NulllToDecimal();
                       
                        


        //                objListdoc.Add(cService);
        //            }

        //        }
        //        else
        //        {
        //            objListdoc = null;
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        objListdoc = null;
        //        ExceptionLogDL.SendExcepToDB(e, 0, "Class : AllReportDL / Function : GetDashBoardUserTypewiseProfit");
        //    }
        //    return objListdoc;
        //}

        ////Get Dashboard User Wise Partner Count
        //public List<WalletAMTBO> GetDashboardUserwisePartnerCount(string PartyId)
        //{
        //    List<WalletAMTBO> objListdoc = new List<WalletAMTBO>();
        //    try
        //    {
        //        SqlParameter[] param = new SqlParameter[1];
        //        param[0] = new SqlParameter("@PrntId", PartyId);
        //        DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_Dashboard_Userwise_Partner_Count]", param);
        //        if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
        //        {
        //            objListdoc = new List<WalletAMTBO>();
        //            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //            {
        //                WalletAMTBO cService = new WalletAMTBO();
        //                cService.WhiteLabel = ds.Tables[0].Rows[i]["WhiteLabel"].NulllToInt(); 
        //                cService.Stockist = ds.Tables[1].Rows[i]["Stockist"].NulllToInt();
        //                cService.Distributer = ds.Tables[2].Rows[i]["Distributer"].NulllToInt(); 
        //                cService.Retailer = ds.Tables[3].Rows[i]["Retailer"].NulllToInt();
        //                cService.TotalCount = ds.Tables[4].Rows[i]["TotalCount"].NulllToInt();
        //                objListdoc.Add(cService);
        //            }

        //        }
        //        else
        //        {
        //            objListdoc = null;
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        objListdoc = null;
        //        ExceptionLogDL.SendExcepToDB(e, 0, "Class : AllReportDL / Function : GetDashboardUserwisePartnerCount");
        //    }
        //    return objListdoc;
        //}
        ////Get DashBoard Service Wise Income
        //public List<WalletAMTBO> GetDashBoardServiceWiseIncome()
        //{
        //    List<WalletAMTBO> objListdoc = new List<WalletAMTBO>();
        //    try
        //    {
        //        //SqlParameter[] param = new SqlParameter[0];
        //        //param[0] = new SqlParameter();
        //        DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_DashBoard_ServiceWise_Income]");
        //        if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
        //        {
        //            objListdoc = new List<WalletAMTBO>();
        //            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //            {
        //                WalletAMTBO cService = new WalletAMTBO();
        //                cService.iPk_CatId = ds.Tables[0].Rows[i]["iPk_CatId"].NulllToInt(); 
        //                cService.CatDesc = ds.Tables[0].Rows[i]["CatDesc"].NulllToString();
        //                cService.TxnAmnt = ds.Tables[0].Rows[i]["TxnAmnt"].NulllToDecimal(); 
        //                cService.Profit = ds.Tables[0].Rows[i]["Profit"].NulllToDecimal();                        
        //                objListdoc.Add(cService);
        //            }

        //        }
        //        else
        //        {
        //            objListdoc = null;
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        objListdoc = null;
        //        ExceptionLogDL.SendExcepToDB(e, 0, "Class : AllReportDL / Function : GetDashBoardServiceWiseIncome");
        //    }
        //    return objListdoc;
        //}





    }
}

