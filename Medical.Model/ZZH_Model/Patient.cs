using System;
using System.Collections.Generic;
using System.Text;

namespace Medical.Model.ZZH_Model
{
    /// <summary>
    /// 患者管理
    /// </summary>
    public class Patient
    {
        /// <summary>
        /// 患者主键
        /// </summary>
        public int PatientId { get; set; }
        /// <summary>
        /// 患者编码
        /// </summary>
        public string PatientCode { get; set; }
        /// <summary>
        /// 患者图片
        /// </summary>
        public string PatientImg { get; set; }
        /// <summary>
        /// 患者姓名
        /// </summary>
        public string PatientName { get; set; }
        /// <summary>
        /// 患者卡号
        /// </summary>
        public string PatientCard { get; set; }
        /// <summary>
        /// 患者年龄
        /// </summary>
        public int PatientAge { get; set; }
        /// <summary>
        /// 患者出生日期
        /// </summary>
        public DateTime PatientDateBirth { get; set; }
        /// <summary>
        /// 性别外键
        /// </summary>
        public bool PatientSex { get; set; }
        /// <summary>
        /// 患者手机号码
        /// </summary>
        public string PatientPhone { get; set; }
        /// <summary>
        /// 患者证件号码
        /// </summary>
        public string Patientpapers { get; set; }
        /// <summary>
        /// 患者来源外键
        /// </summary>
        public int PatientSource { get; set; }
        /// <summary>
        /// 会员类型
        /// </summary>
        public int MemberId { get; set; }
        public string MemberTypeName { get; set; }
        /// <summary>
        /// 到期时间
        /// </summary>
        public DateTime EndData { get; set; }
        /// <summary>
        /// 名族
        /// </summary>
        public string Nation { get; set; }
        /// <summary>
        /// 婚姻
        /// </summar
        public bool MaritalStatus { get; set; }
        /// <summary>
        /// 学历
        /// </summary>
        public int Education { get; set; }
        /// <summary>
        /// 省外键
        /// </summary>
        public int ProvinceId { get; set; }
        /// <summary>
        /// 市外键
        /// </summary>
        public int CityId { get; set; }
        /// <summary>
        /// 详细地址
        /// </summary>
        public string PatientAddress { get; set; }
        /// <summary>
        /// 职位外键
        /// </summary>
        public int Position { get; set; }
        /// <summary>
        /// 操作人
        /// </summary>
        public int CaoPeopleId { get; set; }
        public string CaoZuoRenName { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 家庭关系外键
        /// </summary>
        public int FamilyTiesId { get; set; }
        /// <summary>
        /// 家庭成员名称
        /// </summary>
        public string ReleFamilyName { get; set; }
        /// <summary>
        /// 患者家庭成员
        /// </summary>
        public bool ReleFamilySex { get; set; }
        /// <summary>
        /// 患者家庭成员年龄
        /// </summary>
        public int ReleFamilyAge { get; set; }
        /// <summary>
        /// 患者家庭成员手机号
        /// </summary>
        public string ReleFamilyPhone { get; set; }
        /// <summary>
        /// 患者状态
        /// </summary>
        public bool PatientStateId { get; set; }
        public int DId { get; set; }
        public string DepartmentName { get; set; }
        public string aaa { get; set; }
        public DateTime a { get; set; }

    }
}
