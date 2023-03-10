using BO;
using BO.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Text;
using static BO.Models.Partial;
using static System.Exception;

namespace DL
{

    public class CommissionMasterDL
    {
        ResponseData objResponseData = new ResponseData();
        public static IConfiguration _configuration;
        string connectionString = DBCS.GetConnectionString();
        //public ResponseData InsertServiceProvider(Serviceprovider obj)
        //{
        //    try
        //    {
                
        //        SqlParameter[] param = new SqlParameter[11];
        //        param[0] = new SqlParameter("@ServiceProviderMasterId", obj.ServiceProviderMasterId);
        //        param[1] = new SqlParameter("@ServiceType", obj.ServiceType);
        //        param[2] = new SqlParameter("@ServiceProviderId", obj.ServiceProviderId);
        //        param[3] = new SqlParameter("@ValidationUrl", obj.ValidationUrl);
        //        param[4] = new SqlParameter("@PaymentUrl", obj.PaymentUrl);
        //        param[5] = new SqlParameter("@CheckUrl", obj.CheckUrl);
        //        param[6] = new SqlParameter("@Priority", obj.priority);
        //        param[7] = new SqlParameter("@IsWebActive", obj.IsWebActive);
        //        param[8] = new SqlParameter("@IsMobileActive", obj.IsMobileActive);
        //        param[9] = new SqlParameter("@Status", obj.Status);
        //        param[10] = new SqlParameter("@PartyId", obj.PartyId);


        //        DataTable DT = BaseFunction.FillDataTable("[dbo].[USP_MASTER_VendorsDetail_Save]", param);
        //        if (DT != null)
        //        {
        //            if (DT.Rows.Count > 0)
        //            {
        //                objResponseData.statusCode = Convert.ToInt32(DT.Rows[0]["StatusCode"]);
        //                objResponseData.Message = DT.Rows[0]["Message"].ToString();

        //            }
        //        }
        //        else
        //        {
        //            objResponseData.statusCode = 0;
        //            objResponseData.Message = "Failed";
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        objResponseData.statusCode = 0;
        //        objResponseData.Message = "Failed";
        //        ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : InsertSubMenuMaster");
        //    }
        //    return objResponseData;
        //}

        //public List<Serviceprovider> GetServiceProvider(int Id)
        //{
        //    List<Serviceprovider> Servicelist = new List<Serviceprovider>();
        //    try
        //    {
                
        //        SqlParameter[] param = null;
        //        if (Id != 0)
        //        {
        //            param = new SqlParameter[1];
        //            param[0] = new SqlParameter("@Id", Id);
        //        }

        //        DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_MASTER_VendorsDetail_View]", param);

        //        if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
        //        {
        //            Servicelist = new List<Serviceprovider>();

        //            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //            {
        //                Serviceprovider obj = new Serviceprovider();

        //                obj.ServiceProviderMasterId = ds.Tables[0].Rows[i]["iPK_SrvcPrvdId"].NulllToInt();
        //                obj.ServiceProviderName = ds.Tables[0].Rows[i]["ServiceProviderName"].NulllToString();
        //                obj.ValidationUrl = ds.Tables[0].Rows[i]["sVldtnUrl"].NulllToString();
        //                obj.PaymentUrl = ds.Tables[0].Rows[i]["sPymntUrl"].NulllToString();
        //                obj.CheckUrl = ds.Tables[0].Rows[i]["sChkUrl"].NulllToString();
        //                obj.ServiceName = ds.Tables[0].Rows[i]["ServiceName"].NulllToString();
        //                obj.Status = ds.Tables[0].Rows[i]["iStts"].NulllToInt();
        //                obj.IsMobileActive = ds.Tables[0].Rows[i]["iMblActv"].NulllToInt();
        //                obj.IsWebActive = ds.Tables[0].Rows[i]["iIsWebActv"].NulllToInt();
        //                obj.ServiceType = ds.Tables[0].Rows[i]["iSrvcTyp"].NulllToInt();
        //                obj.priority = ds.Tables[0].Rows[i]["iPriority"].NulllToInt();
        //                obj.ServiceProviderId = ds.Tables[0].Rows[i]["iFK_SrvcPrvdId"].NulllToInt();
        //                Servicelist.Add(obj);

        //            }

        //        }
        //        else
        //        {
        //            Servicelist = null;
        //        }

        //    }
        //    catch (Exception e)
        //    {
        //        Servicelist = null;
        //        ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetServiceProvider");
        //    }
        //    return Servicelist;
        //}

        //public ResponseData InsertServiceProviderrate(ServiceProviderRateconfiguration obj)
        //{
        //    try
        //    {
                
