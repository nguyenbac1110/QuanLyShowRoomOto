using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlTypes;

namespace QuanLyShowRoomOto
{
    public class dangnhap
    {
        private KetNoi kn;
        public dangnhap()
        {
            kn = new KetNoi();
        }
        public bool CheckAdminLogin(string name, string password)
        {
            string sql = "SELECT COUNT(*) AS Count FROM Admin WHERE name = @name AND pass = @password";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@name", name),
                new SqlParameter("@password", password)
            };

            DataTable dt = kn.ReadData_Para(sql, parameters);
            return dt.Rows.Count > 0 && int.Parse(dt.Rows[0]["Count"].ToString()) > 0;
        }

      
        public bool CheckEmployeeLogin(string username, string password)
        {
            string sql = "SELECT COUNT(*) AS Count FROM Employee WHERE Username = @username AND Password = @password";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@username", username),
                new SqlParameter("@password", password)
            };

            DataTable dt = kn.ReadData_Para(sql, parameters);
            return dt.Rows.Count > 0 && int.Parse(dt.Rows[0]["Count"].ToString()) > 0;
        }
        public EmployeeInfo GetEmployeeInfo(string username)
        {
            string sql = "SELECT  EmployeeID,FirstName, LastName, Sex FROM Employee WHERE Username = @username";
            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@username", username)
            };

            DataTable dt = kn.ReadData_Para(sql, parameters);

            if (dt.Rows.Count > 0)
            {
                return new EmployeeInfo
                {
                    EmployeeID = dt.Rows[0]["EmployeeID"].ToString(),
                    FirstName = dt.Rows[0]["FirstName"].ToString(),
                    LastName = dt.Rows[0]["LastName"].ToString(),
                    Sex = dt.Rows[0]["Sex"].ToString()
                };
            }

            return null; 
        }
    }
    }
