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
        DateTime _NgayTao;
        DateTime _NgaySua;
        DateTime _NgayDuyet;
        string _NguoiTao = string.Empty;
        string _NguoiSua = string.Empty;
        string _NguoiDuyet = string.Empty;
        string _url_file = string.Empty;
        int _SoLuongXem = 0;
        int _type = 0;
        string _CrawData = string.Empty;

        public int idTinTuc { get => _idTinTuc; set => _idTinTuc = value; }
        public string TieuDe { get => _TieuDe; set => _TieuDe = value; }
        public string TomTatNoiDung { get => _TomTatNoiDung; set => _TomTatNoiDung = value; }
        public string NoiDung { get => _NoiDung; set => _NoiDung = value; }
        public string Avata { get => _avata; set => _avata = value; }
        public int LoaiTinTuc { get => _LoaiTinTuc; set => _LoaiTinTuc = value; }
        public int TrangThai { get => _TrangThai; set => _TrangThai = value; }
        public DateTime NgayTao { get => _NgayTao; set => _NgayTao = value; }
        public DateTime NgaySua { get => _NgaySua; set => _NgaySua = value; }
        public DateTime NgayDuyet { get => _NgayDuyet; set => _NgayDuyet = value; }
        public string NguoiTao { get => _NguoiTao; set => _NguoiTao = value; }
        public string NguoiSua { get => _NguoiSua; set => _NguoiSua = value; }
        public string NguoiDuyet { get => _NguoiDuyet; set => _NguoiDuyet = value; }
        public string Url_file { get => _url_file; set => _url_file = value; }
        public int SoLuongXem { get => _SoLuongXem; set => _SoLuongXem = value; }
        public string CrawData { get => _CrawData; set => _CrawData = value; }
        public int Type { get => _type; set => _type = value; }
        
    }
}