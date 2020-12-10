using System;
using System.Collections.Generic;
using System.Text;

namespace Medical.Model.Jcy_Model
{
    /// <summary>
    /// 会员条件设置
    /// </summary>
    public class SetFunc
    {
        /// <summary>
        /// 会员条件表主键
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 折扣
        /// </summary>
        public int RsestId { get; set; }
        /// <summary>
        /// 升级
        /// </summary>
        public int Rupgrade { get; set; }
        /// <summary>
        /// 消费积分比例
        /// </summary>
        public int XId { get; set; }
        /// <summary>
        /// 充值积分比例
        /// </summary>
        public int CId { get; set; }
        /// <summary>
        /// 单次积分上限
        /// </summary>
        public int Uppers { get; set; }
    }
}
