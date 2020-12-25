using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Options;
using Medical.Model.DLH_Medical.Model;
using Medical.Model.ZHQ;
using Medical.System.Servers;
using Medical.Model;

namespace Medical.System.BLL
{
    public class D_Charge_BLL
    {
        public IOptions<ConnectionStrings> _conn;

        D_Charge dal;

        public D_Charge_BLL (IOptions<ConnectionStrings> conn)
        {
            _conn = conn;
            dal = new D_Charge(conn);
        }

        /// <summary>
        /// 显示收费信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<D_Charge_Statistics> GetD_Charge_Statistics(string name="",int pageindex=1,int pagesize=10)
        {
            return dal.GetD_Charge_Statistics(name,pageindex,pagesize);
        }
    }
}
