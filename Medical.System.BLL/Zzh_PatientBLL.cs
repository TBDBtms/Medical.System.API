using Medical.Model;
using Medical.Model.Jcy_Model;
using Medical.Model.ZZH_Model;
using Medical.System.Servers;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace Medical.System.BLL
{
    public class Zzh_PatientBLL
    {
        public IOptions<ConnectionStrings> _conn;
        Zzh_PatientServers _Zzh_PatientServers;
        public Zzh_PatientBLL(IOptions<ConnectionStrings> conn)
        {
            _conn = conn;
            _Zzh_PatientServers = new Zzh_PatientServers(conn);

        }
        /// <summary>
        /// 患者管理显示界面
        /// </summary>
        /// <returns></returns>
        public List<Patient> GetPatient(string name = "", int id = 0)
        {
            return _Zzh_PatientServers.GetPatient(name,id);
        }
        /// <summary>
        /// 会员等级下拉
        /// </summary>
        /// <returns></returns>
        public List<VIPgrade> ZGetVIPgrade()
        {
            return _Zzh_PatientServers.ZGetVIPgrade();
        }
        /// <summary>
        /// 删除患者信息
        /// </summary>
        /// <returns></returns>
        public int DelPatient(int id = 0)
        {
            return _Zzh_PatientServers.DelPatient(id);
        }
        /// <summary>
        /// 添加患者信息
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public int AddPatient(Patient m)
        {
            return _Zzh_PatientServers.AddPatient(m);
        }
        /// <summary>
        /// 患者来源下拉
        /// </summary>
        /// <returns></returns>
        public List<PatientSource> GetPatientSource()
        {
            return _Zzh_PatientServers.GetPatientSource();
        }
        /// <summary>
        /// 学历下拉
        /// </summary>
        /// <returns></returns>
        public List<Education> GetEducation()
        {
            return _Zzh_PatientServers.GetEducation();
        }
        /// <summary>
        /// 省下拉
        /// </summary>
        /// <returns></returns>
        public List<Province> GetProvince()
        {
            return _Zzh_PatientServers.GetProvince();
        }
        /// <summary>
        /// 市下拉
        /// </summary>
        /// <returns></returns>
        public List<City> GetCity()
        {
            return _Zzh_PatientServers.GetCity();
        }
        /// <summary>
        /// 省市二级联动
        /// </summary>
        /// <returns></returns>
        public List<City> GetCitys(int provinceId = 0)
        {
            return _Zzh_PatientServers.GetCitys(provinceId);
        }
        /// <summary>
        /// 职业下拉
        /// </summary>
        /// <returns></returns>
        public List<Position> GetPosition()
        {
            return _Zzh_PatientServers.GetPosition();
        }
        /// <summary>
        /// 修改患者信息
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public int UpdPatient(Patient m)
        {
            return _Zzh_PatientServers.UpdPatient(m);
        }
        /// <summary>
        /// 回显患者信息
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        public Patient GetPatient(int patientId=0)
        {
            return _Zzh_PatientServers.GetPatient(patientId);
        }
    }
}
