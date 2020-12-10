using System;
using System.Collections.Generic;
using System.Text;

namespace Medical.Model.Jcy_Model
{
    /// <summary>
    /// 支付方式设置
    /// </summary>
    public class SetPayment
    {
        /// <summary>
        /// 支付方式主键
        /// </summary>
        public int SId { get; set; }
        /// <summary>
        /// 现金支付
        /// </summary>
        public int CashId { get; set; }
        /// <summary>
        /// 支付宝
        /// </summary>
        public int AlipayId { get; set; }
        /// <summary>
        /// 微信
        /// </summary>
        public int WeChatId { get; set; }
        /// <summary>
        /// 银行卡
        /// </summary>
        public int BankcardId { get; set; }
        /// <summary>
        /// 会员卡
        /// </summary>
        public int ClubCardId { get; set; }
        /// <summary>
        /// 挂账
        /// </summary>
        public int Suspends { get; set; }
    }
}