        //        SqlParameter[] param = new SqlParameter[9];
        //        param[0] = new SqlParameter("@CommissionType", obj.CommissionType);
        //        param[1] = new SqlParameter("@CommissionRate", obj.CommissionRate);
        //        param[2] = new SqlParameter("@ServiceProviderId", obj.ServiceProviderId);
        //        param[3] = new SqlParameter("@OperaterId ", obj.OperaterId);
        //        param[4] = new SqlParameter("@FromDate", obj.FromDate);
        //        param[5] = new SqlParameter("@ToDate", obj.ToDate);
        //        param[6] = new SqlParameter("@Status", obj.Status);
        //        param[7] = new SqlParameter("@PartyId", obj.PartyId);
        //        param[8] = new SqlParameter("@CommissionApplicableId", obj.CommissionApplicableId);
        //        DataTable DT = BaseFunction.FillDataTable("[dbo].[USP_MASTER_VendorCommissionRates_Save]", param);
        //        if (DT != null)
        //        {
        //            if (DT.Rows.Count > 0)
        //            {
        //                objResponseData.statusCode = Convert.ToInt32(DT.Rows[0]["StatusCode"]);
        //                objResponseData.Message = DT.Rows[0]["Message"].ToString();

        //            }
        //        }
        //        else
        //        {
        //            objResponseData.statusCode = 0;
        //            objResponseData.Message = "Failed";
        //        }



        //    }
        //    catch (Exception e)
        //    {
        //        objResponseData.statusCode = 0;
        //        objResponseData.Message = "Failed";
        //        ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : InsertSubMenuMaster");
        //    }
        //    return objResponseData;
        //}

        //public List<ServiceProviderRateconfiguration> GetServiceProviderRate(int Id)
        //{
        //    List<ServiceProviderRateconfiguration> ServiceRatelist = new List<ServiceProviderRateconfiguration>();
        //    try
        //    {
                
        //        SqlParameter[] param = new SqlParameter[1];
        //        param[0] = new SqlParameter("@Id", Id);
        //        DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_MASTER_VendorCommissionRates_View]", param);

        //        if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
        //        {
        //            ServiceRatelist = new List<ServiceProviderRateconfiguration>();

        //            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //            {
        //                ServiceProviderRateconfiguration obj = new ServiceProviderRateconfiguration();
        //                obj.ServiceProviderRateConfigurationId = ds.Tables[0].Rows[i]["iPK_SrvcRtConfig"].NulllToInt();
        //                obj.CommissionType = ds.Tables[0].Rows[i]["iCmssnTyp"].NulllToInt();
        //                obj.CommissionRate = ds.Tables[0].Rows[i]["dCmmsnRt"].NulllToDecimal();
        //                obj.FromDate = ((DateTime)ds.Tables[0].Rows[i]["dtFrmDt"]).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture).NulllToString();
        //                obj.ToDate = ((DateTime)ds.Tables[0].Rows[i]["dtToDt"]).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture).NulllToString();
        //                obj.TypeName = ds.Tables[0].Rows[i]["TypeName"].NulllToString();
        //                obj.Status = ds.Tables[0].Rows[i]["iStts"].NulllToInt();
        //                obj.OperaterId = ds.Tables[0].Rows[i]["iFK_OprtId"].NulllToInt();
        //                obj.OperaterName = ds.Tables[0].Rows[i]["OperaterName"].NulllToString();
        //                ServiceRatelist.Add(obj);
        //            }

        //        }
        //        else
        //        {
        //            ServiceRatelist = null;
        //        }

        //    }
        //    catch (Exception e)
        //    {
        //        ServiceRatelist = null;
        //        ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetServiceProviderRate");
        //    }
        //    return ServiceRatelist;
        //}

        //public ResponseData InsertCommissionInformation(tbl_CommissionMaster obj)
        //{
        //    try
        //    {
                
        //        SqlParameter[] param = new SqlParameter[15];
        //        param[0] = new SqlParameter("@CommissionMasterId", obj.CommissionMasterId.NulllToInt());
        //        param[1] = new SqlParameter("@ServiceTypeId", obj.ServiceTypeId.NulllToInt());
        //        param[2] = new SqlParameter("@ChargeType", obj.ChargeType.NulllToInt());
        //        param[3] = new SqlParameter("@Commissionrang", obj.Commissionrang.NulllToInt());
        //        param[4] = new SqlParameter("@CustomerFeeType", obj.CustomerFeeType.NulllToInt());
        //        param[5] = new SqlParameter("@IsCustomerFeesApplicable", obj.IsCustomerFeesApplicable.NulllToInt());
        //        param[6] = new SqlParameter("@CustomerFeeValue", obj.CustomerFeeValue.NulllToDecimal());
        //        param[7] = new SqlParameter("@ChargeValue", obj.ChargeValue.NulllToDecimal());
        //        param[8] = new SqlParameter("@MinMaxApplicableOn", obj.MinMaxApplicableOn.NulllToInt());
        //        param[9] = new SqlParameter("@MinMaxValue", obj.MinMaxValue.NulllToInt());
        //        param[10] = new SqlParameter("@MinMaxApplicablevalue", obj.MinMaxApplicablevalue.NulllToDecimal());
        //        param[11] = new SqlParameter("@PartyId", obj.PartyId.NulllToString());
        //        param[12] = new SqlParameter("@UserType", obj.UserType.NulllToInt());
        //        param[13] = new SqlParameter("@Isdefault", obj.Isdefault.NulllToInt());
        //        param[14] = new SqlParameter("@IsdefaultpartyId", obj.IsdefaultPartyId.NulllToString());
        //        DataTable DT = BaseFunction.FillDataTable("[dbo].[USP_ADMIN_SetPartnersCommissionRates_Save]", param);
        //        if (DT != null)
        //        {
        //            if (DT.Rows.Count > 0)
        //            {
        //                objResponseData.statusCode = Convert.ToInt32(DT.Rows[0]["StatusCode"]);
        //                objResponseData.Message = DT.Rows[0]["Message"].ToString();

