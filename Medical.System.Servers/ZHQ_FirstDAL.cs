using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Medical.Model;
using Medical.Model.ZHQ;
using Microsoft.Extensions.Options;
using Dapper;
using System.Linq;

namespace Medical.System.Servers
{
   public  class ZHQ_FirstDAL
    {
        IDbConnection dbconn;
        public ZHQ_FirstDAL(IOptions<ConnectionStrings> conn)
        {
            dbconn = new SqlConnection(conn.Value.Conn);
        }

        public List<Drug_administration> GetDrug_administration()
        {
            string sql = "select * from Drug_administration";
            return dbconn.Query<Drug_administration>(sql).ToList();
        }
    }
}
