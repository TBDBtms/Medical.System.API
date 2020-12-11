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
        public List<Patient> GetPatient()
        {
            return _Zzh_PatientServers.GetPatient();
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

    }
}
