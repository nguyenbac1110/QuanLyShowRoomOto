using QuanLyShowRoomOto.QuanLyShowRoomOto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyShowRoomOto
{
    public partial class frmcanhan : Form
    {
        private string employeeID;
        private canhan canhan;
        private Form frmmain;
        public frmcanhan(string employeeID, Form frmmain)
        {
            InitializeComponent();
            this.employeeID = employeeID;
            this.frmmain = frmmain;
            canhan = new canhan();
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            xet(true);
            
        }

        private void btnboqua_Click(object sender, EventArgs e)
        {
            xet(false);
           
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            try
            {
                canhan.UpdateEmployeeInfo(
                    txtEmployeeID.Text.Trim(),
                    txtFirstName.Text.Trim(),
                    txtLastName.Text.Trim(),
                    cbxSex.Text.Trim(),
                    dateDateOfBirth.Value,
                    txtAddress.Text.Trim(),
                    txtPhone.Text.Trim()
                );

                MessageBox.Show("Lưu thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                xet(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btndangxuat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                frmDangNhap frmDangNhap = new frmDangNhap();
                frmDangNhap.Show();
                if (frmmain != null)
                {
                    frmmain.Hide(); 
                }
                else
                {
                    MessageBox.Show("Lỗi: frmmain không được khởi tạo.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void xet(bool check)
        {
            txtEmployeeID.Enabled = false;
            txtAddress.Enabled = check;
            txtFirstName.Enabled = check;
            txtLastName.Enabled = check;
            txtPhone.Enabled = check;
            dateDateOfBirth.Enabled = check;
            btnboqua.Visible = check;
            btnluu.Visible = check;
        }

        private void frmcanhan_Load(object sender, EventArgs e)
        {
            LoadEmployeeInfo();
            xet(false);
        }
        private void LoadEmployeeInfo()
        {
            DataTable dt = canhan.GetEmployeeInfoByID(employeeID);

            if (dt.Rows.Count > 0)
            {
                txtEmployeeID.Text = dt.Rows[0]["EmployeeID"].ToString();
                txtFirstName.Text = dt.Rows[0]["FirstName"].ToString();
                txtLastName.Text = dt.Rows[0]["LastName"].ToString();
                cbxSex.Text = dt.Rows[0]["Sex"].ToString();
                dateDateOfBirth.Value = Convert.ToDateTime(dt.Rows[0]["DateOfBirth"]);
                txtAddress.Text = dt.Rows[0]["Address"].ToString();
                txtPhone.Text = dt.Rows[0]["Phone"].ToString();
            }
        }
    }
}
