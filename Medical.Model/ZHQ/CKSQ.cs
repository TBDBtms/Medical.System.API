using System;
using System.Collections.Generic;
using System.Text;

namespace Medical.Model.ZHQ
{
   public class CKSQ
    {
        //		CKSQId int primary key identity,
        public int CKSQId { get; set; }
        //CKSQYPName varchar(50),  --申请药品名称
        public string CKSQYPName { get; set; }
        //CKSQImg varchar(200),--图片
        public string CKSQImg { get; set; }
        //CKSQNum int,--申请数量
        public int CKSQNum { get; set; }
        //CKSQTime datetime,--申请时间
        public DateTime CKSQTime { get; set; }
        //CKSQName varchar(50),--申请人
        public string CKSQName { get; set; }
        //CKSQCGJ float,--采购价
        public float CKSQCGJ { get; set; }
        //CKSQLSJ float,--零售价
        public float CKSQLSJ { get; set; }
        //CKSQDesc varchar(500),--备注
        public string CKSQDesc { get; set; }
        //CKSQState int,--申请状态
        public int CKSQState { get; set; }
        //CKSQLX varchar(50),--申请药品的类型
        public string CKSQLX { get; set; }

    }
}
