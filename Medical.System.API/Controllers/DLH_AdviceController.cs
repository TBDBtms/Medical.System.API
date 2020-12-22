using Medical.Model;
using Medical.Model.DLH_Medical.Model;
using Medical.Model.ZHQ;
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
    public class DLH_AdviceController : ControllerBase
    {
        D_Advice_BLL bll;
        public IOptions<ConnectionStrings> _conn;
        public DLH_AdviceController(IOptions<ConnectionStrings> conn)
        {
            _conn = conn;
            bll = new D_Advice_BLL(conn);
        }
        [Route("api/[controller]/GetAdvice")]
        [HttpGet]
        /// <summary>
        /// 显示诊断信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>

        public Page<Advice> GetAdvice(int tj = 0, string name = "", int pageindex = 1, int pagesize = 10)
        {
            var list = bll.GetAdvice(tj, name, pageindex, pagesize);
            foreach (var item in list.PageList)
            {
                item.time = item.AdviceTable.ToString("yyyy-MM-dd");
            }

            return list;
        }
        [HttpPost]
        [Route("api/[controller]/AdviceAdd")]
        /// <summary>
        /// 添加诊断信息
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public IActionResult AdviceAdd([FromForm] Advice c)
        {
            return Ok(bll.AdviceAdd(c));
        }
        [HttpPost]
        [Route("api/[controller]/AdviceModify")]
        /// <summary>
        /// 修改诊断信息
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public IActionResult AdviceModify([FromForm] Advice c)
        {
            return Ok(bll.AdviceModify(c));
        }
        [HttpGet]
        [Route("api/[controller]/GetAdvices")]
        /// <summary>
        /// 回显
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public Advice GetAdvices(int cid = 0)
        {
            return bll.GetAdvices(cid);
        }
        [HttpPost]
        [Route("api/[controller]/DeleteAdvice")]
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public IActionResult DeleteAdvice(int cid)
        {
            return Ok(bll.DeleteAdvice(cid));
        }

    }
}
