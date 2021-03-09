using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WenBenhVienNhietDoi.Models;

namespace WenBenhVienNhietDoi.Controllers
{
    public class BangGiaDVKTController : Controller
    {
        PublicHelp _publicHelp = new PublicHelp();
        // GET: BangGiaDVKT
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult GetDetailsTinTuc()
        {
            var DanhSachDichVU = _publicHelp.ConvertToList<BangGiaDVKTModels>(_publicHelp.DanhSachDichVU());
            return Json(DanhSachDichVU, JsonRequestBehavior.AllowGet);
        }
    }
}