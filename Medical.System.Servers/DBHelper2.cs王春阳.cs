﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
//using System.Configuration;


namespace Medical.System.Servers
{
    public static class DBHelper2
    {
        public static string strConn = "Data Source=ZHAOZHIHONG\\SQLEXPRESS;Initial Catalog=D_Clinic_System;Integrated Security=True";
      

        /// <summary>
        /// 增、删、改
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="strConn"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string sql)
        {
            SqlConnection conn=new SqlConnection(strConn);
            int n=0;
            try 
	        {	        
		        conn.Open();
                SqlCommand cmd=new SqlCommand(sql,conn);
                n=cmd.ExecuteNonQuery();
	        }
	        catch (Exception ex)
	        {
		        throw ex;
	        }
            finally 
            {
                conn.Close();
            }
            return n;
        }

        /// <summary>
        /// 这是执行带参数的sql增、删、改语句:insert into student(name,sex) values(@name,@sex)
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="strConn">数据库连接字符串</param>
        /// <param name="par">参数数组</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string sql,SqlParameter[] par)
        {
            SqlConnection conn = new SqlConnection(strConn);
            int n = 0;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddRange(par);
                n = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return n;
        }

        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="strSqlList">多条SQL语句</param>		
        public static bool ExecuteSqlTran(List<string> strSqlList)
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                SqlTransaction trans = conn.BeginTransaction();
                cmd.Transaction = trans;
                    try
                    {
                        for (int n = 0; n < strSqlList.Count; n++)
                        {
                            string strsql = strSqlList[n].ToString();
                            if (strsql.Trim().Length > 1)
                            {
                                cmd.CommandText = strsql;
                                cmd.ExecuteNonQuery();
                            }
                        }
                        trans.Commit();
                        return true;
                    }
                
                catch (SqlException ex)
                {
                    trans.Rollback();
                    return false;
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        public static int ExecuteSqlTran2(List<string> strSqlList)
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                SqlTransaction trans = conn.BeginTransaction();
                cmd.Transaction = trans;
                try
                {
                    for (int n = 0; n < strSqlList.Count; n++)
                    {
                        string strsql = strSqlList[n].ToString();
                        if (strsql.Trim().Length > 1)
                        {
                            cmd.CommandText = strsql;
                            cmd.ExecuteNonQuery();
                        }
                    }
                    trans.Commit();
                    return strSqlList.Count;
                }

                catch (SqlException ex)
                {
                    trans.Rollback();
                    return strSqlList.Count;
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        /// <summary>
        /// 一行一列
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="strConn"></param>
        /// <returns></returns>
        public static object ExecuteScalar(string sql)
        {
            SqlConnection conn = new SqlConnection(strConn);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                return cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// 执行存储过程的一行一列
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="strConn">数据库连接字符串</param>
        /// <param name="par">参数数组</param>
        /// <returns></returns>
        public static object ExecuteScalar(string sql,SqlParameter[] par)
        {
            SqlConnection conn = new SqlConnection(strConn);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(par);
                return cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// 查询表
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="strConn"></param>
        /// <returns></returns>
        public static DataTable GetTable(string sql)
        {
            SqlConnection conn=new SqlConnection(strConn);
            DataTable db = new DataTable();
            try
            {
                SqlDataAdapter dap = new SqlDataAdapter(sql, conn);
                dap.Fill(db);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return db;
        }

        /// <summary>
        /// 使用存储过程填充表填充表，并且同事得到输出参数
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="strConn"></param>
        /// <param name="par"></param>
        /// <returns></returns>
        public static DataTable GetTable(string sql,SqlParameter[] par)
        {
            SqlConnection conn = new SqlConnection(strConn);
            DataTable db = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(par);//添加参数
                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                dap.Fill(db);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return db;
        }

        /// <summary>
        /// 获取list集合
        /// 查询、显示、绑定下拉
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
      

        /// <summary>
        /// 获取Model
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <returns></returns>
     
        /// <summary>
        /// 数据表转List
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dt"></param>
        /// <returns></returns>
      

    }
}
