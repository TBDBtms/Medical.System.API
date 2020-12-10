using System;
using System.Collections.Generic;
using System.Text;

namespace Medical.Model.ZHQ
{
   public class CK_Refused
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int CK_RefusedId { get; set; }
        /// <summary>
        /// 商品单号
        /// </summary>
        public string CK_RefusedDH { get; set; }
        /// <summary>
        /// 入库日期
        /// </summary>
        public DateTime CK_RefusedRKTime { get; set; }
        /// <summary>
        /// 入库类型
        /// </summary>
        public int CK_RefusedLX { get; set; }
        /// <summary>
        /// 入库数量
        /// </summary>
        public int CK_RefusedNumber { get; set; }
        /// <summary>
        /// 供应商
        /// </summary>
        public int CK_RefusedGYS { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string CK_RefusedDesc { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string CK_RefusedName { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        public float CK_RefusedPrice { get; set; }
    }
}
