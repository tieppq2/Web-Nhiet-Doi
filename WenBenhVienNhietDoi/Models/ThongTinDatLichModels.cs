using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WenBenhVienNhietDoi.Models
{
    public class ThongTinDatLichModels
    {
        int _ID = 0;

        string _HoTen = "";

        DateTime _NgaySinh;
        DateTime _NgayKham;

        bool _GioiTinh;

        string _DiaChi= "";

        string _SDT = "";

        string _Email = "";

        string _TheBHYT = "";

        string _NoiDungKham = "";

        public int ID { get => _ID; set => _ID = value; }
        public string HoTen { get => _HoTen; set => _HoTen = value; }
        public DateTime NgaySinh { get => _NgaySinh; set => _NgaySinh = value; }
        public bool GioiTinh { get => _GioiTinh; set => _GioiTinh = value; }
        public string DiaChi { get => _DiaChi; set => _DiaChi = value; }
        public string SDT { get => _SDT; set => _SDT = value; }
        public string Email { get => _Email; set => _Email = value; }
        public string TheBHYT { get => _TheBHYT; set => _TheBHYT = value; }
        public string NoiDungKham { get => _NoiDungKham; set => _NoiDungKham = value; }
        public DateTime NgayKham { get => _NgayKham; set => _NgayKham = value; }
    }
}