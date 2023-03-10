using BO;
using BO.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Text;
using static System.Exception;

namespace DL
{
   public class TestDL
    {          
        public List<Testing> GetServicesDetail()
        {
            List<Testing> objCategormaster = new List<Testing>();
            try
            {
                            
                DataSet ds = BaseFunction.FillDataSet("[dbo].[ServiceDetail]");
                if (ds != null && ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                {
                    objCategormaster = new List<Testing>();

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        Testing objdoc = new Testing();
                        objdoc.CategoryId = ds.Tables[0].Rows[i]["CategoryId"].NulllToInt();                        
                        objdoc.CategoryName = ds.Tables[0].Rows[i]["CategoryName"].ToString();
                        objdoc.ChargeType = ds.Tables[0].Rows[i]["ChargeType"].ToString();
                        objdoc.Unitname = ds.Tables[0].Rows[i]["Unitname"].ToString();
                        objdoc.PaymentName = ds.Tables[0].Rows[i]["PaymentName"].ToString();
                        objdoc.ClassName = ds.Tables[0].Rows[i]["ClassName"].NulllToString();
                        objdoc.Amount = ds.Tables[0].Rows[i]["Amount"].NulllToString();
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
    }

}
