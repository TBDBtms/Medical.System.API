using System;
using System.Collections.Generic;
using System.Text;

namespace Medical.Model.DLH_Medical.Model
{
    /// <summary>
    /// 主诉信息
    /// </summary>
    public class Principle
    {
        /// <summary>
        /// 主诉信息Id
        /// </summary>
        public int PrincipleId { get; set; }
        /// <summary>
        /// 主诉分类外键
        /// </summary>
        public int PrincipleTypeId { get; set; }
        /// <summary>
        /// 主诉内容
        /// </summary>
        public string PrincipleName { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime PrincipleTable { get; set; }
        /// <summary>
        /// 医生创建人 自动识别登录医生的姓名
        /// </summary>
        public int Createperson { get; set; }
    }
}
