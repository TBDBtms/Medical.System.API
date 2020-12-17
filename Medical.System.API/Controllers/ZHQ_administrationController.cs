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
using Medical.System.Servers;
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
        public IActionResult Getadministration(int tj = 0, string name = "", int pageindex = 1, int pagesize = 10, int bid = 0, int wid = 0)
        {
            return Ok(bll.Getadministration(tj, name, pageindex, pagesize,bid,wid));
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
        /// 查询品牌表
        /// </summary>
        /// <returns></returns>
        /// 
        [Route("api/[Controller]/GetBrand")]
        [HttpGet]
        public IActionResult GetBrand()
        {
            return Ok(bll.GetBrand());
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
        /// <summary>
        /// 修改药品价格根据Id获取单挑数据
        /// </summary>
        /// <returns></returns>
        /// 
        [Route("api/[Controller]/GetFirstPricing")]
        [HttpGet]
        public IActionResult GetFirstPricing(int id = 0)
        {
            return Ok(bll.GetFirstPricing(id));
        }
        /// <summary>
        /// 修改药品价格
        /// </summary>
        /// <param name="id"></param>
        /// <param name="price"></param>
        /// <returns></returns>
        /// 
        [Route("api/[Controller]/UpdPrice2")]
        [HttpGet]
        public int UpdPrice(int id = 0, float price = 0)
        {
            return bll.UpdPrice(id, price);
        }
        /// <summary>
        /// 查询药品调价明细
        /// </summary>
        /// <returns></returns>
        /// 
        [Route("api/[Controller]/GetPricing")]
        [HttpGet]
        public IActionResult GetPricing(int tj = 0, string name = "", int pageindex = 1, int pagesize = 10)
        {
            return Ok(bll.GetPricing(tj, name, pageindex, pagesize));
        }
        /// <summary>
        /// 添加药品调价明细
        /// </summary>
        /// <returns></returns>
        /// 
        [Route("api/[Controller]/AddPricing")]
        [HttpPost]
        public int AddPricing([FromForm]Pricing model)
        {
            return bll.AddPricing(model);
        }
        [Route("api/[Controller]/addimg")]
        [HttpGet]
        public int addimg(string img)
        {
            string sql = $"insert into db1215 values('{img}')";
            return DBhelper.CMD(sql);
        }

    }
}
