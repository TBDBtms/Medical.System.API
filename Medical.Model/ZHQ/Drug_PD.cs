using System;
using System.Collections.Generic;
using System.Text;

namespace Medical.Model.ZHQ
{
   public class Drug_PD
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Drug_PDId { get; set; }
        /// <summary>
        /// 药品编号
        /// </summary>
        public string Drug_PDBH { get; set; }
        /// <summary>
        /// 药品名称
        /// </summary>
        public string Drug_PDName { get; set; }
        /// <summary>
        /// 药品规格
        /// </summary>
        public string Drug_PDGG { get; set; }
        /// <summary>
        /// 上产厂家
        /// </summary>
        public int DanufacturerId { get; set; }
        /// <summary>
        /// 当前库存数量
        /// </summary>
        public int Drug_PDKC_DP { get; set; }
        /// <summary>
        /// 盘点库存数量
        /// </summary>
        public int Drug_PDKC_PD { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Drug_PD_Desc { get; set; }
    }
}
