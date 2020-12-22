using Medical.Model;
using Medical.Model.DLH_Medical.Model;
using Medical.Model.ZHQ;
using Medical.System.Servers;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace Medical.System.BLL
{
    public class D_Principleaction_BLL
    {
        public IOptions<ConnectionStrings> _conn;
        D_Principleaction dal;
        public D_Principleaction_BLL(IOptions<ConnectionStrings> conn)
        {
            _conn = conn;
            dal = new D_Principleaction(conn);
        }


        /// <summary>
        /// 显示过往病史信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        //public Page<Principleaction> GetPage(int tj = 0, string name = "", int pageindex = 1, int pagesize = 10)
        //{
        //    return dal.GetPage(tj, name, pageindex, pagesize);
        //}
        public List<sb> GetDate()
        {
            return dal.GetDate();
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public int DeletePrincipleaction(int cid)
        {
            return dal.DeletePrincipleaction(cid);
        }
    }
}