        //            }
        //        }
        //        else
        //        {
        //            objResponseData.statusCode = 0;
        //            objResponseData.Message = "Failed";
        //        }

        //    }
        //    catch (Exception e)
        //    {
        //        objResponseData.statusCode = 0;
        //        objResponseData.Message = "Failed";
        //        ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : InsertComission");
        //    }
        //    return objResponseData;
        //}

        public ResponseData InsertUserRechargeData(int OperaterId, int UserType, int ServiceId, string PartyId, int Id, string IsdefaultPartyId)
        {
            try
            {
                
                SqlParameter[] param = new SqlParameter[6];
                param[0] = new SqlParameter("@ServiceProviderId", OperaterId);
                param[1] = new SqlParameter("@UserType", UserType);
                param[2] = new SqlParameter("@ServiceTypeId", ServiceId);
                param[3] = new SqlParameter("@PartyId", PartyId);
                param[4] = new SqlParameter("@CommissionMasterId", Id);
                param[5] = new SqlParameter("@IsdefaultPartyId", IsdefaultPartyId);
                DataTable DT = BaseFunction.FillDataTable("[dbo].[USP_ADMIN_ChildPartnersCommissionRates_Save]", param);
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
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : InsertComission");
            }
            return objResponseData;
        }
        public ResponseData InsertRechargeData(int OperaterId, int UserType, int ServiceId, string PartyId, int Id, string IsdefaultPartyId)
        {
            try
            {
                
                SqlParameter[] param = new SqlParameter[6];
                param[0] = new SqlParameter("@ServiceProviderId", OperaterId);
                param[1] = new SqlParameter("@UserType", UserType);
                param[2] = new SqlParameter("@ServiceTypeId", ServiceId);
                param[3] = new SqlParameter("@PartyId", PartyId);
                param[4] = new SqlParameter("@CommissionMasterId", Id);
                param[5] = new SqlParameter("@IsdefaultPartyId", IsdefaultPartyId);
                DataTable DT = BaseFunction.FillDataTable("[dbo].[USP_ADMIN_DirectPartnersCommissionRates_Save]", param);
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
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : InsertComission");
            }
            return objResponseData;
        }
        //public List<tbl_CommissionMaster> GetCommissionMaster(int Id, string PartyId = null, int SpecialId = 1)
        //{
        //    List<tbl_CommissionMaster> Comissionlist = new List<tbl_CommissionMaster>();
        //    try
        //    {
                
        //        SqlParameter[] param = null;
        //        if (Id > 0)
        //        {
        //            param = new SqlParameter[2];
        //            param[0] = new SqlParameter("@Id", Id);
                   
        //        }
                
        //        if (SpecialId < 1)
        //        {
        //            param = new SqlParameter[2];
        //            param[0] = new SqlParameter("@PartyId", PartyId);
        //            param[1] = new SqlParameter("@SpecialId", SpecialId);
        //        }
        //        DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_ADMIN_CommissionListPage_View]", param);
        //        if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
        //        {
        //            Comissionlist = new List<tbl_CommissionMaster>();

        //            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //            {
        //                tbl_CommissionMaster obj = new tbl_CommissionMaster();
        //                obj.CommissionMasterId = ds.Tables[0].Rows[i]["iPK_CmssnId"].NulllToInt();
        //                obj.ServiceTypeId = ds.Tables[0].Rows[i]["iFK_SrvcTypId"].NulllToInt();
        //                obj.ChargeType = ds.Tables[0].Rows[i]["iChrTyp"].NulllToInt();
        //                obj.Commissionrang = ds.Tables[0].Rows[i]["iCmmssnRng"].NulllToInt();
        //                obj.IsCustomerFeesApplicable = ds.Tables[0].Rows[i]["sCustFsOn"].NulllToInt();
        //                obj.CustomerFeeType = ds.Tables[0].Rows[i]["bCustFsTyp"].NulllToInt();
        //                obj.CustomerFeeValue = ds.Tables[0].Rows[i]["dCustFsVal"].NulllToDecimal();
        //                obj.ChargeValue = ds.Tables[0].Rows[i]["dChrgVal"].NulllToDecimal();
        //                obj.UserType = ds.Tables[0].Rows[i]["iUsrTyp"].NulllToInt();
        //                obj.MinMaxApplicableOn = ds.Tables[0].Rows[i]["bMinMaxAplcbl"].NulllToInt();
        //                obj.MinMaxValue = ds.Tables[0].Rows[i]["dMinMaxVal"].NulllToInt();
        //                obj.MinMaxApplicablevalue = ds.Tables[0].Rows[i]["iMinMaxAplcblVal"].NulllToDecimal();
        //                obj.UserName = ds.Tables[0].Rows[i]["UserName"].NulllToString();
        //                obj.ServiceName = ds.Tables[0].Rows[i]["ServiceName"].NulllToString();
        //                obj.Isdefault = ds.Tables[0].Rows[i]["bIsDflt"].NulllToInt();
        //                obj.IsdefaultPartyName = ds.Tables[0].Rows[i]["IsdefaultPartyName"].NulllToString();
        //                obj.Status = ds.Tables[0].Rows[i]["iStts"].NulllToInt();
        //                obj.IsdefaultPartyId = ds.Tables[0].Rows[i]["sFK_DfltPrtyCode"].NulllToString();
        //                Comissionlist.Add(obj);
        //            }
        //        }
        //        else
        //        {
        //            Comissionlist = null;
        //        }
        //        if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
        //        {
        //            Comissionlist = new List<tbl_CommissionMaster>();

