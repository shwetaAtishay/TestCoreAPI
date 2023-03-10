using BO;
using BO.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Text;

namespace DL
{
   public class RateDL
    {
        #region Rate Details
        ResponseData objResponseData = new ResponseData();
        string connectionString = DBCS.GetConnectionString();
        public List<RateMaster> GetRateMasterDetail(string ID = "")
        {
            List<RateMaster> objListRateMaster = new List<RateMaster>();
            try
            {
                string queryString = "[dbo].[USP_GetRateDetails]";
                using (SqlConnection connect = new SqlConnection())
                {
                    SqlCommand cmd = new SqlCommand(queryString, connect);
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (ID != "")
                    {
                        cmd.Parameters.AddWithValue("@ParentId", ID);
                    }
                    connect.ConnectionString = connectionString;
                    cmd.Connection = connect;
                    if (connect.State != ConnectionState.Open)
                    {
                        connect.Open();
                    }
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                    {
                        objListRateMaster = new List<RateMaster>();

                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            RateMaster objRateMaster = new RateMaster();
                            objRateMaster.RateMasterId = ds.Tables[0].Rows[i]["RateId"].NulllToInt();
                            objRateMaster.DepartmentName = ds.Tables[0].Rows[i]["DepartmentName"].ToString();
                            objRateMaster.ServiceName = ds.Tables[0].Rows[i]["ServiceName"].ToString();
                            objRateMaster.ChildServiceName = ds.Tables[0].Rows[i]["ChildServiceName"].ToString();
                            objRateMaster.DepartmentCharge = ds.Tables[0].Rows[i]["DepartmentCharge"].NulllToInt();
                            objRateMaster.EmitraCharge = ds.Tables[0].Rows[i]["EmitraCharge"].NulllToInt();
                            objRateMaster.PrintingCharge = ds.Tables[0].Rows[i]["PrintingCharge"].NulllToInt();
                            objRateMaster.HomeCharge = ds.Tables[0].Rows[i]["HomeCharge"].NulllToInt();
                            objRateMaster.IsActive = ds.Tables[0].Rows[i]["IsActive"].NulllToInt();
                            objRateMaster.MstCategoryId = ds.Tables[0].Rows[i]["MstCategoryId"].NulllToInt();
                            objRateMaster.SubMstCategoryId = ds.Tables[0].Rows[i]["SubMstCategoryId"].NulllToInt();
                            objRateMaster.ChildCateId = ds.Tables[0].Rows[i]["ChildCateId"].NulllToInt();
                            objRateMaster.CollectionTime = ds.Tables[0].Rows[i]["CollectionTime"].ToString();
                            objRateMaster.ID = ds.Tables[0].Rows[i]["District"].ToString();
                            objListRateMaster.Add(objRateMaster);

                        }

                    }
                    else
                    {
                        objListRateMaster = null;
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionLogDL.SendExcepToDB(e, ID.NulllToLong(), "Class : UserDL / Function : GetUserMasterDetail");
                objListRateMaster = null;
            }
            return objListRateMaster;
        }
        public List<SlotMaster> GetSlotMasterDetail(string ID, int Type)
        {
            List<SlotMaster> objListSlotMaster = new List<SlotMaster>();
            try
            {
                string queryString = "[dbo].[EditSlotMaster]";
                using (SqlConnection connect = new SqlConnection())
                {
                    SqlCommand cmd = new SqlCommand(queryString, connect);
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (Type == 0)
                    {
                        cmd.Parameters.AddWithValue("@SlotMasterId", ID);
                    }

                    //if (!string.IsNullOrEmpty(ID))
                    //{
                    //    cmd.Parameters.AddWithValue("@SlotMasterId", ID);
                    //}
                    connect.ConnectionString = connectionString;
                    cmd.Connection = connect;
                    if (connect.State != ConnectionState.Open)
                    {
                        connect.Open();
                    }
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                    {
                        objListSlotMaster = new List<SlotMaster>();

                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            SlotMaster objRateMaster = new SlotMaster();
                            objRateMaster.SlotMasterId = ds.Tables[0].Rows[i]["SlotMasterId"].NulllToString();
                            objRateMaster.DistrictId = ds.Tables[0].Rows[i]["DistrictId"].NulllToInt();
                            objRateMaster.BlockId = ds.Tables[0].Rows[i]["BlockId"].NulllToInt();
                            objRateMaster.AreaId = ds.Tables[0].Rows[i]["AreaId"].NulllToInt();
                            objRateMaster.DistrictName = ds.Tables[0].Rows[i]["DistrictName"].NulllToString();
                            objRateMaster.BlockName = ds.Tables[0].Rows[i]["BlockName"].NulllToString();
                            objRateMaster.AreaName = ds.Tables[0].Rows[i]["AreaName"].NulllToString();
                            objRateMaster.Fromdate = ((DateTime)ds.Tables[0].Rows[i]["FromDate"]).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture).NulllToString();
                            objRateMaster.Todate = ((DateTime)ds.Tables[0].Rows[i]["Todate"]).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture).NulllToString();
                            //objRateMaster.Fromdate = Convert.ToDateTime(ds.Tables[0].Rows[i]["FromDate"]);
                            //objRateMaster.Todate = Convert.ToDateTime(ds.Tables[0].Rows[i]["ToDate"]);
                            objRateMaster.ActivateSlot = ds.Tables[0].Rows[i]["ActivateSlot"].NulllToString();
                            objRateMaster.Freedata = ds.Tables[0].Rows[i]["FreezeData"].NulllToString();
                            objRateMaster.IsActive = ds.Tables[0].Rows[i]["IsActive"].NulllToInt();
                            objListSlotMaster.Add(objRateMaster);

                        }

                    }
                    else
                    {
                        objListSlotMaster = null;
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionLogDL.SendExcepToDB(e, ID.NulllToLong(), "Class : UserDL / Function : GetUserMasterDetail");
                objListSlotMaster = null;
            }
            return objListSlotMaster;
        }
        #endregion
        public List<RateSpecialCategory> GetSpecialCategoryWiseRate(RateSpecialCategory obj)
        {
            List<RateSpecialCategory> objListRateMaster = new List<RateSpecialCategory>();
            try
            {
                string queryString = "[dbo].[GetSpecialCategoryData]";
                using (SqlConnection connect = new SqlConnection())
                {
                    SqlCommand cmd = new SqlCommand(queryString, connect);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RateMasterId", obj.RateMasterId);
                    cmd.Parameters.AddWithValue("@SpecialMasterId", obj.SpecialMasterid);
                    connect.ConnectionString = connectionString;
                    cmd.Connection = connect;
                    if (connect.State != ConnectionState.Open)
                    {
                        connect.Open();
                    }
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                    {
                        objListRateMaster = new List<RateSpecialCategory>();

                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            RateSpecialCategory objRateMaster = new RateSpecialCategory();

                            objRateMaster.DepartmentCharge = ds.Tables[0].Rows[i]["DepartmentCharge"].NulllToInt();
                            objRateMaster.EmitraCharge = ds.Tables[0].Rows[i]["EmitraCharge"].NulllToInt();

                            objRateMaster.IsActive = ds.Tables[0].Rows[i]["IsActive"].NulllToInt();

                            objListRateMaster.Add(objRateMaster);

                        }

                    }
                    else
                    {
                        objListRateMaster = null;
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionLogDL.SendExcepToDB(e, obj.SpecialMasterid.NulllToLong(), "Class : UserDL / Function : GetSpecialCategoryWiseRate");
                objListRateMaster = null;
            }
            return objListRateMaster;
        }
        //Get Special Category DropDown
        public List<RateSpecialCategory> GetSpecialCategoryWise(RateSpecialCategory obj)
        {
            List<RateSpecialCategory> objListRateMaster = new List<RateSpecialCategory>();
            try
            {
                string queryString = "[dbo].[Get_SpecialCategoryRate]";
                using (SqlConnection connect = new SqlConnection())
                {
                    SqlCommand cmd = new SqlCommand(queryString, connect);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RATEID", obj.RateMasterId);
                    //cmd.Parameters.AddWithValue("@SpecialMasterId", obj.SpecialMasterid);
                    connect.ConnectionString = connectionString;
                    cmd.Connection = connect;
                    if (connect.State != ConnectionState.Open)
                    {
                        connect.Open();
                    }
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                    {
                        objListRateMaster = new List<RateSpecialCategory>();

                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            RateSpecialCategory objRateMaster = new RateSpecialCategory();
                            objRateMaster.RateMasterId = ds.Tables[0].Rows[i]["RateMasterId"].NulllToInt();
                            objRateMaster.SpecialCategoryid = ds.Tables[0].Rows[i]["SpecialCategoryid"].NulllToInt();
                            objRateMaster.DepartmentCharge = ds.Tables[0].Rows[i]["DepartmentCharge"].NulllToInt();
                            objRateMaster.EmitraCharge = ds.Tables[0].Rows[i]["EmitraCharge"].NulllToInt();
                            objRateMaster.IsActive = ds.Tables[0].Rows[i]["IsActive"].NulllToInt();
                            objListRateMaster.Add(objRateMaster);

                        }

                    }
                    else
                    {
                        objListRateMaster = null;
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionLogDL.SendExcepToDB(e, obj.SpecialMasterid.NulllToLong(), "Class : UserDL / Function : GetSpecialCategoryWiseRate");
                objListRateMaster = null;
            }
            return objListRateMaster;
        }
        public ResponseData InsertUpdateSpecialCategory(RateSpecialCategory obj)
        {
            using (DataTable DT = new DataTable())
            {
                using (SqlConnection connect = new SqlConnection())
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "[dbo].[UpdateSpecialCategory]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@RateMasterId", obj.RateMasterId);
                        cmd.Parameters.AddWithValue("@SpecialMasterid", obj.SpecialMasterid);
                        cmd.Parameters.AddWithValue("@DepartmentCharge", obj.DepartmentCharge);
                        cmd.Parameters.AddWithValue("@EmitraCharge", obj.EmitraCharge);
                        cmd.Parameters.AddWithValue("@IsActive", obj.IsActive);

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
                            ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : InsertUpdateRate");
                        }
                    }
                }
                return objResponseData;
            }
        }
        public ResponseData InsertUpdateSlot(SlotMaster obj)
        {
            using (DataTable DT = new DataTable())
            {
                using (SqlConnection connect = new SqlConnection())
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "[dbo].[InsertUpdateSlot]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@SlotMasterId", obj.SlotMasterId);
                        cmd.Parameters.AddWithValue("@Fromdate", obj.Fromdate);
                        cmd.Parameters.AddWithValue("@Todate", obj.Todate);
                        cmd.Parameters.AddWithValue("@DistrictId", obj.DistrictId);
                        cmd.Parameters.AddWithValue("@BlockId", obj.BlockId);
                        cmd.Parameters.AddWithValue("@AreaId", obj.AreaId);
                        cmd.Parameters.AddWithValue("@CreatedByID", obj.CreatedByID);
                        cmd.Parameters.AddWithValue("@CreatedByName", obj.CreatedByName);
                        cmd.Parameters.AddWithValue("@ActivateSlot", obj.ActivateSlot);
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
                            ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : InsertUpdateSlot");
                        }
                    }
                }
                return objResponseData;
            }
        }
        public ResponseData InsertUpdateRate(RateMaster obj)
        {
            using (DataTable DT = new DataTable())
            {
                using (SqlConnection connect = new SqlConnection())
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "[dbo].[USP_InsertAndUpdateRatelist]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@RateId", obj.RateId);
                        cmd.Parameters.AddWithValue("@MstCategoryId", obj.MstCategoryId);
                        cmd.Parameters.AddWithValue("@SubMstCategoryId", obj.SubMstCategoryId);
                        cmd.Parameters.AddWithValue("@ChildCateId", obj.ChildCateId);
                        cmd.Parameters.AddWithValue("@DepartmentCharge", obj.DepartmentCharge);
                        cmd.Parameters.AddWithValue("@EmitraCharge", obj.EmitraCharge);
                        cmd.Parameters.AddWithValue("@PrintingCharge", obj.PrintingCharge);
                        cmd.Parameters.AddWithValue("@HomeCharge", obj.HomeCharge);
                        cmd.Parameters.AddWithValue("@CreatedByName", obj.CreatedByName);
                        cmd.Parameters.AddWithValue("@CreatedByID", obj.CreatedByID);
                        cmd.Parameters.AddWithValue("@CreatedIP", obj.CreatedIP);
                        cmd.Parameters.AddWithValue("@CollectionTime", obj.CollectionTime);
                        cmd.Parameters.AddWithValue("@ID", obj.ID);
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
                            ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : InsertUpdateRate");
                        }
                    }
                }
                return objResponseData;
            }
        }
        public ResponseData ChangeStatus(RateMaster obj)
        {
            using (DataTable DT = new DataTable())
            {
                using (SqlConnection connect = new SqlConnection())
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "[dbo].[USP_ChangeStatus]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@RateId", obj.RateId);
                        cmd.Parameters.AddWithValue("@TypeId", obj.IsActive);
                        cmd.Parameters.AddWithValue("@ModifyByID", obj.ModifyByID);
                        cmd.Parameters.AddWithValue("@ModifyByName", obj.ModifyByName);
                        cmd.Parameters.AddWithValue("@ModifyIP", obj.ModifyIP);
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
                            ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : ChangeStatus");
                        }
                    }
                }
                return objResponseData;
            }
        }

        public ResponseData SlotChangeStatus(SlotMaster obj)
        {
            using (DataTable DT = new DataTable())
            {
                using (SqlConnection connect = new SqlConnection())
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "[dbo].[USP_SlotChangeStatus]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id", obj.SlotMasterId);
                        cmd.Parameters.AddWithValue("@TypeId", obj.IsActive);

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
                            ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : ChangeStatus");
                        }
                    }
                }
                return objResponseData;
            }
        }
        public ResponseData InsertFreezeDate(FreezeSlot obj)
        {
            using (DataTable DT = new DataTable())
            {
                using (SqlConnection connect = new SqlConnection())
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "[dbo].[InsertSlotFreezeDate]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@SlotMasterId", obj.SlotMasterId);
                        cmd.Parameters.AddWithValue("@Remark", obj.Remark);
                        cmd.Parameters.AddWithValue("@CreateById", obj.CreateById);
                        cmd.Parameters.AddWithValue("@CreateByName", obj.CreatedByName);
                        cmd.Parameters.AddWithValue("@FreezeDate", obj.FreezeDate);
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
                            ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : InsertUpdateSlotEnquiryMaster");
                        }
                    }
                }
                return objResponseData;
            }
        }
        public ResponseData InsertUpdateSlotEnquiryMaster(SlotEnquiryMasterTemp obj)
        {
            using (DataTable DT = new DataTable())
            {
                using (SqlConnection connect = new SqlConnection())
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "[dbo].[InsertupdateSlotEnquiry]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@SlotMasterId", obj.SlotMasterId);
                        cmd.Parameters.AddWithValue("@ColourId", obj.ColourId);
                        cmd.Parameters.AddWithValue("@NoofEnquiry", obj.NoofEnquiry);
                        cmd.Parameters.AddWithValue("@Id", obj.Id);

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
                            ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : InsertUpdateSlotEnquiryMaster");
                        }
                    }
                }
                return objResponseData;
            }
        }

        public ResponseData DeleteSlotEnquiry(long Id)
        {
            using (DataTable DT = new DataTable())
            {
                using (SqlConnection connect = new SqlConnection())
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "[dbo].[DeleteSlotEnquiry]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id", Id);


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
                            ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : DeleteSlotEnquiry");
                        }
                    }
                }
                return objResponseData;
            }
        }
        public List<FreezeSlot> GetFreezeSlotDetail(string ID = "")
        {
            List<FreezeSlot> objListRateMaster = new List<FreezeSlot>();
            try
            {
                string queryString = "[dbo].[ShowFreezeDate]";
                using (SqlConnection connect = new SqlConnection())
                {
                    SqlCommand cmd = new SqlCommand(queryString, connect);
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (ID != "")
                    {
                        cmd.Parameters.AddWithValue("@SlotMasterId", ID);
                    }
                    connect.ConnectionString = connectionString;
                    cmd.Connection = connect;
                    if (connect.State != ConnectionState.Open)
                    {
                        connect.Open();
                    }
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                    {
                        objListRateMaster = new List<FreezeSlot>();

                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            FreezeSlot objRateMaster = new FreezeSlot();
                            objRateMaster.SlotFreezeDateId = ds.Tables[0].Rows[i]["SlotFreezeDateId"].NulllToLong();

                            objRateMaster.Remark = ds.Tables[0].Rows[i]["Remark"].ToString();

                            objRateMaster.FreezeDate = ds.Tables[0].Rows[i]["Freedate"].NulllToString();

                            objListRateMaster.Add(objRateMaster);

                        }

                    }
                    else
                    {
                        objListRateMaster = null;
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionLogDL.SendExcepToDB(e, ID.NulllToLong(), "Class : UserDL / Function : GetFreezeSlotDetail");
                objListRateMaster = null;
            }
            return objListRateMaster;

        }
        public List<SlotEnquiryMasterTemp> GetAllSlotColor(string ID = "")
        {
            List<SlotEnquiryMasterTemp> objListRateMaster = new List<SlotEnquiryMasterTemp>();
            try
            {
                string queryString = "[dbo].[ShowSlotEnquiryMaster]";
                using (SqlConnection connect = new SqlConnection())
                {
                    SqlCommand cmd = new SqlCommand(queryString, connect);
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (ID != "")
                    {
                        cmd.Parameters.AddWithValue("@SlotMasterId", ID);
                    }
                    connect.ConnectionString = connectionString;
                    cmd.Connection = connect;
                    if (connect.State != ConnectionState.Open)
                    {
                        connect.Open();
                    }
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                    {
                        objListRateMaster = new List<SlotEnquiryMasterTemp>();

                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            SlotEnquiryMasterTemp objRateMaster = new SlotEnquiryMasterTemp();
                            objRateMaster.Id = ds.Tables[0].Rows[i]["Id"].NulllToInt();
                            objRateMaster.NoofEnquiry = ds.Tables[0].Rows[i]["NoofEnquiry"].NulllToInt();
                            objRateMaster.SlotMasterId = ds.Tables[0].Rows[i]["SlotMasterId"].ToString();
                            objRateMaster.ColourId = ds.Tables[0].Rows[i]["ColorId"].NulllToLong();
                            objRateMaster.ColorName = ds.Tables[0].Rows[i]["Category"].NulllToString();

                            objListRateMaster.Add(objRateMaster);

                        }

                    }
                    else
                    {
                        objListRateMaster = null;
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionLogDL.SendExcepToDB(e, ID.NulllToLong(), "Class : UserDL / Function : GetAllSlotColor");
                objListRateMaster = null;
            }
            return objListRateMaster;
        }
        public ResponseData DeleteFreezeDate(long Id)
        {
            using (DataTable DT = new DataTable())
            {
                using (SqlConnection connect = new SqlConnection())
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "[dbo].[DeleteFreezeDate]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id", Id);

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
                            ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : DeleteFreezeDate");
                        }
                    }
                }
                return objResponseData;
            }
        }
    }
}
