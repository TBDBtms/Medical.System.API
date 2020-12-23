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
    public class DLH_PrincController : ControllerBase
    {
        D_Principleaction_BLL bll;
        public IOptions<ConnectionStrings> _conn;
        public DLH_PrincController(IOptions<ConnectionStrings> coon)
        {
            _conn = coon;
            bll = new D_Principleaction_BLL(coon);
        }

        [HttpGet]
        [RouteAttribute("api/[controller]/GetDate")]
        /// <summary>
        /// 显示既往病例信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        //public Page<Principleaction> GetPage(int tj,string name,int pageIndex,int pageSize)
        //{
        //    var list = bll.GetPage(tj, name, pageIndex, pageSize);
        //    foreach (var item in list.PageList)
        //    {
        //        item.time = item.PastTable.ToString("yyyy-MM-dd");
        //    }
        //    return list;
        //}
        public IActionResult GetDate(int pageIndex = 1, int pageSize = 10)
        {
            var list = bll.GetDate();
            foreach (var item in list)
            {
                item.time = item.CaseTable.ToString("yyyy-MM-dd");
            }

            int count = list.Count;
            return Ok(new { list = list.Skip((pageIndex - 1) * pageSize).Take(pageSize), Count = count });
        }
        

        [HttpPost]
        [Route("api/[controller]/DeletePrinc")]
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public int DeletePrinc(int cid)
        {
            var list = bll.DeletePrincipleaction(cid);
            return list;
        }
    }
}
