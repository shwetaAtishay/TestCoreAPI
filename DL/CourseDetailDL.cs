using BO;
using BO.Models;
using DL;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace DL
{
    public class CourseDetailDL

    {
        ResponseData objResponseData = new ResponseData();
        ErrorBO _Access = new ErrorBO();
        public static IConfiguration _configuration;
        string connectionString = DBCS.GetConnectionString();


        public ResponseData CourseDetailConfigure(AddCourseBO obj)
        {
            using (DataTable DT = new DataTable())
            {
                using (SqlConnection connect = new SqlConnection())
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "[dbo].[USP_MASTER_AddCourseDetails_Save]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TrustInfoId", obj.TrustInfoId);
                        cmd.Parameters.AddWithValue("@CollageId", obj.iCollegeId);
                        cmd.Parameters.AddWithValue("@DegreeId", obj.TagDegrees);
                        cmd.Parameters.AddWithValue("@CourseId", obj.TagCourse);
                        //cmd.Parameters.AddWithValue("@CourseId", obj.TagCourse);
                        cmd.Parameters.AddWithValue("@SubjectName", obj.SubjectName);
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
                            ExceptionLogDL.SendExcepToDB(e, 0, "Class : BasicDetailsDL / Function : InsertUpdateBasickDetails");
                        }
                    }
                }
                return objResponseData;
            }
        }
        /// <summary>
        /// This method write by abhishek ,purpose of this method to return list of Addcourse regarding by TrustId
        /// </summary>
        /// <param name="TrustId"></param>
        /// <returns>List of AddCourseBO</returns>
        public List<AddCourseBO> GetCourseData(string TrustId)
        {
            List<AddCourseBO> objlist = new List<AddCourseBO>();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@TrustId", TrustId);
                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_MASTER_AddCourse_List]", param);
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    objlist = new List<AddCourseBO>();
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        AddCourseBO objdoc = new AddCourseBO();
                        objdoc.iPk_AddCourseId = Convert.ToInt32(ds.Tables[0].Rows[i]["iPk_AddCourseId"].NulllToInt());
                        objdoc.TrustInfoId = ds.Tables[0].Rows[i]["TrustName"].NulllToString();
                        objdoc.iCollegeId = ds.Tables[0].Rows[i]["CollageName"].NulllToString();
                        objdoc.TagDegrees = ds.Tables[0].Rows[i]["Deegree"].NulllToString();
                        objdoc.iFK_CourseId = ds.Tables[0].Rows[i]["iFK_CourseId"].NulllToInt();
                        objdoc.SubjectName = ds.Tables[0].Rows[i]["subjectlist"].NulllToString();
                        objdoc.TagCourse = ds.Tables[0].Rows[i]["Courses"].NulllToString();
                        objdoc.PNOC = ds.Tables[0].Rows[i]["PNOC"].NulllToInt();
                        objdoc.TNOC = ds.Tables[0].Rows[i]["TNOC"].NulllToInt();
                        objdoc.iFK_DeptId = ds.Tables[0].Rows[i]["iFK_DeptId"].NulllToInt();
                        objdoc.ClgId = ds.Tables[0].Rows[i]["ClgId"].NulllToInt();
                        objdoc.Sublist = ds.Tables[0].Rows[i]["Sublist"].NulllToString();
                        objdoc.Fk_StatusId = ds.Tables[0].Rows[i]["Fk_StatusId"].NulllToInt();
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
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : TargetDL / Function : GetTarget");
            }
            return objlist;
        }
        //By ID for edit
        public List<AddCourseBO> DetailsList(string type, int iPK_SubId, string SubjectName)
        {
            List<AddCourseBO> objlist = new List<AddCourseBO>();
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@iPK_SubId", iPK_SubId);
                param[1] = new SqlParameter("@Type", type);
                param[2] = new SqlParameter("@sSubjectName", SubjectName);
                // param[3] = new SqlParameter("@ApplicationNo", applicationNumber);
                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_MASTER_SubjectDetails_ViewUpdate]", param);
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    objlist = new List<AddCourseBO>();
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        AddCourseBO objdoc = new AddCourseBO();
                        objdoc.iPK_SubId = Convert.ToInt32(ds.Tables[0].Rows[i]["iPK_SubId"]);
                        objdoc.SubjectName = ds.Tables[0].Rows[i]["sSubjectName"].NulllToString();
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
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : CourseDL / Function : DetailsList");
            }
            return objlist;
        }
        //For Page Render
        public List<AddCourseBO> SubjectPageDetailsList(string applGUID)
        {
            List<AddCourseBO> objlist = new List<AddCourseBO>();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@Type", "GetIDeatails");
                param[1] = new SqlParameter("@Guid", applGUID);
                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_MASTER_SubjectDetails_View]", param);
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    objlist = new List<AddCourseBO>();
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        AddCourseBO objdoc = new AddCourseBO();
                        //objdoc.iPK_SubId = Convert.ToInt32(ds.Tables[0].Rows[i]["iPK_SubId"]);
                        objdoc.TagDegrees = ds.Tables[0].Rows[i]["sDeptName"].NulllToString();
                        objdoc.TagCourse = ds.Tables[0].Rows[i]["sName"].NulllToString();
                        objdoc.iCollegeId = ds.Tables[0].Rows[i]["sNameOfClg"].NulllToString();
                        //objdoc.SubjectName = ds.Tables[0].Rows[i]["sSubjectName"].NulllToString();
                        //objdoc.applicationNumber = ds.Tables[0].Rows[i]["applicationNumber"].NulllToString();
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
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : TargetDL / Function : GetTarget");
            }
            return objlist;
        }
        //end
        public List<AddCourseBO> SubjectDetailsList(string applGUID)
        {
            List<AddCourseBO> objlist = new List<AddCourseBO>();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@Type", "get");
                param[1] = new SqlParameter("@Guid", applGUID);
                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_MASTER_SubjectDetails_View]", param);
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    objlist = new List<AddCourseBO>();
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        AddCourseBO objdoc = new AddCourseBO();
                        objdoc.iPK_SubId = Convert.ToInt32(ds.Tables[0].Rows[i]["iPK_SubId"]);
                        objdoc.TagDegrees = ds.Tables[0].Rows[i]["degree"].NulllToString();
                        objdoc.TagCourse = ds.Tables[0].Rows[i]["Course"].NulllToString();
                        objdoc.SubjectName = ds.Tables[0].Rows[i]["sSubjectName"].NulllToString();
                        objdoc.CollegeName = ds.Tables[0].Rows[i]["CollageName"].NulllToString();
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
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : TargetDL / Function : GetTarget");
            }
            return objlist;
        }
        public List<CustomEnum> CollegeDetailsList()
        {
            List<CustomEnum> objlist = new List<CustomEnum>();
            try
            {
                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_MASTER_CollegeDetails_List]");
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    objlist = new List<CustomEnum>();
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        CustomEnum objdoc = new CustomEnum();
                        objdoc.Id = Convert.ToInt32(ds.Tables[0].Rows[i]["iPk_ClgID"].NulllToInt());
                        objdoc.Name = ds.Tables[0].Rows[i]["sNameOfClg"].NulllToString();
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
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : TargetDL / Function : GetTarget");
            }
            return objlist;
        }

        //Subject Details Save
        public ResponseData SubjectDetails(AddCourseBO obj)
        {
            using (DataTable DT = new DataTable())
            {
                using (SqlConnection connect = new SqlConnection())
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {

                        cmd.CommandText = "[dbo].[USP_MASTER_AddSubjectDetails_Save]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CollegeId", 0);  //obj.iCollegeId);
                        cmd.Parameters.AddWithValue("@SubjectName", obj.SubjectName);
                        cmd.Parameters.AddWithValue("@DegreeId", 0); //obj.TagDegrees); ;
                        cmd.Parameters.AddWithValue("@CourseId", 0);  //obj.TagCourse);
                        cmd.Parameters.AddWithValue("@applNumber", obj.applicationNumber);
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
                                    objResponseData.Data = obj.applicationNumber;
                                }
                            }
                            else
                            {
                                objResponseData.statusCode = 0;
                                objResponseData.Message = "Failed";
                                objResponseData.Data = "";
                            }
                        }
                        catch (Exception e)
                        {
                            objResponseData.statusCode = 0;
                            objResponseData.Message = "Failed";
                            objResponseData.Data = "";
                            ExceptionLogDL.SendExcepToDB(e, 0, "Class : AddCourseDL / Function : SubjectDetail");
                        }
                    }
                }
                return objResponseData;
            }
        }

        public List<AddCourseBO> GetEditData(int id)
        {
            List<AddCourseBO> objlist = new List<AddCourseBO>();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@Id", id);

                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_MASTER_AddCourse_Edit]", param);
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    objlist = new List<AddCourseBO>();
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        AddCourseBO objdoc = new AddCourseBO();
                        objdoc.iPk_AddCourseId = Convert.ToInt32(ds.Tables[0].Rows[i]["iPk_AddCourseId"]);
                        objdoc.TrustInfoId = ds.Tables[0].Rows[i]["TrustName"].NulllToString();
                        objdoc.iCollegeId = ds.Tables[0].Rows[i]["CollageName"].NulllToString();
                        objdoc.iFK_DeptId = Convert.ToInt32(ds.Tables[0].Rows[i]["iFK_DeptId"]);
                        objdoc.TagDegrees = ds.Tables[0].Rows[i]["Deegree"].NulllToString();
                        objdoc.iFK_CourseId = ds.Tables[0].Rows[i]["iFK_CourseId"].NulllToInt();
                        objdoc.TagCourse = ds.Tables[0].Rows[i]["Courses"].NulllToString();
                        objdoc.SubjectId = ds.Tables[0].Rows[i]["SubjectId"].NulllToString();
                        objdoc.SubjectName = ds.Tables[0].Rows[i]["subjectlist"].NulllToString();
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
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : TargetDL / Function : GetTarget");
            }
            return objlist;
        }

        public ResponseData RemoveData(int id)
        {
            ResponseData objlist = new ResponseData();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@Id", id);

                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_MASTER_AddCourse_RemoveData]", param);
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    objlist.statusCode = Convert.ToInt32(ds.Tables[0].Rows[0]["StatusCode"]);
                    objlist.Message = ds.Tables[0].Rows[0]["Message"].ToString();

                }
                else
                {
                    objlist.statusCode = 0;
                    objlist.Message = "Failed";
                }
            }
            catch (Exception e)
            {
                objlist = null;
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : TargetDL / Function : GetTarget");
            }
            return objlist;
        }


        public ResponseData PutEditData(AddCourseBO obj)
        {
            using (DataTable DT = new DataTable())
            {
                using (SqlConnection connect = new SqlConnection())
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {

                        cmd.CommandText = "[dbo].[USP_MASTER_AddCourseDetails_EditUpdate]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TrustInfoId", obj.TrustInfoId);
                        cmd.Parameters.AddWithValue("@CollageId", obj.iCollegeId);
                        cmd.Parameters.AddWithValue("@DegreeId", obj.TagDegrees);
                        cmd.Parameters.AddWithValue("@CourseId", obj.TagCourse);
                        //cmd.Parameters.AddWithValue("@SubjectId", obj.SubjectName);
                        cmd.Parameters.AddWithValue("@iPk_AddCourseId", obj.iPk_AddCourseId);
                        cmd.Parameters.AddWithValue("@sSubjectlist ", obj.SubjectName);
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
                            ExceptionLogDL.SendExcepToDB(e, 0, "Class : BasicDetailsDL / Function : InsertUpdateBasickDetails");
                        }
                    }
                }
                return objResponseData;
            }
        }

        public List<AddCourseBO> ExistingNOCGetSubjectList(ExistingNOCRequest obj)
        {
            DataSet ds = new DataSet();
            List<AddCourseBO> objlist = new List<AddCourseBO>();
            try
            {
                SqlParameter[] param = new SqlParameter[5];
                param[0] = new SqlParameter("@Type", "SubjectDetails");
                param[1] = new SqlParameter("@CollageId", obj.CollageId);
                param[2] = new SqlParameter("@CourseId", obj.CourseId);
                param[3] = new SqlParameter("@DepartmentId", obj.DepartmentId);
                param[4] = new SqlParameter("@TrustId", obj.TrustId);
                ds = BaseFunction.FillDataSet("[dbo].[USP_ExistingNOCDetails]", param);

                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    objlist = new List<AddCourseBO>();
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        AddCourseBO objdoc = new AddCourseBO();
                        objdoc.iPK_SubId = Convert.ToInt32(ds.Tables[0].Rows[i]["iPK_SubId"]);
                        objdoc.TagDegrees = ds.Tables[0].Rows[i]["Dept"].NulllToString();
                        objdoc.TagCourse = ds.Tables[0].Rows[i]["Course"].NulllToString();
                        objdoc.SubjectName = ds.Tables[0].Rows[i]["sSubjectName"].NulllToString();
                        //objdoc.CollegeName = ds.Tables[0].Rows[i]["CollageName"].NulllToString();
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
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : TargetDL / Function : GetTarget");
            }
            return objlist;
        }

        public List<CustomEnum> SubjectList(int id)
        {
            List<CustomEnum> objlist = new List<CustomEnum>();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@clg_id", id);
                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_MASTER_Subject_List_Course]", param);
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    objlist = new List<CustomEnum>();
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        CustomEnum objdoc = new CustomEnum();
                        objdoc.Id = Convert.ToInt32(ds.Tables[0].Rows[i]["Id"].NulllToInt());
                        objdoc.text = ds.Tables[0].Rows[i]["text"].NulllToString();
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
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : TargetDL / Function : GetTarget");
            }
            return objlist;
        }

    }
}
