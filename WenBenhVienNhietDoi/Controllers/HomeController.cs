using CommonHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using WenBenhVienNhietDoi.Models;

namespace WenBenhVienNhietDoi.Controllers
{
    public class HomeController : Controller
    {
        PublicHelp _publicHelp = new PublicHelp();
        [HttpGet]
        public ViewResult Index()
        {
            DataSet DanhSach_TinTuc_TOP_main = DBProcess.GetDataSet("DanhSach_TinTuc_TOP5_main");
            DataSet DanhSach_TinTuc_HDBV = _publicHelp.DanhSach_TinTuc("DanhSach_TinTuc_main", 0, 9, 4);
            DataSet DanhSach_TinTuc_TRNH = _publicHelp.DanhSach_TinTuc("DanhSach_TinTuc_main", 0, 19, 4);
            DataSet DanhSach_TinTuc_KHDT = _publicHelp.DanhSach_TinTuc("DanhSach_TinTuc_main", 0, 14, 3);

            ViewBag.DanhSach_TinTuc_Top5_main = _publicHelp.ConvertToList<TinTucModels>(DanhSach_TinTuc_TOP_main.Tables[0]);
            ViewBag.DanhSach_TinTuc_Top_main = _publicHelp.ConvertToList<TinTucModels>(DanhSach_TinTuc_TOP_main.Tables[1]);
            ViewBag.DanhSach_Slides = _publicHelp.ConvertToList<TinTucModels>(DanhSach_TinTuc_TOP_main.Tables[2]);
            ViewBag.DanhSach_TinTuc_HDBV = _publicHelp.ConvertToList<TinTucModels>(DanhSach_TinTuc_HDBV.Tables[0]);
            ViewBag.DanhSach_TinTuc_KHDT = _publicHelp.ConvertToList<TinTucModels>(DanhSach_TinTuc_KHDT.Tables[0]);
            ViewBag.DanhSach_TinTuc_TRNH = _publicHelp.ConvertToList<TinTucModels>(DanhSach_TinTuc_TRNH.Tables[0]);
            return View();
        }
        public ActionResult MenuAction()
        {
            List<MenuModels> menuModels;
            List<MenuModels> menuModels_parent;
            ListMenuModels Menu = new ListMenuModels();
            var dt_tmp = DBProcess.GetDataSet("web_ListMenu");
            var dt = dt_tmp.Tables[0];
            var dt_parent = dt.Select("capmenu = 1");
            //menuModels_parent= _publicHelp.ConvertToList<MenuModels>(dt);
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
            return PartialView("_MenuAction", Menu);
            //return PartialView("_LayoutMasterPage", Menu);
        }
        public ActionResult MenuAction2()
        {
            List<MenuModels> menuModels;
            List<MenuModels> menuModels_parent;
            ListMenuModels Menu = new ListMenuModels();
            var dt_tmp = DBProcess.GetDataSet("web_ListMenu");
            var dt = dt_tmp.Tables[0];
            var dt_parent = dt.Select("capmenu = 1");
            //menuModels_parent= _publicHelp.ConvertToList<MenuModels>(dt);
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
            return PartialView("_MenuAction2", Menu);
            //return PartialView("_LayoutMasterPage", Menu);
        }
        public ActionResult Menu()
        {
            List<MenuModels> menuModels;
            List<MenuModels> menuModels_parent;
            ListMenuModels Menu = new ListMenuModels();
            var dt_tmp = DBProcess.GetDataSet("web_ListMenu");
            var dt = dt_tmp.Tables[0];
            var dt_parent = dt.Select("capmenu = 1");
            //menuModels_parent= _publicHelp.ConvertToList<MenuModels>(dt);
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
           // return PartialView("_MenuAction", Menu);
            return PartialView("_LayoutMasterPage", Menu);
        }
    }

}