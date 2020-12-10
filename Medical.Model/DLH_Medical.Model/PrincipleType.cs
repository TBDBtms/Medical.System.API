using System;
using System.Collections.Generic;
using System.Text;

namespace Medical.Model.DLH_Medical.Model
{
    /// <summary>
    /// 主诉分类
    /// </summary>
    public class PrincipleType
    {
        /// <summary>
        /// 主诉分类Id
        /// </summary>
        public int PrincipleTypeId { get; set; }
        /// <summary>
        /// 主诉分类名称
        /// </summary>
        public string PrincipleTypeName { get; set; }
    }
}
