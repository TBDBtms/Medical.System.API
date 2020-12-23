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
        /// <summary>
        /// 添加入库信息进行入库
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
        [HttpGet]
        [Route("api/[controller]/AddRKB")]
        public int AddRKB(int id)
        {
            return bll.AddRKB(id);
        }
        /// <summary>
        /// 查询入库信息表
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpGet]
        [Route("api/[controller]/GetRKB")]
        public List<RKB> GetRKB()
        {
            return bll.GetRKB();
        }
        /// <summary>
        /// 入库拒绝
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
        [HttpGet]
        [Route("api/[controller]/RKJU")]
        public int RKJU(int id)
        {
            return bll.RKJU(id);
        }
        /// <summary>
        /// 加库存
        /// </summary>
        /// <param name="num"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
        [HttpGet]
        [Route("api/[controller]/JiaNum")]
        public int JiaNum(int num, int id,int rid)
        {
            return bll.JiaNum(num, id,rid);
        }
        /// <summary>
        /// 删除入库申请记录单挑删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
        [HttpGet]
        [Route("api/[controller]/DelRKSQ")]
        public int DelRKSQ(int id)
        {
            return bll.DelRKSQ(id);
        }
        /// <summary>
        /// 删除入库通过表单挑数据删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
        [HttpGet]
        [Route("api/[controller]/DelRKB")]
        public int DelRKB(int id)
        {
            return bll.DelRKB(id);
        }
    }
}
