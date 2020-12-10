using System;
using System.Collections.Generic;
using System.Text;

namespace Medical.Model.Jcy_Model
{
    /// <summary>
    /// 供应商
    /// </summary>
    public class SupplierInfo
    {
        /// <summary>
        /// 供应商表主键
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 供应商编号
        /// </summary>
        public string SupGIS { get; set; }
        /// <summary>
        /// 供应商名称
        /// </summary>
        public string SupName { get; set; }
        /// <summary>
        /// 联系人
        /// </summary>
        public string LinkMan { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string LinkPhone { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CTimes { get; set; }
        /// <summary>
        /// 创建人员
        /// </summary>
        public string CMan { get; set; }
        /// <summary>
        /// 供应商状态
        /// </summary>
        public int SupState { get; set; }
        /// <summary>
        /// 说明
        /// </summary>
        public string Remark { get; set; }
    }
}
