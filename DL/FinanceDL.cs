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
    public class FinanceDL
    {
        ResponseData objResponseData = new ResponseData();

        public ResponseData addFinanceDetails(FinanceModalSave financeModal)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] param;

                if (financeModal.financeCapitals.Count > 0)
                {
                    foreach (var item in financeModal.financeCapitals)
                    {
                        param = new SqlParameter[4];
                        param[0] = new SqlParameter("@type", "Capital");
                        //param[1] = new SqlParameter("@iFk_AplcnId", 0);
                        param[1] = new SqlParameter("@sFirmName", item.sFirstName.NulllToString());
                        param[2] = new SqlParameter("@dAproxWdth", item.dAproxWdth.NulllToDecimal());
                        param[3] = new SqlParameter("@sCapitalRemark", item.sRemark.NulllToString());
                        ds = BaseFunction.FillDataSet("[dbo].[USP_ADMIN_FinanceDetails_Save]", param);
                    }
                }

                if (financeModal.financeIncomes.Count > 0)
                {
                    foreach (var item in financeModal.financeIncomes)
                    {
                        param = new SqlParameter[5];
                        param[0] = new SqlParameter("@type", "Income");
                        //param[1] = new SqlParameter("@iFk_AplcnId", 0);
                        param[1] = new SqlParameter("@sIncomeName", item.sName.NulllToString());
                        param[2] = new SqlParameter("@dAproxIncome", item.dAproxIncome.NulllToDecimal());
                        param[3] = new SqlParameter("@sTimeFrame", item.sTimeFrame.NulllToInt());
                        param[4] = new SqlParameter("@iTyp", item.iTyp.NulllToInt());
                        ds = BaseFunction.FillDataSet("[dbo].[USP_ADMIN_FinanceDetails_Save]", param);
                    }
                }

                if (financeModal.financeProjects.Count > 0)
                {
                    foreach (var item in financeModal.financeProjects)
                    {
                        param = new SqlParameter[6];
                        param[0] = new SqlParameter("@type", "Project");
                        //param[1] = new SqlParameter("@iFk_AplcnId", 0);
                        param[1] = new SqlParameter("@sProjectName", item.sName.NulllToString());
                        param[2] = new SqlParameter("@dAproxFund", item.dAproxFund.NulllToDecimal());
                        param[3] = new SqlParameter("@sProjectRemark", item.sRemark.NulllToString());
                        param[4] = new SqlParameter("@isource", item.iTyp.NulllToInt());
                        param[5] = new SqlParameter("@dExovtPrjctCost", financeModal.ProjectExpectedCost.NulllToDecimal());
                        ds = BaseFunction.FillDataSet("[dbo].[USP_ADMIN_FinanceDetails_Save]", param);
                    }
                }

                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        objResponseData.Message = ds.Tables[0].Rows[0]["Message"].NulllToString();
                        objResponseData.ResponseCode = "0";
                        objResponseData.statusCode = 1;
                        return objResponseData;
                    }
                    else
                    {
                        objResponseData.Message = CustomMessage.NORECORDFOUND;
                        objResponseData.ResponseCode = CustomMessage.NORECORDFOUND_RESPONSECODE.ToString();
                        objResponseData.statusCode = 0;
                        return objResponseData;
                    }
                }
                else
                {
                    objResponseData.Message = CustomMessage.NORECORDFOUND;
                    objResponseData.ResponseCode = CustomMessage.NORECORDFOUND_RESPONSECODE.ToString();
                    objResponseData.statusCode = 0;
                    return objResponseData;
                }
            }
            catch (Exception ex)
            {
                //objResponseData.Message = BO.CustomMessage.EXCEPTIONOCCURRED;
                //objResponseData.ResponseCode = BO.CustomMessage.EXCEPTIONOCCURRED_RESPONSECODE.ToString();
                return objResponseData;
            }
        }


    }
}
