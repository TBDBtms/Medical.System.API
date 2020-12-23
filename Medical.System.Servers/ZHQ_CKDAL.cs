using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Medical.Model;
using Microsoft.Extensions.Options;

namespace Medical.System.Servers
{
  public  class ZHQ_CKDAL
    {
        IDbConnection dbconn;
        public ZHQ_CKDAL(IOptions<ConnectionStrings> conn)
        {
            dbconn = new SqlConnection(conn.Value.Conn);
        }
    }
}
