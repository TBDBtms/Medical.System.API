using Medical.Model;
using Medical.Model.HZX_Model;
using Medical.System.BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medical.System.API.Controllers
{

    [ApiController]
    public class Hzx_LoginController : ControllerBase
    {
        public IOptions<ConnectionStrings> _conn;
        Hzx_LoginBLL bll;
        public Hzx_LoginController(IOptions<ConnectionStrings> coon)
        {
            _conn = coon;
            bll = new  Hzx_LoginBLL(coon);
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="Uiphone">手机号</param>
        /// <param name="Upass">密码</param>
        /// <returns></returns>
        [RouteAttribute("api/[controller]/Login")]
        [HttpGet]
        public Userinfo Login(string Uiphone = "", string Upass = "")
        {

            var list = bll.Login(Uiphone, Upass).FirstOrDefault();
            return list;
        }

        /// <summary>
        /// 显示所有用户
        /// </summary>
        /// <returns></returns>
        [RouteAttribute("api/[controller]/GetUserinfos")]
        [HttpGet]
        public List<Userinfo> GetUserinfos()
        {
            var list = bll.GetUserinfos();
            return list;
        }


    }
}
