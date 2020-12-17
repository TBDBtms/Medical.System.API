using Medical.Model;
using Medical.Model.HZX_Model;
using Medical.System.BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medical.System.API.Controllers
{

    [ApiController]
    public class Hzx_LoginController : ControllerBase
    {
        public IOptions<ConnectionStrings> _conn;
        Hzx_LoginBLL bll;
        public Hzx_LoginController(IOptions<ConnectionStrings> coon)
        {
            _conn = coon;
            bll = new  Hzx_LoginBLL(coon);
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="Uiphone">手机号</param>
        /// <param name="Upass">密码</param>
        /// <returns></returns>
        [RouteAttribute("api/[controller]/Login")]
        [HttpGet]
        public Userinfo Login(string Uname = "", string Upass = "")
        {

            var list = bll.Login(Uname, Upass).FirstOrDefault();
            return list;
        }

        [RouteAttribute("api/[controller]/GetQuanxians")]
        [HttpGet]
        public List<Quanxian> GetQuanxians()
        {
            return bll.GetQuanxians();
        }
        /// <summary>
        /// 显示所有用户
        /// </summary>
        /// <returns></returns>
        [RouteAttribute("api/[controller]/GetUserinfos")]
        [HttpGet]
        public List<Userinfo> GetUserinfos(int Ukeids=0,string Uname="")
        {
            var list = bll.GetUserinfos();
            if (Ukeids>0)
            {
                list = list.Where(m => m.Ukeids == Ukeids).ToList();
            }
            if (!string.IsNullOrEmpty(Uname))
            {
                list = list.Where(m => m.Uname.Contains(Uname)).ToList();
            }
            return list;
        }
        /// <summary>
        /// 角色下拉
        /// </summary>
        /// <returns></returns>
        [RouteAttribute("api/[controller]/GetRoleinfo")]
        [HttpGet]
        public List<Roleinfo> GetRoleinfo()
        {
            var list = bll.GetRoleinfos();
            return list;
        }
        /// <summary>
        /// 获取省下拉
        /// </summary>
        /// <returns></returns>
        [RouteAttribute("api/[controller]/GetMarkets")]
        [HttpGet]
        public List<Market> GetMarkets()
        {
            var list = bll.GetMarkets();
            return list;
        }
        /// <summary>
        /// 回显用户
        /// </summary>
        /// <returns></returns>
        [RouteAttribute("api/[controller]/GetUserinfodan")]
        [HttpGet]
        public Userinfo GetUserinfodan(int Uid)
        {
            var list = bll.GetUserinfodan(Uid);
            return list;
        }
        [RouteAttribute("api/[controller]/GetCounties")]
        [HttpGet]
        public List<County> GetCounties(int Mid)
        {
            
            var list = bll.GetCounties(Mid);
            return list;
        }
        /// <summary>
        /// 配置角色
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        /// 
        [RouteAttribute("api/[controller]/Addquan")]
        [HttpPost]
        public IActionResult Addquan()
        {
            Rqinfo r = new Rqinfo();
            var rid = Request.Form["rid"];
            var qid = Request.Form["qid"];
            r.Qids = qid;
            r.Rids = Convert.ToInt32(rid);
            var list= bll.Addquan(r);
            return Ok(list);



        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        [RouteAttribute("api/[controller]/UpdUser")]
        [HttpPost]
        public int UpdUser([FromForm]Userinfo u)
        {

            var list = bll.Upd(u);
            return list;
        }
        /// <summary>
        /// 科室下拉
        /// </summary>
        /// <param name="Mid"></param>
        /// <returns></returns>
        [RouteAttribute("api/[controller]/GetKeshis")]
        [HttpGet]
        public List<Keshi> GetKeshis()
        {
            var list = bll.GetKeshis();
            return list;
        }
        /// <summary>
        /// 添加员工
        /// </summary>
        /// <returns></returns>       
    
        [RouteAttribute("api/[controller]/AddUserinfo")]
         [HttpPost]
        public int AddUserinfo([FromForm]Userinfo u)
        {
            var list = bll.AddUserinfo(u);
            return list;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Uiphone"></param>
        /// <param name="Upass"></param>
        /// <returns></returns>
        [RouteAttribute("api/[controller]/DelUserinfo")]
        [HttpPost]
        public int DelUserinfo(int Uid)
        {

            var list = bll.DelUserinfo(Uid);
            return list;
        }
        /// 通过用户名修改密码
        /// </summary>
        /// <param name="Uname"></param>
        /// <param name="Upass"></param>
        /// <returns></returns>
        /// 
        /// 
        [RouteAttribute("api/[controller]/UpdPass")]
        [HttpGet]
        public int UpdPass(string Uname="", string Upass="")
        {
            var list = bll.UpdPass(Uname, Upass);
            return list;

        }
        /// <summary>
        /// 找回密码
        /// </summary>
        /// <param name="Uname"></param>
        /// <param name="Upass"></param>
        /// 
        /// <returns></returns>
       [RouteAttribute("api/[controller]/zhao")]
        [HttpGet]
        public int zhao(string Uname="", string Upass="", string Uiphone="")
        {

            return bll.zhao(Uname, Upass, Uiphone);

        }
        /// <summary>
        /// /添加科室
        /// </summary>
        /// <param name="Kname"></param>
        /// <returns></returns>
        /// 
        [RouteAttribute("api/[controller]/Addkeshi")]
        [HttpGet]
        public int Addkeshi(string Kname="")
        {
            return bll.Addkeshi(Kname);

        }
        /// <summary>
        /// 删除科室
        /// </summary>
        /// <param name="Kid"></param>
        /// <returns></returns>
        ///      
       [RouteAttribute("api/[controller]/Delkeshi")]
        [HttpPost]
        public int Delkeshi(int Kid)
        {
            return bll.Delkeshi(Kid);

        }
        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="Rid"></param>
        /// <returns></returns>
        [RouteAttribute("api/[controller]/DelRole")]
        [HttpPost]
        public int DelRole(int Rid)
        {

            return bll.DelRole(Rid);
        }
        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="Rname"></param>
        /// <returns></returns>
        [RouteAttribute("api/[controller]/Addrole")]
        [HttpPost]
        public int Addrole([FromForm]Roleinfo r)
        {

            return bll.Addrole(r);
        }

    }
}
