using Dapper;
using Medical.Model;
using Medical.Model.ZZH_Model;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Medical.System.Servers
{
    public class Zzh_ChargeServers
    {
        public IOptions<ConnectionStrings> _conn;
        IDbConnection dbcoon;
        public Zzh_ChargeServers(IOptions<ConnectionStrings> conn)
        {
            _conn = conn;
            dbcoon = new SqlConnection(conn.Value.Conn);
        }
        /// <summary>
        /// 门诊日志
        /// </summary>
        /// <returns></returns>
        public List<Outpatientlog> GetOutpatientlog()
        {
            string strsql = $"select * from Outpatientlog";
            return dbcoon.Query<Outpatientlog>(strsql).ToList();
        }
    }
}
