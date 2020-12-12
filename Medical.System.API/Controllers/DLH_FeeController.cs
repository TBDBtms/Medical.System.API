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
        public List<PrescriptionInfo> GetPrescriptionInfos()
        {
            var list = bll.GetPrescriptionInfos();
            return list;
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
            var list = bll.GetCostsInfos(name,pid);
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
        public int ModifyCost(CostsInfo model)
        {
            var list = bll.ModifyCost(model);
            return list;
        }
        [RouteAttribute("api/[controller]/FXCost")]
        [HttpPost]
        /// <summary>
        /// 修改附加回显
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public CostsInfo FXCost(int cid)
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
        public int FYStart(CostsInfo c)
        {
            var list = bll.FYStart(c);
            return list;
        }
        
        [RouteAttribute("api/[controller]/VIPZheko")]
        [HttpPost]
        /// <summary>
        /// 会员状态为否
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public int VIPZheko(CostsInfo c)
        {
            var list = bll.VIPZheko(c);
            return list;
        }
        
    }
}
