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
    public class Zzh_PatientServers
    {
        public IOptions<ConnectionStrings> _conn;
        IDbConnection dbcoon;
        public Zzh_PatientServers(IOptions<ConnectionStrings> conn)
        {
            _conn = conn;
            dbcoon = new SqlConnection(conn.Value.Conn);

        }
        public List<Patient> GetPatient()
        {
            string sql = $"select * from Patient";
            return dbcoon.Query<Patient>(sql).ToList();
        }
    }
}
