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
        public IActionResult  GetUserinfos(int Ukeids=0,string Uname="",int pageindex=1,int pagesize=10)
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
            int count = list.Count;
            return Ok(new { list = list.Skip((pageindex - 1) * pagesize).Take(pagesize), Count = count });
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
        [HttpPost]
        public int zhao([FromForm]Userinfo u)
        {
            return bll.zhao(u);


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
        /// <summary>
        /// 获取接诊类型
        /// </summary>
        /// <returns></returns>
        [RouteAttribute("api/[controller]/GetJZtypes")]
        [HttpGet]
        public List<JZtype> GetJZtypes()
        {
            return bll.GetJZtypes();


        }
        /// <summary>
        /// 添加挂号信息
        /// </summary>
        /// <returns></returns>
        [RouteAttribute("api/[controller]/AddGua")]
        [HttpPost]
        public int AddGua([FromForm]X_Guahao g)
        {
            return bll.AddGua(g);

        }
        /// <summary>
        /// 显示挂号单
        /// </summary>
        /// <returns></returns>
        [RouteAttribute("api/[controller]/GetX_Guahaos")]
        [HttpGet]
        public IActionResult GetX_Guahaos(int kid=0,string yname="",int pageindex=1,int pagesize=2)
        {
            
            var list= bll.GetX_Guahaos();
            if (kid > 0)
            {
                list = list.Where(m => m.ksids == kid).ToList();

            }
            if (!string.IsNullOrEmpty(yname))
            {
                list = list.Where(m => m.Yname.Contains(yname)).ToList();
            }

            int count = list.Count;
            return Ok(new { list = list.Skip((pageindex - 1) * pagesize).Take(pagesize), Count = count });

        }
        //退号
        [RouteAttribute("api/[controller]/Delhao")]
        [HttpPost]
        public int Delhao(int gid)
        {
            return bll.Delhao(gid);

        }
        /// <summary>
        /// 获取单条挂号信息
        /// </summary>
        /// <param name="Gid"></param>
        /// <returns></returns>
        [RouteAttribute("api/[controller]/GetX_Guahaosdan")]
        [HttpGet]
        public X_Guahao GetX_Guahaosdan(int Gid)
        {
            return bll.GetX_Guahaosdan(Gid);

        }
        /// <summary>
        /// 修改挂号信息
        /// </summary>
        /// <param name="g"></param>
        /// <returns></returns>
        [RouteAttribute("api/[controller]/UpdGua")]
        [HttpPost]
        public int UpdGua([FromForm]X_Guahao g)
        {
            return bll.UpdGua(g);
        }
        /// <summary>
        //修改状态
        /// </summary>
        /// <param name="Gid"></param>
        /// <returns></returns>
        [RouteAttribute("api/[controller]/Updissale")]
        [HttpPost]
        public int Updissale(int Gid)
        {
            return bll.Updissale(Gid);


        }
        /// <summary>
        /// 添加处方
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        [RouteAttribute("api/[controller]/AddJzhospital")]
        [HttpPost]
        public int AddJzhospital([FromForm]Chufang c)
        {
            return bll.AddJzhospital(c);

        }
        /// <summary>
        /// 显示病例
        /// </summary>
        /// <returns></returns>
        [RouteAttribute("api/[controller]/GetChufangs")]
        [HttpGet]
        public IActionResult GetChufangs(int Jztid=0, string Hname="",int pageindex=1,int pagesize=2)
        {
            var list= bll.GetChufangs();
            if (Jztid>0)
            {
                list = list.Where(m => m.Jztid == Jztid).ToList();
            }
            if (!string.IsNullOrEmpty(Hname))
            {
                list = list.Where(m => m.Hname.Contains(Hname)).ToList();
            }
            int count = list.Count;
            return Ok(new { list = list.Skip((pageindex - 1) * pagesize).Take(pagesize), Count = count });


        }
        //插入登录记录
        [RouteAttribute("api/[controller]/AddJlu")]
        [HttpPost]
        public int AddJlu([FromForm]Jlu j)
        {
            return bll.AddJlu(j);


        }
        /// <summary>
        /// 登入记录
        /// </summary>
        /// <returns></returns>
        [RouteAttribute("api/[controller]/GetJlus")]
        [HttpGet]
        public IActionResult GetJlus(int pageindex = 1, int pagesize = 2)
        {
            var list=bll.GetJlus();
            int count = list.Count;
            return Ok(new { list = list.Skip((pageindex - 1) * pagesize).Take(pagesize), Count = count });
        }
        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="Jid"></param>
        /// <returns></returns>
        /// 
        [RouteAttribute("api/[controller]/Deljlu")]
        [HttpPost]
        public int Deljlu(int Jid)
        {
            return bll.Deljlu(Jid);

        }
    }
}

