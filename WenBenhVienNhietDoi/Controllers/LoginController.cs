using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WenBenhVienNhietDoi.Models;

namespace WenBenhVienNhietDoi.Controllers
{
    public class LoginController : Controller
    {
        PublicHelp _publicHelp = new PublicHelp();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index2()
        {
            if (Session["Data"] != null)
                Session["Data"] = null;
            return View("~/Views/Login/Login.cshtml");
        }
        [HttpGet]
        public JsonResult DangNhap(string user, string pass)
        {
            var data_tmp = _publicHelp.DangNhap(user, pass);
            if (data_tmp.Rows.Count > 0)
            {
                var data = _publicHelp.ConvertToList<TaiKhoanModels>(data_tmp);
                Session["Data"] = data;
                //return View("~/Views/Administrator/Index.cshtml");
                return Json("Success", JsonRequestBehavior.AllowGet);
            }
            //ViewBag.DanhSach_TinTuc_Top5_main = _publicHelp.ConvertToList<TinTucModels>(DanhSach_TinTuc.Tables[0]);
            //var data = _publicHelp.ConvertToList<TinTucModels>(DanhSach_TinTuc.Tables[0]);
            return Json("Login failed", JsonRequestBehavior.AllowGet);
        }

    }
}