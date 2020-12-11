using System.Data;
using Microsoft.Extensions.Options;
using Medical.Model.DLH_Medical.Model;
using System.Collections.Generic;
using Medical.Model;
using Dapper;
using System.Data.SqlClient;
using System.Linq;

namespace Medical.System.Servers
{
    public class D_Fee_settings
    {
        public IOptions<ConnectionStrings> _conn;

        IDbConnection dbconn;
        public D_Fee_settings(IOptions<ConnectionStrings> conn)
        {
            _conn = conn;
            dbconn = new SqlConnection(_conn.Value.Conn);
        }


        /// <summary>
        /// 查询处方类型
        /// </summary>
        /// <returns></returns>
        public List<PrescriptionInfo> GetPrescriptionInfos()
        {
            string sql = "select * from PrescriptionInfo";
            return dbconn.Query<PrescriptionInfo>(sql).ToList();
        }

        public List<CostsInfo> GetCostsInfos(string name="",int pid=0)
        {
            string sql = "select * from CostsInfo c join PrescriptionInfo p on c.RecipeKey=p.RecipeId join Userinfo u on c.CreatepersonKey=u.Uid where 1=1";
            if (!string.IsNullOrEmpty(name))
            {
                sql += $" and c.Additional='{name}'";
            }
            if (pid>0)
            {
                sql += $" and p.RecipeId={pid}";
            }
            return dbconn.Query<CostsInfo>(name, pid).ToList();
        }
        

    }
}
