using System;
using System.Collections.Generic;
using System.Text;

namespace Medical.Model.Jcy_Model
{
    /// <summary>
    /// 会员设置
    /// </summary>
    public class MemberSet
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 会员等级id
        /// </summary>
        public int VGradeId { get; set; }
        /// <summary>
        /// 患者姓名
        /// </summary>
        public string PatientName { get; set; }
        /// <summary>
        /// 会员等级
        /// </summary>
        public string VGradeName { get; set; }
        /// <summary>
        /// 会员姓名
        /// </summary>
        /// <returns></returns>
        public string VIPName { get; set; }
        /// <summary>
        /// 折扣
        /// </summary>
        public float VIPReset { get; set; }
        /// <summary>
        /// 最低积分
        /// </summary>
        public int MinIntegral { get; set; }
        /// <summary>
        /// 升级所需
        /// </summary>
        public int Upgrade { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int States { get; set; }
    }
}
