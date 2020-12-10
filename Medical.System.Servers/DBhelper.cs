using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;

namespace Medical.System.Servers
{
  public  class DBhelper
    {
        static string str = "Data Source=192.168.0.178;Initial Catalog=D_Clinic_System;User ID=sa";
        public static List<T> GetList<T>(string sql)
        {
            using (SqlConnection conn = new SqlConnection(str))
            {
                conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                string list = JsonConvert.SerializeObject(dt);
                List<T> list1 = JsonConvert.DeserializeObject<List<T>>(list);
                return list1;
            }
        }

        public static int CMD(string sql)
        {
            using (SqlConnection conn = new SqlConnection(str))
            {
                conn.Open();
                SqlCommand com = new SqlCommand(sql, conn);
                return com.ExecuteNonQuery();
            }
        }
    }
}
