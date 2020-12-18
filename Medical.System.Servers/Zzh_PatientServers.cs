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
        public List<Patient> GetPatient(string name = "", int id = 0)
        {
            string sql = $"select * from Patient a join MemberType b on a.MemberTypeId=b.MemberTypeId join CaoZuoRen c on a.CaoPeopleId=c.CaoZuoRenId join PatientState f on a.PatientStateId=f.PatientStateId where 1=1";
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
            if (id > 0)
            {
                sql += $" and b.MemberTypeId={id}";
            }
            return dbcoon.Query<Patient>(sql).ToList();
        }
        /// <summary>
        /// 会员等级下拉
        /// </summary>
        /// <returns></returns>
        public List<MemberType> GetMemberType()
        {
            string sql = $"select * from MemberType";
            return dbcoon.Query<MemberType>(sql).ToList();
        }        
        /// <summary>
        /// 家庭关系
        /// </summary>
        /// <returns></returns>
        public List<FamilyTies> GetFamilyTies()
        {
            string sql = $"select * from FamilyTies";
            return dbcoon.Query<FamilyTies>(sql).ToList();
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
        public int DelPatient(int id = 0)
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
            Random r = new Random();
            m.PatientCode = (r.Next(0, 10000)).ToString();
            string sql = $"insert into Patient values('{m.PatientCode}','{m.PatientName}','{m.PatientCard}','{m.PatientAge}','{m.PatientDateBirth}','{m.PatientSex}','{m.PatientPhone}','{m.Patientpapers}','{m.PatientSource}','{m.MemberTypeId}','{m.EndData}','{m.Nation}','{m.MaritalStatus}','{m.Education}','{m.ProvinceId}','{m.CityId}','{m.PatientAddress}','{m.Position}','{m.Remark}','{m.Departments}','{m.CaoPeopleId}','{m.CreateTime}','{m.FamilyTiesId}','{m.ReleFamilyName}','{m.ReleFamilySex}','{m.ReleFamilyAge}','{m.ReleFamilyPhone}','{m.PatientStateId}')";
            return dbcoon.Execute(sql);
        }
        /// <summary>
        /// 患者状态
        /// </summary>
        /// <returns></returns>
        public List<PatientState> GetPatientState()
        {
            string sql = $"select * from PatientState";
            return dbcoon.Query<PatientState>(sql).ToList();
        }
        /// <summary>
        /// 操作人
        /// </summary>
        /// <returns></returns>
        public List<CaoZuoRen> GetCaoZuoRen()
        {
            string sql = $"select * from CaoZuoRen";
            return dbcoon.Query<CaoZuoRen>(sql).ToList();
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
        public List<City> GetCitys(int provinceId = 0)
        {
            string sql = $"select * from City where ProvinceId='{provinceId}'";
            return dbcoon.Query<City>(sql).ToList();
        }
        /// <summary>
        /// 修改患者信息
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public int UpdPatient(Patient m)
        {
            Random r = new Random();
            m.PatientCode = (r.Next(0, 10000)).ToString();
            m.CreateTime = DateTime.Now;
            string sql = $"update Patient set PatientCode='{m.PatientCode}',PatientName='{m.PatientName}',PatientCard='{m.PatientCard}',PatientAge='{m.PatientAge}',PatientDateBirth='{m.PatientDateBirth}',PatientSex='{m.PatientSex}',PatientPhone='{m.PatientPhone}',Patientpapers='{m.Patientpapers}',PatientSource='{m.PatientSource}',MemberTypeId='{m.MemberTypeId}',EndData='{m.EndData}',Nation='{m.Nation}',MaritalStatus='{m.MaritalStatus}',Education='{m.Education}',ProvinceId='{m.ProvinceId}',CityId='{m.CityId}',PatientAddress='{m.PatientAddress}',Position='{m.Position}',CaoPeopleId='{m.CaoPeopleId}',Departments='{m.Departments}',Remark='{m.Remark}',CreateTime='{m.CreateTime}',FamilyTiesId='{m.FamilyTiesId}',ReleFamilyName='{m.ReleFamilyName}',ReleFamilySex='{m.ReleFamilySex}',ReleFamilyAge='{m.ReleFamilyAge}',ReleFamilyPhone='{m.ReleFamilyPhone}',PatientStateId='{m.PatientStateId}' where PatientId='{m.PatientId}'";
            return dbcoon.Execute(sql);
        }
        /// <summary>
        /// 回显患者信息
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        public Patient ShowPatient(int patientId = 0)
        {
            string sql = $"select * from Patient where PatientId='{patientId}'";
            return dbcoon.Query<Patient>(sql).FirstOrDefault();
        }
    }
}
