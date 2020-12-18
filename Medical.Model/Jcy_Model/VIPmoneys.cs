using System;
using System.Collections.Generic;
using System.Text;

namespace Medical.Model.Jcy_Model
{
    /// <summary>
    /// 充值/退款记录
    /// </summary>
    public class VIPmoneys
    {
        public int Id { get; set; }
        /// <summary>
        /// 交易时间
        /// </summary>
        public DateTime DealTimes { get; set; }
        /// <summary>
        /// 交易类型
        /// </summary>
        public string DealType { get; set; }
        /// <summary>
        /// 交易金额
        /// </summary>
        public decimal DealPrice { get; set; }
        /// <summary>
        /// 赠送金额
        /// </summary>
        public decimal GiveMoney { get; set; }
        /// <summary>
        /// 合计金额
        /// </summary>
        public decimal SumMoney { get; set; }
        /// <summary>
        /// 操作员
        /// </summary>
        public string Mans { get; set; }
    }
}
