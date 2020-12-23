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
        public List<Userinfo> Login(string Uname, string Upass)
        {
            return dal.Login(Uname, Upass);
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
        /// 权限下拉
        /// </summary>
        /// <returns></returns>
        public List<Quanxian> GetQuanxians()
        {
            return dal.GetQuanxians();
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
        /// <summary>
        /// 配置角色
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public bool Addquan(Rqinfo r)
        {
            return dal.Addquan(r);



        } /// <summary>
          /// 通过用户名修改密码
          /// </summary>
          /// <param name="Uname"></param>
          /// <param name="Upass"></param>
          /// <returns></returns>
        public int UpdPass(string Uname, string Upass)
        {
            return dal.UpdPass(Uname, Upass);


        }
        /// <summary>
        /// 找回密码
        /// </summary>
        /// <param name="Uname"></param>
        /// <param name="Upass"></param>
        /// <returns></returns>
        public int zhao(Userinfo u)
        {
            return dal.zhao(u);


        }
        /// <summary>
        /// /添加科室
        /// </summary>
        /// <param name="Kname"></param>
        /// <returns></returns>
        public int Addkeshi(string Kname)
        {
            return dal.Addkeshi(Kname);

        }
        /// <summary>
        /// 删除科室
        /// </summary>
        /// <param name="Kid"></param>
        /// <returns></returns>
        public int Delkeshi(int Kid)
        {
            return dal.Delkeshi(Kid);

        }
        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="Rid"></param>
        /// <returns></returns>
        public int DelRole(int Rid)
        {

            return dal.DelRole(Rid);
        }
        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="Rname"></param>
        /// <returns></returns>
        public int Addrole(Roleinfo r)
        {

            return dal.Addrole(r);
        }
        /// <summary>
           /// 获取接诊类型
           /// </summary>
           /// <returns></returns>
        public List<JZtype> GetJZtypes()
        {
            return dal.GetJZtypes();


        }
        /// <summary>
        /// 添加挂号信息
        /// </summary>
        /// <returns></returns>
        public int AddGua(X_Guahao g)
        {
            return dal.AddGua(g);

        } /// <summary>
          /// 显示挂号单
          /// </summary>
          /// <returns></returns>
        public List<X_Guahao> GetX_Guahaos()
        {
            return dal.GetX_Guahaos();

        }   //退号
        public int Delhao(int gid)
        {
            return dal.Delhao(gid);

        }
        /// <summary>
        /// 获取单条挂号信息
        /// </summary>
        /// <param name="Gid"></param>
        /// <returns></returns>
        public X_Guahao GetX_Guahaosdan(int Gid)
        {
            return dal.GetX_Guahaosdan(Gid);

        }
        /// <summary>
        /// 修改挂号信息
        /// </summary>
        /// <param name="g"></param>
        /// <returns></returns>
        public int UpdGua(X_Guahao g)
        {
            return dal.UpdGua(g);
        }
        /// <summary>
        //修改状态
        /// </summary>
        /// <param name="Gid"></param>
        /// <returns></returns>
        public int Updissale(int Gid)
        {
            return dal.Updissale(Gid);


        }
        /// <summary>
        /// 添加处方
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public int AddJzhospital(Chufang c)
        {
            return dal.AddJzhospital(c);

        }
        /// <summary>
        /// 显示病例
        /// </summary>
        /// <returns></returns>
        public List<Chufang> GetChufangs()
        {
            return dal.GetChufangs();


        }
        //插入登录记录
        public int AddJlu(Jlu j)
        {
            return dal.AddJlu(j);


        }
        /// <summary>
        /// 登入记录
        /// </summary>
        /// <returns></returns>
        public List<Jlu> GetJlus()
        {
            return dal.GetJlus();
        }
        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="Jid"></param>
        /// <returns></returns>
        public int Deljlu(int Jid)
        {
            return dal.Deljlu(Jid);

        }
    }
}
