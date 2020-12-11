using Dapper;
using Medical.Model;
using Medical.Model.Jcy_Model;
using Medical.Model.ZZH_Model;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Medical.System.Servers
{
    public class Zzh_PatientServers
    {
        public IOptions<ConnectionStrings> _conn;
        IDbConnection dbcoon;
        public Zzh_PatientServers(IOptions<ConnectionStrings> conn)
        {
            _conn = conn;
            dbcoon = new SqlConnection(conn.Value.Conn);

        }
        /// <summary>
        /// 患者管理显示界面
        /// </summary>
        /// <param name="pname"></param>
        /// <param name="phone"></param>
        /// <returns></returns>
        public List<Patient> GetPatient()
        {
            string sql = $"select * from Patient a join VIPgrade b on a.MemberId=b.VGradeId";

            return dbcoon.Query<Patient>(sql).ToList();
        }
        /// <summary>
        /// 会员等级下拉
        /// </summary>
        /// <returns></returns>
        public List<VIPgrade> ZGetVIPgrade()
        {
            string sql = $"select * from VIPgrade";
            return dbcoon.Query<VIPgrade>(sql).ToList();
        }
        /// <summary>
        /// 患者管理删除
        /// </summary>
        /// <returns></returns>
        public int DelPatient(int id=0)
        {
            string sql = $"delete from Patient where PatientId={id}";
            return dbcoon.Execute(sql);
        }
    }
}
