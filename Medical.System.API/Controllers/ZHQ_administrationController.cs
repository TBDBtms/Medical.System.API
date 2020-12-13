using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Medical.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Medical.System.BLL;
using Medical.Model.ZHQ;

namespace Medical.System.API.Controllers
{
  
    [ApiController]
    public class ZHQ_administrationController : ControllerBase
    {
        ZHQ_administBLL bll;
        public ZHQ_administrationController(IOptions<ConnectionStrings> conn)
        {
            bll = new ZHQ_administBLL(conn);
        }
        /// <summary>
        /// 显示药品
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [Route("api/[Controller]/Getadministration")]
        [HttpGet]
        public IActionResult Getadministration(int tj = 0, string name = "", int pageindex = 1, int pagesize = 10)
        {
            return Ok(bll.Getadministration(tj, name, pageindex, pagesize));
        }
        /// <summary>
        /// 添加药品
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/[Controller]/Addadministration")]
        public int Addadministration([FromForm]Drug_administration model)
        {
           
            return bll.Addadministration(model);
        }
        /// <summary>
        /// 查询分类表
        /// </summary>
        /// <returns></returns>
        /// 
        [Route("api/[Controller]/Getclassification")]
        [HttpGet]
        public IActionResult Getclassification()
        {
            return Ok(bll.Getclassification());
        }
        /// <summary>
        /// 查询剂型
        /// </summary>
        /// <returns></returns>
        /// 
        [Route("api/[Controller]/Getform")]
        [HttpGet]
        public IActionResult Getform()
        {
            return Ok(bll.Getform());
        }
        /// <summary>
        /// 查询发票
        /// </summary>
        /// <returns></returns>
        /// 
        [Route("api/[Controller]/GetInvoice1")]
        [HttpGet]
        public IActionResult GetInvoice1()
        {
            return Ok(bll.GetInvoice1());
        }
        /// <summary>
        /// 查询厂家
        /// </summary>
        /// <returns></returns>
        /// 
        [Route("api/[Controller]/GetManufacturer")]
        [HttpGet]
        public IActionResult GetManufacturer()
        {
            return Ok(bll.GetManufacturer());
        }
    }
}
