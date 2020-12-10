using System;
using System.Collections.Generic;
using System.Text;

namespace Medical.Model.ZZH_Model
{
    /// <summary>
    /// 门诊日志
    /// </summary>
    public class Outpatientlog
    {
        /// <summary>
        /// 门诊类型Id
        /// </summary>
        public int OutpatientlogeId { get; set; }
        /// <summary>
        /// 连接患者外键
        /// </summary>
        public int PatientId { get; set; }
        /// <summary>
        /// 连接医生外键
        /// </summary>
        public int DoctorsId { get; set; }
        /// <summary>
        /// 连接科室外键
        /// </summary>
        public int OfficeId { get; set; }
        /// <summary>
        /// 连接收费状态外键
        /// </summary>
        public int ChargeStateId { get; set; }
    }
}
