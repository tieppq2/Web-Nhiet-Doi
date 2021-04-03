using CommonHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WenBenhVienNhietDoi.Models;

namespace WenBenhVienNhietDoi.Controllers
{
    public class PublicHelp
    {

        public List<T> ConvertToList<T>(DataTable dt)
        {
            var columnNames = dt.Columns.Cast<DataColumn>()
                    .Select(c => c.ColumnName)
                    .ToList();
            var properties = typeof(T).GetProperties();
            return dt.AsEnumerable().Select(row =>
            {
                var objT = Activator.CreateInstance<T>();
                foreach (var pro in properties)
                {
                    if (columnNames.Contains(pro.Name))
                    {
                        PropertyInfo pI = objT.GetType().GetProperty(pro.Name);
                        pro.SetValue(objT, row[pro.Name] == DBNull.Value ? null : Convert.ChangeType(row[pro.Name], pI.PropertyType));
                    }
                }
                return objT;
            }).ToList();
        }
        public DataSet DanhSach_TinTuc(string store, int ID, int ID_Parent, int Top)
        {
            SqlParameter[] paras = {
                new SqlParameter("@ID", SqlDbType.Int),
                new SqlParameter("@ID_Parent", SqlDbType.Int),
                new SqlParameter("@count", SqlDbType.Int),
            };
            paras[0].Value = Convert.ToInt32(ID);
            paras[1].Value = Convert.ToInt32(ID_Parent);
            paras[2].Value = Convert.ToInt32(Top);
            return DBProcess.GetDataSet(store, paras);
        }
        public DataSet DanhSach_TinTuc_MainParent(string store, int ID_Parent, int level, int Top)
        {
            SqlParameter[] paras = {
                new SqlParameter("@ID_Parent", SqlDbType.Int),
                new SqlParameter("@level", SqlDbType.Int),
                new SqlParameter("@count", SqlDbType.Int),
            };
            paras[1].Value = Convert.ToInt32(level);
            paras[0].Value = Convert.ToInt32(ID_Parent);
            paras[2].Value = Convert.ToInt32(Top);
            return DBProcess.GetDataSet(store, paras);
        }
        public DataSet DanhSach_TinTuc_Admin(string store, int type, int status, int loaitintuc, string tungay, string denngay)
        {
            SqlParameter[] paras = {
                new SqlParameter("@type", SqlDbType.Int),
                new SqlParameter("@status", SqlDbType.Int),
                new SqlParameter("@loaitintuc", SqlDbType.Int),
                new SqlParameter("@tungay", SqlDbType.Date),
                new SqlParameter("@denngay", SqlDbType.Date),
            };
            paras[0].Value = Convert.ToInt32(type);
            paras[1].Value = Convert.ToInt32(status);
            paras[2].Value = Convert.ToInt32(loaitintuc);
            paras[3].Value = Convert.ToDateTime(tungay);
            paras[4].Value = Convert.ToDateTime(denngay);
            return DBProcess.GetDataSet(store, paras);
        }
        public string ConvertDataTabletoString(DataTable dt)
        {
            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            Dictionary<string, object> row;

            foreach (DataRow dr in dt.Rows)
            {

                row = new Dictionary<string, object>();
                //row.Add( "ID", dr["idCha"]);
                //row.Add("text", dr["TenMenuCha"]);
                //row.Add("url", dr["linkurl"]);                    
                //row.Add("inc", string__inc);

                //row.Add(col.ColumnName == "idCha" ? "ID" : col.ColumnName == "TenMenuCha" ? "text" : "", dr[col]);
                foreach (DataColumn col in dt.Columns)
                {
                    row.Add(col.ColumnName, dr[col]);
                }
                rows.Add(row);
            }
            return serializer.Serialize(rows);
        }
        public List<MenuJson> Getdata(DataTable dt)
        {
            List<MenuJson> data = new List<MenuJson>();
            data.Add(new MenuJson
            {
                id = 0,
                text = "-----Tất cả-----",
                url = "",
                inc = new List<Child>()
            });
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["capmenu"].ToString() == "0")

