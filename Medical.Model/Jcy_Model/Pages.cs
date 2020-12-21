using System;
using System.Collections.Generic;
using System.Text;

namespace Medical.Model.Jcy_Model
{
    public class Pages<T> where T:class,new()
    {
        public int Countnum { get; set; }

        public List<T> PageList { get; set; }
    }
}
