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
    public partial class frmEmployee : Form
    {
        SqlConnection con;

        SqlDataAdapter adapter = new SqlDataAdapter();

        public frmEmployee()
        {
            InitializeComponent();
        }

        private void frmEmployee_Load(object sender, EventArgs e)
        {
            string constring = ConfigurationManager.ConnectionStrings["ql"].ConnectionString.ToString();
            con = new SqlConnection(constring);
            con.Open();
            Hienthi();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string sqlINSERT = "INSERT INTO Employee(EmployeeID, FirstName, LastName, Sex, DateOfBirth, Address, Phone, DepartmentName, Username, Password) VALUES (@EmployeeID, @FirstName, @LastName, @Sex, @DateOfBirth, @Address, @Phone, @DepartmentName, @Username, @Password)";
            SqlCommand cmd = new SqlCommand(sqlINSERT, con);
            cmd.Parameters.AddWithValue("EmployeeID", txtEmployeeID.Text);
            cmd.Parameters.AddWithValue("FirstName", txtFirstName.Text);
            cmd.Parameters.AddWithValue("LastName", txtLastName.Text);
            cmd.Parameters.AddWithValue("Sex", cbxSex.SelectedIndex == 0 ? 1 : 0);
            cmd.Parameters.AddWithValue("DateOfBirth", dateDateOfBirth.Value);
            cmd.Parameters.AddWithValue("Address", txtAddress.Text);
            cmd.Parameters.AddWithValue("Phone", txtPhone.Text);
            cmd.Parameters.AddWithValue("DepartmentName", txtDepartmentName.Text);
            cmd.Parameters.AddWithValue("Username", txtUsername.Text);
            cmd.Parameters.AddWithValue("Password", txtPassword.Text);
            cmd.ExecuteNonQuery();
            Hienthi();
            MessageBox.Show("Nhân viên được thêm thành công!"); ;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string sqlDELETE = "DELETE FROM Employee WHERE EmployeeID = @EmployeeID";
            SqlCommand cmd = new SqlCommand(sqlDELETE, con);
            cmd.Parameters.AddWithValue("@EmployeeID", txtEmployeeID.Text);
            try
            {
                cmd.ExecuteNonQuery();
                Hienthi();
                MessageBox.Show("Xóa thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Hienthi();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            pnlluu_boqua.Visible = true;
            pnlthem_sua.Visible = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string sqlEDIT = "UPDATE Employee SET FirstName = @FirstName, LastName = @LastName, Sex = @Sex, DateOfBirth = @DateOfBirth, Address = @Address, Phone = @Phone, DepartmentName = @DepartmentName, Username = @Username, Password = @Password WHERE EmployeeID = @EmployeeID";
            SqlCommand cmd = new SqlCommand(sqlEDIT, con);
            cmd.Parameters.AddWithValue("EmployeeID", txtEmployeeID.Text);
            cmd.Parameters.AddWithValue("FirstName", txtFirstName.Text);
            cmd.Parameters.AddWithValue("LastName", txtLastName.Text);
            cmd.Parameters.AddWithValue("Sex", cbxSex.SelectedIndex == 0 ? 1 : 0);
            cmd.Parameters.AddWithValue("DateOfBirth", dateDateOfBirth.Value);
            cmd.Parameters.AddWithValue("Address", txtAddress.Text);
            cmd.Parameters.AddWithValue("Phone", txtPhone.Text);
            cmd.Parameters.AddWithValue("DepartmentName", txtDepartmentName.Text);
            cmd.Parameters.AddWithValue("Username", txtUsername.Text);
            cmd.Parameters.AddWithValue("Password", txtPassword.Text);
            cmd.ExecuteNonQuery();
            Hienthi();
            MessageBox.Show("Đã sửa thông tin nhân viên có mã: " + txtEmployeeID.Text);
        }

        private void btnSkip_Click(object sender, EventArgs e)
        {
            pnlluu_boqua.Visible = false;
            pnlthem_sua.Visible = true;
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            if (e.RowIndex >= 0)
            {
                i = e.RowIndex;
                txtEmployeeID.Text = dgv.Rows[i].Cells[0].Value.ToString();
                txtFirstName.Text = dgv.Rows[i].Cells[1].Value.ToString();
                txtLastName.Text = dgv.Rows[i].Cells[2].Value.ToString();
                cbxSex.Text = dgv.Rows[i].Cells[3].Value.ToString().ToLower() == "true" ? "Nam" : "Nữ";
                dateDateOfBirth.Text = dgv.Rows[i].Cells[4].Value.ToString();
                txtAddress.Text = dgv.Rows[i].Cells[5].Value.ToString();
                txtPhone.Text = dgv.Rows[i].Cells[6].Value.ToString();
                txtDepartmentName.Text = dgv.Rows[i].Cells[7].Value.ToString();
                txtUsername.Text = dgv.Rows[i].Cells[8].Value.ToString();
                txtPassword.Text = dgv.Rows[i].Cells[9].Value.ToString();
            }
        }

        public void Hienthi()
        {
            string sqlSelect = "SELECT *, CASE WHEN Sex = 1 THEN 'Nam' ELSE 'Nữ' END AS NewSex FROM Employee";
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
    }
}
