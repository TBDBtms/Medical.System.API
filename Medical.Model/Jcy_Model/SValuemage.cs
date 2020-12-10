using System;
using System.Collections.Generic;
using System.Text;

namespace Medical.Model.Jcy_Model
{
	/// <summary>
	/// 积分管理
	/// </summary>
    public class SValuemage
    {
		/// <summary>
		/// 主键
		/// </summary>
        public int Id { get; set; }
		/// <summary>
		/// 卡号
		/// </summary>
		public string IdCard { get; set; }
		/// <summary>
		/// 会员类型
		/// </summary>
		public string VTypeName { get; set; }
		/// <summary>
		/// 会员等级
		/// </summary>
        public int VGradeId { get; set; }
		/// <summary>
		/// 会员姓名
		/// </summary>
        public string VIPName { get; set; }
		/// <summary>
		/// 手机号
		/// </summary>
        public string Phone { get; set; }
		/// <summary>
		/// 积累储值
		/// </summary>
		public decimal AmassSvalue { get; set; }
		/// <summary>
		/// 积累赠送
		/// </summary>
		public decimal AddGiveMoney { get; set; }
		/// <summary>
		/// 余额
		/// </summary>
		public decimal SvalueMoney { get; set; }
		/// <summary>
		/// 储值积累消费
		/// </summary>
		public decimal AmassPrice { get; set; }
		/// <summary>
		/// 充值金额
		/// </summary>
		public decimal PayMoney { get; set; }
		/// <summary>
		/// 赠送金额
		/// </summary>
		public decimal GiveMoney { get; set; }
		/// <summary>
		/// 支付方式
		/// </summary>
        public int SId { get; set; }
		/// <summary>
		/// 退款金额
		/// </summary>
		public decimal Rprice { get; set; }
		/// <summary>
		/// 退款方式
		/// </summary>
		public string RMent { get; set; }
		/// <summary>
		/// 备注
		/// </summary>
		public string Remark { get; set; }
	}
}
