using System;
using System.Collections.Generic;
using System.Text;

namespace Medical.Model.Jcy_Model
{
    /// <summary>
    /// 会员列表信息
    /// </summary>
    public class VIPInfo
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
        /// 会员等级Id
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
        /// 积累消费
        /// </summary>
        public decimal AmassPrice { get; set; }
        /// <summary>
        /// 储值余额
        /// </summary>
        public decimal SvalueMoney { get; set; }
        /// <summary>
        /// 积累储值
        /// </summary>
        public decimal AmassSvalue { get; set; }
        /// <summary>
        /// 积分
        /// </summary>
        public int Integral { get; set; }
        /// <summary>
        /// 开卡时间
        /// </summary>
        public DateTime?StartTime { get; set; }
        /// <summary>
        /// 到期时间
        /// </summary>
        public DateTime?EndTime { get; set; }
        /// <summary>
        /// 会员状态
        /// </summary>
        public int VIPState { get; set; }
        /// <summary>
        /// 充值金额
        /// </summary>
        public decimal PayMoney { get; set; }
        /// <summary>
        /// 赠送金额
        /// </summary>
        public decimal GiveMoney { get; set; }
        /// <summary>
        /// 支付方式Id
        /// </summary>
        public int SId { get; set; }
        /// <summary>
        /// 支付方式
        /// </summary>
        public string SName { get; set; }
        /// <summary>
        /// 折扣
        /// </summary>
        public float Discount { get; set; }
        /// <summary>
        /// 增加数量
        /// </summary>
        public int AddNum { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string AddRemark { get; set; }
        /// <summary>
        /// 扣减数量
        /// </summary>
        public int KJNum { get; set; }
        /// <summary>
        /// 扣减备注
        /// </summary>
        public string KJRemark { get; set; }
        /// <summary>
        /// 积分清零
        /// </summary>
        public string InClearRemark { get; set; }
        /// <summary>
        /// 退款金额
        /// </summary>
        public decimal RePrice { get; set; }
        /// <summary>
        /// 退款方式Id
        /// </summary>
        public int ReTypeId { get; set; }
        /// <summary>
        /// 退款方式
        /// </summary>
        public string ReTypeName { get; set; }
        /// <summary>
        /// 退款备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 会员等级
        /// </summary>
        public string VGradeName { get; set; }
        /// <summary>
        /// 患者姓名
        /// </summary>
        public string PatientName { get; set; }

        public int sid { get; set; }
    }
}
