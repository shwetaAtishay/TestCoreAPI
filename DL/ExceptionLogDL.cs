using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.IO;
using System.Reflection;

namespace DL
{
    public class ExceptionLogDL
    {
        public static string m_exePath = string.Empty;
        public static void LogWrite(string logMessage)
        {
            m_exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            try
            {
                using (StreamWriter w = File.AppendText(m_exePath + "\\" + "log.txt"))
                {
                    Log(logMessage, w);
                }
            }
            catch (Exception ex)
            {
            }
        }

        public static void Log(string logMessage, TextWriter txtWriter)
        {
            try
            {
                txtWriter.Write("\r\nLog Entry : ");
                txtWriter.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                    DateTime.Now.ToLongDateString());
                txtWriter.WriteLine("  :");
                txtWriter.WriteLine("  :{0}", logMessage);
                txtWriter.WriteLine("-------------------------------");
            }
            catch (Exception ex)
            {
            }
        }

        public static void SendExcepToDB(Exception exdb, long userID, string excepURLFunction, string connectionstring = null)
        {

            //DataSet ds = new DataSet();
            //using (SqlConnection conn = new SqlConnection())
            //{
            //    using (SqlCommand cmd = new SqlCommand())
            //    {
            //        excepURLFunction = "";
            //        conn.ConnectionString = "Server =.; Database = Zapures; Trusted_Connection = true;";
            //        cmd.Connection = null;
            //        cmd.CommandText = "[dbo].[USP_ERROR_API_ExceptionLog_Insert]";
            //        cmd.CommandType = CommandType.StoredProcedure;
            //        cmd.Parameters.AddWithValue("@UserID", userID);
            //        cmd.Parameters.AddWithValue("@ExceptionMsg", exdb.Message.ToString());
            //        cmd.Parameters.AddWithValue("@ExceptionURL", excepURLFunction);
            //        cmd.Parameters.AddWithValue("@ExceptionSource", exdb.GetType().Name.ToString() + " " + exdb.StackTrace.ToString());
            //        if (cmd.Connection.State != ConnectionState.Open)
            //        {
            //            cmd.Connection.Open();
            //        }
            //        SqlDataAdapter da = new SqlDataAdapter(cmd);
            //        da.Fill(ds);
            //    }
            //}
        }

        public static void WriteExceptionDB(Exception ex, string userID, string ExceptionFrom, string ExceptionUrl, string Application, string ControllerName)
        {
            SqlParameter[] param = new SqlParameter[7];
            param[0] = new SqlParameter("@Application", Application);
            param[1] = new SqlParameter("@ControllerName", ControllerName);
            param[2] = new SqlParameter("@ErrorCode", ex.GetType().Name.ToString());
            param[3] = new SqlParameter("@ExceptionMessage", ex.Message.ToString());
            param[4] = new SqlParameter("@ExceptionStackTrace", ex.StackTrace);
            param[5] = new SqlParameter("@ExceptionFrom", ExceptionFrom);
            param[6] = new SqlParameter("@ExceptionUrl", ExceptionUrl);
            int res = BaseFunction.ExecuteQuery("[dbo].[USP_ERROR_API_ExceptionLog_Insert]", param);
        }

    }
}
