using System;
using System.Collections.Generic;
using System.Text;

namespace Medical.Model.ZZH_Model
{
    /// <summary>
    /// 关联家庭成员
    /// </summary>
    public class ReleFamily
    {
        /// <summary>
        /// 家庭成员Id
        /// </summary>
        public int ReleFamilyId { get; set; }
        /// <summary>
        /// 患者信息外键
        /// </summary>
        public int PatientId { get; set; }
        /// <summary>
        /// 家庭关系外键
        /// </summary>
        public int FamilyTiesId { get; set; }
        /// <summary>
        /// 家庭成员名称
        /// </summary>
        public string ReleFamilyName { get; set; }
        /// <summary>
        /// 患者家庭成员性别
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
        /// 患者家庭成员工作单位
        /// </summary>
        public string ReleFamilyWorkUnit { get; set; }
        /// <summary>
        /// 患者家庭创建时间
        /// </summary>
        public DateTime FamilyStateTime { get; set; }
    }
}
