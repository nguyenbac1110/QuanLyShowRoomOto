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
    public partial class frmCustomer : Form
    {
        public frmCustomer()
        {
            InitializeComponent();
        }
        SqlConnection con;

        SqlDataAdapter adapter = new SqlDataAdapter();

        private void frmCustomer_Load(object sender, EventArgs e)
        {
            string constring = ConfigurationManager.ConnectionStrings["ql"].ConnectionString.ToString();
            con = new SqlConnection(constring);
            con.Open();
            Hienthi();
        }
        public void Hienthi()
        {
            string sqlSelect = "select * , CASE WHEN Sex = 1 THEN 'Nam' ELSE 'Nữ' END AS NewSex from Customer";
            SqlCommand cmd = new SqlCommand(sqlSelect, con);
            DataTable dt = new DataTable();
            adapter.SelectCommand = cmd;
            dt.Clear();
            adapter.Fill(dt);
            dgv.DataSource = dt;
            dgv.Columns["Sex"].Visible = false;
            dgv.Columns["NewSex"].HeaderText = "Giới Tính";
            dgv.Columns["NewSex"].DisplayIndex = 3;
            dgv.AutoResizeColumns();
        }
        private void btnthem_Click(object sender, EventArgs e)
        {
            string sqlINSERT = "INSERT INTO Customer(CustomerID,FirstName,LastName, Sex, DateOfBirth, Address, Phone) VALUES (@CustomerID,@FirstName,@LastName, @Sex, @DateOfBirth, @Address, @Phone)";
            SqlCommand cmd = new SqlCommand(sqlINSERT, con);
            cmd.Parameters.AddWithValue("CustomerID", txtma.Text);
            cmd.Parameters.AddWithValue("FirstName", txtfiname.Text);
            cmd.Parameters.AddWithValue("LastName", txtlaname.Text);
            cmd.Parameters.AddWithValue("Sex", cbxgt.SelectedIndex == 0 ? 1 : 0);
            cmd.Parameters.AddWithValue("DateOfBirth", dtpNs.Value);
            cmd.Parameters.AddWithValue("Address", txtdiachi.Text);
            cmd.Parameters.AddWithValue("Phone", txtsdt.Text);
            cmd.ExecuteNonQuery();
            Hienthi();
            MessageBox.Show("Đã thêm khách hàng mới thành công!"); ;
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            string sqlDELETE = "DELETE FROM Customer WHERE CustomerID = @CustomerID";
            SqlCommand cmd = new SqlCommand(sqlDELETE, con);
            cmd.Parameters.AddWithValue("@CustomerID", txtma.Text);
            try
            {
                cmd.ExecuteNonQuery();
                Hienthi();
                MessageBox.Show("Xóa thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa : " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Hienthi();
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            string sqlEDIT = "UPDATE Customer SET FirstName = @FirstName,LastName = @LastName,Sex =@Sex,DateOfBirth = @DateOfBirth,Address = @Address, Phone=@Phone where CustomerID = @CustomerID";
            SqlCommand cmd = new SqlCommand(sqlEDIT, con);
            cmd.Parameters.AddWithValue("CustomerID", txtma.Text);
            cmd.Parameters.AddWithValue("FirstName", txtfiname.Text);
            cmd.Parameters.AddWithValue("LastName", txtlaname.Text);
            cmd.Parameters.AddWithValue("Sex", cbxgt.SelectedIndex == 0 ? 1 : 0);
            cmd.Parameters.AddWithValue("DateOfBirth", dtpNs.Value);
            cmd.Parameters.AddWithValue("Address", txtdiachi.Text);
            cmd.Parameters.AddWithValue("Phone", txtsdt.Text);
            cmd.ExecuteNonQuery();
            Hienthi();
            MessageBox.Show("Đã sửa thông tin khách có mã là: " + txtma.Text);
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
                txtma.Text = dgv.Rows[i].Cells[0].Value.ToString();
                txtfiname.Text = dgv.Rows[i].Cells[1].Value.ToString();
                txtlaname.Text = dgv.Rows[i].Cells[2].Value.ToString();
                cbxgt.Text = dgv.Rows[i].Cells[3].Value.ToString().ToLower() == "true" ? "Nam" : "Nữ";
                dtpNs.Text = dgv.Rows[i].Cells[4].Value.ToString();
                txtdiachi.Text = dgv.Rows[i].Cells[5].Value.ToString();
                txtsdt.Text = dgv.Rows[i].Cells[6].Value.ToString();
            }
        }
    }
}
