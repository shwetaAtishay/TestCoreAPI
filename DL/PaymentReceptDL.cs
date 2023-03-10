using BO.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DL
{
    public class PaymentReceptDL
    {
        ResponseData objResponseData = new ResponseData();
        //ErrorBO objResponseData = new ErrorBO();
        ErrorBO _Access = new ErrorBO();
        public static IConfiguration _configuration;
        string connectionString = DBCS.GetConnectionString();
        public ResponseData PayReceptDetails(ParticalPaymentBO obj)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] param = new SqlParameter[10];
                param[0] = new SqlParameter("@Type", "Insert");
                param[1] = new SqlParameter("@ChanalNo", obj.ChanalNo);
                param[2] = new SqlParameter("@BankName", obj.BankName);
                param[3] = new SqlParameter("@ApplicationFees", obj.ApplicationFees);
                param[4] = new SqlParameter("@BranchName", obj.BranchName);
                param[5] = new SqlParameter("@DepositeOn", obj.DepositeOn);
                param[6] = new SqlParameter("@PaymentDocument", obj.PaymentDocument);
                param[7] = new SqlParameter("@PaymentDocumentExtension", obj.PaymentDocumentExtension);
                param[8] = new SqlParameter("@PaymentDocumentContenttype", obj.PaymentDocumentContenttype);
                param[9] = new SqlParameter("@Remark", obj.Remark);

                ds = BaseFunction.FillDataSet("[dbo].[USP_ParticalpaymentDetails_Save]", param);
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        objResponseData.Message = ds.Tables[0].Rows[0]["Message"].NulllToString();
                        objResponseData.statusCode = ds.Tables[0].Rows[0]["statusCode"].NulllToInt();
                        return objResponseData;
                    }
                    else
                    {
                        objResponseData.Message = ds.Tables[0].Rows[0]["Message"].NulllToString();
                        objResponseData.statusCode = ds.Tables[0].Rows[0]["statusCode"].NulllToInt();
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
                throw ex;
            }


        }

        public List<ParticalPaymentBO> GetReceptDataList(string Type = "GetDetails")
        {
            //DataSet ds = new DataSet();
            ResponseData responseData = new ResponseData();
            List<ParticalPaymentBO> objlist = new List<ParticalPaymentBO>();

            try
            {

                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@Type", Type);
                //ds = BaseFunction.FillDataSet("[dbo].[USP_ParticalpaymentDetails_Save]", param);
                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_ParticalpaymentDetails_Save]", param);
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    objlist = new List<ParticalPaymentBO>();
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        ParticalPaymentBO objdoc = new ParticalPaymentBO();
                        objdoc.iPk_PymtID = Convert.ToInt32(ds.Tables[0].Rows[i]["iPk_PymtID"].NulllToInt());
                        objdoc.ChanalNo = ds.Tables[0].Rows[i]["sChanalNo"].NulllToString();
                        objdoc.BankName = ds.Tables[0].Rows[i]["sBankName"].NulllToString();
                        objdoc.ApplicationFees = ds.Tables[0].Rows[i]["sApplicationFees"].NulllToString();
                        objdoc.BranchName = ds.Tables[0].Rows[i]["sBranchName"].NulllToString();
                        objdoc.DepositeOn = ds.Tables[0].Rows[i]["sDepositeOn"].NulllToString();
                        objdoc.Remark = ds.Tables[0].Rows[i]["sRemark"].NulllToString();
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
        public List<OLDNOCBO> GetOLDNOCDataList()
        {
            //DataSet ds = new DataSet();
            //ResponseData responseData = new ResponseData();
            List<OLDNOCBO> objlist = new List<OLDNOCBO>();
            try
            {
                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_Report_ClgCourse_Subjectwise_Data]");
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    objlist = new List<OLDNOCBO>();
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        OLDNOCBO objdoc = new OLDNOCBO();
                        objdoc.sNameOfClg = ds.Tables[0].Rows[i]["sNameOfClg"].NulllToString();
                        objdoc.Numbers = ds.Tables[0].Rows[i]["Numbers"].NulllToString();
                        objlist.Add(objdoc);
                    }
                    for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                    {
                        OLDNOCBO objdoc = new OLDNOCBO();

                        objdoc.sNameOfClg = ds.Tables[1].Rows[i]["sNameOfClg"].NulllToString();
                        objdoc.CourseName = ds.Tables[1].Rows[i]["CourseName"].NulllToString();
                        objdoc.Numbers = ds.Tables[1].Rows[i]["Numbers"].NulllToString();
                        objlist.Add(objdoc);
                    }
                    for (int i = 0; i < ds.Tables[2].Rows.Count; i++)
                    {
                        OLDNOCBO objdoc = new OLDNOCBO();
                        //table2
                        objdoc.sNameOfClg = ds.Tables[2].Rows[i]["sNameOfClg"].NulllToString();
                        objdoc.CourseName = ds.Tables[2].Rows[i]["CourseName"].NulllToString();
                        objdoc.SubjectName = ds.Tables[2].Rows[i]["SubjectName"].NulllToString();
                        objdoc.Numbers = ds.Tables[2].Rows[i]["Numbers"].NulllToString();
                        objlist.Add(objdoc);
                    }
                    for (int i = 0; i < ds.Tables[3].Rows.Count; i++)
                    {
                        OLDNOCBO objdoc = new OLDNOCBO();
                        //table3
                        objdoc.sNameOfClg = ds.Tables[3].Rows[i]["sNameOfClg"].NulllToString();
                        objdoc.CourseName = ds.Tables[3].Rows[i]["CourseName"].NulllToString();
                        objdoc.SubjectName = ds.Tables[3].Rows[i]["SubjectName"].NulllToString();
                        objdoc.NOCType = ds.Tables[3].Rows[i]["NOCType"].NulllToString();
                        objdoc.sAttachFile = ds.Tables[3].Rows[i]["sAttachFile"].NulllToString();
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
