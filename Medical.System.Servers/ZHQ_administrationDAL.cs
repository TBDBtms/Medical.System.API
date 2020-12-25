using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Medical.Model;
using Microsoft.Extensions.Options;
using Medical.Model.ZHQ;
using Dapper;
using System.Linq;

namespace Medical.System.Servers
{
   public class ZHQ_administrationDAL
    {
        IDbConnection dbconn;
        public ZHQ_administrationDAL(IOptions<ConnectionStrings> conn)
        {
            dbconn = new SqlConnection(conn.Value.Conn);
        }
        /// <summary>
        /// 查看所有药品
        /// </summary>
        /// <returns></returns>
        public Page<Drug_administration> Getadministration(int tj=0,string name="",int pageindex=1,int pagesize=10, int pp = 0, int fl = 0, int jx = 0)
        {
            if (!string.IsNullOrEmpty(name))
            {
                var t = IsNumberic(name);
                if (t)
                {
                    tj = 1;
                }
                else
                {
                    tj = 2;
                }
            }
            else
            {
                name = "";
            }
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter() { ParameterName="@PP",DbType=DbType.Int32,Value=pp},
                new SqlParameter() { ParameterName="@JX",DbType=DbType.Int32,Value=jx},
                new SqlParameter() { ParameterName="@FL",DbType=DbType.Int32,Value=fl},
                new SqlParameter() { ParameterName="@DId",DbType=DbType.Int32,Value=tj},
                new SqlParameter() { ParameterName="@Name",DbType=DbType.String,Value=name},
                new SqlParameter() { ParameterName="@PageIndex",DbType=DbType.Int32,Value=pageindex},
                new SqlParameter() { ParameterName="@PageSize",DbType=DbType.Int32,Value=pagesize},
                new SqlParameter() { ParameterName="@AllCount",DbType=DbType.Int32,Direction= ParameterDirection.Output},
            };
            List<Drug_administration> list = DBhelper.GetDataTable_Proc<Drug_administration>("Drug_administrationPage", param);

            Page<Drug_administration> page = new Page<Drug_administration>()
            { 
                 Countnum = Convert.ToInt32(param[7].Value),
                 PageList=list
            }; 
            return page;
        }
        private bool IsNumberic(string name="")
        {
            try
            {
                int var1 = Convert.ToInt32(name);
                return true;
            }
            catch
            {
                return false;
            }
        }
        //DrugId, DrugBM, DrugTXM, DrugTYM, DrugPYM, DrugFL, DrugGG, DrugJX, DrugFP, DrugWH, DrugCJ,
        //DrugBZDW, DrugBZDWXS, DrugJBDW, DrugJLXS, DrugJLDW, DrugCGJ, DrugLSJ, DrugYF, DrugDCYL, DrugPD,
        //DrugYXQ, DrugKCSX, DrugKCXX, DrugSM, DrugXSNum, DrupPDState, DrugState
        /// <summary>
        /// 添加药品
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Addadministration(Drug_administration model)
        {
            model.Drugctime = DateTime.Now;
            model.DrugState = 1;
            model.DrupPDState = 0;
            model.DrugXSNum = 0;
            model.DrugKC = 0;
            model.DrugWH = "99999";
            model.DrugJSKC = 0;
            return dbconn.Execute("insert into Drug_administration values(@DrugBM, @DrugTXM, @DrugTYM, @DrugPYM, @DrugFL, @DrugGG, @DrugJX, @DrugFP, @DrugWH, @DrugCJ, @DrugBZDW, @DrugBZDWXS, @DrugJBDW, @DrugJLXS, @DrugJLDW, @DrugCGJ, @DrugLSJ, @DrugYF,@DrugDCYL, @DrugPD, @DrugYXQ, @DrugKCSX, @DrugKCXX, @DrugSM,@DrugXSNum,@DrupPDState,@DrugState,@Drugctime,@DrugKC,@DrugBrandId,@ImgUrl,@DrugJSKC)", model);
        }

