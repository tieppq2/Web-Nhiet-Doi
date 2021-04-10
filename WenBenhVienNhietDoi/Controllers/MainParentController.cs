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
        public ActionResult Details(int page, int ID, int ID_Parent)
        {
            //DataSet dt;
            int recodperpage = 10, Pagesize = 10;
            DataSet dt = _publicHelp.DanhSach_TinTuc_Page(page, recodperpage, Pagesize, ID, ID_Parent);
            var ds_TiTuc = dt.Tables[0];
            var ds_Page = dt.Tables[1];
            var html = "";
            for (int i = 0; i < ds_TiTuc.Rows.Count; i++)
            {
                html = html + "<div class=\"news-hot-home-3\">" +
                                " <div style=\"float: left; z-index: 2;\">" +
                                    " <a href=\"/TinTuc/Details/" + ds_TiTuc.Rows[i]["idTinTuc"] + "\" target=\"_blank\">" +
                                        " <img src=\"" + ds_TiTuc.Rows[i]["Avata"] + "\" alt=\"" + ds_TiTuc.Rows[i]["TieuDe"] + "\" style=\"width:250px; height:170px;\">" +
                                    " </a>" +
                                " </div>" +
                                " <div style=\"padding-left:273px;\">" +
                                    " <div class=\"titleTranblock\">" +
                                        " <a href=\"/TinTuc/Details/" + ds_TiTuc.Rows[i]["idTinTuc"] + "\" target=\"_blank\" style=\"font-size: 20px;\">" + ds_TiTuc.Rows[i]["TieuDe"] + "</a>" +
                                    " </div>" +
                                    " <div class=\"line-time\">" + ds_TiTuc.Rows[i]["TomTatNoiDung"] + "</div>" +
                                    " <div class=\"title-time\" style=\"    text-align: right;\">" +
                                        " <i class=\"fa fa-calendar\" style=\"color:red; padding:0; font-size: 14px;\"></i>" +
                                          ds_TiTuc.Rows[i]["NgayDuyet"] + "&nbsp;&nbsp;&nbsp;&nbsp;"+
                                        " <i class=\"fa fa-eye\" style=\"color:red; padding:0; font-size: 14px;\"></i>" +
                                        " <span id=\"idView\">" + ds_TiTuc.Rows[i]["SoLuongXem"] + "</span>" +
                                    " </div>" +
                                " </div>" +
                            " </div>";
            }
            ViewBag.html = html;
            //ViewBag.Name_MenuParent = _publicHelp.ConvertToList<MenuModels>(dt.Tables[0]);
            ViewBag.html_page = dt.Tables[1].Rows[0]["Paging"];
            //if (CapMenu==2)
            //{
            //    DataSet dt = _publicHelp.DanhSach_TinTuc(page, recodperpage, Pagesize, ID, ID_Parent);
            //    ViewBag.Name_MenuParent = _publicHelp.ConvertToList<MenuModels>(dt.Tables[0]);
            //    ViewBag.TinTuc_Main_Details = _publicHelp.ConvertToList<TinTucModels>(dt.Tables[1]);
            //    //ViewBag.TinTuc_Top5_NewOther = _publicHelp.ConvertToList<TinTucModels>(TinTuc_Details.Tables[2]);
            //    //ViewBag.Name_MenuParent = _publicHelp.ConvertToList<MenuModels>(TinTuc_Details.Tables[0]);
            //    //ViewBag.TinTuc_Main_Details = _publicHelp.ConvertToList<TinTucModels>(TinTuc_Details.Tables[4]);
            //}
            //else //CapMenu !=2
            //{
            //    dt = _publicHelp.DanhSach_TinTuc("MainParent_tinTuc", 0, ID, 5);
            //    ViewBag.Name_MenuParent = _publicHelp.ConvertToList<MenuModels>(dt.Tables[0]);
            //    ViewBag.TinTuc_Main_Details = _publicHelp.ConvertToList<TinTucModels>(dt.Tables[2]);
            //}
            return View("~/Views/MainParent/Details.cshtml");
        }

    }
}