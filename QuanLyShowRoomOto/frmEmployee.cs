using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyShowRoomOto
{
    public partial class frmEmployee : Form
    {
        public Employee employee;
        public frmEmployee()
        {
            InitializeComponent();
            employee = new Employee();
        }
        private bool KtraMa(string EmployeeID)
        {
            return employee.KtraMa(EmployeeID);
        }
        private void frmEmployee_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            dgv.DataSource = employee.LayDSEmployee();
            dgv.AutoResizeColumns();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (KiemTraRong())
            {
                MessageBox.Show("Xin hãy vui lòng nhập đầy đủ thông tin!");
                return;
            }
            if (KtraMa(txtEmployeeID.Text))
            {
                MessageBox.Show("Mã nhân viên đã tồn tại!");
                return;
            }
            try
            {
                employee.CreateEmployee(txtEmployeeID.Text, txtFirstName.Text, txtLastName.Text, cbxSex.Text, dateDateOfBirth.Value, txtAddress.Text, txtPhone.Text, txtDepartmentName.Text, txtUsername.Text, txtPassword.Text);
                LoadData();
                Setrong();
                MessageBox.Show("Thêm nhân viên thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm nhân viên: " + ex.Message);
            }
        }

        private void Setrong()
        {
            txtEmployeeID.Clear();
            txtFirstName.Clear();
            txtLastName.Clear();
            txtAddress.Clear();
            txtPhone.Clear();
            txtDepartmentName.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
        }

        private bool KiemTraRong()
        {
            return string.IsNullOrWhiteSpace(txtEmployeeID.Text) || string.IsNullOrWhiteSpace(txtFirstName.Text) || string.IsNullOrWhiteSpace(txtLastName.Text) || string.IsNullOrWhiteSpace(cbxSex.Text) || string.IsNullOrWhiteSpace(dateDateOfBirth.Text) || string.IsNullOrWhiteSpace(txtAddress.Text) || string.IsNullOrWhiteSpace(txtPhone.Text) || string.IsNullOrWhiteSpace(txtDepartmentName.Text) || string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text);

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmployeeID.Text))
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên cần xóa!");
                return;
            }

            if (!KtraMa(txtEmployeeID.Text))
            {
                MessageBox.Show("Mã nhân viên không tồn tại!");
                return;
            }
            try
            {
                employee.DeleteEmployee(txtEmployeeID.Text);
                LoadData();
                Setrong();
                MessageBox.Show("Xóa nhân viên thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa nhân viên: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            txtEmployeeID.Enabled = false;
            pnlluu_boqua.Visible = true;
            pnlthem_sua.Visible = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (KiemTraRong())
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
                return;
            }

            if (!KtraMa(txtEmployeeID.Text))
            {
                MessageBox.Show("Mã nhân viên không tồn tại!");
                return;
            }
            try
            {
                employee.UpdateEmployee(txtEmployeeID.Text, txtFirstName.Text, txtLastName.Text, cbxSex.Text, dateDateOfBirth.Value, txtAddress.Text, txtPhone.Text, txtDepartmentName.Text, txtUsername.Text, txtPassword.Text);
                LoadData();
                Setrong();
                MessageBox.Show("Cập nhật nhân viên thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật khách hàng: " + ex.Message);
            }
            txtEmployeeID.Enabled = true;
        }

        private void btnSkip_Click(object sender, EventArgs e)
        {
            pnlluu_boqua.Visible = false;
            pnlthem_sua.Visible = true;
            txtEmployeeID.Enabled = true;
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
                cbxSex.Text = dgv.Rows[i].Cells[3].Value.ToString();
                dateDateOfBirth.Text = dgv.Rows[i].Cells[4].Value.ToString();
                txtAddress.Text = dgv.Rows[i].Cells[5].Value.ToString();
                txtPhone.Text = dgv.Rows[i].Cells[6].Value.ToString();
                txtDepartmentName.Text = dgv.Rows[i].Cells[7].Value.ToString();
                txtUsername.Text = dgv.Rows[i].Cells[8].Value.ToString();
                txtPassword.Text = dgv.Rows[i].Cells[9].Value.ToString();
            }
        }
    }
}
