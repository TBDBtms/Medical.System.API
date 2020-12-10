using System;
using System.Data;
using System.Data.SqlClient;
using Medical.Model;
using Microsoft.Extensions.Options;

namespace Medical.System.Servers
{
    public class DALLX
    {
        IDbConnection dbconn;
        public DALLX(IOptions<ConnectionStrings> conn)
        {
            dbconn = new SqlConnection(conn.Value.Conn);
        }
    }
}
