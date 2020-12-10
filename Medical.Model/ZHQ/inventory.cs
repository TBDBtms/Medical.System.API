using System;
using System.Collections.Generic;
using System.Text;

namespace Medical.Model.ZHQ
{
   public class inventory
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int inventoryId { get; set; }
        /// <summary>
        /// 商品单号
        /// </summary>
        public string ProductDH { get; set; }
        /// <summary>
        /// 库存商品名称
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// 库存商品单价
        /// </summary>
        public float ProductPrice { get; set; }
        /// <summary>
        /// 商品生产厂家
        /// </summary>
        public int ManufacturerId { get; set; }
        /// <summary>
        /// 商品剩余数量
        /// </summary>
        public int ProductKC { get; set; }
        /// <summary>
        /// 商品入库日期
        /// </summary>
        public DateTime RKRJ { get; set; }
        /// <summary>
        /// 商品备注
        /// </summary>
        public string ProductDesc { get; set; }
        /// <summary>
        /// 药剂类型
        /// </summary>
        public int Dosage_formId { get; set; }
    }
}
