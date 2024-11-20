using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyShowRoomOto
{
    public class Order
    {
        private KetNoi kn;

        public Order()
        {
            kn = new KetNoi();
        }

        public DataTable GetCustomers()
        {
            return kn.ReadData("SELECT CustomerID FROM Customer");
        }
        public CarInfo GetCarInfoByID(int carID)
        {
            string query = "SELECT Name, Price FROM Car WHERE CarID = @CarID";
            SqlParameter[] parameters = {
                new SqlParameter("@CarID", carID)
            };
            DataTable dt = kn.ReadData_Para(query, parameters);

            if (dt.Rows.Count > 0)
            {
                return new CarInfo
                {
                    Name = dt.Rows[0]["Name"].ToString(),
                    Price = Convert.ToSingle(dt.Rows[0]["Price"])
                };
            }
            return null; 
        }
        public DataTable GetEmployees()
        {
            return kn.ReadData("SELECT EmployeeID FROM Employee");
        }

        public DataTable GetCars()
        {
            return kn.ReadData("SELECT CarID, Name FROM Car");
        }
        public void AddOrder(string orderId, string customerId, string employeeId, DateTime date, string request, decimal total)
        {
            string query = "INSERT INTO [Order] (OrderID, CustomerID, EmployeeID, Date, Request, Total) " +
                           "VALUES (@OrderID, @CustomerID, @EmployeeID, @Date, @Request, @Total)";
            SqlParameter[] parameters = {
                new SqlParameter("@OrderID", orderId),
                new SqlParameter("@CustomerID", customerId),
                new SqlParameter("@EmployeeID", employeeId),
                new SqlParameter("@Date", date),
                new SqlParameter("@Request", request),
                new SqlParameter("@Total", total)
            };
            kn.CreateUpdateDelete(query, parameters);
        }

        public void AddOrderDetail(string orderId, string carId, int quantity, decimal price)
        {
            string query = "INSERT INTO OrderDetails (OrderID, CarID, Quantity, Price) " +
                           "VALUES (@OrderID, @CarID, @Quantity, @Price)";
            SqlParameter[] parameters = {
                new SqlParameter("@OrderID", orderId),
                new SqlParameter("@CarID", carId),
                new SqlParameter("@Quantity", quantity),
                new SqlParameter("@Price", price)
            };
            kn.CreateUpdateDelete(query, parameters);
        }
        public void DeleteOrder(string orderId)
        {
            string deleteOrderDetailsQuery = "DELETE FROM OrderDetails WHERE OrderID = @OrderID";
            string deleteOrderQuery = "DELETE FROM [Order] WHERE OrderID = @OrderID";
            SqlParameter[] parametersForDetails = {
                new SqlParameter("@OrderID", orderId)
            };
                    SqlParameter[] parametersForOrder = {
                new SqlParameter("@OrderID", orderId)
            };
            kn.CreateUpdateDelete(deleteOrderDetailsQuery, parametersForDetails);
            kn.CreateUpdateDelete(deleteOrderQuery, parametersForOrder);
        }
        public DataTable LoadOrders()
        {
            string query = "SELECT OrderID FROM [Order]";
            return kn.ReadData(query);
        }
    }
}
