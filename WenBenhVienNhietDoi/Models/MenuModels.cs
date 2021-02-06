using System;
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
        int _CapMenu = 0;
        string _linkurl = string.Empty;

        public int Id { get => _id; set => _id = value; }
        public int IdCha { get => _idCha; set => _idCha = value; }
        public string TenMenu { get => _TenMenu; set => _TenMenu = value; }
        public int CapMenu { get => _CapMenu; set => _CapMenu = value; }
        public string Linkurl { get => _linkurl; set => _linkurl = value; }
    }
    public class ListMenuModels
    {
        public List<MenuModels> ListParentMenu { get; set; }
        public List<MenuModels> ListMenu { get; set; }
    }
}