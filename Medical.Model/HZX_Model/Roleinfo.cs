using System;
using System.Collections.Generic;
using System.Text;

namespace Medical.Model.HZX_Model
{
   public class Roleinfo
    {
        /// <summary>
        /// 角色id
        /// </summary>
        public int Rid { get; set; }
        /// <summary>
        /// 角色姓名
        /// </summary>
        public string Rname { get; set; }
        /// <summary>
        /// 权限外键
        /// </summary>
        public int qids { get; set; }
    }
}
