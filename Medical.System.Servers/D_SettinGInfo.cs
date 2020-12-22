using Dapper;
using Medical.Model;
using Medical.Model.DLH_Medical.Model;
using Medical.Model.ZHQ;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;


namespace Medical.System.Servers
{
    public class D_SettinGInfo
    {
        public IOptions<ConnectionStrings> _conn;

        IDbConnection dbconn;
        public D_SettinGInfo(IOptions<ConnectionStrings> conn)
        {
            _conn = conn;
            dbconn = new SqlConnection(_conn.Value.Conn);
        }
        /// <summary>
        /// 显示诊断信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Page<CaseInfo> GetCaseInfos(int tj = 0, string name = "", int pageindex = 1, int pagesize = 10)
        {
            if (!string.IsNullOrEmpty(name))
            {
                var t = IsNumberic(name);
                if (t)
                {
                    tj = 1;
                }
                else
                {
                    tj = 2;
                }
            }
            else
            {
                name = "";
            }
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter() { ParameterName="@DId",DbType=DbType.Int32,Value=tj},
                new SqlParameter() { ParameterName="@Name",DbType=DbType.String,Value=name},
                new SqlParameter() { ParameterName="@PageIndex",DbType=DbType.Int32,Value=pageindex},
                new SqlParameter() { ParameterName="@PageSize",DbType=DbType.Int32,Value=pagesize},
                new SqlParameter() { ParameterName="@AllCount",DbType=DbType.Int32,Direction= ParameterDirection.Output},
            };
            List<CaseInfo> list = DBhelper.GetDataTable_Proc<CaseInfo>("Proc_CaseInfo", param);

            Page<CaseInfo> page = new Page<CaseInfo>()
            {
                Countnum = Convert.ToInt32(param[4].Value),
                PageList = list
            };
            return page;
        }
        private bool IsNumberic(string name = "")
        {
            try
            {
                int var1 = Convert.ToInt32(name);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 添加诊断信息
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public int CassAdd(CaseInfo c)
        {
            string sql = $"insert into CaseInfo values('{c.CaseName}','{c.CaseTable}',{c.Createperson})";
            return dbconn.Execute(sql);
        }
        /// <summary>
        /// 修改诊断信息
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public int CaseModify(CaseInfo c)
        {
            string sql = $"update CaseInfo set CaseName='{c.CaseName}',CaseTable='{c.CaseTable}',Createperson={c.Createperson} where CaseId={c.CaseId}";
            return dbconn.Execute(sql);
        }
        /// <summary>
        /// 回显
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public CaseInfo GetCase(int cid=0)
        {
            string sql = $"select * from CaseInfo c join Userinfo u on c.Createperson=u.Uid where CaseId={cid}";
            return dbconn.Query<CaseInfo>(sql).FirstOrDefault();
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public int DeleteCase(int cid)
        {
            string sql = $"delete from CaseInfo where CaseId={cid}";
            return dbconn.Execute(sql);
        }       
    }
}
