using Medical.Model.DLH_Medical.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using System.Data;
using System.Data.SqlClient;
using Medical.System.BLL;
using Medical.Model;


namespace Medical.System.API.Controllers
{
    [ApiController]
    public class DLH_Charge : ControllerBase
    {
        public IOptions<ConnectionStrings> _conn;
        D_Charge_BLL bll;
        public DLH_Charge (IOptions<ConnectionStrings> conn)
        {
            _conn = conn;
            bll = new D_Charge_BLL(conn);
        }
        [HttpGet]
        [Route("api/[controller]/GetD_Charge_Statistics")]
        /// <summary>
        /// 显示收费信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public IActionResult GetD_Charge_Statistics(string name="",int pageindex=1,int pagesize=10)
        {
            var list = bll.GetD_Charge_Statistics(name,pageindex,pagesize);
            int Count = list.Count;
            return Ok(new { list = list.Skip((pageindex - 1) * pageindex).Take(pagesize), Count = Count });
        }
    }
}
