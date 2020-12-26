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
        public List<VIPInfo> GetVIPInfos(DateTime? stime, DateTime? etime, int id = 0, string name = "", int flag = 0)
        {
            string str = $"select * from VIPInfo a join VIPgrade b on a.VGradeId=b.VGradeId join Patient c on a.Id=c.PatientId where 1=1";

            if (stime != null && etime != null)
            {
                str += $" and a.StartTime between '{stime}' and '{stime}'";
            }
            if (id > 0)
            {
                str += $" and b.VGradeId={id}";
            }
            if (flag == 1)
            {
                str += $" and c.PatientName like '%" + name + "%'";
            }
            if (flag == 2)
            { 
                str += $" and a.Phone='{name}'";
            }
            if (flag == 3)
            {
                str += $" and a.IdCard='{name}'";
            }
            return dbcoon.Query<VIPInfo>(str).ToList();
        }
        /// <summary>
        /// 余额充值返填信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public VIPInfo GetById(int id)
        {
            try
            {
                string str = $"select * from VIPInfo a join Patient c on a.id=c.PatientId  where a.Id={id}";
                var strs = dbcoon.Query<VIPInfo>(str).ToList();
                if (strs.Count > 0)
                {
                    return strs.First();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
        /// <summary>
        /// 余额充值
        /// </summary>
        /// <param name="vip"></param>
        /// <returns></returns>
        public int UpdVIPInfo(VIPInfo vip)
        {
            string sqls = $"select * from VIPInfo where Id={vip.Id}";
            var list = DBhelper.GetList<VIPInfo>(sqls).FirstOrDefault();
            var money = list.AmassPrice + vip.SvalueMoney;
            var price = list.SvalueMoney + vip.GiveMoney + vip.PayMoney;
            var numprice = list.Integral + vip.PayMoney + vip.GiveMoney;
            string str = $"update VIPInfo set Integral={numprice},AmassPrice={money},SvalueMoney={price},PayMoney={vip.PayMoney},GiveMoney={vip.GiveMoney},SId={vip.SId} WHERE Id={vip.Id}";
            return dbcoon.Execute(str);
        }
        /// <summary>
        /// 充值/退款记录
        /// </summary>
        /// <returns></returns>
        public List<VIPmoneys> GetVIPmoneys(string name = "")
        {

            string str = $"select * from VIPmoneys a join SValuemage b on a.Id=b.Id join Patient c on a.id=c.PatientId where c.PatientName='{name}'";
            return dbcoon.Query<VIPmoneys>(str).ToList();
        }
        /// <summary>
        /// 下拉会员等级
        /// </summary>
        /// <returns></returns>
        public List<VIPgrade> GetVIPgrades()
        {
            string str = $"select top 6 * from VIPgrade";
            return dbcoon.Query<VIPgrade>(str).ToList();
        }
        /// <summary>
        /// 显示设置会员等级数据
        /// </summary>
        /// <returns></returns>
        public List<VIPInfo> GetVIPgrade()
        {
            string str = $"select distinct a.VGradeId,a.VTypeName,a.Discount,b.VGradeName from VIPInfo a join VIPgrade b on a.VGradeId=b.VGradeId where id<=5";
            return dbcoon.Query<VIPInfo>(str).ToList();
        }
        /// <summary>
        /// 修改会员等级
        /// </summary>
        /// <param name="vip"></param>
        /// <returns></returns>
        public int UpdVIPgrade(VIPInfo vip)
        {
            string str = $"update VIPInfo set EndTime='{vip.EndTime}',VGradeId='{vip.VGradeId}',VIPName='{vip.VIPName}',Discount={vip.Discount} where Id={vip.Id}";
            return dbcoon.Execute(str);
        }
        /// <summary>
        /// 增加积分
        /// </summary>
        /// <param name="vip"></param>
        /// <returns></returns>
        public int AddIntegral(VIPInfo vip)
        {
            string sqls = $"select Integral from VIPInfo where Id={vip.Id}";
            var list = DBhelper.GetList<VIPInfo>(sqls).FirstOrDefault();
            var integrals = list.Integral;
            string str = $"update VIPInfo set Integral={integrals + vip.Integral},AddRemark='{vip.AddRemark}' where Id={vip.Id}";
            return dbcoon.Execute(str);
        }
        /// <summary>
        /// 扣减积分
        /// </summary>
        /// <param name="vip"></param>
        /// <returns></returns>
        public int JIanIntegral(VIPInfo vip)
        {
            string sqls = $"select * from VIPInfo where Id={vip.Id}";
            var list = DBhelper.GetList<VIPInfo>(sqls).FirstOrDefault();
            var kjnums = list.Integral;
            string str = $"update VIPInfo set Integral={kjnums - vip.Integral},KJRemark='{vip.KJRemark}' where Id={vip.Id}";
            return dbcoon.Execute(str);
        }
        /// <summary>
        /// 积分清零
        /// </summary>
        /// <param name="vip"></param>
        /// <returns></returns>
        public int ClearIntegral(VIPInfo vip)
        {
            string str = $"update VIPInfo set Integral={vip.Integral = 0},InClearRemark='{vip.InClearRemark}' where Id={vip.Id}";
            return dbcoon.Execute(str);
        }
        /// <summary>
        /// 退款
        /// </summary>
        /// <param name="vip"></param>
        /// <returns></returns>
        public int RePrice(VIPInfo vip)
        {
            string sqls = $"select SvalueMoney from VIPInfo where Id={vip.Id}";
            var list = DBhelper.GetList<VIPInfo>(sqls).FirstOrDefault();
            var TKje = list.SvalueMoney - vip.RePrice;
            string str = $"update VIPInfo set SvalueMoney={TKje},ReTypeId={vip.ReTypeId},Remark='{vip.Remark}' where Id={vip.Id}";
            return dbcoon.Execute(str);
        }
        /// <summary>
        ///会员等级变更记录
        /// </summary>
        /// <returns></returns>
        public List<VIPInfo> SetGrade(string name = "")
        {
            string str = $"select * from VIPInfo a join SetGrade b on a.Id=b.Id join Patient c on a.Id=c.PatientId where c.PatientName='{name}'";
            return dbcoon.Query<VIPInfo>(str).ToList();
        }
        /// <summary>
        /// 添加会员等级变动记录
        /// </summary>
        /// <param name="grade"></param>
        /// <returns></returns>
        public int AddGrade(SetGrade grade)
        {
            var strs = grade.ChTime = DateTime.Now;
            string str = $"insert into SetGrade values('{grade.VIPCard}','{grade.VIPName}',{strs},'{grade.ChType}','{grade.Operator}')";
            return dbcoon.Execute(str);
        }
        /// <summary>
        /// 储值管理
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="phone"></param>
        /// <param name="card"></param>
        /// <returns></returns>
        public List<SValuemage> GetSValuemages(int id, string name = "", string phone = "", string card = "", int flag = 0)
        {
            string str = $"select * from SValuemage a join VIPgrade b on a.VGradeId=b.VGradeId join Patient c on a.id=c.PatientId where 1=1";
            if (id > 0)
            {
                str += $" and a.VGradeId={id}";
            }
            if (flag == 1)
            {
                str += $" and c.PatientName='{name}'";
            }
            if (flag == 2)
            {
                str += $" and a.Phone='{phone}'";
            }
            if (flag == 3)
            {
                str += $" and a.idCard='{card}'";
            }
            return dbcoon.Query<SValuemage>(str).ToList();
        }
        /// <summary>
        /// 储值管理的充值
        /// </summary>
        /// <param name="sva"></param>
        /// <returns></returns>
        public int UpdCZ(SValuemage sva)
        {
            string sqls = $"select * from SValuemage where Id={sva.Id}";
            var list = DBhelper.GetList<SValuemage>(sqls).FirstOrDefault();
            var money = list.AmassPrice + sva.SvalueMoney;
            var price = list.SvalueMoney + sva.GiveMoney + sva.PayMoney;
            var numprice = list.AddGiveMoney + sva.PayMoney + sva.GiveMoney;
            string str = $"update SValuemage set AddGiveMoney={numprice},AmassPrice={money},SvalueMoney={price},PayMoney={sva.PayMoney},GiveMoney={sva.GiveMoney},SId={sva.SId} WHERE Id={sva.Id}";
            return dbcoon.Execute(str);
        }
        /// <summary>
        /// 储值余额退款1
        /// </summary>
        /// <param name="sva"></param>
        /// <returns></returns>
        public int UpdTK(SValuemage sva)
        {
            string sqls = $"select SvalueMoney from SValuemage where Id={sva.Id}";
            var list = DBhelper.GetList<SValuemage>(sqls).FirstOrDefault();
            var TKje = list.SvalueMoney;
            string str = $"update SValuemage set Rprice={TKje - sva.Rprice},RMent='{sva.RMent}',Remark='{sva.Remark}' where Id={sva.Id}";
            return dbcoon.Execute(str);
        }
        /// <summary>
        /// 储值-充值退款记录
        /// </summary>
        /// <param name="vips"></param>
        /// <returns></returns>
        public int AddJL(VIPmoneys vips)
        {
            string sqls = $"select * from VIPmoneys where Id={vips.Id}";
            var list = DBhelper.GetList<VIPmoneys>(sqls).FirstOrDefault();
            vips.DealTimes = DateTime.Now;
            vips.SumMoney = list.GiveMoney + list.DealPrice;
            return dbcoon.Execute("insert into VIPmoneys values(@DealTimes,@DealType,@DealPrice,@Givemoney,@SumMoney,@Mans)", vips);
        }
        /// <summary>
        /// 积分管理
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="phone"></param>
        /// <param name="card"></param>
        /// <returns></returns>
        public List<Pointmanage> GetPointmanages(int id, string name = "", string phone = "", string card = "", int flag = 0)
        {
            string str = $"select * from Pointmanage a join VIPgrade b on a.VGradeId=b.VGradeId join Patient c on a.id=c.PatientId where 1=1";
            if (id > 0)
            {
                str += $" and a.VGradeId={id}";
            }
            if (flag == 1)
            {
                str += $" and c.PatientName='{name}'";
            }
            if (flag == 2)
            {
                str += $" and a.Phone='{phone}'";
            }
            if (flag == 3)
            {
                str += $" and a.idCard='{card}'";
            }
            return dbcoon.Query<Pointmanage>(str).ToList();
        }
        /// <summary>
        /// 积分变动记录
        /// </summary>
        /// <returns></returns>
        public List<PointInfo> GetJFBD(string name = "")
        {
            string str = $"select * from PointInfo a join VIPInfo b on a.Id=b.Id join Patient c on a.Id=c.PatientId where c.PatientName='{name}'";
            return dbcoon.Query<PointInfo>(str).ToList();
        }
        /// <summary>
        /// 添加积分变动记录
        /// </summary>
        /// <returns></returns>
        public int AddJF(PointInfo point)
        {
            string str = $"insert into PointInfo values('{point.NewTimes = DateTime.Now}','{point.ChangeCZ}',{point.Num},'{point.Man}','{point.Remark}')";
            return dbcoon.Execute(str);
        }
        /// <summary>
        /// 会员设置显示
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="phone"></param>
        /// <param name="card"></param>
        /// <returns></returns>
        public List<MemberSet> GetMembers()
        {
            string str = $"select * from MemberSet a join VIPgrade b on a.VGradeId=b.VGradeId join Patient c on a.id=c.PatientId where 1=1";
            return dbcoon.Query<MemberSet>(str).ToList();
        }
        /// <summary>
        /// 会员设置返填
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="phone"></param>
        /// <param name="card"></param>
        /// <returns></returns>
        public MemberSet GetShowMembers(int id)
        {
            try
            {
                string str = $"select * from MemberSet where Id={id}";
                var list = dbcoon.Query<MemberSet>(str).ToList();
                if (list.Count() > 0)
                {
                    return list.First();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
        /// <summary>
        /// 新增会员类型
        /// </summary>
        /// <param name="mset"></param>
        /// <returns></returns>
        public int AddVIPType(MemberSet mset)
        {
            string str = $"insert into MemberSet values({mset.VGradeId},'{mset.VGradeName}','{mset.VIPName}',{mset.VIPReset},{mset.MinIntegral},{mset.Upgrade},'{mset.Remark}',{mset.States})";
            return dbcoon.Execute(str);
        }
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="mset"></param>
        /// <returns></returns>
        public int UpdVIPType(MemberSet mset)
        {
            string str = $"update MemberSet set VGradeName='{mset.VGradeName}',VIPName='{mset.VIPName}',VIPReset={mset.VIPReset},MinIntegral={mset.MinIntegral},Upgrade={mset.Upgrade},Remark='{mset.Remark}',States={mset.States} where Id={mset.Id}";
            return dbcoon.Execute(str);
        }
        /// <summary>
        /// 设置会员条件
        /// </summary>
        /// <param name="funcs"></param>
        /// <returns></returns>
        public int UpdVipwhere(SetFunc funcs)
        {
            string str = $"UPDATE SetFunc set RsestId={funcs.RsestId},Rupgrade={funcs.Rupgrade},XId={funcs.XId},CId={funcs.CId},Uppers={funcs.Uppers} where Id={funcs.Id}";
            return dbcoon.Execute(str);
        }
        /// <summary>
        /// 支付方式
        /// </summary>
        /// <param name="sets"></param>
        /// <returns></returns>
        public int UpdZF(SetPayment sets)
        {
            string str = $"update SetPayment set CashId={sets.CashId},AlipayId={sets.AlipayId},WeChatId={sets.WeChatId},BankcardId={sets.BankcardId},ClubCardId={sets.ClubCardId},Suspends={sets.Suspends} where SId=1";
            return dbcoon.Execute(str);
        }
        /// <summary>
        /// 供应商管理
        /// </summary>
        /// <param name="gid"></param>
        /// <returns></returns>
        public List<SupplierInfo> GetSupplierInfos(string name = "")
        {
            string str = $"select * from SupplierInfo where 1=1";
            if (!string.IsNullOrEmpty(name))
            {
                str += $" and SupName like '%" + name + "%'";
            }
            return dbcoon.Query<SupplierInfo>(str).ToList();
        }
        /// <summary>
        /// 回显
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SupplierInfo FindById(int id)
        {
            try
            {
                string str = $"select * from SupplierInfo where Id={id}";
                var list = DBhelper.GetList<SupplierInfo>(str).ToList();
                if (str.Count() > 0)
                {
                    return list.First();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        public int UpdSupplier(SupplierInfo supper)
        {
            string str = $"update SupplierInfo set SupGIS='{supper.SupGIS}',SupName='{supper.SupName}',LinkMan='{supper.LinkMan}',LinkPhone='{supper.LinkPhone}',CTimes='{supper.CTimes = DateTime.Now}',CMan='{supper.CMan}',SupState={supper.SupState},Remark='{supper.Remark}' where Id={supper.Id}";
            return dbcoon.Execute(str);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Del(int id)
        {
            string str = $"delete from SupplierInfo where Id={id}";
            return dbcoon.Execute(str);
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="supper"></param>
        /// <returns></returns>
        public int Add(SupplierInfo supper)
        {
            string str = $"insert into SupplierInfo values('{supper.SupGIS}','{supper.SupName}','{supper.LinkMan}','{supper.LinkPhone}','{supper.CTimes = DateTime.Now}','{supper.CMan}',{supper.SupState},'{supper.Remark}')";
            return dbcoon.Execute(str);
        }
    }
}
