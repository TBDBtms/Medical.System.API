using System;
using System.Collections.Generic;
using System.Text;

namespace Medical.Model.ZHQ
{
  public  class Drug_administration
    {
        /// <summary>
        /// 药品主键
        /// </summary>
        public int DrugId { get; set; }
        /// <summary>
        /// 药品编码
        /// </summary>
        public string DrugBM { get; set; }
        /// <summary>
        /// 药品条形码
        /// </summary>
        public string DrugTXM { get; set; }
        /// <summary>
        /// 药品通用名
        /// </summary>
        public string DrugTYM { get; set; }
        /// <summary>
        /// 药品拼音码
        /// </summary>
        public string DrugPYM { get; set; }
        /// <summary>
        /// 关联药品分类表
        /// </summary>
        public int DrugFL { get; set; }
        /// <summary>
        /// 药品规格
        /// </summary>
        public string DrugGG { get; set; }
        /// <summary>
        /// 关联药品剂型表
        /// </summary>
        public int DrugJX { get; set; }
        /// <summary>
        /// 关联药品发票表
        /// </summary>
        public int DrugFP { get; set; }
        /// <summary>
        /// 药品批准文号
        /// </summary>
        public string DrugWH { get; set; }
        /// <summary>
        /// 关联生产厂家表
        /// </summary>
        public int DrugCJ { get; set; }
        /// <summary>
        /// 关联单位表 包装单位,
        /// </summary>
        public string DrugBZDW { get; set; }
        /// <summary>
        /// 包装单位基本系数
        /// </summary>
        public int DrugBZDWXS { get; set; }
        /// <summary>
        /// 关联单位表 基本单位,
        /// </summary>
        public string DrugJBDW { get; set; }
        /// <summary>
        /// 剂量系数
        /// </summary>
        public int DrugJLXS { get; set; }
        /// <summary>
        /// 剂量单位，关联单位表
        /// </summary>
        public string DrugJLDW { get; set; }
        /// <summary>
        /// 药品采购价
        /// </summary>
        public float DrugCGJ { get; set; }
        /// <summary>
        /// 药品零售价
        /// </summary>
        public float DrugLSJ { get; set; }
        /// <summary>
        /// 药品用法
        /// </summary>
        public string DrugYF { get; set; }
        /// <summary>
        /// 药品单次用量
        /// </summary>
        public int DrugDCYL { get; set; }
        /// <summary>
        /// 药品使用频度
        /// </summary>
        public string DrugPD { get; set; }
        /// <summary>
        /// 药品有效期
        /// </summary>
        public string DrugYXQ { get; set; }
        /// <summary>
        /// 库存上限
        /// </summary>
        public int DrugKCSX { get; set; }
        /// <summary>
        /// 库存下线
        /// </summary>
        public int DrugKCXX { get; set; }
        /// <summary>
        /// 药品说明
        /// </summary>
        public string DrugSM { get; set; }
        /// <summary>
        /// 药品销售数量
        /// </summary>
        public int DrugXSNum { get; set; }
        /// <summary>
        /// 盘点状态
        /// </summary>
        public int DrupPDState { get; set; }
        /// <summary>
        /// 药品状态
        /// </summary>
        public int DrugState { get; set; }
        /// <summary>
        /// 药品分类名称
        /// </summary>
        public string DrugClassName { get; set; }
        /// <summary>
        /// 发票项目名称
        /// </summary>
        public string InvoiceName { get; set; }
        /// <summary>
        /// 药品剂型名称
        /// </summary>
        public string Dosage_formName { get; set; }
        /// <summary>
        /// 生产厂家名称
        /// </summary>
        public string ManufacturerName { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime Drugctime { get; set; }
        /// <summary>
        /// 库存
        /// </summary>
        public int DrugKC { get; set; }
    }
}
