using Medical.Model;
using Medical.Model.DLH_Medical.Model;
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
    public class DLH_FeeController : ControllerBase
    {
        D_Fee_BLL bll;
        public IOptions<ConnectionStrings> _conn;
        public DLH_FeeController(IOptions<ConnectionStrings> coon)
        {
            _conn = coon;
            bll = new D_Fee_BLL(coon);
        }
        [HttpGet]
        [RouteAttribute("api/[controller]/GetPrescriptionInfos")]

        /// <summary>
        /// 查询处方类型
        /// </summary>
        /// <returns></returns>
        public IActionResult GetPrescriptionInfos()
        {
            return Ok(bll.GetPrescriptionInfos());
        }
        [HttpGet]
        [RouteAttribute("api/[controller]/GetCostsInfos")]
        /// <summary>
        /// 附加费用设置
        /// </summary>
        /// <param name="name">费用名称</param>
        /// <param name="pid">处方类别</param>
        /// <returns></returns>
        public List<CostsInfo> GetCostsInfos(string name = "", int pid = 0)
        {
            var list = bll.GetCostsInfos(name, pid);
            foreach (var item in list)
            {
                item.time = item.CTime.ToString("yyyy-MM-dd");
            }
            return list;
        }
        [HttpPost]
        [RouteAttribute("api/[controller]/DelCost")]
        /// <summary>
        /// 删除附加费用
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public int DelCost(int cid)
        {
            var list = bll.DelCost(cid);
            return list;
        }
        [RouteAttribute("api/[controller]/ModifyCost")]
        [HttpPost]
        /// <summary>
        /// 修改附加费用
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public IActionResult ModifyCost([FromForm] CostsInfo model)
        {
            return Ok(bll.ModifyCost(model));
        }
        [RouteAttribute("api/[controller]/FXCost")]
        [HttpGet]
        /// <summary>
        /// 修改附加回显
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public CostsInfo FXCost(int cid = 0)
        {
            var list = bll.FXCost(cid);
            return list;
        }
        [RouteAttribute("api/[controller]/FYStart")]
        [HttpPost]
        /// <summary>
        /// 判断费用状态开始
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public IActionResult FYStart(CostsInfo c)
        {
            return Ok(bll.FYStart(c));
        }

        [RouteAttribute("api/[controller]/VIPZheko")]
        [HttpPost]
        /// <summary>
        /// 会员状态为否
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public IActionResult VIPZheko(CostsInfo c)
        {
            return Ok(bll.VIPZheko(c));
        }
        [HttpPost]
        [RouteAttribute("api/[controller]/AddCost")]
        /// <summary>
        /// 添加附加费用
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public IActionResult AddCost([FromForm] CostsInfo c)
        {
            return Ok(bll.AddCost(c));
        }


        ///====================================================================================================================
        [HttpGet]
        [RouteAttribute("api/[controller]/GetConsultations")]
        /// <summary>
        /// 诊疗费设置
        /// </summary>
        /// <param name="name">费用名称</param>
        /// <param name="pid">处方类别</param>
        /// <returns></returns>
        public List<Consultation> GetConsultations(string name = "")
        {
            var list = bll.GetConsultations(name);
            foreach (var item in list)
            {
                item.time = item.ZLTime.ToString("yyyy-MM-dd");
            }
            return list;
        }

        [HttpPost]
        [RouteAttribute("api/[controller]/DelConsultations")]
        /// <summary>
        /// 删除诊疗费用
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public int DelConsultations(int cid)
        {
            return bll.DelConsultations(cid);
        }

        [HttpPost]
        [RouteAttribute("api/[controller]/AddConsultations")]
        /// <summary>
        /// 添加诊疗费用
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public IActionResult AddConsultations([FromForm] Consultation c)
        {
            //c.CTime = DateTime.Now;
            return Ok(bll.AddConsultations(c));
        }

        [RouteAttribute("api/[controller]/ModifyConsultations")]
        [HttpPost]
        /// <summary>
        /// 修改诊疗费用
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public IActionResult ModifyConsultations([FromForm] Consultation model)
        {
            return Ok(bll.ModifyConsultations(model));
        }

        [RouteAttribute("api/[controller]/FXConsultations")]
        [HttpGet]
        /// <summary>
        /// 修改诊疗费回显
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public Consultation FXConsultations(int cid = 0)
        {
            var list = bll.FXConsultations(cid);
            return list;
        }

        //===============================挂号=================================================
        [HttpGet]
        [RouteAttribute("api/[controller]/GetRegistrations")]
        /// <summary>
        /// 挂号费设置
        /// </summary>
        /// <param name="name">费用名称</param>
        /// <returns></returns>
        public List<Registration> GetRegistrations(string name = "")
        {
            var list = bll.GetRegistrations(name);
            foreach (var item in list)
            {
                item.time = item.GHTime.ToString("yyyy-MM-dd");
            }
            return list;
        }
        [HttpPost]
        [RouteAttribute("api/[controller]/DelRegistration")]
        /// <summary>
        /// 删除挂号费用
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public int DelRegistration(int cid)
        {
            var list = bll.DelRegistration(cid);
            return list;
        }
        [HttpPost]
        [RouteAttribute("api/[controller]/AddRegistration")]
        /// <summary>
        /// 添加挂号费用
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public IActionResult AddRegistration([FromForm]Registration c)
        {
            return Ok(bll.AddRegistration(c));
        }
        [RouteAttribute("api/[controller]/ModifyRegistration")]
        [HttpPost]
        /// <summary>
        /// 修改挂号费用
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public IActionResult ModifyRegistration([FromForm]Registration model)
        {
            return Ok(bll.ModifyRegistration(model));
         
        }
        [RouteAttribute("api/[controller]/FXRegistration")]
        [HttpGet]
        /// <summary>
        /// 修改挂号回显
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public Registration FXRegistration(int cid = 0)
        {
            var list = bll.FXRegistration(cid);
            return list;
        }
    }
}
