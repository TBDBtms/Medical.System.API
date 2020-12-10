using System;
using System.Collections.Generic;
using System.Text;

namespace Medical.Model.ZZH_Model
{
    /// <summary>
    /// 市
    /// </summary>
    public class City
    {
        /// <summary>
        /// 市Id
        /// </summary>
        public int CityId { get; set; }
        /// <summary>
        /// 市名称
        /// </summary>
        public string CityName { get; set; }
        /// <summary>
        /// 省外键
        /// </summary>
        public int ProvinceId { get; set; }
    }
}
