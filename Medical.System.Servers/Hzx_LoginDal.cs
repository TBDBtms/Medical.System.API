using Dapper;
using Medical.Model;
using Medical.Model.HZX_Model;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Medical.System.Servers
{
  public  class Hzx_LoginDal
    {
        public IOptions<ConnectionStrings> _conn;
        IDbConnection dbcoon;
        public Hzx_LoginDal(IOptions<ConnectionStrings> coon)
        {

            _conn = coon;
            dbcoon = new SqlConnection(_conn.Value.Conn);

        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public List<Userinfo> Login(string Uiphone, string Upass)
        {
            string sql = $"select * from Userinfo u join Roleinfo r on r.Rid=u.rids join Quanxian q on q.Qid=r.qids join Keshi k on k.Kid=u.Ukeids join County c on c.Cid=u.cids join Market m on m.Mid=c.mids where Uiphone='{Uiphone}'and Upass='{Upass}' ";
            return dbcoon.Query<Userinfo>(sql).ToList();
        }
        /// <summary>
        /// 获取所有员工信息
        /// </summary>
        /// <returns></returns>
        public List<Userinfo> GetUserinfos()
        {
            string sql = $"select * from Userinfo u join Roleinfo r on r.Rid=u.rids join Quanxian q on q.Qid=r.qids join Keshi k on k.Kid=u.Ukeids join County c on c.Cid=u.cids join Market m on m.Mid=c.mids";
            return dbcoon.Query<Userinfo>(sql).ToList();
        }
        /// <summary>
        /// 添加员工
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int AddUserinfo(Userinfo u)
        {
            string sql = $"insert into Userinfo values('{u.Uname}','{u.Usex}','{u.Uage}','{u.Uiphone}','{u.Ukeids}','{u.CreateTime}','{u.CreatName}','{u.Uissale}','{u.Uzhanghao}','{u.Upass}','{u.rids}','{u.Uno}','{u.Uxue}','{u.cids}')";
            return dbcoon.Execute(sql);
        }
        /// <summary>
        /// 回显获取单条数据
        /// </summary>
        /// <param name="Uid"></param>
        /// <returns></returns>
        public Userinfo GetUserinfodan(int Uid)
        {
            string sql = $"select * from Userinfo u join Roleinfo r on r.Rid=u.rids join Quanxian q on q.Qid=r.qids join Keshi k on k.Kid=u.Ukeids join County c on c.Cid=u.cids join Market m on m.Mid=c.mids where Uid={Uid}";
            return dbcoon.Query<Userinfo>(sql).FirstOrDefault();
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="u">模型</param>
        /// <returns></returns>
        public int Upd(Userinfo u)
        {
            string sql = $"Update Userinfo set Uname='{u.Uname}',Usex='{u.Usex}',Uage='{u.Uage}',Uiphone='{u.Uiphone}',Ukeids='{u.Ukeids}',CreateTime='{u.CreateTime}',CreateName='{u.CreatName}',Uissale='{u.Uissale}',Uzhanghao='{u.Uzhanghao}',Upass='{u.Upass}',rids='{u.rids}',Uno='{u.Uno}',Uxue='{u.Uxue}',cids='{u.cids}'where Uid='{u.Uid}'";
            return dbcoon.Execute(sql);

        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Uid">id</param>
        /// <returns></returns>
        public int Del(int Uid)
        {
            string sql = $"delete from Userinfo where Uid='{Uid}'";
            return dbcoon.Execute(sql);
        }
        /// <summary>
        /// 角色下拉
        /// </summary>
        /// <returns></returns>
        public List<Roleinfo> GetRoleinfos()
        {
            string sql = $"select *from Roleinfo";
            return dbcoon.Query<Roleinfo>(sql).ToList();
        }
        /// <summary>
        /// 县级下拉
        /// </summary>
        /// <returns></returns>
        public List<Market> GetMarkets()
        {
            string sql = $"select * from Market";
            return dbcoon.Query<Market>(sql).ToList();
        }
        /// <summary>
        /// 市下拉
        /// </summary>
        /// <param name="Mid"></param>
        /// <returns></returns>
        public List<County> GetCounties(int Mid)
        {
            string sql = $"select * from County where mids={Mid}";
            return dbcoon.Query<County>(sql).ToList();
        }

    }
}
