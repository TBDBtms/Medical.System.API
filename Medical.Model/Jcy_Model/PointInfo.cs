using System;
using System.Collections.Generic;
using System.Text;

namespace Medical.Model.Jcy_Model
{
    /// <summary>
    /// 积分变动记录表
    /// </summary>
    public class PointInfo
    {
        public int Id { get; set; }
        public DateTime NewTimes { get; set; }
        public string ChangeCZ { get; set; }
        public int Num { get; set; }
        public string Man { get; set; }
        public string Remark { get; set; }
    }
}
