using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WenBenhVienNhietDoi.Models
{
    public class BangGiaDVKTModels
    {
        int _STT = 0;
        string _MA_DV = string.Empty;
        string _TEN_DV = string.Empty;
        float _GIA_TT13 = 0;

        public int STT { get => _STT; set => _STT = value; }
        public string MA_DV { get => _MA_DV; set => _MA_DV = value; }
        public string TEN_DV { get => _TEN_DV; set => _TEN_DV = value; }
        public float GIA_TT13 { get => _GIA_TT13; set => _GIA_TT13 = value; }
    }
}