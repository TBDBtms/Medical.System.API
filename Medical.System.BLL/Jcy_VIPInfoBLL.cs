using System;
using System.Collections.Generic;
using System.Text;
using Medical.Model.Jcy_Model;
using Medical.Model;
using Medical.System.Servers;
using Microsoft.Extensions.Options;

namespace Medical.System.BLL
{
    /// <summary>
    /// 会员模块
    /// </summary>
    public class Jcy_VIPInfoBLL
    {
        Jcy_VIPInfoDAL dal;
        public Jcy_VIPInfoBLL(IOptions<ConnectionStrings> conn)
        {
            dal = new Jcy_VIPInfoDAL(conn);
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
        public Pages<VIPInfo> GetVIPInfos(DateTime? stime, DateTime? etime, int pd = 0, int id = 0, string name = "", string phone = "", string card = "", int PageIndex = 0, int PageSize = 0, int AllCount = 0)
        {
            return dal.GetVIPInfos(stime, etime, pd,id,name, phone, card,PageIndex,PageSize,AllCount);
        }
        /// <summary>
        /// 余额充值返填信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public VIPInfo GetById(int id)
        {
            return dal.GetById(id);
        }
        /// <summary>
        /// 余额充值
        /// </summary>
        /// <param name="vip"></param>
        /// <returns></returns>
        public int UpdVIPInfo(VIPInfo vip)
        {
            return dal.UpdVIPInfo(vip);
        }
        /// <summary>
        /// 下拉会员等级
        /// </summary>
        /// <returns></returns>
        public List<VIPgrade> GetVIPgrades()
        {
            return dal.GetVIPgrades();
        }
        /// <summary>
        /// 显示设置会员等级数据
        /// </summary>
        /// <returns></returns>
        public List<VIPInfo> GetVIPgrade()
        {
            return dal.GetVIPgrade();
        }
        /// <summary>
        /// 修改会员等级
        /// </summary>
        /// <param name="vip"></param>
        /// <returns></returns>
        public int UpdVIPgrade(VIPInfo vip)
        {
            return dal.UpdVIPgrade(vip);
        }
        /// <summary>
        /// 增加积分
        /// </summary>
        /// <param name="vip"></param>
        /// <returns></returns>
        public int AddIntegral(VIPInfo vip)
        {
            return dal.AddIntegral(vip);
        }
        /// <summary>
        /// 扣减积分
        /// </summary>
        /// <param name="vip"></param>
        /// <returns></returns>
        public int JIanIntegral(VIPInfo vip)
        {
            return dal.JIanIntegral(vip);
        }
        /// <summary>
        /// 积分清零
        /// </summary>
        /// <param name="vip"></param>
        /// <returns></returns>
        public int ClearIntegral(VIPInfo vip)
        {
            return dal.ClearIntegral(vip);
        }
        /// <summary>
        /// 退款
        /// </summary>
        /// <param name="vip"></param>
        /// <returns></returns>
        public int RePrice(VIPInfo vip)
        {
            return dal.RePrice(vip);
        }
        /// <summary>
        ///会员等级变更记录
        /// </summary>
        /// <returns></returns>
        public List<VIPInfo> SetGrade(string name = "")
        {
            return dal.SetGrade(name);

        }
        /// <summary>
        /// 添加会员等级变动记录
        /// </summary>
        /// <param name="grade"></param>
        /// <returns></returns>
        public int AddGrade(SetGrade grade)
        {
            return dal.AddGrade(grade);
        }
        /// <summary>
        /// 储值管理
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="phone"></param>
        /// <param name="card"></param>
        /// <returns></returns>
        public List<SValuemage> GetSValuemages(int id, string name = "", string phone = "", string card = "")
        {
            return dal.GetSValuemages(id, name, phone, card);
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
            return dal.GetShowMembers(id);
        }
        /// <summary>
        /// 充值/退款记录
        /// </summary>
        /// <returns></returns>
        public List<VIPmoneys> GetVIPmoneys(string name = "")
        {
            return dal.GetVIPmoneys(name);
        }
        /// <summary>
        /// 添加储值-充值退款记录
        /// </summary>
        /// <param name="vips"></param>
        /// <returns></returns>
        public int AddJL(VIPmoneys vips)
        {
            return dal.AddJL(vips);
        }
        /// <summary>
        /// 积分管理
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="phone"></param>
        /// <param name="card"></param>
        /// <returns></returns>
        public List<Pointmanage> GetPointmanages(int id, string name = "", string phone = "", string card = "")
        {
            return dal.GetPointmanages(id, name, phone, card);
        }
        /// <summary>
        /// 积分变动记录
        /// </summary>
        /// <returns></returns>
        public List<PointInfo> GetJFBD(string name = "")
        {
            return dal.GetJFBD(name);
        }
        /// <summary>
        /// 添加积分变动记录
        /// </summary>
        /// <returns></returns>
        public int AddJF(PointInfo point)
        {
            return dal.AddJF(point);
        }
        /// <summary>
        /// 会员设置
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="phone"></param>
        /// <param name="card"></param>
        /// <returns></returns>
        public List<MemberSet> GetMembers()
        {
            return dal.GetMembers();
        }
        /// <summary>
        /// 储值管理的充值
        /// </summary>
        /// <param name="sva"></param>
        /// <returns></returns>
        public int UpdCZ(SValuemage sva)
        {
            return dal.UpdCZ(sva);
        }
        /// <summary>
        /// 储值余额退款1
        /// </summary>
        /// <param name="sva"></param>
        /// <returns></returns>
        public int UpdTK(SValuemage sva)
        {
            return dal.UpdTK(sva);
        }
        /// <summary>
        /// 新增会员类型
        /// </summary>
        /// <param name="mset"></param>
        /// <returns></returns>
        public int AddVIPType(MemberSet mset)
        {
            return dal.AddVIPType(mset);
        }
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="mset"></param>
        /// <returns></returns>
        public int UpdVIPType(MemberSet mset)
        {
            return dal.UpdVIPType(mset);
        }
        /// <summary>
        /// 设置会员条件
        /// </summary>
        /// <param name="funcs"></param>
        /// <returns></returns>
        public int UpdVipwhere(SetFunc funcs)
        {
            return dal.UpdVipwhere(funcs);
        }
        /// <summary>
        /// 支付方式
        /// </summary>
        /// <param name="sets"></param>
        /// <returns></returns>
        public int UpdZF(SetPayment sets)
        {
            return dal.UpdZF(sets);
        }
        /// <summary>
        /// 供应商管理
        /// </summary>
        /// <param name="gid"></param>
        /// <returns></returns>
        public List<SupplierInfo> GetSupplierInfos(string name = "")
        {
            return dal.GetSupplierInfos(name);
        }
        /// <summary>
        /// 回显
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SupplierInfo FindById(int id)
        {
            return dal.FindById(id);
        }
        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        public int UpdSupplier(SupplierInfo supper)
        {
            return dal.UpdSupplier(supper);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Del(int id)
        {
            return dal.Del(id);
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="supper"></param>
        /// <returns></returns>
        public int Add(SupplierInfo supper)
        {
            return dal.Add(supper);
        }
    }
}
