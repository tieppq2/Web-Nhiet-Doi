﻿using CommonHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;

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
        public DataSet DanhSach_TinTuc_main(string store, int IDCHA, int Top)
        {
            SqlParameter[] paras = {
                new SqlParameter("@ID_CHA", SqlDbType.Int),
                new SqlParameter("@count", SqlDbType.Int),
            };
            paras[0].Value = Convert.ToInt32(IDCHA);
            paras[1].Value = Convert.ToInt32(Top);
            return DBProcess.GetDataSet(store, paras);
        }
    }
}