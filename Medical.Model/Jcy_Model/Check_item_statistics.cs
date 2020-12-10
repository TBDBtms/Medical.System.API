using System;
using System.Collections.Generic;
using System.Text;

namespace Medical.Model.Jcy_Model
{
    /// <summary>
    /// 检查项目统计
    /// </summary>
    public class Check_item_statistics
    {
        /// <summary>
        /// 检查项目统计id
        /// </summary>
        public int SequenceId { get; set; }
        /// <summary>
        /// 订单编号
        /// </summary>
        public string order_number { get; set; }
        /// <summary>
        /// 项目类型
        /// </summary>
        public int project_type { get; set; }
        /// <summary>
        /// 项目编编码
        /// </summary>
        public string coding { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>
        public string Item { get; set; }
        /// <summary>
        /// 发票类型
        /// </summary>
        public int Invoice_type { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int number { get; set; }
        /// <summary>
        /// 成本单价
        /// </summary>
        public decimal Cost { get; set; }
        /// <summary>
        /// 零售单价
        /// </summary>
        public decimal retail_price { get; set; }
        /// <summary>
        /// 成本单价
        /// </summary>
        public decimal Cost_prices { get; set; }
        /// <summary>
        /// 零售总价
        /// </summary>
        public decimal retail_prices { get; set; }
        /// <summary>
        /// 利润总价
        /// </summary>
        public decimal profit { get; set; }
        /// <summary>
        /// 订单日期
        /// </summary>
        public DateTime Indent { get; set; }
    }
}
