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
    public class HomeController : Controller
    {
        [HttpGet]
        public ViewResult Index()
        {
            List<MenuModels> menuModels;
            List<MenuModels> menuModels_parent;
            ListMenuModels Menu = new ListMenuModels();
            var dt_tmp = DBProcess.GetDataSet("web_ListMenu");
            var dt = dt_tmp.Tables[0];
            var dt_parent = dt.Select("capmenu = 1");
            menuModels_parent = (from rw in dt.AsEnumerable()
                          select new MenuModels()
                          {
                              IdCha = Convert.ToInt32(rw["idCha"]),
                              Id = Convert.ToInt32(rw["id"]),
                              TenMenu = Convert.ToString(rw["TenMenu"]),
                              CapMenu = Convert.ToInt32(rw["capmenu"]),
                              Linkurl = Convert.ToString(rw["linkurl"])
                          }).ToList();
            Menu.ListParentMenu = menuModels_parent;
            menuModels = (from rw in dt_parent.AsEnumerable()
                          select new MenuModels()
                          {
                              IdCha = Convert.ToInt32(rw["idCha"]),
                              Id = Convert.ToInt32(rw["id"]),
                              TenMenu = Convert.ToString(rw["TenMenu"]),
                              CapMenu = Convert.ToInt32(rw["capmenu"]),
                              Linkurl = Convert.ToString(rw["linkurl"])
                          }).ToList();
            Menu.ListMenu = menuModels;
            // ViewBag.MenuModels = menuModels;
            return View(Menu);
        }
    }
}