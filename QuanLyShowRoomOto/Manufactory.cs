using System.Data;
using System.Data.SqlClient;

namespace QuanLyShowRoomOto
{
    public class Manufactory
    {
        private KetNoi kn;

        public Manufactory()
        {
            kn = new KetNoi();
        }

        public DataTable LayDSManufactory()
        {
            string sql = "SELECT * FROM Manufactory";
            return kn.ReadData(sql);
        }

        public bool KtraMa(string manufactoryID)
        {
            string sql = $"SELECT COUNT(*) AS Count FROM Manufactory WHERE ManufactoryID = '{manufactoryID.Replace("'", "''")}'";
            DataTable dt = kn.ReadData(sql);
            return dt.Rows.Count > 0 && int.Parse(dt.Rows[0]["Count"].ToString()) > 0;
        }

        public void CreateManufactory(string manufactoryID, string manufactoryName, string address, string phone, string addInfor)
        {
            string sql = @"INSERT INTO Manufactory(ManufactoryID, ManufactoryName, Address, Phone, AddInfor)
                           VALUES (@ManufactoryID, @ManufactoryName, @Address, @Phone, @AddInfor)";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ManufactoryID", manufactoryID),
                new SqlParameter("@ManufactoryName", manufactoryName),
                new SqlParameter("@Address", address),
                new SqlParameter("@Phone", phone),
                new SqlParameter("@AddInfor", addInfor)
            };
            kn.CreateUpdateDelete(sql, sp);
        }

        public void UpdateManufactory(string manufactoryID, string manufactoryName, string address, string phone, string addInfor)
        {
            string sql = @"UPDATE Manufactory
                           SET ManufactoryName = @ManufactoryName, Address = @Address, Phone = @Phone, AddInfor = @AddInfor
                           WHERE ManufactoryID = @ManufactoryID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ManufactoryID", manufactoryID),
                new SqlParameter("@ManufactoryName", manufactoryName),
                new SqlParameter("@Address", address),
                new SqlParameter("@Phone", phone),
                new SqlParameter("@AddInfor", addInfor)
            };
            kn.CreateUpdateDelete(sql, sp);
        }

        public void DeleteManufactory(string manufactoryID)
        {
            string sql = "DELETE FROM Manufactory WHERE ManufactoryID = @ManufactoryID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@ManufactoryID", manufactoryID)
            };
            kn.CreateUpdateDelete(sql, sp);
        }
    }
}
