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
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Charge> GetCharge()
        {
            string strsql = $"select * from Charge";
            return dbcoon.Query<Charge>(strsql).ToList();
        }
    }
}
