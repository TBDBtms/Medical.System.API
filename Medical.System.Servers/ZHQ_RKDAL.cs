using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dapper;
using Medical.Model;
using Medical.Model.ZHQ;
using Microsoft.Extensions.Options;

namespace Medical.System.Servers
{
   public class ZHQ_RKDAL
    {
        IDbConnection dbconn;
        public ZHQ_RKDAL(IOptions<ConnectionStrings> conn)
        {
            dbconn = new SqlConnection(conn.Value.Conn);
        }
        /// <summary>
        /// 添加申请
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddRKSQ(RKSQ model)
        {
            int row = dbconn.Execute("insert into RKSQ values(@RKSQYPName,@RKSQImg,@RKSQNum,@RKSQTime,@RKSQName,@RKSQCGJ,@RKSQLSJ,@RKSQDesc,@RKSQState,@RKSQLX)", model);
            return row;
        }
        /// <summary>
        /// 查询申请信息表
        /// </summary>
        /// <returns></returns>
        public List<RKSQ> GetRKSQ()
        {
            string sql = "select * from RKSQ";
            var list= dbconn.Query<RKSQ>(sql).ToList();
            foreach (var item in list)
            {
                item.gtime = item.RKSQTime.ToString("yyyy-MM-dd");
            }

            return list;
        }
        /// <summary>
        /// 修改申批状态
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tgstate"></param>
        /// <returns></returns>
        public int UpdState(int id, int tgstate)
        {
            int row = dbconn.Execute($"update RKSQ set RKSQState={tgstate} where RKSQId={id}");
            return row;
        }
    }
}
