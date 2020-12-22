using System;
using System.Collections.Generic;
using System.Text;
using Medical.Model;
using Medical.Model.ZHQ;
using Medical.System.Servers;
using Microsoft.Extensions.Options;

namespace Medical.System.BLL
{
   public class ZHQ_RKBLL
    {
        ZHQ_RKDAL dal;
        public ZHQ_RKBLL(IOptions<ConnectionStrings> conn)
        {
            dal = new ZHQ_RKDAL(conn);
        }
        /// <summary>
        /// 添加申请
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddRKSQ(RKSQ model)
        {
            return dal.AddRKSQ(model);
        }
        /// <summary>
        /// 查询申请信息表
        /// </summary>
        /// <returns></returns>
        public List<RKSQ> GetRKSQ()
        {
            return dal.GetRKSQ();
        }
        /// <summary>
        /// 修改申批状态
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tgstate"></param>
        /// <returns></returns>
        public int UpdState(int id, int tgstate)
        {
            return dal.UpdState(id, tgstate);
        }
        /// <summary>
        /// 添加入库信息进行入库
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int AddRKB(int id)
        {
            return dal.AddRKB(id);
        }
        /// <summary>
        /// 查询入库信息表
        /// </summary>
        /// <returns></returns>
        public List<RKB> GetRKB()
        {
            return dal.GetRKB();
        }
        /// <summary>
        /// 入库拒绝
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int RKJU(int id)
        {
            return dal.RKJU(id);
        }
        /// <summary>
        /// 加库存
        /// </summary>
        /// <param name="num"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public int JiaNum(int num, int id)
        {
            return dal.JiaNum(num, id);
        }
    }
}
