using System;
using System.Collections.Generic;
using System.Text;
using Medical.System.Servers;
using Medical.Model;
using Medical.Model.DLH_Medical.Model;
using Microsoft.Extensions.Options;

namespace Medical.System.BLL
{
    public class D_Fee_BLL
    {
        D_Fee_settings dal;
        private IOptions<ConnectionStrings> coon;

        public D_Fee_BLL(IOptions<ConnectionStrings> coon)
        {
            this.coon = coon;
        }

        /// <summary>
        /// 查询处方类型
        /// </summary>
        /// <returns></returns>
        public List<PrescriptionInfo> GetPrescriptionInfos()
        {
            return dal.GetPrescriptionInfos();
        }
        /// <summary>
        /// 附加费用设置
        /// </summary>
        /// <param name="name">费用名称</param>
        /// <param name="pid">处方类别</param>
        /// <returns></returns>
        public List<CostsInfo> GetCostsInfos(string name = "", int pid = 0)
        {
            return dal.GetCostsInfos(name, pid);
        }
        /// <summary>
        /// 删除附加费用
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public int DelCost(int cid)
        {
            return dal.DelCost(cid);
        }
        /// <summary>
        /// 修改附加费用
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int ModifyCost(CostsInfo model)
        {
            return dal.ModifyCost(model);
        }
        /// <summary>
        /// 修改附加回显
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public CostsInfo FXCost(int cid)
        {
            return dal.FXCost(cid);
        }
        /// <summary>
        /// 判断费用状态开始
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public int FYStart(CostsInfo c)
        {
            return dal.FYStart(c);
        }
        /// <summary>
        /// 判断费用状态关闭
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public int FYStart1(CostsInfo c)
        {
            return dal.FYStart1(c);
        }
        /// <summary>
        /// 会员状态为否
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public int VIPZheko(CostsInfo c)
        {
            return dal.VIPZheko(c);
        }
        /// <summary>
        /// 会员状态为是
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public int VIPZhoKo1(CostsInfo c)
        {
            return dal.VIPZhoKo1(c);
        }
    }
}
