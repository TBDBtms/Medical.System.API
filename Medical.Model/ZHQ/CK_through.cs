using System;
using System.Collections.Generic;
using System.Text;

namespace Medical.Model.ZHQ
{
  public  class CK_through
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int CK_throughId { get; set; }
        /// <summary>
        /// 商品单号
        /// </summary>
        public string CK_throughDH { get; set; }
        /// <summary>
        /// 入库日期
        /// </summary>
        public DateTime CK_throughRKTime { get; set; }
        /// <summary>
        /// 入库类型
        /// </summary>
        public int CK_throughLX { get; set; }
        /// <summary>
        /// 入库数量
        /// </summary>
        public int CK_throughNumber { get; set; }
        /// <summary>
        /// 供应商
        /// </summary>
        public int CK_throughGYS { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string CK_throughDesc { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string CK_throughName { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        public float CK_throughPrice { get; set; }
    }
}
