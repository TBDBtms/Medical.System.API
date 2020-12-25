using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Options;
using System.Linq;
using Dapper;
using Medical.Model.DLH_Medical;
using Medical.Model;
using System.Data.SqlClient;
using System.Data;
using Medical.Model.ZHQ;
using Medical.Model.DLH_Medical.Model;

namespace Medical.System.Servers
{
    public class D_Charge
    {
        public IOptions<ConnectionStrings> _conn;

        IDbConnection dbconn;
        public D_Charge(IOptions<ConnectionStrings> conn)
        {
            _conn = conn;
            dbconn = new SqlConnection(_conn.Value.Conn);
        }

        /// <summary>
        /// 显示诊断信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<D_Charge_Statistics> GetD_Charge_Statistics(string name="",int pageindex=1,int pagesize=10)
        {
            string sql = $"select * from waijian w join CostsInfo c on w.GuaId=c.SequenceIdes join Consultation t on w.Fujia=t.SequenceId join X_Guahao x on w.ZhenId = x.Gid join VIPInfo v on w.GuaZId=v.Id join SetVIPGrade s on w.HuanId=s.Id join Userinfo u on w.YaoId=u.Uid join Patient p on w.UseId=p.PatientId join Drug_administration d on w.VipId=d.DrugId join Registration r on w.SetId=r.SequenceIds join Keshi k on w.keshiId=k.Kid where p.PatientName like '%{name}%'";
            return dbconn.Query<D_Charge_Statistics>(sql).ToList();
        }
        
        
    }
}
