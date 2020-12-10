using System;
using System.Collections.Generic;
using System.Text;

namespace Medical.Model.ZHQ
{
   public class RK_through
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int RK_throughId { get; set; }
        /// <summary>
        /// 商品单号
        /// </summary>
        public string RK_throughDH { get; set; }
        /// <summary>
        /// 入库日期
        /// </summary>
        public DateTime RK_throughRKTime { get; set; }
        /// <summary>
        /// 入库类型
        /// </summary>
        public int RK_throughLX { get; set; }
        /// <summary>
        /// 入库数量
        /// </summary>
        public int RK_throughNumber { get; set; }
        /// <summary>
        /// 供应商
        /// </summary>
        public int RK_throughGYS { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string RK_throughDesc { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string RK_throughName { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        public float RK_throughPrice { get; set; }
    }
}
