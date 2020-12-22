using Medical.Model;
using Medical.Model.ZHQ;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Medical.Model.DLH_Medical.Model;
using Dapper;
using System.Linq;

namespace Medical.System.Servers
{
    public class D_Principleaction
    {
        public IOptions<ConnectionStrings> _conn;

        IDbConnection dbconn;
        public D_Principleaction(IOptions<ConnectionStrings> conn)
        {
            _conn = conn;
            dbconn = new SqlConnection(_conn.Value.Conn);
        }
        /// <summary>
        /// 显示既往信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        
        //public Page<Principleaction> GetPage(int tj = 0, string name = "", int pageindex = 1, int pagesize = 10)
        //{
        //    if (!string.IsNullOrEmpty(name))
        //    {
        //        var t = IsNumberic(name);
        //        if (t)
        //        {
        //            tj = 1;
        //        }
        //        else
        //        {
        //            tj = 2;
        //        }
        //    }
        //    else
        //    {
        //        name = "";
        //    }
        //    SqlParameter[] param = new SqlParameter[] {
        //        new SqlParameter() { ParameterName="@DId",DbType=DbType.Int32,Value=tj},
        //        new SqlParameter() { ParameterName="@Name",DbType=DbType.String,Value=name},
        //        new SqlParameter() { ParameterName="@PageIndex",DbType=DbType.Int32,Value=pageindex},
        //        new SqlParameter() { ParameterName="@PageSize",DbType=DbType.Int32,Value=pagesize},
        //        new SqlParameter() { ParameterName="@AllCount",DbType=DbType.Int32,Direction= ParameterDirection.Output},
        //    };
        //    List<Principleaction> list = DBhelper.GetDataTable_Proc<Principleaction>("Proc_Principleaction", param);

        //    Page<Principleaction> page = new Page<Principleaction>()
        //    {
        //        Countnum = Convert.ToInt32(param[4].Value),
        //        PageList = list
        //    };
        //    return page;
        //}
        //private bool IsNumberic(string name = "")
        //{
        //    try
        //    {
        //        int var1 = Convert.ToInt32(name);
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        public List<sb> GetDate(int pageIndex=1,int pageSize=10)
        {
            var i = new CaseInfo();
            var c = new Principleaction();
            var getdate = DateTime.Now.Day;
            var day = getdate - i.CaseTable.Day;
            if (day>0)
            {
                string sql = $"insert into Principleaction (PastName,PastTable,Createperson) select CaseName,CaseTable,Createperson from CaseInfo select * from Principleaction join Userinfo on Principleaction.Createperson=Userinfo.Uid delete from CaseInfo";
                return dbconn.Query<sb>(sql).Skip((pageIndex-1)*pageSize).Take(pageIndex*pageSize).ToList();
            }
            else
            {
                string sql = "select * from Principleaction join Userinfo on Principleaction.Createperson=Userinfo.Uid";
                return dbconn.Query<sb>(sql).Skip((pageIndex - 1) * pageSize).Take(pageIndex * pageSize).ToList();
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public int DeletePrincipleaction(int cid)
        {
            string sql = $"delete from Principleaction where PastId={cid}";
            return dbconn.Execute(sql);
        }
    }
}
