using System;
using System.Collections.Generic;
using System.Text;
using Medical.Model.Jcy_Model;
using Medical.Model;
using Medical.System.Servers;
using Microsoft.Extensions.Options;

namespace Medical.System.BLL
{
    public class Jcy_VIPInfoBLL
    {
        Jcy_VIPInfoDAL dal;
        public Jcy_VIPInfoBLL(IOptions<ConnectionStrings> conn)
        {
            dal = new Jcy_VIPInfoDAL(conn);
        }
    }
}
