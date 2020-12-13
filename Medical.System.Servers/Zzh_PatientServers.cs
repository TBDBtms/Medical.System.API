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
        public List<Patient> GetPatient(string name = "",int id=0)
        {
            string sql = $"select * from Patient a join VIPgrade b on a.MemberId=b.VGradeId where 1=1";
            if (!string.IsNullOrEmpty(name))
            {
                var t = IsNumberic(name);
                if (t)
                {
                    sql += $" and PatientPhone='{name}'";
                }
                else
                {
                    sql += $" and PatientName like '%{name}%'";
                }
            }
            if(id>0)
            {
                sql += $" and VGradeId={id}";
            }
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
        private bool IsNumberic(string name = "")
        {
            try
            {
                int var1 = Convert.ToInt32(name);
                return true;
            }
            catch
            {
                return false;
            }
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
        /// <summary>
        /// 添加患者信息
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public int AddPatient(Patient m)
        {
            m.CaoPeople = "张三";
            m.CreateTime = DateTime.Now;
            m.MemberId = 0;
            Random r = new Random();
            m.PatientCode = (r.Next(0, 10000)).ToString();
            string sql = $"insert into Patient values('{m.PatientCode}','{m.PatientName}','{m.PatientCard}','{m.PatientAge}','{m.PatientDateBirth}','{m.PatientSex}','{m.PatientPhone}','{m.Patientpapers}','{m.PatientSourceId}','{m.MemberId}','{m.MemberType}','{m.EndData}','{m.Nation}','{m.MaritalStatus}','{m.EducationId}','{m.ProvinceId}','{m.CityId}','{m.PatientAddress}','{m.PositionId}','{m.WorkUnit}','{m.Remark}','{m.CaoPeople}','{m.CreateTime}')";
            return dbcoon.Execute(sql);
        }
        /// <summary>
        /// 患者来源下拉
        /// </summary>
        /// <returns></returns>
        public List<PatientSource> GetPatientSource()
        {
            string sql = $"select * from PatientSource";
            return dbcoon.Query<PatientSource>(sql).ToList();
        }
        /// <summary>
        /// 学历下拉
        /// </summary>
        /// <returns></returns>
        public List<Education> GetEducation()
        {
            string sql = $"select * from Education";
            return dbcoon.Query<Education>(sql).ToList();
        }
        /// <summary>
        /// 省下拉
        /// </summary>
        /// <returns></returns>
        public List<Province> GetProvince()
        {
            string sql = $"select * from Province";
            return dbcoon.Query<Province>(sql).ToList();
        }
        /// <summary>
        /// 市下拉
        /// </summary>
        /// <returns></returns>
        public List<City> GetCity()
        {
            string sql = $"select * from City";
            return dbcoon.Query<City>(sql).ToList();
        }
        /// <summary>
        /// 省市二级联动
        /// </summary>
        /// <returns></returns>
        public List<City> GetCitys(int provinceId=0)
        {
            string sql = $"select * from City where ProvinceId='{provinceId}'";
            return dbcoon.Query<City>(sql).ToList();
        }
        /// <summary>
        /// 职业下拉
        /// </summary>
        /// <returns></returns>
        public List<Position> GetPosition()
        {
            string sql = $"select * from Position";
            return dbcoon.Query<Position>(sql).ToList();
        }
    }
    
}
