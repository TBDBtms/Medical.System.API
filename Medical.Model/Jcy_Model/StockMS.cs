using System;
using System.Collections.Generic;
using System.Text;

namespace Medical.Model.Jcy_Model
{
    /// <summary>
    /// 库存管理
    /// </summary>
    public class StockMS
    {
        /// <summary>
        /// 库存管理表主键
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 药品编码
        /// </summary>
        public string GSI { get; set; }
        /// <summary>
        /// 货位号
        /// </summary>
        public string ShyCard { get; set; }
        /// <summary>
        /// 药品名称
        /// </summary>
        public string DrugName { get; set; }
        /// <summary>
        /// 处方类别id
        /// </summary>
        public int CFId { get; set; }
        /// <summary>
        /// 规格
        /// </summary>
        public string Sizes { get; set; }
        /// <summary>
        /// 剂型
        /// </summary>
        public string DosageX { get; set; }
        /// <summary>
        /// 厂家
        /// </summary>
        public string Factory { get; set; }
        /// <summary>
        /// 库存
        /// </summary>
        public string Repertory { get; set; }
        /// <summary>
        /// 采购金额
        /// </summary>
        public decimal PurchPrice { get; set; }
        /// <summary>
        /// 零售金额
        /// </summary>
        public decimal RetailPrice { get; set; }
    }
}
