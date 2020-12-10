using System;
using System.Collections.Generic;
using System.Text;

namespace Medical.Model.DLH_Medical.Model
{
    /// <summary>
    /// 过往病例
    /// </summary>
    public class Associate
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int AssocId { get; set; }
        /// <summary>
        /// 过往病例
        /// </summary>
        public string AssocName { get; set; }
        /// <summary>
        /// 当前时间
        /// </summary>
        public DateTime AssocTable { get; set; }
        /// <summary>
        /// 医生创建人 自动识别登录医生的姓名
        /// </summary>
        public int Createperson { get; set; }
    }
}
