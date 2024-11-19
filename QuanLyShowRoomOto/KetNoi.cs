using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyShowRoomOto
{
    public class KetNoi
    {
        public SqlConnection con;
        public void openConnection()
        {
            //string constring = ConfigurationManager.ConnectionStrings["ql"].ConnectionString.ToString();
            con = new SqlConnection($@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={Application.StartupPath}\qlshowroom.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
        }
        public void closeConnection()
        {
            con.Close();
        }
        public DataTable ReadData(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                openConnection();
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                closeConnection();
            }
            return dt;
        }
        public DataTable ReadData_Para(string sql, SqlParameter[] parameters = null)
        {
            DataTable dt = new DataTable();
            try
            {
                openConnection();
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                closeConnection();
            }
            return dt;
        }
        public void CreateUpdateDelete(string sql, SqlParameter[] sqlParameters = null)
        {
            try
            {
                openConnection();
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    if (sqlParameters != null) cmd.Parameters.AddRange(sqlParameters);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                closeConnection();
            }
        }
      
    }
}