        /// <summary>
        /// 查询分类表
        /// </summary>
        /// <returns></returns>
        public List<Drug_classification> Getclassification()
        {
            string sql = "select * from Drug_classification";
            return dbconn.Query<Drug_classification>(sql).ToList();
        }
        /// <summary>
        /// 查询剂型
        /// </summary>
        /// <returns></returns>
        public List<Dosage_form> Getform()
        {
            string sql = "select * from Dosage_form";
            return dbconn.Query<Dosage_form>(sql).ToList();
        }
        /// <summary>
        /// 查询发票
        /// </summary>
        /// <returns></returns>
        public List<Invoice1> GetInvoice1()
        {
            string sql = "select * from Invoice1";
            return dbconn.Query<Invoice1>(sql).ToList();
        }
        /// <summary>
        /// 查询品牌表
        /// </summary>
        /// <returns></returns>
        public List<Brand> GetBrand()
        {
            string sql = "select * from Brand";
            return dbconn.Query<Brand>(sql).ToList() ;
        }
        /// <summary>
        /// 查询厂家
        /// </summary>
        /// <returns></returns>
        public List<Manufacturer> GetManufacturer()
        {
            string sql = "select * from Manufacturer";
            return dbconn.Query<Manufacturer>(sql).ToList();
        }
        /// <summary>
        /// 修改药品价格根据Id获取单挑数据
        /// </summary>
        /// <returns></returns>
        public Drug_administration GetFirstPricing(int id=0)
        {
            string sql = $"select * from Drug_administration a join Drug_classification b on a.DrugFL=b.DrugClassId join Dosage_form c on a.DrugJX=c.Dosage_formId join Invoice1 d on a.DrugFP=d.InvoiceId join Manufacturer e on a.DrugCJ=e.ManufacturerId join Brand p on a.DrugBrandId=p.BrandId where a.DrugId={id}";
            return dbconn.Query<Drug_administration>(sql).ToList().FirstOrDefault();
        }
        /// <summary>
        /// 修改药品价格方法
        /// </summary>
        /// <param name="id"></param>
        /// <param name="price"></param>
        /// <returns></returns>
        public int UpdPrice(int id = 0, float price = 0)
        {
            string sql = $"update Drug_administration set DrugLSJ={price} where DrugId={id}";
            return dbconn.Execute(sql);
        }
        /// <summary>
        /// 查询药品调价明细
        /// </summary>
        /// <returns></returns>
        public Page<Pricing> GetPricing(int tj = 0, string name = "", int pageindex = 1, int pagesize = 10) 
        {
            if (!string.IsNullOrEmpty(name))
            {
                var t = IsNumberic(name);
                if (t)
                {
                    tj = 1;
                }
                else
                {
                    tj = 2;
                }
            }
            else
            {
                name = "";
            }
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter() { ParameterName="@DId",DbType=DbType.Int32,Value=tj},
                new SqlParameter() { ParameterName="@Name",DbType=DbType.String,Value=name},
                new SqlParameter() { ParameterName="@PageIndex",DbType=DbType.Int32,Value=pageindex},
                new SqlParameter() { ParameterName="@PageSize",DbType=DbType.Int32,Value=pagesize},
                new SqlParameter() { ParameterName="@AllCount",DbType=DbType.Int32,Direction= ParameterDirection.Output},
            };
            List<Pricing> list = DBhelper.GetDataTable_Proc<Pricing>("PricingPage", param);

            Page<Pricing> page = new Page<Pricing>()
            {
                Countnum = Convert.ToInt32(param[4].Value),
                PageList = list
            };
            return page;
        }
        /// <summary>
        /// 添加药品调价明细
        /// </summary>
        /// <returns></returns>
        public int AddPricing(Pricing model)
        {
            model.PricingTime = DateTime.Now;
            return dbconn.Execute("insert into Pricing values(@PricingBH, @PricingName, @PricingGG, @PricingKC,@PricingCGJ, @PricingLSJ, @PricingXLSJ, @PricingTime, @PricingRName)", model);
        }
     
    }
}
