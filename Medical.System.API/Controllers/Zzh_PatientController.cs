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
        public List<Patient> GetPatients(string name = "", int id = 0)
        {
            var list = _Zzh_PatientBLL.GetPatient(name,id);
            return list;
        }
        [RouteAttribute("api/[controller]/ZGetVIPgrade")]
        [HttpGet]
        public List<VIPgrade> ZGetVIPgrade()
        {
            var list = _Zzh_PatientBLL.ZGetVIPgrade();
            return list;
        }
        /// <summary>
        /// 删除患者信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [RouteAttribute("api/[controller]/DelPatient")]
        [HttpPost]
        public int DelPatient(int id=0)
        {
            var list = _Zzh_PatientBLL.DelPatient(id);
            return list;
        }
        /// <summary>
        /// 添加患者信息
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        [RouteAttribute("api/[controller]/AddPatient")]
        [HttpPost]
        public int AddPatient([FromForm]Patient m)
        {
            var list= _Zzh_PatientBLL.AddPatient(m);
            return list;
        }
        /// <summary>
        /// 患者来源下拉
        /// </summary>
        /// <returns></returns>
        [RouteAttribute("api/[controller]/GetPatientSource")]
        [HttpGet]
        public List<PatientSource> GetPatientSource()
        {
            var list= _Zzh_PatientBLL.GetPatientSource();
            return list;
        }
        /// <summary>
        /// 学历下拉
        /// </summary>
        /// <returns></returns>、
        [RouteAttribute("api/[controller]/GetEducation")]
        [HttpGet]
        public List<Education> GetEducation()
        {
            var list = _Zzh_PatientBLL.GetEducation();
            return list;
        }
        /// <summary>
        /// 省下拉
        /// </summary>
        /// <returns></returns>
        [RouteAttribute("api/[controller]/GetProvince")]
        [HttpGet]
        public List<Province> GetProvince()
        {
            var list = _Zzh_PatientBLL.GetProvince();
            return list;
        }
        /// <summary>
        /// 市下拉
        /// </summary>
        /// <returns></returns>
        [RouteAttribute("api/[controller]/GetCity")]
        [HttpGet]
        public List<City> GetCity()
        {
            var list = _Zzh_PatientBLL.GetCity();
            return list;
        }
        /// <summary>
        /// 省市二级联动
        /// </summary>
        /// <returns></returns>
        [RouteAttribute("api/[controller]/GetCitys")]
        [HttpGet]
        public List<City> GetCitys(int provinceId = 0)
        {
            var list = _Zzh_PatientBLL.GetCitys(provinceId);
            return list;
        }
        /// <summary>
        /// 职业下拉
        /// </summary>
        /// <returns></returns>
        [RouteAttribute("api/[controller]/GetPosition")]
        [HttpGet]
        public List<Position> GetPosition()
        {
            var list = _Zzh_PatientBLL.GetPosition();
            return list;
        }
    }
}
