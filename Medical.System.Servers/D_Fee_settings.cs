using System.Data;
using Microsoft.Extensions.Options;
using Medical.Model.DLH_Medical.Model;
using System.Collections.Generic;
using Medical.Model;
using Dapper;
using System.Data.SqlClient;
using System.Linq;
using System;

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
            string sql = "select * from PrescriptionInfo where 1=1";
            return dbconn.Query<PrescriptionInfo>(sql).ToList();
        }
        /// <summary>
        /// 附加费用设置
        /// </summary>
        /// <param name="name">费用名称</param>
        /// <param name="pid">处方类别</param>
        /// <returns></returns>
        public List<CostsInfo> GetCostsInfos(string name="",int pid=0)
        {
            
            string sql = "select * from CostsInfo c join PrescriptionInfo p on c.RecipeKey=p.RecipeId join Userinfo u on c.CreatepersonKey=u.Uid where 1=1 ";
            if (!string.IsNullOrEmpty(name))
            {
                sql += $" and c.Additional='{name}'";
            }
            if (pid>0)
            {
                sql += $" and p.RecipeId={pid}";
            }
            return dbconn.Query<CostsInfo>(sql).ToList();
        }
        /// <summary>
        /// 删除附加费用
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public int DelCost(int cid)
        {
            var sql = $"delete from CostsInfo where SequenceId={cid}";
            return dbconn.Execute(sql);
        }
        /// <summary>
        /// 修改附加费用
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int ModifyCost(CostsInfo model)
        {
            string sql = $"Update CostsInfo set Additional='{model.Additional}',RecipeKey={model.RecipeKey},MoneyInfn={model.MoneyInfn},Cost={model.Cost},CTime='{model.CTime}',CreatepersonKey={model.CreatepersonKey},Vip='{model.Vip}',CState='{model.CState}' where SequenceId={model.SequenceId}";
            return dbconn.Execute(sql);
        }
        /// <summary>
        /// 修改附加回显
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public CostsInfo FXCost(int cid=0)
        {
            string sql = $"select * from CostsInfo c join PrescriptionInfo p on c.RecipeKey=p.RecipeId where c.SequenceId={cid}";

            return dbconn.Query<CostsInfo>(sql).FirstOrDefault();
        }
        /// <summary>
        /// 判断费用状态开始/判断费用状态关闭
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public int FYStart(CostsInfo c)
        {
            string sql = $"update CostsInfo set CState=CState-1 where SequenceId={c.SequenceId}";
            return dbconn.Execute(sql);
        }

        /// <summary>
        /// 会员状态为否/会员状态为是
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public int VIPZheko(CostsInfo c)
        {
            string sql = $"update CostsInfo set Vip=Vip-1 where SequenceId={c.SequenceId}";
            return dbconn.Execute(sql);
        }
        /// <summary>
        /// 添加附加费用
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public int AddCost(CostsInfo c)
        {
            //c.CTime = DateTime.Now;
            string sql = $"insert into CostsInfo values('{c.Additional}','{c.RecipeKey}', '{c.MoneyInfn}', '{c.Cost}','{c.CTime}' ,'{c.CreatepersonKey}','{c.Vip}','{c.CState}')";
            return dbconn.Execute(sql);
        }
    }
}
