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
  public  class ZHQ_CKDAL
    {
        IDbConnection dbconn;
        public ZHQ_CKDAL(IOptions<ConnectionStrings> conn)
        {
            dbconn = new SqlConnection(conn.Value.Conn);
        }
        /// <summary>
        /// 添加出库申请
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddCKSQ(CKSQ model)
        {
            int row = dbconn.Execute("insert into CKSQ values(@CKSQYPName,@CKSQImg,@CKSQNum,@CKSQTime,@CKSQName,@CKSQCGJ,@CKSQLSJ,@CKSQDesc,@CKSQState,@CKSQLX,@tid)", model);
            return row;
        }
        /// <summary>
        /// 查询出库申请
        /// </summary>
        /// <returns></returns>
        public List<CKSQ> GetCKSQ()
        {
            string sql = "select * from CKSQ";
           
            var list= dbconn.Query<CKSQ>(sql).ToList();
            foreach (var item in list)
            {
                item.gtime = item.CKSQTime.ToString("yyyy-MM-dd");
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
            int row = dbconn.Execute($"update CKSQ set CKSQState={tgstate} where CKSQId={id}");
            return row;
        }
        /// <summary>
        /// 出库拒绝
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int CKJU(int id)
        {
            string sql = $"update CKSQ set CKSQState=10 where CKSQId={id}";
            return dbconn.Execute(sql);
        }
        /// <summary>
        /// 出库
        /// </summary>
        /// <param name="id"></param>
        /// <param name="num"></param>
        /// <param name="tid"></param>
        /// <returns></returns>
        public double CKNUM(int id,int num,int tid)
        {
            try
            {
                var list = dbconn.Query<Drug_administration>($"select DrugKC from Drug_administration where DrugId={tid}").ToList().FirstOrDefault();
                int kc = list.DrugKC - num;
                if (kc < 0)
                {
                    return list.DrugKC;  //库存不够返回
                }
                string sql = $"update Drug_administration set DrugJSKC=DrugJSKC+{num},DrugKC=DrugKC-{num} where DrugId={tid};update CKSQ set CKSQState=6 where CKSQId={id}";
                int row = dbconn.Execute(sql);
                if (row > 0)
                {
                    return 1.5;
                }
                else
                {
                    return 3.5;
                }
            }
            catch (Exception)
            {
                return 2.5;
                throw;
            }
  
        }
        /// <summary>
        /// 如果库存不做申请数量出已有库存的数量
        /// </summary>
        /// <param name="xnum"></param>
        /// <param name="tid"></param>
        /// <returns></returns>
        public int CXNUM(int xnum,int tid,int id)
        {
            string sql = $"update Drug_administration set DrugJSKC=DrugJSKC+{xnum},DrugKC=DrugKC-{xnum} where DrugId={tid};;update CKSQ set CKSQState=6 where CKSQId={id}";
            int row = dbconn.Execute(sql);
            if (row > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        /// <summary>
        /// 删除出库成功或出库拒绝信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DelCK(int id)
        {
            string sql = $"delete from CKSQ where CKSQId={id}";
            return dbconn.Execute(sql);
        }
    }
}
