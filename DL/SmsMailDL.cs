using BO.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DL
{
    public class SmsMailDL
    {
        public SMSTemplates SendSMS_DocumentApproval(string templatekey)
        {
            
            SMSTemplates smsList = new SMSTemplates();
            try {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@SMSType", templatekey);
                DataSet ds = BaseFunction.FillDataSet("USP_ADMIN_GetSMSTemplate", param);
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            smsList.TemplateKey = dr["TemplateKey"].ToString();
                            smsList.SMSTemplate = dr["MessageTemplate"].ToString();
                            smsList.DLTTemplate = dr["DLTTemplate"].ToString();
                            smsList.Description = dr["Description"].ToString();
                            smsList.TemplateId = dr["TemplateId"].ToString();
                        }

                    }

                }
            }
            catch(Exception ex)
            {
                ExceptionLogDL.WriteExceptionDB(ex, "NA", "api", "SMSMailDL:SendSMS_DocumentApproval", "UNOCapi", "NA");
            }
            
            return smsList;
        }
    }
}