        //            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //            {
        //                tbl_CommissionMaster obj = new tbl_CommissionMaster();
        //                obj.CommissionMasterId = ds.Tables[0].Rows[i]["iPK_CmssnId"].NulllToInt();
        //                obj.ServiceTypeId = ds.Tables[0].Rows[i]["iFK_SrvcTypId"].NulllToInt();
        //                obj.ChargeType = ds.Tables[0].Rows[i]["iChrTyp"].NulllToInt();
        //                obj.Commissionrang = ds.Tables[0].Rows[i]["iCmmssnRng"].NulllToInt();
        //                obj.IsCustomerFeesApplicable = ds.Tables[0].Rows[i]["sCustFsOn"].NulllToInt();
        //                obj.CustomerFeeType = ds.Tables[0].Rows[i]["bCustFsTyp"].NulllToInt();
        //                obj.CustomerFeeValue = ds.Tables[0].Rows[i]["dCustFsVal"].NulllToDecimal();
        //                obj.ChargeValue = ds.Tables[0].Rows[i]["dChrgVal"].NulllToDecimal();
        //                obj.UserType = ds.Tables[0].Rows[i]["iUsrTyp"].NulllToInt();
        //                obj.MinMaxApplicableOn = ds.Tables[0].Rows[i]["bMinMaxAplcbl"].NulllToInt();
        //                obj.MinMaxValue = ds.Tables[0].Rows[i]["dMinMaxVal"].NulllToInt();
        //                obj.MinMaxApplicablevalue = ds.Tables[0].Rows[i]["iMinMaxAplcblVal"].NulllToDecimal();
        //                obj.UserName = ds.Tables[0].Rows[i]["UserName"].NulllToString();
        //                obj.ServiceName = ds.Tables[0].Rows[i]["ServiceName"].NulllToString();
        //                obj.Isdefault = ds.Tables[0].Rows[i]["bIsDflt"].NulllToInt();
        //                obj.IsdefaultPartyName = ds.Tables[0].Rows[i]["IsdefaultPartyName"].NulllToString();
        //                obj.Status = ds.Tables[0].Rows[i]["iStts"].NulllToInt();
        //                obj.IsdefaultPartyId = ds.Tables[0].Rows[i]["sFK_DfltPrtyCode"].NulllToString();
        //                Comissionlist.Add(obj);
        //            }

        //        }
        //        else
        //        {
        //            Comissionlist = null;
        //        }

        //    }
        //    catch (Exception e)
        //    {
        //        Comissionlist = null;
        //        ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetServiceProviderRate");
        //    }
        //    return Comissionlist;
        //}

        //public List<UserCommission> GenerateRechargesUserWise(int OperaterId, int UserType, int OperaterNameEnum, int ServiceProviderEnum, int ServiceId = 0, string PartyId = null, int Id = 0)
        //{
        //    List<UserCommission> Rechargelist = new List<UserCommission>();
        //    try
        //    {
                
        //        SqlParameter[] param = new SqlParameter[7];
        //        param[0] = new SqlParameter("@ServiceProvider", OperaterId);
        //        param[1] = new SqlParameter("@UserType", UserType);
        //        param[2] = new SqlParameter("@ServiceTypeId", ServiceId);
        //        param[3] = new SqlParameter("@EnumNo", OperaterNameEnum);
        //        param[4] = new SqlParameter("@ServiceProviderEnumNo", ServiceProviderEnum);
        //        param[5] = new SqlParameter("@PartyId", PartyId);
        //        param[6] = new SqlParameter("@Id", Id);
        //        DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_MASTER_ChildPartnersCommissionRates_View]", param);

        //        if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
        //        {
        //            Rechargelist = new List<UserCommission>();

        //            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //            {
        //                UserCommission obj = new UserCommission();
        //                obj.CommissionMasterId = ds.Tables[0].Rows[i]["iCmmssnMstId"].NulllToInt();
        //                obj.UserCommissionId = ds.Tables[0].Rows[i]["iPK_UsrCmmssnId"].NulllToInt();
        //                obj.ChargeType = ds.Tables[0].Rows[i]["iChrTyp"].NulllToInt();
        //                obj.ServiceId = ds.Tables[0].Rows[i]["iSrvicId"].NulllToInt();
        //                obj.TransactionAmountFrom = ds.Tables[0].Rows[i]["iTrnsctnAmtFrm"].NulllToInt();
        //                obj.TransactionAmountTo = ds.Tables[0].Rows[i]["iTrnsctnAmtTo"].NulllToInt();
        //                obj.CommissionAmount = ds.Tables[0].Rows[i]["dCmmssnAmt"].NulllToDecimal();
        //                obj.CommissionPercentage = ds.Tables[0].Rows[i]["iCmmssnPrcnt"].NulllToInt();
        //                obj.UserType = ds.Tables[0].Rows[i]["iUsrTyp"].NulllToInt();
        //                obj.OperatorName = ds.Tables[0].Rows[i]["OperatorName"].NulllToString();
        //                obj.ServiceProviderName = ds.Tables[0].Rows[i]["ServiceProviderName"].NulllToString();
        //                Rechargelist.Add(obj);
        //            }

