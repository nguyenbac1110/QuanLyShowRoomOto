using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyShowRoomOto
{
    public class Car
    {
        private KetNoi kn;
        public Car()
        {
            kn = new KetNoi();
        }
        public DataTable LayDSXe()
        {
            string sql = "select * from Car";
            return kn.ReadData(sql);
        }
        public DataTable Load_ManufactoryID()
        {
            string sql = "SELECT ManufactoryID FROM Manufactory";
            return kn.ReadData(sql);
        }

        public bool KtraMa(string carID)
        {
            string sql = $"SELECT COUNT(*) AS Count FROM Car WHERE CarID = '{carID.Replace("'", "''")}'";

            DataTable dt = kn.ReadData(sql);
            if (dt.Rows.Count > 0 && int.Parse(dt.Rows[0]["Count"].ToString()) > 0)
                return true;

            return false;
        }
        public void CreateCar(string carID, string modelName, string name, decimal price, string status, string addInfor, string manufactoryID)
        {
            string sql = @"INSERT INTO Car(CarID, ModelName, Name, Price, Status, AddInfor, ManufactoryID)
                           VALUES (@CarID, @ModelName, @Name, @Price, @Status, @AddInfor, @ManufactoryID)";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@CarID", carID),
                new SqlParameter("@ModelName", modelName),
                new SqlParameter("@Name", name),
                new SqlParameter("@Price", price),
                new SqlParameter("@Status", status),
                new SqlParameter("@AddInfor", addInfor),
                new SqlParameter("@ManufactoryID", manufactoryID)
            };
            kn.CreateUpdateDelete(sql, sp);
        }
        public void UpdateCar(string carID, string modelName, string name, decimal price, string status, string addInfor, string manufactoryID)
        {
            string sql = @"UPDATE Car
                           SET ModelName = @ModelName, Name = @Name, Price = @Price, Status = @Status, AddInfor = @AddInfor, ManufactoryID = @ManufactoryID
                           WHERE CarID = @CarID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@CarID", carID),
                new SqlParameter("@ModelName", modelName),
                new SqlParameter("@Name", name),
                new SqlParameter("@Price", price),
                new SqlParameter("@Status", status),
                new SqlParameter("@AddInfor", addInfor),
                new SqlParameter("@ManufactoryID", manufactoryID)
            };
            kn.CreateUpdateDelete(sql, sp);
        }
        public void DeleteCar(string carID)
        {
            string sql = "DELETE FROM Car WHERE CarID = @CarID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@CarID", carID)
            };
            kn.CreateUpdateDelete(sql, sp);
        }
    }
}
