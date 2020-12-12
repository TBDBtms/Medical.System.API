using System;
using System.Collections.Generic;
using System.Text;
using Medical.Model;
using Microsoft.Extensions.Options;
using Medical.System.Servers;
using Medical.Model.ZHQ;

namespace Medical.System.BLL
{
  public  class ZHQ_administBLL
    {
        ZHQ_administrationDAL dal;
        public ZHQ_administBLL(IOptions<ConnectionStrings> conn)
        {
            dal = new ZHQ_administrationDAL(conn);
        }
        public List<Drug_administration> Getadministration(string name="")
        {
            return dal.Getadministration(name);
        }
    }
}
