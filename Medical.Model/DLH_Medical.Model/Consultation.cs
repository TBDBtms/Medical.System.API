using System;
using System.Collections.Generic;
using System.Text;

namespace Medical.Model.DLH_Medical.Model
{
    /// <summary>
    /// 诊疗费设置
    /// </summary>
    public class Consultation
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int SequenceId { get; set; }
        /// <summary>
        /// 附件费用名称
        /// </summary>
        public string Additional { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public double MoneyInfn { get; set; }
        /// <summary>
        /// 成本价
        /// </summary>
        public double Cost { get; set; }
        /// <summary>
        /// 当前时间
        /// </summary>
        public DateTime ZLTime { get; set; }
        /// <summary>
        /// 创建人员外键
        /// </summary>
        public int CreatepersonKey { get; set; }
        /// <summary>
        /// 会员折扣
        /// </summary>
        public bool Vip { get; set; }
        /// <summary>
        /// 费用状态
        /// </summary>
        public bool CState { get; set; }


        #region 员工
        public int Uid { get; set; }
        public string Uname { get; set; }
        #endregion

        public string time { get; set; }
    }
}
