using System;
using System.Collections.Generic;
using System.Text;

namespace Medical.Model.ZHQ
{
  public  class Drug_classification
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int DrugClassId { get; set; }
        /// <summary>
        /// 药品分类主键
        /// </summary>
        public string DrugClassName { get; set; }
    }
}
