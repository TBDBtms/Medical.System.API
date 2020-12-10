using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Medical.Model.Jcy_Model;
using Medical.Model;
using Microsoft.Extensions.Options;
using Dapper;
using System.Linq;

namespace Medical.System.Servers
{
    public class Jcy_VIPInfoDAL
    {
        public IOptions<ConnectionStrings> _conn;
        IDbConnection dbcoon;
        public Jcy_VIPInfoDAL(IOptions<ConnectionStrings> conn)
        {
            _conn = conn;
            dbcoon = new SqlConnection(_conn.Value.Conn);
        }
        /// <summary>
        /// 显示会员信息
        /// </summary>
        /// <param name="stime"></param>
        /// <param name="etime"></param>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="phone"></param>
        /// <param name="card"></param>
        /// <returns></returns>
        public List<VIPInfo> GetVIPInfos(DateTime? stime, DateTime? etime, int id=0,string name="",string phone="",string card="")
        {
            string str = $"select * from VIPInfo a join VIPgrade b on a.VGradeId=b.VGradeId where 1=1";
            if (stime!=null && etime!=null)
            {
                str += $" and a.StartTime Between {stime} and {etime}";
            }
            if (id>0)
            {
                str += $" and b.VGradeId={id}";
            }
            if (!string.IsNullOrEmpty(name))
            {
                str += $" and a.VIPName='{name}'";
            }
            if (!string.IsNullOrEmpty(phone))
            {
                str += $" and a.Phone='{phone}'";
            }
            if (!string.IsNullOrEmpty(card))
            {
                str += $" and a.Card='{card}'";
            }
            return dbcoon.Query<VIPInfo>(str).ToList();
        }
        /// <summary>
        /// 余额充值返填信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<VIPInfo> GetById(int id)
        {
            string str = $"select * from VIPInfo where Id={id}";
            return dbcoon.Query<VIPInfo>(str).ToList();
        }
        /// <summary>
        /// 余额充值
        /// </summary>
        /// <param name="vip"></param>
        /// <returns></returns>
        public int UpdVIPInfo(VIPInfo vip)
        {
            string str = $"update VIPInfo set PayMoney={vip.PayMoney},GiveMoney={vip.GiveMoney},Id={vip.Id}";
            return dbcoon.Execute(str);
        }
        /// <summary>
        /// 下拉会员等级
        /// </summary>
        /// <returns></returns>
        public List<VIPgrade> GetVIPgrades()
        {
            string str = $"select * from VIPgrade";
            return dbcoon.Query<VIPgrade>(str).ToList();
        }
        /// <summary>
        /// 显示设置会员等级数据
        /// </summary>
        /// <returns></returns>
        public List<VIPInfo> GetVIPgrade()
        {
            string str = $"select * from VIPInfo a join VIPgrade b on a.VGradeId=b.VGradeId where 1=1";
            return dbcoon.Query<VIPInfo>(str).ToList();
        }
        /// <summary>
        /// 修改会员等级
        /// </summary>
        /// <param name="vip"></param>
        /// <returns></returns>
        public int UpdVIPgrade(VIPInfo vip)
        {
            string str = $"update VIPInfo set EndTime={vip.EndTime},VGradeId={vip.VGradeId},Id={vip.Id}";
            return dbcoon.Execute(str);
        }
        /// <summary>
        /// 增加积分
        /// </summary>
        /// <param name="vip"></param>
        /// <returns></returns>
        public int AddIntegral(VIPInfo vip)
        {
            string str = $"update VIPInfo set Integral=Integral+{vip.Integral},AddRemark='{vip.AddRemark}',Id={vip.Id}";
            return dbcoon.Execute(str);
        }
        /// <summary>
        /// 扣减积分
        /// </summary>
        /// <param name="vip"></param>
        /// <returns></returns>
        public int JIanIntegral(VIPInfo vip)
        {
            string str = $"update VIPInfo set Integral=Integral-{vip.Integral},KJRemark='{vip.KJRemark}',Id={vip.Id}";
            return dbcoon.Execute(str);
        }
        /// <summary>
        /// 积分清零
        /// </summary>
        /// <param name="vip"></param>
        /// <returns></returns>
        public int ClearIntegral(VIPInfo vip)
        {
            string str = $"update VIPInfo set Integral=0,InClearRemark='{vip.InClearRemark}',Id={vip.Id}";
            return dbcoon.Execute(str);
        }
        /// <summary>
        /// 退款
        /// </summary>
        /// <param name="vip"></param>
        /// <returns></returns>
        public int RePrice(VIPInfo vip)
        {
            string str = $"update VIPInfo set RePrice=RePrice-{vip.RePrice},ReTypeId={vip.ReTypeId},Remark='{vip.Remark}',Id={vip.Id}";
            return dbcoon.Execute(str);
        }
        /// <summary>
        ///会员等级变更记录
        /// </summary>
        /// <returns></returns>
        public List<VIPInfo> SetGrade()
        {
            string str = $"select * from VIPInfo a join SetGrade b on a.Id=b.Id where 1=1";
            return dbcoon.Query<VIPInfo>(str).ToList();
        }
    }
}
