using System;
using System.Collections.Generic;
using System.Text;

namespace Medical.Model.DLH_Medical.Model
{
    /// <summary>
    /// 已收费
    /// </summary>
    public class Has_charge
    {
        /// <summary>
        /// 已收费主键
        /// </summary>
        public int vHasId { get; set; }
        /// <summary>
        /// 订单编号
        /// </summary>
        public string HasCardc { get; set; }
        /// <summary>
        /// 患者信息
        /// </summary>
        public int PatientId { get; set; }
        /// <summary>
        /// 订单类型id
        /// </summary>
        public int IndentId { get; set; }
        /// <summary>
        /// 科室id
        /// </summary>
        public int SectionId { get; set; }
        /// <summary>
        /// 接诊医生id
        /// </summary>
        public int ClinicalId { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime StartTime { get; set; }
        /// <summary>
        /// 应收金额
        /// </summary>
        public double ReceivablePrice { get; set; }
        /// <summary>
        /// 实收金额
        /// </summary>
        public double OfficialPrice { get; set; }
        /// <summary>
        /// 支付方式
        /// </summary>
        public int PaymentModeId { get; set; }
        /// <summary>
        /// 收费状态
        /// </summary>
        public int CState { get; set; }
    }
}
