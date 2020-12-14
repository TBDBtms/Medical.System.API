using System;
using System.Collections.Generic;
using System.Text;

namespace Medical.Model.ZZH_Model
{
    /// <summary>
    /// 患者来源
    /// </summary>
    public class PatientSource
    {
        /// <summary>
        /// 患者来源Id
        /// </summary>
        public int PatientSourceId { get; set; }
        /// <summary>
        /// 患者来源
        /// </summary>
        public string PatientSourceName { get; set; }
        public DateTime CreateTime { get; set; }
        public string CreatePeople { get; set; }
    }
}
