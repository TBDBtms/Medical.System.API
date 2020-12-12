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
    public class ZHQ_administrationController : ControllerBase
    {
        ZHQ_administBLL bll;
        public ZHQ_administrationController(IOptions<ConnectionStrings> conn)
        {
            bll = new ZHQ_administBLL(conn);
        }
        [Route("Getadministration")]
        [HttpGet]
        public IActionResult Getadministration(string name="")
        {
            return Ok(bll.Getadministration(name));
        }
    }
}
