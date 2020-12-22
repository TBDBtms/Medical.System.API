using System;
using System.Collections.Generic;
using System.Text;

namespace Medical.Model.ZHQ
{
   public class RKSQ
    {
        //	RKSQId int primary key identity,
        public int RKSQId { get; set; }
        //RKSQYPName varchar(50),  --申请药品名称
        public string RKSQYPName { get; set; }
        //RKSQImg varchar(200),--图片
        public string RKSQImg { get; set; }
        //RKSQNum int,--申请数量
        public int RKSQNum { get; set; }
        //RKSQTime datetime,--申请时间
        public DateTime RKSQTime { get; set; }
        //RKSQName varchar(50),--申请人
        public string RKSQName { get; set; }
        //RKSQCGJ float,--采购价
        public float RKSQCGJ { get; set; }
        //RKSQLSJ float,--零售价
        public float RKSQLSJ { get; set; }
        //RKSQDesc varchar(50),--备注
        public string RKSQDesc { get; set; }
        //RKSQState int,--申请状态
        public int RKSQState { get; set; }
        //RKSQLX varchar(50),--申请药品的类型
        public string RKSQLX { get; set; }
        public string gtime { get; set; }
    }
}
