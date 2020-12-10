using System;
using System.Collections.Generic;
using System.Text;

namespace Medical.Model.DLH_Medical.Model
{
    /// <summary>
    /// 支付方式
    /// </summary>
    public class Pattern
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int PatternId { get; set; }
        /// <summary>
        ///  -- 1.现金支付 2.支付宝 3.微信支付 4.银行卡支付 5.会员支付 6.挂账
        /// </summary>
        public int PatternName { get; set; }
    }
}
