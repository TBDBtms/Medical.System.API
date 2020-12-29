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
    public class ZHQ_CKController : ControllerBase
    {
        ZHQ_CKBLL bll;
        public ZHQ_CKController(IOptions<ConnectionStrings> conn)
        {
            bll = new ZHQ_CKBLL(conn);
        }
        /// <summary>
        /// 添加出库申请
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// 
        [HttpPost]
        [Route("api/[controller]/AddCKSQ")]
        public int AddCKSQ([FromForm]CKSQ model)
        {
            model.CKSQState = 1;
            return bll.AddCKSQ(model);
        }
        /// <summary>
        /// 查询出库申请
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpGet]
        [Route("api/[controller]/GetCKSQ")]
        public IActionResult GetCKSQ()
        {
            var list = bll.GetCKSQ();
           
            return Ok(list);
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
        /// <summary>
        /// 出库拒绝
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
        [HttpGet]
        [Route("api/[controller]/CKJU")]
        public int CKJU(int id)
        {
            return bll.CKJU(id);
        }
        /// <summary>
        /// 出库
        /// </summary>
        /// <param name="id"></param>
        /// <param name="num"></param>
        /// <param name="tid"></param>
        /// <returns></returns>
        /// 
        [HttpGet]
        [Route("api/[controller]/CKNUM")]
        public double CKNUM(int id, int num, int tid)
        {
            return bll.CKNUM(id, num, tid);
        }
        /// <summary>
        /// 如果库存不做申请数量出已有库存的数量
        /// </summary>
        /// <param name="xnum"></param>
        /// <param name="tid"></param>
        /// <returns></returns>
        /// 
        [HttpGet]
        [Route("api/[controller]/CXNUM")]
        public int CXNUM(int xnum, int tid,int id)
        {
            return bll.CXNUM(xnum, tid,id);
        }
        /// <summary>
        /// 删除出库成功或出库拒绝信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
        [HttpGet]
        [Route("api/[controller]/DelCK")]
        public int DelCK(int id)
        {
            return bll.DelCK(id);
        }
    }
}
