using System;
using System.Collections.Generic;
using System.Text;

namespace Medical.Model.HZX_Model
{
    /// <summary>
    /// 挂号相关表
    /// </summary>
  public  class X_Guahao
    {
        /// <summary>
        /// 挂号id
        /// </summary>
        public int Gid         { get; set; }
        /// <summary>
        ///编号
        /// </summary>
        public int Gno         { get; set; }
  /// <summary>
  /// 科室外键
  /// </summary>
        public int ksids       { get; set; }
        /// <summary>
        /// 接诊类型外键
        /// </summary>
        public int Jids        { get; set; }
        /// <summary>
        /// 医生外键
        /// </summary>
        public int uids        { get; set; }
        /// <summary>
        /// 挂号费
        /// </summary>
        public string Gmoney      { get; set; }
        /// <summary>
        /// 诊疗费
        /// </summary>
        public string Zlmoney     { get; set; }
        /// <summary>
        /// 挂号日期
        /// </summary>
        public DateTime Gtime       { get; set; }
        /// <summary>
        /// 挂号员
        /// </summary>
        public string Gpelete     { get; set; }
        /// <summary>
        /// 患者姓名
        /// </summary>
        public string Hname       { get; set; }
        /// <summary>
        /// 患者卡号
        /// </summary>
        public string Hkahao      { get; set; }
        /// <summary>
        /// 患者年龄
        /// </summary>
        public int Hage        { get; set; }
        /// <summary>
        /// 患者出生日期
        /// </summary>
        public DateTime Hcreatetime { get; set; }
        /// <summary>
        /// 患者性别
        /// </summary>
        public bool Hsex        { get; set; }
        /// <summary>
        /// 患者手机号
        /// </summary>
        public string Hiphone     { get; set; }
        /// <summary>
        /// 患者身份证
        /// </summary>
        public string Hsfz        { get; set; }
        /// <summary>
        /// 患者家乡id外键
        /// </summary>
        public int Hcids       { get; set; }
        /// <summary>
        /// 患者详细地址
        /// </summary>
        public string Haddress    { get; set; }
        /// <summary>
        /// 留言
        /// </summary>
        public string Hremaek { get; set; }
    }
}
