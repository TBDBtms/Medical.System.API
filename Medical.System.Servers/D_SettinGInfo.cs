using Dapper;
using Medical.Model;
using Medical.Model.DLH_Medical.Model;
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
        public List<CaseInfo> GetCaseInfos(string name="")
        {
            string sql = $"select * from CaseInfo c join Userinfo u on c.Createperson=u.uid where 1=1";
            if (!string.IsNullOrEmpty(name))
            {
                sql += $" and CaseName={name}";
            }
            return dbconn.Query<CaseInfo>(sql).ToList();
        }
        /// <summary>
        /// 添加诊断信息
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public int CassAdd(CaseInfo c)
        {
            c.time = new DateTime().ToString("yyyy-MM-dd");
            string sql = $"insert into CaseInfo values('{c.CaseName}','{c.time}',{c.Createperson})";
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
        public CaseInfo GetCase(int cid)
        {
            string sql = $"select * from CaseInfo";
            return dbconn.Query<CaseInfo>(sql).FirstOrDefault();
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public int DeleteCase(int cid)
        {
            string sql = $"delect from CaseInfo where CaseId={cid}";
            return dbconn.Execute(sql);
        }

       
    }
}
