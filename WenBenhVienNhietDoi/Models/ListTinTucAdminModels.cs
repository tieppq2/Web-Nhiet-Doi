using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WenBenhVienNhietDoi.Models
{
    public class ListTinTucAdminModels
    {
        int _type = 0;
        int _status  = 0;
        int _loaitintuc  = 0;
        DateTime _tungay;
        DateTime _denngay;

        public int Type { get => _type; set => _type = value; }
        public int Status { get => _status; set => _status = value; }
        public int Loaitintuc { get => _loaitintuc; set => _loaitintuc = value; }
        public DateTime Tungay { get => _tungay; set => _tungay = value; }
        public DateTime Denngay { get => _denngay; set => _denngay = value; }
    }
}