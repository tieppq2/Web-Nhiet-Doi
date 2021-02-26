using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WenBenhVienNhietDoi.Models
{
    public class MenuLinkModels
    {
        int _IDParnet = 0;
        int _IDMenu = 0;
        string _MenuParent = string.Empty;
        string _TenMenu = string.Empty;

        public int IDParnet { get => _IDParnet; set => _IDParnet = value; }
        public int IDMenu { get => _IDMenu; set => _IDMenu = value; }
        public string MenuParent { get => _MenuParent; set => _MenuParent = value; }
        public string TenMenu { get => _TenMenu; set => _TenMenu = value; }
    }
}