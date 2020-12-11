using Medical.Model;
using Medical.Model.Jcy_Model;
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
    [ApiController]
    public class Zzh_PatientController : ControllerBase
    {
        public IOptions<ConnectionStrings> _conn;
        Zzh_PatientBLL _Zzh_PatientBLL;
        public Zzh_PatientController(IOptions<ConnectionStrings> conn)
        {
            _conn = conn;
            _Zzh_PatientBLL = new Zzh_PatientBLL(conn);

        }
        [RouteAttribute("api/[controller]/GetPatients")]
        [HttpGet]
        public List<Patient> GetPatients()
        {
            var list = _Zzh_PatientBLL.GetPatient();
            return list;
        }
        [RouteAttribute("api/[controller]/ZGetVIPgrade")]
        [HttpGet]
        public List<VIPgrade> ZGetVIPgrade()
        {
            var list = _Zzh_PatientBLL.ZGetVIPgrade();
            return list;
        }
        [RouteAttribute("api/[controller]/DelPatient")]
        [HttpPost]
        public int DelPatient(int id=0)
        {
            var list = _Zzh_PatientBLL.DelPatient(id);
            return list;
        }
    }
}
