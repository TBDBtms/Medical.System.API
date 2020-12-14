using System;
using System.Collections.Generic;
using System.Text;

namespace Medical.Model.ZZH_Model
{
    /// <summary>
    /// 职位
    /// </summary>
    public class Position
    {
        /// <summary>
        /// 职位编号
        /// </summary>
        public int PositionId { get; set; }
        /// <summary>
        /// 职位名称
        /// </summary>
        public string PositionName { get; set; }
        public DateTime CreateTime { get; set; }
        public string CreatePeople { get; set; }
    }
}
