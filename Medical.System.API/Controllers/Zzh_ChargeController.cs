using Medical.Model;
using Medical.Model.ZZH_Model;
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
    [Route("api/[controller]")]
    [ApiController]
    public class Zzh_ChargeController : ControllerBase
    {
        public IOptions<ConnectionStrings> _conn;
        Zzh_ChargeBLL _Zzh_ChargeBLL;
        public Zzh_ChargeController(IOptions<ConnectionStrings> conn)
        {
            _conn = conn;
            _Zzh_ChargeBLL = new Zzh_ChargeBLL(conn);
        }
    }
}
