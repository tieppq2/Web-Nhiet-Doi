using CommonHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WenBenhVienNhietDoi.Models;

namespace WenBenhVienNhietDoi.Controllers
{
    public class MainParentController : Controller
    {
        PublicHelp _publicHelp = new PublicHelp();
        // GET: MainParent
        public ActionResult Index()
        {
            //DataSet DanhSach_TinTuc_TOP_main = DBProcess.GetDataSet("DanhSach_TinTuc_TOP5_main");

            //ViewBag.DanhSach_TinTuc_Top_main = _publicHelp.ConvertToList<TinTucModels>(DanhSach_TinTuc_TOP_main.Tables[0]);
            return View();
        }
        public ActionResult Details(int ID,int CapMenu)
        {
            DataSet dt;
            if (CapMenu==2)
            {
                 dt = _publicHelp.DanhSach_TinTuc("MainParent_tinTuc", ID, 0, 5);
                ViewBag.Name_MenuParent = _publicHelp.ConvertToList<MenuModels>(dt.Tables[0]);
                ViewBag.TinTuc_Main_Details = _publicHelp.ConvertToList<TinTucModels>(dt.Tables[1]);
                //ViewBag.TinTuc_Top5_NewOther = _publicHelp.ConvertToList<TinTucModels>(TinTuc_Details.Tables[2]);
                //ViewBag.Name_MenuParent = _publicHelp.ConvertToList<MenuModels>(TinTuc_Details.Tables[0]);
                //ViewBag.TinTuc_Main_Details = _publicHelp.ConvertToList<TinTucModels>(TinTuc_Details.Tables[4]);
            }
            else //CapMenu !=2
            {
                dt = _publicHelp.DanhSach_TinTuc("MainParent_tinTuc", 0, ID, 5);
                ViewBag.Name_MenuParent = _publicHelp.ConvertToList<MenuModels>(dt.Tables[0]);
                ViewBag.TinTuc_Main_Details = _publicHelp.ConvertToList<TinTucModels>(dt.Tables[2]);
            }
            return View("~/Views/MainParent/Details.cshtml");
        }

    }
}