                    data.Add(new MenuJson
                    {
                        id = int.Parse(dt.Rows[i]["idCha"].ToString()),
                        text = dt.Rows[i]["TenMenuCha"].ToString(),
                        url = dt.Rows[i]["linkurl"].ToString(),
                        inc = new List<Child>()
                    });
            }

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["capmenu"].ToString() == "1")
                {
                    var parent = data.FirstOrDefault(d => d.id == int.Parse(dt.Rows[i]["idCha"].ToString()));

                    if (parent != null)
                        parent.inc.Add(new Child
                        {
                            id = int.Parse(dt.Rows[i]["id"].ToString()),
                            text = dt.Rows[i]["TenMenu"].ToString(),
                            url = dt.Rows[i]["linkurl"].ToString()
                        });
                }
            }
            return data;
        }
        public int AdminExcTinTuc(TinTucModels tinTucModels)
        {
            SqlParameter[] paras = {
                new SqlParameter("@idTinTuc", SqlDbType.Int),
                new SqlParameter("@TieuDe", SqlDbType.NVarChar),
                new SqlParameter("@TomTatNoiDung", SqlDbType.NVarChar),
                new SqlParameter("@NoiDung", SqlDbType.NText),
                //new SqlParameter("@avata", SqlDbType.Int),
                new SqlParameter("@LoaiTinTuc", SqlDbType.Int),
                new SqlParameter("@TrangThai", SqlDbType.Int),
                new SqlParameter("@NgayTao", SqlDbType.DateTime),
                new SqlParameter("@NgaySua", SqlDbType.DateTime),
                new SqlParameter("@NgayDuyet", SqlDbType.DateTime),
                new SqlParameter("@NguoiTao", SqlDbType.Int),
                new SqlParameter("@NguoiSua", SqlDbType.Int),
                new SqlParameter("@NguoiDuyet", SqlDbType.Int),
                new SqlParameter("@url_file", SqlDbType.NVarChar),
                new SqlParameter("@CrawData", SqlDbType.NVarChar),
                new SqlParameter("@Type", SqlDbType.Int),
                new SqlParameter("@avata", SqlDbType.NVarChar),
            };
            paras[0].Value = Convert.ToInt32(tinTucModels.idTinTuc);
            paras[1].Value = Convert.ToString(tinTucModels.TieuDe);
            paras[2].Value = Convert.ToString(tinTucModels.TomTatNoiDung);
            paras[3].Value = Convert.ToString(tinTucModels.NoiDung);
            paras[4].Value = Convert.ToInt32(tinTucModels.LoaiTinTuc);
            paras[5].Value = Convert.ToInt32(tinTucModels.TrangThai);
            paras[6].Value = Convert.ToString(tinTucModels.NgayTao);
            paras[7].Value = Convert.ToString(tinTucModels.NgaySua);
            paras[8].Value = Convert.ToString(tinTucModels.NgayDuyet);
            paras[9].Value = Convert.ToString(tinTucModels.NguoiTao);
            paras[10].Value = Convert.ToInt32(tinTucModels.NguoiSua);
            paras[11].Value = Convert.ToInt32(tinTucModels.NguoiDuyet);
            paras[12].Value = Convert.ToString(tinTucModels.Url_file);
            paras[13].Value = Convert.ToString(tinTucModels.CrawData);
            paras[14].Value = Convert.ToInt32(tinTucModels.Type);
            paras[15].Value = Convert.ToString(tinTucModels.Avata);

            int statusEx = int.Parse(DBProcess.GetDataTable("ExcTinTuc", paras).Rows[0][0].ToString());

            return statusEx;
        }
        public int AdminUpdateStatusMes(int idTinTuc, int TrangThai, int type,int slides)
        {
            SqlParameter[] paras = {
                new SqlParameter("@idTinTuc", SqlDbType.Int),
                //new SqlParameter("@TieuDe", SqlDbType.NVarChar),
                //new SqlParameter("@TomTatNoiDung", SqlDbType.NVarChar),
                //new SqlParameter("@NoiDung", SqlDbType.NText),
                ////new SqlParameter("@avata", SqlDbType.Int),
                //new SqlParameter("@LoaiTinTuc", SqlDbType.Int),
                new SqlParameter("@TrangThai", SqlDbType.Int),
                //new SqlParameter("@NgayTao", SqlDbType.NVarChar),
                //new SqlParameter("@NgaySua", SqlDbType.NVarChar),
                //new SqlParameter("@NgayDuyet", SqlDbType.NVarChar),
                //new SqlParameter("@NguoiTao", SqlDbType.Int),
                //new SqlParameter("@NguoiSua", SqlDbType.Int),
                //new SqlParameter("@NguoiDuyet", SqlDbType.Int),
                //new SqlParameter("@url_file", SqlDbType.NVarChar),
                //new SqlParameter("@CrawData", SqlDbType.NVarChar),
                new SqlParameter("@type", SqlDbType.Int),
                new SqlParameter("@slides", SqlDbType.Int),
            };
            paras[0].Value = Convert.ToInt32(idTinTuc);
            //paras[1].Value = Convert.ToString(tinTucModels.TieuDe);
            //paras[2].Value = Convert.ToString(tinTucModels.TomTatNoiDung);
            //paras[3].Value = Convert.ToString(tinTucModels.NoiDung);
            //paras[4].Value = Convert.ToInt32(tinTucModels.LoaiTinTuc);
            paras[1].Value = Convert.ToInt32(TrangThai);
            //paras[6].Value = Convert.ToString(tinTucModels.NgayTao);
            //paras[7].Value = Convert.ToString(tinTucModels.NgaySua);
            //paras[8].Value = Convert.ToString(tinTucModels.NgayDuyet);
            //paras[9].Value = Convert.ToString(tinTucModels.NguoiTao);
            //paras[10].Value = Convert.ToInt32(tinTucModels.NguoiSua);
            //paras[11].Value = Convert.ToInt32(tinTucModels.NguoiDuyet);
            //paras[12].Value = Convert.ToString(tinTucModels.Url_file);
            //paras[13].Value = Convert.ToString(tinTucModels.CrawData);
            paras[2].Value = Convert.ToInt32(type);
            paras[3].Value = Convert.ToInt32(slides);

            int statusEx = int.Parse(DBProcess.GetDataTable("UpdateStatusMes", paras).Rows[0]["idTinTuc"].ToString());

            return statusEx;
        }
        public DataTable DanhSachDichVU()
        {
            return DBProcess.GetDataTable("DanhSachDichVU");
        }
        public bool ThemBNDatLich(ThongTinDatLichModels datLichKham)
        {
            SqlParameter[] paras = {
                new SqlParameter("@HoTen", SqlDbType.NVarChar),
                new SqlParameter("@NgaySinh", SqlDbType.NVarChar),
                new SqlParameter("@GioiTinh", SqlDbType.Int),
                new SqlParameter("@DiaChi", SqlDbType.NVarChar),
                new SqlParameter("@SDT", SqlDbType.NVarChar),
                new SqlParameter("@Email", SqlDbType.NVarChar),
                new SqlParameter("@TheBHYT", SqlDbType.NVarChar),
                new SqlParameter("@NoiDungKham", SqlDbType.NText),
                new SqlParameter("@NgayKham", SqlDbType.NVarChar),
            };
            paras[0].Value = !string.IsNullOrEmpty(datLichKham.HoTen)?Convert.ToString(datLichKham.HoTen): (object)DBNull.Value;
            paras[1].Value = Convert.ToString(datLichKham.NgaySinh) ;
            paras[2].Value = Convert.ToInt32(datLichKham.GioiTinh?1:0);
            paras[3].Value = !string.IsNullOrEmpty(datLichKham.DiaChi) ?Convert.ToString(datLichKham.DiaChi) : (object)DBNull.Value;
            paras[4].Value = !string.IsNullOrEmpty(datLichKham.SDT) ?Convert.ToString(datLichKham.SDT) : (object)DBNull.Value;
            paras[5].Value = !string.IsNullOrEmpty(datLichKham.Email) ?Convert.ToString(datLichKham.Email) : (object)DBNull.Value;
            paras[6].Value = !string.IsNullOrEmpty(datLichKham.TheBHYT) ?Convert.ToString(datLichKham.TheBHYT) : (object)DBNull.Value;
            paras[7].Value = !string.IsNullOrEmpty(datLichKham.NoiDungKham) ?Convert.ToString(datLichKham.NoiDungKham) : (object)DBNull.Value;
            paras[8].Value = Convert.ToString(datLichKham.NgayKham);

            var statusEx = DBProcess.Exec("ThemBNDatLich", paras);

            return statusEx;
        }

        public DataTable DangNhap(string username, string pass)
        {
            pass = CreateMD5(pass);
            SqlParameter[] paras = {
                new SqlParameter("@UserName", SqlDbType.NVarChar),
                new SqlParameter("@Pass", SqlDbType.NVarChar),
            };
            paras[0].Value = Convert.ToString(username);
            paras[1].Value = Convert.ToString(pass);

            return DBProcess.GetDataTable("DangNhap", paras);
        }
        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            input = "TiepPQ@" + input;
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}