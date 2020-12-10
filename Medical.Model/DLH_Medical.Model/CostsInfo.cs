using System;
using System.Collections.Generic;
using System.Text;

namespace Medical.Model.DLH_Medical.Model
{
    /// <summary>
    /// 附加费用设置
    /// </summary>
    public class CostsInfo
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int SequenceId { get; set; }
        /// <summary>
        /// 附加费用名称
        /// </summary>
        public string Additional { get; set; }
        /// <summary>
        /// 处方类别key
        /// </summary>
        public int RecipeKey { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public double MoneyInfn { get; set; }
        /// <summary>
        /// 成本价
        /// </summary>
        public double Cost { get; set; }
        /// <summary>
        /// 当前时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 创建人员外键
        /// </summary>
        public int CreatepersonKey { get; set; }
        /// <summary>
        /// 会员折扣
        /// </summary>
        public bool Vip { get; set; }
        /// <summary>
        /// 费用状态
        /// </summary>
        public bool CState { get; set; }

    }
}
