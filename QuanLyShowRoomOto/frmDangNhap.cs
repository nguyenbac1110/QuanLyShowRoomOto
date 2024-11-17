using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;


namespace QuanLyShowRoomOto
{
    public partial class frmDangNhap : Form
    {
        dangnhap dangnhap;
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            string username = txttk.Text.Trim();
            string password = txtmk.Text.Trim();

            if (dangnhap.CheckAdminLogin(username, password))
            {
                MessageBox.Show("Đăng nhập Admin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmain mainForm = new frmain("Admin", null, null, null);
                mainForm.Show();
                this.Hide();
                return;
            }
            if (dangnhap.CheckEmployeeLogin(username, password))
            {
                var employeeInfo = dangnhap.GetEmployeeInfo(username);
                MessageBox.Show("Đăng nhập Employee thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmain mainForm = new frmain("Employee", employeeInfo.FirstName, employeeInfo.LastName, employeeInfo.Sex);
                mainForm.Show();
                this.Hide();
                return;
            }
            MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng.", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
           dangnhap = new dangnhap();
        }
    }
}
