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
using static System.Exception;

namespace DL
{
    public class AdminDL
    {

        ResponseData objResponseData = new ResponseData();
        ErrorBO _Access = new ErrorBO();
        public static IConfiguration _configuration;
        string connectionString = DBCS.GetConnectionString();
        //


        #region Changed By shipra
        public List<CustomEnum> GetCustomEnum()
        {
            List<CustomEnum> objlist = new List<CustomEnum>();
            try
            {                
                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_ADMIN_CustomFields_View]");
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    objlist = new List<CustomEnum>();
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        CustomEnum objdoc = new CustomEnum();
                        objdoc.CustomEnumId = ds.Tables[0].Rows[i]["iPK_CustEnum"].NulllToInt();
                        objdoc.EnumNo = ds.Tables[0].Rows[i]["iFK_EnumNo"].NulllToInt();
                        //objdoc.Id = Convert.ToInt32(ds.Tables[0].Rows[i]["iId"].NulllToString()).NulllToInt();
                        objdoc.Name = ds.Tables[0].Rows[i]["sName"].ToString();
                        objdoc.IsActive = ds.Tables[0].Rows[i]["Active"].NulllToInt();
                        objlist.Add(objdoc);

                    }

                }
                else
                {
                    objlist = null;
                }
            }
            catch (Exception e)
            {
                objlist = null;
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetCustomEnum");
            }
            return objlist;
        }
        public List<setting> GetSetting()
        {
            List<setting> objlist = new List<setting>();
            try
            {                
                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_ADMIN_CustomFieldEnumSetting_View]");
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    objlist = new List<setting>();
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        setting objdoc = new setting();
                        objdoc.Id = Convert.ToInt32(ds.Tables[0].Rows[i]["iSttngId"]);
                        objdoc.Name = ds.Tables[0].Rows[i]["sName"].NulllToString();
                        objdoc.IsActive = ds.Tables[0].Rows[i]["iIsActv"].NulllToInt();
                        objlist.Add(objdoc);
                    }
                }
                else
                {
                    objlist = null;
                }
            }
            catch (Exception e)
            {
                objlist = null;
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetSetting");
            }
            return objlist;
        }
        public int UpdateSubjectLines(int Id, string Text)
        {
            int Master = 0;
            try
            {
                
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@Id", Id);
                param[1] = new SqlParameter("@Text", Text);
                DataTable DT = BaseFunction.FillDataTable("[dbo].[USP_MASTER_UpdateSettingTitle_Update]",param);
                if (DT != null)
                {
                    if (DT.Rows.Count > 0)
                    {
                        Master = Convert.ToInt32(DT.Rows[0]["StatusCode"]);
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : DeleteCustomSentence");
            }
            return Master;
        }

        public int DeleteCustomSentence(int Id)
        {
            int Master = 0;
            try
            {
                
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@EnumNo", Id);
                param[1] = new SqlParameter("@Type", 2);
                DataTable DT = BaseFunction.FillDataTable("[dbo].[USP_ADMIN_NewFieldinEnum_SaveUpdateDelete]",param);
                if (DT != null)
                {
                    if (DT.Rows.Count > 0)
                    {
                        Master = Convert.ToInt32(DT.Rows[0]["StatusCode"]);
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : DeleteCustomSentence");
            }
            return Master;
        }
        public int InsertNewCustomEnumRow(int Id)
        {
            int master = 0;
            try
            {
               
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@EnumNo", Id);
                param[1] = new SqlParameter("@Type", 1);
                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_ADMIN_NewFieldinEnum_SaveUpdateDelete]", param);
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        master = ds.Tables[0].Rows[i]["iPK_CustEnum"].NulllToInt();
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : InsertNewCustomEnumRow");
            }
            return master;
        }

        public List<CustomList> GetChargesType(long ServiceId)
        {
            List<CustomList> objListdoc = new List<CustomList>();
            try
            {
                
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@type","ChargeType");
                param[0] = new SqlParameter("@Id", ServiceId);
                DataSet ds = BaseFunction.FillDataSet("[mst].[USP_ADMIN_GetMasterDataForDropdown_View]", param);
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    objListdoc = new List<CustomList>();

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        CustomList objdoc = new CustomList();
                        objdoc.Id = ds.Tables[0].Rows[i]["Id"].NulllToInt();
                        objdoc.text = ds.Tables[0].Rows[i]["text"].NulllToString();
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
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetCustomList");
            }
            return objListdoc;
        }

        #region 1
        //public List<CategoryMaster> GetServicesDetail(int Id)
        //{
        //    List<CategoryMaster> objCategormaster = new List<CategoryMaster>();
        //    try
        //    {
        //        
        //        SqlParameter[] param = new SqlParameter[1];
        //        param[0] = new SqlParameter("@Id", Id);
        //        DataSet ds = BaseFunction.FillDataSet("[dbo].[ServiceDetail]", param);
        //        if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
        //        {
        //            objCategormaster = new List<CategoryMaster>();

        //            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //            {
        //                CategoryMaster objdoc = new CategoryMaster();
        //                objdoc.CategoryId = ds.Tables[0].Rows[i]["CategoryId"].NulllToInt();
        //                //objdoc.CategoryId = Convert.ToInt32(ds.Tables[0].Rows[i]["CategoryId"]);
        //                objdoc.Name = ds.Tables[0].Rows[i]["Name"].NulllToString();
        //                objdoc.VarificationList = ds.Tables[0].Rows[i]["varificationList"].NulllToString();
        //                objdoc.DocumentList = ds.Tables[0].Rows[i]["DocumentList"].NulllToString();
        //                objdoc.HardwareList = ds.Tables[0].Rows[i]["HardwareList"].NulllToString();
        //                objdoc.ClassName = ds.Tables[0].Rows[i]["ClassName"].NulllToString();
        //                objdoc.IsActive = ds.Tables[0].Rows[i]["IsActive"].NulllToInt();
        //                objCategormaster.Add(objdoc);

        //            }

        //        }
        //        else
        //        {
        //            objCategormaster = null;
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        objCategormaster = null;
        //        ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetServicesDetail");
        //    }
        //    return objCategormaster;
        //}
        public List<SRVCMST> GetServicesDetail(int Id)
        {
            List<SRVCMST> objCategormaster = new List<SRVCMST>();
            try
            {
                
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@Id", Id);
                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_ADMIN_ServiceMaster_View]", param);
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    objCategormaster = new List<SRVCMST>();

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        SRVCMST objdoc = new SRVCMST();
                        objdoc.iPK_CatId = ds.Tables[0].Rows[i]["iPK_CatId"].NulllToInt();
                        //objdoc.CategoryId = Convert.ToInt32(ds.Tables[0].Rows[i]["CategoryId"]);
                        objdoc.sName = ds.Tables[0].Rows[i]["sName"].NulllToString();
                        objdoc.sVrfctnLst = ds.Tables[0].Rows[i]["sVrfctnLst"].NulllToString();
                        objdoc.sDcmntLst = ds.Tables[0].Rows[i]["sDcmntLst"].NulllToString();
                        objdoc.sHrdwrLst = ds.Tables[0].Rows[i]["sHrdwrLst"].NulllToString();
                        objdoc.sClsNm = ds.Tables[0].Rows[i]["sClsNm"].NulllToString();
                        objdoc.iIsActv = ds.Tables[0].Rows[i]["IsActive"].NulllToInt();
                        objCategormaster.Add(objdoc);
                    }

                }
                else
                {
                    objCategormaster = null;
                }
            }
            catch (Exception e)
            {
                objCategormaster = null;
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetServicesDetail");
            }
            return objCategormaster;
        }
        #endregion

        #region 3
        
        //public ResponseData InserGstApplicable(GSTApplicable obj)
        //{
        //    try
        //    {
                
        //        SqlParameter[] param = new SqlParameter[8];
        //        param[0] = new SqlParameter("@ServiceHardwareId", obj.ServiceHardwareId);
        //        param[1] = new SqlParameter("@Type", obj.TypeId);
        //        param[2] = new SqlParameter("@ApplicableType", obj.ApplicableChargesType);
        //        param[3] = new SqlParameter("@GST", obj.GST);
        //        param[4] = new SqlParameter("@Fromdate", obj.FromDate);
        //        param[5] = new SqlParameter("@Todate", obj.ToDate);
        //        param[6] = new SqlParameter("@TaxType", obj.TaxType);
        //        param[7] = new SqlParameter("@UnitId", obj.UnitId);
        //        DataTable DT = BaseFunction.FillDataTable("[mst].[USP_MASTER_GSTApplicable_Save]", param);
        //        if (DT != null)
        //        {
        //            if (DT.Rows.Count > 0)
        //            {
        //                objResponseData.statusCode = DT.Rows[0]["StatusCode"].NulllToInt();
        //                objResponseData.Message = DT.Rows[0]["Message"].NulllToString();

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
        //        ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : InsertServices");
        //    }
        //    return objResponseData;
        //}
        #endregion

        #region 2      
        public ResponseData InsertServices(SRVCMST obj)
        {
            try
            {
                
                SqlParameter[] param = new SqlParameter[6];
                param[0] = new SqlParameter("@categoryMaster", obj.iPK_CatId);
                param[1] = new SqlParameter("@Name", obj.sName);
                param[2] = new SqlParameter("@DocumentList", obj.sDcmntLst);
                param[3] = new SqlParameter("@VarificationList", obj.sVrfctnLst);
                param[4] = new SqlParameter("@HardwareList", obj.sHrdwrLst);
                param[5] = new SqlParameter("@ClassName", obj.sClsNm);
                DataTable DT = BaseFunction.FillDataTable("[mst].[USP_ADMIN_ServiceConfiguration_Save]", param);
                if (DT != null)
                {
                    if (DT.Rows.Count > 0)
                    {
                        objResponseData.statusCode = DT.Rows[0]["StatusCode"].NulllToInt();
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
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : InsertServices");
            }
            return objResponseData;
        }

        #endregion
        public ResponseData ChangeStatus(Activeclass obj)
        {
            try
            {
                
                DataTable DT = new DataTable();
                SqlParameter[] param = null;
                if (obj.status == 2 || obj.Tablename != "RateMaster")
                {
                    param = new SqlParameter[3];
                    param[0] = new SqlParameter("@tablename", obj.Tablename);
                    param[1] = new SqlParameter("@Id", obj.Id);
                    param[2] = new SqlParameter("@type", obj.status);
                    DT = BaseFunction.FillDataTable("[dbo].[USP_MASTER_ActivateDeactivateMastersForm_Update]", param);
                }
                else
                {
                    param = new SqlParameter[1];
                    param[0] = new SqlParameter("@RatemasterId", obj.Id);
                    DT = BaseFunction.FillDataTable("[dbo].[USP_ADMIN_ManageRateStatus_Update]", param);
                }
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
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : InsertServices");
            }
            return objResponseData;
        }

        #region 4
        public ResponseData InsertRateMaster(RateMaster obj)
        {
            try
            {
                
                SqlParameter[] param = new SqlParameter[6];
                param[0] = new SqlParameter("@Amount", obj.Amount);
                param[1] = new SqlParameter("@HardWareServicesId", obj.HardWareServicesId);
                param[2] = new SqlParameter("@ChargeType", obj.ChargeType);
                param[3] = new SqlParameter("@UnitType", obj.UnitType);
                param[4] = new SqlParameter("@PaymentType", obj.PaymentType);
                param[5] = new SqlParameter("@TypeId", obj.TypeId);
                DataTable DT = BaseFunction.FillDataTable("[dbo].[USP_ADMIN_RateMaster_Save]", param);
                if (DT != null)
                {
                    if (DT.Rows.Count > 0)
                    {
                        objResponseData.statusCode = DT.Rows[0]["StatusCode"].NulllToInt();
                        objResponseData.Message = DT.Rows[0]["Message"].NulllToString();

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
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : InsertRateMaster");
            }
            return objResponseData;
        }
        //public ResponseData InsertRateMaster(RateMaster obj)
        //{
        //    try
        //    {
        //        
        //        SqlParameter[] param = new SqlParameter[6];
        //        param[0] = new SqlParameter("@Amount", obj.Amount);
        //        param[1] = new SqlParameter("@HardWareServicesId", obj.HardWareServicesId);
        //        param[2] = new SqlParameter("@ChargeType", obj.ChargeType);
        //        param[3] = new SqlParameter("@UnitType", obj.UnitType);
        //        param[4] = new SqlParameter("@PaymentType", obj.PaymentType);
        //        param[5] = new SqlParameter("@TypeId", obj.TypeId);
        //        DataTable DT = BaseFunction.FillDataTable("[dbo].[InsertRateMaster]", param);
        //        if (DT != null)
        //        {
        //            if (DT.Rows.Count > 0)
        //            {
        //                objResponseData.statusCode = DT.Rows[0]["StatusCode"].NulllToInt();
        //                objResponseData.Message = DT.Rows[0]["Message"].NulllToString();

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
        //        ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : InsertRateMaster");
        //    }
        //    return objResponseData;
        //}
        #endregion
        public List<GlobalClass> GetGeographicalData(int Id, int districtId, int Type)
        {
            List<GlobalClass> objGlobal = new List<GlobalClass>();
            try
            {
                
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@DistrictId", Id);
                param[1] = new SqlParameter("@BlockId ", districtId);
                param[2] = new SqlParameter("@type", Type);
                DataSet ds = BaseFunction.FillDataSet("[mst].[USP_ADMIN_GetDistrictCityArea_select]]", param);
                using (SqlConnection connect = new SqlConnection())
                {
                    if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                    {
                        objGlobal = new List<GlobalClass>();

                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            GlobalClass objdoc = new GlobalClass();
                            objdoc.Id = ds.Tables[0].Rows[i]["Id"].NulllToInt();
                            objdoc.Text = ds.Tables[0].Rows[i]["Name"].NulllToString();
                            objdoc.Pincode = ds.Tables[0].Rows[i]["PinCode"].NulllToString();


                            objGlobal.Add(objdoc);

                        }

                    }
                    else
                    {
                        objGlobal = null;
                    }
                }
            }
            catch (Exception e)
            {
                objGlobal = null;
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetGeographicalData");
            }
            return objGlobal;
        }


        #region 5
        public List<ShowRateMaster> GetRateMasterDetail()
        {
            List<ShowRateMaster> objCategormaster = new List<ShowRateMaster>();
            try
            {
                
                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_ADMIN_ServiceHardwareRates_Select]");
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    objCategormaster = new List<ShowRateMaster>();

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        ShowRateMaster objdoc = new ShowRateMaster();
                        objdoc.RateMasterId = ds.Tables[0].Rows[i]["iPK_RateMstId"].NulllToInt();
                        objdoc.Name = ds.Tables[0].Rows[i]["Name"].NulllToString();
                        objdoc.ServiceName = ds.Tables[0].Rows[i]["ServiceName"].NulllToString();
                        objdoc.ChargeType = ds.Tables[0].Rows[i]["ChargeType"].NulllToString();
                        objdoc.UnitType = ds.Tables[0].Rows[i]["UnitType"].NulllToString();
                        objdoc.PaymentType = ds.Tables[0].Rows[i]["PaymentType"].NulllToString();
                        objdoc.Amount = ds.Tables[0].Rows[i]["BiAmt"].NulllToString();
                        objdoc.Isactive = ds.Tables[0].Rows[i]["Isactive"].NulllToInt();
                        objCategormaster.Add(objdoc);
                    }
                }
                else
                {
                    objCategormaster = null;
                }
            }
            catch (Exception e)
            {
                objCategormaster = null;
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetServicesDetail");
            }
            return objCategormaster;
        }
        #endregion

        #region 6
        //public List<GSTApplicable> GetApplicableGstDetails()
        //{
        //    List<GSTApplicable> objCategormaster = new List<GSTApplicable>();
        //    try
        //    {
        //        
        //        DataSet ds = BaseFunction.FillDataSet("[mst].[ShowGstDetails]");
        //        if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
        //        {
        //            objCategormaster = new List<GSTApplicable>();

        //            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //            {
        //                GSTApplicable objdoc = new GSTApplicable();
        //                objdoc.Id = ds.Tables[0].Rows[i]["Id"].NulllToLong();
        //                objdoc.TypeName = ds.Tables[0].Rows[i]["TypeName"].NulllToString();
        //                objdoc.ServiceName = ds.Tables[0].Rows[i]["ServiceName"].NulllToString();
        //                objdoc.GST = ds.Tables[0].Rows[i]["GST"].NulllToDecimal();
        //                //objdoc.TotalAmount = ds.Tables[0].Rows[i]["TotalAmount"].NulllToDecimal();
        //                //objdoc.Tax = ds.Tables[0].Rows[i]["Tax"].NulllToDecimal();
        //                //objdoc.GrandTotal = ds.Tables[0].Rows[i]["GrandTotal"].NulllToDecimal();
        //                objdoc.IsActive = ds.Tables[0].Rows[i]["IsActive"].NulllToInt();
        //                objdoc.FromDate = ((DateTime)ds.Tables[0].Rows[i]["FromDate"]).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture).NulllToString();
        //                objdoc.ToDate = ((DateTime)ds.Tables[0].Rows[i]["ToDate"]).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture).NulllToString();
        //                //objdoc.GrandTotal = ds.Tables[0].Rows[i]["GrandTotal"].NulllToDecimal();
        //                objdoc.IsActive = ds.Tables[0].Rows[i]["IsActive"].NulllToInt();
        //                objdoc.ApplicableChargesType = ds.Tables[0].Rows[i]["ApplicableChargesType"].NulllToString();
        //                //objdoc.ChargesType= ds.Tables[0].Rows[i]["ChargesType"].ToString();
        //                objdoc.TaxTypeName = ds.Tables[0].Rows[i]["TaxName"].NulllToString();
        //                objdoc.UnitName = ds.Tables[0].Rows[i]["UnitName"].NulllToString();
        //                objCategormaster.Add(objdoc);

        //            }

        //        }
        //        else
        //        {
        //            objCategormaster = null;
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        objCategormaster = null;
        //        ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetApplicableGstDetails");
        //    }
        //    return objCategormaster;
        //}

        //public List<GSTApplicable> GetApplicableGstDetails()
        //{
        //    List<GSTApplicable> objCategormaster = new List<GSTApplicable>();
        //    try
        //    {
                
        //        DataSet ds = BaseFunction.FillDataSet("[mst].[USP_ADMIN_ServiceTaxConfig_View]");
        //        if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
        //        {
        //            objCategormaster = new List<GSTApplicable>();

        //            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //            {
        //                GSTApplicable objdoc = new GSTApplicable();
        //                objdoc.Id = ds.Tables[0].Rows[i]["iPK_GstId"].NulllToLong();
        //                objdoc.TypeName = ds.Tables[0].Rows[i]["TypeName"].NulllToString();
        //                objdoc.ServiceName = ds.Tables[0].Rows[i]["ServiceName"].NulllToString();
        //                objdoc.GST = ds.Tables[0].Rows[i]["GST"].NulllToDecimal();
        //                //objdoc.TotalAmount = ds.Tables[0].Rows[i]["TotalAmount"].NulllToDecimal();
        //                //objdoc.Tax = ds.Tables[0].Rows[i]["Tax"].NulllToDecimal();
        //                //objdoc.GrandTotal = ds.Tables[0].Rows[i]["GrandTotal"].NulllToDecimal();
        //                objdoc.IsActive = ds.Tables[0].Rows[i]["IsActive"].NulllToInt();
        //                objdoc.FromDate = ((DateTime)ds.Tables[0].Rows[i]["FromDate"]).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture).NulllToString();
        //                objdoc.ToDate = ((DateTime)ds.Tables[0].Rows[i]["ToDate"]).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture).NulllToString();
        //                //objdoc.GrandTotal = ds.Tables[0].Rows[i]["GrandTotal"].NulllToDecimal();
        //                objdoc.IsActive = ds.Tables[0].Rows[i]["IsActive"].NulllToInt();
        //                objdoc.ApplicableChargesType = ds.Tables[0].Rows[i]["sAplcblChrgTyp"].NulllToString();
        //                //objdoc.ChargesType= ds.Tables[0].Rows[i]["ChargesType"].ToString();
        //                objdoc.TaxTypeName = ds.Tables[0].Rows[i]["TaxName"].NulllToString();
        //                objdoc.UnitName = ds.Tables[0].Rows[i]["UnitName"].NulllToString();
        //                objCategormaster.Add(objdoc);

        //            }

        //        }
        //        else
        //        {
        //            objCategormaster = null;
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        objCategormaster = null;
        //        ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetApplicableGstDetails");
        //    }
        //    return objCategormaster;
        //}
        #endregion
        //public List<PandingPaymentList> PaymentPendingList(string StringPara)
        //{
        //    //List<PandingPaymentList> _result = new List<PartyPaymentCollect>();
        //    List<PandingPaymentList> _resultModel = new List<PandingPaymentList>();
        //    try
        //    {
                
        //        SqlParameter[] param = new SqlParameter[1];
        //        param[0] = new SqlParameter("@StringType", StringPara);
        //        DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_ADMIN_PaymentDetails_View]",param);
        //        if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
        //        {
        //            // First tabe
        //            if (ds.Tables[0].Rows.Count > 0)
        //            {
        //                foreach (DataRow dr in ds.Tables[0].Rows)
        //                {

        //                    _resultModel.Add(new PandingPaymentList()
        //                    {
        //                        PayTrackingId = dr["iPK_PaytrckngId"].NulllToInt(),
        //                        OrderId = dr["iFK_OrdrId"].NulllToString(),
        //                        PartyId = dr["sPrtyCode"].NulllToString(),
        //                        Party = dr["Party"].NulllToString(),
        //                        Name = dr["PartyName"].NulllToString(),
        //                        StateCity = dr["Address"].NulllToString(),
        //                        Charges = dr["dPayblAmt"].NulllToDecimal(),
        //                        Transactionamt = dr["dTrnsctnAmt"].NulllToDecimal(),
        //                        BalanceAmt = dr["dBlncAmt"].NulllToDecimal(),
        //                        RegistrationNo = dr["RegistrationNo"].NulllToString()
        //                    });
        //                }
        //                return _resultModel;
        //                //_result.GrandTotal = _result.GrandTotal + dr["Amount"].NulllToDecimal();
        //            }
        //            //_result.Message = BO.CustomBO.CustomMessage.DATAFOUND;
        //            //_result.Flag = BO.CustomBO.CustomMessage.DATAFOUND_RESPONSECODE.NulllToInt();

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        //_result.Message = BO.CustomBO.CustomMessage.EXCEPTIONOCCURRED;
        //        //_result.Flag = BO.CustomBO.CustomMessage.EXCEPTIONOCCURRED_RESPONSECODE.NulllToInt();
        //        return _resultModel;
        //    }
        //    return _resultModel;
        //}
        //public PartyProfile GetPartyDetails(PartyProfile obj)
        //{

        //    PartyProfile returnModel = new PartyProfile();
        //    try
        //    {
                
        //        SqlParameter[] param = new SqlParameter[2];
        //        param[0] = new SqlParameter("@StringType", obj.StringType);
        //        param[1] = new SqlParameter("@PartyId", obj.PartyId);
        //        DataSet ds = BaseFunction.FillDataSet("[dbo].[GetPartyRegistrationDetails]", param);
        //        if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
        //        {
        //            if (ds.Tables[0].Rows.Count > 0)
        //            {
        //                foreach (DataRow dr in ds.Tables[0].Rows)
        //                {
        //                    returnModel.PartyId = dr["PartyId"].NulllToString();
        //                    returnModel.Type = dr["Type"].NulllToInt();
        //                    returnModel.CompanyId = dr["CompanyId"].NulllToInt();
        //                    returnModel.PartyCode = dr["PartyCode"].NulllToInt();
        //                    returnModel.FirstName = dr["FirstName"].NulllToString();
        //                    returnModel.MiddleName = dr["MiddleName"].NulllToString();
        //                    returnModel.LastName = dr["LastName"].NulllToString();
        //                    returnModel.MobileNumber = dr["MobileNumber"].NulllToString();
        //                    returnModel.EmailId = dr["EmailId"].NulllToString();
        //                    returnModel.CityId = dr["City"].NulllToInt();
        //                    returnModel.StateId = dr["State"].NulllToInt();
        //                    returnModel.RoleId = dr["SystemRole"].NulllToInt();
        //                    returnModel.DateofBirth = dr["DateofBirth"].NulllToDateTime();

        //                    returnModel.CurrentAddressLine1 = dr["CurrentAddressLine1"].NulllToString();
        //                    returnModel.CurrentAddressLine2 = dr["CurrentAddressLine2"].NulllToString();
        //                    returnModel.CurrentAddressLine3 = dr["CurrentAddressLine3"].NulllToString();
        //                    returnModel.CurrentAddressPincode = dr["CurrentAddressPincode"].NulllToString();

        //                    returnModel.ParmentAddressLine1 = dr["ParmentAddressLine1"].NulllToString();
        //                    returnModel.ParmentAddressLine2 = dr["ParmentAddressLine2"].NulllToString();
        //                    returnModel.ParmentAddressLine3 = dr["ParmentAddressLine3"].NulllToString();
        //                    returnModel.ParmentAddressPincode = dr["ParmentAddressPincode"].NulllToString();

        //                    returnModel.CompanyContactNumber = dr["CompanyContactNo"].NulllToString();
        //                    returnModel.CompanyEmail = dr["CompanyEmail"].NulllToString();
        //                    returnModel.CompanyGSTNo = dr["CompanyGSTNo"].NulllToString();
        //                    returnModel.CompanyGSTNo = dr["CompanyTanNo"].NulllToString();

        //                    returnModel.CompanyAddressLine1 = dr["CompanyAddressLine1"].NulllToString();
        //                    returnModel.CompanyAddressLine2 = dr["CompanyAddressLine2"].NulllToString();
        //                    returnModel.CompanyAddressLine3 = dr["CompanyAddressLine3"].NulllToString();
        //                    returnModel.CompanyAddressPincode = dr["CompanyAddressPincode"].NulllToString();

        //                    returnModel.ResponseCode = dr["Flag"].NulllToString();
        //                    returnModel.Message = dr["Message"].NulllToString();
        //                }
        //            }
        //            else
        //            {
        //                objResponseData.Message = BO.CustomMessage.NORECORDFOUND;
        //                objResponseData.ResponseCode = BO.CustomMessage.NORECORDFOUND_RESPONSECODE.ToString();
        //            }

        //        }
        //        else
        //        {
        //            objResponseData.Message = BO.CustomMessage.NORECORDFOUND;
        //            objResponseData.ResponseCode = BO.CustomMessage.NORECORDFOUND_RESPONSECODE.ToString();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        objResponseData.Message = BO.CustomMessage.EXCEPTIONOCCURRED;
        //        objResponseData.ResponseCode = BO.CustomMessage.EXCEPTIONOCCURRED_RESPONSECODE.ToString();
        //        return returnModel;
        //    }
        //    return returnModel;
        //}

        //public PartyPaymentCollect GetPartyPaymentCollectionByPartyId(PandingPaymentList obj)
        //{
        //    PartyPaymentCollect _result = new PartyPaymentCollect();
        //    _result.partsummary = new Partsummary();
        //    _result.ServiesDetailsList = new List<ServiesDetails>();
        //    try
        //    {
                
        //        SqlParameter[] param = new SqlParameter[3];
        //        param[0] = new SqlParameter("@StringType", obj.StringType);
        //        param[1] = new SqlParameter("@PayTrackingId", obj.PayTrackingId);
        //        param[2] = new SqlParameter("@PartyId", obj.PartyId);
        //        DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_ADMIN_PaymentDetails_View]", param);
        //        if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
        //        {
        //            // First tabe
        //            if (ds.Tables[0].Rows.Count > 0)
        //            {
        //                _result.partsummary.PartyId = ds.Tables[0].Rows[0]["sPK_PrtyCode"].NulllToString();
        //                _result.partsummary.Name = ds.Tables[0].Rows[0]["sName"].NulllToString();
        //                _result.partsummary.MobileNumber = ds.Tables[0].Rows[0]["sMobileNo"].NulllToString();
        //                _result.partsummary.Email = ds.Tables[0].Rows[0]["sEmailId"].NulllToString();
        //                _result.partsummary.Address = ds.Tables[0].Rows[0]["ParmentAddress"].NulllToString();
        //                _result.partsummary.PayTrackingId = ds.Tables[0].Rows[0]["PayTrackingId"].NulllToInt();
        //                _result.partsummary.BalanceAmount = ds.Tables[0].Rows[0]["BalancaAmt"].NulllToInt();

        //            }

        //            if (ds.Tables[1].Rows.Count > 0)
        //            {

        //                foreach (DataRow dr in ds.Tables[1].Rows)
        //                {

        //                    //if (dr["chargeType"].NulllToString() != "GST")
        //                    //{

        //                    _result.ServiesDetailsList.Add(new ServiesDetails()
        //                    {
        //                        PartyId = dr["sPrtyCode"].NulllToString(),
        //                        ServiceType = dr["Servicetype"].NulllToString(),
        //                        Service = dr["Name"].ToString(),
        //                        ChargeType = dr["chargeType"].NulllToString(),
        //                        Charge = dr["Amount"].NulllToDecimal(),
        //                        GST = dr["dGstAmnt"].NulllToDecimal(),
        //                        IGST = dr["dIGST"].NulllToDecimal(),
        //                        CGST = dr["dCGST"].NulllToDecimal(),
        //                        ServiceCharge = dr["dSrvcChrgs"].NulllToDecimal(),
        //                        Commision = dr["dCmmssn"].NulllToDecimal(),
        //                        CourierCharge = dr["dCrrChrgs"].NulllToDecimal(),
        //                        TotalAmount = dr["TotalAmount"].NulllToDecimal(),
        //                    });
        //                    //}
        //                    if (dr["Servicetype"].NulllToString() == "service")
        //                    {
        //                        _result.GrandTotal = _result.GrandTotal + dr["Amount"].NulllToDecimal();
        //                    }
        //                    else
        //                    {
        //                        _result.GrandTotal = _result.GrandTotal + dr["Amount"].NulllToDecimal() + dr["GstAmount"].NulllToDecimal();
        //                    }
        //                    //_result.GrandTotal = _result.GrandTotal + dr["TotalAmount"].NulllToDecimal();
        //                }
        //                foreach (DataRow dr2 in ds.Tables[2].Rows)
        //                {
        //                    _result.serviceGst = _result.serviceGst + dr2["dGstAmnt"].NulllToDecimal();
        //                }
        //                _result.GrandTotal = _result.GrandTotal + _result.serviceGst;
        //                _result.Message = BO.CustomMessage.DATAFOUND;
        //                _result.Flag = BO.CustomMessage.DATAFOUND_RESPONSECODE.NulllToInt();

        //            }
        //        }
        //        return _result;
        //    }
        //    catch (Exception ex)
        //    {
        //        _result.Message = BO.CustomMessage.EXCEPTIONOCCURRED;
        //        _result.Flag = BO.CustomMessage.EXCEPTIONOCCURRED_RESPONSECODE.NulllToInt();
        //        return _result;
        //    }
        //    //return _result;
        //}

        //public ResponseData SavePaymentCollection(PaymentCollectionModel obj)
        //{
        //    DataSet ds = new DataSet();
        //    try
        //    {
                
        //        SqlParameter[] param = new SqlParameter[10];
        //        param[0] = new SqlParameter("@PayTrackingId", obj.PayTrackingId);
        //        param[1] = new SqlParameter("@OrderId", obj.OrderId);
        //        param[2] = new SqlParameter("@PartyId", obj.PartyId);
        //        param[3] = new SqlParameter("@TransactionAmt", obj.CollectedAmt);
        //        param[4] = new SqlParameter("@Mode", "704");
        //        param[5] = new SqlParameter("@PaymentMode", obj.PaymentMode);
        //        param[6] = new SqlParameter("@Bank", obj.Bank);
        //        param[7] = new SqlParameter("@Account", obj.AccountNumber);
        //        param[8] = new SqlParameter("@ChequeNo", obj.ChequeNumber);
        //        param[9] = new SqlParameter("@CollectedBy", obj.RecivedBy);
        //        ds = BaseFunction.FillDataSet("[dbo].[USP_Admin_PaymentCollection_Save]", param);
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
        //public List<PandingPaymentList> ChequePendingList(string obj)
        //{
        //    List<PandingPaymentList> _resultModel = new List<PandingPaymentList>();
        //    try
        //    {
                
        //        SqlParameter[] param = new SqlParameter[1];
        //        param[0] = new SqlParameter("@StringType", obj);
        //        DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_ADMIN_PaymentDetails_View]", param);
        //        if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
        //        {
        //            if (ds.Tables[0].Rows.Count > 0)
        //            {
        //                foreach (DataRow dr in ds.Tables[0].Rows)
        //                {

        //                    _resultModel.Add(new PandingPaymentList()
        //                    {
        //                        PayTrackingId = dr["iPK_PaytrckngId"].NulllToInt(),
        //                        OrderId = dr["iFK_OrdrId"].NulllToString(),
        //                        PartyId = dr["sPrtyCode"].NulllToString(),
        //                        Party = dr["Party"].NulllToString(),
        //                        Name = dr["PartyName"].NulllToString(),
        //                        StateCity = dr["Address"].NulllToString(),
        //                        Charges = dr["dPayblAmt"].NulllToDecimal(),
        //                        Transactionamt = dr["dTrnsctnAmt"].NulllToDecimal(),
        //                        BalanceAmt = dr["dBlncAmt"].NulllToDecimal(),
        //                        ChequeNo = dr["sChequeNo"].NulllToString(),
        //                        RegistrationNo = dr["RegistrationNo"].NulllToString()
        //                    });
        //                }
        //                return _resultModel;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return _resultModel;
        //    }
        //    return _resultModel;
        //}
        //public ResponseData ChequeClear(PaymentCollectionModel obj)
        //{
        //    DataSet ds = new DataSet();
        //    try
        //    {
                
        //        SqlParameter[] param = new SqlParameter[3];
        //        param[0] = new SqlParameter("@PayTrackingId", obj.PayTrackingId);
        //        param[1] = new SqlParameter("@OrderId", obj.OrderId);
        //        param[2] = new SqlParameter("@PartyId", obj.PartyId);
        //        ds = BaseFunction.FillDataSet("[dbo].[USP_ACCOUNT_ChequeClearance_SaveUpdate]", param);
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
        //public List<PandingPaymentList> ChequeUnClearedList(string obj)
        //{
        //    //List<PandingPaymentList> _result = new List<PartyPaymentCollect>();
        //    List<PandingPaymentList> _resultModel = new List<PandingPaymentList>();

        //    try
        //    {
                
        //        SqlParameter[] param = new SqlParameter[1];
        //        param[0] = new SqlParameter("@StringType", obj);
        //        DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_ADMIN_PaymentDetails_View]", param);
        //        if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
        //        {
        //            // First tabe


        //            if (ds.Tables[0].Rows.Count > 0)
        //            {
        //                foreach (DataRow dr in ds.Tables[0].Rows)
        //                {

        //                    _resultModel.Add(new PandingPaymentList()
        //                    {
        //                        PayTrackingId = dr["iPK_PaytrckngId"].NulllToInt(),
        //                        OrderId = dr["iFK_OrdrId"].NulllToString(),
        //                        PartyId = dr["sPrtyCode"].NulllToString(),
        //                        Party = dr["Party"].NulllToString(),
        //                        Name = dr["PartyName"].NulllToString(),
        //                        StateCity = dr["Address"].NulllToString(),
        //                        Charges = dr["dPayblAmt"].NulllToDecimal(),
        //                        Transactionamt = dr["dTrnsctnAmt"].NulllToDecimal(),
        //                        BalanceAmt = dr["dBlncAmt"].NulllToDecimal(),
        //                        ChequeNo = dr["sChequeNo"].NulllToString(),
        //                        RegistrationNo = dr["RegistrationNo"].NulllToString()
        //                    });
        //                }
        //                return _resultModel;
        //                //_result.GrandTotal = _result.GrandTotal + dr["Amount"].NulllToDecimal();
        //            }
        //            //_result.Message = BO.CustomBO.CustomMessage.DATAFOUND;
        //            //_result.Flag = BO.CustomBO.CustomMessage.DATAFOUND_RESPONSECODE.NulllToInt();

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        //_result.Message = BO.CustomBO.CustomMessage.EXCEPTIONOCCURRED;
        //        //_result.Flag = BO.CustomBO.CustomMessage.EXCEPTIONOCCURRED_RESPONSECODE.NulllToInt();
        //        return _resultModel;
        //    }
        //    return _resultModel;
        //}
        //public ResponseData ChequeUnClear(PaymentCollectionModel obj)
        //{
        //    DataSet ds = new DataSet();
        //    try
        //    {
                
        //        SqlParameter[] param = new SqlParameter[3];
        //        param[0] = new SqlParameter("@PayTrackingId", obj.PayTrackingId);
        //        param[1] = new SqlParameter("@OrderId", obj.OrderId);
        //        param[2] = new SqlParameter("@PartyId", obj.PartyId);
        //        ds = BaseFunction.FillDataSet("[dbo].[USP_ACCOUNT_ChequeUnClear_SaveUpdate]", param);
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

        //public ResponseData ChequeCancel(PaymentCollectionModel obj)
        //{
        //    DataSet ds = new DataSet();
        //    try
        //    {
                
        //        SqlParameter[] param = new SqlParameter[4];
        //        param[0] = new SqlParameter("@PayTrackingId", obj.PayTrackingId);
        //        param[1] = new SqlParameter("@OrderId", obj.OrderId);
        //        param[2] = new SqlParameter("@PartyId", obj.PartyId);
        //        param[3] = new SqlParameter("@CanceledBy", "");
        //        ds = BaseFunction.FillDataSet("[dbo].[USP_ACCOUNT_ChequeUnClear_SaveUpdate]", param);


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
        //public CompanyConsumptionList ServiceProviderWiseConsumptionList()
        //{
        //    CompanyConsumptionList ConsumptionList = new CompanyConsumptionList();
        //    try
        //    {
                
        //        SqlParameter[] param = new SqlParameter[1];
        //        param[0] = new SqlParameter("@Type", "ConsumptionList");
        //        DataSet ds = BaseFunction.FillDataSet("[mst].[ServiceProviderWiseConsuption]", param);
        //        ConsumptionList.CompanyConsumptionLst = new List<CompanyConsumption>();
        //        if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
        //        {
        //            if (ds.Tables[0].Rows.Count > 0 && ds.Tables.Count > 1)
        //            {
        //                ConsumptionList.ResponseCode = ds.Tables[0].Rows[0]["Flag"].NulllToString();
        //                ConsumptionList.Messsage = ds.Tables[0].Rows[0]["Message"].NulllToString();
        //                foreach (DataRow DR in ds.Tables[1].Rows)
        //                {
        //                    ConsumptionList.CompanyConsumptionLst.Add(
        //                    new CompanyConsumption
        //                    {
        //                        PartyId = DR["PartyId"].ToString(),
        //                        ServiceProvider = DR["ServiceProvider"].ToString(),
        //                        ServiceType = DR["ServiceType"].ToString(),
        //                        AvgDailyConsumption = DR["AvgDailyConsumption"].NulllToDecimal(),
        //                        LeadTimeInDay = DR["LeadTimeInDay"].NulllToDecimal(),
        //                        Safetyfactor = DR["Safetyfactor"].NulllToDecimal(),
        //                        maxConsumption = DR["maxConsumption"].NulllToDecimal(),
        //                        Status = DR["Status"].ToString(),
        //                    }
        //                 );

        //                }
        //            }
        //            else
        //            {
        //                ConsumptionList.ResponseCode = ds.Tables[0].Rows[0]["Flag"].NulllToString();
        //                ConsumptionList.Messsage = ds.Tables[0].Rows[0]["Message"].NulllToString();
        //            }
        //        }
        //        else
        //        {
        //            ConsumptionList.ResponseCode = "0";
        //            ConsumptionList.Messsage = "Data Not Found";
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        ConsumptionList.ResponseCode = "5";
        //        ConsumptionList.Messsage = "Invalid Request! Please contact Support...";
        //        ExceptionLogDL.SendExcepToDB(ex, 0, "ClientWalletRechargeDL:ClientWalletRequest");
        //    }
        //    return ConsumptionList;
        //}
        //public ErrorBO ConsumptionRequest(CompanyConsumption request)
        //{
        //    try
        //    {
                
        //        SqlParameter[] param = new SqlParameter[7];
        //        param[0] = new SqlParameter("@Type", "Insert_CompanyConsumption");
        //        param[1] = new SqlParameter("@PartyId", request.PartyId);
        //        param[2] = new SqlParameter("@ServiceProvider", request.ServiceProvider);
        //        param[3] = new SqlParameter("@ServiceType", request.ServiceType);
        //        param[4] = new SqlParameter("@AvgDailyConsumption", request.AvgDailyConsumption);
        //        param[5] = new SqlParameter("@LeadTimeInDay", request.LeadTimeInDay);
        //        param[6] = new SqlParameter("@Safetyfactor", request.Safetyfactor);
        //        DataTable DT = BaseFunction.FillDataTable("[mst].[ServiceProviderWiseConsuption]", param);
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
        //        ExceptionLogDL.SendExcepToDB(ex, 0, "AdminDL:ConsumptionRequest");
        //        _Access.ResponseCode = "5";
        //        _Access.Messsage = "Details Not Found-Ex!Please Contact Support.";
        //        return _Access;
        //    }
        //}

        public ChangeRquestDataList ChangeRequestList(string PartyId, int PartyType = 0)
        {
            ChangeRquestDataList _resultModel = new ChangeRquestDataList();
            _resultModel.ExistingParentDetails = new ClientRequestData();
            _resultModel.RequestedParentDetails = new ClientRequestData();
            _resultModel.ParentDetails = new List<ClientRequestData>();
            try
            {
                
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@StringType", "RequestSend");
                param[1] = new SqlParameter("@PartyId", PartyId);
                param[2] = new SqlParameter("@PartyType", PartyType);
                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_OPERATION_ChangeRequest_View]", param);

                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    // First tabe
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            //_resultModel.Add(new ClientRequestData()
                            //{
                            _resultModel.ExistingParentDetails.PartyId = dr["sPK_PrtyCode"].NulllToString();
                            _resultModel.ExistingParentDetails.PartyType = dr["Party"].NulllToString();
                            _resultModel.ExistingParentDetails.ParentId = dr["sPrntId"].NulllToString();
                            _resultModel.ExistingParentDetails.RegistrationId = dr["sRegNo"].NulllToString();
                            _resultModel.ExistingParentDetails.Name = dr["PartyName"].NulllToString();
                            _resultModel.ExistingParentDetails.EmailId = dr["sEmailId"].NulllToString();
                            _resultModel.ExistingParentDetails.Mobilenumber = dr["sMobileNo"].NulllToString();
                            _resultModel.ExistingParentDetails.District = dr["DistrictId"].NulllToString();
                            _resultModel.ExistingParentDetails.State = dr["StateId"].NulllToString();
                            _resultModel.ExistingParentDetails.CompanyAddress = dr["CompanyAddress"].NulllToString();
                            _resultModel.ExistingParentDetails.IsActive = dr["iIsActv"].NulllToInt();
                            _resultModel.ExistingParentDetails.Currentstatus = dr["CurrentStatus"].NulllToString();
                            //});
                        }
                        //_result.GrandTotal = _result.GrandTotal + dr["Amount"].NulllToDecimal();
                    }

                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables[1].Rows)
                        {

                            //_resultModel.Add(new ClientRequestData()
                            //{
                            //_resultModel.RequestedParentDetails.IsParentKnow == false
                            if (dr["bIsPrntKnow"].NulllToBoolean() == false)
                            {
                                _resultModel.RequestedParentDetails.RegistrationId = dr["sRegNo"].NulllToString();
                                _resultModel.RequestedParentDetails.Currentstatus = dr["CurrentStatus"].NulllToString();
                            }
                            else
                            {
                                _resultModel.RequestedParentDetails.PartyId = dr["sPK_PrtyCode"].NulllToString();
                                _resultModel.RequestedParentDetails.PartyType = dr["Party"].NulllToString();
                                _resultModel.RequestedParentDetails.ParentId = dr["sPrntId"].NulllToString();
                                _resultModel.RequestedParentDetails.RegistrationId = dr["sRegNo"].NulllToString();
                                _resultModel.RequestedParentDetails.Name = dr["PartyName"].NulllToString();
                                _resultModel.RequestedParentDetails.EmailId = dr["sEmailId"].NulllToString();
                                _resultModel.RequestedParentDetails.Mobilenumber = dr["sMobileNo"].NulllToString();
                                _resultModel.RequestedParentDetails.District = dr["DistrictId"].NulllToString();
                                _resultModel.RequestedParentDetails.State = dr["StateId"].NulllToString();
                                _resultModel.RequestedParentDetails.CompanyAddress = dr["CompanyAddress"].NulllToString();
                                _resultModel.RequestedParentDetails.IsActive = dr["iIsActv"].NulllToInt();
                                _resultModel.RequestedParentDetails.Currentstatus = dr["CurrentStatus"].NulllToString();
                                _resultModel.RequestedParentDetails.Narration = dr["sNarration"].NulllToString();
                            }
                            //});
                        }
                        //_result.GrandTotal = _result.GrandTotal + dr["Amount"].NulllToDecimal();
                    }
                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables[2].Rows)
                        {

                            _resultModel.ParentDetails.Add(new ClientRequestData()
                            {
                                PartyId = dr["sPK_PrtyCode"].NulllToString(),
                                PartyType = dr["Party"].NulllToString(),
                                ParentId = dr["sPrntId"].NulllToString(),
                                RegistrationId = dr["sRegNo"].NulllToString(),
                                Name = dr["PartyName"].NulllToString(),
                                EmailId = dr["sEmailId"].NulllToString(),
                                Mobilenumber = dr["sMobileNo"].NulllToString(),
                                District = dr["DistrictId"].NulllToString(),
                                State = dr["StateId"].NulllToString(),
                                CompanyAddress = dr["CompanyAddress"].NulllToString(),
                                IsActive = dr["iIsActv"].NulllToInt(),
                                Currentstatus = dr["CurrentStatus"].NulllToString(),
                            });
                        }
                        //_result.GrandTotal = _result.GrandTotal + dr["Amount"].NulllToDecimal();
                    }
                    //_result.Message = BO.CustomBO.CustomMessage.DATAFOUND;
                    //_result.Flag = BO.CustomBO.CustomMessage.DATAFOUND_RESPONSECODE.NulllToInt();

                }

            }
            catch (Exception ex)
            {
                return _resultModel;
            }
            return _resultModel;
        }

        //public List<ClientSwitchRequestData> GetChangeRequestListNew(string PartyId)
        //{
        //    List<ClientSwitchRequestData> _result = new List<ClientSwitchRequestData>();

        //    try
        //    {

                
        //        SqlParameter[] param = new SqlParameter[2];
        //        param[0] = new SqlParameter("@StringType", "AllPendingRequestList");
        //        param[1] = new SqlParameter("@PartyId", PartyId);
        //        DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_OPERATION_ChangeRequest_View]", param);
        //        if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
        //        {
        //            // First tabe
        //            if (ds.Tables[0].Rows.Count > 0)
        //            {
        //                foreach (DataRow dr in ds.Tables[0].Rows)
        //                {
        //                    _result.Add(new ClientSwitchRequestData
        //                    {
        //                        //From Request
        //                        PartyId = dr["PartyId"].NulllToString(),
        //                        RegistrationNo = dr["PartyRegistrationNo"].NulllToString(),
        //                        PartyType = dr["PartyType"].NulllToString(),
        //                        Currentstatus = dr["CurrentStatus"].NulllToString(),
        //                        MainWalletBalance = dr["MainWalletBalance"].NulllToDouble(),
        //                        PartyName = dr["PartyName"].NulllToString(),

        //                        FromParentId = dr["FromParentId"].NulllToString(),
        //                        FromParentRegistrationNo = dr["FromRegistrationNo"].NulllToString(),
        //                        FromParentPartyType = dr["FromPartyType"].NulllToString(),
        //                        FromParentName = dr["FromParentName"].NulllToString(),
        //                        FromMainWalletBalance = dr["FromMainWalletBalance"].NulllToDouble(),

        //                        ToParentId = dr["ToPartyId"].NulllToString(),
        //                        ToParentName = dr["ToParentName"].NulllToString(),
        //                        ToParentRegistrationNo = dr["ToRegistrationNo"].NulllToString(),
        //                        ToParentPartyType = dr["ToPartyType"].NulllToString(),
        //                        ToMainWalletBalance = dr["ToMainWalletBalance"].NulllToDouble(),
        //                        Switchtype = dr["sSwtchTyp"].NulllToString(),
        //                        SwitchRequestId = dr["iPK_SwtchRqstId"].NulllToInt()
        //                    });
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    return _result;
        //}

        public ResponseData SaveChangeRequest(string PartyId, string ParentId)
        {
            DataSet ds = new DataSet();
            try
            {
                
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@PartyId", PartyId);
                param[1] = new SqlParameter("@ParentId", ParentId);
                ds = BaseFunction.FillDataSet("[dbo].[USP_OPERATION_ChangeRequest_Save]", param);
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        objResponseData.Message = ds.Tables[0].Rows[0]["Message"].NulllToString();
                        objResponseData.ResponseCode = ds.Tables[0].Rows[0]["Flag"].NulllToString();
                        return objResponseData;
                    }
                    else
                    {
                        objResponseData.Message = CustomMessage.NORECORDFOUND;
                        objResponseData.ResponseCode = CustomMessage.NORECORDFOUND_RESPONSECODE.ToString();
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
                objResponseData.Message = CustomMessage.EXCEPTIONOCCURRED;
                objResponseData.ResponseCode = CustomMessage.EXCEPTIONOCCURRED_RESPONSECODE.ToString();
                return objResponseData;
            }
        }

        public List<ClientRequestData> GetChangeRequestList(string PartyId)
        {
            List<ClientRequestData> _result = new List<ClientRequestData>();
            try
            {
                
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@StringType", "AllRequestSendList");
                param[1] = new SqlParameter("@PartyId", PartyId);
                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_OPERATION_ChangeRequest_View]", param);

                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    // First tabe
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            _result.Add(new ClientRequestData
                            {
                                //From Request
                                PartyId = dr["ToPartyId"].NulllToString(),
                                PartyType = dr["PartyType"].NulllToString(),
                                //ParentId = dr["ToParentId"].NulllToString(),
                                //RegistrationId = dr["ToRegistrationNo"].NulllToString(),
                                //Name = dr["ToParentName"].NulllToString(),
                                //EmailId = dr["ToEmailId"].NulllToString(),
                                Mobilenumber = dr["ToDistrictId"].NulllToString(),
                                //District = dr["ToDistrictId"].NulllToString(),
                                //State = dr["ToStateId"].NulllToString(),
                                CompanyAddress = dr["ToCompanyAddress"].NulllToString(),
                                //From Request
                                //To Request
                                FromPartyId = dr["FromPartyId"].NulllToString(),
                                FromName = dr["FromPartyName"].NulllToString(),
                                FromPartyType = dr["FromPartyType"].NulllToString(),
                                //FromParentId = dr["FromParentId"].NulllToString(),
                                FromRegistrationId = dr["FromRegistrationNo"].NulllToString(),

                                FromEmailId = dr["FromEmailId"].NulllToString(),
                                FromMobilenumber = dr["FromMobileNumber"].NulllToString(),
                                FromDistrict = dr["FromDistrictId"].NulllToString(),
                                FromState = dr["FromStateId"].NulllToString(),
                                FromCompanyAddress = dr["FromCompanyAddress"].NulllToString(),
                                //ToRequest
                                IsActive = dr["iIsActv"].NulllToInt(),
                                Currentstatus = dr["CurrentStatus"].NulllToString(),
                            });
                        }
                    }
                }

            }
            catch (Exception ex)
            {

            }
            return _result;
        }

        public ResponseData RejectChangeRequest(string PartyId, string LoginId)
        {
            DataSet ds = new DataSet();
            try
            {
                
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@Type", "Reject_Parent");
                param[1] = new SqlParameter("@PartyId", PartyId);
                param[2] = new SqlParameter("@FromParentID", LoginId);
                ds = BaseFunction.FillDataSet("[dbo].[USP_OPERATION_SwitchParentRequestApproveReject_SaveUpdate]", param);


                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        objResponseData.Message = ds.Tables[0].Rows[0]["Message"].NulllToString();
                        objResponseData.ResponseCode = ds.Tables[0].Rows[0]["Flag"].NulllToString();
                        return objResponseData;
                    }
                    else
                    {
                        objResponseData.Message = CustomMessage.NORECORDFOUND;
                        objResponseData.ResponseCode = CustomMessage.NORECORDFOUND_RESPONSECODE.ToString();
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
                objResponseData.Message = CustomMessage.EXCEPTIONOCCURRED;
                objResponseData.ResponseCode = CustomMessage.EXCEPTIONOCCURRED_RESPONSECODE.ToString();
                return objResponseData;
            }
        }

        public ResponseData ApprovedChangeRequest(string PartyId, string LoginId)
        {
            DataSet ds = new DataSet();
            try
            {
                
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@Type", "Approved_Parent");
                param[1] = new SqlParameter("@PartyId", PartyId);
                param[2] = new SqlParameter("@FromParentID", LoginId);
                ds = BaseFunction.FillDataSet("[dbo].[USP_OPERATION_SwitchParentRequestApproveReject_SaveUpdate]", param);



                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        objResponseData.Message = ds.Tables[0].Rows[0]["Message"].NulllToString();
                        objResponseData.ResponseCode = ds.Tables[0].Rows[0]["Flag"].NulllToString();
                        return objResponseData;
                    }
                    else
                    {
                        objResponseData.Message = CustomMessage.NORECORDFOUND;
                        objResponseData.ResponseCode = CustomMessage.NORECORDFOUND_RESPONSECODE.ToString();
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
                objResponseData.Message = CustomMessage.EXCEPTIONOCCURRED;
                objResponseData.ResponseCode = CustomMessage.EXCEPTIONOCCURRED_RESPONSECODE.ToString();
                return objResponseData;
            }
        }
        #endregion

        //public ClientSwitchRequestData GetChangeRequestData(string PartyId, string LoginId)
        //{
        //    ClientSwitchRequestData _result = new ClientSwitchRequestData();
        //    DataSet ds = new DataSet();
        //    try
        //    {
                
        //        SqlParameter[] param = new SqlParameter[3];
        //        param[0] = new SqlParameter("@Type", "GetChangeRequestDetail");
        //        param[1] = new SqlParameter("@PartyId", PartyId);
        //        param[2] = new SqlParameter("@LoginId", LoginId);
        //        ds = BaseFunction.FillDataSet("[dbo].[USP_OPERATION_GetDetailsVendorWiseWhileParentChangeRequest_View]", param);
        //        if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
        //        {
        //            if (ds.Tables[0].Rows.Count > 0)
        //            {
        //                _result.Messsage = ds.Tables[0].Rows[0]["Message"].NulllToString();
        //                _result.ResponseCode = ds.Tables[0].Rows[0]["Flag"].NulllToString();
        //            }
        //            if (ds.Tables[1].Rows.Count > 0)
        //            {
        //                _result.SwitchRequestId = ds.Tables[1].Rows[0]["iPK_SwtchRqstId"].NulllToInt();
        //                _result.Switchtype = ds.Tables[1].Rows[0]["sSwtchTyp"].NulllToString();
        //                _result.IsParentKnow = ds.Tables[1].Rows[0]["bIsPrntKnow"].NulllToBoolean();
        //                _result.PartyId = ds.Tables[1].Rows[0]["SPrtyCode"].NulllToString();
        //                _result.FromParentId = ds.Tables[1].Rows[0]["sFrmPrntId"].NulllToString();
        //                _result.FromParentName = ds.Tables[1].Rows[0]["FromParentName"].NulllToString();
        //                _result.ToParentId = ds.Tables[1].Rows[0]["sToPrntId"].NulllToString();
        //                _result.ToParentName = ds.Tables[1].Rows[0]["ToParentName"].NulllToString();
        //                _result.ChangeLevel = ds.Tables[1].Rows[0]["ChangeLevel"].NulllToString();
        //                _result.ToParentPartyType = ds.Tables[1].Rows[0]["ToParentType"].ToString();

        //            }
        //            if (ds.Tables[2].Rows.Count > 0)
        //            {
        //                _result.clientList = new List<ClientSwitchRequestData>();
        //                foreach (DataRow dr  in ds.Tables[2].Rows)
        //                {
        //                    _result.clientList.Add(new ClientSwitchRequestData
        //                    {
        //                        PartyName = dr["PartyName"].NulllToString(),
        //                        MainWalletBalance = dr["MainWalletBalance"].NulllToDouble(),
        //                        MobileNo = dr["MobileNumber"].NulllToString(),
        //                    });
        //                }     
        //            }

        //            if (ds.Tables[3].Rows.Count > 0)
        //            {
        //                _result.NewParentTypeList = new List<ListData>();
        //                foreach (DataRow dr in ds.Tables[3].Rows)
        //                {
        //                    _result.NewParentTypeList.Add(new ListData
        //                    {
        //                        ListID = dr["ListID"].NulllToString(),
        //                        ListName = dr["ListName"].NulllToString(),                                
        //                    });
        //                }
        //            }                    
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    return _result;
        //}

        public SelectedList SelectList(ListRequest ObjReq)
        {
            SelectedList cliData = new SelectedList();
            try
            {
                List<ListData> list = new List<ListData>();
                
                SqlParameter[] param = new SqlParameter[5];
                param[0] = new SqlParameter("@Type", ObjReq.Type);
                param[1] = new SqlParameter("@PartyId", ObjReq.LoginID);
                param[2] = new SqlParameter("@LoginId", ObjReq.LoginID);
                param[3] = new SqlParameter("@ParentId", ObjReq.ParentID);
                param[4] = new SqlParameter("@ToParentType", ObjReq.CangeRequestType);
                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_OPERATION_GetDetailsVendorWiseWhileParentChangeRequest_View]", param);
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    cliData.ResponseCode = "1";
                    cliData.Messsage = "Success";
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        list.Add(new ListData()
                        {
                            ListID = dr["ListID"].NulllToString()
                            ,
                            ListName = dr["ListName"].NulllToString()
                        });
                    }
                    cliData.Data = list;
                }
                else
                {
                    cliData.ResponseCode = "0";
                    cliData.Messsage = "No Data Found-Un!";
                    cliData.Data = null;
                }
            }
            catch (Exception ex)
            {
                cliData.ResponseCode = "5";
                cliData.Messsage = "No Data Found-Un!";
                cliData.Data = null;
                //ExceptionLog.SendExcepToDB(ex, "NA", "SwitchVendorDA:SelectList", ex.Message.ToString());
                return cliData;
            }
            return cliData;
        }

        //public ErrorBO SwitchParent(SwitchVendor BOobj)
        //{
        //    try
        //    {

        //        SqlParameter[] param = new SqlParameter[5];
        //        param[0] = new SqlParameter("@Type", BOobj.SwitchType);
        //        //param[1] = new SqlParameter("@SubType", BOobj.SwitchType);
        //        param[1] = new SqlParameter("@PartyId", BOobj.PartyId);
        //        param[2] = new SqlParameter("@SwitchVendorId", BOobj.SwitchVendorId);
        //        param[3] = new SqlParameter("@ToParentID", BOobj.ToParentID);
        //        param[4] = new SqlParameter("@FromParentID", BOobj.FromParentID);

        //        DataTable DT = BaseFunction.FillDataTable("[dbo].[ChangeClientParentSettlement]", param);
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
        //        //ExceptionLog.SendExcepToDB(ex, "NA", "SwitchVendorDA:SwitchParent", ex.Message.ToString());
        //        _Access.ResponseCode = "5";
        //        _Access.Messsage = "Details Not Found-Ex!Please Contact Support.";
        //        return _Access;
        //    }
        //}

        public List<AddCourseBO> FacilityDetails(string GUID)
        {
            List<AddCourseBO> objlist = new List<AddCourseBO>();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@Type", "Facility");
                param[1] = new SqlParameter("@Guid", GUID);
                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_Facility_List]", param);
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        objlist = new List<AddCourseBO>();
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            AddCourseBO objdoc = new AddCourseBO();
                            objdoc.iPk_AddCourseId = Convert.ToInt32(ds.Tables[0].Rows[i]["iPk_ColgFcltyId"]);
                            //objdoc.trustinfoid = ds.tables[0].rows[i]["trustname"].nullltostring();
                            //objdoc.icollegeid = ds.tables[0].rows[i]["collagename"].nullltostring();
                            //objdoc.tagdegrees = ds.tables[0].rows[i]["deegree"].nullltostring();
                            objdoc.File = ds.Tables[0].Rows[i]["File"].NulllToString();
                            objdoc.DocumentContent = ds.Tables[0].Rows[i]["DocumentContent"].NulllToString();
                            objdoc.DocumentExtension = ds.Tables[0].Rows[i]["DocumentExtension"].NulllToString();
                            objdoc.TagCourse = ds.Tables[0].Rows[i]["Courses"].NulllToString();
                            objdoc.Facility = ds.Tables[0].Rows[i]["Facility"].NulllToString();
                            objlist.Add(objdoc);
                        }
                    }

                }
                else
                {
                    objlist = null;
                }
            }
            catch (Exception e)
            {
                objlist = null;
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : TargetDL / Function : GetTarget");
            }
            return objlist;
        }

        public ResponseData GetFacilitesList()
        {
            try
            {

                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_Master_Facilites_List]");
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    objResponseData.ResponseCode = "000";
                    objResponseData.Message = "Facilites  List";
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

        public List<AddCourseBO> GetIdDetails(string GUID)
        {
            List<AddCourseBO> objlist = new List<AddCourseBO>();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@Type", "GetListGuid");
                param[1] = new SqlParameter("@Guid", GUID);
                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_Facility_List]", param);
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        objlist = new List<AddCourseBO>();
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            AddCourseBO objdoc = new AddCourseBO();

                            objdoc.TrustInfoId = ds.Tables[0].Rows[i]["iFKTst_ID"].NulllToString();
                            objdoc.iCollegeId = ds.Tables[0].Rows[i]["iFKCLG_ID"].NulllToString();
                            objdoc.iFK_DeptId = ds.Tables[0].Rows[i]["iFKDEPT_ID"].NulllToInt();
                            objlist.Add(objdoc);
                        }
                    }

                }
                else
                {
                    objlist = null;
                }
            }
            catch (Exception e)
            {
                objlist = null;
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : TargetDL / Function : GetTarget");
            }
            return objlist;
        }

        //public ResponseData RemoveData(int id)
        //{
        //    ResponseData objlist = new ResponseData();
        //    try
        //    {
        //        SqlParameter[] param = new SqlParameter[1];
        //        param[0] = new SqlParameter("@Id", id);

        //        DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_MASTER_FacilityCourse_RemoveData]", param);
        //        if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
        //        {
        //            objlist.statusCode = Convert.ToInt32(ds.Tables[0].Rows[0]["StatusCode"]);
        //            objlist.Message = ds.Tables[0].Rows[0]["Message"].ToString();

        //        }
        //        else
        //        {
        //            objlist.statusCode = 0;
        //            objlist.Message = "Failed";
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        objlist = null;
        //        ExceptionLogDL.SendExcepToDB(e, 0, "Class : TargetDL / Function : GetTarget");
        //    }
        //    return objlist;
        //}
    }
}
