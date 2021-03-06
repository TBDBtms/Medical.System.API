﻿using Dapper;
using Medical.Model;
using Medical.Model.Jcy_Model;
using Medical.Model.ZHQ;
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
        public Pagess<Patient> GetPatient(DateTime? sdate=null, DateTime? edate=null, string name = "",int id = 0,int tj = 0, int pageindex = 1, int pagesize = 10)
        {
            var stime = new DateTime();
            var etime = new DateTime();
            int wid=0;
            wid = tj;
            if (!string.IsNullOrEmpty(name))
            {
                if (wid==1)
                {
                    tj = 2;
                }
                else if(wid==2)
                {
                    tj = 1;
                }
            }
            else
            {
                name = "";
            }

            if (sdate == null)
            {
                var str = $"select min(CreateTime) as a from Patient";
                var a = dbcoon.Query<Patient>(str).ToList().FirstOrDefault();
                stime = a.a;
            }
            else
            {
                stime = Convert.ToDateTime(sdate);
            }
            if(edate == null)
            {
                var str = $"select max(CreateTime) as a from Patient";
                var a = dbcoon.Query<Patient>(str).ToList().FirstOrDefault();
                etime = a.a;
            }
            else
            {
                etime = Convert.ToDateTime(edate);
            }
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter() { ParameterName="@Stime",DbType=DbType.DateTime,Value=stime},
                new SqlParameter() { ParameterName="@Etime",DbType=DbType.DateTime,Value=etime},
                new SqlParameter() { ParameterName="@Id",DbType=DbType.Int32,Value=tj},
                new SqlParameter() { ParameterName="@WId",DbType=DbType.Int32,Value=id},
                new SqlParameter() { ParameterName="@Name",DbType=DbType.String,Value=name},
                new SqlParameter() { ParameterName="@PageIndex",DbType=DbType.Int32,Value=pageindex},
                new SqlParameter() { ParameterName="@PageSize",DbType=DbType.Int32,Value=pagesize},
                new SqlParameter() { ParameterName="@AllCount",DbType=DbType.Int32,Direction= ParameterDirection.Output},
            };
            List<Patient> list = DBhelper.GetDataTable_Proc<Patient>("Proc_Patients", param);
            foreach (var item in list)
            {
                item.aaa = item.CreateTime.ToString("yyyy-MM-dd");
            }
            Pagess<Patient> page1 = new Pagess<Patient>()
            {
                Countnum = Convert.ToInt32(param[7].Value),
                PageList = list
            };
            return page1;
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
        /// 科室
        /// </summary>
        /// <returns></returns>
        public List<Department> GetDepartment()
        {
            string sql = $"select * from Department";
            return dbcoon.Query<Department>(sql).ToList();
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
            m.PatientImg = "~/Zzhimg/QQ图片20201218101515 (1).png";
            string sql = $"insert into Patient values('{m.PatientCode}','{m.PatientImg}','{m.PatientName}','{m.PatientCard}','{m.PatientAge}','{m.PatientDateBirth}','{m.PatientSex}','{m.PatientPhone}','{m.Patientpapers}','{m.PatientSource}','{m.MemberId}','{m.EndData}','{m.Nation}','{m.MaritalStatus}','{m.Education}','{m.ProvinceId}','{m.CityId}','{m.PatientAddress}','{m.Position}','{m.Remark}','{m.DId}','{m.CaoPeopleId}','{m.CreateTime}','{m.FamilyTiesId}','{m.ReleFamilyName}','{m.ReleFamilySex}','{m.ReleFamilyAge}','{m.ReleFamilyPhone}','{m.PatientStateId}')";
            return dbcoon.Execute(sql);
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
            m.PatientImg = "~/Zzhimg/QQ图片20201218101515 (1).png";
            string sql =$"update Patient set PatientCode='{m.PatientCode}',PatientImg='{m.PatientImg}',PatientName='{m.PatientName}',PatientCard='{m.PatientCard}',PatientAge='{m.PatientAge}',PatientDateBirth='{m.PatientDateBirth}',PatientSex='{m.PatientSex}',PatientPhone='{m.PatientPhone}',Patientpapers='{m.Patientpapers}',PatientSource='{m.PatientSource}',MemberId='{m.MemberId}',EndData='{m.EndData}',Nation='{m.Nation}',MaritalStatus='{m.MaritalStatus}',Education='{m.Education}',ProvinceId='{m.ProvinceId}',CityId='{m.CityId}',PatientAddress='{m.PatientAddress}',Position='{m.Position}',CaoPeopleId='{m.CaoPeopleId}',DId='{m.DId}',Remark='{m.Remark}',CreateTime='{m.CreateTime}',FamilyTiesId='{m.FamilyTiesId}',ReleFamilyName='{m.ReleFamilyName}',ReleFamilySex='{m.ReleFamilySex}',ReleFamilyAge='{m.ReleFamilyAge}',ReleFamilyPhone='{m.ReleFamilyPhone}',PatientStateId='{m.PatientStateId}' where PatientId='{m.PatientId}'";
            return dbcoon.Execute(sql);
        }
        public int UpdPat(Patient m)
        {
            string sql = $"update Patient set MemberId='{m.MemberId}',EndData='{m.EndData}' where PatientId='{m.PatientId}'";
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
        /// <summary>
        //修改状态
        /// </summary>
        /// <param name="Gid"></param>
        /// <returns></returns>
        public int Updaaa(int Aid)
        {
            string sql = $"update Patient set PatientStateId=PatientStateId-1 where PatientId={Aid}";
            return dbcoon.Execute(sql);
        }
    }
}
