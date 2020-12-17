using Medical.Model;
using Medical.Model.DLH_Medical.Model;
using Medical.System.Servers;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace Medical.System.BLL
{
    public class D_Settings
    {
        public IOptions<ConnectionStrings> _conn;
        D_SettinGInfo dal;
        public D_Settings(IOptions<ConnectionStrings> conn)
        {
            _conn = conn;
            dal = new D_SettinGInfo(conn);

        }


        /// <summary>
        /// 显示诊断信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<CaseInfo> GetCaseInfos(string name = "")
        {
            return dal.GetCaseInfos(name);
        }
        /// <summary>
        /// 添加诊断信息
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public int CassAdd(CaseInfo c)
        {
            return dal.CassAdd(c);
        }
        /// <summary>
        /// 修改诊断信息
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public int CaseModify(CaseInfo c)
        {
            return dal.CaseModify(c);
        }
        /// <summary>
        /// 回显
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public CaseInfo GetCase(int cid)
        {
            return dal.GetCase(cid);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public int DeleteCase(int cid)
        {
            return dal.DeleteCase(cid);
        }
    }
}
