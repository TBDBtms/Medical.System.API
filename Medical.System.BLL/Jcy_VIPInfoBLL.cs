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
        public List<VIPInfo> GetVIPInfos(DateTime? stime, DateTime? etime, int id = 0, string name = "", string phone = "", string card = "")
        {
            return dal.GetVIPInfos(stime, etime, id, name, phone, card);
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
            return dal.UpdVIPgrade(vip);
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
        public List<VIPInfo> SetGrade()
        {
            return dal.SetGrade();
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
            return dal.GetSValuemages(id,name,phone,card);
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
    }
}
