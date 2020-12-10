using System;
using System.Collections.Generic;
using System.Text;

namespace Medical.Model.DLH_Medical.Model
{
    /// <summary>
    /// 待收费
    /// </summary>
    public class Charge
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int ChargeId { get; set; }
        /// <summary>
        /// 编号
        /// </summary>
        public string ChargeOrder { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public int Chargetype { get; set; }
        /// <summary>
        /// 患者信息
        /// </summary>
        public int PatientId { get; set; }
        /// <summary>
        /// 科室信息
        /// </summary>
        public int Department { get; set; }
        /// <summary>
        /// 接诊医生
        /// </summary>
        public int Doctor { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime EndTime { get; set; }
        /// <summary>
        /// 就诊医生外键
        /// </summary>
        public int RegistrationId { get; set; }
    }
}
