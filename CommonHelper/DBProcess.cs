using System;
using System.Web;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.IO;
using System.Net;

namespace CommonHelper
{

    #region DBProcess
    public class DBProcess
    {
        static string ConnStr = System.Configuration.ConfigurationSettings.AppSettings["connectionSt"];
        static string ConnStrCP = System.Configuration.ConfigurationSettings.AppSettings["connectionStCP"];
        //System.Configuration.ConfigurationSettings.AppSettings["connectionSt"];
        #region Connection
        public static void OpenConn(SqlConnection conn)
        {
            try
            {
                if (conn.State == ConnectionState.Open)
                {
                }
                else
                {
                    conn.Open();
                }
            }
            catch
            {
                //HttpContext.Current.Response.Redirect("error.aspx?id=1");
            }
        }

        public static void CloseConn(SqlConnection conn)
        {
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static void RollbackTransaction(SqlTransaction transaction)
        {
            if (transaction != null)
            {
                transaction.Rollback();
            }
        }

        #endregion

        #region Get Dataset
        public static DataSet GetDataSet(string store)
        {
            DataSet mDataSet = null;
            SqlConnection conn = new SqlConnection(ConnStr);

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = store;
            try
            {
                OpenConn(conn);
                using (SqlDataAdapter reader = new SqlDataAdapter(cmd))
                {
                    mDataSet = new DataSet();
                    reader.Fill(mDataSet);
                }
            }
            catch (Exception ex)
            {
                mDataSet = null;
            }
            finally
            {
                cmd.Dispose();
                CloseConn(conn);
            }

            return mDataSet;
        }

        public static DataTable GetDataTable(string store)
        {
            DataTable mDataSet = null;
            SqlConnection conn = new SqlConnection(ConnStr);

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = store;
            try
            {
                OpenConn(conn);
                using (SqlDataAdapter reader = new SqlDataAdapter(cmd))
                {
                    mDataSet = new DataTable();
                    reader.Fill(mDataSet);
                }
            }
            catch (Exception ex)
            {
                mDataSet = null;
            }
            finally
            {
                cmd.Dispose();
                CloseConn(conn);
            }

            return mDataSet;
        }

        public static DataSet GetDataSet(string store, SqlParameter[] para)
        {
            DataSet mDataSet = null;
            SqlConnection conn = new SqlConnection(ConnStr);

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = store;
            #region Add Values
            cmd.Parameters.AddRange(para);
            #endregion
            try
            {
                OpenConn(conn);
                using (SqlDataAdapter reader = new SqlDataAdapter(cmd))
                {

                    mDataSet = new DataSet();
                    reader.Fill(mDataSet);

                }
            }
            catch (Exception ex)
            {
                mDataSet = null;
            }
            finally
            {
                cmd.Dispose();
                CloseConn(conn);
            }

            return mDataSet;
        }

        public static DataTable GetDataTable(string store, SqlParameter[] para)
        {
            DataTable mDataSet = null;
            SqlConnection conn = new SqlConnection(ConnStr);

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = store;
            #region Add Values
            cmd.Parameters.AddRange(para);
            #endregion
            try
            {
                OpenConn(conn);
                using (SqlDataAdapter reader = new SqlDataAdapter(cmd))
                {
                    mDataSet = new DataTable();
                    reader.Fill(mDataSet);

                }
            }
            catch (Exception ex)
            {
                mDataSet = null;
            }
            finally
            {
                cmd.Dispose();
                CloseConn(conn);
            }

            return mDataSet;
        }

        public static string GetString(string store)
        {
            string re = "";
            DataTable mDataSet = null;
            SqlConnection conn = new SqlConnection(ConnStr);

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = store;
            try
            {
                OpenConn(conn);
                using (SqlDataAdapter reader = new SqlDataAdapter(cmd))
                {
                    mDataSet = new DataTable();
                    reader.Fill(mDataSet);
                    re = mDataSet.Rows[0][0].ToString();
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                cmd.Dispose();
                CloseConn(conn);
            }

            return re;
        }

        public static string GetString(string store, SqlParameter[] para)
        {
            DataTable mDataSet = null;
            SqlConnection conn = new SqlConnection(ConnStr);

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = store;
            #region Add Values
            cmd.Parameters.AddRange(para);
            #endregion
            try
            {
                OpenConn(conn);
                using (SqlDataAdapter reader = new SqlDataAdapter(cmd))
                {
                    mDataSet = new DataTable();
                    reader.Fill(mDataSet);

                }
            }
            catch (Exception ex)
            {
                mDataSet = null;
            }
            finally
            {
                cmd.Dispose();
                CloseConn(conn);
            }

            return mDataSet.Rows[0][0].ToString();
        }

        public static string GetStringOutput(string store, string strOutput, SqlParameter[] para)
        {
            string result = "";
            SqlConnection conn = new SqlConnection(ConnStr);
            SqlTransaction t = null;
            OpenConn(conn);
            t = conn.BeginTransaction();

            SqlCommand cmd = new SqlCommand(store, conn, t);
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = store;

            #region Add Values
            //cmd.Parameters.(para);
            SqlParameter outparam = cmd.Parameters.Add(strOutput, SqlDbType.NVarChar);
            outparam.Direction = ParameterDirection.Output;
            #endregion

            try
            {
                cmd.ExecuteNonQuery();
                result = cmd.Parameters[strOutput].Value.ToString();
                t.Commit();
            }
            catch (Exception ex)
            {
                DBProcess.RollbackTransaction(t);
                result = "";
            }
            finally
            {
                cmd.Dispose();
                CloseConn(conn);
            }
            return result;
        }
        #endregion

        #region Execute
        //result = false --> Thuc thi khong thanh cong (Loi)
        //result = true --> Thanh cong
        public static bool Exec(string store)
        {
            bool result = false;
            SqlConnection conn = new SqlConnection(ConnStr);
            SqlTransaction t = null;
            OpenConn(conn);
            t = conn.BeginTransaction();
            SqlCommand cmd = new SqlCommand(store, conn, t);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = store;
            try
            {
                cmd.ExecuteNonQuery();
                result = true;
                t.Commit();

            }
            catch (Exception ex)
            {
                DBProcess.RollbackTransaction(t);
                result = false;
            }
            finally
            {
                cmd.Dispose();
                CloseConn(conn);
            }
            return result;
        }

        public static bool Exec(string store, SqlParameter[] para)
        {
            bool result = false;
            SqlConnection conn = new SqlConnection(ConnStr);
            SqlTransaction t = null;
            OpenConn(conn);
            t = conn.BeginTransaction();

            SqlCommand cmd = new SqlCommand(store, conn, t);
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = store;
            #region Add Values
            cmd.Parameters.AddRange(para);
            #endregion


            try
            {
                cmd.ExecuteNonQuery();
                result = true;
                t.Commit();
            }
            catch (Exception ex)
            {
                DBProcess.RollbackTransaction(t);

                result = false;
            }
            finally
            {
                cmd.Dispose();
                CloseConn(conn);
            }
            return result;
        }

        public static int ExecAdd(string store, SqlParameter[] para)
        {

            int result = 0;
            SqlConnection conn = new SqlConnection(ConnStr);
            SqlTransaction t = null;

            OpenConn(conn);
            t = conn.BeginTransaction();

            SqlCommand cmd = new SqlCommand(store, conn, t);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = store;

            #region Add Values
            cmd.Parameters.AddRange(para);
            #endregion
            try
            {
                result = Convert.ToInt32(cmd.ExecuteScalar());
                t.Commit();
            }
            catch (Exception ex)
            {
                DBProcess.RollbackTransaction(t);
                result = 0;
            }
            finally
            {
                cmd.Dispose();
                CloseConn(conn);
            }

            return result;
        }

        #endregion
    }
    #endregion
    public class DBProcessCP
    {
        static string ConnStrCP = System.Configuration.ConfigurationSettings.AppSettings["connectionStCP"];
        //System.Configuration.ConfigurationSettings.AppSettings["connectionSt"];
        #region Connection
        public static void OpenConn(SqlConnection conn)
        {
            try
            {
                if (conn.State == ConnectionState.Open)
                {
                }
                else
                {
                    conn.Open();
                }
            }
            catch
            {
                //HttpContext.Current.Response.Redirect("error.aspx?id=1");
            }
        }

        public static void CloseConn(SqlConnection conn)
        {
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static void RollbackTransaction(SqlTransaction transaction)
        {
            if (transaction != null)
            {
                transaction.Rollback();
            }
        }

        #endregion

        #region Get Dataset
        public static DataSet GetDataSet(string store)
        {
            DataSet mDataSet = null;
            SqlConnection conn = new SqlConnection(ConnStrCP);

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = store;
            try
            {
                OpenConn(conn);
                using (SqlDataAdapter reader = new SqlDataAdapter(cmd))
                {
                    mDataSet = new DataSet();
                    reader.Fill(mDataSet);
                }
            }
            catch (Exception ex)
            {
                mDataSet = null;
            }
            finally
            {
                cmd.Dispose();
                CloseConn(conn);
            }

            return mDataSet;
        }

        public static DataTable GetDataTable(string store)
        {
            DataTable mDataSet = null;
            SqlConnection conn = new SqlConnection(ConnStrCP);

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = store;
            try
            {
                OpenConn(conn);
                using (SqlDataAdapter reader = new SqlDataAdapter(cmd))
                {
                    mDataSet = new DataTable();
                    reader.Fill(mDataSet);
                }
            }
            catch (Exception ex)
            {
                mDataSet = null;
            }
            finally
            {
                cmd.Dispose();
                CloseConn(conn);
            }

            return mDataSet;
        }

        public static DataSet GetDataSet(string store, SqlParameter[] para)
        {
            DataSet mDataSet = null;
            SqlConnection conn = new SqlConnection(ConnStrCP);

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = store;
            #region Add Values
            cmd.Parameters.AddRange(para);
            #endregion
            try
            {
                OpenConn(conn);
                using (SqlDataAdapter reader = new SqlDataAdapter(cmd))
                {

                    mDataSet = new DataSet();
                    reader.Fill(mDataSet);

                }
            }
            catch (Exception ex)
            {
                mDataSet = null;
            }
            finally
            {
                cmd.Dispose();
                CloseConn(conn);
            }

            return mDataSet;
        }

        public static DataTable GetDataTable(string store, SqlParameter[] para)
        {
            DataTable mDataSet = null;
            SqlConnection conn = new SqlConnection(ConnStrCP);

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = store;
            #region Add Values
            cmd.Parameters.AddRange(para);
            #endregion
            try
            {
                OpenConn(conn);
                using (SqlDataAdapter reader = new SqlDataAdapter(cmd))
                {
                    mDataSet = new DataTable();
                    reader.Fill(mDataSet);

                }
            }
            catch (Exception ex)
            {
                mDataSet = null;
            }
            finally
            {
                cmd.Dispose();
                CloseConn(conn);
            }

            return mDataSet;
        }

        public static string GetString(string store)
        {
            string re = "";
            DataTable mDataSet = null;
            SqlConnection conn = new SqlConnection(ConnStrCP);

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = store;
            try
            {
                OpenConn(conn);
                using (SqlDataAdapter reader = new SqlDataAdapter(cmd))
                {
                    mDataSet = new DataTable();
                    reader.Fill(mDataSet);
                    re = mDataSet.Rows[0][0].ToString();
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                cmd.Dispose();
                CloseConn(conn);
            }

            return re;
        }

        public static string GetString(string store, SqlParameter[] para)
        {
            DataTable mDataSet = null;
            SqlConnection conn = new SqlConnection(ConnStrCP);

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = store;
            #region Add Values
            cmd.Parameters.AddRange(para);
            #endregion
            try
            {
                OpenConn(conn);
                using (SqlDataAdapter reader = new SqlDataAdapter(cmd))
                {
                    mDataSet = new DataTable();
                    reader.Fill(mDataSet);

                }
            }
            catch (Exception ex)
            {
                mDataSet = null;
            }
            finally
            {
                cmd.Dispose();
                CloseConn(conn);
            }

            return mDataSet.Rows[0][0].ToString();
        }

        public static string GetStringOutput(string store, string strOutput, SqlParameter[] para)
        {
            string result = "";
            SqlConnection conn = new SqlConnection(ConnStrCP);
            SqlTransaction t = null;
            OpenConn(conn);
            t = conn.BeginTransaction();

            SqlCommand cmd = new SqlCommand(store, conn, t);
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = store;

            #region Add Values
            //cmd.Parameters.(para);
            SqlParameter outparam = cmd.Parameters.Add(strOutput, SqlDbType.NVarChar);
            outparam.Direction = ParameterDirection.Output;
            #endregion

            try
            {
                cmd.ExecuteNonQuery();
                result = cmd.Parameters[strOutput].Value.ToString();
                t.Commit();
            }
            catch (Exception ex)
            {
                DBProcessCP.RollbackTransaction(t);
                result = "";
            }
            finally
            {
                cmd.Dispose();
                CloseConn(conn);
            }
            return result;
        }
        #endregion

        #region Execute
        //result = false --> Thuc thi khong thanh cong (Loi)
        //result = true --> Thanh cong
        public static bool Exec(string store)
        {
            bool result = false;
            SqlConnection conn = new SqlConnection(ConnStrCP);
            SqlTransaction t = null;
            OpenConn(conn);
            t = conn.BeginTransaction();
            SqlCommand cmd = new SqlCommand(store, conn, t);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = store;
            try
            {
                cmd.ExecuteNonQuery();
                result = true;
                t.Commit();

            }
            catch (Exception ex)
            {
                DBProcessCP.RollbackTransaction(t);
                result = false;
            }
            finally
            {
                cmd.Dispose();
                CloseConn(conn);
            }
            return result;
        }

        public static bool Exec(string store, SqlParameter[] para)
        {
            bool result = false;
            SqlConnection conn = new SqlConnection(ConnStrCP);
            SqlTransaction t = null;
            OpenConn(conn);
            t = conn.BeginTransaction();

            SqlCommand cmd = new SqlCommand(store, conn, t);
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = store;
            #region Add Values
            cmd.Parameters.AddRange(para);
            #endregion


            try
            {
                cmd.ExecuteNonQuery();
                result = true;
                t.Commit();
            }
            catch (Exception ex)
            {
                DBProcessCP.RollbackTransaction(t);

                result = false;
            }
            finally
            {
                cmd.Dispose();
                CloseConn(conn);
            }
            return result;
        }

        public static int ExecAdd(string store, SqlParameter[] para)
        {

            int result = 0;
            SqlConnection conn = new SqlConnection(ConnStrCP);
            SqlTransaction t = null;

            OpenConn(conn);
            t = conn.BeginTransaction();

            SqlCommand cmd = new SqlCommand(store, conn, t);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = store;

            #region Add Values
            cmd.Parameters.AddRange(para);
            #endregion
            try
            {
                result = Convert.ToInt32(cmd.ExecuteScalar());
                t.Commit();
            }
            catch (Exception ex)
            {
                DBProcessCP.RollbackTransaction(t);
                result = 0;
            }
            finally
            {
                cmd.Dispose();
                CloseConn(conn);
            }

            return result;
        }

        #endregion
    }

}
