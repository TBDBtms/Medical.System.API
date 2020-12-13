using System;
using System.Collections.Generic;
using System.Text;

namespace Medical.Model.ZHQ
{
   public class Page<T> where T:class,new()
    {
        public int Countnum { get; set; }

        public List<T> PageList { get; set; }

    }
}