        //        }
        //        else
        //        {
        //            Rechargelist = null;
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Rechargelist = null;
        //        ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetServiceProviderRate");
        //    }
        //    return Rechargelist;
        //}

        //public List<UserCommission> GetRechargeData(int OperaterId, int UserType, int OperaterNameEnum, int ServiceProviderEnum, int ServiceId = 0, string PartyId = null, int Id = 0)
        //{
        //    List<UserCommission> Rechargelist = new List<UserCommission>();
        //    try
        //    {
                
        //        SqlParameter[] param = null;
        //        if (Id != 0)
        //        {
        //            param = new SqlParameter[7];
        //        }
        //        else
        //        {
        //            param = new SqlParameter[6];
        //        }
        //        param[0] = new SqlParameter("@ServiceProvider", OperaterId);
        //        param[1] = new SqlParameter("@UserType", UserType);
        //        param[2] = new SqlParameter("@ServiceTypeId", ServiceId);
        //        param[3] = new SqlParameter("@EnumNo", OperaterNameEnum);
        //        param[4] = new SqlParameter("@ServiceProviderEnumNo", ServiceProviderEnum);
        //        param[5] = new SqlParameter("@PartyId", PartyId);
        //        if (Id != 0)
        //        {
        //            param[6] = new SqlParameter("@Id", Id);
        //        }
        //        DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_ADMIN_DirectPartnersCommissionRates_View]", param);
        //        if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
        //        {
        //            Rechargelist = new List<UserCommission>();

        //            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //            {
        //                UserCommission obj = new UserCommission();
        //                obj.CommissionMasterId = ds.Tables[0].Rows[i]["iCmmssnMstId"].NulllToInt();
        //                obj.UserCommissionId = ds.Tables[0].Rows[i]["iPK_UsrCmmssnId"].NulllToInt();
        //                obj.ChargeType = ds.Tables[0].Rows[i]["iChrTyp"].NulllToInt();
        //                obj.ServiceId = ds.Tables[0].Rows[i]["iSrvicId"].NulllToInt();
        //                obj.TransactionAmountFrom = ds.Tables[0].Rows[i]["iTrnsctnAmtFrm"].NulllToInt();
        //                obj.TransactionAmountTo = ds.Tables[0].Rows[i]["iTrnsctnAmtTo"].NulllToInt();
        //                obj.CommissionAmount = ds.Tables[0].Rows[i]["dCmmssnAmt"].NulllToDecimal();
        //                obj.CommissionPercentage = ds.Tables[0].Rows[i]["iCmmssnPrcnt"].NulllToInt();
        //                obj.UserType = ds.Tables[0].Rows[i]["iUsrTyp"].NulllToInt();
        //                obj.OperatorName = ds.Tables[0].Rows[i]["OperatorName"].NulllToString();
        //                obj.ServiceProviderName = ds.Tables[0].Rows[i]["ServiceProviderName"].NulllToString();
        //                Rechargelist.Add(obj);
        //            }

        //        }
        //        else
        //        {
        //            Rechargelist = null;
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Rechargelist = null;
        //        ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetServiceProviderRate");
        //    }
        //    return Rechargelist;
        //}

        public List<Dropdown> GetPartyInformationBasedonParentId(int Type, string PartyId)
        {
            List<Dropdown> objListdoc = new List<Dropdown>();
            try
            {
                
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@Type", Type);
                param[1] = new SqlParameter("@ParentId", PartyId);
                DataSet ds = BaseFunction.FillDataSet("[dbo].[GetPartyInformationBasedonParentId]", param);

                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    objListdoc = new List<Dropdown>();

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        Dropdown objdoc = new Dropdown();
                        objdoc.Id = ds.Tables[0].Rows[i]["Id"].ToString();
                        objdoc.Text = ds.Tables[0].Rows[i]["text"].ToString();


                        objListdoc.Add(objdoc);

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
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetChargesType");
            }
            return objListdoc;
        }

        public ResponseData Changestatus(Commisssiondata obj)
        {
            try
            {
                
                SqlParameter[] param = new SqlParameter[7];
                param[0] = new SqlParameter("@ServiceTypeId", obj.ServiceTypeId);
                param[1] = new SqlParameter("@TableName", obj.TableName);
                param[2] = new SqlParameter("@UserType", obj.UserType);
                param[3] = new SqlParameter("@CommissionMasterId", obj.CommissionMasterId);
                param[4] = new SqlParameter("@Isdefault", obj.Isdefault);
                param[5] = new SqlParameter("@PartyId", obj.PartyId);
                param[6] = new SqlParameter("@IsdefaultPartyId", obj.IsdefaultPartyId);
                DataTable DT = BaseFunction.FillDataTable("[dbo].[USP_ADMIN_ActivateDeactivateCurrentComission_Update]", param);
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
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : InsertSubMenuMaster");
            }
            return objResponseData;            
        }


