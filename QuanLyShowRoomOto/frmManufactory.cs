using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public partial class frmManufactory : Form
    {
        SqlConnection con;
        SqlDataAdapter adapter = new SqlDataAdapter();

        public frmManufactory()
        {
            InitializeComponent();
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            string sqlINSERT = "INSERT INTO Manufactory( ManufactoryID, ManufactoryName, Address, Phone, AddInfor) VALUES ( @ManufactoryID, @ManufactoryName, @Address, @Phone, @AddInfor)";
            SqlCommand cmd = new SqlCommand(sqlINSERT, con);
            cmd.Parameters.AddWithValue("ManufactoryID", txtMa.Text);
            cmd.Parameters.AddWithValue("ManufactoryName", txtTen.Text);
            cmd.Parameters.AddWithValue("Address", txtDiaChi.Text);
            cmd.Parameters.AddWithValue("Phone", txtSDT.Text);
            cmd.Parameters.AddWithValue("AddInfor", txtTTBS.Text);
            cmd.ExecuteNonQuery();
            Hienthi();
            Clear();
            MessageBox.Show("Đã thêm mới xe thành công!", "Thông báo", MessageBoxButtons.OK); ;
        }

        private void frmManufactory_Load(object sender, EventArgs e)
        {
            string constring = ConfigurationManager.ConnectionStrings["ql"].ConnectionString.ToString();
            con = new SqlConnection(constring);
            con.Open();
            Hienthi();
        }

        public void Hienthi()
        {
            string sqlSelect = "select * from Manufactory";
            SqlCommand cmd = new SqlCommand(sqlSelect, con);
            DataTable dt = new DataTable();
            adapter.SelectCommand = cmd;
            dt.Clear();
            adapter.Fill(dt);
            dgv.DataSource = dt;
            dgv.AutoResizeColumns();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            string sqlDELETE = "DELETE FROM Manufactory WHERE ManufactoryID = @ManufactoryID";
            SqlCommand cmd = new SqlCommand(sqlDELETE, con);
            cmd.Parameters.AddWithValue("@ManufactoryID", txtMa.Text);
            try
            {
                cmd.ExecuteNonQuery();
                Hienthi();
                Clear();
                MessageBox.Show("Xóa thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa mặt hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Hienthi();
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
           
            string sqlEDIT = "UPDATE Manufactory SET ManufactoryName = @ManufactoryName, Address = @Address,Phone =@Phone, AddInfor = @AddInfor where ManufactoryID =@ManufactoryID";
            SqlCommand cmd = new SqlCommand(sqlEDIT, con);
            cmd.Parameters.AddWithValue("ManufactoryID", txtMa.Text);
            cmd.Parameters.AddWithValue("ManufactoryName", txtTen.Text);
            cmd.Parameters.AddWithValue("Address", txtDiaChi.Text);
            cmd.Parameters.AddWithValue("Phone", txtSDT.Text);
            cmd.Parameters.AddWithValue("AddInfor", txtTTBS.Text);
            cmd.ExecuteNonQuery();
            Hienthi();
            MessageBox.Show("Đã sửa thông tin xe có mã xe là: " + txtMa.Text, "Thông báo", MessageBoxButtons.OK);
        }

        private void btnboqua_Click(object sender, EventArgs e)
        {
            pnlluu_boqua.Visible = false;
            pnlthem_sua.Visible = true;
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            pnlluu_boqua.Visible = true;
            pnlthem_sua.Visible = false;
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            if (e.RowIndex >= 0)
            {
                i = e.RowIndex;
                txtMa.Text = dgv.Rows[i].Cells[0].Value.ToString();
                txtTen.Text = dgv.Rows[i].Cells[1].Value.ToString();
                txtDiaChi.Text = dgv.Rows[i].Cells[2].Value.ToString();
                txtSDT.Text = dgv.Rows[i].Cells[3].Value.ToString();
                txtTTBS.Text = dgv.Rows[i].Cells[4].Value.ToString();
            }
        }
        public void Clear()
        {
            txtMa.Text = "";
            txtTen.Text = "";
            txtDiaChi.Text = "";
            txtSDT.Text = "";
            txtTTBS.Text = "";
        }

    }
}
