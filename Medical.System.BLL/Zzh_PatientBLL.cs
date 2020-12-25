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
        public Pagess<Patient> GetPatient(DateTime? sdate=null, DateTime? edate=null, string name = "", int id = 0, int tj = 0, int pageindex = 1, int pagesize = 10)
        {
            return _Zzh_PatientServers.GetPatient(sdate,edate,name,id, tj, pageindex, pagesize);
        }
        /// <summary>
        /// 会员等级下拉
        /// </summary>
        /// <returns></returns>
        public List<MemberType> GetMemberType()
        {
            return _Zzh_PatientServers.GetMemberType();
        }
        /// <summary>
        /// 科室
        /// </summary>
        /// <returns></returns>
        public List<Department> GetDepartment()
        {
            return _Zzh_PatientServers.GetDepartment();
        }
        /// <summary>
        /// 家庭关系
        /// </summary>
        /// <returns></returns>
        public List<FamilyTies> GetFamilyTies()
        {
            return _Zzh_PatientServers.GetFamilyTies();
        }
        /// <summary>
        /// 操作人
        /// </summary>
        /// <returns></returns>
        public List<CaoZuoRen> GetCaoZuoRen()
        {
            return _Zzh_PatientServers.GetCaoZuoRen();
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
        /// 修改患者信息
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public int UpdPatient(Patient m)
        {
            return _Zzh_PatientServers.UpdPatient(m);
        }
        public int UpdPat(Patient m)
        {
            return _Zzh_PatientServers.UpdPat(m);
        }
        /// <summary>
        /// 回显患者信息
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        public Patient ShowPatient(int patientId=0)
        {
            return _Zzh_PatientServers.ShowPatient(patientId);
        }
        /// <summary>
        //修改状态
        /// </summary>
        /// <param name="Gid"></param>
        /// <returns></returns>
        public int Updaaa(int Aid)
        {
            return _Zzh_PatientServers.Updaaa(Aid);
        }
    }
}
