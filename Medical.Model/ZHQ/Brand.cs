using System;
using System.Collections.Generic;
using System.Text;

namespace Medical.Model.ZHQ
{
   public class Brand
    {

        //   BrandId int primary key identity,
        public int BrandId { get; set; }   //品牌表主键
        //BrandName varchar(50)
        public string BrandName { get; set; }  //品牌名称
    }
}
