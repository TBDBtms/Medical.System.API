using System;
using System.Collections.Generic;
using System.Text;

namespace Medical.Model.HZX_Model
{
   public class Userinfo
    {
        /// <summary>
        ///员工id
        /// </summary>
        public int Uid { get; set; }
        /// <summary>
        /// 员工姓名
        /// </summary>
        public string Uname { get; set; }
        public bool Usex { get; set; }
        /// <summary>
        /// 年龄
        /// </summary>
        public int Uage { get; set; }
        /// <summary>
        /// 员工手机号
        /// </summary>
        public string Uiphone { get; set; }
        /// <summary>
        /// 科室外键
        /// </summary>
        public int Ukeids { get; set; }
        //创建时间
        public DateTime CreateTime { get; set; }
        //创建人
        public string CreatName { get; set; }
        public bool Uissale { get; set; }
        //账号
        public string Uzhanghao { get; set; }
        public string Upass { get; set; }
        //角色表外键
        public int rids { get; set; }
        //员工编号
        public int Uno { get; set; }
        //血型
        public string Uxue { get; set; }
        //市级表下拉
        public int cids { get; set; }
        /// <summary>
        /// 权限码
        /// </summary>
        public string Qma { get; set; }
        /// <summary>
        /// 角色名
        /// </summary>
        public string Rname { get; set; }
        /// <summary>
        /// 权限描述
        /// </summary>
        public string Qremark { get; set; }
        /// <summary>
        /// 市下拉
        /// </summary>
        public string Cname { get; set; }
        public string Kname { get; set; }

    }
}
