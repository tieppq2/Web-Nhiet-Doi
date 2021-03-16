using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WenBenhVienNhietDoi.Models
{
    public class TaiKhoanModels
    {
        int _ID = 0;
        string _UserName = string.Empty;
        string _Name = string.Empty;

        public int ID { get => _ID; set => _ID = value; }
        public string UserName { get => _UserName; set => _UserName = value; }
        public string Name { get => _Name; set => _Name = value; }
    }
}