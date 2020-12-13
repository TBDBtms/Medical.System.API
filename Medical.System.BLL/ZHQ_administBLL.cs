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
    }
}
