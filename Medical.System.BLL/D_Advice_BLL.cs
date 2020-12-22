using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Options;
using Medical.Model;
using Medical.System.Servers;
using Medical.Model.ZHQ;
using Medical.Model.DLH_Medical.Model;

namespace Medical.System.BLL
{
    public class D_Advice_BLL
    {
        public IOptions<ConnectionStrings> _conn;

        D_Advice dal;

        public D_Advice_BLL(IOptions<ConnectionStrings> conn)
        {
            _conn = conn;
            dal = new D_Advice(conn);
        }


        /// <summary>
        /// 显示诊断信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>

        public Page<Advice> GetAdvice(int tj = 0, string name = "", int pageindex = 1, int pagesize = 10)
        {
            return dal.GetAdvice(tj, name, pageindex, pagesize);
        }
        /// <summary>
        /// 添加诊断信息
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public int AdviceAdd(Advice c)
        {
            return dal.AdviceAdd(c);
        }
        /// <summary>
        /// 修改诊断信息
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public int AdviceModify(Advice c)
        {
            return dal.AdviceModify(c);
        }
        /// <summary>
        /// 回显
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public Advice GetAdvices(int cid = 0)
        {
            return dal.GetAdvices(cid);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public int DeleteAdvice(int cid)
        {
            return dal.DeleteAdvice(cid);
        }
    }
}
