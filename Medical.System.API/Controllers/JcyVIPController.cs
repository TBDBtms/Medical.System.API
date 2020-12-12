﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Medical.Model.Jcy_Model;
using Medical.System.BLL;
using Medical.Model;
using Microsoft.Extensions.Options;

namespace Medical.System.API.Controllers
{
    [ApiController]
    public class JcyVIPController : ControllerBase
    {
        Jcy_VIPInfoBLL bll;
        public IOptions<ConnectionStrings> _conn;
        public JcyVIPController(IOptions<ConnectionStrings> coon)
        {
            _conn = coon;
            bll = new Jcy_VIPInfoBLL(coon);

        }
        /// <summary>
        /// 显示会员信息
        /// </summary>
        /// <param name="stime"></param>
        /// <param name="etime"></param>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="phone"></param>
        /// <param name="card"></param>
        /// <returns></returns>
        [Route("api/[controller]/GetVIPInfos")]
        [HttpGet]
        public IActionResult GetVIPInfos(DateTime? stime, DateTime? etime, int id = 0, string name = "", string phone = "", string card = "")
        {
            return Ok(bll.GetVIPInfos(stime, etime, id, name, phone, card));
        }
        /// <summary>
        /// 余额充值返填信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("api/[controller]/GetById")]
        [HttpGet]
        public IActionResult GetById(int id)
        {
            return Ok(bll.GetById(id));
        }
        /// <summary>
        /// 余额充值
        /// </summary>
        /// <param name="vip"></param>
        /// <returns></returns>
        [Route("api/[controller]/UpdVIPInfo")]
        [HttpPost]
        public IActionResult UpdVIPInfo(VIPInfo vip)
        {
            return Ok(bll.UpdVIPgrade(vip));
        }
        /// <summary>
        /// 下拉会员等级
        /// </summary>
        /// <returns></returns>
        [Route("api/[controller]/GetVIPgrades")]
        [HttpGet]
        public IActionResult GetVIPgrades()
        {
            return Ok(bll.GetVIPgrades());
        }
        /// <summary>
        /// 显示设置会员等级数据
        /// </summary>
        /// <returns></returns>
        [Route("api/[controller]/GetVIPgrade")]
        [HttpGet]
        public IActionResult GetVIPgrade()
        {
            return Ok(bll.GetVIPgrade());
        }
        /// <summary>
        /// 修改会员等级
        /// </summary>
        /// <param name="vip"></param>
        /// <returns></returns>
        [Route("api/[controller]/UpdVIPgrade")]
        [HttpPost]
        public IActionResult UpdVIPgrade(VIPInfo vip)
        {
            return Ok(bll.UpdVIPgrade(vip));
        }
        /// <summary>
        /// 增加积分
        /// </summary>
        /// <param name="vip"></param>
        /// <returns></returns>
        [Route("api/[controller]/AddIntegral")]
        [HttpPost]
        public IActionResult AddIntegral(VIPInfo vip)
        {
            return Ok(bll.AddIntegral(vip));
        }
        /// <summary>
        /// 扣减积分
        /// </summary>
        /// <param name="vip"></param>
        /// <returns></returns>
        [Route("api/[controller]/JIanIntegral")]
        [HttpPost]
        public IActionResult JIanIntegral(VIPInfo vip)
        {
            return Ok(bll.JIanIntegral(vip));
        }
        /// <summary>
        /// 积分清零
        /// </summary>
        /// <param name="vip"></param>
        /// <returns></returns>
        [Route("api/[controller]/ClearIntegrals")]
        [HttpPost]
        public IActionResult ClearIntegral(VIPInfo vip)
        {
            return Ok(bll.ClearIntegral(vip));
        }
        /// <summary>
        /// 退款
        /// </summary>
        /// <param name="vip"></param>
        /// <returns></returns>
        [Route("api/[controller]/RePrice")]
        [HttpPost]
        public IActionResult RePrice(VIPInfo vip)
        {
            return Ok(bll.RePrice(vip));
        }
        /// <summary>
        ///会员等级变更记录
        /// </summary>
        /// <returns></returns>
        [Route("api/[controller]/SetGrade")]
        [HttpPost]
        public IActionResult SetGrade()
        {
            return Ok(bll.SetGrade());
        }
        /// <summary>
        /// 储值管理
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="phone"></param>
        /// <param name="card"></param>
        /// <returns></returns>
        [Route("api/[controller]/GetCZ")]
        [HttpGet]
        public IActionResult GetCZ(int id=0,string name="",string phone="",string card="")
        {
            return Ok(bll.GetSValuemages(id,name,phone,card));
        }
        /// <summary>
        /// 积分管理
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="phone"></param>
        /// <param name="card"></param>
        /// <returns></returns>
        [Route("api/[controller]/GetJF")]
        [HttpGet]
        public IActionResult GetJF(int id = 0, string name = "", string phone = "", string card = "")
        {
            return Ok(bll.GetPointmanages(id, name, phone, card));
        }
        /// <summary>
        /// 会员设置
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="phone"></param>
        /// <param name="card"></param>
        /// <returns></returns>
        [Route("api/[controller]/GetMemberSet")]
        [HttpGet]
        public IActionResult GetMemberSet()
        {
            return Ok(bll.GetMembers());
        }
    }
}