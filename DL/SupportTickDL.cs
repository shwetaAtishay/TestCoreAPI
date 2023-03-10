using BO.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Text;

namespace DL
{
    public class SupportTickDL
    {
        ResponseData objResponseData = new ResponseData();
        //ErrorBO objResponseData = new ErrorBO();
        public static IConfiguration _configuration;
        string connectionString = DBCS.GetConnectionString();

        public ResponseData SupportDetailSave(SupportIssue obj)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] param = new SqlParameter[9];
                param[0] = new SqlParameter("@Type", "Insert");
                param[1] = new SqlParameter("@Tickets", obj.Tickets);
                param[2] = new SqlParameter("@Subject", obj.Subject);
                param[3] = new SqlParameter("@MobileNumber", obj.MobileNumber);
                param[4] = new SqlParameter("@Email", obj.Email);
                param[5] = new SqlParameter("@Message", obj.Message);
                param[6] = new SqlParameter("@TicketFile", obj.TicketFile);
                param[7] = new SqlParameter("@TicketFileExtension", obj.TicketFileExtension);
                param[8] = new SqlParameter("@TicketFileContentType", obj.TicketFileContentType);
                ds = BaseFunction.FillDataSet("[dbo].[USP_MASTER_Supp_Ticket_Save]", param);
              
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        objResponseData.Message = ds.Tables[0].Rows[0]["Message"].NulllToString();
                        objResponseData.statusCode = ds.Tables[0].Rows[0]["Flag"].NulllToInt();
                        return objResponseData;
                    }
                    else
                    {
                        objResponseData.Message = ds.Tables[0].Rows[0]["Message"].NulllToString();
                        objResponseData.ResponseCode = ds.Tables[0].Rows[0]["Flag"].NulllToString();
                        return objResponseData;
                    }
                }
                else
                {
                    objResponseData.Message = BO.Models.CustomMessage.NORECORDFOUND;
                    objResponseData.ResponseCode = BO.Models.CustomMessage.NORECORDFOUND_RESPONSECODE.ToString();
                    return objResponseData;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<SupportIssue> GetSupportData()
        {
            List<SupportIssue> _result = new List<SupportIssue>();
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@Type", "SupportDetails");
                ds = BaseFunction.FillDataSet("[dbo].[USP_MASTER_Supp_Ticket_Save]", param);
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        objResponseData.Message = ds.Tables[1].Rows[0]["Message"].NulllToString();
                        objResponseData.ResponseCode = ds.Tables[1].Rows[0]["Flag"].NulllToString();

                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow DR in ds.Tables[0].Rows)
                            {
                                _result.Add(new SupportIssue
                                {
                                    Id = DR["iPK_IssueId"].NulllToInt(),
                                    TicketsName = DR["TicketName"].NulllToString(),
                                    Subject = DR["sSubject"].NulllToString(),
                                    Email = DR["sEmailId"].NulllToString(),
                                    MobileNumber = DR["sMobileNo"].NulllToString(),
                                    Message = DR["sMessage"].NulllToString(),
                                    TicketStatus = DR["Ticket_Status"].NulllToString(),
                                    dateCreate = DR["dtcreatDate"].NulllToString(),
                                    TicketFile = DR["File"].NulllToString(),
                                    TicketFileExtension = DR["sTicketFileContentType"].NulllToString(),
                                    TicketFileContentType = DR["sTicketFileContentType"].NulllToString(),
                                   
                                });
                            }
                        }

                        return _result;
                    }
                    else
                    {
                        objResponseData.Message = ds.Tables[0].Rows[0]["Message"].NulllToString();
                        objResponseData.ResponseCode = ds.Tables[0].Rows[0]["Flag"].NulllToString();
                        return _result;
                    }
                }
                else
                {
                    objResponseData.Message = CustomMessage.NORECORDFOUND;
                    objResponseData.ResponseCode = CustomMessage.NORECORDFOUND_RESPONSECODE.ToString();
                    return _result;
                }
            }
            catch (Exception ex)
            {
                objResponseData.Message = CustomMessage.EXCEPTIONOCCURRED;
                objResponseData.ResponseCode = CustomMessage.EXCEPTIONOCCURRED_RESPONSECODE.ToString();
                ExceptionLogDL.WriteExceptionDB(ex, "NA", "api", "TrusteeDL:TrustInfoList", "UNOCapi", "NA");
                return _result;
            }
        }

        public ResponseData TicketsList()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@Type", "SupportTicket");
                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_MASTER_Supp_Ticket_Save]", param);
                if (ds != null && ds.Tables != null)
                {
                    objResponseData.ResponseCode = "000";
                    objResponseData.Data = ds.Tables[0];
                    objResponseData.Message = "Support Ticket List...";
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

        public ResponseData RemoveDataTickets(int id)
        {
            ResponseData objlist = new ResponseData();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@Type", "SupportTicketDelete");
                param[1] = new SqlParameter("@Id", id);

                DataSet ds = BaseFunction.FillDataSet("[dbo].[USP_MASTER_Supp_Ticket_Save]", param);
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

        public SupportIssue GetTicketsImagesList(int Identity)
        {
            SupportIssue _result = new SupportIssue();
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@Type", "SupportTicketImagesList");
                param[1] = new SqlParameter("@Id", Identity);
                ds = BaseFunction.FillDataSet("[dbo].[USP_MASTER_Supp_Ticket_Save]", param);
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        objResponseData.Message = ds.Tables[1].Rows[0]["Message"].NulllToString();
                        objResponseData.ResponseCode = ds.Tables[1].Rows[0]["Flag"].NulllToString();

                        if (ds.Tables[0].Rows.Count > 0)
                        {

                            _result.TicketFile = ds.Tables[0].Rows[0]["File"].ToString();
                            _result.TicketFileExtension = ds.Tables[0].Rows[0]["sTicketFileExtension"].NulllToString();
                            _result.TicketFileContentType = ds.Tables[0].Rows[0]["sTicketFileContentType"].NulllToString();

                        }

                        return _result;
                    }
                    else
                    {
                        objResponseData.Message = ds.Tables[0].Rows[0]["Message"].NulllToString();
                        objResponseData.ResponseCode = ds.Tables[0].Rows[0]["Flag"].NulllToString();
                        return _result;
                    }
                }
                else
                {
                    objResponseData.Message = CustomMessage.NORECORDFOUND;
                    objResponseData.ResponseCode = CustomMessage.NORECORDFOUND_RESPONSECODE.ToString();
                    return _result;
                }
            }
            catch (Exception ex)
            {
                objResponseData.Message = CustomMessage.EXCEPTIONOCCURRED;
                objResponseData.ResponseCode = CustomMessage.EXCEPTIONOCCURRED_RESPONSECODE.ToString();
                ExceptionLogDL.WriteExceptionDB(ex, "NA", "api", "TrusteeDL:DocumentDetail", "UNOCapi", "NA");
                return _result;
            }
        }

    }
}
