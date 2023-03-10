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
   public class ServiceConfigDL
    {
        ResponseData objResponseData = new ResponseData();
        string connectionString = DBCS.GetConnectionString();

        public List<CustomEnum> GetCustomEnum()
        {
            //string query = @"
            //                select CustomEnumId,EnumNo,Name  from
            //                dbo.CustomEnum
            //                ";

            //DataTable table = new DataTable();
            //string sqlDataSource = _configuration.GetConnectionString("DBCS");
            //SqlDataReader myReader;
            //using (SqlConnection connect = new SqlConnection())
            //{
            //    connect.ConnectionString = connectionString;
            //    if (connect.State != ConnectionState.Open)
            //    {
            //        connect.Open();
            //    }
            //    using (SqlCommand myCommand = new SqlCommand(query, connect))
            //    {
            //        myReader = myCommand.ExecuteReader();
            //        table.Load(myReader);
            //        myReader.Close();
            //        connect.Close();
            //        foreach (DataRow row in table.Rows)
            //        {
            //            string name = row["CustomEnum"].ToString();
            //            string description = row["EnumNo"].ToString();
            //            string icoFileName = row["Name"].ToString();

            //        }
            //    }
            //}


            List<CustomEnum> objlist = new List<CustomEnum>();
            try
            {
                string queryString = "[dbo].[ShowCustomEnum]";
                using (SqlConnection connect = new SqlConnection())
                {
                    SqlCommand cmd = new SqlCommand(queryString, connect);
                    cmd.CommandType = CommandType.StoredProcedure;



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
                        objlist = new List<CustomEnum>();

                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            CustomEnum objdoc = new CustomEnum();
                            objdoc.CustomEnumId = ds.Tables[0].Rows[i]["CustomEnumId"].NulllToInt();
                            objdoc.EnumNo = ds.Tables[0].Rows[i]["EnumNo"].NulllToInt();
                            objdoc.Id = Convert.ToInt32(ds.Tables[0].Rows[i]["Id"]);
                            objdoc.Name = ds.Tables[0].Rows[i]["Name"].ToString();
                            objdoc.IsActive = ds.Tables[0].Rows[i]["Active"].NulllToInt();
                            objlist.Add(objdoc);

                        }

                    }
                    else
                    {
                        objlist = null;
                    }
                }

            }
            catch (Exception e)
            {
                objlist = null;
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetCustomEnum");
            }
            return objlist;
        }
        #region Get Document 
        public List<DepartmentTypeDocumentBO> GetDepartmentServiceList()
        {
            List<DepartmentTypeDocumentBO> objListService = new List<DepartmentTypeDocumentBO>();

            string queryString = "[dbo].[Get_ParentService_List]";
            using (SqlConnection connect = new SqlConnection())
            {
                SqlCommand cmd = new SqlCommand(queryString, connect);
                cmd.CommandType = CommandType.StoredProcedure;
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
                    Console.Write(ds);
                    objListService = new List<DepartmentTypeDocumentBO>();

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        DepartmentTypeDocumentBO objCountry = new DepartmentTypeDocumentBO();
                        objCountry.MstCategoryID = Convert.ToInt32(ds.Tables[0].Rows[i]["MstCategoryID"]);
                        objCountry.Category = ds.Tables[0].Rows[i]["Category"].NulllToString();
                        objListService.Add(objCountry);
                    }

                }
                else
                {
                    objListService = null;
                }
            }
            Console.Write(objListService);
            return objListService;

        }
        #endregion

        #region Get Document 
        public List<DepartmentTypeDocumentBO> GetDepartmentWiseServiceList(string districtId)
        {
            List<DepartmentTypeDocumentBO> objListService = new List<DepartmentTypeDocumentBO>();

            string queryString = "[dbo].[GetDistrictWiseDepartment]";
            using (SqlConnection connect = new SqlConnection())
            {
                SqlCommand cmd = new SqlCommand(queryString, connect);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("DistrictID", districtId);
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
                    Console.Write(ds);
                    objListService = new List<DepartmentTypeDocumentBO>();

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        DepartmentTypeDocumentBO objCountry = new DepartmentTypeDocumentBO();
                        objCountry.MstCategoryID = Convert.ToInt32(ds.Tables[0].Rows[i]["MstCategoryID"]);
                        objCountry.Category = ds.Tables[0].Rows[i]["Category"].NulllToString();
                        objListService.Add(objCountry);
                    }

                }
                else
                {
                    objListService = null;
                }
            }
            Console.Write(objListService);
            return objListService;

        }
        #endregion

        #region Get Service
        public List<DepartmentTypeDocumentBO> GetServiceList()
        {
            List<DepartmentTypeDocumentBO> objListService = new List<DepartmentTypeDocumentBO>();

            string queryString = "[dbo].[Get_SubService_List]";
            using (SqlConnection connect = new SqlConnection())
            {
                SqlCommand cmd = new SqlCommand(queryString, connect);
                cmd.CommandType = CommandType.StoredProcedure;
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
                    Console.Write(ds);
                    objListService = new List<DepartmentTypeDocumentBO>();

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        DepartmentTypeDocumentBO objCountry = new DepartmentTypeDocumentBO();
                        objCountry.MstCategoryID = Convert.ToInt32(ds.Tables[0].Rows[i]["MstCategoryID"]);
                        objCountry.Category = ds.Tables[0].Rows[i]["Category"].NulllToString();
                        objListService.Add(objCountry);
                    }

                }
                else
                {
                    objListService = null;
                }
            }
            Console.Write(objListService);
            return objListService;

        }
        #endregion

        public List<setting> GetSetting()
        {
            List<setting> objlist = new List<setting>();
            try
            {
                string queryString = "[dbo].[ShowSetting]";
                using (SqlConnection connect = new SqlConnection())
                {
                    SqlCommand cmd = new SqlCommand(queryString, connect);
                    cmd.CommandType = CommandType.StoredProcedure;



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
                        objlist = new List<setting>();

                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            setting objdoc = new setting();
                            objdoc.Id = Convert.ToInt32(ds.Tables[0].Rows[i]["SettingId"]);
                            objdoc.Name = ds.Tables[0].Rows[i]["Name"].ToString();
                            objdoc.IsActive = ds.Tables[0].Rows[i]["IsActive"].NulllToInt();
                            objlist.Add(objdoc);

                        }

                    }
                    else
                    {
                        objlist = null;
                    }
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
            using (DataTable DT = new DataTable())
            {
                using (SqlConnection connect = new SqlConnection())
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "[dbo].[UpdateCustomEnum]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id", Id);
                        cmd.Parameters.AddWithValue("@Text", Text);
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
                                    Master = Convert.ToInt32(DT.Rows[0]["StatusCode"]);


                                }
                            }

                        }
                        catch (Exception e)
                        {

                            ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : DeleteCustomSentence");
                        }
                    }
                }
                return Master;
            }
        }
        public int DeleteCustomSentence(int Id)
        {
            int Master = 0;
            using (DataTable DT = new DataTable())
            {
                using (SqlConnection connect = new SqlConnection())
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "[dbo].[InsertNewCustomEnumRow]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@EnumNo", Id);
                        cmd.Parameters.AddWithValue("@Type", 2);
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
                                    Master = Convert.ToInt32(DT.Rows[0]["StatusCode"]);


                                }
                            }

                        }
                        catch (Exception e)
                        {

                            ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : DeleteCustomSentence");
                        }
                    }
                }
                return Master;
            }
        }
        public int InsertNewCustomEnumRow(int Id)
        {
            int master = 0;
            try
            {

                string queryString = "[dbo].[InsertNewCustomEnumRow]";
                using (SqlConnection connect = new SqlConnection())
                {
                    SqlCommand cmd = new SqlCommand(queryString, connect);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EnumNo", Id);
                    cmd.Parameters.AddWithValue("@Type", 1);

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


                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {

                            master = ds.Tables[0].Rows[i]["CustomEnumId"].NulllToInt();


                        }

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

                string queryString = "[mst].[FillChargesType]";
                using (SqlConnection connect = new SqlConnection())
                {
                    SqlCommand cmd = new SqlCommand(queryString, connect);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", ServiceId);


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
                        objListdoc = new List<CustomList>();

                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            CustomList objdoc = new CustomList();
                            objdoc.Id = Convert.ToInt32(ds.Tables[0].Rows[i]["Id"]);
                            objdoc.text = ds.Tables[0].Rows[i]["text"].ToString();


                            objListdoc.Add(objdoc);

                        }

                    }
                    else
                    {
                        objListdoc = null;
                    }
                }
            }
            catch (Exception e)
            {
                objListdoc = null;
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetChargesType");
            }
            return objListdoc;
        }
        public List<ServiceTypeDocument> GetServiceByDepartmentId(int ID = 0, bool ActiveOnly = false, string SortBy = null, string SearchText = null)
        {
            List<ServiceTypeDocument> objListdoc = new List<ServiceTypeDocument>();
            try
            {
                string queryString = "[dbo].[USP_GetServiceByDepartmentId]";
                using (SqlConnection connect = new SqlConnection())
                {
                    SqlCommand cmd = new SqlCommand(queryString, connect);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", ID);

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
                        objListdoc = new List<ServiceTypeDocument>();

                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            ServiceTypeDocument objdoc = new ServiceTypeDocument();
                            objdoc.MstCategoryID = ds.Tables[0].Rows[i]["MstCategoryId"].NulllToInt();
                            objdoc.ServiceName = ds.Tables[0].Rows[i]["Category"].NulllToString();
                            objdoc.Type = ds.Tables[0].Rows[i]["Childlist"].NulllToInt();
                            objListdoc.Add(objdoc);
                        }
                    }
                    else
                    {
                        objListdoc = null;
                    }
                }
            }
            catch (Exception e)
            {
                objListdoc = null;
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetServiceByDepartmentId");
            }
            return objListdoc;
        }

        public List<ServiceTypeDocument> GetChildSubCategory(int ID = 0, bool ActiveOnly = false, string SortBy = null, string SearchText = null)
        {
            List<ServiceTypeDocument> objListdoc = new List<ServiceTypeDocument>();
            try
            {

                string queryString = "[sdi].[USP_ServiceChildMapping]";
                using (SqlConnection connect = new SqlConnection())
                {
                    SqlCommand cmd = new SqlCommand(queryString, connect);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", ID);

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
                        objListdoc = new List<ServiceTypeDocument>();

                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            ServiceTypeDocument objdoc = new ServiceTypeDocument();
                            objdoc.MstCategoryID = ds.Tables[0].Rows[i]["Childcate"].NulllToInt();
                            objdoc.ServiceName = ds.Tables[0].Rows[i]["Name"].NulllToString();
                            //objdoc.DocumentName_Hindi = ds.Tables[0].Rows[i]["DocumentName_Hindi"].NulllToString();
                            //objdoc.Fromdays = ds.Tables[0].Rows[i]["Fromdays"].NulllToInt();
                            //objdoc.Todays = ds.Tables[0].Rows[i]["Todays"].NulllToInt();
                            //objdoc.MstServiceTypeID = ds.Tables[0].Rows[i]["MstServiceTypeID"].NulllToInt();
                            //objdoc.MstCategoryID = ds.Tables[0].Rows[i]["ID"].NulllToInt();
                            //objdoc.Required = ds.Tables[0].Rows[i]["Required"].NulllToString();
                            objdoc.Type = ds.Tables[0].Rows[i]["Isactive"].NulllToInt();
                            objListdoc.Add(objdoc);

                        }

                    }
                    else
                    {
                        objListdoc = null;
                    }
                }
            }
            catch (Exception e)
            {
                objListdoc = null;
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetServiceByDepartmentId");
            }
            return objListdoc;
        }

        public List<CustomList> GetCustomList(int Enumno)
        {

            List<CustomList> objListdoc = new List<CustomList>();
            try
            {

                string queryString = "[dbo].[Usp_GetEnumDetail]";
                using (SqlConnection connect = new SqlConnection())
                {
                    SqlCommand cmd = new SqlCommand(queryString, connect);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EnumNo", Enumno);


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
                        objListdoc = new List<CustomList>();

                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            CustomList objdoc = new CustomList();
                            objdoc.Id = Convert.ToInt32(ds.Tables[0].Rows[i]["Id"]);
                            objdoc.text = ds.Tables[0].Rows[i]["CustomName"].ToString();


                            objListdoc.Add(objdoc);

                        }

                    }
                    else
                    {
                        objListdoc = null;
                    }
                }
            }
            catch (Exception e)
            {
                objListdoc = null;
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetCustomList");
            }
            return objListdoc;
        }
        public List<CategoryMaster> GetServicesDetail(int Id)
        {
            List<CategoryMaster> objCategormaster = new List<CategoryMaster>();
            try
            {

                string queryString = "[dbo].[ServiceDetail]";
                using (SqlConnection connect = new SqlConnection())
                {
                    SqlCommand cmd = new SqlCommand(queryString, connect);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", Id);


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
                        objCategormaster = new List<CategoryMaster>();

                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            CategoryMaster objdoc = new CategoryMaster();
                            objdoc.CategoryId = ds.Tables[0].Rows[i]["CategoryId"].NulllToInt();
                            //objdoc.CategoryId = Convert.ToInt32(ds.Tables[0].Rows[i]["CategoryId"]);
                            objdoc.Name = ds.Tables[0].Rows[i]["Name"].ToString();
                            objdoc.VarificationList = ds.Tables[0].Rows[i]["varificationList"].ToString();
                            objdoc.DocumentList = ds.Tables[0].Rows[i]["DocumentList"].ToString();
                            objdoc.HardwareList = ds.Tables[0].Rows[i]["HardwareList"].ToString();
                            objdoc.ClassName = ds.Tables[0].Rows[i]["ClassName"].NulllToString();
                            objdoc.IsActive = ds.Tables[0].Rows[i]["IsActive"].NulllToInt();
                            objCategormaster.Add(objdoc);

                        }

                    }
                    else
                    {
                        objCategormaster = null;
                    }
                }
            }
            catch (Exception e)
            {
                objCategormaster = null;
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetServicesDetail");
            }
            return objCategormaster;
        }
        //public ResponseData InserGstApplicable(GSTApplicable obj)
        //{
        //    using (DataTable DT = new DataTable())
        //    {
        //        using (SqlConnection connect = new SqlConnection())
        //        {
        //            using (SqlCommand cmd = new SqlCommand())
        //            {
        //                cmd.CommandText = "[mst].[InsertGSTApplicable]";
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                cmd.Parameters.AddWithValue("@ServiceHardwareId", obj.ServiceHardwareId);
        //                cmd.Parameters.AddWithValue("@Type", obj.TypeId);
        //                cmd.Parameters.AddWithValue("@ApplicableType", obj.ApplicableChargesType);
        //                cmd.Parameters.AddWithValue("@GST", obj.GST);
        //                cmd.Parameters.AddWithValue("@Fromdate", obj.FromDate);
        //                cmd.Parameters.AddWithValue("@Todate", obj.ToDate);
        //                cmd.Parameters.AddWithValue("@TaxType", obj.TaxType);
        //                cmd.Parameters.AddWithValue("@UnitId", obj.UnitId);
        //                //cmd.Parameters.AddWithValue("@DepartmentCharge", obj.DepartmentCharge);
        //                //cmd.Parameters.AddWithValue("@EmitraCharge", obj.EmitraCharge);
        //                //cmd.Parameters.AddWithValue("@PrintingCharge", obj.PrintingCharge);
        //                //cmd.Parameters.AddWithValue("@HomeCharge", obj.HomeCharge);
        //                //cmd.Parameters.AddWithValue("@CreatedByName", obj.CreatedByName);
        //                //cmd.Parameters.AddWithValue("@CreatedByID", obj.CreatedByID);
        //                //cmd.Parameters.AddWithValue("@CreatedIP", obj.CreatedIP);
        //                //cmd.Parameters.AddWithValue("@CollectionTime", obj.CollectionTime);

        //                try
        //                {
        //                    connect.ConnectionString = connectionString;
        //                    cmd.Connection = connect;
        //                    if (cmd.Connection.State != ConnectionState.Open)
        //                    {
        //                        cmd.Connection.Open();
        //                    }
        //                    SqlDataReader dr = cmd.ExecuteReader();
        //                    DT.Load(dr);
        //                    cmd.Connection.Close();
        //                    if (DT != null)
        //                    {
        //                        if (DT.Rows.Count > 0)
        //                        {
        //                            objResponseData.statusCode = Convert.ToInt32(DT.Rows[0]["StatusCode"]);
        //                            objResponseData.Message = DT.Rows[0]["Message"].ToString();

        //                        }
        //                    }
        //                    else
        //                    {
        //                        objResponseData.statusCode = 0;
        //                        objResponseData.Message = "Failed";
        //                    }
        //                }
        //                catch (Exception e)
        //                {
        //                    objResponseData.statusCode = 0;
        //                    objResponseData.Message = "Failed";
        //                    ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : InsertServices");
        //                }
        //            }
        //        }
        //        return objResponseData;
        //    }
        //}
        public ResponseData InsertServices(CategoryMaster obj)
        {
            using (DataTable DT = new DataTable())
            {
                using (SqlConnection connect = new SqlConnection())
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "[dbo].[Usp_ServicesOperation]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@categoryMaster", obj.CategoryId);
                        cmd.Parameters.AddWithValue("@Name", obj.Name);
                        cmd.Parameters.AddWithValue("@DocumentList", obj.DocumentList);
                        cmd.Parameters.AddWithValue("@VarificationList", obj.VarificationList);
                        cmd.Parameters.AddWithValue("@HardwareList", obj.HardwareList);
                        cmd.Parameters.AddWithValue("@ClassName", obj.ClassName);
                        //cmd.Parameters.AddWithValue("@DepartmentCharge", obj.DepartmentCharge);
                        //cmd.Parameters.AddWithValue("@EmitraCharge", obj.EmitraCharge);
                        //cmd.Parameters.AddWithValue("@PrintingCharge", obj.PrintingCharge);
                        //cmd.Parameters.AddWithValue("@HomeCharge", obj.HomeCharge);
                        //cmd.Parameters.AddWithValue("@CreatedByName", obj.CreatedByName);
                        //cmd.Parameters.AddWithValue("@CreatedByID", obj.CreatedByID);
                        //cmd.Parameters.AddWithValue("@CreatedIP", obj.CreatedIP);
                        //cmd.Parameters.AddWithValue("@CollectionTime", obj.CollectionTime);

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
                            ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : InsertServices");
                        }
                    }
                }
                return objResponseData;
            }
        }
        public ResponseData ChangeStatus(Activeclass obj)
        {
            using (DataTable DT = new DataTable())
            {
                using (SqlConnection connect = new SqlConnection())
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "[dbo].[ChangeStatus]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@tablename", obj.Tablename);
                        cmd.Parameters.AddWithValue("@Id", obj.Id);
                        cmd.Parameters.AddWithValue("@type", obj.status);
                        //cmd.Parameters.AddWithValue("@VarificationList", obj.VarificationList);
                        //cmd.Parameters.AddWithValue("@HardwareList", obj.HardwareList);
                        //cmd.Parameters.AddWithValue("@DepartmentCharge", obj.DepartmentCharge);
                        //cmd.Parameters.AddWithValue("@EmitraCharge", obj.EmitraCharge);
                        //cmd.Parameters.AddWithValue("@PrintingCharge", obj.PrintingCharge);
                        //cmd.Parameters.AddWithValue("@HomeCharge", obj.HomeCharge);
                        //cmd.Parameters.AddWithValue("@CreatedByName", obj.CreatedByName);
                        //cmd.Parameters.AddWithValue("@CreatedByID", obj.CreatedByID);
                        //cmd.Parameters.AddWithValue("@CreatedIP", obj.CreatedIP);
                        //cmd.Parameters.AddWithValue("@CollectionTime", obj.CollectionTime);

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
                            ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : InsertServices");
                        }
                    }
                }
                return objResponseData;
            }
        }

        public ResponseData InsertRateMaster(RateMaster obj)
        {
            using (DataTable DT = new DataTable())
            {
                using (SqlConnection connect = new SqlConnection())
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "[dbo].[InsertRateMaster]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Amount", obj.Amount);
                        cmd.Parameters.AddWithValue("@HardWareServicesId", obj.HardWareServicesId);
                        cmd.Parameters.AddWithValue("@ChargeType", obj.ChargeType);
                        cmd.Parameters.AddWithValue("@UnitType", obj.UnitType);
                        cmd.Parameters.AddWithValue("@PaymentType", obj.PaymentType);
                        cmd.Parameters.AddWithValue("@TypeId", obj.TypeId);


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
                            ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : InsertRateMaster");
                        }
                    }
                }
                return objResponseData;
            }
        }
        public List<GlobalClass> GetGeographicalData(int Id, int districtId, int Type)
        {
            List<GlobalClass> objGlobal = new List<GlobalClass>();
            try
            {

                string queryString = "[mst].[GetDistrictBlock]";
                using (SqlConnection connect = new SqlConnection())
                {
                    SqlCommand cmd = new SqlCommand(queryString, connect);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DistrictId", Id);
                    cmd.Parameters.AddWithValue("@BlockId ", districtId);
                    cmd.Parameters.AddWithValue("@type", Type);


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
                        objGlobal = new List<GlobalClass>();

                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            GlobalClass objdoc = new GlobalClass();
                            objdoc.Id = ds.Tables[0].Rows[i]["Id"].NulllToInt();
                            objdoc.Text = ds.Tables[0].Rows[i]["Name"].ToString();
                            objdoc.Pincode = ds.Tables[0].Rows[i]["PinCode"].ToString();


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
        public List<ShowRateMaster> GetRateMasterDetail()
        {
            List<ShowRateMaster> objCategormaster = new List<ShowRateMaster>();
            try
            {
                string queryString = "[dbo].[GetRateMasterDetail]";
                using (SqlConnection connect = new SqlConnection())
                {
                    SqlCommand cmd = new SqlCommand(queryString, connect);
                    cmd.CommandType = CommandType.StoredProcedure;



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
                        objCategormaster = new List<ShowRateMaster>();

                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            ShowRateMaster objdoc = new ShowRateMaster();
                            objdoc.RateMasterId = Convert.ToInt32(ds.Tables[0].Rows[i]["RateMasterId"]);
                            objdoc.Name = ds.Tables[0].Rows[i]["Name"].ToString();
                            objdoc.ServiceName = ds.Tables[0].Rows[i]["ServiceName"].ToString();
                            objdoc.ChargeType = ds.Tables[0].Rows[i]["ChargeType"].ToString();
                            objdoc.UnitType = ds.Tables[0].Rows[i]["UnitType"].ToString();
                            objdoc.PaymentType = ds.Tables[0].Rows[i]["PaymentType"].ToString();
                            objdoc.Amount = ds.Tables[0].Rows[i]["Amount"].ToString();
                            objdoc.Isactive = Convert.ToInt32(ds.Tables[0].Rows[i]["Isactive"]);

                            objCategormaster.Add(objdoc);

                        }

                    }
                    else
                    {
                        objCategormaster = null;
                    }
                }
            }
            catch (Exception e)
            {
                objCategormaster = null;
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetServicesDetail");
            }
            return objCategormaster;
        }
        //public List<GSTApplicable> GetApplicableGstDetails()
        //{
        //    List<GSTApplicable> objCategormaster = new List<GSTApplicable>();
        //    try
        //    {

        //        string queryString = "[mst].[ShowGstDetails]";
        //        using (SqlConnection connect = new SqlConnection())
        //        {
        //            SqlCommand cmd = new SqlCommand(queryString, connect);
        //            cmd.CommandType = CommandType.StoredProcedure;



        //            connect.ConnectionString = connectionString;
        //            cmd.Connection = connect;
        //            if (connect.State != ConnectionState.Open)
        //            {
        //                connect.Open();
        //            }
        //            SqlDataAdapter da = new SqlDataAdapter(cmd);
        //            DataSet ds = new DataSet();
        //            da.Fill(ds);
        //            if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
        //            {
        //                objCategormaster = new List<GSTApplicable>();

        //                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //                {
        //                    GSTApplicable objdoc = new GSTApplicable();
        //                    objdoc.Id = ds.Tables[0].Rows[i]["Id"].NulllToLong();
        //                    objdoc.TypeName = ds.Tables[0].Rows[i]["TypeName"].ToString();
        //                    objdoc.ServiceName = ds.Tables[0].Rows[i]["ServiceName"].ToString();
        //                    objdoc.GST = ds.Tables[0].Rows[i]["GST"].NulllToDecimal();
        //                    //objdoc.TotalAmount = ds.Tables[0].Rows[i]["TotalAmount"].NulllToDecimal();
        //                    //objdoc.Tax = ds.Tables[0].Rows[i]["Tax"].NulllToDecimal();
        //                    //objdoc.GrandTotal = ds.Tables[0].Rows[i]["GrandTotal"].NulllToDecimal();
        //                    objdoc.IsActive = ds.Tables[0].Rows[i]["IsActive"].NulllToInt();
        //                    objdoc.FromDate = ((DateTime)ds.Tables[0].Rows[i]["FromDate"]).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture).NulllToString();
        //                    objdoc.ToDate = ((DateTime)ds.Tables[0].Rows[i]["ToDate"]).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture).NulllToString();
        //                    //objdoc.GrandTotal = ds.Tables[0].Rows[i]["GrandTotal"].NulllToDecimal();
        //                    objdoc.IsActive = ds.Tables[0].Rows[i]["IsActive"].NulllToInt();
        //                    objdoc.ApplicableChargesType = ds.Tables[0].Rows[i]["ApplicableChargesType"].ToString();
        //                    //objdoc.ChargesType= ds.Tables[0].Rows[i]["ChargesType"].ToString();
        //                    objdoc.TaxTypeName = ds.Tables[0].Rows[i]["TaxName"].ToString();
        //                    objdoc.UnitName = ds.Tables[0].Rows[i]["UnitName"].ToString();
        //                    objCategormaster.Add(objdoc);

        //                }

        //            }
        //            else
        //            {
        //                objCategormaster = null;
        //            }
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        objCategormaster = null;
        //        ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetApplicableGstDetails");
        //    }
        //    return objCategormaster;
        //}

        //public List<PandingPaymentList> PaymentPendingList(string StringPara)
        //{
        //    //List<PandingPaymentList> _result = new List<PartyPaymentCollect>();
        //    List<PandingPaymentList> _resultModel = new List<PandingPaymentList>();

        //    string queryString = "[dbo].[SP_GetCollectPayment]";
        //    try
        //    {
        //        using (SqlConnection connect = new SqlConnection(connectionString))
        //        {
        //            SqlCommand cmd = new SqlCommand(queryString, connect);
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@StringType", StringPara);
        //            //cmd.Parameters.AddWithValue("@PartyId", obj.PartyId);
        //            //cmd.Parameters.AddWithValue("@LoginID", obj.LoginID);
        //            SqlDataAdapter da = new SqlDataAdapter(cmd);
        //            DataSet ds = new DataSet();
        //            da.Fill(ds);
        //            if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
        //            {
        //                // First tabe
        //                if (ds.Tables[0].Rows.Count > 0)
        //                {
        //                    foreach (DataRow dr in ds.Tables[0].Rows)
        //                    {

        //                        _resultModel.Add(new PandingPaymentList()
        //                        {
        //                            PayTrackingId = dr["PayTrackingId"].NulllToInt(),
        //                            OrderId = dr["OrderId"].NulllToString(),
        //                            PartyId = dr["PartyId"].NulllToString(),
        //                            Party = dr["Party"].NulllToString(),
        //                            Name = dr["PartyName"].NulllToString(),
        //                            StateCity = dr["Address"].NulllToString(),
        //                            Charges = dr["PayableAmount"].NulllToDecimal(),
        //                            Transactionamt = dr["TransactionAmt"].NulllToDecimal(),
        //                            BalanceAmt = dr["BalancaAmt"].NulllToDecimal(),
        //                            RegistrationNo = dr["RegistrationNo"].NulllToString()
        //                        });
        //                    }
        //                    return _resultModel;
        //                    //_result.GrandTotal = _result.GrandTotal + dr["Amount"].NulllToDecimal();
        //                }
        //                //_result.Message = BO.CustomBO.CustomMessage.DATAFOUND;
        //                //_result.Flag = BO.CustomBO.CustomMessage.DATAFOUND_RESPONSECODE.NulllToInt();

        //            }
        //        }
        //        //}
        //        //return _result;
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
        //    string queryString = "[dbo].[GetPartyRegistrationDetails]";
        //    PartyProfile returnModel = new PartyProfile();
        //    try
        //    {
        //        using (SqlConnection conn = new SqlConnection(connectionString))
        //        {
        //            SqlCommand cmd = new SqlCommand(queryString, conn);
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@StringType", obj.StringType);
        //            cmd.Parameters.AddWithValue("@PartyId", obj.PartyId);
        //            //cmd.Parameters.AddWithValue("@LoginID", obj.LoginID);
        //            SqlDataAdapter da = new SqlDataAdapter(cmd);
        //            DataSet ds = new DataSet();
        //            da.Fill(ds);
        //            if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
        //            {
        //                if (ds.Tables[0].Rows.Count > 0)
        //                {
        //                    foreach (DataRow dr in ds.Tables[0].Rows)
        //                    {
        //                        returnModel.PartyId = dr["PartyId"].NulllToString();
        //                        returnModel.Type = dr["Type"].NulllToInt();
        //                        returnModel.CompanyId = dr["CompanyId"].NulllToInt();
        //                        returnModel.PartyCode = dr["PartyCode"].NulllToInt();
        //                        returnModel.FirstName = dr["FirstName"].NulllToString();
        //                        returnModel.MiddleName = dr["MiddleName"].NulllToString();
        //                        returnModel.LastName = dr["LastName"].NulllToString();
        //                        returnModel.MobileNumber = dr["MobileNumber"].NulllToString();
        //                        returnModel.EmailId = dr["EmailId"].NulllToString();
        //                        returnModel.CityId = dr["City"].NulllToInt();
        //                        returnModel.StateId = dr["State"].NulllToInt();
        //                        returnModel.RoleId = dr["SystemRole"].NulllToInt();
        //                        returnModel.DateofBirth = dr["DateofBirth"].NulllToDateTime();

        //                        returnModel.CurrentAddressLine1 = dr["CurrentAddressLine1"].NulllToString();
        //                        returnModel.CurrentAddressLine2 = dr["CurrentAddressLine2"].NulllToString();
        //                        returnModel.CurrentAddressLine3 = dr["CurrentAddressLine3"].NulllToString();
        //                        returnModel.CurrentAddressPincode = dr["CurrentAddressPincode"].NulllToString();

        //                        returnModel.ParmentAddressLine1 = dr["ParmentAddressLine1"].NulllToString();
        //                        returnModel.ParmentAddressLine2 = dr["ParmentAddressLine2"].NulllToString();
        //                        returnModel.ParmentAddressLine3 = dr["ParmentAddressLine3"].NulllToString();
        //                        returnModel.ParmentAddressPincode = dr["ParmentAddressPincode"].NulllToString();

        //                        returnModel.CompanyContactNumber = dr["CompanyContactNo"].NulllToString();
        //                        returnModel.CompanyEmail = dr["CompanyEmail"].NulllToString();
        //                        returnModel.CompanyGSTNo = dr["CompanyGSTNo"].NulllToString();
        //                        returnModel.CompanyGSTNo = dr["CompanyTanNo"].NulllToString();

        //                        returnModel.CompanyAddressLine1 = dr["CompanyAddressLine1"].NulllToString();
        //                        returnModel.CompanyAddressLine2 = dr["CompanyAddressLine2"].NulllToString();
        //                        returnModel.CompanyAddressLine3 = dr["CompanyAddressLine3"].NulllToString();
        //                        returnModel.CompanyAddressPincode = dr["CompanyAddressPincode"].NulllToString();

        //                        returnModel.ResponseCode = dr["Flag"].NulllToString();
        //                        returnModel.Message = dr["Message"].NulllToString();
        //                    }
        //                }
        //                else
        //                {
        //                    objResponseData.Message = BO.CustomMessage.NORECORDFOUND;
        //                    objResponseData.ResponseCode = BO.CustomMessage.NORECORDFOUND_RESPONSECODE.ToString();
        //                }

        //            }
        //            else
        //            {
        //                objResponseData.Message = BO.CustomMessage.NORECORDFOUND;
        //                objResponseData.ResponseCode = BO.CustomMessage.NORECORDFOUND_RESPONSECODE.ToString();
        //            }
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
        //    string queryString = "[dbo].[SP_GetCollectPayment]";
        //    try
        //    {
        //        using (SqlConnection conn = new SqlConnection(connectionString))
        //        {
        //            SqlCommand cmd = new SqlCommand(queryString, conn);
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@StringType", obj.StringType);
        //            cmd.Parameters.AddWithValue("@PayTrackingId", obj.PayTrackingId);
        //            cmd.Parameters.AddWithValue("@PartyId", obj.PartyId);
        //            SqlDataAdapter da = new SqlDataAdapter(cmd);
        //            DataSet ds = new DataSet();
        //            da.Fill(ds);
        //            if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
        //            {
        //                // First tabe
        //                if (ds.Tables[0].Rows.Count > 0)
        //                {
        //                    _result.partsummary.PartyId = ds.Tables[0].Rows[0]["PartyId"].NulllToString();
        //                    _result.partsummary.Name = ds.Tables[0].Rows[0]["Name"].NulllToString();
        //                    _result.partsummary.MobileNumber = ds.Tables[0].Rows[0]["MobileNumber"].NulllToString();
        //                    _result.partsummary.Email = ds.Tables[0].Rows[0]["EmailId"].NulllToString();
        //                    _result.partsummary.Address = ds.Tables[0].Rows[0]["ParmentAddress"].NulllToString();
        //                    _result.partsummary.PayTrackingId = ds.Tables[0].Rows[0]["PayTrackingId"].NulllToInt();
        //                    _result.partsummary.BalanceAmount = ds.Tables[0].Rows[0]["BalancaAmt"].NulllToInt();

        //                }

        //                if (ds.Tables[1].Rows.Count > 0)
        //                {

        //                    foreach (DataRow dr in ds.Tables[1].Rows)
        //                    {

        //                        //if (dr["chargeType"].NulllToString() != "GST")
        //                        //{

        //                        _result.ServiesDetailsList.Add(new ServiesDetails()
        //                        {
        //                            PartyId = dr["PartyId"].NulllToString(),
        //                            ServiceType = dr["Servicetype"].NulllToString(),
        //                            Service = dr["Name"].ToString(),
        //                            ChargeType = dr["chargeType"].NulllToString(),
        //                            Charge = dr["Amount"].NulllToDecimal(),
        //                            GST = dr["GstAmount"].NulllToDecimal(),
        //                            IGST = dr["IGST"].NulllToDecimal(),
        //                            CGST = dr["CGST"].NulllToDecimal(),
        //                            ServiceCharge = dr["ServiceCharges"].NulllToDecimal(),
        //                            Commision = dr["Commision"].NulllToDecimal(),
        //                            CourierCharge = dr["CourierCharges"].NulllToDecimal(),
        //                            TotalAmount = dr["TotalAmount"].NulllToDecimal(),
        //                        });
        //                        //}
        //                        if (dr["Servicetype"].NulllToString() == "service")
        //                        {
        //                            _result.GrandTotal = _result.GrandTotal + dr["Amount"].NulllToDecimal();
        //                        }
        //                        else
        //                        {
        //                            _result.GrandTotal = _result.GrandTotal + dr["Amount"].NulllToDecimal() + dr["GstAmount"].NulllToDecimal();
        //                        }
        //                        //_result.GrandTotal = _result.GrandTotal + dr["TotalAmount"].NulllToDecimal();
        //                    }
        //                    foreach (DataRow dr2 in ds.Tables[2].Rows)
        //                    {
        //                        _result.serviceGst = _result.serviceGst + dr2["GstAmount"].NulllToDecimal();
        //                    }
        //                    _result.GrandTotal = _result.GrandTotal + _result.serviceGst;
        //                    _result.Message = BO.CustomMessage.DATAFOUND;
        //                    _result.Flag = BO.CustomMessage.DATAFOUND_RESPONSECODE.NulllToInt();

        //                }
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
        //        using (SqlConnection conn = new SqlConnection(connectionString))
        //        {
        //            using (SqlCommand cmd = new SqlCommand())
        //            {
        //                cmd.CommandText = "[dbo].[SavePaymentColletion]";
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                cmd.Parameters.AddWithValue("@PayTrackingId", obj.PayTrackingId);
        //                cmd.Parameters.AddWithValue("@OrderId", obj.OrderId);
        //                cmd.Parameters.AddWithValue("@PartyId", obj.PartyId);
        //                cmd.Parameters.AddWithValue("@TransactionAmt", obj.CollectedAmt);
        //                //cmd.Parameters.AddWithValue("@BalancaAmt", obj.BalanceAmt);
        //                cmd.Parameters.AddWithValue("@Mode", "704");
        //                cmd.Parameters.AddWithValue("@PaymentMode", obj.PaymentMode);
        //                cmd.Parameters.AddWithValue("@Bank", obj.Bank);
        //                cmd.Parameters.AddWithValue("@Account", obj.AccountNumber);
        //                cmd.Parameters.AddWithValue("@ChequeNo", obj.ChequeNumber);
        //                cmd.Parameters.AddWithValue("@CollectedBy", obj.RecivedBy);
        //                //cmd.Parameters.AddWithValue("@@Narration")
        //                //conn.ConnectionString = con;
        //                cmd.Connection = conn;
        //                if (cmd.Connection.State != ConnectionState.Open)
        //                {
        //                    cmd.Connection.Open();
        //                }
        //                SqlDataAdapter da = new SqlDataAdapter(cmd);
        //                da.Fill(ds);
        //                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
        //                {
        //                    if (ds.Tables[0].Rows.Count > 0)
        //                    {
        //                        objResponseData.Message = ds.Tables[0].Rows[0]["Message"].NulllToString();
        //                        objResponseData.ResponseCode = ds.Tables[0].Rows[0]["Flag"].NulllToString();
        //                        return objResponseData;
        //                    }
        //                    else
        //                    {
        //                        objResponseData.Message = BO.CustomMessage.NORECORDFOUND;
        //                        objResponseData.ResponseCode = BO.CustomMessage.NORECORDFOUND_RESPONSECODE.ToString();
        //                        return objResponseData;
        //                    }
        //                }
        //                else
        //                {
        //                    objResponseData.Message = BO.CustomMessage.NORECORDFOUND;
        //                    objResponseData.ResponseCode = BO.CustomMessage.NORECORDFOUND_RESPONSECODE.ToString();
        //                    return objResponseData;
        //                }
        //            }
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
        //    //List<PandingPaymentList> _result = new List<PartyPaymentCollect>();
        //    List<PandingPaymentList> _resultModel = new List<PandingPaymentList>();

        //    string queryString = "[dbo].[SP_GetCollectPayment]";
        //    try
        //    {
        //        using (SqlConnection conn = new SqlConnection(connectionString))
        //        {
        //            SqlCommand cmd = new SqlCommand(queryString, conn);
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@StringType", obj);
        //            //cmd.Parameters.AddWithValue("@PartyId", obj.PartyId);
        //            //cmd.Parameters.AddWithValue("@LoginID", obj.LoginID);
        //            SqlDataAdapter da = new SqlDataAdapter(cmd);
        //            DataSet ds = new DataSet();
        //            da.Fill(ds);
        //            if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
        //            {
        //                // First tabe


        //                if (ds.Tables[0].Rows.Count > 0)
        //                {
        //                    foreach (DataRow dr in ds.Tables[0].Rows)
        //                    {

        //                        _resultModel.Add(new PandingPaymentList()
        //                        {
        //                            PayTrackingId = dr["PayTrackingId"].NulllToInt(),
        //                            OrderId = dr["OrderId"].NulllToString(),
        //                            PartyId = dr["PartyId"].NulllToString(),
        //                            Party = dr["Party"].NulllToString(),
        //                            Name = dr["PartyName"].NulllToString(),
        //                            StateCity = dr["Address"].NulllToString(),
        //                            Charges = dr["PayableAmount"].NulllToDecimal(),
        //                            Transactionamt = dr["TransactionAmt"].NulllToDecimal(),
        //                            BalanceAmt = dr["BalancaAmt"].NulllToDecimal(),
        //                            ChequeNo = dr["ChequeNo"].NulllToString(),
        //                            RegistrationNo = dr["RegistrationNo"].NulllToString()
        //                        });
        //                    }
        //                    return _resultModel;
        //                    //_result.GrandTotal = _result.GrandTotal + dr["Amount"].NulllToDecimal();
        //                }
        //                //_result.Message = BO.CustomBO.CustomMessage.DATAFOUND;
        //                //_result.Flag = BO.CustomBO.CustomMessage.DATAFOUND_RESPONSECODE.NulllToInt();

        //            }
        //        }
        //        //}
        //        //return _result;
        //    }
        //    catch (Exception ex)
        //    {
        //        //_result.Message = BO.CustomBO.CustomMessage.EXCEPTIONOCCURRED;
        //        //_result.Flag = BO.CustomBO.CustomMessage.EXCEPTIONOCCURRED_RESPONSECODE.NulllToInt();
        //        return _resultModel;
        //    }
        //    return _resultModel;
        //}

        //public ResponseData ChequeClear(PaymentCollectionModel obj)
        //{
        //    DataSet ds = new DataSet();
        //    try
        //    {
        //        using (SqlConnection conn = new SqlConnection(connectionString))
        //        {
        //            using (SqlCommand cmd = new SqlCommand())
        //            {
        //                cmd.CommandText = "[dbo].[ChequeClear]";
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                cmd.Parameters.AddWithValue("@PayTrackingId", obj.PayTrackingId);
        //                cmd.Parameters.AddWithValue("@OrderId", obj.OrderId);
        //                cmd.Parameters.AddWithValue("@PartyId", obj.PartyId);
        //                cmd.Connection = conn;
        //                if (cmd.Connection.State != ConnectionState.Open)
        //                {
        //                    cmd.Connection.Open();
        //                }
        //                SqlDataAdapter da = new SqlDataAdapter(cmd);
        //                da.Fill(ds);
        //                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
        //                {
        //                    if (ds.Tables[0].Rows.Count > 0)
        //                    {
        //                        objResponseData.Message = ds.Tables[0].Rows[0]["Message"].NulllToString();
        //                        objResponseData.ResponseCode = ds.Tables[0].Rows[0]["Flag"].NulllToString();
        //                        return objResponseData;
        //                    }
        //                    else
        //                    {
        //                        objResponseData.Message = BO.CustomMessage.NORECORDFOUND;
        //                        objResponseData.ResponseCode = BO.CustomMessage.NORECORDFOUND_RESPONSECODE.ToString();
        //                        return objResponseData;
        //                    }
        //                }
        //                else
        //                {
        //                    objResponseData.Message = BO.CustomMessage.NORECORDFOUND;
        //                    objResponseData.ResponseCode = BO.CustomMessage.NORECORDFOUND_RESPONSECODE.ToString();
        //                    return objResponseData;
        //                }
        //            }
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

        //    string queryString = "[dbo].[SP_GetCollectPayment]";
        //    try
        //    {
        //        using (SqlConnection conn = new SqlConnection(connectionString))
        //        {
        //            SqlCommand cmd = new SqlCommand(queryString, conn);
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@StringType", obj);
        //            //cmd.Parameters.AddWithValue("@PartyId", obj.PartyId);
        //            //cmd.Parameters.AddWithValue("@LoginID", obj.LoginID);
        //            SqlDataAdapter da = new SqlDataAdapter(cmd);
        //            DataSet ds = new DataSet();
        //            da.Fill(ds);
        //            if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
        //            {
        //                // First tabe


        //                if (ds.Tables[0].Rows.Count > 0)
        //                {
        //                    foreach (DataRow dr in ds.Tables[0].Rows)
        //                    {

        //                        _resultModel.Add(new PandingPaymentList()
        //                        {
        //                            PayTrackingId = dr["PayTrackingId"].NulllToInt(),
        //                            OrderId = dr["OrderId"].NulllToString(),
        //                            PartyId = dr["PartyId"].NulllToString(),
        //                            Party = dr["Party"].NulllToString(),
        //                            Name = dr["PartyName"].NulllToString(),
        //                            StateCity = dr["Address"].NulllToString(),
        //                            Charges = dr["PayableAmount"].NulllToDecimal(),
        //                            Transactionamt = dr["TransactionAmt"].NulllToDecimal(),
        //                            BalanceAmt = dr["BalancaAmt"].NulllToDecimal(),
        //                            ChequeNo = dr["ChequeNo"].NulllToString(),
        //                            RegistrationNo = dr["RegistrationNo"].NulllToString()
        //                        });
        //                    }
        //                    return _resultModel;
        //                    //_result.GrandTotal = _result.GrandTotal + dr["Amount"].NulllToDecimal();
        //                }
        //                //_result.Message = BO.CustomBO.CustomMessage.DATAFOUND;
        //                //_result.Flag = BO.CustomBO.CustomMessage.DATAFOUND_RESPONSECODE.NulllToInt();

        //            }
        //        }
        //        //}
        //        //return _result;
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
        //        using (SqlConnection conn = new SqlConnection(connectionString))
        //        {
        //            using (SqlCommand cmd = new SqlCommand())
        //            {
        //                cmd.CommandText = "[dbo].[ChequeUnClear]";
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                cmd.Parameters.AddWithValue("@PayTrackingId", obj.PayTrackingId);
        //                cmd.Parameters.AddWithValue("@OrderId", obj.OrderId);
        //                cmd.Parameters.AddWithValue("@PartyId", obj.PartyId);
        //                cmd.Connection = conn;
        //                if (cmd.Connection.State != ConnectionState.Open)
        //                {
        //                    cmd.Connection.Open();
        //                }
        //                SqlDataAdapter da = new SqlDataAdapter(cmd);
        //                da.Fill(ds);
        //                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
        //                {
        //                    if (ds.Tables[0].Rows.Count > 0)
        //                    {
        //                        objResponseData.Message = ds.Tables[0].Rows[0]["Message"].NulllToString();
        //                        objResponseData.ResponseCode = ds.Tables[0].Rows[0]["Flag"].NulllToString();
        //                        return objResponseData;
        //                    }
        //                    else
        //                    {
        //                        objResponseData.Message = BO.CustomMessage.NORECORDFOUND;
        //                        objResponseData.ResponseCode = BO.CustomMessage.NORECORDFOUND_RESPONSECODE.ToString();
        //                        return objResponseData;
        //                    }
        //                }
        //                else
        //                {
        //                    objResponseData.Message = BO.CustomMessage.NORECORDFOUND;
        //                    objResponseData.ResponseCode = BO.CustomMessage.NORECORDFOUND_RESPONSECODE.ToString();
        //                    return objResponseData;
        //                }
        //            }
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
        //        using (SqlConnection conn = new SqlConnection(connectionString))
        //        {
        //            using (SqlCommand cmd = new SqlCommand())
        //            {
        //                cmd.CommandText = "[dbo].[ChequeCancel]";
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                cmd.Parameters.AddWithValue("@PayTrackingId", obj.PayTrackingId);
        //                cmd.Parameters.AddWithValue("@OrderId", obj.OrderId);
        //                cmd.Parameters.AddWithValue("@PartyId", obj.PartyId);
        //                cmd.Parameters.AddWithValue("@CanceledBy", "");
        //                cmd.Connection = conn;
        //                if (cmd.Connection.State != ConnectionState.Open)
        //                {
        //                    cmd.Connection.Open();
        //                }
        //                SqlDataAdapter da = new SqlDataAdapter(cmd);
        //                da.Fill(ds);
        //                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
        //                {
        //                    if (ds.Tables[0].Rows.Count > 0)
        //                    {
        //                        objResponseData.Message = ds.Tables[0].Rows[0]["Message"].NulllToString();
        //                        objResponseData.ResponseCode = ds.Tables[0].Rows[0]["Flag"].NulllToString();
        //                        return objResponseData;
        //                    }
        //                    else
        //                    {
        //                        objResponseData.Message = BO.CustomMessage.NORECORDFOUND;
        //                        objResponseData.ResponseCode = BO.CustomMessage.NORECORDFOUND_RESPONSECODE.ToString();
        //                        return objResponseData;
        //                    }
        //                }
        //                else
        //                {
        //                    objResponseData.Message = BO.CustomMessage.NORECORDFOUND;
        //                    objResponseData.ResponseCode = BO.CustomMessage.NORECORDFOUND_RESPONSECODE.ToString();
        //                    return objResponseData;
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        objResponseData.Message = BO.CustomMessage.EXCEPTIONOCCURRED;
        //        objResponseData.ResponseCode = BO.CustomMessage.EXCEPTIONOCCURRED_RESPONSECODE.ToString();
        //        return objResponseData;
        //    }
        //}
        public ChangeRquestDataList ChangeRequestList(string PartyId)
        {
            ChangeRquestDataList _resultModel = new ChangeRquestDataList();
            _resultModel.ExistingParentDetails = new ClientRequestData();
            _resultModel.RequestedParentDetails = new ClientRequestData();
            _resultModel.ParentDetails = new List<ClientRequestData>();
            string queryString = "[dbo].[Sp_GetchangeRequest]";
            try
            {
                using (SqlConnection connect = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(queryString, connect);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@StringType", "RequestSend");
                    cmd.Parameters.AddWithValue("@PartyId", PartyId);
                    //cmd.Parameters.AddWithValue("@PartyId", obj.PartyId);
                    //cmd.Parameters.AddWithValue("@LoginID", obj.LoginID);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                    {
                        // First tabe
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow dr in ds.Tables[0].Rows)
                            {
                                //_resultModel.Add(new ClientRequestData()
                                //{
                                _resultModel.ExistingParentDetails.PartyId = dr["ParentId"].NulllToString();
                                _resultModel.ExistingParentDetails.PartyType = dr["Party"].NulllToString();
                                _resultModel.ExistingParentDetails.ParentId = dr["ParentId"].NulllToString();
                                _resultModel.ExistingParentDetails.RegistrationId = dr["RegistrationNo"].NulllToString();
                                _resultModel.ExistingParentDetails.Name = dr["PartyName"].NulllToString();
                                _resultModel.ExistingParentDetails.EmailId = dr["EmailId"].NulllToString();
                                _resultModel.ExistingParentDetails.Mobilenumber = dr["MobileNumber"].NulllToString();
                                _resultModel.ExistingParentDetails.District = dr["DistrictId"].NulllToString();
                                _resultModel.ExistingParentDetails.State = dr["StateId"].NulllToString();
                                _resultModel.ExistingParentDetails.CompanyAddress = dr["CompanyAddress"].NulllToString();
                                _resultModel.ExistingParentDetails.IsActive = dr["IsActive"].NulllToInt();
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
                                _resultModel.RequestedParentDetails.PartyId = dr["ParentId"].NulllToString();
                                _resultModel.RequestedParentDetails.PartyType = dr["Party"].NulllToString();
                                _resultModel.RequestedParentDetails.ParentId = dr["ParentId"].NulllToString();
                                _resultModel.RequestedParentDetails.RegistrationId = dr["RegistrationNo"].NulllToString();
                                _resultModel.RequestedParentDetails.Name = dr["PartyName"].NulllToString();
                                _resultModel.RequestedParentDetails.EmailId = dr["EmailId"].NulllToString();
                                _resultModel.RequestedParentDetails.Mobilenumber = dr["MobileNumber"].NulllToString();
                                _resultModel.RequestedParentDetails.District = dr["DistrictId"].NulllToString();
                                _resultModel.RequestedParentDetails.State = dr["StateId"].NulllToString();
                                _resultModel.RequestedParentDetails.CompanyAddress = dr["CompanyAddress"].NulllToString();
                                _resultModel.RequestedParentDetails.IsActive = dr["IsActive"].NulllToInt();
                                _resultModel.RequestedParentDetails.Currentstatus = dr["CurrentStatus"].NulllToString();
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
                                    PartyId = dr["PartyId"].NulllToString(),
                                    PartyType = dr["Party"].NulllToString(),
                                    ParentId = dr["ParentId"].NulllToString(),
                                    RegistrationId = dr["RegistrationNo"].NulllToString(),
                                    Name = dr["PartyName"].NulllToString(),
                                    EmailId = dr["EmailId"].NulllToString(),
                                    Mobilenumber = dr["MobileNumber"].NulllToString(),
                                    District = dr["DistrictId"].NulllToString(),
                                    State = dr["StateId"].NulllToString(),
                                    CompanyAddress = dr["CompanyAddress"].NulllToString(),
                                    IsActive = dr["IsActive"].NulllToInt(),
                                    Currentstatus = dr["CurrentStatus"].NulllToString(),
                                });
                            }
                            //_result.GrandTotal = _result.GrandTotal + dr["Amount"].NulllToDecimal();
                        }
                        //_result.Message = BO.CustomBO.CustomMessage.DATAFOUND;
                        //_result.Flag = BO.CustomBO.CustomMessage.DATAFOUND_RESPONSECODE.NulllToInt();

                    }
                }
                //}
                //return _result;
            }
            catch (Exception ex)
            {
                //_result.Message = BO.CustomBO.CustomMessage.EXCEPTIONOCCURRED;
                //_result.Flag = BO.CustomBO.CustomMessage.EXCEPTIONOCCURRED_RESPONSECODE.NulllToInt();
                return _resultModel;
            }
            return _resultModel;

        }
        public ResponseData SaveChangeRequest(string PartyId, string ParentId)
        {
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "[dbo].[sp_SaveChangeRequest]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@PartyId", PartyId);
                        cmd.Parameters.AddWithValue("@ParentId", ParentId);
                        //cmd.Parameters.AddWithValue("@@Narration")
                        //conn.ConnectionString = con;
                        cmd.Connection = conn;
                        if (cmd.Connection.State != ConnectionState.Open)
                        {
                            cmd.Connection.Open();
                        }
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);
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
            string queryString = "[dbo].[Sp_GetchangeRequest]";
            try
            {
                using (SqlConnection connect = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(queryString, connect);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@StringType", "AllRequestSendList");
                    cmd.Parameters.AddWithValue("@PartyId", PartyId);
                    //cmd.Parameters.AddWithValue("@PartyId", obj.PartyId);
                    //cmd.Parameters.AddWithValue("@LoginID", obj.LoginID);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
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
                                    IsActive = dr["IsActive"].NulllToInt(),
                                    Currentstatus = dr["CurrentStatus"].NulllToString(),
                                });
                            }
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
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_ChangeRequestChangeStatus]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@StringType", "Rejected");
                        cmd.Parameters.AddWithValue("@PartyId", PartyId);
                        cmd.Parameters.AddWithValue("@LoginId", LoginId);
                        //conn.ConnectionString = con;
                        cmd.Connection = conn;
                        if (cmd.Connection.State != ConnectionState.Open)
                        {
                            cmd.Connection.Open();
                        }
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);
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
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "[dbo].[SP_ChangeRequestChangeStatus]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@StringType", "Approved");
                        cmd.Parameters.AddWithValue("@PartyId", PartyId);
                        cmd.Parameters.AddWithValue("@LoginId", LoginId);
                        //conn.ConnectionString = con;
                        cmd.Connection = conn;
                        if (cmd.Connection.State != ConnectionState.Open)
                        {
                            cmd.Connection.Open();
                        }
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);
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
                }
            }
            catch (Exception ex)
            {
                objResponseData.Message = CustomMessage.EXCEPTIONOCCURRED;
                objResponseData.ResponseCode = CustomMessage.EXCEPTIONOCCURRED_RESPONSECODE.ToString();
                return objResponseData;
            }
        }
        public ResponseData UpdateDistrictSlotCounter(string DistrictName, int Counter)
        {
            //ResponseData responseData = new ResponseData();
            try
            {
                string queryString = "[dbo].[USP_UpdateDistrictSlotCounter]";
                using (SqlConnection connect = new SqlConnection())
                {
                    SqlCommand cmd = new SqlCommand(queryString, connect);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DistName", DistrictName.NulllToString());
                    cmd.Parameters.AddWithValue("@CounterValue", Counter.NulllToInt());
                    //cmd.Parameters.AddWithValue("@UpdatedBy", UpdatedBy.NulllToInt());
                    connect.ConnectionString = connectionString;
                    cmd.Connection = connect;
                    if (connect.State != ConnectionState.Open)
                    {
                        connect.Open();
                    }
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    if (ds != null && ds.Tables != null)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            objResponseData.statusCode = ds.Tables[0].Rows[0]["StatusCode"].NulllToInt();
                            objResponseData.Message = ds.Tables[0].Rows[0]["Message"].NulllToString();
                            objResponseData.ResponseCode = "000";
                        }
                    }
                    else
                    {
                        objResponseData.statusCode = 0;
                        objResponseData.Message = "Plese try Again";
                        objResponseData.ResponseCode = "000";
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : UpdateDistrictSlotCounter");
                objResponseData.statusCode = 0;
                objResponseData.Message = "Failed";
                objResponseData.ResponseCode = "000";
            }
            return objResponseData;
        }
        #region Get RateMaster
        public List<RateMaster> GetRateMasterList(int MstCategoryId, int SubMstCategoryId, int ChildCateId)
        {
            List<RateMaster> objListRate = new List<RateMaster>();
            string queryString = "[dbo].[USP_GetRete_Master]";
            using (SqlConnection connect = new SqlConnection())
            {
                SqlCommand cmd = new SqlCommand(queryString, connect);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MstCategoryID", MstCategoryId.NulllToString());
                cmd.Parameters.AddWithValue("@SubMstCategoryId", SubMstCategoryId.NulllToString());
                cmd.Parameters.AddWithValue("@ChildCateId", ChildCateId.NulllToString());

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
                    Console.Write(ds);
                    objListRate = new List<RateMaster>();

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        RateMaster objCountry = new RateMaster();
                        objCountry.RateId = Convert.ToInt32(ds.Tables[0].Rows[i]["RateId"]);
                        objCountry.DepartmentCharge = ds.Tables[0].Rows[i]["DepartmentCharge"].NulllToInt();
                        objCountry.EmitraCharge = ds.Tables[0].Rows[i]["EmitraCharge"].NulllToInt();
                        objCountry.PrintingCharge = ds.Tables[0].Rows[i]["PrintingCharge"].NulllToInt();
                        objCountry.HomeCharge = ds.Tables[0].Rows[i]["HomeCharge"].NulllToInt();
                        objCountry.CollectionTotal = ds.Tables[0].Rows[i]["CollectionTotal"].NulllToString();
                        objCountry.Total = ds.Tables[0].Rows[i]["Total"].NulllToString();
                        objCountry.DeliveryTotal = ds.Tables[0].Rows[i]["DeliveryTotal"].NulllToString();
                        objListRate.Add(objCountry);
                    }

                }
                else
                {
                    objListRate = null;
                }
            }
            Console.Write(objListRate);
            return objListRate;

        }
        #endregion
        #region Color
        public ResponseData UpdateColorServices(ServiceTypeDocument obj)
        {
            using (DataTable DT = new DataTable())
            {
                using (SqlConnection connect = new SqlConnection())
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "[dbo].[InsertColorService]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.AddWithValue("@MstServiceTypeID", objCitizenReq.MstServiceTypeID);
                        cmd.Parameters.AddWithValue("@CategoryName", obj.ServiceName);
                        cmd.Parameters.AddWithValue("@Buffer", obj.Type);
                        cmd.Parameters.AddWithValue("@Childlist", obj.InputString);
                        cmd.Parameters.AddWithValue("@CreatedByName", obj.CreatedByName);
                        cmd.Parameters.AddWithValue("@CreatedByID", obj.CreatedByID);
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
                            ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : UpdateChildServices");
                        }
                    }
                }
                return objResponseData;
            }
        }
        #endregion
        #region DataServiceList
        public List<ServiceTypeDocument> GetDataServiceList(string ID = "")
        {
            List<ServiceTypeDocument> objListService = new List<ServiceTypeDocument>();
            string queryString = "[dbo].[GetServiceList]";
            using (SqlConnection connect = new SqlConnection())
            {
                SqlCommand cmd = new SqlCommand(queryString, connect);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", ID);
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
                    Console.Write(ds);
                    objListService = new List<ServiceTypeDocument>();

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        ServiceTypeDocument objCountry = new ServiceTypeDocument();
                        objCountry.MstCategoryID = Convert.ToInt32(ds.Tables[0].Rows[i]["MstCategoryID"]);
                        objCountry.ServiceName = ds.Tables[0].Rows[i]["ServiceName"].NulllToString();
                        objCountry.Type = ds.Tables[0].Rows[i]["Type"].NulllToInt();
                        objListService.Add(objCountry);
                    }

                }
                else
                {
                    objListService = null;
                }
            }
            Console.Write(objListService);
            return objListService;
        }
        #endregion
        #region AddNewServiceType
        public ResponseData InsertServicedepartMapping(ServiceTypeDocument obj)
        {
            using (DataTable DT = new DataTable())
            {
                using (SqlConnection connect = new SqlConnection())
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "[dbo].[USP_MappingServicesDepartment]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@MstCategory", obj.MstCategoryID);
                        cmd.Parameters.AddWithValue("@ServiceName", obj.ServiceName);
                        //cmd.Parameters.AddWithValue("@DocumentName_Hindi", obj.DocumentName_Hindi);
                        //cmd.Parameters.AddWithValue("@Fromdays", obj.Fromdays);
                        //cmd.Parameters.AddWithValue("@Todays", obj.Todays);
                        //cmd.Parameters.AddWithValue("@Required", obj.Required);
                        //cmd.Parameters.AddWithValue("@CreatedByName", obj.CreatedByName);
                        //cmd.Parameters.AddWithValue("@CreatedByID", obj.CreatedByID);
                        //cmd.Parameters.AddWithValue("@CreatedIP", obj.CreatedIP);
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
                            ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : InsertServicedepartMapping");
                        }
                    }
                }
                return objResponseData;
            }
        }
        public ResponseData UpdateChildServices(ServiceTypeDocument obj)
        {
            using (DataTable DT = new DataTable())
            {
                using (SqlConnection connect = new SqlConnection())
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        if (obj.DocumentName == "DocData")
                        {
                            cmd.CommandText = "[dbo].[ServiceMappingDocument]";
                        }
                        else
                        {
                            cmd.CommandText = "[dbo].[ServiceMappingChildServicesy]";
                        }
                        cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.AddWithValue("@MstServiceTypeID", objCitizenReq.MstServiceTypeID);
                        cmd.Parameters.AddWithValue("@CategoryId", obj.MstCategoryID);
                        cmd.Parameters.AddWithValue("@SubCategory", obj.ServiceName);
                        cmd.Parameters.AddWithValue("@InputString", obj.InputString);
                        cmd.Parameters.AddWithValue("@ChildSubCategory", obj.ChildSubCategory);
                        cmd.Parameters.AddWithValue("@Type", obj.Type);
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
                            ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : UpdateChildServices");
                        }
                    }
                }
                return objResponseData;
            }
        }
        public ResponseData InsertServiceType(ServiceTypeDocument obj)
        {
            using (DataTable DT = new DataTable())
            {
                using (SqlConnection connect = new SqlConnection())
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        if (obj.Type == 2)
                        {
                            cmd.CommandText = "[dbo].[USP_InsertDocument]";
                            cmd.CommandType = CommandType.StoredProcedure;
                            //cmd.Parameters.AddWithValue("@MstServiceTypeID", objCitizenReq.MstServiceTypeID);
                            cmd.Parameters.AddWithValue("@DocumentName", obj.DocumentName);
                            cmd.Parameters.AddWithValue("@DocumentName_Hindi", obj.DocumentName_Hindi);
                        }
                        else
                        {
                            cmd.CommandText = "[dbo].[USP_ServiceDepartment_Insert]";
                            cmd.CommandType = CommandType.StoredProcedure;
                            //cmd.Parameters.AddWithValue("@MstServiceTypeID", objCitizenReq.MstServiceTypeID);
                            cmd.Parameters.AddWithValue("@ServiceName", obj.ServiceName);
                            cmd.Parameters.AddWithValue("@ServiceTypeCode", obj.ServiceTypeCode);
                            cmd.Parameters.AddWithValue("@Type", obj.Type);
                            cmd.Parameters.AddWithValue("@SubServiceType", obj.SubServiceType);
                            cmd.Parameters.AddWithValue("@ID", obj.ID);
                            cmd.Parameters.AddWithValue("@CollectionID", obj.CollectionID);


                        }

                        cmd.Parameters.AddWithValue("@CreatedByName", obj.CreatedByName);
                        cmd.Parameters.AddWithValue("@CreatedByID", obj.CreatedByID);
                        cmd.Parameters.AddWithValue("@CreatedIP", obj.CreatedIP);
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
                            ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : InsertServiceType");
                        }
                    }
                }
                return objResponseData;
            }
        }
        public ResponseData InsertServiceDocument(ServiceTypeDocument obj)
        {
            using (DataTable DT = new DataTable())
            {
                using (SqlConnection connect = new SqlConnection())
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "[dbo].[USP_ServiceDocument_Insert]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        //  cmd.Parameters.AddWithValue("@MstServiceTypeID", obj.MstServiceTypeID);
                        cmd.Parameters.AddWithValue("@DocumentName", obj.DocumentName);
                        cmd.Parameters.AddWithValue("@DocumentName_Hindi", obj.DocumentName_Hindi);
                        cmd.Parameters.AddWithValue("@Fromdays", obj.Fromdays);
                        cmd.Parameters.AddWithValue("@Todays", obj.Todays);
                        cmd.Parameters.AddWithValue("@Required", obj.Required);
                        cmd.Parameters.AddWithValue("@CreatedByName", obj.CreatedByName);
                        cmd.Parameters.AddWithValue("@CreatedByID", obj.CreatedByID);
                        cmd.Parameters.AddWithValue("@CreatedIP", obj.CreatedIP);
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
                            ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : InsertServiceType");
                        }
                    }
                }
                return objResponseData;
            }
        }
        public List<ServiceTypeDocument> GetDocumentList(string ID = "", string ChildId = "", bool ActiveOnly = false, string SortBy = null, string SearchText = null)
        {
            List<ServiceTypeDocument> objListdoc = new List<ServiceTypeDocument>();
            try
            {
                string queryString = "[dbo].[USP_MappingDocumentwithService]";
                using (SqlConnection connect = new SqlConnection())
                {
                    SqlCommand cmd = new SqlCommand(queryString, connect);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MstcategoryId", ID);
                    cmd.Parameters.AddWithValue("@ChildServiceId", ChildId);
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
                        objListdoc = new List<ServiceTypeDocument>();

                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            ServiceTypeDocument objdoc = new ServiceTypeDocument();
                            objdoc.MstCategoryID = ds.Tables[0].Rows[i]["DocumentID"].NulllToInt();
                            objdoc.ServiceName = ds.Tables[0].Rows[i]["DocumentName"].NulllToString();
                            //objdoc.DocumentName_Hindi = ds.Tables[0].Rows[i]["DocumentName_Hindi"].NulllToString();
                            //objdoc.Fromdays = ds.Tables[0].Rows[i]["Fromdays"].NulllToInt();
                            //objdoc.Todays = ds.Tables[0].Rows[i]["Todays"].NulllToInt();
                            //objdoc.MstServiceTypeID = ds.Tables[0].Rows[i]["MstServiceTypeID"].NulllToInt();
                            //objdoc.MstCategoryID = ds.Tables[0].Rows[i]["ID"].NulllToInt();
                            //objdoc.Required = ds.Tables[0].Rows[i]["Required"].NulllToString();
                            objdoc.Type = ds.Tables[0].Rows[i]["Isactive"].NulllToInt();
                            objListdoc.Add(objdoc);

                        }

                    }
                    else
                    {
                        objListdoc = null;
                    }
                }
            }
            catch (Exception e)
            {
                objListdoc = null;
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetServiceByDepartmentId");
            }
            return objListdoc;
        }
        public List<ServiceTypeDocument> GetServiceTypeDocument(string ID = "", bool ActiveOnly = false, string SortBy = null, string SearchText = null)
        {
            List<ServiceTypeDocument> objListdoc = new List<ServiceTypeDocument>();
            try
            {
                string queryString = "[dbo].[USP_M_ServiceTypeDocumentListByServiceId]";
                using (SqlConnection connect = new SqlConnection())
                {
                    SqlCommand cmd = new SqlCommand(queryString, connect);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", ID);
                    cmd.Parameters.AddWithValue("@SortBy", SortBy);
                    cmd.Parameters.AddWithValue("@SearchText", SearchText);
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
                        objListdoc = new List<ServiceTypeDocument>();
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            ServiceTypeDocument objdoc = new ServiceTypeDocument();
                            objdoc.SrNo = ds.Tables[0].Rows[i]["SrNo"].NulllToInt();
                            objdoc.DocumentName = ds.Tables[0].Rows[i]["DocumentName"].NulllToString();
                            objdoc.DocumentName_Hindi = ds.Tables[0].Rows[i]["DocumentName_Hindi"].NulllToString();
                            objdoc.Fromdays = ds.Tables[0].Rows[i]["Fromdays"].NulllToInt();
                            objdoc.Todays = ds.Tables[0].Rows[i]["Todays"].NulllToInt();
                            objdoc.MstServiceTypeID = ds.Tables[0].Rows[i]["MstServiceTypeID"].NulllToInt();
                            objdoc.MstCategoryID = ds.Tables[0].Rows[i]["ID"].NulllToInt();
                            objdoc.Required = ds.Tables[0].Rows[i]["Required"].NulllToString();
                            objdoc.IsActive = ds.Tables[0].Rows[i]["IsActive"].NulllToBoolean();
                            objListdoc.Add(objdoc);
                        }
                    }
                    else
                    {
                        objListdoc = null;
                    }
                }
            }
            catch (Exception e)
            {
                objListdoc = null;
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetServiceTypeDocument");
            }
            return objListdoc;
        }
        #endregion
        public List<ServiceTypeDocument> GetMainServiceList(string ID = "", bool ActiveOnly = false, string SortBy = null, string SearchText = null)
        {

            List<ServiceTypeDocument> objListdoc = new List<ServiceTypeDocument>();
            try
            {
                string queryString = "[dbo].[USP_M_AllServiceTypeList]";
                using (SqlConnection connect = new SqlConnection())
                {
                    SqlCommand cmd = new SqlCommand(queryString, connect);
                    cmd.CommandType = CommandType.StoredProcedure;
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
                        objListdoc = new List<ServiceTypeDocument>();

                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            ServiceTypeDocument objdoc = new ServiceTypeDocument();
                            objdoc.SrNo = ds.Tables[0].Rows[i]["SrNo"].NulllToInt();
                            objdoc.ServiceName = ds.Tables[0].Rows[i]["ServiceName"].NulllToString();
                            objdoc.ServiceTypeCode = ds.Tables[0].Rows[i]["ServiceTypeCode"].NulllToString();
                            objdoc.IsActive = ds.Tables[0].Rows[i]["IsActive"].NulllToBoolean();
                            objdoc.MstCategoryID = ds.Tables[0].Rows[i]["ID"].NulllToInt();
                            objListdoc.Add(objdoc);

                        }

                    }
                    else
                    {
                        objListdoc = null;
                    }
                }
            }
            catch (Exception e)
            {
                objListdoc = null;
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetServiceList");
            }
            return objListdoc;
        }


        public List<ServiceTypeDocument> GetServiceListNew(string ID = "", bool ActiveOnly = false, string SortBy = null, string SearchText = null)
        {

            List<ServiceTypeDocument> objListdoc = new List<ServiceTypeDocument>();
            try
            {
                string queryString = "[sdi].[USP_M_AllServiceTypeList]";
                using (SqlConnection connect = new SqlConnection())
                {
                    SqlCommand cmd = new SqlCommand(queryString, connect);
                    cmd.CommandType = CommandType.StoredProcedure;
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
                        objListdoc = new List<ServiceTypeDocument>();

                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            ServiceTypeDocument objdoc = new ServiceTypeDocument();
                            objdoc.SrNo = ds.Tables[0].Rows[i]["SrNo"].NulllToInt();
                            objdoc.ServiceName = ds.Tables[0].Rows[i]["ServiceName"].NulllToString();
                            objdoc.ServiceTypeCode = ds.Tables[0].Rows[i]["ServiceTypeCode"].NulllToString();
                            objdoc.IsActive = ds.Tables[0].Rows[i]["IsActive"].NulllToBoolean();
                            objdoc.MstCategoryID = ds.Tables[0].Rows[i]["ID"].NulllToInt();
                            objListdoc.Add(objdoc);

                        }

                    }
                    else
                    {
                        objListdoc = null;
                    }
                }
            }
            catch (Exception e)
            {
                objListdoc = null;
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetServiceList");
            }
            return objListdoc;
        }

    }
}
