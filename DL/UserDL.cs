using BO.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using static BO.Models.Partial;

namespace DL
{
    public class UserDL
    {
        ResponseData objResponseData = new ResponseData();
        public static IConfiguration _configuration;
        string connectionString = DBCS.GetConnectionString();
        string BaseURL = DBCS.GetBaseURL();

        #region Abhishek
        public List<PartyMaster> GetPartyDetail(string Id)
        {
            List<PartyMaster> objListdoc = new List<PartyMaster>();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@Id", Id);
                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_MASTER_PartyMaster_View]", param);
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    objListdoc = new List<PartyMaster>();

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        PartyMaster objdoc = new PartyMaster();
                        objdoc.PartyId = ds.Tables[0].Rows[i]["sPK_PrtyCode"].NulllToString();
                        objdoc.FirstName = ds.Tables[0].Rows[i]["sFstName"].NulllToString();
                        objdoc.LastName = ds.Tables[0].Rows[i]["sLstName"].NulllToString();
                        objdoc.MiddleName = ds.Tables[0].Rows[i]["sMidName"].NulllToString();
                        objdoc.EmailId = ds.Tables[0].Rows[i]["sEmailId"].NulllToString();
                        objdoc.DOB = ds.Tables[0].Rows[i]["dtDoB"].NulllToString();
                        if (!string.IsNullOrEmpty(objdoc.DOB))
                        {
                            objdoc.DateofBirth = ((DateTime)ds.Tables[0].Rows[i]["dtDoB"]).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture).NulllToString();
                            objdoc.DOB = ((DateTime)ds.Tables[0].Rows[i]["dtDoB"]).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture).NulllToString();
                        }
                        objdoc.MobileNumber = ds.Tables[0].Rows[i]["sMobileNo"].NulllToString();
                        objdoc.Type = ds.Tables[0].Rows[i]["iTyp"].NulllToInt();
                        objdoc.CUAdd1 = ds.Tables[0].Rows[i]["sCmpnyAddrs1"].NulllToString();
                        objdoc.CUAdd2 = ds.Tables[0].Rows[i]["sCmpnyAddrs2"].NulllToString();
                        objdoc.CUAdd3 = ds.Tables[0].Rows[i]["sCmpnyAddrs3"].NulllToString();
                        objdoc.CULandMark = ds.Tables[0].Rows[i]["sCmpnyLndMrk"].NulllToString();
                        objdoc.CUPinCode = ds.Tables[0].Rows[i]["sCmpnyPinCode"].NulllToString();
                        objdoc.PAAdd1 = ds.Tables[0].Rows[i]["sPrmantAddrs1"].NulllToString();
                        objdoc.PAAdd2 = ds.Tables[0].Rows[i]["sPrmantAddrs2"].NulllToString();
                        objdoc.PAAdd3 = ds.Tables[0].Rows[i]["sPrmantAddrs3"].NulllToString();
                        objdoc.PALandMark = ds.Tables[0].Rows[i]["sParmntLndMrk"].NulllToString();
                        objdoc.PAPinCode = ds.Tables[0].Rows[i]["sPrmantPinCode"].NulllToString();
                        objdoc.COAdd1 = ds.Tables[0].Rows[i]["sCrospondAddrs1"].NulllToString();
                        objdoc.COAdd2 = ds.Tables[0].Rows[i]["sCrospondAddrs2"].NulllToString();
                        objdoc.COAdd3 = ds.Tables[0].Rows[i]["sCrospondAddrs3"].NulllToString();
                        objdoc.COLandMark = ds.Tables[0].Rows[i]["sCrospondLndMrk"].NulllToString();
                        objdoc.COPinCode = ds.Tables[0].Rows[i]["sCrospondPinCode"].NulllToString();
                        objdoc.GST = ds.Tables[0].Rows[i]["sGst"].NulllToString();
                        objdoc.CompanyContactNo = ds.Tables[0].Rows[i]["BiCmpnyContctNo"].NulllToLong();
                        objdoc.CompanyEmailId = ds.Tables[0].Rows[i]["sCmpnyEmailId"].NulllToString();
                        objdoc.AadhaarDist = ds.Tables[0].Rows[i]["sAadharDist"].NulllToString();
                        objdoc.AadhaarLoc = ds.Tables[0].Rows[i]["sAadharLoc"].NulllToString();
                        objdoc.AadhaarPO = ds.Tables[0].Rows[i]["sAadharPo"].NulllToString();
                        objdoc.AadhaarStreet = ds.Tables[0].Rows[i]["sAadharStreet"].NulllToString();
                        objdoc.Aadhaarhouse = ds.Tables[0].Rows[i]["sAadharHouse"].NulllToString();
                        objdoc.Aadhaarlandmark = ds.Tables[0].Rows[i]["sAadharLndMrk"].NulllToString();
                        objdoc.PanStatus = ds.Tables[0].Rows[i]["PanStatus"].NulllToString();
                        objdoc.AdhaarCardStatus = ds.Tables[0].Rows[i]["AdhaarCardStatus"].NulllToString();
                        objdoc.EmailStatus = ds.Tables[0].Rows[i]["EmailStatus"].NulllToString();
                        objdoc.MobileStatus = ds.Tables[0].Rows[i]["MobileStatus"].NulllToString();
                        objdoc.CountryName = ds.Tables[0].Rows[i]["CountryName"].NulllToString();
                        objdoc.DistrictName = ds.Tables[0].Rows[i]["DistrictName"].NulllToString();
                        objdoc.StateName = ds.Tables[0].Rows[i]["StateName"].NulllToString();
                        objdoc.CityName = ds.Tables[0].Rows[i]["CityName"].NulllToString();
                        objdoc.AreaName = ds.Tables[0].Rows[i]["AreaName"].NulllToString();
                        objdoc.ProfileImage = ds.Tables[0].Rows[i]["ProfileImage"].NulllToString();
                        objdoc.CountryId = ds.Tables[0].Rows[i]["iCntryId"].NulllToInt();
                        objdoc.StateId = ds.Tables[0].Rows[i]["iStateId"].NulllToInt();
                        objdoc.DistrictId = ds.Tables[0].Rows[i]["iDistId"].NulllToString();
                        objdoc.CityId = ds.Tables[0].Rows[i]["iCityId"].NulllToString();
                        objdoc.AreaId = ds.Tables[0].Rows[i]["iAreaId"].NulllToInt();
                        objdoc.IsGST_Applicable = ds.Tables[0].Rows[i]["IsGST_Applicable"].NulllToInt();
                        objdoc.IsTDS_Applicable = ds.Tables[0].Rows[i]["IsTDS_Applicable"].NulllToInt();
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
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetPartyDetail");
            }
            return objListdoc;
        }
        public List<Documentlist> GetUploadDocumentlist(string Id)
        {
            List<Documentlist> objListdoc = new List<Documentlist>();
            try
            {

                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@Id", Id);
                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_MASTER_UserDocumentList_View]", param);
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    objListdoc = new List<Documentlist>();

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        Documentlist objdoc = new Documentlist();
                        objdoc.DocumentId = ds.Tables[0].Rows[i]["iDocId"].NulllToInt();
                        objdoc.UploadDocumentUrl = ds.Tables[0].Rows[i]["sUplodDcumntUrl"].NulllToString();
                        objdoc.DocumentName = ds.Tables[0].Rows[i]["DocumentName"].NulllToString();
                        objdoc.DocumentStatus = ds.Tables[0].Rows[i]["DocumentStatus"].NulllToInt();

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
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetPartyDetail");
            }
            return objListdoc;
        }
        public ResponseData UpdatePartyMaster(PartyMaster obj)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[35];
                param[0] = new SqlParameter("@PartyId", obj.PartyId);
                param[1] = new SqlParameter("@FirstName", obj.FirstName);
                param[2] = new SqlParameter("@MiddleName", obj.MiddleName);
                param[3] = new SqlParameter("@LastName", obj.LastName);
                param[4] = new SqlParameter("@MobileNumber", obj.MobileNumber);
                param[5] = new SqlParameter("@EmailId", obj.EmailId);

                param[6] = new SqlParameter("@DOB", obj.DateofBirth);
                param[7] = new SqlParameter("@Type", obj.Type);
                param[8] = new SqlParameter("@role", obj.RoleId);
                param[9] = new SqlParameter("@State", obj.StateId);
                param[10] = new SqlParameter("@District", obj.DistrictId);
                param[11] = new SqlParameter("@City", obj.CityId);

                param[12] = new SqlParameter("@CUADD1", obj.CUAdd1);
                param[13] = new SqlParameter("@CUADD2", obj.CUAdd2);
                param[14] = new SqlParameter("@CUADD3", obj.CUAdd3);
                param[15] = new SqlParameter("@CULandMark", obj.CULandMark);
                param[16] = new SqlParameter("@CUPinCode", obj.CUPinCode);
                param[17] = new SqlParameter("@PAAdd1", obj.PAAdd1);

                param[18] = new SqlParameter("@PAAdd2", obj.PAAdd2);
                param[19] = new SqlParameter("@PAAdd3", obj.PAAdd3);
                param[20] = new SqlParameter("@PALandMark", obj.PALandMark);
                param[21] = new SqlParameter("@PAPinCode", obj.PAPinCode);
                param[22] = new SqlParameter("@COAdd1", obj.COAdd1);
                param[23] = new SqlParameter("@COAdd2", obj.COAdd2);
                param[24] = new SqlParameter("@COAdd3", obj.COAdd3);
                param[25] = new SqlParameter("@COLandMark", obj.COLandMark);
                param[26] = new SqlParameter("@COPinCode", obj.COPinCode);

                param[27] = new SqlParameter("@CompanyContactNumber", obj.CompanyContactNo);
                param[28] = new SqlParameter("@ComapnyEmail", obj.CompanyEmailId);
                param[29] = new SqlParameter("@GSTNo", obj.GST);
                param[30] = new SqlParameter("@ProfileImage", obj.ProfileImage);

                param[31] = new SqlParameter("@Country", obj.CountryId);
                param[32] = new SqlParameter("@Area", obj.AreaId);
                param[33] = new SqlParameter("@IsGST", obj.IsGST_Applicable);
                param[34] = new SqlParameter("@IsTDS", obj.IsTDS_Applicable);
                DataTable DT = BaseFunction.FillDataTable("[dbo].[USP_MASTER_PartyMaster_Save]", param);
                if (DT != null)
                {
                    if (DT.Rows.Count > 0)
                    {
                        objResponseData.statusCode = Convert.ToInt32(DT.Rows[0]["StatusCode"]);
                        //objResponseData.Message = DT.Rows[0]["Message"].ToString();

                    }
                }
                else
                {
                    objResponseData.statusCode = 0;
                    //objResponseData.Message = "Failed";
                }
            }
            catch (Exception e)
            {
                objResponseData.statusCode = 0;
                //objResponseData.Message = "Failed";
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : UpdatePartyMaster");
            }
            return objResponseData;

        }
        public List<RegistratedUser> GetRegistratedUsers()
        {
            List<RegistratedUser> objListUser = new List<RegistratedUser>();
            try
            {


                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_MASTER_RegisteredUserList_View]");
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    objListUser = new List<RegistratedUser>();

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        RegistratedUser obj = new RegistratedUser();
                        obj.PartyId = ds.Tables[0].Rows[i]["sPK_PrtyCode"].NulllToString();
                        obj.UserType = ds.Tables[0].Rows[i]["UserType"].NulllToString();
                        obj.RegistrationNo = ds.Tables[0].Rows[i]["RegistrationNo"].NulllToString();
                        obj.UserName = ds.Tables[0].Rows[i]["UserName"].NulllToString();
                        obj.FirstName = ds.Tables[0].Rows[i]["sFstName"].NulllToString();
                        obj.MobileNumber = ds.Tables[0].Rows[i]["sMobileNo"].NulllToString();
                        obj.Servicecollection = ds.Tables[0].Rows[i]["Servicecollection"].NulllToString();
                        obj.Hardwarecollection = ds.Tables[0].Rows[i]["Hardwarecollection"].NulllToString();
                        obj.IsActive = ds.Tables[0].Rows[i]["IsActive"].NulllToInt();
                        obj.PaymentStatus = ds.Tables[0].Rows[i]["PaymentStatus"].NulllToString();
                        obj.EncryPartyId = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(obj.PartyId));
                        objListUser.Add(obj);

                    }

                }
                else
                {
                    objListUser = null;
                }
            }
            catch (Exception e)
            {
                objListUser = null;
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetRegistratedUsers");
            }
            return objListUser;

        }

        // DONE BY SHIPRA
        public List<ACtivedServicesHardwarelist> GetActivedServicesandHardwareList(string Id)
        {
            List<ACtivedServicesHardwarelist> objListdoc = new List<ACtivedServicesHardwarelist>();
            try
            {

                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@Id", Id);
                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_ADMIN_ServicesandHardwarelist_View]", param);
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    objListdoc = new List<ACtivedServicesHardwarelist>();

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        ACtivedServicesHardwarelist objdoc = new ACtivedServicesHardwarelist();
                        objdoc.OrderId = ds.Tables[0].Rows[i]["OrderId"].NulllToString();
                        objdoc.OrderStatus = ds.Tables[0].Rows[i]["OrderStatus"].NulllToString();
                        objdoc.PartyId = ds.Tables[0].Rows[i]["PartyId"].NulllToString();
                        objdoc.Servicecollection = ds.Tables[0].Rows[i]["Servicecollection"].NulllToString();
                        objdoc.Hardwarecollection = ds.Tables[0].Rows[i]["Hardwarecollection"].NulllToString();


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
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetPartyDetail");
            }
            return objListdoc;
        }
        public List<PayTracking> GetPayTrackings(string Id)
        {
            List<PayTracking> objListdoc = new List<PayTracking>();
            try
            {

                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@Id", Id);
                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_ACCOUNT_PartywisePaymentTracking_Select]", param);
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    objListdoc = new List<PayTracking>();

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        PayTracking objdoc = new PayTracking();
                        objdoc.OrderId = ds.Tables[0].Rows[i]["iFK_OrdrId"].NulllToString();
                        objdoc.PayableAmount = ds.Tables[0].Rows[i]["dPayblAmt"].NulllToDecimal();
                        objdoc.PartyId = ds.Tables[0].Rows[i]["sPrtyCode"].NulllToString();
                        objdoc.TransactionAmt = ds.Tables[0].Rows[i]["dTrnsctnAmt"].NulllToDecimal();
                        objdoc.BalancaAmt = ds.Tables[0].Rows[i]["dBlncAmt"].NulllToDecimal();
                        objdoc.ModeType = ds.Tables[0].Rows[i]["Mode"].NulllToString();
                        objdoc.PaymentMode = ds.Tables[0].Rows[i]["sPaymntMode"].NulllToString();
                        objdoc.TransactionDate = ((DateTime)ds.Tables[0].Rows[i]["dtTrnsctnDt"]).ToString("yyyy-MM-dd hh:mm:ss", CultureInfo.InvariantCulture).NulllToString();
                        objdoc.Bank = ds.Tables[0].Rows[i]["Bank"].NulllToString();
                        objdoc.Account = ds.Tables[0].Rows[i]["Account"].NulllToString();
                        objdoc.UPI = ds.Tables[0].Rows[i]["UPI"].NulllToString();
                        objdoc.ChequeNo = ds.Tables[0].Rows[i]["ChequeNo"].NulllToString();
                        objdoc.CurrentStatus = ds.Tables[0].Rows[i]["CurrentStatus"].NulllToString();
                        objdoc.PaymentStatus = ds.Tables[0].Rows[i]["iPaymntStatus"].NulllToInt();
                        objdoc.BankUTR = ds.Tables[0].Rows[i]["BankUTR"].NulllToString();

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
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetPartyDetail");
            }
            return objListdoc;
        }
        #endregion

        #region vivek
        public List<CustomList> GetCustomList(int Enumno)
        {
            List<CustomList> objListdoc = new List<CustomList>();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@EnumNo", Enumno);
                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_ADMIN_CustomFieldsByEnumNo_View]", param);
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
            catch (Exception e)
            {
                objListdoc = null;
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetCustomList", connectionString);
            }
            return objListdoc;
        }
    
        public ResponseData Login(Login login)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@EmailId", login.Email);
                param[1] = new SqlParameter("@Passwordstr", login.Password);
                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_MASTER_UserLoginCheck_Select]", param);
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    objResponseData.ResponseCode = "000";
                    objResponseData.Message = "User Details";
                    objResponseData.Data = JObject.FromObject(new UserModelSession
                    {
                        EmailId = ds.Tables[0].Rows[0]["sEmailId"].NulllToString(),
                        MobileNumber = ds.Tables[0].Rows[0]["sMobileNo"].NulllToString(),
                        PartyId = ds.Tables[0].Rows[0]["sPK_PrtyCode"].NulllToString(),
                        ServicesCollection = ds.Tables[0].Rows[0]["sSrvicC"].NulllToString(),
                        Type = ds.Tables[0].Rows[0]["iTyp"].NulllToString(),
                        Username = ds.Tables[0].Rows[0]["Username"].NulllToString(),
                        IsActive = ds.Tables[0].Rows[0]["IsActive"].NulllToString(),
                        PartialOrderID = ds.Tables[0].Rows[0]["PartialOrderID"].NulllToString(),
                        RegistrationNo = ds.Tables[0].Rows[0]["sRegNo"].NulllToString(),
                        profileImage = ds.Tables[0].Rows[0]["profileImage"].NulllToString(),
                        RoleId = ds.Tables[0].Rows[0]["iRoleId"].NulllToInt(),
                        DepartmentId = ds.Tables[0].Rows[0]["iDeptId"].NulllToInt(),
                        Hirarchy = ds.Tables[0].Rows[0]["sHirarchy"].NulllToString(),
                        UserType = ds.Tables[0].Rows[0]["UserType"].NulllToString(),
                        CityId = ds.Tables[0].Rows[0]["CityId"].NulllToInt(),
                        DistrictId = ds.Tables[0].Rows[0]["DistrictId"].NulllToInt(),
                        StateId = ds.Tables[0].Rows[0]["StateId"].NulllToInt(),
                        iLocLvl = ds.Tables[0].Rows[0]["iLocLvl"].NulllToInt(),
                        //CashInWallet = ds.Tables[1].Rows[0]["CashInWallet"].NulllToDouble(),
                        //CashOutWallet = ds.Tables[2].Rows[0]["CashOutWallet"].NulllToDouble(),
                        //UseableAmtWallet = ds.Tables[3].Rows[0]["UseableAmtWallet"].NulllToDouble(),
                        //PendingTransationinQueyWallet = ds.Tables[4].Rows[0]["PendingTransationinQueyWallet"].NulllToDouble()
                    });
                    objResponseData.statusCode = 1;
                }
                else
                {
                    objResponseData.ResponseCode = "001";
                    objResponseData.Message = "User Details Not Found...";
                    objResponseData.statusCode = -1;
                }
            }
            catch (Exception e)
            {
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : Login", connectionString);
            }
            return objResponseData;
        }
        public ResponseData ResetPassword(ResetPassword resetpassword)
        {
            try
            {

                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@email", resetpassword.Email);
                param[1] = new SqlParameter("@password", resetpassword.Password);
                param[2] = new SqlParameter("@type", resetpassword.Type);
                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_ADMIN_ResetUsersPassword_SelectUpdate]", param);
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    objResponseData.ResponseCode = "000";
                    objResponseData.Message = ds.Tables[0].Rows[0]["Message"].NulllToString();
                    objResponseData.statusCode = ds.Tables[0].Rows[0]["StatusCode"].NulllToInt();
                }
                else
                {
                    objResponseData.ResponseCode = "001";
                    objResponseData.Message = "Not Saved...";
                    objResponseData.statusCode = -1;
                }
            }
            catch (Exception e)
            {
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : ResetPassword", connectionString);
            }
            return objResponseData;
        }
        public ResponseData GetServicesDetails()
        {
            try
            {
                List<Getservicesetails> lstservices = new List<Getservicesetails>();

                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_MASTER_ServiceswithAmount_View]");
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        Getservicesetails service = new Getservicesetails();
                        var serviceName = ds.Tables[0].Rows[i]["sName"].NulllToString();

                        var serviceIconImage = serviceName.Trim().Replace(" ", "_");
                        serviceIconImage = serviceIconImage.Replace("-", "_");
                        serviceIconImage = BaseURL + serviceIconImage + ".png";

                        service.RateMasterId = ds.Tables[0].Rows[i]["iPK_RateMstId"].NulllToString();
                        service.ServiceName = ds.Tables[0].Rows[i]["ServiceName"].NulllToString();
                        service.Name = ds.Tables[0].Rows[i]["sName"].NulllToString();
                        service.CategoryID = ds.Tables[0].Rows[i]["CategoryID"].NulllToString();
                        service.className = serviceIconImage;//ds.Tables[0].Rows[i]["className"].NulllToString();
                        service.ChargeType = ds.Tables[0].Rows[i]["ChargeType"].NulllToString();
                        service.UnitType = ds.Tables[0].Rows[i]["UnitType"].NulllToString();
                        service.PaymentType = ds.Tables[0].Rows[i]["PaymentType"].NulllToString();
                        service.Amount = ds.Tables[0].Rows[i]["BiAmt"].NulllToInt();
                        service.Isactive = ds.Tables[0].Rows[i]["Isactive"].NulllToInt();

                        lstservices.Add(service);
                    }

                    objResponseData.ResponseCode = "000";
                    objResponseData.Message = "Service List";
                    objResponseData.statusCode = 1;
                    objResponseData.Data = lstservices;

                }
                else
                {
                    objResponseData.ResponseCode = "001";
                    objResponseData.Message = "Not Saved...";
                    objResponseData.statusCode = -1;
                }
            }
            catch (Exception e)
            {
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetServicesDetails", connectionString);
            }
            return objResponseData;
        }
        public ResponseData GetServicesDetailsAndroid()
        {
            try
            {
                List<GetservicesetailsAndroid> lstservices = new List<GetservicesetailsAndroid>();

                DataSet ds = BaseFunction.FillDataSet("[dbo].[ShowServiceswithAmount_Android]");
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        GetservicesetailsAndroid service = new GetservicesetailsAndroid();

                        var serviceName = ds.Tables[0].Rows[i]["Name"].NulllToString();

                        var serviceIconImage = serviceName.Trim().Replace(" ", "_");
                        serviceIconImage = serviceIconImage.Replace("-", "_");
                        serviceIconImage = BaseURL + serviceIconImage + ".png";

                        service.CategoryID = ds.Tables[0].Rows[i]["CategoryID"].NulllToString();
                        service.Name = ds.Tables[0].Rows[i]["Name"].NulllToString();
                        service.RegistrationCharge = ds.Tables[0].Rows[i]["RegistrationCharge"].NulllToString();
                        service.AnnualMaintenanceCharge = ds.Tables[0].Rows[i]["AnnualMaintenanceCharge"].NulllToString();
                        service.GSTPercentage = ds.Tables[0].Rows[i]["GSTPercentage"].NulllToString();
                        service.ServiceIcon = serviceIconImage;
                        lstservices.Add(service);
                    }

                    objResponseData.ResponseCode = "000";
                    objResponseData.Message = "Service List";
                    objResponseData.statusCode = 1;
                    objResponseData.Data = lstservices;

                }
                else
                {
                    objResponseData.ResponseCode = "001";
                    objResponseData.Message = "Not Saved...";
                    objResponseData.statusCode = -1;
                }
            }
            catch (Exception e)
            {
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetServicesDetailsAndroid", connectionString);
            }
            return objResponseData;
        }
        public ResponseData GetServices()
        {
            try
            {
                List<Services> lstservices = new List<Services>();

                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_MASTER_ServiceDetails_View]");
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        Services service = new Services();

                        service.CategoryId = ds.Tables[0].Rows[i]["iPK_CatId"].NulllToString();
                        service.Name = ds.Tables[0].Rows[i]["sName"].NulllToString();
                        service.ClassName = ds.Tables[0].Rows[i]["sClsNm"].NulllToString();
                        service.varificationList = ds.Tables[0].Rows[i]["varificationList"].NulllToString();
                        service.DocumentList = ds.Tables[0].Rows[i]["DocumentList"].NulllToString();
                        service.HardwareList = ds.Tables[0].Rows[i]["HardwareList"].NulllToString();

                        lstservices.Add(service);
                    }

                    objResponseData.ResponseCode = "000";
                    objResponseData.Message = "Service List";
                    objResponseData.statusCode = 1;
                    objResponseData.Data = lstservices;

                }
                else
                {
                    objResponseData.ResponseCode = "001";
                    objResponseData.Message = "Not Saved...";
                    objResponseData.statusCode = -1;
                }
            }
            catch (Exception e)
            {
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetServices", connectionString);
            }
            return objResponseData;
        }
        //Not in use
        //public ResponseData GethardwareForService(string services)
        //{
        //    try
        //    {
        //        List<HardwareList> lsthardware = new List<HardwareList>();

        //        SqlParameter[] param = new SqlParameter[1];
        //        param[0] = new SqlParameter("@serviceIDs", services);
        //        DataSet ds = BaseFunction.FillDataSet("[dbo].[sp_gethardwareList]", param);
        //        if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
        //        {
        //            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //            {
        //                HardwareList hardware = new HardwareList();

        //                hardware.HardwareId = ds.Tables[0].Rows[i]["Hardwareid"].NulllToString();
        //                hardware.Name = ds.Tables[0].Rows[i]["Name"].NulllToString();
        //                hardware.GST = ds.Tables[0].Rows[i]["GST"].NulllToString();
        //                hardware.Amount = ds.Tables[0].Rows[i]["Amount"].NulllToString();
        //                hardware.ChargeType = ds.Tables[0].Rows[i]["ChargeType"].NulllToString();
        //                hardware.UnitType = ds.Tables[0].Rows[i]["UnitType"].NulllToString();

        //                lsthardware.Add(hardware);
        //            }

        //            objResponseData.ResponseCode = "000";
        //            objResponseData.Message = "Hardware List";
        //            objResponseData.statusCode = 1;
        //            objResponseData.Data = lsthardware;

        //        }
        //        else
        //        {
        //            objResponseData.ResponseCode = "001";
        //            objResponseData.Message = "Not Saved...";
        //            objResponseData.statusCode = -1;
        //        }                
        //    }
        //    catch (Exception e)
        //    {
        //        ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GethardwareForService", connectionString);
        //    }
        //    return objResponseData;
        //}
        public ResponseData GetdetailsForUser(string email)
        {
            try
            {

                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@email", email);
                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_MASTER_UserProfileAndPurcharseDetails_View]", param);
                UserModel user = new UserModel();
                List<ServiceNameList> serviceNames = new List<ServiceNameList>();
                List<HardwareNameList> hardwareNames = new List<HardwareNameList>();
                List<DocumentList> documents = new List<DocumentList>();
                List<PaymentDetails> payments = new List<PaymentDetails>();


                if (ds != null && ds.Tables != null)
                {
                    DataTable dtuserData = ds.Tables[0];
                    DataTable serviceData = ds.Tables[1];
                    DataTable hardwareData = ds.Tables[2];
                    DataTable documentData = ds.Tables[3];
                    DataTable paymentData = ds.Tables[4];

                    for (int i = 0; i < dtuserData.Rows.Count; i++)
                    {
                        user.Name = dtuserData.Rows[i]["sName"].NulllToString();
                        user.FirstName = dtuserData.Rows[i]["sFstName"].NulllToString();
                        user.MobileVerified = dtuserData.Rows[i]["MobileVerified"].NulllToInt();
                        user.AdhaarVerified = dtuserData.Rows[i]["AdhaarVerified"].NulllToInt();
                        user.PanVerified = dtuserData.Rows[i]["PanVerified"].NulllToInt();
                        user.EmailVerified = dtuserData.Rows[i]["EmailVerified"].NulllToInt();
                        user.PanCard = dtuserData.Rows[i]["sPanCrd"].NulllToString();
                        user.AdhaarCard = dtuserData.Rows[i]["sAadharCrd"].NulllToString();
                        user.MobileNumber = dtuserData.Rows[i]["sMobileNo"].NulllToString();
                        user.EmailId = dtuserData.Rows[i]["sEmailId"].NulllToString();
                        user.JanAadharNo = dtuserData.Rows[i]["JanAadharNo"].NulllToString();
                        user.PartyId = dtuserData.Rows[i]["sPK_PrtyCode"].NulllToString();
                        user.ParentService = dtuserData.Rows[i]["ParentService"].NulllToString();
                        user.UserType = dtuserData.Rows[i]["UserType"].NulllToString();
                        user.State = dtuserData.Rows[i]["State"].NulllToString();
                        user.District = dtuserData.Rows[i]["District"].NulllToString();
                        user.City = dtuserData.Rows[i]["City"].NulllToString();
                        user.Status = dtuserData.Rows[i]["Status"].NulllToString();
                        user.ParentName = dtuserData.Rows[i]["ParentName"].NulllToString();

                    }
                    for (int i = 0; i < serviceData.Rows.Count; i++)
                    {
                        ServiceNameList service = new ServiceNameList();
                        service.ServiceName = serviceData.Rows[i]["ServiceName"].NulllToString();

                        serviceNames.Add(service);
                    }
                    for (int i = 0; i < hardwareData.Rows.Count; i++)
                    {
                        HardwareNameList hardwareName = new HardwareNameList();

                        hardwareName.HardwareName = hardwareData.Rows[i]["HardwareName"].NulllToString();

                        hardwareNames.Add(hardwareName);
                    }
                    for (int i = 0; i < documentData.Rows.Count; i++)
                    {
                        DocumentList document = new DocumentList();

                        document.PartyId = documentData.Rows[i]["sFK_PrtyCode"].NulllToString();
                        document.UploadDocumentUrl = documentData.Rows[i]["sUplodDcumntUrl"].NulllToString();
                        document.Name = documentData.Rows[i]["sName"].NulllToString();

                        documents.Add(document);
                    }
                    for (int i = 0; i < paymentData.Rows.Count; i++)
                    {
                        PaymentDetails payment = new PaymentDetails();

                        payment.PartyId = paymentData.Rows[i]["sPrtyCode"].NulllToString();
                        payment.Amount = paymentData.Rows[i]["Amount"].NulllToString();
                        payment.PaymentMode = paymentData.Rows[i]["PaymentMode"].NulllToString();
                        payment.PaymentStatus = paymentData.Rows[i]["PaymentStatus"].NulllToString();

                        payments.Add(payment);
                    }
                    objResponseData.ResponseCode = "000";
                    objResponseData.Message = "Details";
                    objResponseData.statusCode = 1;
                    objResponseData.Data = new
                    {
                        userDetails = user,
                        ServiceName = serviceNames,
                        HarwareName = hardwareNames,
                        Documents = documents,
                        PayDetails = payments
                    };

                }
                else
                {
                    objResponseData.ResponseCode = "001";
                    objResponseData.Message = "Not Saved...";
                    objResponseData.statusCode = -1;
                }

            }
            catch (Exception e)
            {
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetdetailsForUser", connectionString);
            }
            return objResponseData;
        }

        //For sending email with all details
        public UserDetailsData GetdetailsForUserforEmail(string email)
        {
            UserDetailsData userAllData = new UserDetailsData();
            try
            {

                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@email", email);
                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_MASTER_UserProfileAndPurcharseDetails_View]", param);
                UserModel user = new UserModel();
                List<ServiceNameList> serviceNames = new List<ServiceNameList>();
                List<HardwareNameList> hardwareNames = new List<HardwareNameList>();
                List<DocumentList> documents = new List<DocumentList>();
                List<PaymentDetails> payments = new List<PaymentDetails>();


                if (ds != null && ds.Tables != null)
                {
                    DataTable dtuserData = ds.Tables[0];
                    DataTable serviceData = ds.Tables[1];
                    DataTable hardwareData = ds.Tables[2];
                    DataTable documentData = ds.Tables[3];
                    DataTable paymentData = ds.Tables[4];


                    for (int i = 0; i < dtuserData.Rows.Count; i++)
                    {
                        user.Name = dtuserData.Rows[i]["Name"].NulllToString();
                        user.FirstName = dtuserData.Rows[i]["FirstName"].NulllToString();
                        user.MobileVerified = dtuserData.Rows[i]["MobileVerified"].NulllToInt();
                        user.AdhaarVerified = dtuserData.Rows[i]["AdhaarVerified"].NulllToInt();
                        user.PanVerified = dtuserData.Rows[i]["PanVerified"].NulllToInt();
                        user.EmailVerified = dtuserData.Rows[i]["EmailVerified"].NulllToInt();
                        user.PanCard = dtuserData.Rows[i]["PanCard"].NulllToString();
                        user.AdhaarCard = dtuserData.Rows[i]["AdhaarCard"].NulllToString();
                        user.MobileNumber = dtuserData.Rows[i]["MobileNumber"].NulllToString();
                        user.EmailId = dtuserData.Rows[i]["EmailId"].NulllToString();
                        user.JanAadharNo = dtuserData.Rows[i]["JanAadharNo"].NulllToString();
                        user.PartyId = dtuserData.Rows[i]["PartyId"].NulllToString();
                        user.ParentService = dtuserData.Rows[i]["ParentService"].NulllToString();
                        user.UserType = dtuserData.Rows[i]["UserType"].NulllToString();
                        user.State = dtuserData.Rows[i]["State"].NulllToString();
                        user.District = dtuserData.Rows[i]["District"].NulllToString();
                        user.City = dtuserData.Rows[i]["City"].NulllToString();
                        user.Status = dtuserData.Rows[i]["Status"].NulllToString();
                        user.ParentName = dtuserData.Rows[i]["ParentName"].NulllToString();
                    }
                    for (int i = 0; i < serviceData.Rows.Count; i++)
                    {
                        ServiceNameList service = new ServiceNameList();
                        service.ServiceName = serviceData.Rows[i]["ServiceName"].NulllToString();

                        serviceNames.Add(service);
                    }
                    for (int i = 0; i < hardwareData.Rows.Count; i++)
                    {
                        HardwareNameList hardwareName = new HardwareNameList();

                        hardwareName.HardwareName = hardwareData.Rows[i]["HardwareName"].NulllToString();

                        hardwareNames.Add(hardwareName);
                    }
                    for (int i = 0; i < documentData.Rows.Count; i++)
                    {
                        DocumentList document = new DocumentList();

                        document.PartyId = documentData.Rows[i]["PartyId"].NulllToString();
                        document.UploadDocumentUrl = documentData.Rows[i]["UploadDocumentUrl"].NulllToString();
                        document.Name = documentData.Rows[i]["Name"].NulllToString();

                        documents.Add(document);
                    }
                    for (int i = 0; i < paymentData.Rows.Count; i++)
                    {
                        PaymentDetails payment = new PaymentDetails();

                        payment.PartyId = paymentData.Rows[i]["PartyId"].NulllToString();
                        payment.Amount = paymentData.Rows[i]["Amount"].NulllToString();
                        payment.PaymentMode = paymentData.Rows[i]["PaymentMode"].NulllToString();
                        payment.PaymentStatus = paymentData.Rows[i]["PaymentStatus"].NulllToString();

                        payments.Add(payment);
                    }

                    userAllData.userDetails = user;
                    userAllData.serviceName = serviceNames;
                    userAllData.harwareName = hardwareNames;
                    userAllData.documents = documents;
                    userAllData.payDetails = payments;
                }
                else
                {
                    userAllData.userDetails = new UserModel();
                    userAllData.serviceName = new List<ServiceNameList>();
                    userAllData.harwareName = new List<HardwareNameList>();
                    userAllData.documents = new List<DocumentList>();
                    userAllData.payDetails = new List<PaymentDetails>();
                }
            }
            catch (Exception e)
            {
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetdetailsForUser", connectionString);

            }
            return userAllData;
        }
        public ResponseData RegisteredUserData()
        {
            try
            {
                List<RegistredUser> lstUserDetails = new List<RegistredUser>();


                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_ADMIN_Active_InactiveUser_View]");
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        RegistredUser userDetails = new RegistredUser();

                        userDetails.userType = ds.Tables[0].Rows[i]["UserType"].NulllToString();
                        userDetails.RegistrationNo = ds.Tables[0].Rows[i]["RegistrationNo"].NulllToString();
                        userDetails.PartyId = ds.Tables[0].Rows[i]["sPK_PrtyCode"].NulllToString();
                        userDetails.userName = ds.Tables[0].Rows[i]["UserName"].NulllToString();
                        userDetails.FirstName = ds.Tables[0].Rows[i]["sFstName"].NulllToString();
                        userDetails.MobileNumber = ds.Tables[0].Rows[i]["sMobileNo"].NulllToString();
                        userDetails.ServiceList = ds.Tables[0].Rows[i]["Servicecollection"].NulllToString();
                        userDetails.HardwareList = ds.Tables[0].Rows[i]["Hardwarecollection"].NulllToString();
                        userDetails.PaymentStatus = ds.Tables[0].Rows[i]["PaymentStatus"].NulllToString();
                        userDetails.EmailId = ds.Tables[0].Rows[i]["sEmailId"].NulllToString();
                        userDetails.IsActive = ds.Tables[0].Rows[i]["IsActive"].NulllToInt();
                        userDetails.Role = ds.Tables[0].Rows[i]["Role"].NulllToString();
                        userDetails.iRoleId = ds.Tables[0].Rows[i]["iRoleId"].NulllToInt();

                        lstUserDetails.Add(userDetails);
                    }
                    objResponseData.ResponseCode = "000";
                    objResponseData.Message = "Registered UserList";
                    objResponseData.statusCode = 1;
                    objResponseData.Data = lstUserDetails;
                }
                else
                {
                    objResponseData.ResponseCode = "001";
                    objResponseData.Message = "No Data Available...";
                    objResponseData.statusCode = -1;
                }
            }
            catch (Exception e)
            {
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : RegisteredUserData", connectionString);
            }
            return objResponseData;
        }
        public ResponseData ActiveInactiveUser(string PartyId, string status)
        {
            try
            {

                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@partyId", PartyId);
                param[1] = new SqlParameter("@status", status);

                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_ADMIN_UserActivationDeactivation_Update]", param);
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {

                    objResponseData.ResponseCode = "000";
                    objResponseData.statusCode = ds.Tables[0].Rows[0]["StatusCode"].NulllToInt();
                    objResponseData.Message = ds.Tables[0].Rows[0]["Message"].NulllToString();
                    objResponseData.Data = "";
                }
                else
                {
                    objResponseData.ResponseCode = "001";
                    objResponseData.Message = "No Data Available...";
                    objResponseData.statusCode = -1;
                }
            }
            catch (Exception e)
            {
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : ActiveInactiveUser", connectionString);
            }
            return objResponseData;
        }
        public ResponseData UpdateVerificationStatus(string PartyId, string colName, string colValue, int status)
        {
            try
            {

                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@partyId", PartyId.NulllToString());
                param[1] = new SqlParameter("@status", status.NulllToString());
                param[2] = new SqlParameter("@col", colName.NulllToString());
                param[3] = new SqlParameter("@colVal", (colValue == "" ? null : colValue.NulllToString()));


                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_ADMIN_UsersDocverification_Update]", param);
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {

                    objResponseData.ResponseCode = "000";
                    objResponseData.statusCode = 1;
                    objResponseData.Message = "Updated Successfully";
                    objResponseData.Data = "";
                }
                else
                {
                    objResponseData.ResponseCode = "001";
                    objResponseData.Message = "No Data Available...";
                    objResponseData.statusCode = -1;
                }
            }
            catch (Exception e)
            {
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : UpdateVerificationStatus", connectionString);
            }
            return objResponseData;
        }
     
    
     
    
        public ResponseData SaveAadhaarData(AadharWithPartyId aadhar)
        {
            try
            {
                if (aadhar.Aadhaar != null)
                {

                    SqlParameter[] param = new SqlParameter[13];
                    param[0] = new SqlParameter("@PartyId", aadhar.PartyId);
                    param[1] = new SqlParameter("@AadhaarName", aadhar.Aadhaar.data.full_name);
                    param[2] = new SqlParameter("@AadhaarCareOf", aadhar.Aadhaar.data.care_of);
                    param[3] = new SqlParameter("@AadhaarDist", aadhar.Aadhaar.data.address.dist);
                    param[4] = new SqlParameter("@AadhaarPO", aadhar.Aadhaar.data.address.po);
                    param[5] = new SqlParameter("@AadhaarLoc", aadhar.Aadhaar.data.address.loc);
                    param[6] = new SqlParameter("@AadhaarVtc", aadhar.Aadhaar.data.address.vtc);
                    param[7] = new SqlParameter("@AadhaarSubdist", aadhar.Aadhaar.data.address.subdist);
                    param[8] = new SqlParameter("@AadhaarStreet", aadhar.Aadhaar.data.address.street);
                    param[9] = new SqlParameter("@Aadhaarhouse", aadhar.Aadhaar.data.address.house);
                    param[10] = new SqlParameter("@Aadhaarlandmark", (aadhar.Aadhaar.data.address.landmark == null ? "NA" : aadhar.Aadhaar.data.address.landmark));
                    param[11] = new SqlParameter("@AadhaarPincode", aadhar.Aadhaar.data.zip);
                    param[12] = new SqlParameter("@AadhaarDOB", aadhar.Aadhaar.data.dob);
                    DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_MASTER_UserAdharCardDetails_SaveUpdate]", param);
                    if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                    {

                        objResponseData.ResponseCode = "000";
                        objResponseData.statusCode = 1;
                        objResponseData.Message = "Data Saved";
                        objResponseData.Data = "";
                    }
                    else
                    {
                        objResponseData.ResponseCode = "001";
                        objResponseData.Message = "No Data Available...";
                        objResponseData.statusCode = -1;
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : UpdateVerificationStatus", connectionString);
            }
            return objResponseData;
        }
        public ResponseData SavePurchaseData(AddPurchase purchase)
        {
            int order = purchase.OrderId.NulllToInt();
            var finalorderID = purchase.PartyId + "/" + DateTime.Now.ToString("dMyyyy") + "/" + (order + 1).ToString("d4");

            var result = "";
            var serviceCollection = "";

            double Totalpayableamt = 0;
            foreach (var item in purchase.PurchaseLists)
            {
                result = SavePurchase(purchase.PartyId, finalorderID, item);
                Totalpayableamt += item.TotalPrice.NulllToDouble() + item.GSTPrice.NulllToDouble();

                if (serviceCollection == "")
                {
                    if (item.Type == 1)
                    {
                        serviceCollection = item.CategoryID;
                    }
                }
                else
                {
                    if (item.Type == 1)
                    {
                        serviceCollection += "," + item.CategoryID;
                    }
                }
            }

            foreach (var item in purchase.PurchaseLists)
            {
                SaveOrderBooking(purchase.PartyId, finalorderID, item);
            }

            UpdateServiceCollectionPartyMaster(purchase.PartyId, serviceCollection, purchase.appTandCId.ToString());

            SavePaymentTracking(purchase.PartyId, finalorderID, Totalpayableamt.NulllToString());


            if (result == "Saved...")
            {
                objResponseData.ResponseCode = "000";
                objResponseData.Message = "Details Saved...";
                objResponseData.statusCode = 1;
                objResponseData.UserID = finalorderID;
            }
            else
            {
                objResponseData.ResponseCode = "001";
                objResponseData.Message = "Details Not Saved...";
                objResponseData.statusCode = -1;
            }


            return objResponseData;
        }
        public void SaveOrderBooking(string partyId, string orderId, PurchaseList purchases)
        {

            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@OrderId", orderId);
            param[1] = new SqlParameter("@TypeId", purchases.Type);
            param[2] = new SqlParameter("@ServiceHardwareAmount", purchases.TotalPrice);
            param[3] = new SqlParameter("@ServiceHardwareTaxAmount", purchases.GSTPrice);
            param[4] = new SqlParameter("@PartyId", partyId);
            DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_OPERATION_OrderBooking_Save]", param);
            if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
            {
                objResponseData.ResponseCode = "000";
                objResponseData.Message = "Details Saved...";
                objResponseData.statusCode = 1;

            }
            else
            {
                objResponseData.ResponseCode = "001";
                objResponseData.Message = "Details Not Saved...";
                objResponseData.statusCode = -1;
            }

        }
        public string SavePurchase(string partyId, string orderId, PurchaseList purchase)
        {

            try
            {

                SqlParameter[] param = new SqlParameter[5];
                param[0] = new SqlParameter("@PartyId", partyId);
                param[1] = new SqlParameter("@OrderId", orderId);
                param[2] = new SqlParameter("@ServiceHardwareId", purchase.CategoryID);
                param[3] = new SqlParameter("@TypeId", purchase.Type);
                param[4] = new SqlParameter("@IsActive", 1);
                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_MASTER_AddPurchaseDetails_Save]", param);
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    objResponseData.ResponseCode = "000";
                    objResponseData.Message = "Details Saved...";
                    objResponseData.statusCode = 1;

                }
                else
                {
                    objResponseData.ResponseCode = "001";
                    objResponseData.Message = "Details Not Saved...";
                    objResponseData.statusCode = -1;
                }
            }
            catch (Exception e)
            {
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : SavePurchase", connectionString);
            }

            return "Saved...";

        }
        public string SavePaymentTracking(string partyId, string orderId, string TotalAmount)
        {

            try
            {

                SqlParameter[] param = new SqlParameter[17];
                param[0] = new SqlParameter("@OrderId", orderId);
                param[1] = new SqlParameter("@PayableAmount", TotalAmount);
                param[2] = new SqlParameter("@TransactionAmt", "0");
                param[3] = new SqlParameter("@BalancaAmt", TotalAmount);
                param[4] = new SqlParameter("@Mode", "704");
                param[5] = new SqlParameter("@PaymentMode", "703");
                param[6] = new SqlParameter("@Bank", "");
                param[7] = new SqlParameter("@BankUTR", "");
                param[8] = new SqlParameter("@Account", "");
                param[9] = new SqlParameter("@UPI", "");
                param[10] = new SqlParameter("@ChequeNo", "");
                param[11] = new SqlParameter("@CollectedBy", "");
                param[12] = new SqlParameter("@CurrentStatus", "");
                param[13] = new SqlParameter("@Narration", "");
                param[14] = new SqlParameter("@PaymentStatus", "2");
                param[15] = new SqlParameter("@PartyId", partyId);
                param[16] = new SqlParameter("@ChequeStatus", "0");
                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_ADMIN_UserPaymentTracking_Save]", param);
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    objResponseData.ResponseCode = "000";
                    objResponseData.Message = "Details Saved...";
                    objResponseData.statusCode = 1;

                }
                else
                {
                    objResponseData.ResponseCode = "001";
                    objResponseData.Message = "Details Not Saved...";
                    objResponseData.statusCode = -1;
                }

            }
            catch (Exception e)
            {
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : SavePurchase", connectionString);
            }

            return "Saved...";

        }
        public string UpdateServiceCollectionPartyMaster(string partyId, string ServiceCollection, string TnCID)
        {

            try
            {

                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@partyId", partyId);
                param[1] = new SqlParameter("@serviceCollection", ServiceCollection);
                param[2] = new SqlParameter("@TnCId", TnCID);
                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_OPERATION_CheckoutListUpdate_Update]", param);
                if (ds != null && ds.Tables != null)
                {
                    objResponseData.ResponseCode = "000";
                    objResponseData.Message = "Details Saved...";
                    objResponseData.statusCode = 1;

                }
                else
                {
                    objResponseData.ResponseCode = "001";
                    objResponseData.Message = "Details Not Saved...";
                    objResponseData.statusCode = -1;
                }

            }
            catch (Exception e)
            {
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : SavePurchase", connectionString);
            }

            return "Saved...";

        }
        public ResponseData SaveContentData(ContentPage content)
        {
            try
            {

                SqlParameter[] param = new SqlParameter[8];
                param[0] = new SqlParameter("@PageTitle", content.PageTitle);
                param[1] = new SqlParameter("@PageImage", content.PageImage);
                param[2] = new SqlParameter("@PageKeywords", content.PageKeywords);
                param[3] = new SqlParameter("@MetaDescription", content.MetaDescription);
                param[4] = new SqlParameter("@PageContent", content.PageContent);
                param[5] = new SqlParameter("@PageURL", content.PageURL);
                param[6] = new SqlParameter("@enumId", content.EnumId);
                param[7] = new SqlParameter("@createdBy", "Admin");

                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_ADMIN_PageTemplate_Save]", param);
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    objResponseData.ResponseCode = "000";
                    objResponseData.Message = "Content Saved...";
                    objResponseData.statusCode = 1;
                }
                else
                {
                    objResponseData.ResponseCode = "001";
                    objResponseData.Message = "No Data Available...";
                    objResponseData.statusCode = -1;
                }
            }
            catch (Exception e)
            {
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : SaveContentData", connectionString);
            }
            return objResponseData;
        }
        public ResponseData EditContentData(ContentPage content)
        {
            try
            {

                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@type", content.Type);
                param[1] = new SqlParameter("@id", content.Id);
                param[2] = new SqlParameter("@Content", content.PageContent == null ? "" : content.PageContent.TrimStart());
                param[3] = new SqlParameter("@updatedBy", "Admin");

                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_ADMIN_PageTemplate_UpdateView]", param);
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    objResponseData.ResponseCode = "000";
                    objResponseData.Message = "Content Updated Successfully...";
                    objResponseData.statusCode = 1;
                    objResponseData.Data = ds.Tables[0];

                }
                else
                {
                    objResponseData.ResponseCode = "001";
                    objResponseData.Message = "No Data Available...";
                    objResponseData.statusCode = -1;
                }
            }
            catch (Exception e)
            {
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : EditContentData", connectionString);
            }
            return objResponseData;
        }

        //public ResponseData MyPayment(string partyId)
        //{
        //    try
        //    {
        //        List<MyPayment> myPaymentList = new List<MyPayment>();

        //        SqlParameter[] param = new SqlParameter[1];
        //        param[0] = new SqlParameter("@partyId", partyId == "" ? null : partyId);                
        //        DataSet ds = BaseFunction.FillDataSet("[dbo].[sp_MyPayment]", param);                
        //        if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
        //        {
        //            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //            {
        //                MyPayment myPayment = new MyPayment();
        //                myPayment.OrderNo = ds.Tables[0].Rows[i]["OrderNo"].NulllToString();
        //                myPayment.OrderDate = ds.Tables[0].Rows[i]["OrderDate"].NulllToString();
        //                myPayment.item = ds.Tables[0].Rows[i]["item"].NulllToString();
        //                myPayment.TransectionAmount = ds.Tables[0].Rows[i]["TransAmount"].NulllToString();
        //                myPayment.BalanceAmount = ds.Tables[0].Rows[i]["BalAmount"].NulllToString();
        //                myPayment.PaymentMode = ds.Tables[0].Rows[i]["PaymentMode"].NulllToString();
        //                myPayment.PaymentStatus = ds.Tables[0].Rows[i]["PaymentStatus"].NulllToString();
        //                myPaymentList.Add(myPayment);
        //            }
        //            objResponseData.ResponseCode = "000";
        //            objResponseData.Message = "Payment List";
        //            objResponseData.statusCode = 1;
        //            objResponseData.Data = myPaymentList;

        //        }
        //        else
        //        {
        //            objResponseData.ResponseCode = "001";
        //            objResponseData.Message = "No Data Available...";
        //            objResponseData.statusCode = -1;
        //        }                
        //    }
        //    catch (Exception e)
        //    {
        //        ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : MyPayment", connectionString);
        //    }
        //    return objResponseData;
        //}
        public ResponseData MyPaymentOnScroll(int pageNumber, int pageSize, string PartyId)
        {
            try
            {
                List<MyPayment> myPaymentList = new List<MyPayment>();

                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@PageIndex", pageNumber);
                param[1] = new SqlParameter("@PageSize", pageSize);
                param[2] = new SqlParameter("@PartyId", PartyId);
                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_REPORT_GetAllPaymentUserWise_View]", param);
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        MyPayment myPayment = new MyPayment();

                        myPayment.OrderNo = ds.Tables[0].Rows[i]["OrderNo"].NulllToString();
                        myPayment.OrderDate = ds.Tables[0].Rows[i]["OrderDate"].NulllToString();
                        myPayment.item = ds.Tables[0].Rows[i]["item"].NulllToString();
                        myPayment.TransectionAmount = ds.Tables[0].Rows[i]["TransAmount"].NulllToString();
                        myPayment.BalanceAmount = ds.Tables[0].Rows[i]["BalAmount"].NulllToString();
                        myPayment.PaymentMode = ds.Tables[0].Rows[i]["PaymentMode"].NulllToString();
                        myPayment.PaymentStatus = ds.Tables[0].Rows[i]["PaymentStatus"].NulllToString();

                        myPaymentList.Add(myPayment);
                    }
                    objResponseData.ResponseCode = "000";
                    objResponseData.Message = "Payment List";
                    objResponseData.statusCode = 1;
                    objResponseData.Data = myPaymentList;

                }
                else
                {
                    objResponseData.ResponseCode = "001";
                    objResponseData.Message = "No Data Available...";
                    objResponseData.statusCode = -1;
                }

            }
            catch (Exception e)
            {
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : MyPayment", connectionString);
            }
            return objResponseData;
        }
        public ResponseData GetCategoryAllInformation(string Type)
        {
            try
            {
                List<GetservicesetailsAndroidNew> ServieDetailsList = new List<GetservicesetailsAndroidNew>();

                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@type", Type);

                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_ADMIN_ServiceConfigurationDetails_View]", param);
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        GetservicesetailsAndroidNew ServieDetails = new GetservicesetailsAndroidNew();


                        var serviceName = ds.Tables[0].Rows[i]["sCatName"].NulllToString();

                        var serviceIconImage = serviceName.Trim().Replace(" ", "_");
                        serviceIconImage = serviceIconImage.Replace("-", "_");
                        serviceIconImage = BaseURL + serviceIconImage + ".png";

                        ServieDetails.CategoryId = ds.Tables[0].Rows[i]["iFK_CatId"].NulllToString();
                        ServieDetails.TypeName = ds.Tables[0].Rows[i]["sTypNm"].NulllToString();
                        ServieDetails.GstAmount = ds.Tables[0].Rows[i]["dGstAmnt"].NulllToDecimal();
                        ServieDetails.IGST = ds.Tables[0].Rows[i]["dIGST"].NulllToDecimal();
                        ServieDetails.CGST = ds.Tables[0].Rows[i]["dCGST"].NulllToDecimal();
                        ServieDetails.ServiceCharges = ds.Tables[0].Rows[i]["dSrvcChrgs"].NulllToDecimal();
                        ServieDetails.CourierCharges = ds.Tables[0].Rows[i]["dCrrChrgs"].NulllToDecimal();
                        ServieDetails.TotalAmount = ds.Tables[0].Rows[i]["dTotalAmnt"].NulllToDecimal();
                        ServieDetails.CategoryName = ds.Tables[0].Rows[i]["sCatName"].NulllToString();
                        ServieDetails.Createddate = ds.Tables[0].Rows[i]["dtCrtdDt"].NulllToDateTime();
                        ServieDetails.IsActive = ds.Tables[0].Rows[i]["iIsActv"].NulllToInt();
                        ServieDetails.services = ds.Tables[0].Rows[i]["services"].NulllToString();
                        ServieDetails.ServiceIcon = serviceIconImage;


                        ServieDetailsList.Add(ServieDetails);
                    }
                    objResponseData.ResponseCode = "000";
                    objResponseData.Message = "Service List";
                    objResponseData.statusCode = 1;
                    objResponseData.Data = ServieDetailsList;

                }
                else
                {
                    objResponseData.ResponseCode = "001";
                    objResponseData.Message = "No Data Available...";
                    objResponseData.statusCode = -1;
                }
            }
            catch (Exception e)
            {
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetCategoryAllInformation", connectionString);
            }
            return objResponseData;
        }
        public ResponseData GetUserType()

        {
            try
            {
                List<Dropdown> ddlList = new List<Dropdown>();
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@type", "UserType");
                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_ADMIN_GetMasterDataForDropdown_View]", param);
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        Dropdown ddl = new Dropdown();

                        ddl.Id = ds.Tables[0].Rows[i]["Id"].NulllToString();
                        ddl.Text = ds.Tables[0].Rows[i]["text"].NulllToString();
                        ddlList.Add(ddl);
                    }
                    objResponseData.ResponseCode = "000";
                    objResponseData.Message = "UserType List";
                    objResponseData.statusCode = 1;
                    objResponseData.Data = ddlList;
                }
                else
                {
                    objResponseData.ResponseCode = "001";
                    objResponseData.Message = "No Data Available...";
                    objResponseData.statusCode = -1;
                }

            }
            catch (Exception e)
            {
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetUserType", connectionString);
            }
            return objResponseData;
        }
        public ResponseData SaveGeoGraphical(GeographicalMaster graphical)
        {
            try
            {

                SqlParameter[] param = new SqlParameter[8];
                param[0] = new SqlParameter("@CountryId", graphical.CountryId);
                param[1] = new SqlParameter("@StateId", graphical.StateId);
                param[2] = new SqlParameter("@DistrictId", graphical.DistrictId);
                param[3] = new SqlParameter("@CityId", graphical.CityId);
                param[4] = new SqlParameter("@AreaId", graphical.AreaId);
                param[5] = new SqlParameter("@Name", graphical.Name);
                param[6] = new SqlParameter("@PinCode", graphical.PinCode);
                param[7] = new SqlParameter("@type", graphical.Type);
                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_ADMIN_GeographicalData_Save]", param);
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    objResponseData.ResponseCode = "000";
                    objResponseData.Message = ds.Tables[0].Rows[0]["Message"].NulllToString();
                    objResponseData.statusCode = ds.Tables[0].Rows[0]["StatusCode"].NulllToInt();

                }
                else
                {
                    objResponseData.ResponseCode = "001";
                    objResponseData.Message = "No Data Available...";
                    objResponseData.statusCode = -1;
                }

            }
            catch (Exception e)
            {
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : SaveGeoGraphical", connectionString);
            }
            return objResponseData;
        }
        public ResponseData GetGeoGraphical(GeographicalMaster graphical)
        {
            try
            {

                SqlParameter[] param = new SqlParameter[5];
                param[0] = new SqlParameter("@type", graphical.Type);
                param[1] = new SqlParameter("@countryId", graphical.CountryId);
                param[2] = new SqlParameter("@stateID", graphical.StateId);
                param[3] = new SqlParameter("@DistrictID", graphical.DistrictId);
                param[4] = new SqlParameter("@CityId", graphical.CityId);

                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_ADMIN_GetGeoDataForDropdownConditionally_View]", param);
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    objResponseData.ResponseCode = "000";
                    objResponseData.Message = graphical.Type + " List";
                    objResponseData.statusCode = 1;
                    objResponseData.Data = ds.Tables[0];
                }
                else
                {
                    objResponseData.ResponseCode = "001";
                    objResponseData.Message = "No Data Available...";
                    objResponseData.statusCode = -1;
                }
            }
            catch (Exception e)
            {
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetGeoGraphical", connectionString);
            }
            return objResponseData;
        }
        public ResponseData GetDocumentLibraryData(string Type, int companyId)
        {
            try
            {

                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@type", Type);
                param[1] = new SqlParameter("@companyID", companyId);

                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_ADMIN_DocumentLibrary_View]", param);
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    objResponseData.ResponseCode = "000";
                    objResponseData.Message = Type + " List";
                    objResponseData.statusCode = 1;
                    objResponseData.Data = ds.Tables[0];
                }
                else
                {
                    objResponseData.ResponseCode = "001";
                    objResponseData.Message = "No Data Available...";
                    objResponseData.statusCode = -1;
                }
            }
            catch (Exception e)
            {
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetDocumentLibraryData", connectionString);
            }
            return objResponseData;
        }
        public ResponseData SaveDocumentList(List<DocumentLibraryMaster> documents)
        {
            try
            {
                var totalrowsForTransection = documents.Count;

                DeleteDocument(documents[0].CompanyID);
                int transectionDone = 0;


                foreach (var items in documents)
                {
                    transectionDone += SaveDocument(items);
                }
                if (totalrowsForTransection == transectionDone)
                {
                    objResponseData.ResponseCode = "000";
                    objResponseData.Message = "Document Saved...!";
                    objResponseData.statusCode = 1;
                }

            }
            catch (Exception e)
            {
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : SaveDocumentList", connectionString);
            }
            return objResponseData;
        }
        public int SaveDocument(DocumentLibraryMaster document)
        {
            try
            {

                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@companyTypeID", document.CompanyID);
                param[1] = new SqlParameter("@customEnumID", document.DocumentID);
                param[2] = new SqlParameter("@isMandatory", document.isMandatory);
                param[3] = new SqlParameter("@isActive", document.isActive);

                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_ADMIN_DocumentSetting_SaveUpdate]", param);
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    objResponseData.ResponseCode = "000";
                    objResponseData.Message = ds.Tables[0].Rows[0]["Message"].NulllToString();
                    objResponseData.statusCode = ds.Tables[0].Rows[0]["StatusCode"].NulllToInt();
                }
                else
                {
                    objResponseData.ResponseCode = "001";
                    objResponseData.Message = "No Data Available...";
                    objResponseData.statusCode = -1;
                }
            }
            catch (Exception e)
            {
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : SaveDocument", connectionString);
            }
            return 1;
        }
        public int DeleteDocument(string companyID)
        {
            try
            {

                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@companyTypeID", companyID);

                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_MASTER_DeleteExistsingDocumentList_Delete]", param);
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    objResponseData.ResponseCode = "000";
                    objResponseData.Message = ds.Tables[0].Rows[0]["Message"].NulllToString();
                    objResponseData.statusCode = ds.Tables[0].Rows[0]["StatusCode"].NulllToInt();
                }
                else
                {
                    objResponseData.ResponseCode = "001";
                    objResponseData.Message = "No Data Available...";
                    objResponseData.statusCode = -1;
                }
            }
            catch (Exception e)
            {

                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : DeleteDocument", connectionString);
            }
            return 1;
        }
        public ResponseData GetGeoGraphicalList()
        {
            try
            {

                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_ADMIN_GeoDataList_View]");
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    objResponseData.ResponseCode = "000";
                    objResponseData.Message = "Geographical  List";
                    objResponseData.statusCode = 1;
                    objResponseData.Data = ds.Tables[0];
                }
                else
                {
                    objResponseData.ResponseCode = "001";
                    objResponseData.Message = "No Data Available...";
                    objResponseData.statusCode = -1;
                }
            }
            catch (Exception e)
            {
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetGeoGraphicalList", connectionString);
            }
            return objResponseData;
        }
        public UploadDoc UploadRequiredDocuments(UploadDoc doc)
        {
            var status = "0";
            var serverImagePath = "";
            try
            {
                var relativPath = "\\wwwroot\\images";
                var extention = ".jpg";

                var imageUploadPath = Path.Combine(Directory.GetCurrentDirectory() + relativPath, doc.PartyId + "_" + doc.DocumentName + extention);

                if (File.Exists(imageUploadPath))
                {
                    File.Delete(imageUploadPath);
                    File.WriteAllBytes(imageUploadPath, doc.Image);
                }
                else
                {
                    File.WriteAllBytes(imageUploadPath, doc.Image);
                }

                var splittedRelativepath = relativPath.Split("\\");

                //var host = _httpContext.HttpContext.Request.Host;

                serverImagePath = "/" +
                   splittedRelativepath[2].ToString() + "/" + doc.PartyId + "_" + doc.DocumentName + extention; // /images/<filename>.jpg



                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@PartyId", doc.PartyId);
                param[1] = new SqlParameter("@UploadDocumentUrl", serverImagePath);
                param[2] = new SqlParameter("@DocumentType", doc.DocumentID);
                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_MASTER_DocumentUpload_Save]", param);
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    objResponseData.ResponseCode = "000";
                    objResponseData.Message = "Details Saved...";
                    objResponseData.statusCode = 1;
                    status = "1";
                }
                else
                {
                    objResponseData.ResponseCode = "001";
                    objResponseData.Message = "Details Not Saved...";
                    objResponseData.statusCode = -1;
                    status = "-1";
                }

            }
            catch (Exception ex)
            { }
            return new UploadDoc
            {
                DocumentName = doc.DocumentName,
                ImageURL = serverImagePath,
                DocumentID = status
            };
        }
        public ResponseData GetAllSettings(string Id = null)
        {
            try
            {

                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@Id", Id);

                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_ADMIN_CustomFieldSetting_View]", param);
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    objResponseData.ResponseCode = "000";
                    if (Id == null)
                        objResponseData.Message = "Settings  List";
                    else
                        objResponseData.Message = "Setting";

                    objResponseData.statusCode = 1;
                    objResponseData.Data = ds.Tables[0];
                }
                else
                {
                    objResponseData.ResponseCode = "001";
                    objResponseData.Message = "No Data Available...";
                    objResponseData.statusCode = -1;
                }
            }
            catch (Exception e)
            {
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetAllSettings", connectionString);
            }
            return objResponseData;
        }
        public ResponseData UpdateSetting(Settings settings)
        {
            try
            {


                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@id", settings.Id);
                param[1] = new SqlParameter("@name", settings.SettingName);
                param[2] = new SqlParameter("@status", settings.IsActive);
                param[3] = new SqlParameter("@type", settings.Type);
                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_MASTER_ManageMainSetting_Update]", param);
                if (ds != null && ds.Tables != null)
                {
                    objResponseData.ResponseCode = "000";
                    if (settings.Type == "Search")
                    {
                        objResponseData.Data = ds.Tables[0];
                        objResponseData.Message = ds.Tables[1].Rows[0][1].NulllToString();
                    }
                    else
                    {
                        objResponseData.Data = new DataTable();
                        objResponseData.Message = ds.Tables[0].Rows[0][1].NulllToString();
                    }

                    objResponseData.statusCode = 1;
                }
                else
                {
                    objResponseData.ResponseCode = "001";
                    objResponseData.Message = "No Data Available...";
                    objResponseData.statusCode = -1;
                }

            }
            catch (Exception e)
            {
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : UpdateSetting", connectionString);
            }
            return objResponseData;
        }
        public ResponseData GetPermissionDetails(int RoleId, int DepartmentId)
        {
            try
            {

                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@roleId", RoleId);
                param[1] = new SqlParameter("@deptId", DepartmentId);

                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_ADMIN_PremissionDetails_View]", param);
                if (ds != null && ds.Tables != null)
                {
                    objResponseData.ResponseCode = "000";

                    objResponseData.Data = ds.Tables[0];
                    objResponseData.Message = ds.Tables[0].Rows[0][1].NulllToString();
                    objResponseData.statusCode = 1;
                }
                else
                {
                    objResponseData.ResponseCode = "001";
                    objResponseData.Message = "No Data Available...";
                    objResponseData.statusCode = -1;
                }
            }
            catch (Exception e)
            {
                ExceptionLogDL.LogWrite("GetPermissionDetails:" + e.Message);
                //LogWriter.LogWrite(ex.Message);
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetPermissionDetails", connectionString);
            }
            return objResponseData;
        }
        public ResponseData GetMenusAndSubmenus(string Type, string MenuId, string partyid)
        {
            try
            {

                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@type", Type);
                param[1] = new SqlParameter("@menuId", MenuId);
                param[2] = new SqlParameter("@PartyId", partyid);

                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_ADMIN_GetMasterDataForDropdown_View]", param);
                if (ds != null && ds.Tables != null)
                {
                    objResponseData.ResponseCode = "000";
                    objResponseData.Data = ds.Tables[0];
                    objResponseData.Message = "Data Fetched Successfully...!";
                    objResponseData.statusCode = 1;
                }
                else
                {
                    objResponseData.ResponseCode = "001";
                    objResponseData.Message = "No Data Available...";
                    objResponseData.statusCode = -1;
                }
            }
            catch (Exception e)
            {
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetMenus", connectionString);
            }
            return objResponseData;
        }
        public Dropdown GetEmailTemplate(string Type, string MenuId = null, string partyid = null)
        {
            Dropdown dropdown = new Dropdown();
            try
            {

                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@type", Type);
                param[1] = new SqlParameter("@menuId", MenuId);
                param[2] = new SqlParameter("@PartyId", partyid);

                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_ADMIN_GetMasterDataForDropdown_View]", param);
                if (ds != null && ds.Tables != null)
                {
                    dropdown.Id = ds.Tables[0].Rows[0][0].ToString();
                    dropdown.Text = ds.Tables[0].Rows[0][1].ToString();
                }
                else
                {
                    return new Dropdown();
                }
            }
            catch (Exception e)
            {
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetMenus", connectionString);
            }
            return dropdown;
        }
        public int UpdateDisplayOrderID(int DisplayorderID, int submenuId)
        {
            int s = 0;
            try
            {

                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@DisplayOrderID", DisplayorderID);
                param[1] = new SqlParameter("@submenuID", submenuId);

                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_MASTER_ManageSubmenuDisplayOrder_Update]", param);
                if (ds != null && ds.Tables != null)
                {
                    //objResponseData.ResponseCode = "000";
                    //objResponseData.Message = ds.Tables[0].Rows[0][1].ToString();
                    //objResponseData.statusCode = 1;
                    s = 1;
                }
                else
                {
                    //objResponseData.ResponseCode = "001";
                    //objResponseData.Message = "No Data Available...";
                    //objResponseData.statusCode = -1;
                    s = 0;
                }
            }
            catch (Exception e)
            {
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : UpdateDisplayID", connectionString);
            }
            return s;
        }
        public ResponseData UpdateDisplayID(string Ids)
        {

            var IDs = Ids.Split(',');
            var TotalCount = IDs.Length;
            var Status = 0;
            var newSubmenuId = 1;
            if (IDs != null)
            {
                foreach (var item in IDs)
                {
                    if (item != "")
                    {
                        Status += UpdateDisplayOrderID(newSubmenuId, item.NulllToInt());
                        newSubmenuId = newSubmenuId + 1;
                    }
                }
            }
            if (TotalCount == Status)
            {
                objResponseData.ResponseCode = "000";
                objResponseData.Message = "Details Updated Successfully...!";
                objResponseData.statusCode = 1;
            }
            else
            {
                objResponseData.ResponseCode = "001";
                objResponseData.Message = "No Data Available...";
                objResponseData.statusCode = -1;
            }


            return objResponseData;
        }
        public ResponseData AddGroup(AddGroup group)
        {
            try
            {

                SqlParameter[] param = new SqlParameter[7];
                param[0] = new SqlParameter("@GroupId", group.GroupID);
                param[1] = new SqlParameter("@GroupName", group.GroupName);
                param[2] = new SqlParameter("@MenuID", group.MenuID);
                param[3] = new SqlParameter("@SubmenuId", group.SubmenuId);
                param[4] = new SqlParameter("@PartyId", group.PartyId);
                param[5] = new SqlParameter("@CreatedBy", group.PartyId);
                param[6] = new SqlParameter("@type", group.Type);

                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_ADMIN_CreateNewGroup_SaveUpdate]", param);

                if (ds != null && ds.Tables != null)
                {
                    objResponseData.ResponseCode = "000";

                    objResponseData.Data = ds.Tables[0];
                    objResponseData.Message = ds.Tables[0].Rows[0][1].NulllToString();
                    objResponseData.statusCode = 1;
                }
                else
                {
                    objResponseData.ResponseCode = "001";
                    objResponseData.Message = "No Data Available...";
                    objResponseData.statusCode = -1;
                }

            }
            catch (Exception e)
            {
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : AddGroup", connectionString);
            }
            return objResponseData;
        }
        public ResponseData AddDepartment(AddDepartment department)
        {
            try
            {

                SqlParameter[] param = new SqlParameter[5];
                param[0] = new SqlParameter("@DepartmentId", department.DepartmentID);
                param[1] = new SqlParameter("@DepartmentName", department.DepartmentName);
                param[2] = new SqlParameter("@PartyId", department.PartyId);
                param[3] = new SqlParameter("@CreatedBy", department.PartyId);
                param[4] = new SqlParameter("@type", department.Type);


                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_ADMIN_CreateNewDepartment_Save]", param);
                if (ds != null && ds.Tables != null)
                {
                    objResponseData.ResponseCode = "000";

                    objResponseData.Data = ds.Tables[0];
                    objResponseData.Message = ds.Tables[0].Rows[0][1].NulllToString();
                    objResponseData.statusCode = 1;
                }
                else
                {
                    objResponseData.ResponseCode = "001";
                    objResponseData.Message = "No Data Available...";
                    objResponseData.statusCode = -1;
                }

            }
            catch (Exception e)
            {
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : AddDepartment", connectionString);
            }
            return objResponseData;
        }
        public ResponseData GetAadhaarData(string partyID)
        {
            try
            {


                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@partyID", partyID);

                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_MASTER_GetAadhaarDetail_View]", param);
                if (ds != null && ds.Tables != null)
                {
                    objResponseData.ResponseCode = "000";

                    objResponseData.Data = ds.Tables[0];
                    objResponseData.Message = ds.Tables[0].Rows[0][1].NulllToString();
                    objResponseData.statusCode = 1;
                }
                else
                {
                    objResponseData.ResponseCode = "001";
                    objResponseData.Message = "No Data Available...";
                    objResponseData.statusCode = -1;
                }

            }
            catch (Exception e)
            {
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetAadhaarData", connectionString);
            }
            return objResponseData;
        }
        public ResponseData AddPartnerDetails(PartyMaster party)
        {
            try
            {

                SqlParameter[] param = new SqlParameter[9];
                param[0] = new SqlParameter("@FirstName", party.FirstName);
                param[1] = new SqlParameter("@MiddleName", party.MiddleName);
                param[2] = new SqlParameter("@LastName", party.LastName);
                param[3] = new SqlParameter("@MobileNumber", party.MobileNumber);
                param[4] = new SqlParameter("@EmailId", party.EmailId);
                param[5] = new SqlParameter("@Type", party.Type);
                param[6] = new SqlParameter("@Password", party.Password);
                param[7] = new SqlParameter("@ParentId", party.ParentId);
                param[8] = new SqlParameter("@username", party.Name);

                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_MASTER_NewPartner_Save]", param);
                if (ds != null && ds.Tables != null)
                {
                    objResponseData.ResponseCode = "000";

                    objResponseData.Data = ds.Tables[0];
                    objResponseData.Message = ds.Tables[0].Rows[0][1].NulllToString();
                    objResponseData.statusCode = 1;
                    objResponseData.UserID = ds.Tables[0].Rows[0]["userID"].NulllToString();
                }
                else
                {
                    objResponseData.ResponseCode = "001";
                    objResponseData.Message = "No Data Available...";
                    objResponseData.statusCode = -1;
                    objResponseData.UserID = "";
                }

            }
            catch (Exception e)
            {
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : AddPartnerDetails", connectionString);
            }
            return objResponseData;
        }
        public ResponseData AddSystemUserDetails(PartyMaster party)
        {
            try
            {

                SqlParameter[] param = new SqlParameter[11];
                param[0] = new SqlParameter("@FirstName", party.FirstName);
                param[1] = new SqlParameter("@MobileNumber", party.MobileNumber);
                param[2] = new SqlParameter("@EmailId", party.EmailId);
                param[3] = new SqlParameter("@Type", (party.Type == null ? 5 : party.Type));
                param[4] = new SqlParameter("@Password", party.Password);
                param[5] = new SqlParameter("@roleId", party.RoleId);
                param[6] = new SqlParameter("@userName", party.FirstName);
                param[7] = new SqlParameter("@ParentId", party.ParentId);
                param[8] = new SqlParameter("@DistId", party.DistrictId);
                param[9] = new SqlParameter("@tehsilId", party.CityId);
                param[10] = new SqlParameter("@loclvl", party.loclvl);

                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_MASTER_SystemUser_Save]", param);
                if (ds != null && ds.Tables != null)
                {
                    objResponseData.ResponseCode = "000";

                    objResponseData.Data = ds.Tables[0];
                    objResponseData.Message = ds.Tables[0].Rows[0][1].NulllToString();
                    objResponseData.statusCode = 1;
                    objResponseData.UserID = ds.Tables[0].Rows[0]["userID"].NulllToString();
                }
                else
                {
                    objResponseData.ResponseCode = "001";
                    objResponseData.Message = "No Data Available...";
                    objResponseData.statusCode = -1;
                    objResponseData.UserID = "";
                }
            }
            catch (Exception e)
            {
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : AddSystemUserDetails", connectionString);
            }
            return objResponseData;
        }
        public ResponseData AddAPIReqRes(APIReqResModal reqResModal)
        {
            try
            {

                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@TransactionId", reqResModal.TransactionId);
                param[1] = new SqlParameter("@API_Request", reqResModal.API_Request);
                param[2] = new SqlParameter("@API_Response", reqResModal.API_Response);
                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_OPERATION_APIReqRes_Save]", param);
                if (ds != null && ds.Tables != null)
                {
                    objResponseData.ResponseCode = "000";
                    objResponseData.Data = ds.Tables[0];
                    objResponseData.Message = ds.Tables[0].Rows[0][1].NulllToString();
                    objResponseData.statusCode = 1;
                }
                else
                {
                    objResponseData.ResponseCode = "001";
                    objResponseData.Message = "No Data Available...";
                    objResponseData.statusCode = -1;
                }

            }
            catch (Exception e)
            {
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : AddAPIReqRes", connectionString);
            }
            return objResponseData;
        }
        #endregion

        #region Transection Table data
        public ResponseData SaveTransection(TransectionMasterRequest transectionMasterRequest)
        {
            try
            {

                SqlParameter[] param = new SqlParameter[19];
                param[0] = new SqlParameter("@transectionId", transectionMasterRequest.TransectionId);
                param[1] = new SqlParameter("@transectionAMT", transectionMasterRequest.TransectionAmount);
                param[2] = new SqlParameter("@refrenceId", transectionMasterRequest.RefrenceId);
                param[3] = new SqlParameter("@partyId", transectionMasterRequest.PartyId);
                param[4] = new SqlParameter("@usertype", transectionMasterRequest.UserType);
                param[5] = new SqlParameter("@operatorID", transectionMasterRequest.OperatorId);
                param[6] = new SqlParameter("@serviceId", transectionMasterRequest.ServicetypeId);
                param[7] = new SqlParameter("@serviceproviderId", transectionMasterRequest.ServiceProviderId);
                param[8] = new SqlParameter("@CGST", 9);
                param[9] = new SqlParameter("@SGST", 9);
                param[10] = new SqlParameter("@TDS", 5);
                param[11] = new SqlParameter("@IGST", 18);
                param[12] = new SqlParameter("@CustomerFeeType", transectionMasterRequest.CustomerFeeType);
                param[13] = new SqlParameter("@CustomerFee", transectionMasterRequest.CustomerFee);
                param[14] = new SqlParameter("@ValueOfCustomerFee", transectionMasterRequest.ValueOfCustomerFee);
                param[15] = new SqlParameter("@mobileNo", transectionMasterRequest.MobileNo);
                param[16] = new SqlParameter("@lat", transectionMasterRequest.Latitude);
                param[17] = new SqlParameter("@long", transectionMasterRequest.Longitude);
                param[18] = new SqlParameter("@ipAddress", transectionMasterRequest.IPAddress);

                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_OPERATION_ServiceTransaction_Save]", param);
                if (ds != null && ds.Tables != null)
                {
                    objResponseData.ResponseCode = "000";

                    objResponseData.Data = ds.Tables[0];
                    objResponseData.Message = ds.Tables[0].Rows[0][1].ToString();
                    objResponseData.statusCode = 1;
                }
                else
                {
                    objResponseData.ResponseCode = "001";
                    objResponseData.Message = "No Data Available...";
                    objResponseData.statusCode = -1;
                }
            }
            catch (Exception e)
            {
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetHirarichyDetails", connectionString);
            }
            return objResponseData;
        }

        public ResponseData UpdateSoldPriceForTransection(string transectionId, decimal rechargePrice)
        {
            try
            {

                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@txnID", transectionId);
                param[1] = new SqlParameter("@SoldPrice", rechargePrice);

                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_OPERATION_UpdateSoldandPurchasePrice_Update]", param);
                if (ds != null && ds.Tables != null)
                {
                    objResponseData.ResponseCode = "000";

                    objResponseData.Data = ds.Tables[0];
                    objResponseData.Message = "List Of HirarchyData...";
                    objResponseData.statusCode = 1;
                }
                else
                {
                    objResponseData.ResponseCode = "001";
                    objResponseData.Message = "No Data Available...";
                    objResponseData.statusCode = -1;
                }
            }
            catch (Exception e)
            {
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetHirarichyDetails", connectionString);
            }
            return objResponseData;
        }
        public ResponseData GetCommissionRate(string partyID, int PartyType, int operatorId, int serviceId, int serviceProviderId)
        {
            try
            {

                SqlParameter[] param = new SqlParameter[5];
                param[0] = new SqlParameter("@partyId", partyID);
                param[1] = new SqlParameter("@partytype", PartyType);
                param[2] = new SqlParameter("@OperaterId", operatorId);
                param[3] = new SqlParameter("@serviceId", serviceId);
                param[4] = new SqlParameter("@serviceprovider", serviceProviderId);

                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_MASTER_GetUserwiseComission_Select]", param);
                if (ds != null && ds.Tables != null)
                {
                    objResponseData.ResponseCode = "000";
                    objResponseData.Data = ds.Tables[0];
                    objResponseData.Message = "List Of Commission Rates...";
                    objResponseData.statusCode = 1;
                }
                else
                {
                    objResponseData.ResponseCode = "001";
                    objResponseData.Message = "No Data Available...";
                    objResponseData.statusCode = -1;
                }
            }
            catch (Exception e)
            {
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetCommissionRate", connectionString);
            }
            return objResponseData;
        }
        public ResponseData GetCommissionDistribution()
        {
            try
            {
                string queryString = "select * from CommissionDistributionMaster";
                using (SqlConnection connect = new SqlConnection())
                {
                    SqlCommand cmd = new SqlCommand(queryString, connect);
                    cmd.CommandType = CommandType.Text;

                    connect.ConnectionString = connectionString;
                    cmd.Connection = connect;
                    if (connect.State != ConnectionState.Open)
                    {
                        connect.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        da.Fill(ds);

                        if (ds != null && ds.Tables != null)
                        {
                            objResponseData.ResponseCode = "000";
                            objResponseData.Data = ds.Tables[0];
                            objResponseData.Message = "List Of Commission Rates...";
                            objResponseData.statusCode = 1;
                        }
                        else
                        {
                            objResponseData.ResponseCode = "001";
                            objResponseData.Message = "No Data Available...";
                            objResponseData.statusCode = -1;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetHirarichyDetails", connectionString);
            }
            return objResponseData;
        }
        public ResponseData GetTransections()
        {
            try
            {

                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_REPORT_GetTransectionData_Select]");
                if (ds != null && ds.Tables != null)
                {
                    objResponseData.ResponseCode = "000";
                    objResponseData.Data = ds.Tables[0];
                    objResponseData.Message = "List Of Commission Rates...";
                    objResponseData.statusCode = 1;
                }
                else
                {
                    objResponseData.ResponseCode = "001";
                    objResponseData.Message = "No Data Available...";
                    objResponseData.statusCode = -1;
                }
            }
            catch (Exception e)
            {
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetHirarichyDetails", connectionString);
            }
            return objResponseData;
        }

        public ResponseData AddUpdateSSO(SSOUserDetail userDetail)
        {
            try
            {

                var dob = userDetail.DateOfBirth;

                SqlParameter[] param = new SqlParameter[25];
                param[0] = new SqlParameter("@sSsoId", userDetail.SSOID);
                param[1] = new SqlParameter("@sAdharNo", userDetail.AadhaarId);
                param[2] = new SqlParameter("@sUsrNm", userDetail.Username);
                param[3] = new SqlParameter("@sPhoneNo", userDetail.IpPhone);
                param[4] = new SqlParameter("@sPAddress", userDetail.PostalAddress);
                param[5] = new SqlParameter("@sEmailId", userDetail.MailOfficial);
                param[6] = new SqlParameter("@sBhamashahId", userDetail.BhamashahId);
                param[7] = new SqlParameter("@sBhamashahMemberId", userDetail.BhamashahMemberId);
                param[8] = new SqlParameter("@sDisplayName", userDetail.DisplayName);
                param[9] = new SqlParameter("@dtDOB", dob);
                param[10] = new SqlParameter("@iGender", userDetail.Gender);
                param[11] = new SqlParameter("@sMobile", userDetail.Mobile);
                param[12] = new SqlParameter("@sTelephone", userDetail.TelephoneNumber);
                param[13] = new SqlParameter("@iphone", userDetail.IpPhone);
                param[14] = new SqlParameter("@sPstAddress", userDetail.PostalAddress);
                param[15] = new SqlParameter("@sPsCode", userDetail.PostalCode);
                param[16] = new SqlParameter("@sCITYNm", userDetail.City);
                param[17] = new SqlParameter("@sSTATENm", userDetail.State);
                //param[18] = new SqlParameter("@sProfileImg", userDetail.sProfileImg);
                param[18] = new SqlParameter("@sDesignation", userDetail.Designation);
                param[19] = new SqlParameter("@sDepartment", userDetail.DepartmentName);
                param[20] = new SqlParameter("@sOffclEmailId", userDetail.MailOfficial);
                param[21] = new SqlParameter("@sEmpNmbr", userDetail.EmployeeNumber);
                param[22] = new SqlParameter("@sDeptId", userDetail.DepartmentId);
                param[23] = new SqlParameter("@sFirstNm", userDetail.FirstName);
                param[24] = new SqlParameter("@sLstNm", userDetail.LastName);
                //param[25] = new SqlParameter("@sJanaadhaarId", userDetail.sJanaadhaarId);
                //param[26] = new SqlParameter("@sJanadhaarMemberId", userDetail.sJanadhaarMemberId);
                //param[27] = new SqlParameter("@sUsrTyp", userDetail.sUsrTyp);
                //param[28] = new SqlParameter("@iFk_YearId", userDetail.iFk_YearId);
                //param[29] = new SqlParameter("@iFk_BranchId", userDetail.iFk_BranchId);

                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_Admin_SSODetails_SaveUpdate]", param);
                if (ds != null && ds.Tables != null)
                {
                    objResponseData.ResponseCode = "000";
                    objResponseData.Data = ds.Tables[0];
                    objResponseData.Message = "SSO Details Found";//$"{ds.Tables[0].Rows[0]["Message"]}";
                    objResponseData.statusCode = 1;
                }
                else
                {
                    objResponseData.ResponseCode = "001";
                    objResponseData.Message = "No Data Available...";
                    objResponseData.statusCode = -1;
                }
            }
            catch (Exception e)
            {
                ExceptionLogDL.LogWrite("AddUpdateSSO:" + e.Message);
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : AddUpdateSSO", connectionString);
            }
            return objResponseData;
        }

        #endregion


        #region Pravin Pawar
        public ResponseData GetDept()
        {
            try
            {

                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_Master_Department_List]");
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    objResponseData.ResponseCode = "000";
                    objResponseData.Message = "Department  List";
                    objResponseData.statusCode = 1;
                    objResponseData.Data = ds.Tables[0];
                }
                else
                {
                    objResponseData.ResponseCode = "001";
                    objResponseData.Message = "No Data Available...";
                    objResponseData.statusCode = -1;
                }
            }
            catch (Exception e)
            {
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetGeoGraphicalList", connectionString);
            }
            return objResponseData;
        }



        public ResponseData GetCourses(int Id = 30)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@Id", Id);
                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_Master_Course_List]",param);
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    objResponseData.ResponseCode = "000";
                    objResponseData.Message = "Course  List";
                    objResponseData.statusCode = 1;
                    objResponseData.Data = ds.Tables[0];
                }
                else
                {
                    objResponseData.ResponseCode = "001";
                    objResponseData.Message = "No Data Available...";
                    objResponseData.statusCode = -1;
                }
            }
            catch (Exception e)
            {
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetGeoGraphicalList", connectionString);
            }
            return objResponseData;
        }

        public ResponseData SaveDeptCourseMap(DeptCourseMap mapping)
        {
            try
            {

                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@Fk_DeptId", mapping.deptId);
                param[1] = new SqlParameter("@Fk_CourseId", mapping.courseId);
                param[2] = new SqlParameter("@Fk_SubjectId", mapping.SubjectID);
                param[3] = new SqlParameter("@iClassId", mapping.ClassID);

                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_ADMIN_DeptCourseMap_Save]", param);
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    objResponseData.ResponseCode = "000";
                    objResponseData.Message = ds.Tables[0].Rows[0]["Message"].NulllToString();
                    objResponseData.statusCode = ds.Tables[0].Rows[0]["StatusCode"].NulllToInt();

                }
                else
                {
                    objResponseData.ResponseCode = "001";
                    objResponseData.Message = "No Data Available...";
                    objResponseData.statusCode = -1;
                }

            }
            catch (Exception e)
            {
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : SaveDeptCourseMap", connectionString);
            }
            return objResponseData;
        }

        public ResponseData GetDeptMappingData()
        {
            try
            {

                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_Master_DeptCourseMapping_Get]");
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    objResponseData.ResponseCode = "000";
                    objResponseData.Message = "Department Course Mapping  List";
                    objResponseData.statusCode = 1;
                    objResponseData.Data = ds.Tables[0];
                }
                else
                {
                    objResponseData.ResponseCode = "001";
                    objResponseData.Message = "No Data Available...";
                    objResponseData.statusCode = -1;
                }
            }
            catch (Exception e)
            {
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetGeoGraphicalList", connectionString);
            }
            return objResponseData;
        }



        // For Academic Master

        public ResponseData GetYear()
        {
            try
            {

                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_Master_Academic_Year_List]");
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    objResponseData.ResponseCode = "000";
                    objResponseData.Message = "Year  List";
                    objResponseData.statusCode = 1;
                    objResponseData.Data = ds.Tables[0];
                }
                else
                {
                    objResponseData.ResponseCode = "001";
                    objResponseData.Message = "No Data Available...";
                    objResponseData.statusCode = -1;
                }
            }
            catch (Exception e)
            {
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : YearList", connectionString);
            }
            return objResponseData;
        }

        public ResponseData GetResult()
        {
            try
            {

                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_Master_Academic_Result_List]");
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    objResponseData.ResponseCode = "000";
                    objResponseData.Message = "Result  List";
                    objResponseData.statusCode = 1;
                    objResponseData.Data = ds.Tables[0];
                }
                else
                {
                    objResponseData.ResponseCode = "001";
                    objResponseData.Message = "No Data Available...";
                    objResponseData.statusCode = -1;
                }
            }
            catch (Exception e)
            {
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : ResultList", connectionString);
            }
            return objResponseData;
        }

        public ResponseData SaveAcdmcMst(AcdmcMst mapping)
        {
            try
            {

                SqlParameter[] param = new SqlParameter[12];
                param[0] = new SqlParameter("@FromYear", mapping.FromYear);
                param[1] = new SqlParameter("@ToYear", mapping.ToYear);
                param[2] = new SqlParameter("@NoOfStudentAppear", mapping.NoOfStudent);
                param[3] = new SqlParameter("@NoOfStudentPassed", mapping.NoOfStudentPass);
                param[4] = new SqlParameter("@Percentage", mapping.Percentage);
                param[5] = new SqlParameter("@Fk_Result", mapping.Fk_Result);
                param[6] = new SqlParameter("@TotalOfStudent", mapping.TotalStudent);
                param[7] = new SqlParameter("@Course", mapping.Course);
                param[8] = new SqlParameter("@GUIID", mapping.GUIID);
                param[9] = new SqlParameter("@clg", mapping.clgID);
                param[10] = new SqlParameter("@Type", mapping.Type);
                param[11] = new SqlParameter("@iPk_AcdmcId", mapping.iPk_AcdmcId);

                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_ADMIN_AcdmcMst_Save]", param);
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    objResponseData.ResponseCode = "000";
                    objResponseData.Message = ds.Tables[0].Rows[0]["Message"].NulllToString();
                    objResponseData.statusCode = ds.Tables[0].Rows[0]["StatusCode"].NulllToInt();

                }
                else
                {
                    objResponseData.ResponseCode = "001";
                    objResponseData.Message = "No Data Available...";
                    objResponseData.statusCode = -1;
                }

            }
            catch (Exception e)
            {
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : SaveDeptCourseMap", connectionString);
            }
            return objResponseData;
        }


        public ResponseData GetAcdmcData(string GUIID, int clgID)
        {
            try
            {

                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@GUIID", GUIID);
                param[1] = new SqlParameter("@clgID", clgID);
                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_Master_AcdmcMst_Get]", param);
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    objResponseData.ResponseCode = "000";
                    objResponseData.Message = "Academic Master List";
                    objResponseData.statusCode = 1;
                    objResponseData.Data = ds.Tables[0];
                }
                else
                {
                    objResponseData.ResponseCode = "001";
                    objResponseData.Message = "No Data Available...";
                    objResponseData.statusCode = -1;
                }
            }
            catch (Exception e)
            {
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetGeoGraphicalList", connectionString);
            }
            return objResponseData;
        }


        public ResponseData GetModule()
        {
            try
            {

                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_SupportTicket_GetModule_List]");
                if (ds != null && ds.Tables != null)
                {
                    objResponseData.ResponseCode = "000";
                    objResponseData.Data = ds.Tables[0];
                    objResponseData.Message = "Get Module List...";
                    objResponseData.statusCode = 1;
                }
                else
                {
                    objResponseData.ResponseCode = "001";
                    objResponseData.Message = "No Data Available...";
                    objResponseData.statusCode = -1;
                }
            }
            catch (Exception e)
            {
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetModule", connectionString);
            }
            return objResponseData;
        }

        public ResponseData GetFunctionality()
        {
            try
            {

                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_SupportTicket_GetFunctionality_List]");
                if (ds != null && ds.Tables != null)
                {
                    objResponseData.ResponseCode = "000";
                    objResponseData.Data = ds.Tables[0];
                    objResponseData.Message = "Get Functionality List...";
                    objResponseData.statusCode = 1;
                }
                else
                {
                    objResponseData.ResponseCode = "001";
                    objResponseData.Message = "No Data Available...";
                    objResponseData.statusCode = -1;
                }
            }
            catch (Exception e)
            {
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetFunctionality", connectionString);
            }
            return objResponseData;
        }

        public ResponseData SaveSupportTicket(SupportTicket Ticket)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[5];
                param[0] = new SqlParameter("@ModuleId", Ticket.ModuleId);
                param[1] = new SqlParameter("@FunctionalityId", Ticket.FunctionalityId);
                param[2] = new SqlParameter("@TicketId", Ticket.TicketId);
                param[3] = new SqlParameter("@Description", Ticket.Description);
                param[4] = new SqlParameter("@Attachment", Ticket.Attachment);

                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_MASTER_SupportTicket_Save]", param);
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {

                    objResponseData.ResponseCode = "000";
                    objResponseData.statusCode = 1;
                    objResponseData.Message = "Data Saved";
                    objResponseData.Data = "";
                }
                else
                {
                    objResponseData.ResponseCode = "001";
                    objResponseData.Message = "No Data Available...";
                    objResponseData.statusCode = -1;
                }

            }
            catch (Exception e)
            {
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : UpdateVerificationStatus", connectionString);
            }
            return objResponseData;
        }

        public ResponseData SaveUniversitesDeptMap(UniversitiesDept mapping)
        {
            try
            {

                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@Fk_DeptId", mapping.Dept);
                param[1] = new SqlParameter("@Fk_UniversitiesId", mapping.University);

                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_ADMIN_UniversitiesDeptMap_Save]", param);
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    objResponseData.ResponseCode = "000";
                    objResponseData.Message = ds.Tables[0].Rows[0]["Message"].NulllToString();
                    objResponseData.statusCode = ds.Tables[0].Rows[0]["StatusCode"].NulllToInt();

                }
                else
                {
                    objResponseData.ResponseCode = "001";
                    objResponseData.Message = "No Data Available...";
                    objResponseData.statusCode = -1;
                }

            }
            catch (Exception e)
            {
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : SaveDeptCourseMap", connectionString);
            }
            return objResponseData;
        }

        public ResponseData GetUniversitiesData()
        {
            try
            {

                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_Master_UniversitiesDeptMap_Get]");
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    objResponseData.ResponseCode = "000";
                    objResponseData.Message = "University Dept List";
                    objResponseData.statusCode = 1;
                    objResponseData.Data = ds.Tables[0];
                }
                else
                {
                    objResponseData.ResponseCode = "001";
                    objResponseData.Message = "No Data Available...";
                    objResponseData.statusCode = -1;
                }
            }
            catch (Exception e)
            {
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetGeoGraphicalList", connectionString);
            }
            return objResponseData;
        }


        public ResponseData GetUniversities()
        {
            try
            {


                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_Universities_List]");
                if (ds != null && ds.Tables != null)
                {
                    objResponseData.ResponseCode = "000";
                    objResponseData.Data = ds.Tables[0];
                    objResponseData.Message = "Get Universities List...";
                    objResponseData.statusCode = 1;
                }
                else
                {
                    objResponseData.ResponseCode = "001";
                    objResponseData.Message = "No Data Available...";
                    objResponseData.statusCode = -1;
                }
            }
            catch (Exception e)
            {
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetCourseData", connectionString);
            }
            return objResponseData;
        }

        #endregion

        public ResponseData GetGeoGraphicalData(GeoLocationMaster graphical)
        {
            try
            {

                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@Type", graphical.Type);
                param[1] = new SqlParameter("@ID", graphical.Id == null ? 0 : graphical.Id);

                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_ADMIN_GetGeoDataForDropdown_View]", param);
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    objResponseData.ResponseCode = "000";
                    objResponseData.Message = graphical.Type + " List";
                    objResponseData.statusCode = 1;
                    objResponseData.Data = ds.Tables[0];
                }
                else
                {
                    objResponseData.ResponseCode = "001";
                    objResponseData.Message = "No Data Available...";
                    objResponseData.statusCode = -1;
                }
            }
            catch (Exception e)
            {
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetGeoGraphical", connectionString);
            }
            return objResponseData;
        }
        public ResponseData GetUserSendbackForward(string MenuId, string PartyId)
        {
            try
            {

                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@type", "SendbackForward");
                param[1] = new SqlParameter("@menuId", MenuId);
                param[2] = new SqlParameter("@PartyId", PartyId);

                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_ADMIN_GetMasterDataForDropdown_View]", param);
                if (ds != null && ds.Tables != null)
                {
                    objResponseData.ResponseCode = "000";
                    objResponseData.Data = ds.Tables[0];
                    objResponseData.Message = "Data Fetched Successfully...!";
                    objResponseData.statusCode = 1;
                }
                else
                {
                    objResponseData.ResponseCode = "001";
                    objResponseData.Message = "No Data Available...";
                    objResponseData.statusCode = -1;
                }
            }
            catch (Exception e)
            {
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetMenus", connectionString);
            }
            return objResponseData;
        }

        public ResponseData GetCourseData()
        {
            try
            {

                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_Course_List]");
                if (ds != null && ds.Tables != null)
                {
                    objResponseData.ResponseCode = "000";
                    objResponseData.Data = ds.Tables[0];
                    objResponseData.Message = "Get Course List...";
                    objResponseData.statusCode = 1;
                }
                else
                {
                    objResponseData.ResponseCode = "001";
                    objResponseData.Message = "No Data Available...";
                    objResponseData.statusCode = -1;
                }
            }
            catch (Exception e)
            {
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetCourseData", connectionString);
            }
            return objResponseData;
        }


        public ResponseData GetSubjects()
        {
            try
            {

                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_Master_Subject_List]");
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    objResponseData.ResponseCode = "000";
                    objResponseData.Message = "Subject  List";
                    objResponseData.statusCode = 1;
                    objResponseData.Data = ds.Tables[0];
                }
                else
                {
                    objResponseData.ResponseCode = "001";
                    objResponseData.Message = "No Data Available...";
                    objResponseData.statusCode = -1;
                }
            }
            catch (Exception e)
            {
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetGeoGraphicalList", connectionString);
            }
            return objResponseData;
        }

        public ResponseData GetACDMCDataEdit(int AcdmcId)
        {
            try
            {

                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@AcdmcId", AcdmcId);



                DataSet ds = BaseFunction.FillDataSet("[dbo].[Usp_Admin_GetAcdmcData_view]", param);
                if (ds != null && ds.Tables != null)
                {
                    objResponseData.ResponseCode = "000";
                    objResponseData.Data = ds.Tables[0];
                    objResponseData.Message = "Data Fetched Successfully...!";
                    objResponseData.statusCode = 1;
                }
                else
                {
                    objResponseData.ResponseCode = "001";
                    objResponseData.Message = "No Data Available...";
                    objResponseData.statusCode = -1;
                }
            }
            catch (Exception e)
            {
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetMenus", connectionString);
            }
            return objResponseData;
        }
        public ResponseData GetACDMCDataDelete(int AcdmcId)
        {
            try
            {

                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@Pk_AcdmcId", AcdmcId);



                DataSet ds = BaseFunction.FillDataSet("[dbo].[Usp_Admin_GetAcdmcData_Delete]", param);
                if (ds != null && ds.Tables != null)
                {
                    objResponseData.ResponseCode = "000";
                    objResponseData.Data = ds.Tables[0];
                    objResponseData.Message = "Data Deleted Successfully...!";
                    objResponseData.statusCode = 1;
                }
                else
                {
                    objResponseData.ResponseCode = "001";
                    objResponseData.Message = "No Data Available...";
                    objResponseData.statusCode = -1;
                }
            }
            catch (Exception e)
            {
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetMenus", connectionString);
            }
            return objResponseData;
        }
        
        public ResponseData CheckSSO(string sso)
        {
            try
            {

                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@ssoiD", sso);

                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_ADMIN_Check_SSOUser_Select]", param);
                if (ds != null && ds.Tables != null)
                {
                    objResponseData.ResponseCode = "000";
                    objResponseData.Message = ds.Tables[0].Rows[0]["Message"].ToString();
                    objResponseData.statusCode = Convert.ToInt32(ds.Tables[0].Rows[0]["StatusCode"]);
                }
                else
                {
                    objResponseData.ResponseCode = "001";
                    objResponseData.Message = "No Data Available...";
                    objResponseData.statusCode = -1;
                }
            }
            catch (Exception e)
            {
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetMenus", connectionString);
            }
            return objResponseData;
        }
    }
}