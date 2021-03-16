using CommonHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using WenBenhVienNhietDoi.Models;

namespace WenBenhVienNhietDoi.Controllers
{
    public class AdministratorController : Controller
    {
        PublicHelp _publicHelp = new PublicHelp();
        // GET: Administrator
        public ActionResult Index()
        {
            //if (Session["ID"] != null)
                return View();
            //else
            //    return View("~/Views/Login/Login.cshtml");
        }
        public ActionResult DangBai(int? ID)
        {
            //if (Session["Data"] == null)
            //{
            //    return Json("Login failed");
            //}
            //else
            //{
                return View();
            //}
            //else
            //    return View("~/Views/Login/Login.cshtml");
        }
        [HttpPost]
        public JsonResult GetDetailsTinTuc(int ID)
        {
            if (Session["ID"] == null)
            {
                return Json("Login failed");
            }
            else
            {
                var TinTuc_Details = _publicHelp.ConvertToList<TinTucModels>(_publicHelp.DanhSach_TinTuc("AdminTinTuc", int.Parse(ID.ToString()), 0, 1).Tables[0]);
                return Json(TinTuc_Details);
            }
            
        }
        [HttpPost]
        public JsonResult PostMethod()
        {
            //var data = Session["Data"];
            //if (data == null)
            //{                
            //    return Json("Login failed");
            //}
            //else
            //{
                var dt = DBProcess.GetDataSet("web_ListMenu").Tables[0];
                return Json(_publicHelp.Getdata(dt));
        //}
            
    }                
        [HttpPost]
        public async Task<JsonResult> UploadHomeReport()
        {
            if (Session["ID"] == null)
            {
                return Json("Login failed");
            }
            else
            {
                try
                {
                    foreach (string file in Request.Files)
                    {
                        var fileContent = Request.Files[file];
                        if (fileContent != null && fileContent.ContentLength > 0)
                        {
                            // get a stream
                            var stream = fileContent.InputStream;
                            // and optionally write the file to disk
                            var fileName = Path.GetFileName(fileContent.FileName);
                            var path = Path.Combine(Server.MapPath("~/Images"), fileName);
                            fileContent.SaveAs(path);
                        }
                    }
                }
                catch (Exception)
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return Json("Upload failed");
                }

                return Json("File uploaded successfully");
        }
    }
        [HttpPost, ValidateInput(false)]
        public async Task<JsonResult> CreateTinTuc(TinTucModels TinTuc)
        {
            if (Session["ID"] == null)
            {
                return Json("Login failed");
            }
            else
            {
                try
                {
                    var ID = _publicHelp.AdminExcTinTuc(TinTuc);
                    if (Request.Files.Count > 0)
                    //if (_publicHelp.AdminExcTinTuc(TinTuc) != TinTuc.idTinTuc)
                    {
                        foreach (string file in Request.Files)
                        {
                            var fileContent = Request.Files[file];
                            if (fileContent != null && fileContent.ContentLength > 0)
                            {
                                // get a stream
                                var stream = fileContent.InputStream;
                                // and optionally write the file to disk
                                var fileName = Path.GetFileName(fileContent.FileName);
                                var path = Path.Combine(Server.MapPath("~/Images"), fileName);
                                fileContent.SaveAs(path);
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    return Json("File uploaded fail: " + e.Message.ToString());
                }

                return Json("File uploaded successfully");
        }
    }
        [HttpPost]
        public JsonResult DanhSachTinTuc(int type, int status, int loaitintuc, string tungay, string denngay)
        {
            if (Session["Data"] == null)
            {
                return Json("Login failed");
            }
            else
            {
                DataSet DanhSach_TinTuc = _publicHelp.DanhSach_TinTuc_Admin("DanhSachTinTuc", type, status, loaitintuc, tungay, denngay);

                //ViewBag.DanhSach_TinTuc_Top5_main = _publicHelp.ConvertToList<TinTucModels>(DanhSach_TinTuc.Tables[0]);
                var data = _publicHelp.ConvertToList<TinTucModels>(DanhSach_TinTuc.Tables[0]);
                return Json(data);
            }
        }
        [HttpPost]
        public JsonResult AdminUpdateStatusMes(int ID, int TrangThai, int type, int slides)
        {
            if (Session["ID"] == null)
            {
                return Json("Login failed");
            }
            else
            {
                int data = _publicHelp.AdminUpdateStatusMes(ID, TrangThai, type, slides);
                return Json(data);
            }
        }
    }
}