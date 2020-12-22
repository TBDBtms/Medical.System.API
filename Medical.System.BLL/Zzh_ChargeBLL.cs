using Medical.Model;
using Medical.Model.ZZH_Model;
using Medical.System.Servers;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace Medical.System.BLL
{
    public class Zzh_ChargeBLL
    {
        public IOptions<ConnectionStrings> _conn;
        Zzh_ChargeServers _Zzh_ChargeServers;
        public Zzh_ChargeBLL(IOptions<ConnectionStrings> conn)
        {
            _conn = conn;
            _Zzh_ChargeServers = new Zzh_ChargeServers(conn);

        }
        /// <summary>
        /// 门诊日志
        /// </summary>
        /// <returns></returns>
        public List<Outpatientlog> GetOutpatientlog()
        {
            return _Zzh_ChargeServers.GetOutpatientlog();
        }
    }
}
