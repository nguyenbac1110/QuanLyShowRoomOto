using System;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyShowRoomOto
{
    public class Employee
    {
        private KetNoi kn;

        public Employee()
        {
            kn = new KetNoi();
        }

        public DataTable LayDSEmployee()
        {
            string sql = "SELECT * FROM Employee";
            return kn.ReadData(sql);
        }

        public bool KtraMa(string employeeID)
        {
            string sql = $"SELECT COUNT(*) AS Count FROM Employee WHERE EmployeeID = '{employeeID.Replace("'", "''")}'";
            DataTable dt = kn.ReadData(sql);
            return dt.Rows.Count > 0 && int.Parse(dt.Rows[0]["Count"].ToString()) > 0;
        }

        public void CreateEmployee(string employeeID, string firstName, string lastName, string sex, DateTime dateOfBirth, string address, string phone, string departmentName, string username, string password)
        {
            string sql = @"INSERT INTO Employee(EmployeeID, FirstName, LastName, Sex, DateOfBirth, Address, Phone, DepartmentName, Username, Password)
                           VALUES (@EmployeeID, @FirstName, @LastName, @Sex, @DateOfBirth, @Address, @Phone, @DepartmentName, @Username, @Password)";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@EmployeeID", employeeID),
                new SqlParameter("@FirstName", firstName),
                new SqlParameter("@LastName", lastName),
                new SqlParameter("@Sex", sex),
                new SqlParameter("@DateOfBirth", dateOfBirth),
                new SqlParameter("@Address", address),
                new SqlParameter("@Phone", phone),
                new SqlParameter("@DepartmentName", departmentName),
                new SqlParameter("@Username", username),
                new SqlParameter("@Password", password)
            };
            kn.CreateUpdateDelete(sql, sp);
        }

        public void UpdateEmployee(string employeeID, string firstName, string lastName, string sex, DateTime dateOfBirth, string address, string phone, string departmentName, string username, string password)
        {
            string sql = @"UPDATE Employee
                           SET FirstName = @FirstName, LastName = @LastName, Sex = @Sex, DateOfBirth = @DateOfBirth, Address = @Address,
                               Phone = @Phone, DepartmentName = @DepartmentName, Username = @Username, Password = @Password
                           WHERE EmployeeID = @EmployeeID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@EmployeeID", employeeID),
                new SqlParameter("@FirstName", firstName),
                new SqlParameter("@LastName", lastName),
                new SqlParameter("@Sex", sex),
                new SqlParameter("@DateOfBirth", dateOfBirth),
                new SqlParameter("@Address", address),
                new SqlParameter("@Phone", phone),
                new SqlParameter("@DepartmentName", departmentName),
                new SqlParameter("@Username", username),
                new SqlParameter("@Password", password)
            };
            kn.CreateUpdateDelete(sql, sp);
        }

        public void DeleteEmployee(string employeeID)
        {
            string sql = "DELETE FROM Employee WHERE EmployeeID = @EmployeeID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@EmployeeID", employeeID)
            };
            kn.CreateUpdateDelete(sql, sp);
        }
    }
}
