using System;
using System.Collections.Generic;
using System.Text;

namespace Medical.Model.DLH_Medical.Model
{
    /// <summary>
    /// 过往病史
    /// </summary>
    public class Principleaction
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int AdviceId { get; set; }
        /// <summary>
        /// 病史内容
        /// </summary>
        public string AdviceName { get; set; }
        /// <summary>
        /// 当前时间
        /// </summary>
        public DateTime AdviceTable { get; set; }
        /// <summary>
        /// 医生创建人 自动识别登录医生的姓名
        /// </summary>
        public int Createperson { get; set; }
    }
}
