using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;

namespace WenBenhVienNhietDoi.Models
{
    public class TinTucModels
    {
        int _idTinTuc = 0;
        string _TieuDe = string.Empty;
        string _TomTatNoiDung = string.Empty;
        string _NoiDung = string.Empty;
        string _avata = string.Empty;
        int _LoaiTinTuc = 0;
        int _TrangThai = 0;
        string _NgayTao= string.Empty;
        string _NgaySua = string.Empty;
        string _NgayDuyet = string.Empty;
        int _NguoiTao = 0;
        int _NguoiSua = 0;
        int _NguoiDuyet = 0;
        string _url_file = string.Empty;
        int _SoLuongXem = 0;
        int _type = 0;
        int _CapMenu = 0;
        string _CrawData = string.Empty;
        string _MenuParent = string.Empty;
        string _TenMenu = string.Empty;
        int _Sildes = 0;

        public int idTinTuc { get => _idTinTuc; set => _idTinTuc = value; }
        public string TieuDe { get => _TieuDe; set => _TieuDe = value; }
        public string TomTatNoiDung { get => _TomTatNoiDung; set => _TomTatNoiDung = value; }
        public string NoiDung { get => _NoiDung; set => _NoiDung = value; }
        public string Avata { get => _avata; set => _avata = value; }
        public int LoaiTinTuc { get => _LoaiTinTuc; set => _LoaiTinTuc = value; }
        public int TrangThai { get => _TrangThai; set => _TrangThai = value; }
        public string NgayTao { get => _NgayTao; set => _NgayTao = value; }
        public string NgaySua { get => _NgaySua; set => _NgaySua = value; }
        public string NgayDuyet { get => _NgayDuyet; set => _NgayDuyet = value; }
        public int NguoiTao { get => _NguoiTao; set => _NguoiTao = value; }
        public int NguoiSua { get => _NguoiSua; set => _NguoiSua = value; }
        public int NguoiDuyet { get => _NguoiDuyet; set => _NguoiDuyet = value; }
        public string Url_file { get => _url_file; set => _url_file = value; }
        public int SoLuongXem { get => _SoLuongXem; set => _SoLuongXem = value; }
        public string CrawData { get => _CrawData; set => _CrawData = value; }
        public int Type { get => _type; set => _type = value; }
        public string MenuParent { get => _MenuParent; set => _MenuParent = value; }
        public string TenMenu { get => _TenMenu; set => _TenMenu = value; }
        public int CapMenu { get => _CapMenu; set => _CapMenu = value; }
        public int Sildes { get => _Sildes; set => _Sildes = value; }
    }
}