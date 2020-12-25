using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Medical.Model.Jcy_Model;
using Medical.System.BLL;
using Medical.Model;
using Microsoft.Extensions.Options;

namespace Medical.System.API.Controllers
{
    [ApiController]
    public class JcyVIPController : ControllerBase
    {
        Jcy_VIPInfoBLL bll;
        public IOptions<ConnectionStrings> _conn;
        public JcyVIPController(IOptions<ConnectionStrings> coon)
        {
            _conn = coon;
            bll = new Jcy_VIPInfoBLL(coon);
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
        /// <returns></returns>11
        [Route("api/[controller]/GetVIPInfos")]
        [HttpGet]
        public IActionResult GetVIPInfos(DateTime? stime, DateTime? etime, int id = 0, string name = "", int flag = 0, int pageindex=1,int pagesize=10)
        {
            var list = bll.GetVIPInfos(stime, etime, id, name, flag);
            int count = list.Count;
            return Ok(new {list=list.Skip((pageindex-1)*pagesize).Take(pagesize),Count=count});
        }
        /// <summary>
        /// 会员设置返填
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="phone"></param>
        /// <param name="card"></param>
        /// <returns></returns>
        [Route("api/[controller]/GetShowMembers")]
        [HttpGet]
        public IActionResult GetShowMembers(int id)
        {
            return Ok(bll.GetShowMembers(id));
        }
        /// <summary>
        /// 余额充值返填信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("api/[controller]/GetById")]
        [HttpGet]
        public IActionResult GetById(int id)
        {
            return Ok(bll.GetById(id));
        }
        /// <summary>
        /// 余额充值
        /// </summary>
        /// <param name="vip"></param>
        /// <returns></returns>
        [Route("api/[controller]/UpdVIPInfo")]
        [HttpPost]
        public IActionResult UpdVIPInfo([FromForm]VIPInfo vip)
        {
            return Ok(bll.UpdVIPInfo(vip));
        }
        /// <summary>
        /// 下拉会员等级
        /// </summary>
        /// <returns></returns>
        [Route("api/[controller]/GetVIPgrades")]
        [HttpGet]
        public IActionResult GetVIPgrades()
        {
            return Ok(bll.GetVIPgrades());
        }
        /// <summary>
        /// 显示设置会员等级数据
        /// </summary>
        /// <returns></returns>
        [Route("api/[controller]/GetVIPgrade")]
        [HttpGet]
        public IActionResult GetVIPgrade()
        {
            return Ok(bll.GetVIPgrade());
        }
        /// <summary>
        /// 修改会员等级
        /// </summary>
        /// <param name="vip"></param>
        /// <returns></returns>
        [Route("api/[controller]/UpdVIPgrade")]
        [HttpPost]
        public IActionResult UpdVIPgrade([FromForm] VIPInfo vip)
        {
            return Ok(bll.UpdVIPgrade(vip));
        }
        /// <summary>
        /// 增加积分
        /// </summary>
        /// <param name="vip"></param>
        /// <returns></returns>
        [Route("api/[controller]/AddIntegral")]
        [HttpPost]
        public IActionResult AddIntegral([FromForm] VIPInfo vip)
        {
            return Ok(bll.AddIntegral(vip));
        }
        /// <summary>
        /// 扣减积分
        /// </summary>
        /// <param name="vip"></param>
        /// <returns></returns>
        [Route("api/[controller]/JIanIntegral")]
        [HttpPost]
        public IActionResult JIanIntegral([FromForm] VIPInfo vip)
        {
            return Ok(bll.JIanIntegral(vip));
        }
        /// <summary>
        /// 积分清零
        /// </summary>
        /// <param name="vip"></param>
        /// <returns></returns>
        [Route("api/[controller]/ClearIntegral")]
        [HttpPost]
        public IActionResult ClearIntegral([FromForm] VIPInfo vip)
        {
            return Ok(bll.ClearIntegral(vip));
        }
        /// <summary>
        /// 退款
        /// </summary>
        /// <param name="vip"></param>
        /// <returns></returns>
        [Route("api/[controller]/RePrice")]
        [HttpPost]
        public IActionResult RePrice([FromForm] VIPInfo vip)
        {
            return Ok(bll.RePrice(vip));
        }
        /// <summary>
        ///会员等级变更记录
        /// </summary>
        /// <returns></returns>
        [Route("api/[controller]/SetGrade")]
        [HttpGet]
        public IActionResult SetGrade(string name="")
        {
            return Ok(bll.SetGrade(name));
        }
        /// <summary>
        /// 储值管理
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="phone"></param>
        /// <param name="card"></param>
        /// <returns></returns>
        [Route("api/[controller]/GetCZ")]
        [HttpGet]
        public IActionResult GetCZ(int id=0,string name="",string phone="",string card="",int flag=0,int pageindex=1,int pagesize=10)
        {
            var list = bll.GetSValuemages(id, name, phone, card,flag);
            int count = list.Count;
            return Ok(new { list = list.Skip((pageindex - 1) * pagesize).Take(pagesize), Count = count });
        }
        /// <summary>
        /// 储值管理的充值
        /// </summary>
        /// <param name="sva"></param>
        /// <returns></returns>
        [Route("api/[controller]/UpdCZ")]
        [HttpPost]
        public IActionResult UpdCZ([FromForm]SValuemage sva)
        {
            return Ok(bll.UpdCZ(sva));
        }
        /// <summary>
        /// 储值余额退款
        /// </summary>
        /// <param name="sva"></param>
        /// <returns></returns>
        [Route("api/[controller]/UpdTK")]
        [HttpPost]
        public IActionResult UpdTK([FromForm]SValuemage sva)
        {
            return Ok(bll.UpdTK(sva));
        }
        /// <summary>
        /// 充值/退款记录
        /// </summary>
        /// <returns></returns>
        [Route("api/[controller]/GetVIPmoneys")]
        [HttpGet]
        public IActionResult GetVIPmoneys(string name="")
        {
            return Ok(bll.GetVIPmoneys(name));
        }
        /// <summary>
        /// 添加储值-充值退款记录
        /// </summary>
        /// <param name="vips"></param>
        /// <returns></returns>
        [Route("api/[controller]/AddJL")]
        [HttpPost]
        public int AddJL([FromForm]VIPmoneys vips)
        {
            return bll.AddJL(vips);
        }
        /// <summary>
        /// 积分管理
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="phone"></param>
        /// <param name="card"></param>
        /// <returns></returns>
        [Route("api/[controller]/GetJF")]
        [HttpGet]
        public IActionResult GetJF(int id = 0, string name = "", string phone = "", string card = "",int flag=0,int pageindex=1,int pagesize=10)
        {
            var list = bll.GetPointmanages(id, name, phone, card,flag);
            int count = list.Count;
            return Ok(new { list = list.Skip((pageindex - 1) * pagesize).Take(pagesize), Count = count });
        }
        /// <summary>
        /// 积分变动记录
        /// </summary>
        /// <returns></returns>
        [Route("api/[controller]/GetJFBD")]
        [HttpGet]
        public IActionResult GetJFBD(string name = "")
        {
            return Ok(bll.GetJFBD(name));
        }
        /// <summary>
        /// 添加积分变动记录
        /// </summary>
        /// <returns></returns>
        [Route("api/[controller]/AddJF")]
        [HttpPost]
        public IActionResult AddJF([FromForm]PointInfo point)
        {
            return Ok(bll.AddJF(point));
        }
        /// <summary>
        /// 会员设置
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="phone"></param>
        /// <param name="card"></param>
        /// <returns></returns>
        [Route("api/[controller]/GetMemberSet")]
        [HttpGet]
        public IActionResult GetMemberSet(int pageindex=1,int pagesize=10)
        {
            var list = bll.GetMembers();
            int count = list.Count;
            return Ok(new { list = list.Skip((pageindex - 1) * pagesize).Take(pagesize), Count = count });
        }
        /// <summary>
        /// 新增会员类型
        /// </summary>
        /// <param name="mset"></param>
        /// <returns></returns>
        [Route("api/[controller]/AddVIPType")]
        [HttpPost]
        public IActionResult AddVIPType([FromForm] MemberSet mset)
        {
            return Ok(bll.AddVIPType(mset));
        }
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="mset"></param>
        /// <returns></returns>
        [Route("api/[controller]/UpdVIPType")]
        [HttpPost]
        public IActionResult UpdVIPType([FromForm] MemberSet mset)
        {
            return Ok(bll.UpdVIPType(mset));
        }
        /// <summary>
        /// 添加会员等级变动记录
        /// </summary>
        /// <param name="grade"></param>
        /// <returns></returns>
        [Route("api/[controller]/AddGrade")]
        [HttpPost]
        public IActionResult AddGrade([FromForm] SetGrade grade)
        {
            return Ok(bll.AddGrade(grade));
        }
        /// <summary>
        /// 设置会员条件
        /// </summary>
        /// <param name="funcs"></param>
        /// <returns></returns>
        [Route("api/[controller]/UpdVipwhere")]
        [HttpPost]
        public IActionResult UpdVipwhere([FromForm]SetFunc funcs)
        {
            return Ok(bll.UpdVipwhere(funcs));
        }
        /// <summary>
        /// 设置支付方式
        /// </summary>
        /// <returns></returns>
        [Route("api/[controller]/UpdZF")]
        [HttpPost]
        public IActionResult UpdZF(SetPayment sets)
        {
            return Ok(bll.UpdZF(sets));
        }
        /// <summary>
        /// 供应商管理
        /// </summary>
        /// <param name="gid"></param>
        /// <returns></returns>
        [Route("api/[controller]/GetSupplierInfos")]
        [HttpGet]
        public IActionResult GetSupplierInfos(string name = "",int pageindex=1,int pagesize=10)
        {
            var list = bll.GetSupplierInfos(name);
            int count = list.Count;
            return Ok(new { list = list.Skip((pageindex - 1) * pagesize).Take(pagesize), Count = count });
        }
        /// <summary>
        /// 回显
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("api/[controller]/FindById")]
        [HttpGet]
        public IActionResult FindById(int id)
        {
            return Ok(bll.FindById(id));
        }
        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        [Route("api/[controller]/UpdSupplier")]
        [HttpPost]
        public IActionResult UpdSupplier([FromForm]SupplierInfo supper)
        {
            return Ok(bll.UpdSupplier(supper));
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("api/[controller]/Del")]
        [HttpPost]
        public IActionResult Del([FromForm]int id)
        {
            return Ok(bll.Del(id));
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="supper"></param>
        /// <returns></returns>
        [Route("api/[controller]/Add")]
        [HttpPost]
        public IActionResult Add([FromForm]SupplierInfo supper)
        {
            return Ok(bll.Add(supper));
        }
    }
}
