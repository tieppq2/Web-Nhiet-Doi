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
            if(CapMenu==1)
            {
                DataSet TinTuc_Details = _publicHelp.DanhSach_TinTuc("TinTuc_Details", 0, ID, 5);
                ViewBag.TinTuc_Details = _publicHelp.ConvertToList<TinTucModels>(TinTuc_Details.Tables[0]);
                ViewBag.TinTuc_Top5_New = _publicHelp.ConvertToList<TinTucModels>(TinTuc_Details.Tables[1]);
                ViewBag.TinTuc_Top5_NewOther = _publicHelp.ConvertToList<TinTucModels>(TinTuc_Details.Tables[2]);
                ViewBag.Name_MenuParent = _publicHelp.ConvertToList<MenuModels>(TinTuc_Details.Tables[3]);
                ViewBag.TinTuc_Main_Details = _publicHelp.ConvertToList<TinTucModels>(TinTuc_Details.Tables[4]);
                //ViewBag.Name_MenuParent = TinTuc_Details.Tables[3].Rows[0][1];
                //if (TinTuc_Details.Tables[3].Rows[0]["idCha"] == TinTuc_Details.Tables[3].Rows[0]["id"])
                //    ViewBag.Name_Menu = "";
                //else
                //    ViewBag.Name_Menu = TinTuc_Details.Tables[3].Rows[0][3];
                return View("~/Views/MainParent/Details.cshtml");
            }
            else
            {
                return View("~/Views/MainParent/DetailsMainParent.cshtml");
            }
            
        }
    }
}