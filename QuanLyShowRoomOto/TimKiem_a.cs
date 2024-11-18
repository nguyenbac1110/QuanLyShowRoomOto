using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyShowRoomOto
{
    public class TimKiem_a
    {
        private KetNoi kn;

        public TimKiem_a()
        {
            kn = new KetNoi();
        }
        public DataTable LayDanhSachCot(string tableName)
        {
            string sql = $"SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{tableName}'";
            return kn.ReadData(sql);
        }

        public DataTable LayDuLieu(string table, string column)
        {
            //Order là từ khóa dự trữ (reserved keyword) trong SQL Server
            string sql = $"SELECT [{column}] FROM [{table}]";
            return kn.ReadData(sql);
        }
        public DataTable TimKiemDuLieu(string tableName, string columnName, string value)
        {
            string sql = $"SELECT * FROM [{tableName}] WHERE [{columnName}] = @Value";
            SqlParameter[] parameters = new SqlParameter[]
            {
             new SqlParameter("@Value", value)
            };
            return kn.ReadData_Para(sql, parameters);
        }
    }
}
