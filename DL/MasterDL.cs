using BO;
using BO.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using static BO.Models.Partial;

namespace DL
{
    public class MasterDL
    {
        ResponseData objResponseData = new ResponseData();
        public static IConfiguration _configuration;
        string connectionString = DBCS.GetConnectionString();
        string BaseURL = DBCS.GetBaseURL();
        #region Abhishek
        public ResponseData UpdateNocDepartmentMapping(NOCDEPMAP obj)
        {
            try
            {
                //NOCDEPMAP
                SqlParameter[] param = new SqlParameter[8];
                param[0] = new SqlParameter("@iPk_DeptMapId", obj.iPk_DeptMapId);
                param[1] = new SqlParameter("@iFk_DeptId", obj.iFk_DeptId);
                param[2] = new SqlParameter("@iFk_NOCDeptId", obj.iFk_NOCDeptId);
                param[3] = new SqlParameter("@iFk_NOCTyp", obj.iFk_NOCTyp);
                param[4] = new SqlParameter("@iStts", obj.iStts);
                param[5] = new SqlParameter("@iMode", obj.iMode);
                param[6] = new SqlParameter("@iFk_NocSpecialId", obj.iFk_NocSpecialId);
                param[7] = new SqlParameter("@iSpecialStatus", obj.iSpecialStatus);
                DataTable DT = BaseFunction.FillDataTable("[dbo].[Usp_Mst_NOC_DepartMapping]", param);
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
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : UpdatePartyMaster");
            }
            return objResponseData;
        }

