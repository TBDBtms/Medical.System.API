using System;
using System.Collections.Generic;
using System.Text;

namespace Medical.Model.DLH_Medical.Model
{
    /// <summary>
    /// 处方类别
    /// </summary>
    public class PrescriptionInfo
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int RecipeId { get; set; }
        /// <summary>
        /// 处方类型名称
        /// </summary>
        public string RecipeName { get; set; }
    }
}
