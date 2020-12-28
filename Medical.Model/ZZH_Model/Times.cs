using System;
using System.Collections.Generic;
using System.Text;

namespace Medical.Model.ZZH_Model
{
    public class Times<T> where T : class, new()
    {
        public int Countnum { get; set; }

        public List<T> PageList { get; set; }
    }
}
