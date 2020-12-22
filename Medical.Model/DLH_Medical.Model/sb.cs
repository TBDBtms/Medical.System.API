using System;
using System.Collections.Generic;
using System.Text;

namespace Medical.Model.DLH_Medical.Model
{
    public class sb
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int CaseId { get; set; }
        /// <summary>
        /// 诊断内容
        /// </summary>
        public string CaseName { get; set; }
        /// <summary>
        /// 当前时间
        /// </summary>
        public DateTime CaseTable { get; set; }
        /// <summary>
        /// 医生创建人 自动识别登录医生的姓名
        /// </summary>
        public int Createperson { get; set; }

        public string time { get; set; }

        #region 员工
        public int Uid { get; set; }
        public string Uname { get; set; }
        #endregion

        /// <summary>
        /// 主键
        /// </summary>
        public int PastId { get; set; }
        /// <summary>
        /// 病史内容
        /// </summary>
        public string PastName { get; set; }
        /// <summary>
        /// 当前时间
        /// </summary>
        public DateTime PastTable { get; set; }
        /// <summary>
        /// 医生创建人 自动识别登录医生的姓名
        /// </summary>
       
    }
}
