using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;


namespace SQLClassLibrary
{
    public class SQLHelper
    {
        //public static readonly string ConnectionStringLocalTransaction = ConfigurationManager.ConnectionStrings["sqlconnString"].ConnectionString;
        public static readonly string ConnectionStringLocalTransaction = ConfigurationManager.AppSettings["sqlconnString"];
        public static void ExecuteNonQuery()
        {
            using (SqlConnection sqlconn = new SqlConnection())
            {
                sqlconn.ConnectionString = ConnectionStringLocalTransaction;
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlconn;
                sqlcmd.CommandText = "select 1 from Student";
                sqlcmd.ExecuteNonQuery();
            }
        }

        public static object ExecuteScalar()
        {
            using (SqlConnection sqlconn = new SqlConnection())
            {
                sqlconn.ConnectionString = ConnectionStringLocalTransaction;
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlconn;
                sqlcmd.CommandText = "select Name from Student";
                return sqlcmd.ExecuteScalar();
            }
        }

        public void DoAppConfig()
        {
            Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            cfa.AppSettings.Settings["NAME"].Value = "WANGLICHAO";
            cfa.Save();  
        }

        public static object ExecuteReader()
        {
            using (SqlConnection sqlconn = new SqlConnection())
            {
                sqlconn.ConnectionString = ConnectionStringLocalTransaction;
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlconn;
                sqlcmd.CommandText = "select * from Student";
                SqlDataReader dr = sqlcmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                List<object> objList = new  List<object>();
                while (dr.Read())
                {
                    object id = dr[0];
                    object name = dr[1];
                    object age = dr[2];
                    object[] abc = {id,name,age};
                    objList.Add(abc);
                }
                return objList;
            }
        }


    }
}