        public ResponseData ServiceProviderChangeStatus(string TableId, int Id, int Type)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@Id", Id);
                param[1] = new SqlParameter("@Type", Type);

                DataTable DT = BaseFunction.FillDataTable("[dbo].[USP_ADMIN_ChangeServiceProviderStatus]", param);
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
            catch (Exception ex)
            {
                objResponseData.statusCode = 0;
                objResponseData.Message = "Failed";
                ExceptionLogDL.SendExcepToDB(ex, 0, "Class : AdminDL / Function : InsertSubMenuMaster");
            }
            return objResponseData;
        }

        #region Admin_SlabData_Mst_Update
        /// <summary>
        /// This Procedure use to Update data of SLBMST table 
        /// This function will be call on Status Changing,Delete,Rang Set Changing
        /// </summary>
        /// <param name="Type"(Type will be Status or RengSet or Delete)></param>
        /// <param name="Id"(iPk_SlbMst)></param>
        /// <param name="status"(0 or 1)></param>
        /// <returns>This function return status,status will be 1 or 0</returns>

        public ResponseData Admin_SlabData_Mst_Update(string Type, int Id, int status)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@Type", Type);
                param[1] = new SqlParameter("@Id", Id);
                param[2] = new SqlParameter("@status", status);
                DataTable DT = BaseFunction.FillDataTable("[dbo].[Usp_Admin_SlabData_Mst_Update]", param);

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
            catch (Exception ex)
            {
                objResponseData.statusCode = 0;
                objResponseData.Message = "Failed";
                ExceptionLogDL.SendExcepToDB(ex, 0, "Class : AdminDL / Function : InsertSlabMaster");
            }
            return objResponseData;
        }
        #endregion

        #region Admin_SlabData_Mst_Save
        /// <summary>
        /// This function use to save data in SLBMST table 
        /// </summary>
        /// <param name="SLBMST Model Object"></param>
        /// <returns>Status 1 then save otherwise 0</returns>
        public ResponseData Admin_SlabData_Mst_Save(SLBMST master)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[6];
                param[0] = new SqlParameter("@SerId", master.iSerId);
                param[1] = new SqlParameter("@Sts", master.iSts);
                param[2] = new SqlParameter("@TxnAmtFm", master.iTxnAmtFm);
                param[3] = new SqlParameter("@TxnAmtTo", master.iTxnAmtTo);
                param[4] = new SqlParameter("@RngSet", master.bRngSet);
                param[5] = new SqlParameter("@PatyCode", master.sPatyCode);
                DataTable DT = BaseFunction.FillDataTable("[dbo].[Usp_Admin_SlabData_Mst_Save]", param);
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
            catch (Exception ex)
            {
                objResponseData.statusCode = 0;
                objResponseData.Message = "Failed";
                ExceptionLogDL.SendExcepToDB(ex, 0, "Class : AdminDL / Function : InsertSlabMaster"); ;
            }
            return objResponseData;
        }
        #endregion

        #region Admin_SlabData_Mst_Show
        /// <summary>
        /// This function show data related to service Id from SLBMST table
        /// </summary>
        /// <param name="(serviceId)Id"></param>
        /// <returns>Return List of Slab related to Service Id from SLBMST table</returns>
        public List<SLBMST> Admin_SlabData_Mst_Show(int Id)
        {
            List<SLBMST> objListdoc = new List<SLBMST>();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@ServiceId", Id);
                DataSet ds = BaseFunction.FillDataSet("[dbo].[Usp_Admin_SlabData_Mst_Show]", param);
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    objListdoc = new List<SLBMST>();

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        SLBMST objdoc = new SLBMST();
                        objdoc.iPk_SlbMst = ds.Tables[0].Rows[i]["iPk_SlbMst"].NulllToInt();
                        objdoc.iTxnAmtFm = ds.Tables[0].Rows[i]["iTxnAmtFm"].NulllToInt();
                        objdoc.iTxnAmtTo = ds.Tables[0].Rows[i]["iTxnAmtTo"].NulllToInt();
                        objdoc.iSts = ds.Tables[0].Rows[i]["iSts"].NulllToInt();
                        objdoc.bRngSet = ds.Tables[0].Rows[i]["bRngSet"].NulllToBoolean();

                        objListdoc.Add(objdoc);
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
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetChargesType");
            }
            return objListdoc;
        }
        #endregion

        #region GetServiceProviderBaseonServiceId
        /// <summary>
        /// This Function use to get Service provider based on ServiceId
        /// </summary>
        /// <param name="ServiceId"></param>
        /// <returns>List of Service provider</returns>
        public List<CustomList> GetServiceProviderBaseonServiceId(int ServiceId)
        {
            List<CustomList> objListdoc = new List<CustomList>();
            try
            {

                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@ServiceId", ServiceId);

                DataSet ds = BaseFunction.FillDataSet("[dbo].[Usp_Admin_ServiceProviderList_Baseon_ServiceId_Mst_Show]", param);
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    objListdoc = new List<CustomList>();

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        CustomList objdoc = new CustomList();
                        objdoc.Id = ds.Tables[0].Rows[i]["Id"].NulllToInt();
                        objdoc.text = ds.Tables[0].Rows[i]["Text"].NulllToString();

                        objListdoc.Add(objdoc);
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
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetServiceProviderBaseonServiceId");
            }
            return objListdoc;
        }
        #endregion

        #region Admin_AEPS_Commission_Show
        /// <summary>
        /// This Function Show Aeps commission by admin
        /// </summary>
        /// <param name="ServiceProviderid"></param>
        /// <returns></returns>
        //public List<UserCommission> Admin_AEPS_Commission_Show(int ServiceProviderid, int CommissionMasterId)
        //{
        //    List<UserCommission> objListdoc = new List<UserCommission>();
        //    try
        //    {
        //        SqlParameter[] param = new SqlParameter[2];
        //        param[0] = new SqlParameter("@ServiceProviderid", ServiceProviderid);
        //        param[1] = new SqlParameter("@CommissionMasterId", CommissionMasterId);
        //        DataSet ds = BaseFunction.FillDataSet("[dbo].[Usp_Admin_AEPS_Commission_Show]", param);

        //        if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
        //        {
        //            objListdoc = new List<UserCommission>();

        //            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //            {
        //                UserCommission objdoc = new UserCommission();
        //                objdoc.UserCommissionId = ds.Tables[0].Rows[i]["UserCommissionId"].NulllToInt();
        //                objdoc.UserType = ds.Tables[0].Rows[i]["UserType"].NulllToInt();
        //                objdoc.ServiceId = ds.Tables[0].Rows[i]["ServiceId"].NulllToInt();
        //                objdoc.TransactionAmountFrom = ds.Tables[0].Rows[i]["TransactionAmountFrom"].NulllToInt();
        //                objdoc.TransactionAmountTo = ds.Tables[0].Rows[i]["TransactionAmountTo"].NulllToInt();
        //                objdoc.CommissionAmount = ds.Tables[0].Rows[i]["CommissionAmount"].NulllToDecimal();
        //                objdoc.CommissionMasterId = ds.Tables[0].Rows[i]["CommissionMasterId"].NulllToInt();
        //                objdoc.Status = ds.Tables[0].Rows[i]["Status"].NulllToInt();
        //                objListdoc.Add(objdoc);

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
        //        ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : Admin_AEPS_Commission_Show");
        //    }
        //    return objListdoc;
        //}
        #endregion

        #region Admin_AEPS_Commission_Save
        //public ResponseData Admin_AEPS_Commission_Save(UserCommission master)
        //{
        //    try
        //    {
        //        SqlParameter[] param = new SqlParameter[10];
        //        param[0] = new SqlParameter("@CommissionAmount", master.CommissionAmount);
        //        param[1] = new SqlParameter("@TransactionAmountFrom", master.TransactionAmountFrom);
        //        param[2] = new SqlParameter("@TransactionAmountTo", master.TransactionAmountTo);
        //        param[3] = new SqlParameter("@CommissionMasterId", master.CommissionMasterId);
        //        param[4] = new SqlParameter("@UserType", master.UserType);
        //        param[5] = new SqlParameter("@ServiceProviderId", master.ServiceProviderId);
        //        param[6] = new SqlParameter("@PartyId", master.PartyId);
        //        param[7] = new SqlParameter("@ServiceId", master.ServiceId);
        //        param[8] = new SqlParameter("@DefaultUserPartyId", master.DefaultUserPartyId);
        //        param[9] = new SqlParameter("@CommissionPercentage", master.CommissionPercentage);
        //        DataTable DT = BaseFunction.FillDataTable("[dbo].[Usp_Admin_AEPS_Commission_Save]", param);

        //        if (DT != null)
        //        {
        //            if (DT.Rows.Count > 0)
        //            {
        //                objResponseData.statusCode = Convert.ToInt32(DT.Rows[0]["StatusCode"]);
        //                objResponseData.Message = DT.Rows[0]["Message"].ToString();

        //            }
        //        }
        //        else
        //        {
        //            objResponseData.statusCode = 0;
        //            objResponseData.Message = "Failed";
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        objResponseData.statusCode = 0;
        //        objResponseData.Message = "Failed";
        //        ExceptionLogDL.SendExcepToDB(ex, 0, "Class : AdminDL / Function : InsertSlabMaster");
        //    }
        //    return objResponseData;
        //}
        #endregion

        #region Admin_Set_APesCommission_All_Show
        //public List<ApesSetCommission> Admin_Set_APesCommission_All_Show(string PartyId, int ServiceId, string DefaultParty)
        //{
        //    List<ApesSetCommission> objListdoc = new List<ApesSetCommission>();
        //    try
        //    {
        //        SqlParameter[] param = new SqlParameter[3];
        //        param[0] = new SqlParameter("@Party", PartyId);
        //        param[1] = new SqlParameter("@serviceId", ServiceId);
        //        param[2] = new SqlParameter("@DefaultUserPartyId", DefaultParty);
        //        DataSet ds = BaseFunction.FillDataSet("[dbo].[Usp_Admin_Set_APesCommission_All_Show]", param);

        //        if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
        //        {
        //            objListdoc = new List<ApesSetCommission>();

        //            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //            {
        //                ApesSetCommission objdoc = new ApesSetCommission();
        //                objdoc.TransactionAmountFrom = ds.Tables[0].Rows[i]["TransactionAmountFrom"].NulllToString();
        //                objdoc.TransactionAmountTo = ds.Tables[0].Rows[i]["TransactionAmountTo"].NulllToString();
        //                objdoc.Retailer = ds.Tables[0].Rows[i]["Retailer"].NulllToString();
        //                objdoc.Distributer = ds.Tables[0].Rows[i]["Distributer"].NulllToString();
        //                objdoc.Stockist = ds.Tables[0].Rows[i]["Stockist"].NulllToString();
        //                objdoc.Whitelabel = ds.Tables[0].Rows[i]["Whitelabel"].NulllToString();
        //                objdoc.Retailer_Commission = ds.Tables[0].Rows[i]["Retailer_Commission"].NulllToString();
        //                objdoc.Distributer_Commission = ds.Tables[0].Rows[i]["Distributer_Commission"].NulllToString();
        //                objdoc.Stockist_Commission = ds.Tables[0].Rows[i]["Stockist_Commission"].NulllToString();
        //                objdoc.Whitelabel_Commission = ds.Tables[0].Rows[i]["Whitelabel_Commission"].NulllToString();
        //                objListdoc.Add(objdoc);
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
        //        ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : Admin_AEPS_Commission_Show");
        //    }
        //    return objListdoc;
        //}

        #endregion

        #region USP_List_ClientInfo_Of_Admin

        public List<Dropdown> USP_List_ClientInfo_Of_Admin()
        {
            List<Dropdown> objListdoc = new List<Dropdown>();
            try
            {
                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_List_ClientInfo_Of_Admin]");

                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    objListdoc = new List<Dropdown>();

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        Dropdown objdoc = new Dropdown();
                        objdoc.PartyId = ds.Tables[0].Rows[i]["PartyId"].NulllToString();
                        objdoc.Text = ds.Tables[0].Rows[i]["FirstName"].NulllToString();
                        objdoc.ID1 = ds.Tables[0].Rows[i]["Namefield"].NulllToString();
                        objListdoc.Add(objdoc);
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
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : USP_List_ClientInfo_Of_Admin");
            }
            return objListdoc;
        }
        #endregion

        //Announcement_Save
        #region Admin_News_Announcement_Save
        public ResponseData Admin_News_Announcement_Save(NEWANNMST master)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[10];
                param[0] = new SqlParameter("@iSts", master.iSts);
                param[1] = new SqlParameter("@iPK_NewId", master.iPK_NewId);
                param[2] = new SqlParameter("@iNwsAnnoType", master.iNwsAnnoType);
                param[3] = new SqlParameter("@dtSrtDt", master.dtSrtDt);
                param[4] = new SqlParameter("@dtEndDt", master.dtEndDt);
                param[5] = new SqlParameter("@dFrmTime", master.dFrmTime);
                param[6] = new SqlParameter("@dToTime", master.dToTime);
                param[7] = new SqlParameter("@sMsg", master.sMsg);
                param[8] = new SqlParameter("@sPatyCode", master.sPatyCode);
                param[9] = new SqlParameter("@sSubject", master.sSubject);

                DataTable DT = BaseFunction.FillDataTable("[dbo].[Usp_Admin_News_Announcement_Save]", param);
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
            catch (Exception ex)
            {
                objResponseData.statusCode = 0;
                objResponseData.Message = "Failed";
                ExceptionLogDL.SendExcepToDB(ex, 0, "Class : AdminDL / Function : Admin_News_Announcement_Save");
            }
            return objResponseData;

        }
        #endregion

        #region Admin_News_Announcement_Show
        public List<NEWANNMST> Admin_News_Announcement_Show(int Type, int ShowType)
        {
            List<NEWANNMST> objListdoc = new List<NEWANNMST>();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@Type", Type);
                param[1] = new SqlParameter("@ShowType", ShowType);
                DataSet ds = BaseFunction.FillDataSet("[dbo].[Usp_Admin_News_Announcement_Show]", param);
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    objListdoc = new List<NEWANNMST>();

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        NEWANNMST objdoc = new NEWANNMST();
                        objdoc.iPK_NewId = ds.Tables[0].Rows[i]["iPK_NewId"].NulllToInt();
                        objdoc.iNwsAnnoType = ds.Tables[0].Rows[i]["iNwsAnnoType"].NulllToInt();
                        objdoc.iSts = ds.Tables[0].Rows[i]["iSts"].NulllToInt();
                        objdoc.dtSrtDt = ((DateTime)ds.Tables[0].Rows[i]["dtSrtDt"]).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture).NulllToString();
                        objdoc.dtEndDt = ((DateTime)ds.Tables[0].Rows[i]["dtEndDt"]).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture).NulllToString();
                        objdoc.dFrmTime = ds.Tables[0].Rows[i]["dFrmTime"].NulllToString();
                        objdoc.dToTime = ds.Tables[0].Rows[i]["dToTime"].NulllToString();
                        objdoc.sSubject = ds.Tables[0].Rows[i]["sSubject"].NulllToString();
                        objdoc.sMsg = ds.Tables[0].Rows[i]["sMsg"].NulllToString();
                        objListdoc.Add(objdoc);
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
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : Admin_News_Announcement_Show");
            }
            return objListdoc;
        }
        #endregion


    }
}
