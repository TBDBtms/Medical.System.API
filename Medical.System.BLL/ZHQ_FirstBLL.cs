using System;
using System.Collections.Generic;
using System.Text;
using Medical.Model;
using Microsoft.Extensions.Options;
using Medical.System.Servers;
using Medical.Model.ZHQ;

namespace Medical.System.BLL
{
  public  class ZHQ_FirstBLL
    {
        ZHQ_FirstDAL dal;
        public ZHQ_FirstBLL(IOptions<ConnectionStrings> conn)
        {
            dal = new ZHQ_FirstDAL(conn);
        }

        public List<Drug_administration> GetDrug_administration()
        {
            return dal.GetDrug_administration();
        }
    }
}
