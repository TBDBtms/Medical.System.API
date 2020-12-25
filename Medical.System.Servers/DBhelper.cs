using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;

namespace Medical.System.Servers
{
    public static class DBhelper
    {
        static string str = "server=192.168.0.178;uid=sa;pwd=DLH1661392274;database=D_Clinic_System";
            public static List<T> GetList<T>(string sql)
            {
                using (SqlConnection conn = new SqlConnection(str))  //查询
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

            public static int CMD(string sql)  //增删改
            {
                using (SqlConnection conn = new SqlConnection(str))
                {
                    conn.Open();
                    SqlCommand com = new SqlCommand(sql, conn);
                    return com.ExecuteNonQuery();
                }
            }

            public static int CMD2(string sql)  //增删改返回数据主键
            {
                using (SqlConnection conn = new SqlConnection(str))
                {
                    conn.Open();
                    SqlCommand com = new SqlCommand(sql, conn);
                    return Convert.ToInt32(com.ExecuteScalar());
                }
            }
            /// <summary>
            /// 查看存储过程
            /// </summary>
            /// <param name="procname"></param>
            /// <param name="paras"></param>
            /// <returns></returns>
            public static List<T> GetDataTable_Proc<T>(string procname, SqlParameter[] paras = null)
            {
                using (SqlConnection conn = new SqlConnection(str))
                {

                    conn.Open();

                    //1.实例化SQL指令
                    SqlCommand command = new SqlCommand(procname, conn);
                    //2,设置SQL指令执行存储过程
                    command.CommandType = CommandType.StoredProcedure;
                    //3.判断存储过程参数
                    if (paras != null)
                    {
                        command.Parameters.AddRange(paras);
                    }

                    //4.实例化适配器
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    //5.实例化DT
                    var dt = new DataTable();
                    //6.填充数据   
                    adapter.Fill(dt);
                    //7.返回dt
                    string list = JsonConvert.SerializeObject(dt);
                    List<T> list1 = JsonConvert.DeserializeObject<List<T>>(list);
                    return list1;
                }
            }

            /// <summary>
            /// 增删改存储过程
            /// </summary>
            /// <param name="procname"></param>
            /// <param name="paras"></param>
            /// <returns></returns>
            public static int CMD_Proc(string procname, SqlParameter[] paras = null)
            {
                using (SqlConnection conn = new SqlConnection(str))
                {

                    conn.Open();

                    //1.实例化SQL指令
                    SqlCommand command = new SqlCommand(procname, conn);
                    //2,设置SQL指令执行存储过程
                    command.CommandType = CommandType.StoredProcedure;
                    //3.判断存储过程参数
                    if (paras != null)
                    {
                        command.Parameters.AddRange(paras);
                    }

                    //4.返回影响行数
                    return command.ExecuteNonQuery();
                }
            }
    }
}
