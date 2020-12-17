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
        public List<Userinfo> Login(string Uname, string Upass)
        {
            string sql = $"select * from Userinfo u join Roleinfo r on r.Rid=u.rids join Rqinfo rq on rq.Rids=r.Rid join Quanxian q on q.Qid=rq.Qids join Keshi ke on ke.Kid=u.Ukeids join County county on county.Cid=u.cids join Market m on m.Mid=county.mids where u.Uname='{Uname}'and u.Upass='{Upass}' ";
            return dbcoon.Query<Userinfo>(sql).ToList();
        }
        /// <summary>
        /// 获取所有员工信息
        /// </summary>
        /// <returns></returns>
        public List<Userinfo> GetUserinfos()
        {
            string sql = $"select * from Userinfo u join Roleinfo r on r.Rid=u.rids join Rqinfo rq on rq.Rids=r.Rid join Quanxian q on q.Qid=rq.Qids join Keshi ke on ke.Kid=u.Ukeids join County county on county.Cid=u.cids join Market m on m.Mid=county.mids";
            return dbcoon.Query<Userinfo>(sql).ToList();
        }
        /// <summary>
        /// 添加员工
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int AddUserinfo(Userinfo u)
        {
            string sql = $"insert into Userinfo values('{u.Uname}','{u.Usex}','{u.Uage}','{u.Uiphone}','{u.Ukeids}','{DateTime.Now}','{u.CreatName}','{u.Uissale}','{u.Uzhanghao}','{u.Upass}','{u.rids}','{u.Uno}','{u.Uxue}','{u.cids}')";
            return dbcoon.Execute(sql);
        }
        /// <summary>
        /// 回显获取单条数据
        /// </summary>
        /// <param name="Uid"></param>
        /// <returns></returns>
        public Userinfo GetUserinfodan(int Uid)
        {
            string sql = $"select * from Userinfo u join Roleinfo r on r.Rid=u.rids join Rqinfo rq on rq.Rids=r.Rid join Quanxian q on q.Qid=rq.Qids join Keshi ke on ke.Kid=u.Ukeids join County county on county.Cid=u.cids join Market m on m.Mid=county.mids where Uid={Uid}";
            return dbcoon.Query<Userinfo>(sql).FirstOrDefault();
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="u">模型</param>
        /// <returns></returns>
        public int Upd(Userinfo u)
        {
            u.CreateTime = DateTime.Now;
            string sql = $"Update Userinfo set Uname='{u.Uname}',Usex='{u.Usex}',Uage='{u.Uage}',Uiphone='{u.Uiphone}',Ukeids='{u.Ukeids}',CreateTime='{u.CreateTime}',CreatName='{u.CreatName}',Uissale='{u.Uissale}',Uzhanghao='{u.Uzhanghao}',Upass='{u.Upass}',rids='{u.rids}',Uno='{u.Uno}',Uxue='{u.Uxue}',cids='{u.cids}' where Uid='{u.Uid}'";
            return dbcoon.Execute(sql);

        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Uid">id</param>
        /// <returns></returns>
        public int DelUserinfo(int Uid)
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
        public List<Quanxian> GetQuanxians()
        {
            string sql = $"select *from Quanxian";
            return dbcoon.Query<Quanxian>(sql).ToList();
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

        /// <summary>
        /// 科室下拉
        /// </summary>
        /// <returns></returns>
        public List<Keshi> GetKeshis()
        {
            string sql = $"select * from Keshi";
            return dbcoon.Query<Keshi>(sql).ToList();
        
        }
        /// <summary>
        /// 配置权限
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public bool Addquan(Rqinfo r)
        {
            var list = r.Qids.TrimEnd(',').Split(',');
            List<string> sql = new List<string>();
            foreach (var m in list)
            {
                sql.Add($"insert into Rqinfo(Qids,Rids) values({m},{r.Rids})");

            }
            return DBHelper2.ExecuteSqlTran(sql);
        
        
        }
        /// <summary>
        /// 通过用户名修改密码
        /// </summary>
        /// <param name="Uname"></param>
        /// <param name="Upass"></param>
        /// <returns></returns>
        public int UpdPass(string Uname, string Upass)
        {
            string sql = $"update Userinfo set Upass='{Upass}' where Uname='{Uname}'";
            return dbcoon.Execute(sql);
        
        
        }
        /// <summary>
        /// 找回密码
        /// </summary>
        /// <param name="Uname"></param>
        /// <param name="Upass"></param>
        /// <returns></returns>
        public int zhao(string Uname, string Upass,string Uiphone)
        {
            string sql = $"update Userinfo set Upass='{Upass}' where Uname='{Uname}'and Uiphone='{Uiphone}'";
            return dbcoon.Execute(sql);


        }
        /// <summary>
        /// /添加科室
        /// </summary>
        /// <param name="Kname"></param>
        /// <returns></returns>
        public int Addkeshi(string Kname)
        {
            string sql = $"insert into Keshi values('{Kname}')";
            return dbcoon.Execute(sql);
        
        }
        /// <summary>
        /// 删除科室
        /// </summary>
        /// <param name="Kid"></param>
        /// <returns></returns>
        public int Delkeshi(int Kid)
        {
            string sql = $"delete from Keshi where Kid='{Kid}'";
            return dbcoon.Execute(sql);
        
        }
        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="Rid"></param>
        /// <returns></returns>
        public int DelRole(int Rid)
        {

            string sql = $"delete from Roleinfo where Rid='{Rid}'";
            return dbcoon.Execute(sql);
        }
        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="Rid"></param>
        /// <returns></returns>
        public int Addrole(Roleinfo r)
        {

            string sql = $"insert into Roleinfo values('{r.Rname}')";
            return dbcoon.Execute(sql);
        }
        /// <summary>
        /// 获取接诊类型
        /// </summary>
        /// <returns></returns>
        public List<JZtype> GetJZtypes()
        {
            string sql = $"select * from JZtype ";
            return dbcoon.Query<JZtype>(sql).ToList();
        }
        /// <summary>
        /// 添加挂号信息
        /// </summary>
        /// <returns></returns>
        public int AddGua(X_Guahao g)
        {
            string sql = $"insert into  X_Guahao values('{g.Gno}','{g.ksids}','{g.Jids}','{g.Yname}','{g.Gmoney}','{g.Zlmoney}','{g.Gtime}','{g.Gpelete}','{g.Hname}','{g.Hkahao}','{g.Hage}','{g.Hcreatetime}','{g.Hsex}','{g.Hiphone}','{g.Hsfz}','{g.Hcids}','{g.Haddress}','{g.Hremaek}')";
            return dbcoon.Execute(sql);
        
        }
        /// <summary>
        /// 显示挂号单
        /// </summary>
        /// <returns></returns>
        public List<X_Guahao> GetX_Guahaos()
        {
            string sql = $"select * from X_Guahao x join Keshi k on k.Kid=x.ksids  join JZtype ty on ty.Jid=x.Jids join County c on c.Cid=x.Hcids join Market m on m.Mid=c.mids";
            return dbcoon.Query<X_Guahao>(sql).ToList();
        
        }
    }
}
