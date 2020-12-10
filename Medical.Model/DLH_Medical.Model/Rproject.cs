using System;
using System.Collections.Generic;
using System.Text;

namespace Medical.Model.DLH_Medical.Model
{
    /// <summary>
    /// 退费项目-已退费
    /// </summary>
    public class Rproject
    {
        /// <summary>
        /// 退费项目-已退费Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 收费名称
        /// </summary>
        public string ChargeName { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        public double Price { get; set; }
        /// <summary>
        /// 退货数量
        /// </summary>
        public int SalesNum { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        public string Unit { get; set; }
        /// <summary>
        /// 退款金额
        /// </summary>
        public double BakePrice { get; set; }
    }
}
