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
        SqlConnection con;

        SqlDataAdapter adapter = new SqlDataAdapter();
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            string username = txttk.Text.Trim();
            string password = txtmk.Text.Trim();
            if (username == "admin" && password == "admin")
            {
                frmain mainForm = new frmain("Admin"); 
                mainForm.Show();
                this.Hide();
                return; 
            }
            string query = "SELECT COUNT(*) FROM Employee WHERE Username = @username AND Password = @password";

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                int count = (int)cmd.ExecuteScalar(); 

                if (count > 0)
                {
                    MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmain mainForm = new frmain("Employee"); 
                    mainForm.Show();
                    this.Hide(); 
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng.", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

           
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            string constring = ConfigurationManager.ConnectionStrings["ql"].ConnectionString.ToString();
            con = new SqlConnection(constring);
            con.Open();
        }
    }
}
