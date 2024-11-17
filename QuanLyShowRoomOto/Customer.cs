using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyShowRoomOto
{
    public class Customer
    {
        private KetNoi kn;

        public Customer()
        {
            kn = new KetNoi();
        }
        public bool KtraMa(string CustomerID)
        {
            string sql = $"SELECT COUNT(*) AS Count FROM Customer WHERE CustomerID = '{CustomerID.Replace("'", "''")}'";

            DataTable dt = kn.ReadData(sql);
            if (dt.Rows.Count > 0 && int.Parse(dt.Rows[0]["Count"].ToString()) > 0)
                return true;

            return false;
        }
        public DataTable GetAllCustomers()
        {
            string sql = "SELECT * FROM Customer";
            return kn.ReadData(sql);
        }

        public void InsertCustomer(string customerID, string firstName, string lastName, string sex, DateTime dateOfBirth, string address, string phone)
        {
            string sql = @"INSERT INTO Customer (CustomerID, FirstName, LastName, Sex, DateOfBirth, Address, Phone) 
                       VALUES (@CustomerID, @FirstName, @LastName, @Sex, @DateOfBirth, @Address, @Phone)";
            SqlParameter[] parameters =
            {
            new SqlParameter("@CustomerID", customerID),
            new SqlParameter("@FirstName", firstName),
            new SqlParameter("@LastName", lastName),
            new SqlParameter("@Sex", sex),
            new SqlParameter("@DateOfBirth", dateOfBirth),
            new SqlParameter("@Address", address),
            new SqlParameter("@Phone", phone)
             };
            kn.CreateUpdateDelete(sql, parameters);
        }

        public void UpdateCustomer(string customerID, string firstName, string lastName, string sex, DateTime dateOfBirth, string address, string phone)
        {
            string sql = @"UPDATE Customer SET FirstName = @FirstName, LastName = @LastName, Sex = @Sex, 
                       DateOfBirth = @DateOfBirth, Address = @Address, Phone = @Phone 
                       WHERE CustomerID = @CustomerID";
            SqlParameter[] parameters =
            {
            new SqlParameter("@CustomerID", customerID),
            new SqlParameter("@FirstName", firstName),
            new SqlParameter("@LastName", lastName),
            new SqlParameter("@Sex", sex),
            new SqlParameter("@DateOfBirth", dateOfBirth),
            new SqlParameter("@Address", address),
            new SqlParameter("@Phone", phone)
        };
            kn.CreateUpdateDelete(sql, parameters);
        }

        public void DeleteCustomer(string customerID)
        {
            string sql = "DELETE FROM Customer WHERE CustomerID = @CustomerID";
            SqlParameter parameter = new SqlParameter("@CustomerID", customerID);
            kn.CreateUpdateDelete(sql, new SqlParameter[] { parameter });
        }
    }
}
