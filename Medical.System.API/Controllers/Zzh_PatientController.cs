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
        public List<Patient> GetPatients(DateTime? sdate, DateTime? edate, string name = "", int id = 0, int pid = 0)
        {
            var list = _Zzh_PatientBLL.GetPatient(sdate,edate,name,id,pid);

            return list;
        }
        [RouteAttribute("api/[controller]/GetMemberType")]
        [HttpGet]
        public List<MemberType> GetMemberType()
        {
            var list = _Zzh_PatientBLL.GetMemberType();
            return list;
        }
        /// <summary>
        /// 患者状态
        /// </summary>
        /// <returns></returns>
        [RouteAttribute("api/[controller]/GetPatientState")]
        [HttpGet]
        public List<PatientState> GetPatientState()
        {
            var list = _Zzh_PatientBLL.GetPatientState();
            return list;
        }
        /// <summary>
        /// 操作人
        /// </summary>
        /// <returns></returns>
        [RouteAttribute("api/[controller]/GetCaoZuoRen")]
        [HttpGet]
        public List<CaoZuoRen> GetCaoZuoRen()
        {
            var list = _Zzh_PatientBLL.GetCaoZuoRen();
            return list;
        }
        /// <summary>
        /// 科室
        /// </summary>
        /// <returns></returns>
        [RouteAttribute("api/[controller]/GetDepartment")]
        [HttpGet]
        public List<Department> GetDepartment()
        {
            var list = _Zzh_PatientBLL.GetDepartment();
            return list;
        }
        /// <summary>
        /// 家庭关系
        /// </summary>
        /// <returns></returns>
        [RouteAttribute("api/[controller]/GetFamilyTies")]
        [HttpGet]
        public List<FamilyTies> GetFamilyTies()
        {
            var list = _Zzh_PatientBLL.GetFamilyTies();
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
        /// 修改患者信息
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        [RouteAttribute("api/[controller]/UpdPatient")]
        [HttpPost]
        public int UpdPatient([FromForm]Patient m)
        {
            var list = _Zzh_PatientBLL.UpdPatient(m);
            return list;
        }
        /// <summary>
        /// 修改患者会员
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        [RouteAttribute("api/[controller]/UpdPat")]
        [HttpPost]
        public int UpdPat([FromForm]Patient m)
        {
            var list = _Zzh_PatientBLL.UpdPat(m);
            return list;
        }
        /// <summary>
        /// 回显患者信息
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        [RouteAttribute("api/[controller]/ShowPatient")]
        [HttpGet]
        public Patient ShowPatient(int patientId=0)
        {
            var list= _Zzh_PatientBLL.ShowPatient(patientId);
            return list;
        }
    }
}
