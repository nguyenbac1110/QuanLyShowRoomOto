using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyShowRoomOto
{
    namespace QuanLyShowRoomOto
    {
        public class canhan
        {
            private KetNoi kn;

            public canhan()
            {
                kn = new KetNoi();
            }

            public DataTable GetEmployeeInfoByID(string employeeID)
            {
                string sql = "SELECT EmployeeID, FirstName, LastName, Sex, DateOfBirth, Address, Phone FROM Employee WHERE EmployeeID = @employeeID";
                SqlParameter[] parameters = new SqlParameter[]
                {
                new SqlParameter("@employeeID", employeeID)
                };

                return kn.ReadData_Para(sql, parameters);
            }

            public void UpdateEmployeeInfo(string employeeID, string firstName, string lastName, string sex, DateTime dateOfBirth, string address, string phone)
            {
                string sql = @"UPDATE Employee 
                           SET FirstName = @firstName, 
                               LastName = @lastName, 
                               Sex = @sex, 
                               DateOfBirth = @dateOfBirth, 
                               Address = @address, 
                               Phone = @phone
                           WHERE EmployeeID = @employeeID";

                SqlParameter[] parameters = new SqlParameter[]
                {
                new SqlParameter("@employeeID", employeeID),
                new SqlParameter("@firstName", firstName),
                new SqlParameter("@lastName", lastName),
                new SqlParameter("@sex", sex),
                new SqlParameter("@dateOfBirth", dateOfBirth),
                new SqlParameter("@address", address),
                new SqlParameter("@phone", phone)
                };

                kn.CreateUpdateDelete(sql, parameters);
            }
        }
    }
}
