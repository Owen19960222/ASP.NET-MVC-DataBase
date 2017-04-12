using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace esales.Controllers
{

    public class OrderController : Controller
    {

        Models.CodeService CodeService = new Models.CodeService();
 
        /// <summary>
        /// 取得訂單查詢結果
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        
        public ActionResult Index(Models.OrderArg arg)
        {
           ViewBag.EmpCodeData = this.CodeService.GetEmp();
            ViewBag.Company = this.CodeService.GetCompany();
            Models.OrderService orderService = new Models.OrderService();
            ViewBag.SearchResult = orderService.GetOrder(arg);
            return View("Index");
        }

    

        /// <summary>
        /// 取得系統時間
        /// </summary>
        /// <returns></returns>
        public ActionResult GetSysDate()
        {
            return PartialView("_SysDatePartial");
        }
    }
}