using System;
using System.Collections.Generic;
using System.Text;

namespace Medical.Model.ZHQ
{
   public class Examination_RK
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int RK_ExaminationId { get; set; }
        /// <summary>
        /// 单号
        /// </summary>
        public string RK_ExaminationDH { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        public float RK_ExaminationPrice { get; set; }
        /// <summary>
        /// 厂家
        /// </summary>
        public int RK_ManufacturerId { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int RK_ExaminationNumber { get; set; }
        /// <summary>
        /// 提交日期
        /// </summary>
        public DateTime RK_ExaminationTime { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string RK_ExaminationDesc { get; set; }
    }
}
