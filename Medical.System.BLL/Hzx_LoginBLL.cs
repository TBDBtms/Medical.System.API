using Medical.Model;
using Medical.System.Servers;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using Medical.Model.HZX_Model;
namespace Medical.System.BLL
{
  public  class Hzx_LoginBLL
    {
        Hzx_LoginDal dal;
        public Hzx_LoginBLL(IOptions<ConnectionStrings> coon)
        {
            dal = new Hzx_LoginDal(coon);
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public List<Userinfo> Login(string Uiphone, string Upass)
        {
            return dal.Login(Uiphone, Upass);
        }
        /// <summary>
        /// 获取所有员工信息
        /// </summary>
        /// <returns></returns>
        public List<Userinfo> GetUserinfos()
        {
            return dal.GetUserinfos();
        }
        /// <summary>
        /// 添加员工
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int AddUserinfo(Userinfo u)
        {
            return dal.AddUserinfo(u);
        }
        /// <summary>
        /// 回显获取单条数据
        /// </summary>
        /// <param name="Uid"></param>
        /// <returns></returns>
        public Userinfo GetUserinfodan(int Uid)
        {
            return dal.GetUserinfodan(Uid);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int Upd(Userinfo u)
        {
            return dal.Upd(u);

        }
        public int DelUserinfo(int Uid)
        {
            return dal.DelUserinfo(Uid);
        }
        /// <summary>
        /// 角色下拉
        /// </summary>
        /// <returns></returns>
        public List<Roleinfo> GetRoleinfos()
        {
            return dal.GetRoleinfos();
        }
        /// <summary>
        /// 县级下拉
        /// </summary>
        /// <returns></returns>
        public List<Market> GetMarkets()
        {
            return dal.GetMarkets();
        }
        /// <summary>
        /// 市下拉
        /// </summary>
        /// <param name="Mid"></param>
        /// <returns></returns>
        public List<County> GetCounties(int Mid)
        {
            return dal.GetCounties(Mid);
        }
        /// <summary>
        /// 科室下拉
        /// </summary>
        /// <returns></returns>
        public List<Keshi> GetKeshis()
        {
            return dal.GetKeshis();

        }
    }
}
