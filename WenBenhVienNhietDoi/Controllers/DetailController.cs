using CommonHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WenBenhVienNhietDoi.Models;

namespace WenBenhVienNhietDoi.Controllers
{
    public class DetailController : Controller
    {
        PublicHelp _publicHelp = new PublicHelp();
        // GET: Detail
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Details(int ID)
        {
            DataSet TinTuc_Details = _publicHelp.DanhSach_TinTuc("TinTuc_Details", ID,0,1);
            ViewBag.TinTuc_Details = _publicHelp.ConvertToList<TinTucModels>(TinTuc_Details.Tables[0]);
            

            return View();
        }
    }
}