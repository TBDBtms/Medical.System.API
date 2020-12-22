using System;
using System.Collections.Generic;
using System.Text;

namespace Medical.Model.ZHQ
{
   public class ZRK
    {
        //	ZRKId int primary key identity,
        public int ZRKId { get; set; }
        //ZRKBH varchar(50),--入库编号
        public string ZRKBH { get; set; }
        //ZRKYPName varchar(50),--入库药品名称
        public string ZRKYPName { get; set; }
        //ZRKName varchar(50),--操作人
        public string ZRKName { get; set; }
        //ZRKCGJ float,--采购价
        public float ZRKCGJ { get; set; }
        //ZRKLSJ float,--零售价
        public float ZRKLSJ { get; set; }
        //ZRKLX varchar(50),--入库类型
        public string ZRKLX { get; set; }
        //ZRKTime datetime,--操作时间
        public DateTime ZRKTime { get; set; }
        //ManufacturerId int,--关联生产厂家
        public int ManufacturerId { get; set; }
        //ZRKDW varchar(50),--药品单位
        public string ZRKDW { get; set; }

        //ImgUrl varchar(500),--图片
        public string ImgUrl { get; set; }

        public int DrugFL { get; set; } //药品分类
        public string ZRKGG { get; set; }//药品规格

        public int ZRKnum { get; set; } //申请数量
    }
}
