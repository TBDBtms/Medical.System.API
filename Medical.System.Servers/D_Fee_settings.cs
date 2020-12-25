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

        ///=================================================================诊疗==========================================================================================================
        /// <summary>
        /// 诊疗费设置
        /// </summary>
        /// <param name="name">费用名称</param>
        /// <param name="pid">处方类别</param>
        /// <returns></returns>
        public List<Consultation> GetConsultations(string name = "")
        {

            string sql = "select * from Consultation c join Userinfo u on c.CreatepersonKey=u.Uid where 1=1 ";
            if (!string.IsNullOrEmpty(name))
            {
                sql += $" and c.Additional='{name}'";
            }
            
            return dbconn.Query<Consultation>(sql).ToList();
        }

        /// <summary>
        /// 删除诊疗费用
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public int DelConsultations(int cid)
        {
            var sql = $"delete from Consultation where SequenceId={cid}";
            return dbconn.Execute(sql);
        }
        /// <summary>
        /// 添加附加费用
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public int AddConsultations(Consultation c)
        {
            //c.CTime = DateTime.Now;
            string sql = $"insert into Consultation values('{c.Additional}','{c.MoneyInfn}', '{c.Cost}','{c.ZLTime}','{c.CreatepersonKey}','{c.Vip}','{c.CState}')";
            return dbconn.Execute(sql);
        }
        /// <summary>
        /// 修改附加费用
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int ModifyConsultations(Consultation model)
        {
            string sql = $"Update Consultation set Additional='{model.Additional}',MoneyInfn={model.MoneyInfn},Cost={model.Cost},ZLTime='{model.ZLTime}',CreatepersonKey={model.CreatepersonKey},Vip='{model.Vip}',CState='{model.CState}' where SequenceId={model.SequenceId}";
            return dbconn.Execute(sql);
        }
        /// <summary>
        /// 修改附加回显
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public Consultation FXConsultations(int cid = 0)
        {
            string sql = $"select * from Consultation c join Userinfo u on c.CreatepersonKey=u.Uid where c.SequenceId={cid}";

            return dbconn.Query<Consultation>(sql).FirstOrDefault();
        }
        //============================================挂号============
        /// <summary>
        /// 挂号费设置
        /// </summary>
        /// <param name="name">费用名称</param>
        /// <param name="pid">处方类别</param>
        /// <returns></returns>
        public List<Registration> GetRegistrations(string name = "")
        {

            string sql = "select * from Registration r join Userinfo u on r.CreatepersonKey=u.Uid where 1=1";
            if (!string.IsNullOrEmpty(name))
            {
                sql += $" and c.Registra='{name}'";
            }

            return dbconn.Query<Registration>(sql).ToList();
        }

        /// <summary>
        /// 删除挂号费用
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public int DelRegistration(int cid)
        {
            var sql = $"delete from Registration where SequenceId={cid}";
            return dbconn.Execute(sql);
        }
        /// <summary>
        /// 添加挂号费用
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public int AddRegistration(Registration c)
        {
            //c.CTime = DateTime.Now;
            string sql = $"insert into Registration values('{c.Registra}','{c.MoneyInfnses}', '{c.Cost}','{c.GHTime}','{c.CreatepersonKey}','{c.Vip}','{c.CState}')";
            return dbconn.Execute(sql);
        }
        /// <summary>
        /// 修改挂号费用
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int ModifyRegistration(Registration model)
        {
            string sql = $"Update Registration set Registra='{model.Registra}',MoneyInfnses={model.MoneyInfnses},Cost={model.Cost},GHTime='{model.GHTime}',CreatepersonKey={model.CreatepersonKey},Vip='{model.Vip}',CState='{model.CState}' where SequenceIds={model.SequenceIds}";
            return dbconn.Execute(sql);
        }
        /// <summary>
        /// 修改挂号回显
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public Registration FXRegistration(int cid = 0)
        {
            string sql = $"select * from Registration r join Userinfo u on r.CreatepersonKey=u.Uid where r.SequenceId={cid}";

            return dbconn.Query<Registration>(sql).FirstOrDefault();
        }
    }
}
