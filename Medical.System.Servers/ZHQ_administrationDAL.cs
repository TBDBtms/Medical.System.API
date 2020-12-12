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
        public List<Drug_administration> Getadministration(string name="")
        {
            string sql = "select * from Drug_administration a join Drug_classification b on a.DrugFL=b.DrugClassId join " +
                "Dosage_form c on a.DrugJX = c.Dosage_formId join Invoice1 d on a.DrugFP = d.InvoiceId join Manufacturer e on" +
                " a.DrugCJ = e.ManufacturerId where 1=1";
            if (!string.IsNullOrEmpty(name))
            {
                var t = IsNumberic(name);
                if (t)
                {
                    sql += $" and a.DrugBM='{name}'";
                }
                else
                {
                    sql += $" and a.DrugTYM like '%{name}%'";
                }
            }
           
            var list = dbconn.Query<Drug_administration>(sql).ToList();
            return list;
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
    }
}
