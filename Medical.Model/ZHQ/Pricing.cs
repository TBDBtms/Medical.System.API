using System;
using System.Collections.Generic;
using System.Text;

namespace Medical.Model.ZHQ
{
  public  class Pricing
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int PricingId { get; set; }
        /// <summary>
        /// 药品编号
        /// </summary>
        public string PricingBH { get; set; }
        /// <summary>
        /// 药品名称
        /// </summary>
        public string PricingName { get; set; }
        /// <summary>
        /// 药品规格
        /// </summary>
        public string PricingGG { get; set; }
        /// <summary>
        /// 药品库存
        /// </summary>
        public int PricingKC { get; set; }
        /// <summary>
        /// 采购价
        /// </summary>
        public float PricingCGJ { get; set; }
        /// <summary>
        /// 原零售价
        /// </summary>
        public float PricingLSJ { get; set; }
        /// <summary>
        /// 现零售价
        /// </summary>
        public float PricingXLSJ { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime PricingTime { get; set; }
        /// <summary>
        /// 操作人
        /// </summary>
        public string PricingRName { get; set; }
    }
}
