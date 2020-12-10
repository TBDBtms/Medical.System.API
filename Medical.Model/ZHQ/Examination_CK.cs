using System;
using System.Collections.Generic;
using System.Text;

namespace Medical.Model.ZHQ
{
   public class Examination_CK
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int CK_ExaminationId { get; set; }
        /// <summary>
        /// 单号
        /// </summary>
        public string CK_ExaminationDH { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        public float CK_ExaminationPrice { get; set; }
        /// <summary>
        /// 厂家
        /// </summary>
        public int CK_ManufacturerId { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int CK_ExaminationNumber { get; set; }
        /// <summary>
        /// 提交日期
        /// </summary>
        public DateTime CK_ExaminationTime { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string CK_ExaminationDesc { get; set; }
    }
}
