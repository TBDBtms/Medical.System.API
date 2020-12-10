using System;
using System.Collections.Generic;
using System.Text;

namespace Medical.Model.DLH_Medical.Model
{
    /// <summary>
    /// 订单详情已收费
    /// </summary>
    public class Hs_Receipted
    {
        /// <summary>
        /// 订单详情已收费Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 外键
        /// </summary>
        public int HasId { get; set; }
        /// <summary>
        /// 收费名称
        /// </summary>
        public string ChargeName { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        public double Price { get; set; }
        /// <summary>
        /// 总量
        /// </summary>
        public int Sums { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        public string Unit { get; set; }
        /// <summary>
        /// 零售金额
        /// </summary>
        public double RetMoney { get; set; }
        /// <summary>
        /// 折扣
        /// </summary>
        public float Discount { get; set; }
        /// <summary>
        /// 折后金额
        /// </summary>
        public double AfterDisPrice { get; set; }
    }
}
