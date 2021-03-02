﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WenBenhVienNhietDoi.Models
{
    public class MenuModels
    {
        int _id = 0;
        int _idCha = 0;
        string _TenMenu = string.Empty;
        string _TenMenuCha = string.Empty;
        int _CapMenu = 0;
        string _linkurl = string.Empty;

        public int Id { get => _id; set => _id = value; }
        public int IdCha { get => _idCha; set => _idCha = value; }
        public string TenMenu { get => _TenMenu; set => _TenMenu = value; }
        public int CapMenu { get => _CapMenu; set => _CapMenu = value; }
        public string Linkurl { get => _linkurl; set => _linkurl = value; }
        public string TenMenuCha { get => _TenMenuCha; set => _TenMenuCha = value; }
    }
    public class ListMenuModels
    {
        public List<MenuModels> ListParentMenu { get; set; }
        public List<MenuModels> ListMenu { get; set; }
    }
    public class Child
    {
        public int id { get; set; }
        public string text { get; set; }

        public string url { get; set; }
    }
    public class MenuJson
    {
        public int id { get; set; }
        public string text { get; set; }
        public string url { get; set; }
        public List<Child> inc { get; set; }
    }
}