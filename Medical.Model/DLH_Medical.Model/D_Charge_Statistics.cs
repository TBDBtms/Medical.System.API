using System;
using System.Collections.Generic;
using System.Text;

namespace Medical.Model.DLH_Medical.Model
{
    public class D_Charge_Statistics
    {

        public int WeijianId	 { get; set; }
        public int Patid		 { get; set; }
        public int Drug		    { get; set; }
        public int Vipid		 { get; set; }
        public int UserId		 { get; set; }
        public int MonryId		 { get; set; }
        public int CostssId	    { get; set; }
        public int ConId		 { get; set; }
        public int RegId		 { get; set; }
        public int keshiId      { get; set; }
        public float MoneeyCount { get; set; }

        #region 患者
        /// <summary>
        /// 患者主键
        /// </summary>
        public int PatientId { get; set; }
        /// <summary>
        /// 患者编码
        /// </summary>
        public string PatientCode { get; set; }
        /// <summary>
        /// 患者姓名
        /// </summary>
        public string PatientName { get; set; }
        /// <summary>
        /// 患者卡号
        /// </summary>
        public int PatientCard { get; set; }
        /// <summary>
        /// 患者年龄
        /// </summary>
        public int PatientAge { get; set; }
        /// <summary>
        /// 性别外键
        /// </summary>
        public bool PatientSex { get; set; }
        /// <summary>
        /// 患者手机号码
        /// </summary>
        public string PatientPhone { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public int Education { get; set; }
        #endregion

        #region 药
        /// <summary>
        /// 药品主键
        /// </summary>
        public int DrugId { get; set; }
        /// <summary>
        /// 药品通用名
        /// </summary>
        public string DrugTYM { get; set; }
        /// <summary>
        /// 药品零售价
        /// </summary>
        public float DrugLSJ { get; set; }
        /// <summary>
        /// 药品单次用量
        /// </summary>
        public int DrugDCYL { get; set; }
        /// <summary>
        /// 药品使用频度
        /// </summary>
        public string DrugPD { get; set; }
        /// <summary>
        /// 药品说明
        /// </summary>
        public string DrugSM { get; set; }
        #endregion

        #region 诊疗费
        /// <summary>
        /// 主键
        /// </summary>
        public int SequenceId { get; set; }
        /// <summary>
        /// 附件费用名称
        /// </summary>
        public string Additional { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public double MoneyInfn { get; set; }
        /// <summary>
        /// 会员折扣
        /// </summary>
        public bool Vip { get; set; }
        #endregion

        #region 附加费
        /// <summary>
        /// 主键
        /// </summary>
        public int SequenceIdes { get; set; }
        /// <summary>
        /// 附件费用名称
        /// </summary>
        public string Additionals { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public double MoneyInfns { get; set; }

        #endregion


        #region 挂号
        /// <summary>
        /// 主键
        /// </summary>
        public int SequenceIds { get; set; }
        /// <summary>
        /// 挂号费名称
        /// </summary>
        public string Registra { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public double MoneyInfnses { get; set; }
        #endregion

        #region 电子卡
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 会员等级
        /// </summary>
        public string VGradeName { get; set; }
        /// <summary>
        /// 折扣
        /// </summary>
        public float VIPReset { get; set; }
        /// <summary>
        /// 储值余额
        /// </summary>
        public decimal SvalueMoney { get; set; }
        #endregion

        #region 工作人员
        public int Uid { get; set; }
        public string Uname { get; set; }
        #endregion

        #region 挂号相关表
        /// <summary>
        /// 挂号id
        /// </summary>
        public int Gid { get; set; }
        /// <summary>
        ///编号
        /// </summary>
        public int Gno { get; set; }
        /// <summary>
        /// 科室外键
        /// </summary>
        public int ksids { get; set; }
        /// <summary>
        /// 接诊类型外键
        /// </summary>
        public int Jids { get; set; }
        /// <summary>
        /// 医生外键
        /// </summary>
        public string Yname { get; set; }
        /// <summary>
        /// 挂号日期
        /// </summary>
        public DateTime Gtime { get; set; }
        /// <summary>
        /// 挂号员
        /// </summary>
        public string Gpelete { get; set; }
        /// <summary>
        /// 患者姓名
        /// </summary>
        public string Hname { get; set; }
        /// <summary>
        /// 患者卡号
        /// </summary>
        public string Hkahao { get; set; }
        /// <summary>
        /// 患者年龄
        /// </summary>
        public int Hage { get; set; }
        /// <summary>
        /// 患者出生日期
        /// </summary>
        public DateTime Hcreatetime { get; set; }
        /// <summary>
        /// 患者性别
        /// </summary>
        public bool Hsex { get; set; }
        /// <summary>
        /// 患者手机号
        /// </summary>
        public string Hiphone { get; set; }

        #endregion

        #region 科室
        /// <summary>
        /// 科室id
        /// </summary>
        public int Kid { get; set; }
        /// <summary>
        /// 科室名称
        /// </summary>
        public string Kname { get; set; }
        #endregion

    }
}
