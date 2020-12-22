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
    public class DLH_CaseController : ControllerBase
    {
        D_Settings bll;
        public IOptions<ConnectionStrings> _conn;
        public DLH_CaseController(IOptions<ConnectionStrings> coon)
        {
            _conn = coon;
            bll = new D_Settings(coon);
        }

        [HttpGet]
        [RouteAttribute("api/[controller]/GetCaseInfos")]
        /// <summary>
        /// 显示诊断信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Page<CaseInfo> GetCaseInfos(int tj = 0, string name = "", int pageindex = 1, int pagesize = 10)
        {
            var list = bll.GetCaseInfos(tj, name, pageindex, pagesize);
            foreach (var item in list.PageList)
            {
                item.time = item.CaseTable.ToString("yyyy-MM-dd");
            }
            return list;
        }
        [HttpPost]
        [Route("api/[controller]/CassAdd")]
        /// <summary>
        /// 添加诊断信息
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public int CassAdd([FromForm]CaseInfo c)
        {
            var list = bll.CassAdd(c);
            return list;
        }
        [HttpPost]
        [Route("api/[controller]/CaseModify")]
        /// <summary>
        /// 修改诊断信息
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public int CaseModify([FromForm]CaseInfo c)
        {
            var list = bll.CaseModify(c);
            return list;
        }
        [HttpGet]
        [Route("api/[controller]/GetCase")]
        /// <summary>
        /// 回显
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public CaseInfo GetCase(int cid=0)
        {
            var list = bll.GetCase(cid);
            return list;
        }
        [HttpPost]
        [Route("api/[controller]/DeleteCase")]
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public int DeleteCase(int cid)
        {
            var list = bll.DeleteCase(cid);
            return list;
        }
    }
}
