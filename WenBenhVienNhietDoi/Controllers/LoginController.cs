﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WenBenhVienNhietDoi.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DangNhap()
        {
            return View("~/Views/Login/Login.cshtml");
        }
    }
}