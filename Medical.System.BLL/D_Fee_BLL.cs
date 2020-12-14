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
        public IOptions<ConnectionStrings> _conn;
        D_Fee_settings dal;
        public D_Fee_BLL(IOptions<ConnectionStrings> conn)
        {
            _conn = conn;
            dal = new D_Fee_settings(conn);

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
            return dal.GetCostsInfos(name,pid);
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
        public CostsInfo FXCost(int cid=0)
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
        /// 会员状态为否
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public int VIPZheko(CostsInfo c)
        {
            return dal.VIPZheko(c);
        }
        /// <summary>
        /// 添加附加费用
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public int AddCost(CostsInfo c)
        {
            return dal.AddCost(c);
        }



        /// <summary>
        /// 诊疗费设置
        /// </summary>
        /// <param name="name">费用名称</param>
        /// <param name="pid">处方类别</param>
        /// <returns></returns>
        public List<Consultation> GetConsultations(string name="")
        {
            return dal.GetConsultations(name);   
        }

        /// <summary>
        /// 删除诊疗费用
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public int DelConsultations(int cid)
        {
            return dal.DelConsultations(cid);
        }
        /// <summary>
        /// 添加附加费用
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public int AddConsultations(Consultation c)
        {
            //c.CTime = DateTime.Now;
            return dal.AddConsultations(c);
        }
        /// <summary>
        /// 修改附加费用
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int ModifyConsultations(Consultation model)
        {
            return dal.ModifyConsultations(model);
        }
        /// <summary>
        /// 修改附加回显
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public Consultation FXConsultations(int cid = 0)
        {
            return dal.FXConsultations(cid);
        }

        //============================================挂号============
        /// <summary>
        /// 挂号费设置
        /// </summary>
        /// <param name="name">费用名称</param>
        /// <param name="pid">处方类别</param>
        /// <returns></returns>
        public List<Registration> GetRegistrations(string name = "")
        {
            return dal.GetRegistrations(name);
        }

        /// <summary>
        /// 删除诊疗费用
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public int DelRegistration(int cid)
        {
            return dal.DelRegistration(cid);
        }
        /// <summary>
        /// 添加挂号费用
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public int AddRegistration(Registration c)
        {
            return dal.AddRegistration(c);
        }
        /// <summary>
        /// 修改挂号费用
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int ModifyRegistration(Registration model)
        {
            return dal.ModifyRegistration(model);
        }
        /// <summary>
        /// 修改挂号回显
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public Registration FXRegistration(int cid = 0)
        {
            return dal.FXRegistration(cid);
        }
    }
}
