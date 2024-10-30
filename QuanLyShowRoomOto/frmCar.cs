using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace QuanLyShowRoomOto
{
    public partial class frmCar : Form
    {
        public frmCar()
        {
            InitializeComponent();
        }
        SqlConnection con;

        SqlDataAdapter adapter = new SqlDataAdapter();

        private void frmCar_Load(object sender, EventArgs e)
        {
            string constring = ConfigurationManager.ConnectionStrings["ql"].ConnectionString.ToString();
            con = new SqlConnection(constring);
            con.Open();
            Hienthi();
            LoadManufactoryID();
        }

        public void Hienthi()
        {
            string sqlSelect = "select * from Car";
            SqlCommand cmd = new SqlCommand(sqlSelect, con);
            DataTable dt = new DataTable();
            adapter.SelectCommand = cmd;
            dt.Clear();
            adapter.Fill(dt);
            dgv.DataSource = dt;
            dgv.AutoResizeColumns();
        }

        public void LoadManufactoryID()
        {
            string constring = ConfigurationManager.ConnectionStrings["ql"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {
                con.Open();
                string query = "SELECT ManufactoryID FROM Manufactory";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    cbxnsxId.Items.Clear();
                    while (reader.Read())
                    {
                        cbxnsxId.Items.Add(reader["ManufactoryID"].ToString());
                    }
                }
            }
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            if (e.RowIndex >= 0)
            {
                i = e.RowIndex;
                txtma.Text = dgv.Rows[i].Cells[0].Value.ToString();
                txtmodel.Text = dgv.Rows[i].Cells[1].Value.ToString();
                txtten.Text = dgv.Rows[i].Cells[2].Value.ToString();
                txtgia.Text = dgv.Rows[i].Cells[3].Value.ToString();
                txttt.Text = dgv.Rows[i].Cells[4].Value.ToString();
                txtaddinf.Text = dgv.Rows[i].Cells[5].Value.ToString();
                cbxnsxId.Text = dgv.Rows[i].Cells[6].Value.ToString();
            }
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            string sqlINSERT = "INSERT INTO Car(CarID,ModelName, Name, Price, Status, AddInfor, ManufactoryID) VALUES (@CarID,@ModelName, @Name, @Price, @Status, @AddInfor, @ManufactoryID)";
            SqlCommand cmd = new SqlCommand(sqlINSERT, con);
            cmd.Parameters.AddWithValue("CarID", txtma.Text);
            cmd.Parameters.AddWithValue("ModelName", txtmodel.Text);
            cmd.Parameters.AddWithValue("Name", txtten.Text);
            cmd.Parameters.AddWithValue("Price", txtgia.Text);
            cmd.Parameters.AddWithValue("Status", txttt.Text);
            cmd.Parameters.AddWithValue("AddInfor", txtaddinf.Text);
            cmd.Parameters.AddWithValue("ManufactoryID", cbxnsxId.SelectedItem.ToString());
            cmd.ExecuteNonQuery();
            Hienthi();
            MessageBox.Show("Đã thêm mới xe thành công!"); ;
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            string sqlDELETE = "DELETE FROM Car WHERE CarID = @CarID";
            SqlCommand cmd = new SqlCommand(sqlDELETE, con);
            cmd.Parameters.AddWithValue("@CarID", txtma.Text);
            try
            {
                cmd.ExecuteNonQuery();
                Hienthi();
                MessageBox.Show("Xóa thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa mặt hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Hienthi();
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            pnlluu_boqua.Visible = true;
            pnlthem_sua.Visible = false;
        }

        private void btnboqua_Click(object sender, EventArgs e)
        {
            pnlluu_boqua.Visible = false;
            pnlthem_sua.Visible = true;
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            string sqlEDIT = "UPDATE Car SET ModelName = @ModelName,Name = @Name,Price =@Price,Status = @Status,AddInfor = @AddInfor where CarID =@CarID";
            SqlCommand cmd = new SqlCommand(sqlEDIT, con);
            cmd.Parameters.AddWithValue("CarID", txtma.Text);
            cmd.Parameters.AddWithValue("ModelName", txtmodel.Text);
            cmd.Parameters.AddWithValue("Name", txtten.Text);
            cmd.Parameters.AddWithValue("Price", txtgia.Text);
            cmd.Parameters.AddWithValue("Status", txttt.Text);
            cmd.Parameters.AddWithValue("AddInfor", txtaddinf.Text);
            cmd.Parameters.AddWithValue("ManufactoryID", cbxnsxId.SelectedItem.ToString());
            cmd.ExecuteNonQuery();
            Hienthi();
            MessageBox.Show("Đã sửa thông tin xe có mã xe là: " + txtma.Text);
        }
    }
}
