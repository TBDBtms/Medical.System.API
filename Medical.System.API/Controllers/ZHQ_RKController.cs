using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Medical.Model;
using Medical.Model.ZHQ;
using Medical.System.BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
namespace Medical.System.API.Controllers
{
    
    [ApiController]
    public class ZHQ_RKController : ControllerBase
    {
        ZHQ_RKBLL bll;
        public ZHQ_RKController(IOptions<ConnectionStrings> conn)
        {
            bll = new ZHQ_RKBLL(conn);
        }
        /// <summary>
        /// 添加申请
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// 
        [HttpPost]
        [Route("api/[controller]/AddRKSQ")]
        public int AddRKSQ([FromForm]RKSQ model)
        {
            model.RKSQState = 1;
            return bll.AddRKSQ(model);
        }
        /// <summary>
        /// 查询申请信息表
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpGet]
        [Route("api/[controller]/GetRKSQ")]
        public IActionResult GetRKSQ()
        {
            var list= Ok(bll.GetRKSQ());
            return list;
        }
        /// <summary>
        /// 修改申批状态
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tgstate"></param>
        /// <returns></returns>
        /// 
        [HttpGet]
        [Route("api/[controller]/UpdState")]
        public int UpdState(int id, int tgstate)
        {
            return bll.UpdState(id, tgstate);
        }
    }
}