        public ResponseData InsertParameterCategoryMapping(PARAMCAT obj)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[6];
                param[0] = new SqlParameter("@iPk_ParmCateId", obj.iPk_ParmCateId);
                param[1] = new SqlParameter("@iFk_Deptid", obj.iFk_Deptid);
                param[2] = new SqlParameter("@iParCatId", obj.iParCatId);
                param[3] = new SqlParameter("@iParCatSubId", obj.iParCatSubId);
                param[4] = new SqlParameter("@iParUomid", obj.iParUomid);
                param[5] = new SqlParameter("@sParmetNam", obj.sParmetNam);
                DataTable DT = BaseFunction.FillDataTable("[dbo].[Usp_Mst_ParamCategorymapping_save]", param);
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
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : UpdatePartyMaster");
            }
            return objResponseData;
        }

        public List<Dropdown> GetNOCDepartmentsName(int Type)
        {
            List<Dropdown> objList = new List<Dropdown>();
            try
            {

                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@Type", Type);
                DataSet ds = BaseFunction.FillDataSet("[dbo].[Usp_Mst_NOC_DepartMapping_View]", param);
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    objList = new List<Dropdown>();

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        Dropdown obj = new Dropdown();
                        obj.Id = ds.Tables[0].Rows[i]["Id"].NulllToString();
                        obj.Text = ds.Tables[0].Rows[i]["text"].NulllToString();

                        objList.Add(obj);

                    }

                }
                else
                {
                    objList = null;
                }
            }
            catch (Exception e)
            {
                objList = null;
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetRegistratedUsers");
            }
            return objList;

        }
        public List<Dropdown> GetPerameterCategoryList(int Type, int Deptid, int iFk_SelfId, int EnumId)
        {
            List<Dropdown> objList = new List<Dropdown>();
            try
            {

                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@iTypid", Type);
                param[1] = new SqlParameter("@Deptid", Deptid);
                param[2] = new SqlParameter("@iFk_SelfId", iFk_SelfId);
                param[3] = new SqlParameter("@EnumId", EnumId);
                DataSet ds = BaseFunction.FillDataSet("[dbo].[Usp_Mst_Parameter_Category_Mapping_View]", param);
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    objList = new List<Dropdown>();

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        Dropdown obj = new Dropdown();
                        obj.Id = ds.Tables[0].Rows[i]["iNocCstId"].NulllToString();
                        obj.Text = ds.Tables[0].Rows[i]["sName"].NulllToString();

                        objList.Add(obj);

                    }

                }
                else
                {
                    objList = null;
                }
            }
            catch (Exception e)
            {
                objList = null;
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetRegistratedUsers");
            }
            return objList;

        }

        public List<NOCDEPMAP> GetNOCDepartMaplst(int Departid)
        {
            List<NOCDEPMAP> objList = new List<NOCDEPMAP>();
            try
            {
                DataSet ds = new DataSet();
                if (Departid > 0)
                {
                    SqlParameter[] param = new SqlParameter[1];
                    param[0] = new SqlParameter("@Departid", Departid);
                    ds = BaseFunction.FillDataSet("[dbo].[Usp_Mst_NOC_DepartMapping_View]", param);
                }
                else
                {
                    ds = BaseFunction.FillDataSet("[dbo].[Usp_Mst_NOC_DepartMapping_View]");
                }
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    objList = new List<NOCDEPMAP>();

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        NOCDEPMAP obj = new NOCDEPMAP();
                        obj.NewGuid = ds.Tables[0].Rows[i]["NewGuid"].NulllToString();
                        obj.iPk_DeptMapId = ds.Tables[0].Rows[i]["iPk_DeptMapId"].NulllToInt();
                        obj.DepartName = ds.Tables[0].Rows[i]["DepartName"].NulllToString();
                        obj.iFk_DeptId = ds.Tables[0].Rows[i]["iFk_DeptId"].NulllToInt();
                        obj.iFk_NOCDeptId = ds.Tables[0].Rows[i]["iFk_NOCDeptId"].NulllToString();
                        obj.iFk_NOCTyp = ds.Tables[0].Rows[i]["iFk_NOCTyp"].NulllToString();
                        obj.iMode = ds.Tables[0].Rows[i]["iMode"].NulllToInt();
                        obj.iStts = ds.Tables[0].Rows[i]["iStts"].NulllToInt();
                        obj.NocDepartmentName = ds.Tables[0].Rows[i]["NocDepartmentName"].NulllToString();
                        obj.NocDepartmenttype = ds.Tables[0].Rows[i]["NocDepartmenttype"].NulllToString();
                        obj.NocSpecialId = ds.Tables[0].Rows[i]["iFk_NocSpecialId"].NulllToInt();
                        obj.iSpecialStatus = ds.Tables[0].Rows[i]["iSpecialStatus"].NulllToInt();
                        obj.iFk_NocSpecialId = ds.Tables[0].Rows[i]["NocSpecialName"].NulllToString();
                        objList.Add(obj);

                    }

                }
                else
                {
                    objList = null;
                }
            }
            catch (Exception e)
            {
                objList = null;
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetRegistratedUsers");
            }
            return objList;
        }

        public List<PARAMCAT> GetPerameterTableList(int Type, int Deptid, int iFk_SelfId, int EnumId)
        {
            List<PARAMCAT> objList = new List<PARAMCAT>();
            try
            {

                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@iTypid", Type);
                param[1] = new SqlParameter("@Deptid", Deptid);
                param[2] = new SqlParameter("@iFk_SelfId", iFk_SelfId);
                param[3] = new SqlParameter("@EnumId", EnumId);
                DataSet ds = BaseFunction.FillDataSet("[dbo].[Usp_Mst_Parameter_Category_Mapping_NewView]", param);
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    objList = new List<PARAMCAT>();

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        PARAMCAT obj = new PARAMCAT();
                        obj.iPk_ParmCateId = ds.Tables[0].Rows[i]["iPk_ParmCateId"].NulllToInt();
                        obj.iFk_Deptid = ds.Tables[0].Rows[i]["iFk_Deptid"].NulllToInt();
                        obj.iParCatId = ds.Tables[0].Rows[i]["iParCatId"].NulllToString();
                        obj.iParCatSubId = ds.Tables[0].Rows[i]["iParCatSubId"].NulllToString();
                        obj.iParUomid = ds.Tables[0].Rows[i]["iParUomid"].NulllToString();
                        obj.iStts = ds.Tables[0].Rows[i]["iStts"].NulllToInt();
                        obj.sParmetNam = ds.Tables[0].Rows[i]["sParmetNam"].NulllToString();
                        obj.sDeptName = ds.Tables[0].Rows[i]["sDeptName"].NulllToString();
                        obj.sParCatName = ds.Tables[0].Rows[i]["sParCatName"].NulllToString();
                        obj.sParCatSubName = ds.Tables[0].Rows[i]["sParCatSubName"].NulllToString();
                        obj.sParUomName = ds.Tables[0].Rows[i]["sParUomName"].NulllToString();

                        objList.Add(obj);

                    }

                }
                else
                {
                    objList = null;
                }
            }
            catch (Exception e)
            {
                objList = null;
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetRegistratedUsers");
            }
            return objList;

        }

        public List<Dropdown> GetCategorySubUOM(int Deptid, int Category, int SubCategory, string Table)
        {
            List<Dropdown> objList = new List<Dropdown>();
            try
            {

                SqlParameter[] param = new SqlParameter[3];
                //param[0] = new SqlParameter("@Deptid", Deptid);
                param[0] = new SqlParameter("@Category", Category);
                param[1] = new SqlParameter("@SubCategory", SubCategory);
                param[2] = new SqlParameter("@Table", Table);
                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_Admin_Fill_Cate_SubCate_NewUom]", param);
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    objList = new List<Dropdown>();

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        Dropdown obj = new Dropdown();
                        obj.Id = ds.Tables[0].Rows[i]["Id"].NulllToString();

                        obj.Text = ds.Tables[0].Rows[i]["Text"].NulllToString();


                        objList.Add(obj);

                    }

                }
                else
                {
                    objList = null;
                }
            }
            catch (Exception e)
            {
                objList = null;
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetRegistratedUsers");
            }
            return objList;
        }



        public ResponseData InsertParameterValueConfiguration(PARMTVALUCONFMST obj)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[18];
                param[0] = new SqlParameter("@iPK_ParValId", obj.iPK_ParValId);
                param[1] = new SqlParameter("@iFk_Deptid", obj.iFk_Deptid);
                param[2] = new SqlParameter("@iParCatId", obj.iParCatId);
                param[3] = new SqlParameter("@iParCatSubId", obj.iParCatSubId);
                param[4] = new SqlParameter("@iParUomid", obj.iParUomid);
                param[5] = new SqlParameter("@iCourseId", obj.iCourseId);
                param[6] = new SqlParameter("@iMin", obj.iMin);
                param[7] = new SqlParameter("@iMax", obj.iMax);
                param[8] = new SqlParameter("@iField", obj.iField);
                param[9] = new SqlParameter("@iValue", obj.iValue);
                param[10] = new SqlParameter("@iminlength", obj.iminlength);
                param[11] = new SqlParameter("@iminwidth", obj.iminwidth);
                param[12] = new SqlParameter("@iminval", obj.iminval);
                param[13] = new SqlParameter("@imaxlength", obj.imaxlength);
                param[14] = new SqlParameter("@imaxwidth", obj.imaxwidth);
                param[15] = new SqlParameter("@imaxval", obj.imaxval);
                param[16] = new SqlParameter("@iStts", obj.iStts);
                param[17] = new SqlParameter("@iFix", obj.iFix);
                DataTable DT = BaseFunction.FillDataTable("[dbo].[Usp_Mst_ParamValueConfiguration_Save]", param);
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
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : UpdatePartyMaster");
            }
            return objResponseData;
        }

        public List<PARMTVALUCONFMSTView> SelectParameterValueConfiguration(int Id, int EnumId, int CourseEnumId, string Appid)
        {
            List<PARMTVALUCONFMSTView> objList = new List<PARMTVALUCONFMSTView>();
            try
            {
                DataSet ds = new DataSet();
                if (Id == 0)
                {
                    SqlParameter[] param = new SqlParameter[3];
                    param[0] = new SqlParameter("@UOMEnumId", EnumId);
                    param[1] = new SqlParameter("@CourseEnumId", CourseEnumId);

                    param[2] = new SqlParameter("@Appid", Appid);
                    ds = BaseFunction.FillDataSet("[dbo].[Usp_Admin_NewParameterConfigu_View]", param);
                }
                else
                {
                    SqlParameter[] param = new SqlParameter[4];
                    param[0] = new SqlParameter("@UOMEnumId", EnumId);
                    param[1] = new SqlParameter("@CourseEnumId", CourseEnumId);
                    param[2] = new SqlParameter("@iPK_ParValid", Id);

                    param[3] = new SqlParameter("@Appid", Appid);
                    ds = BaseFunction.FillDataSet("[dbo].[Usp_Admin_NewParameterConfigu_View]", param);
                }
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    objList = new List<PARMTVALUCONFMSTView>();

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {

                        PARMTVALUCONFMSTView obj = new PARMTVALUCONFMSTView();
                        obj.iPK_ParValId = ds.Tables[0].Rows[i]["iPK_ParValId"].NulllToInt();
                        obj.iFk_Deptid = ds.Tables[0].Rows[i]["iFk_Deptid"].NulllToInt();
                        obj.iCourseId = ds.Tables[0].Rows[i]["iCourseId"].NulllToInt();
                        obj.iParCatId = ds.Tables[0].Rows[i]["iParCatId"].NulllToInt();
                        obj.iParCatSubId = ds.Tables[0].Rows[i]["iParCatSubId"].NulllToInt();
                        obj.iParUomid = ds.Tables[0].Rows[i]["iParUomid"].NulllToInt();
                        obj.iMin = ds.Tables[0].Rows[i]["iMin"].NulllToInt();
                        obj.iMax = ds.Tables[0].Rows[i]["iMax"].NulllToInt();
                        obj.iField = ds.Tables[0].Rows[i]["iField"].NulllToInt();
                        obj.iValue = ds.Tables[0].Rows[i]["iValue"].NulllToInt();
                        obj.iminlength = ds.Tables[0].Rows[i]["iminlength"].NulllToInt();
                        obj.iminwidth = ds.Tables[0].Rows[i]["iminwidth"].NulllToInt();
                        obj.iminval = ds.Tables[0].Rows[i]["iminval"].NulllToInt();
                        obj.imaxlength = ds.Tables[0].Rows[i]["imaxlength"].NulllToInt();
                        obj.imaxwidth = ds.Tables[0].Rows[i]["imaxwidth"].NulllToInt();
                        obj.imaxval = ds.Tables[0].Rows[i]["imaxval"].NulllToInt();
                        obj.sDeptName = ds.Tables[0].Rows[i]["sDeptName"].NulllToString();
                        obj.sCateName = ds.Tables[0].Rows[i]["sCateName"].NulllToString();
                        obj.sCateSubName = ds.Tables[0].Rows[i]["sCateSubName"].NulllToString();
                        obj.iFix = ds.Tables[0].Rows[i]["iFix"].NulllToInt();
                        obj.UomName = ds.Tables[0].Rows[i]["UomName"].NulllToString();
                        obj.iStts = ds.Tables[0].Rows[i]["iStts"].NulllToInt();
                        obj.CourseName = ds.Tables[0].Rows[i]["CourseName"].NulllToString();
                        obj.InsertValue = ds.Tables[0].Rows[i]["InsertValue"].NulllToString();
                        obj.UploadUrl = ds.Tables[0].Rows[i]["UploadUrl"].NulllToString();
                        objList.Add(obj);

                    }

                }
                else
                {
                    objList = null;
                }
            }
            catch (Exception e)
            {
                objList = null;
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetRegistratedUsers");
            }
            return objList;

        }


        public ResponseData InsertArchitectureDetail(ArchiMstDetail obj)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[12];
                param[0] = new SqlParameter("@ipk_ArchiMstDetId", obj.ipk_ArchiMstDetId);
                param[1] = new SqlParameter("@iParamId ", obj.iParamId);
                param[2] = new SqlParameter("@iSubCatId", obj.iSubCatId);
                param[3] = new SqlParameter("@iUomId", obj.iUomId);
                param[4] = new SqlParameter("@iWid", obj.iWid);
                param[5] = new SqlParameter("@iLen", obj.iLen);
                param[6] = new SqlParameter("@iQty", obj.iQty);
                param[7] = new SqlParameter("@sAppId", obj.sAppId);
                param[8] = new SqlParameter("@bAttachFile", obj.bAttachFile);
                param[9] = new SqlParameter("@sProfileExtension", obj.sProfileExtension);
                param[10] = new SqlParameter("@sProfileContentType", obj.ProfileContentType);
                param[11] = new SqlParameter("@Type", "Insert");
                DataTable DT = BaseFunction.FillDataTable("[dbo].[USp_Admin_InsertArchiMstDetail]", param);
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
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : UpdatePartyMaster");
            }
            return objResponseData;
        }

        public List<ArchiMstDetail> GenerateArchtable(int iParamId, int iSubCatId, int iUomId, string sAppId)
        {
            List<ArchiMstDetail> objList = new List<ArchiMstDetail>();
            try
            {
                DataSet ds = new DataSet();

                SqlParameter[] param = new SqlParameter[5];
                param[0] = new SqlParameter("@iParamId", iParamId);
                param[1] = new SqlParameter("@iSubCatId", iSubCatId);
                param[2] = new SqlParameter("@iUomId", iUomId);
                param[3] = new SqlParameter("@sAppId", sAppId);
                param[4] = new SqlParameter("@Type", "Select");
                ds = BaseFunction.FillDataSet("[dbo].[USp_Admin_InsertArchiMstDetail]", param);

                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    objList = new List<ArchiMstDetail>();

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {

                        ArchiMstDetail obj = new ArchiMstDetail();
                        obj.ipk_ArchiMstDetId = ds.Tables[0].Rows[i]["ipk_ArchiMstDetId"].NulllToInt();
                        obj.iParamId = ds.Tables[0].Rows[i]["iParamId"].NulllToInt();
                        obj.iSubCatId = ds.Tables[0].Rows[i]["iSubCatId"].NulllToInt();
                        obj.iUomId = ds.Tables[0].Rows[i]["iUomId"].NulllToInt();
                        obj.iWid = ds.Tables[0].Rows[i]["iWid"].NulllToInt();
                        obj.iLen = ds.Tables[0].Rows[i]["iLen"].NulllToInt();
                        obj.iQty = ds.Tables[0].Rows[i]["iQty"].NulllToInt();
                        obj.sAppId = ds.Tables[0].Rows[i]["sAppId"].NulllToString();
                        obj.bAttachFile = ds.Tables[0].Rows[i]["Attachfile"].NulllToString();
                        obj.sProfileExtension = ds.Tables[0].Rows[i]["sProfileExtension"].NulllToString();
                        obj.ProfileContentType = ds.Tables[0].Rows[i]["sProfileContentType"].NulllToString();
                        objList.Add(obj);

                    }

                }
                else
                {
                    objList = null;
                }
            }
            catch (Exception e)
            {
                objList = null;
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetRegistratedUsers");
            }
            return objList;

        }
        public List<ArchiMstDetail> AllGenerateArchtable(string sAppId)
        {
            List<ArchiMstDetail> objList = new List<ArchiMstDetail>();
            try
            {
                DataSet ds = new DataSet();

                SqlParameter[] param = new SqlParameter[2];

                param[0] = new SqlParameter("@sAppId", sAppId);
                param[1] = new SqlParameter("@Type", "Select");
                ds = BaseFunction.FillDataSet("[dbo].[USp_Admin_InsertArchiMstDetail]", param);

                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    objList = new List<ArchiMstDetail>();

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {

                        ArchiMstDetail obj = new ArchiMstDetail();
                        obj.ipk_ArchiMstDetId = ds.Tables[0].Rows[i]["ipk_ArchiMstDetId"].NulllToInt();
                        obj.iParamId = ds.Tables[0].Rows[i]["iParamId"].NulllToInt();
                        obj.iSubCatId = ds.Tables[0].Rows[i]["iSubCatId"].NulllToInt();
                        obj.iUomId = ds.Tables[0].Rows[i]["iUomId"].NulllToInt();
                        obj.iWid = ds.Tables[0].Rows[i]["iWid"].NulllToInt();
                        obj.iLen = ds.Tables[0].Rows[i]["iLen"].NulllToInt();
                        obj.iQty = ds.Tables[0].Rows[i]["iQty"].NulllToInt();
                        obj.sAppId = ds.Tables[0].Rows[i]["sAppId"].NulllToString();
                        obj.bAttachFile = ds.Tables[0].Rows[i]["Attachfile"].NulllToString();
                        obj.sProfileExtension = ds.Tables[0].Rows[i]["sProfileExtension"].NulllToString();
                        obj.ProfileContentType = ds.Tables[0].Rows[i]["sProfileContentType"].NulllToString();
                        objList.Add(obj);

                    }

                }
                else
                {
                    objList = null;
                }
            }
            catch (Exception e)
            {
                objList = null;
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetRegistratedUsers");
            }
            return objList;

        }

        public List<ArchiMstDetail> BuildalltabelArchitecture(string sAppId)
        {

            List<ArchiMstDetail> objList = new List<ArchiMstDetail>();
            try
            {
                DataSet ds = new DataSet();

                SqlParameter[] param = new SqlParameter[2];

                param[0] = new SqlParameter("@sAppId", sAppId);
                param[1] = new SqlParameter("@Type", "AllSelect");
                ds = BaseFunction.FillDataSet("[dbo].[USp_Admin_InsertArchiMstDetail]", param);

                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    objList = new List<ArchiMstDetail>();

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {

                        ArchiMstDetail obj = new ArchiMstDetail();
                        obj.iParamId = ds.Tables[0].Rows[i]["iParamId"].NulllToInt();
                        obj.iSubCatId = ds.Tables[0].Rows[i]["iSubCatId"].NulllToInt();
                        obj.iUomId = ds.Tables[0].Rows[i]["iUomId"].NulllToInt();
                        objList.Add(obj);

                    }

                }
                else
                {
                    objList = null;
                }
            }
            catch (Exception e)
            {
                objList = null;
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetRegistratedUsers");
            }
            return objList;


        }

        public ResponseData DeleteArchiMstDet(int Id)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@ipk_ArchiMstDetId", Id);

                param[1] = new SqlParameter("@Type", "Delete");
                DataTable DT = BaseFunction.FillDataTable("[dbo].[USp_Admin_InsertArchiMstDetail]", param);
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
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : UpdatePartyMaster");
            }
            return objResponseData;
        }

        public ResponseData InsertArchitectureMst(ArchitectureMst Mst)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[5];
                param[0] = new SqlParameter("@iFK_AppId", Mst.iFK_AppId);

                param[1] = new SqlParameter("@iParamId", Mst.iParamId);
                param[2] = new SqlParameter("@iSubCatId", Mst.iSubCatId);

                param[3] = new SqlParameter("@iUom", Mst.iUom);
                param[4] = new SqlParameter("@Value", Mst.Value);
                DataTable DT = BaseFunction.FillDataTable("[dbo].[USp_Admin_InsertArchiMst]", param);
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
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : UpdatePartyMaster");
            }
            return objResponseData;
        }

        public ResponseData InsertArchupload(ArchUpload Mst)
        {
            //Usp_Admin_InsertArchupload
            try
            {
                SqlParameter[] param = new SqlParameter[6];
                param[0] = new SqlParameter("@UploadUrl", Mst.UploadUrl);

                param[1] = new SqlParameter("@iParamId", Mst.iParamId);
                param[2] = new SqlParameter("@iSubCatId", Mst.iSubCatId);

                param[3] = new SqlParameter("@iUomId", Mst.iUomId);
                param[4] = new SqlParameter("@sFK_AppId", Mst.sFK_AppId);
                param[5] = new SqlParameter("@Type", Mst.Type);
                DataTable DT = BaseFunction.FillDataTable("[dbo].[Usp_Admin_InsertArchupload]", param);
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
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : UpdatePartyMaster");
            }
            return objResponseData;

        }

        public ResponseData UploadReceipt(UploadReceipt receipt)
        {
            //Usp_Admin_InsertArchupload
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@sApplGUID", receipt.AppGUID);
                param[1] = new SqlParameter("@UploadReceipt", receipt.UploadReceiptDocument);
                param[2] = new SqlParameter("@UploadReceiptExtension", receipt.UploadReceiptDocumentExtension);
                param[3] = new SqlParameter("@UploadReceiptContentType", receipt.UploadReceiptDocumentContent);

                DataTable DT = BaseFunction.FillDataTable("[dbo].[USP_ADMIN_UploadRecipt_Save]", param);
                if (DT != null)
                {
                    if (DT.Rows.Count > 0)
                    {
                        objResponseData.statusCode = Convert.ToInt32(DT.Rows[0]["Flag"]);
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
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : UpdatePartyMaster");
            }
            return objResponseData;

        }

        public ResponseData GetFinYearList()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@Type", "Select");
                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_ADMIN_FinYear_SaveView]", param);

                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    objResponseData.statusCode = 1;
                    objResponseData.ResponseCode = "0";
                    objResponseData.Message = "Data Fetched Successfully...";
                    objResponseData.Data = ds.Tables[0];
                }
                else
                {
                    objResponseData.statusCode = 1;
                    objResponseData.ResponseCode = "0";
                    objResponseData.Message = "No Data Available...";
                }
            }
            catch (Exception e)
            {
                objResponseData.statusCode = 0;
                objResponseData.ResponseCode = "0";
                objResponseData.Message = e.Message;

                //ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetCustomEnum");
            }
            return objResponseData;
        }

        public ResponseData InsertFinYear(FinYear obj)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[5];
                param[0] = new SqlParameter("@iPk_Id", obj.iPk_Id);
                param[1] = new SqlParameter("@Name", obj.sName);
                param[2] = new SqlParameter("@dtStrdate", obj.dtInsertStrDt);
                param[3] = new SqlParameter("@dtEnddate", obj.dtInsertEndDt);
                param[4] = new SqlParameter("@iStts", 1);

                DataTable DT = BaseFunction.FillDataTable("[dbo].[USP_ADMIN_FinYear_SaveView]", param);
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
                objResponseData.ResponseCode = "0";
                objResponseData.Message = e.Message;

                //ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetCustomEnum");
            }
            return objResponseData;
        }

        #endregion

        public ResponseData InsertEvent(EventMstSave Obj)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@Id", Obj.Id);
                param[1] = new SqlParameter("@sNewGuid", Obj.sNewGuid);
                param[2] = new SqlParameter("@dtFormdate", Obj.dtFormdate);
                param[3] = new SqlParameter("@dtTodate", Obj.dtTodate);
                DataTable DT = BaseFunction.FillDataTable("[dbo].[Usp_Admin_InsertEvent]", param);
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
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : UpdatePartyMaster");
            }
            return objResponseData;
        }

        public List<EVNTMST> Event_View(int iFk_DeptId)
        {
            List<EVNTMST> objList = new List<EVNTMST>();
            try
            {
                DataSet ds = new DataSet();

                SqlParameter[] param = new SqlParameter[1];

                param[0] = new SqlParameter("@iFk_DeptId", iFk_DeptId);

                ds = BaseFunction.FillDataSet("[dbo].[Usp_Admin_Event_View]", param);

                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    objList = new List<EVNTMST>();

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {

                        EVNTMST obj = new EVNTMST();
                        obj.iPk_EventId = ds.Tables[0].Rows[i]["iPk_EventId"].NulllToInt();
                        obj.iMode = ds.Tables[0].Rows[i]["iMode"].NulllToInt();
                        obj.dtFormdate = ds.Tables[0].Rows[i]["Fromdate"].NulllToString();
                        obj.dtTodate = ds.Tables[0].Rows[i]["Todate"].NulllToString();
                        obj.iStts = ds.Tables[0].Rows[i]["iStts"].NulllToInt();
                        obj.sNewGuid = ds.Tables[0].Rows[i]["sNewGuid"].NulllToString();
                        obj.NocDepartmentName = ds.Tables[0].Rows[i]["NocDepartmentName"].NulllToString();
                        obj.NocDepartmenttype = ds.Tables[0].Rows[i]["NocDepartmenttype"].NulllToString();
                        obj.DepartName = ds.Tables[0].Rows[i]["DepartName"].NulllToString();
                        objList.Add(obj);

                    }

                }
                else
                {
                    objList = null;
                }
            }
            catch (Exception e)
            {
                objList = null;
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetRegistratedUsers");
            }
            return objList;

        }

        public List<Dropdown> FillDropDown(int Id, string Type, string PartyId)
        {
            List<Dropdown> objList = new List<Dropdown>();
            try
            {
                DataSet ds = new DataSet();

                SqlParameter[] param = new SqlParameter[3];

                param[0] = new SqlParameter("@Id", Id);
                param[1] = new SqlParameter("@Type", Type);
                param[2] = new SqlParameter("@PartyId", PartyId);

                ds = BaseFunction.FillDataSet("[dbo].[Usp_Admin_DropDown_Fill]", param);

                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    objList = new List<Dropdown>();

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {

                        Dropdown obj = new Dropdown();
                        obj.Id = ds.Tables[0].Rows[i]["Id"].NulllToString();
                        obj.Text = ds.Tables[0].Rows[i]["text"].NulllToString();
                        obj.ID1 = ds.Tables[0].Rows[i]["sTehsil"].NulllToString();


                        objList.Add(obj);

                    }

                }
                else
                {
                    objList = null;
                }
            }
            catch (Exception e)
            {
                objList = null;
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetRegistratedUsers");
            }
            return objList;

        }

        public ResponseData InsertCommiteeMster(CommiteeMaster Mst)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[9];
                param[0] = new SqlParameter("@iPk_CommiteeId", Mst.iPk_CommiteeId);
                param[1] = new SqlParameter("@iComtTypid", Mst.iComtTypid);
                param[2] = new SqlParameter("@sComtMemLst", Mst.sComtMemLst);
                param[3] = new SqlParameter("@iDeptId", Mst.iDeptId);
                param[4] = new SqlParameter("@sComtNam", Mst.sComtNam);
                param[5] = new SqlParameter("@sSubj", Mst.sSubj);
                param[6] = new SqlParameter("@filedata", Mst.filedata);
                param[7] = new SqlParameter("@distID", Mst.distID);
                param[8] = new SqlParameter("@tehID", Mst.tehID);
                DataTable DT = BaseFunction.FillDataTable("[dbo].[Usp_Admin_InsertCommiteeId]", param);
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
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : UpdatePartyMaster");
            }
            return objResponseData;
        }
        public List<CommiteeMaster> GetCommiteeList(int Id)
        {
            List<CommiteeMaster> objList = new List<CommiteeMaster>();
            try
            {
                DataSet ds = new DataSet();

                SqlParameter[] param = new SqlParameter[1];

                param[0] = new SqlParameter("@iDeptId", Id);


                ds = BaseFunction.FillDataSet("[dbo].[Usp_Commitee_Show_List]", param);

                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    objList = new List<CommiteeMaster>();

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {

                        CommiteeMaster obj = new CommiteeMaster();
                        obj.iPk_CommiteeId = ds.Tables[0].Rows[i]["iPk_CommiteeId"].NulllToInt();
                        obj.iComtTypid = ds.Tables[0].Rows[i]["iComtTypid"].NulllToInt();
                        obj.sComtMemLst = ds.Tables[0].Rows[i]["sComtMemLst"].NulllToString();
                        obj.iStts = ds.Tables[0].Rows[i]["iStts"].NulllToInt();
                        obj.sComtNam = ds.Tables[0].Rows[i]["sComtNam"].NulllToString();
                        obj.CommiteeMember = ds.Tables[0].Rows[i]["CommiteeMember"].NulllToString();
                        obj.sSubj = ds.Tables[0].Rows[i]["sSubj"].NulllToString();
                        obj.filedata = ds.Tables[0].Rows[i]["sUplimg"].NulllToString();
                        obj.iDeptId = ds.Tables[0].Rows[i]["iDeptId"].NulllToInt();
                        obj.distID = ds.Tables[0].Rows[i]["iDistID"].NulllToInt();
                        obj.tehID = (ds.Tables[0].Rows[i]["iTehID"].ToString() == "") ? 0 : Convert.ToInt32(ds.Tables[0].Rows[i]["iTehID"]);
                        objList.Add(obj);
                    }

                }
                else
                {
                    objList = null;
                }
            }
            catch (Exception e)
            {
                objList = null;
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetRegistratedUsers");
            }
            return objList;

        }

        public List<CommitedMstview> GetCommentTable(InspectionComments Mst)
        {
            List<CommitedMstview> objList = new List<CommitedMstview>();
            try
            {
                DataSet ds = new DataSet();

                SqlParameter[] param = new SqlParameter[4];

                param[0] = new SqlParameter("@sPageName", Mst.sPageName);
                param[1] = new SqlParameter("@iFK_FieldId", Mst.iFK_FieldId);
                param[2] = new SqlParameter("@sAppid", Mst.sAppid);
                param[3] = new SqlParameter("@Type", Mst.type);
                ds = BaseFunction.FillDataSet("[dbo].[Usp_Admin_ShowComment]", param);

                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    objList = new List<CommitedMstview>();

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {

                        CommitedMstview obj = new CommitedMstview();
                        obj.iComtId = ds.Tables[0].Rows[i]["iComtId"].NulllToInt();
                        obj.sName = ds.Tables[0].Rows[i]["sName"].NulllToString();
                        obj.sDiscription = ds.Tables[0].Rows[i]["sDiscription"].NulllToString();
                        obj.iVal = ds.Tables[0].Rows[i]["iVal"].NulllToInt();
                        obj.iCnt = ds.Tables[0].Rows[i]["iCnt"].NulllToInt();
                        obj.sUpdimg = ds.Tables[0].Rows[i]["sUpdimg"].NulllToString();
                        obj.sUsrId = ds.Tables[0].Rows[i]["sUsrId"].NulllToString();
                        obj.CtDate = ds.Tables[0].Rows[i]["dtCtrdate"].NulllToString();
                        obj.iFK_FieldId = ds.Tables[0].Rows[i]["iFK_FieldId"].NulllToInt();
                        obj.Remarklist = ds.Tables[0].Rows[i]["Remarklist"].NulllToString();
                        objList.Add(obj);

                    }

                }
                else
                {
                    objList = null;
                }
            }
            catch (Exception e)
            {
                objList = null;
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetRegistratedUsers");
            }
            return objList;
        }

        public ResponseData SaveComment(InspectionComments Obj)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[8];
                param[0] = new SqlParameter("@iFK_FieldId", Obj.iFK_FieldId);
                param[1] = new SqlParameter("@sAppid", Obj.sAppid);
                param[2] = new SqlParameter("@sDiscription", Obj.sDiscription);
                param[3] = new SqlParameter("@iVal", Obj.iVal);
                param[4] = new SqlParameter("@sUpdimg", Obj.sUpdimg);
                param[5] = new SqlParameter("@sPageName", Obj.sPageName);
                param[6] = new SqlParameter("@sUsrId", Obj.sUsrId);
                param[7] = new SqlParameter("@iComtId", Obj.iComtId);
                //param[8] = new SqlParameter("@Type", Obj.Type);
                DataTable DT = BaseFunction.FillDataTable("[dbo].[Usp_Admin_InsertComment]", param);
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
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : UpdatePartyMaster");
            }
            return objResponseData;
        }
        public List<Dropdown> GetApplicationData(int Deptid, int ApplicationId, int NOCDeptId)
        {
            List<Dropdown> objList = new List<Dropdown>();
            try
            {
                DataSet ds = new DataSet();
                if (NOCDeptId != 0)
                {
                    SqlParameter[] param = new SqlParameter[3];

                    param[0] = new SqlParameter("@Departid", Deptid);
                    param[1] = new SqlParameter("@ApplicationId", ApplicationId);
                    param[2] = new SqlParameter("@NOCDeptId", NOCDeptId);
                    ds = BaseFunction.FillDataSet("[dbo].[Usp_Mst_Fee_DepartApplication_Data]", param);
                }
                else
                {
                    SqlParameter[] param = new SqlParameter[2];

                    param[0] = new SqlParameter("@Departid", Deptid);
                    param[1] = new SqlParameter("@ApplicationId", ApplicationId);
                    ds = BaseFunction.FillDataSet("[dbo].[Usp_Mst_Fee_DepartApplication_Data]", param);
                }



                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    objList = new List<Dropdown>();

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {

                        Dropdown obj = new Dropdown();
                        obj.Id = ds.Tables[0].Rows[i]["Id"].NulllToString();
                        obj.Text = ds.Tables[0].Rows[i]["text"].NulllToString();
                        obj.ID1 = ds.Tables[0].Rows[i]["Type"].NulllToString();

                        objList.Add(obj);

                    }

                }
                else
                {
                    objList = null;
                }
            }
            catch (Exception e)
            {
                objList = null;
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetRegistratedUsers");
            }
            return objList;

        }
        public ResponseData InsertFee(CompleteFeeMaster Mst)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[20];
                param[0] = new SqlParameter("@iPK_ID", Mst.feeMst.iPK_ID);
                param[1] = new SqlParameter("@dtStartdate1", Mst.feeMst.dtStartdate1);
                param[2] = new SqlParameter("@dtEnddate1", Mst.feeMst.dtEnddate1);
                param[3] = new SqlParameter("@dtStartdate2", Mst.feeMst.dtStartdate2);
                param[4] = new SqlParameter("@dtEnddate2", Mst.feeMst.dtEnddate2);
                param[5] = new SqlParameter("@dtStartdate3", Mst.feeMst.dtStartdate3);
                param[6] = new SqlParameter("@dtEnddate3", Mst.feeMst.dtEnddate3);
                param[7] = new SqlParameter("@dtExtendDate", Mst.feeMst.dtExtendDate);
                param[8] = new SqlParameter("@dtSubmitDate", Mst.feeMst.dtSubmitDate);
                param[9] = new SqlParameter("@DeptID", Mst.feeMst.DeptID);
                param[10] = new SqlParameter("@NOCApplID", Mst.feeMst.NOCApplID);
                param[11] = new SqlParameter("@iFyID", Mst.feeMst.iFyID);
                param[12] = new SqlParameter("@dCoEdu_BR", Mst.feeMst.dCoEdu_BR);
                param[13] = new SqlParameter("@dGirls", Mst.feeMst.dGirls);
                param[14] = new SqlParameter("@dCoEdu", Mst.feeMst.dCoEdu);
                param[15] = new SqlParameter("@dGirls_BR ", Mst.feeMst.dGirls_BR);
                param[16] = new SqlParameter("@dUGFee", Mst.feeMst.dUGFee);
                param[17] = new SqlParameter("@dPGFee", Mst.feeMst.dPGFee);
                param[18] = new SqlParameter("@dLateFee", Mst.feeMst.dLateFee);
                param[19] = new SqlParameter("@dAddiLateFee", Mst.feeMst.dAddiLateFee);
                //param[20] = new SqlParameter("@FeeTrnData", Mst.feeTrn);
                DataTable DT = BaseFunction.FillDataTable("[dbo].[Usp_Admin_InsertFeeMst]", param);
                if (DT != null)
                {
                    if (DT.Rows.Count > 0)
                    {
                        objResponseData.statusCode = Convert.ToInt32(DT.Rows[0]["Id"]);
                        SqlParameter[] param2 = new SqlParameter[1];
                        param2[0] = new SqlParameter("@iFk_FeeMstId", objResponseData.statusCode);
                        DataTable DT2 = BaseFunction.FillDataTable("[dbo].[Usp_Admin_DeleteFeeTRN]", param2);
                        //objResponseData.Message = DT.Rows[0]["Message"].ToString();
                        foreach (var item in Mst.feeTrn)
                        {
                            SqlParameter[] param1 = new SqlParameter[10];

                            param1[0] = new SqlParameter("@iPK_id", '0');
                            param1[1] = new SqlParameter("@iFk_DeptID", item.iFk_DeptID);
                            param1[2] = new SqlParameter("@iFK_AppTypID", item.iFK_AppTypID);
                            param1[3] = new SqlParameter("@iFK_FrmID", item.iFK_FrmID);
                            param1[4] = new SqlParameter("@iFk_FyID", '1');
                            param1[5] = new SqlParameter("@dCharges", item.dCharges);
                            param1[6] = new SqlParameter("@iFk_FeeMstId", objResponseData.statusCode);
                            param1[7] = new SqlParameter("@sGuidid", item.sGuidid);
                            param1[8] = new SqlParameter("@iCaseId", item.CaseId);
                            param1[9] = new SqlParameter("@itype", item.type);

                            DataTable DT1 = BaseFunction.FillDataTable("[dbo].[Usp_Admin_InsertFeeTRN]", param1);
                        }
                        objResponseData.statusCode = 1;
                        objResponseData.Message = "Record Save SuccessFully|";

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
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : UpdatePartyMaster");
            }
            return objResponseData;
        }

        public ResponseData AddTrackingData(TrackingData track)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@sApplNo", track.sApplNo);
                param[1] = new SqlParameter("@sNrtn", track.sNrtn);
                param[2] = new SqlParameter("@sAction", track.sAction);

                DataTable DT = BaseFunction.FillDataTable("[dbo].[USP_OPERATION_AddApplicationTracking_Insert]", param);
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
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : AddTrackingData");
            }
            return objResponseData;
        }

        //Added For Saving the Darft application by Vivek 10.02.2023
        public ResponseData AddDeptMSTAppData(List<TrusteeBO.DeptMasterApp> deptMasters)
        {
            try
            {
                var newGUID = Guid.NewGuid();
                foreach (var item in deptMasters)
                {

                    SqlParameter[] param = new SqlParameter[10];
                    param[0] = new SqlParameter("@iFKCLG_ID", item.CollegeID);
                    param[1] = new SqlParameter("@iFKDEPT_ID", item.deptID);
                    param[2] = new SqlParameter("@iFK_CORS_ID", item.CourseID);
                    param[3] = new SqlParameter("@iFK_Subj_ID", item.SubjectID);
                    param[4] = new SqlParameter("@sClgName", item.college);
                    param[5] = new SqlParameter("@sDeptName", item.deptName);
                    param[6] = new SqlParameter("@sCorsName", item.Course);
                    param[7] = new SqlParameter("@sSubjName", item.Subject);
                    param[8] = new SqlParameter("@sGuid", newGUID);
                    param[9] = new SqlParameter("@iFk_FormTypId", item.appType);

                    DataTable DT = BaseFunction.FillDataTable("[dbo].[USP_MASTER_AddDeptApplicationData_Insert]", param);
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
            }
            catch (Exception e)
            {
                objResponseData.statusCode = 0;
                objResponseData.Message = "Failed";
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : AddTrackingData");
            }
            return objResponseData;
        }

        public ResponseData AddDeptMSTAppDataNewCollege(int clgID, string clgName, string appType)
        {
            try
            {
                var newGUID = Guid.NewGuid();
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@iFKCLG_ID", clgID);
                param[1] = new SqlParameter("@sGUID", newGUID);
                param[2] = new SqlParameter("@sClgName", clgName);
                param[3] = new SqlParameter("@appType", appType);

                DataTable DT = BaseFunction.FillDataTable("[dbo].[USP_MASTER_AddDeptApplicationDataForNewCollege_Insert]", param);
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
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : AddTrackingData");
            }
            return objResponseData;
        }
        //public List<Dropdown> GetApplicationCourse(string sGuid, int Courseid)
        //{
        //    List<Dropdown> objList = new List<Dropdown>();
        //    try
        //    {
        //        DataSet ds = new DataSet();

        //        SqlParameter[] param = new SqlParameter[2];

        //        param[0] = new SqlParameter("@sGuid", sGuid);
        //        param[1] = new SqlParameter("@Courseid", Courseid);


        //        ds = BaseFunction.FillDataSet("[dbo].[Usp_Admin_GetCourseandSubject]", param);

        //        if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
        //        {
        //            objList = new List<Dropdown>();

        //            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //            {

        //                Dropdown obj = new Dropdown();
        //                obj.Id = ds.Tables[0].Rows[i]["Id"].NulllToString();
        //                obj.Text = ds.Tables[0].Rows[i]["text"].NulllToString();


        //                objList.Add(obj);

        //            }

        //        }
        //        else
        //        {
        //            objList = null;
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        objList = null;
        //        ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : Usp_Admin_GetCourseandSubject");
        //    }
        //    return objList;

        //}

        public ResponseData GetNewCollegeDetails(int clgID)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@iPk_ClgID", clgID);

                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_ADMIN_GetCollegeDetails_Select]", param);
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    NewCollegeDetails newCollege = new NewCollegeDetails();
                    List<CollegeCourseSubject> courseSubjects = new List<CollegeCourseSubject>();

                    newCollege.sNameOfClg = ds.Tables[0].Rows[0]["sNameOfClg"].ToString();
                    newCollege.clgAddress = ds.Tables[0].Rows[0]["clgAddress"].ToString();
                    newCollege.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                    newCollege.Mobile = ds.Tables[0].Rows[0]["Mobile"].ToString();
                    newCollege.iClgTyp = ds.Tables[0].Rows[0]["iClgTyp"].ToString();
                    newCollege.collegeType = ds.Tables[0].Rows[0]["collegeType"].ToString();
                    newCollege.DistrictID = ds.Tables[0].Rows[0]["DistrictID"].NulllToInt();
                    newCollege.District = ds.Tables[0].Rows[0]["District"].ToString();
                    newCollege.Tehsil = ds.Tables[0].Rows[0]["Tehsil"].ToString();
                    newCollege.TehsilID = ds.Tables[0].Rows[0]["TehsilID"].NulllToInt();
                    newCollege.backwardArea = ds.Tables[0].Rows[0]["backwardArea"].ToString();
                    newCollege.totalFee = ds.Tables[0].Rows[0]["totalFee"].ToString();

                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        for (var i = 0; i <= ds.Tables[1].Rows.Count - 1; i++)
                        {
                            var CollegeCourseSubj = new CollegeCourseSubject
                            {
                                CourseName = ds.Tables[1].Rows[i]["CourseName"].ToString(),
                                subjectName = ds.Tables[1].Rows[i]["subjectName"].ToString(),
                            };

                            courseSubjects.Add(CollegeCourseSubj);
                        }
                    }

                    newCollege.courseSubjects = courseSubjects;

                    objResponseData.statusCode = 0;
                    objResponseData.Message = "College Details";
                    objResponseData.Data = newCollege;

                }
                else
                {
                    objResponseData.statusCode = 0;
                    objResponseData.Message = "No Data Available";
                }
            }
            catch (Exception e)
            {
                objResponseData.statusCode = 0;
                objResponseData.Message = "Failed";
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : AddTrackingData");
            }
            return objResponseData;
        }

        public List<CourserBind> GetApplicationCourse(string sGuid, int Courseid)
        {
            List<CourserBind> objList = new List<CourserBind>();
            try
            {
                DataSet ds = new DataSet();

                SqlParameter[] param = new SqlParameter[1];

                param[0] = new SqlParameter("@sGuid", sGuid);
                //param[1] = new SqlParameter("@Courseid", Courseid);


                ds = BaseFunction.FillDataSet("[dbo].[Usp_Architecture_Mapping]", param);

                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    objList = new List<CourserBind>();

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {

                        CourserBind obj = new CourserBind();
                        obj.Id = ds.Tables[0].Rows[i]["Id"].NulllToInt();
                        obj.text = ds.Tables[0].Rows[i]["text"].NulllToString();
                        obj.RoomNo = ds.Tables[0].Rows[i]["RoomNo"].NulllToInt();
                        obj.RoomNorequired = ds.Tables[0].Rows[i]["RoomNorequired"].NulllToInt();
                        obj.Roomlength = ds.Tables[0].Rows[i]["Roomlength"].NulllToInt();
                        obj.Roomwidth = ds.Tables[0].Rows[i]["Roomwidth"].NulllToInt();
                        obj.RoomCapacity = ds.Tables[0].Rows[i]["RoomCapacity"].NulllToInt();

                        objList.Add(obj);

                    }

                }
                else
                {
                    objList = null;
                }
            }
            catch (Exception e)
            {
                objList = null;
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : Usp_Admin_GetCourseandSubject");
            }
            return objList;

        }

        public List<CourserBind> GetOtherBind(string sGuid)
        {
            List<CourserBind> objList = new List<CourserBind>();
            try
            {
                DataSet ds = new DataSet();

                SqlParameter[] param = new SqlParameter[1];

                param[0] = new SqlParameter("@sGUID", sGuid);
                //param[1] = new SqlParameter("@Courseid", Courseid);


                ds = BaseFunction.FillDataSet("[dbo].[Usp_Admin_OtherMst_View]", param);

                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    objList = new List<CourserBind>();

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {

                        CourserBind obj = new CourserBind();
                        obj.Id = ds.Tables[0].Rows[i]["iNocCstId"].NulllToInt();
                        obj.text = ds.Tables[0].Rows[i]["sName"].NulllToString();
                        obj.RoomNo = ds.Tables[0].Rows[i]["RoomMin"].NulllToInt();

                        obj.Roomlength = ds.Tables[0].Rows[i]["RoomMinlength"].NulllToInt();
                        obj.Roomwidth = ds.Tables[0].Rows[i]["RoomMinWidth"].NulllToInt();


                        objList.Add(obj);

                    }

                }
                else
                {
                    objList = null;
                }
            }
            catch (Exception e)
            {
                objList = null;
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : Usp_Admin_GetCourseandSubject");
            }
            return objList;

        }


        public ResponseData UploadMasterPaymentReceipt(UploadMasterReceipt receipt)
        {
            //Usp_Admin_InsertArchupload
            try
            {
                SqlParameter[] param = new SqlParameter[5];
                param[0] = new SqlParameter("@sApplGUID", receipt.AppGUID);
                param[1] = new SqlParameter("@UploadReceipt", receipt.fullBase64Data);
                param[2] = new SqlParameter("@paidAMT", receipt.paidAMT);
                param[3] = new SqlParameter("@dueAMT", receipt.dueAMT);
                param[4] = new SqlParameter("@paidBy", receipt.paidBy);

                DataTable DT = BaseFunction.FillDataTable("[dbo].[USP_ADMIN_UploadMasterPaymentRecipt_Save]", param);
                if (DT != null)
                {
                    if (DT.Rows.Count > 0)
                    {
                        objResponseData.statusCode = Convert.ToInt32(DT.Rows[0]["Flag"]);
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
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : UpdatePartyMaster");
            }
            return objResponseData;

        }
        public List<FeeTRN> GetFeeTRNList(int Id)
        {
            List<FeeTRN> objList = new List<FeeTRN>();
            try
            {
                DataSet ds = new DataSet();

                SqlParameter[] param = new SqlParameter[1];

                param[0] = new SqlParameter("@Id ", Id);
                ds = BaseFunction.FillDataSet("[dbo].[USP_Admin_FeeTRN_MST]", param);

                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    objList = new List<FeeTRN>();

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {

                        FeeTRN obj = new FeeTRN();
                        obj.iFk_DeptID = ds.Tables[0].Rows[i]["iFk_DeptID"].NulllToInt();
                        obj.DepartmentName = ds.Tables[0].Rows[i]["DepartmentName"].NulllToString();
                        obj.ApplicationType = ds.Tables[0].Rows[i]["ApplicationType"].NulllToString();
                        obj.iFK_FrmID = ds.Tables[0].Rows[i]["iFK_FrmID"].NulllToInt();
                        obj.sGuidid = ds.Tables[0].Rows[i]["sGuidid"].NulllToString();
                        obj.FormName = ds.Tables[0].Rows[i]["FormName"].NulllToString();
                        obj.dCharges = ds.Tables[0].Rows[i]["dCharges"].NulllToDecimal();
                        obj.iFK_AppTypID = ds.Tables[0].Rows[i]["iFK_AppTypID"].NulllToInt();
                        obj.CaseId = ds.Tables[0].Rows[i]["CaseId"].NulllToInt();
                        obj.Casetext = ds.Tables[0].Rows[i]["Casetext"].NulllToString();
                        obj.type = ds.Tables[0].Rows[i]["type"].NulllToString();
                        objList.Add(obj);

                    }


                }
                else
                {
                    objList = null;
                }
            }
            catch (Exception e)
            {
                objList = null;
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetRegistratedUsers");
            }
            return objList;

        }
        public List<FeeMst> GetFeeMstList(int Id)
        {
            List<FeeMst> objList = new List<FeeMst>();
            try
            {
                DataSet ds = new DataSet();

                SqlParameter[] param = new SqlParameter[1];

                param[0] = new SqlParameter("@Id ", Id);




                ds = BaseFunction.FillDataSet("[dbo].[Usp_Admin_FeeMaster]", param);

                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    objList = new List<FeeMst>();
                    if (Id == 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {

                            FeeMst obj = new FeeMst();
                            obj.iPK_ID = ds.Tables[0].Rows[i]["iPK_ID"].NulllToInt();
                            obj.DepartmentName = ds.Tables[0].Rows[i]["DepartmentName"].NulllToString();
                            obj.ApplicationType = ds.Tables[0].Rows[i]["ApplicationType"].NulllToString();
                            obj.dtStartdate1 = ds.Tables[0].Rows[i]["dtStartdate1"].NulllToString();
                            obj.dtEnddate1 = ds.Tables[0].Rows[i]["dtEnddate1"].NulllToString();
                            obj.dtStartdate2 = ds.Tables[0].Rows[i]["dtStartdate2"].NulllToString();
                            obj.dtEnddate2 = ds.Tables[0].Rows[i]["dtEnddate2"].NulllToString();
                            obj.dtStartdate3 = ds.Tables[0].Rows[i]["dtStartdate3"].NulllToString();
                            obj.dtEnddate3 = ds.Tables[0].Rows[i]["dtEnddate1"].NulllToString();

                            obj.dCoEdu = ds.Tables[0].Rows[i]["dCoEdu"].NulllToDecimal();
                            obj.dCoEdu_BR = ds.Tables[0].Rows[i]["dCoEdu_BR"].NulllToDecimal();
                            obj.dGirls = ds.Tables[0].Rows[i]["dGirls"].NulllToDecimal();
                            obj.dGirls_BR = ds.Tables[0].Rows[i]["dGirls_BR"].NulllToDecimal();
                            obj.dUGFee = ds.Tables[0].Rows[i]["dUGFee"].NulllToDecimal();
                            obj.dPGFee = ds.Tables[0].Rows[i]["dPGFee"].NulllToDecimal();
                            obj.dLateFee = ds.Tables[0].Rows[i]["dLateFee"].NulllToDecimal();
                            obj.dAddiLateFee = ds.Tables[0].Rows[i]["dAddiLateFee"].NulllToDecimal();
                            obj.iStatus = ds.Tables[0].Rows[i]["Status"].NulllToInt();
                            objList.Add(obj);

                        }
                    }
                    else
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            FeeMst obj = new FeeMst();
                            obj.iPK_ID = ds.Tables[0].Rows[i]["iPK_ID"].NulllToInt();

                            obj.dtStartdate1 = ds.Tables[0].Rows[i]["dtStartdate1"].NulllToString();
                            obj.dtEnddate1 = ds.Tables[0].Rows[i]["dtEnddate1"].NulllToString();
                            obj.dtStartdate2 = ds.Tables[0].Rows[i]["dtStartdate2"].NulllToString();
                            obj.dtEnddate2 = ds.Tables[0].Rows[i]["dtEnddate2"].NulllToString();
                            obj.dtStartdate3 = ds.Tables[0].Rows[i]["dtStartdate3"].NulllToString();
                            obj.dtEnddate3 = ds.Tables[0].Rows[i]["dtEnddate3"].NulllToString();

                            obj.dCoEdu = ds.Tables[0].Rows[i]["dCoEdu"].NulllToDecimal();
                            obj.dCoEdu_BR = ds.Tables[0].Rows[i]["dCoEdu_BR"].NulllToDecimal();
                            obj.dGirls = ds.Tables[0].Rows[i]["dGirls"].NulllToDecimal();
                            obj.dGirls_BR = ds.Tables[0].Rows[i]["dGirls_BR"].NulllToDecimal();
                            obj.dUGFee = ds.Tables[0].Rows[i]["dUGFee"].NulllToDecimal();
                            obj.dPGFee = ds.Tables[0].Rows[i]["dPGFee"].NulllToDecimal();
                            obj.dLateFee = ds.Tables[0].Rows[i]["dLateFee"].NulllToDecimal();
                            obj.dAddiLateFee = ds.Tables[0].Rows[i]["dAddiLateFee"].NulllToDecimal();
                            obj.iStatus = ds.Tables[0].Rows[i]["iStts"].NulllToInt();

                            obj.DeptID = ds.Tables[0].Rows[i]["DeptID"].NulllToInt();
                            obj.NOCApplID = ds.Tables[0].Rows[i]["NOCApplID"].NulllToInt();

                            obj.iFyID = ds.Tables[0].Rows[i]["iFyID"].NulllToInt();
                            obj.NOCApplID = ds.Tables[0].Rows[i]["NOCApplID"].NulllToInt();

                            obj.dtExtendDate = ds.Tables[0].Rows[i]["dtExtendDate"].NulllToString();
                            obj.dtSubmitDate = ds.Tables[0].Rows[i]["dtSubmitDate"].NulllToString();

                            objList.Add(obj);
                        }
                    }
                }
                else
                {
                    objList = null;
                }
            }
            catch (Exception e)
            {
                objList = null;
                ExceptionLogDL.SendExcepToDB(e, 0, "Class : AdminDL / Function : GetRegistratedUsers");
            }
            return objList;

        }
    }
}
