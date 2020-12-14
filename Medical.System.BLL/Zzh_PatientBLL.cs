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
        public List<PatientSource> GetPatientSource(string name)
        {
            return _Zzh_PatientServers.GetPatientSource(name);
        }
        /// <summary>
        /// 新增患者来源
        /// </summary>
        /// <returns></returns>
        public int AddPatientSource(PatientSource m)
        {
            return _Zzh_PatientServers.AddPatientSource(m);
        }
        /// <summary>
        /// 删除患者来源
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DelPatientSource(int id)
        {
            return _Zzh_PatientServers.DelPatientSource(id);
        }
        /// <summary>
        /// 学历下拉
        /// </summary>
        /// <returns></returns>
        public List<Education> GetEducation(string name)
        {
            return _Zzh_PatientServers.GetEducation(name);
        }
        /// <summary>
        /// 新增学历
        /// </summary>
        /// <returns></returns>
        public int AddEducation(Education m)
        {
            return _Zzh_PatientServers.AddEducation(m);
        }
        /// <summary>
        /// 删除学历下拉
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DelEducation(int id)
        {
            return _Zzh_PatientServers.DelEducation(id);
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
        public List<Position> GetPosition(string name)
        {
            return _Zzh_PatientServers.GetPosition(name);
        }
        /// <summary>
        /// 新增职业
        /// </summary>
        /// <returns></returns>
        public int AddPosition(Position m)
        {
            return _Zzh_PatientServers.AddPosition(m);
        }
        /// <summary>
        /// 删除职业下拉
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DelPosition(int id)
        {
            return _Zzh_PatientServers.DelPosition(id);
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
