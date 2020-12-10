using System;
using System.Collections.Generic;
using System.Text;

namespace Medical.Model.ZHQ
{
  public  class RK_Refused
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int RK_RefusedId { get; set; }
        /// <summary>
        /// 商品单号
        /// </summary>
        public string RK_RefusedDH { get; set; }
        /// <summary>
        /// 入库日期
        /// </summary>
        public DateTime RK_RefusedRKTime { get; set; }
        /// <summary>
        /// 入库类型
        /// </summary>
        public int RK_RefusedLX { get; set; }
        /// <summary>
        /// 入库数量
        /// </summary>
        public int RK_RefusedNumber { get; set; }
        /// <summary>
        /// 供应商
        /// </summary>
        public int RK_RefusedGYS { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string RK_RefusedDesc { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string RK_RefusedName { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        public float RK_RefusedPrice { get; set; }
    }
}
