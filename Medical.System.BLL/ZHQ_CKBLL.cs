using System;
using System.Collections.Generic;
using System.Text;
using Medical.Model;
using Medical.Model.ZHQ;
using Medical.System.Servers;
using Microsoft.Extensions.Options;

namespace Medical.System.BLL
{
   public class ZHQ_CKBLL
    {
        ZHQ_CKDAL dal;
        public ZHQ_CKBLL(IOptions<ConnectionStrings> conn)
        {
            dal = new ZHQ_CKDAL(conn);
        }
        /// <summary>
        /// 添加出库申请
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddCKSQ(CKSQ model)
        {
            return dal.AddCKSQ(model);
        }
        /// <summary>
        /// 查询出库申请
        /// </summary>
        /// <returns></returns>
        public List<CKSQ> GetCKSQ()
        {
            return dal.GetCKSQ();
        }
        /// <summary>
        /// 修改申批状态
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tgstate"></param>
        /// <returns></returns>
        public int UpdState(int id, int tgstate)
        {
            return dal.UpdState(id,tgstate);
        }
        /// <summary>
        /// 出库拒绝
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int CKJU(int id)
        {
            return dal.CKJU(id);
        }
        /// <summary>
        /// 出库
        /// </summary>
        /// <param name="id"></param>
        /// <param name="num"></param>
        /// <param name="tid"></param>
        /// <returns></returns>
        public double CKNUM(int id, int num, int tid)
        {
            return dal.CKNUM(id, num, tid);
        }
        /// <summary>
        /// 如果库存不做申请数量出已有库存的数量
        /// </summary>
        /// <param name="xnum"></param>
        /// <param name="tid"></param>
        /// <returns></returns>
        public int CXNUM(int xnum, int tid,int id)
        {
            return dal.CXNUM(xnum, tid,id);
        }
        /// <summary>
        /// 删除出库成功或出库拒绝信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DelCK(int id)
        {
            return dal.DelCK(id);
        }
    }
}
