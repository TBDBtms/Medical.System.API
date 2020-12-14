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
        public Page<Drug_administration> Getadministration(int tj = 0, string name = "", int pageindex = 1, int pagesize = 10)
        {
            return dal.Getadministration(tj,name,pageindex,pagesize);
        }
        public int Addadministration(Drug_administration model)
        {
            return dal.Addadministration(model);
        }
        /// <summary>
        /// 查询分类表
        /// </summary>
        /// <returns></returns>
        public List<Drug_classification> Getclassification()
        {
            return dal.Getclassification();
        }
        /// <summary>
        /// 查询剂型
        /// </summary>
        /// <returns></returns>
        public List<Dosage_form> Getform()
        {
            return dal.Getform();
        }
        /// <summary>
        /// 查询发票
        /// </summary>
        /// <returns></returns>
        public List<Invoice1> GetInvoice1()
        {
            return dal.GetInvoice1();
        }
        /// <summary>
        /// 查询厂家
        /// </summary>
        /// <returns></returns>
        public List<Manufacturer> GetManufacturer()
        {
            return dal.GetManufacturer();
        }
        /// <summary>
        /// 修改药品价格根据Id获取单挑数据
        /// </summary>
        /// <returns></returns>
        public Drug_administration GetFirstPricing(int id = 0)
        {
            return dal.GetFirstPricing(id);
        }
        /// <summary>
        /// 修改药品价格
        /// </summary>
        /// <param name="id"></param>
        /// <param name="price"></param>
        /// <returns></returns>
        public int UpdPrice(int id = 0, float price = 0)
        {
            return dal.UpdPrice(id, price);
        }
        /// <summary>
        /// 查询药品调价明细
        /// </summary>
        /// <returns></returns>
        public Page<Pricing> GetPricing(int tj = 0, string name = "", int pageindex = 1, int pagesize = 10)
        {
            return dal.GetPricing(tj, name, pageindex, pagesize);
        }
        /// <summary>
        /// 添加药品调价明细
        /// </summary>
        /// <returns></returns>
        public int AddPricing(Pricing model)
        {
            return dal.AddPricing(model);
        }
    }
}
