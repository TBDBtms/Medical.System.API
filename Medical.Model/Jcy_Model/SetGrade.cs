using System;
using System.Collections.Generic;
using System.Text;

namespace Medical.Model.Jcy_Model
{
    /// <summary>
    /// 会员等级表
    /// </summary>
    public class SetGrade
    {
        /// <summary>
        /// 会员等级表主键
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 会员卡号
        /// </summary>
        public string VIPCard { get; set; }
        /// <summary>
        /// 会员姓名
        /// </summary>
        public string VIPName { get; set; }
        /// <summary>
        /// 变动时间
        /// </summary>
        public DateTime ChTime { get; set; }
        /// <summary>
        /// 变更类型
        /// </summary>
        public string ChType { get; set; }
        /// <summary>
        /// 操作员
        /// </summary>
        public string Operator { get; set; }
    }
}
