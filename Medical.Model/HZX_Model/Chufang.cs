using System;
using System.Collections.Generic;
using System.Text;

namespace Medical.Model.HZX_Model
{
  public  class Chufang
    {
        public int Fid         { get; set; }
        public string Hname       { get; set; }
        public string Hkahao      { get; set; }
        public string Hage        { get; set; }
        public DateTime Hcreatetime { get; set; }
        public bool Hsex        { get; set; }
        public string Hiphone     { get; set; }
        public string Hsfz        { get; set; }
        public int Jztid       { get; set; }
        public int ccids       { get; set; }
        public string Haddress    { get; set; }
        public string Zduan       { get; set; }
        public string Yizhu { get; set; }
        /// <summary>
        /// 接诊类型名称
        /// </summary>
        public string Jname { get; set; }
        public string Cname { get; set; }
    }
}
