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
    public partial class frmain : Form
    {
        private string employeeID;

        public frmain(string role, string firstName, string lastName, string sex, string employeeID)
        {
            InitializeComponent();
            this.employeeID = employeeID;

            if (role == "Admin")
            {
                pbheader.Image = Properties.Resources.anh_nam;
                lblten.Text = "Admin";
                btntimkiem_e.Visible = false;
                btntimkiem_a.Visible = true;
                btnttcn.Visible = false;
                btndangxuat.Visible = true;
            }
            else if (role == "Employee")
            {
                lblten.Text = $"{firstName} {lastName}"; 

                if (sex == "Nam")
                {
                    pbheader.Image = Properties.Resources.anh_nam; 
                }
                else if (sex == "Nu")
                {
                    pbheader.Image = Properties.Resources.anh_nu; 
                }
                btnemployee.Visible = false;
                btntimkiem_e.Visible = true;
                btntimkiem_a.Visible = false;
                btndangxuat.Visible = false;
                btnttcn.Visible = true;
            }
        }

        public void loadform(object Form)
        {
            if (this.mainpanel.Controls.Count > 0)
                this.mainpanel.Controls.RemoveAt(0);
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.mainpanel.Controls.Add(f);
            this.mainpanel.Tag = f;
            f.Show();
        }
      

        private void frmain_Load(object sender, EventArgs e)
        {
            RoundPictureBox(pbheader);
        }

        private void RoundPictureBox(PictureBox pcBheader)
        {
            if (pcBheader == null)
                return;

            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddEllipse(0, 0, pcBheader.Width - 1, pcBheader.Height - 1);

            pcBheader.Region = new Region(gp);
        }

        private void btncar_Click(object sender, EventArgs e)
        {
            loadform(new frmCar());
        }

        private void btncustomer_Click(object sender, EventArgs e)
        {
            loadform(new frmCustomer());
        }

        private void btnemployee_Click(object sender, EventArgs e)
        {
            loadform(new frmEmployee());
        }

        private void btnmanufactory_Click(object sender, EventArgs e)
        {
            loadform(new frmManufactory());
        }

        private void btnorder_Click(object sender, EventArgs e)
        {
            loadform(new frmOrder());
        }

        

        private void frmain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btntimkiem_e_Click(object sender, EventArgs e)
        {
            loadform(new frmTimKiem_e());
        }

        private void btntimkiem_a_Click(object sender, EventArgs e)
        {
            loadform(new frmTimKiem_a());
        }

        private void btndangxuat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show( "Bạn có chắc chắn muốn đăng xuất không?","Xác nhận đăng xuất",  MessageBoxButtons.YesNo, MessageBoxIcon.Question  );
            if (result == DialogResult.Yes)
            {
                frmDangNhap frmDangNhap = new frmDangNhap();
                frmDangNhap.Show(); 
                this.Hide();
            }
        }

        private void btnttcn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(employeeID))
            {
                loadform(new frmcanhan(employeeID, this));
            }
            else
            {
                MessageBox.Show("Không thể tải thông tin nhân viên. Vui lòng đăng nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
