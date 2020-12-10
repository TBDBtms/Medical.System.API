using System;
using System.Collections.Generic;
using System.Text;

namespace Medical.Model.HZX_Model
{
  public  class County
    {
        /// <summary>
        /// 市id
        /// </summary>
        public int Cid { get; set; }
        /// <summary>
        /// 市名称
        /// </summary>
        public string Cname { get; set; }
        /// <summary>
        /// 县的外键
        /// </summary>
        public int mids { get; set; }
    }
}
