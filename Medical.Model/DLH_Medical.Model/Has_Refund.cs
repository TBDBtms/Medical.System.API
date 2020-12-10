using System;
using System.Collections.Generic;
using System.Text;

namespace Medical.Model.DLH_Medical.Model
{
    /// <summary>
    /// 已退费
    /// </summary>
    public class Has_Refund
    {
        /// <summary>
        /// 已退费ID
        /// </summary>
        public int HasId { get; set; }
        /// <summary>
        /// 订单编号
        /// </summary>
        public string HasCardc { get; set; }
        /// <summary>
        /// 订单类型id
        /// </summary>
        public int IndentId { get; set; }
        /// <summary>
        /// 患者信息
        /// </summary>
        public int PatientId { get; set; }
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
        /// 退费金额
        /// </summary>
        public double RefundPrice { get; set; }
        /// <summary>
        /// 退费方式
        /// </summary>
        public int PaymentModeId { get; set; }
        /// <summary>
        /// 收费状态 1.已退费 2.已收费
        /// </summary>
        public int CState { get; set; }
    }
}
