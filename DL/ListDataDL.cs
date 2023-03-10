using BO.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DL
{
    public class ListDataDL
    {
        string connectionString = DBCS.GetConnectionString();
        public List<CustomList> GetCommonList(CustomListRequest req)
        {
            List<CustomList> objlist = new List<CustomList>();
            try
            {
                string queryString = "[dbo].[Enume_GetList]";
                using (SqlConnection connect = new SqlConnection())
                {
                    SqlCommand cmd = new SqlCommand(queryString, connect);
                    cmd.CommandType = CommandType.StoredProcedure;
                    connect.ConnectionString = connectionString;
                    cmd.Parameters.AddWithValue("@Type", req.Type);
                    cmd.Parameters.AddWithValue("@ConditionID", req.Id);
                    cmd.Parameters.AddWithValue("@ConditionStringID", req.StrId);
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
                        objlist = new List<CustomList>();

                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            CustomList objdoc = new CustomList();
                            objdoc.Id = ds.Tables[0].Rows[i]["Id"].NulllToInt();
                            objdoc.Name = ds.Tables[0].Rows[i]["text"].ToString();
                            objdoc.Type = ds.Tables[0].Rows[i]["Type"].NulllToString();
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
    }
}
