using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Medical.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Medical.System.BLL;
namespace Medical.System.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZHQ_FirstController : ControllerBase
    {
        ZHQ_FirstBLL bll;
        public ZHQ_FirstController(IOptions<ConnectionStrings> conn)
        {
            bll = new ZHQ_FirstBLL(conn);
        }

        [Route("GetDrug_administration")]
        [HttpGet]
        public IActionResult GetDrug_administration()
        {
            return Ok(bll.GetDrug_administration());
        }
    }
}
