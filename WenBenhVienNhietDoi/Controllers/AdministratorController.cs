using CommonHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WenBenhVienNhietDoi.Controllers
{
    public class AdministratorController : Controller
    {
        PublicHelp _publicHelp = new PublicHelp();
        // GET: Administrator
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DangBai()
        {
            
           // ViewBag.Menu = _publicHelp.ConvertDataTabletoString(dt);
            return View();
        }
        [HttpPost]
        public JsonResult PostMethod()
        {
            var dt = DBProcess.GetDataSet("web_ListMenu").Tables[0];
            //var dt = dt_tmp.Tables[0];
            //var dt_parent = dt.Select("capmenu = 1");
            return Json(_publicHelp.Getdata(dt));
        }
        [HttpPost]
        public ActionResult UploadFiles(HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                try
                {


                    if (file != null)
                    {
                        string path = Path.Combine(Server.MapPath("~/Images"), Path.GetFileName(file.FileName));
                        file.SaveAs(path);

                    }
                    ViewBag.FileStatus = "File uploaded successfully.";
                }
                catch (Exception)
                {

                    ViewBag.FileStatus = "Error while file uploading.";
                }

            }
            return View("DangBai");
        }
    }
}