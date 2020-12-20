using System;
using System.Collections.Generic;
using System.Text;

namespace Medical.Model.DLH_Medical.Model
{
    /// <summary>
    /// 医嘱信息
    /// </summary>
    public class Advice
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int AdviceId { get; set; }
        /// <summary>
        /// 医嘱信息
        /// </summary>
        public string AdviceName { get; set; }
        /// <summary>
        /// 当前时间
        /// </summary>
        public DateTime AdviceTable { get; set; }
        /// <summary>
        /// 医生创建人
        /// </summary>
        public int Createperson { get; set; }
        public string time { get; set; }

        #region 员工
        public int Uid { get; set; }
        public string Uname { get; set; }
        #endregion
    }
}
