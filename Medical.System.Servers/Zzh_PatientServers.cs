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
        public List<PatientSource> GetPatientSource(string name)
        {
            string sql = $"select * from PatientSource where 1=1";
            if(!string.IsNullOrEmpty(name))
            {
                sql += $" and PatientSourceName like '%{name}%'";
            }
            return dbcoon.Query<PatientSource>(sql).ToList();
        }
        /// <summary>
        /// 新增患者来源
        /// </summary>
        /// <returns></returns>
        public int AddPatientSource(PatientSource m)
        {
            m.CreateTime =DateTime.Now;
            m.CreateTime.ToString("yyyy-MM-dd");
            m.CreatePeople = "111";
            string sql = $"insert into PatientSource values('{m.PatientSourceName}','{m.CreateTime}','{m.CreatePeople}')";
            return dbcoon.Execute(sql);
        }
        /// <summary>
        /// 回显患者来源
        /// </summary>
        /// <param name="patientSourceId"></param>
        /// <returns></returns>
        public PatientSource ShoPatientSource(int patientSourceId = 0)
        {
            string sql = $"select * from PatientSource where PatientSourceId='{patientSourceId}'";
            return dbcoon.Query<PatientSource>(sql).FirstOrDefault();
        }
        /// <summary>
        /// 编辑患者来源
        /// </summary>
        /// <returns></returns>
        public int UpdPatientSource(PatientSource m)
        {
            m.CreateTime = DateTime.Now;
            m.CreateTime.ToString("yyyy-MM-dd");
            m.CreatePeople = "111";
            string sql = $"update PatientSource set PatientSourceName='{m.PatientSourceName}',CreateTime='{m.CreateTime}',CreatePeople='{m.CreatePeople}' where PatientSourceId='{m.PatientSourceId}'";
            return dbcoon.Execute(sql);
        }
        /// <summary>
        /// 删除患者来源
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DelPatientSource(int id)
        {
            string sql = $"delete from PatientSource where PatientSourceId={id}";
            return dbcoon.Execute(sql);
        }
        /// <summary>
        /// 学历下拉
        /// </summary>
        /// <returns></returns>
        public List<Education> GetEducation(string name)
        {
            string sql = $"select * from Education where 1=1";
            if (!string.IsNullOrEmpty(name))
            {
                sql += $" and EducationName like '%{name}%'";
            }
            return dbcoon.Query<Education>(sql).ToList();
        }
        /// <summary>
        /// 新增学历
        /// </summary>
        /// <returns></returns>
        public int AddEducation(Education m)
        {
            m.CreateTime = DateTime.Now;
            m.CreateTime.ToString("yyyy-MM-dd");
            m.CreatePeople = "111";
            string sql = $"insert into Education values('{m.EducationName}','{m.CreateTime}','{m.CreatePeople}')";
            return dbcoon.Execute(sql);
        }
        /// <summary>
        /// 回显学历
        /// </summary>
        /// <param name="educationId"></param>
        /// <returns></returns>
        public Education ShowEducation(int educationId = 0)
        {
            string sql = $"select * from Education where EducationId='{educationId}'";
            return dbcoon.Query<Education>(sql).FirstOrDefault();
        }
        /// <summary>
        /// 编辑学历
        /// </summary>
        /// <returns></returns>
        public int UpdEducation(Education m)
        {
            m.CreateTime = DateTime.Now;
            m.CreateTime.ToString("yyyy-MM-dd");
            m.CreatePeople = "111";
            string sql = $"update Education set PatientSourceName='{m.EducationName}',CreateTime='{m.CreateTime}',CreatePeople='{m.CreatePeople} where EducationId='{m.EducationId}'";
            return dbcoon.Execute(sql);
        }
        /// <summary>
        /// 删除学历下拉
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DelEducation(int id)
        {
            string sql = $"delete from Education where EducationId={id}";
            return dbcoon.Execute(sql);
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
        public List<Position> GetPosition(string name)
        {
            string sql = $"select * from Position where 1=1";
            if (!string.IsNullOrEmpty(name))
            {
                sql += $" and PositionName like '%{name}%'";
            }
            return dbcoon.Query<Position>(sql).ToList();
        }
        /// <summary>
        /// 新增职业
        /// </summary>
        /// <returns></returns>
        public int AddPosition(Position m)
        {
            m.CreateTime = DateTime.Now;
            m.CreateTime.ToString("yyyy-MM-dd");
            m.CreatePeople = "111";
            string sql = $"insert into Position values('{m.PositionName}','{m.CreateTime}','{m.CreatePeople}')";

            return dbcoon.Execute(sql);
        }
        /// <summary>
        /// 回显职业
        /// </summary>
        /// <param name="positionId"></param>
        /// <returns></returns>
        public Position ShowPosition(int positionId = 0)
        {
            string sql = $"select * from Position where PositionId='{positionId}'";
            return dbcoon.Query<Position>(sql).FirstOrDefault();
        }
        /// <summary>
        /// 编辑学历
        /// </summary>
        /// <returns></returns>
        public int UpdPosition(Position m)
        {
            m.CreateTime = DateTime.Now;
            m.CreateTime.ToString("yyyy-MM-dd");
            m.CreatePeople = "111";
            string sql = $"update Position set PositionName='{m.PositionName}',CreateTime='{m.CreateTime}',CreatePeople='{m.CreatePeople}' where PositionId='{m.PositionId}'";
            return dbcoon.Execute(sql);
        }
        /// <summary>
        /// 删除职业下拉
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DelPosition(int id)
        {
            string sql = $"delete from Position where PositionId={id}";
            return dbcoon.Execute(sql);
        }
        /// <summary>
        /// 修改患者信息
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public int UpdPatient(Patient m)
        {
            m.CaoPeople = "张三";
            Random r = new Random();
            m.PatientCode = (r.Next(0, 10000)).ToString();
            m.CreateTime = DateTime.Now;
            string sql = $"update Patient set PatientCode='{m.PatientCode}',PatientName='{m.PatientName}',PatientCard='{m.PatientCard}',PatientAge='{m.PatientAge}',PatientDateBirth='{m.PatientDateBirth}',PatientSex='{m.PatientSex}',PatientPhone='{m.PatientPhone}',Patientpapers='{m.Patientpapers}',PatientSourceId='{m.PatientSourceId}',MemberId='{m.MemberId}',MemberType='{m.MemberType}',EndData='{m.EndData}',Nation='{m.Nation}',MaritalStatus='{m.MaritalStatus}',EducationId='{m.EducationId}',ProvinceId='{m.ProvinceId}',CityId='{m.CityId}',PatientAddress='{m.PatientAddress}',PositionId='{m.PositionId}',WorkUnit='{m.WorkUnit}',Remark='{m.Remark}',CaoPeople='{m.CaoPeople}',CreateTime='{m.CreateTime}' where PatientId='{m.PatientId}'";
            return dbcoon.Execute(sql);
        }
        /// <summary>
        /// 回显患者信息
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        public Patient GetPatient(int patientId=0)
        {
            string sql = $"select * from Patient where PatientId='{patientId}'";
            return dbcoon.Query<Patient>(sql).FirstOrDefault();
        }
    }
}
