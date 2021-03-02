using CommonHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
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
        public string ConvertDataTabletoString(DataTable dt)
        {
            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            Dictionary<string, object> row;
            Dictionary<string, object> row_inc;
            var string__inc = "[";

            var dt_inc= dt.Select("capmenu = 1");

            foreach (DataRow dr in dt.Rows)
            {
                
                if (dr["capmenu"].ToString()=="0")
                {
                    row = new Dictionary<string, object>();
                    row.Add( "ID", dr["idCha"]);
                    row.Add("text", dr["TenMenuCha"]);
                    row.Add("url", dr["linkurl"]);
                    for (int i = 0; i < dt_inc.Length; i++)
                    {
                        if(dr["idCha"].ToString()== dt_inc[i]["idCha"].ToString() && dt_inc[i]["capmenu"].ToString() == "1")
                        {
                            //row_inc = new Dictionary<string, object>();
                            //row_inc.Add("ID", dt_inc[i]["id"]);
                            //row_inc.Add("text", dt_inc[i]["TenMenu"]);
                            //row_inc.Add("url", dt_inc[i]["linkurl"]);
                            //row_inc.Add("text", dt_inc[i]["TenMenu"]);
                            string__inc = string__inc + "{ID:" + dt_inc[i]["id"] + ",text:'" + dt_inc[i]["TenMenu"] + "',url:'" + dt_inc[i]["linkurl"] + "'},";
                            //if (i != dt_inc.Length - 1)
                            //    string__inc = string__inc + ";";                            
                        }
                        if (i == dt_inc.Length - 1)
                            string__inc = string__inc + "]";
                    }
                    row.Add("inc", string__inc);

                    //row.Add(col.ColumnName == "idCha" ? "ID" : col.ColumnName == "TenMenuCha" ? "text" : "", dr[col]);
                    //foreach (DataColumn col in dt.Columns)
                    //{
                    //    row.Add(col.ColumnName== "idCha"?"ID": col.ColumnName == "TenMenuCha"? "text":"", dr[col]);
                    //}
                    rows.Add(row);
                }                                
            }
            return serializer.Serialize(rows);
        }
        public List<MenuJson> Getdata(DataTable dt )
        {
            List<MenuJson> data = new List<MenuJson>();

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
    }
}