using System;
using System.Collections.Generic;
using System.Text;

namespace Medical.Model.ZHQ
{
   public class SF_statistical
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int SF_statisticalId { get; set; }
        /// <summary>
        /// 编号
        /// </summary>
        public string SF_statisticalBH { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string SF_statisticalName { get; set; }
        /// <summary>
        /// 零售单价
        /// </summary>
        public float SF_statisticalPrice { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int SF_statisticalNum { get; set; }
        /// <summary>
        /// 规格
        /// </summary>
        public string SF_statisticalGG { get; set; }
        /// <summary>
        /// 生产产商
        /// </summary>
        public int SF_statisticalCS { get; set; }
        /// <summary>
        /// 采购单价
        /// </summary>
        public int SF_statisticalCGDJ { get; set; }
        /// <summary>
        /// 订单日期
        /// </summary>
        public DateTime SF_statisticalTime { get; set; }
    }
}
