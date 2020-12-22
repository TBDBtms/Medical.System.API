﻿using System;
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
            int row = dbconn.Execute("insert into RKSQ values(@RKSQYPName,@RKSQImg,@RKSQNum,@RKSQTime,@RKSQName,@RKSQCGJ,@RKSQLSJ,@RKSQDesc,@RKSQState,@RKSQLX,@tid)", model);
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
        /// <summary>
        /// 添加入库信息进行入库
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int AddRKB(int id)
        {
            string sql = $"insert into RKB(RKSQYPName,RKSQImg,RKSQNum,RKSQTime,RKSQName,RKSQCGJ,RKSQLSJ,RKSQDesc,RKSQState,RKSQLX,pid)select RKSQYPName,RKSQImg,RKSQNum,RKSQTime,RKSQName,RKSQCGJ,RKSQLSJ,RKSQDesc,RKSQState,RKSQLX,tid from RKSQ where RKSQId={id}";

            int row= dbconn.Execute(sql);
            if (row > 0)
            {
                int row1 = dbconn.Execute($"update RKSQ set RKSQState=4 where RKSQId={id}");
                if (row1 > 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }
        /// <summary>
        /// 查询入库信息表
        /// </summary>
        /// <returns></returns>
        public List<RKB> GetRKB()
        {
            string sql = "select * from RKB";
            return dbconn.Query<RKB>(sql).ToList();
        }
        /// <summary>
        /// 入库拒绝
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int RKJU(int id)
        {
            string sql = $"update RKSQ set RKSQState=10 where RKSQId={id}";
            return dbconn.Execute(sql);
        }
        /// <summary>
        /// 加库存
        /// </summary>
        /// <param name="num"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public int JiaNum(int num,int id)
        {
            string sql = $"update Drug_administration set DrugKC=DrugKC+{num} where DrugId={id}";
            return dbconn.Execute(sql);
        }
    }
}
