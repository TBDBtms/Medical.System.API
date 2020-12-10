using System;
using System.Collections.Generic;
using System.Text;

namespace Medical.Model.Jcy_Model
{
    /// <summary>
    /// 积分管理
    /// </summary>
    public class Pointmanage
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
        /// 积分
        /// </summary>
        public float Integral { get; set; }
        /// <summary>
        /// 添加积分
        /// </summary>
        public int AddIntegral { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string AddRemark { get; set; }
        /// <summary>
        /// 扣减积分
        /// </summary>
        public int DelIntefral { get; set; }
        /// <summary>
        /// 删除备注
        /// </summary>
        public string DelRemark { get; set; }
        /// <summary>
        /// 清零
        /// </summary>
        public int resetIntegral { get; set; }
        /// <summary>
        /// 清零备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public DateTime Dtimes { get; set; }
        /// <summary>
        /// 变动操作
        /// </summary>
        public string IChange { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int Nums { get; set; }
        /// <summary>
        /// 操作员
        /// </summary>
        public string Man { get; set; }
        /// <summary>
        /// 操作备注
        /// </summary>
        public string Remarks { get; set; }
    }
}
