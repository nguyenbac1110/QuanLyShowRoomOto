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
        private Car car;
        public frmCar()
        {
            InitializeComponent();
            car = new Car();
        }
        private void frmCar_Load(object sender, EventArgs e)
        {
            HienThiXe();
            LoadManufactoryID();
        }
        private void HienThiXe()
        {
            dgv.DataSource = car.LayDSXe();
            dgv.AutoResizeColumns();
        }
        public void LoadManufactoryID()
        {
            cbxnsxId.Items.Clear();
            DataTable dt = car.Load_ManufactoryID();
            foreach (DataRow row in dt.Rows)
            {
                cbxnsxId.Items.Add(row["ManufactoryID"].ToString());
            }
            cbxnsxId.SelectedIndex = 0;
        }
        private bool KtraMa(string carID)
        {
            return car.KtraMa(carID);
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
            if (KiemTraRong())
            {
                MessageBox.Show("Xin hãy vui lòng nhập đầy đủ thông tin!");
                return;
            }
            if (KtraMa(txtma.Text))
            {
                MessageBox.Show("Mã xe đã tồn tại!");
                return;
            }
            try
            {
                car.CreateCar(txtma.Text, txtmodel.Text, txtten.Text, decimal.Parse(txtgia.Text), txttt.Text, txtaddinf.Text, cbxnsxId.Text);
                HienThiXe();
                Setrong();
                MessageBox.Show("Thêm xe thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm xe: " + ex.Message);
            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtma.Text))
            {
                MessageBox.Show("Vui lòng nhập mã xe cần xóa!");
                return;
            }

            if (!KtraMa(txtma.Text))
            {
                MessageBox.Show("Mã xe không tồn tại!");
                return;
            }

            try
            {
                car.DeleteCar(txtma.Text);
                HienThiXe();
                Setrong();
                MessageBox.Show("Xóa xe thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa xe: " + ex.Message);
            }
        }
        private void btnsua_Click(object sender, EventArgs e)
        {
            txtma.Enabled = false;
            pnlluu_boqua.Visible = true;
            pnlthem_sua.Visible = false;
        }

        private void btnboqua_Click(object sender, EventArgs e)
        {
            pnlluu_boqua.Visible = false;
            pnlthem_sua.Visible = true;
            txtma.Enabled = true;

        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            if (KiemTraRong())
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
                return;
            }

            if (!KtraMa(txtma.Text))
            {
                MessageBox.Show("Mã xe không tồn tại!");
                return;
            }
            try
            {
                car.UpdateCar(txtma.Text, txtmodel.Text, txtten.Text, decimal.Parse(txtgia.Text), txttt.Text, txtaddinf.Text, cbxnsxId.Text);
                HienThiXe();
                Setrong();
                MessageBox.Show("Cập nhật xe thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật xe: " + ex.Message);
            }
            txtma.Enabled = true;

        }
        private bool KiemTraRong()
        {
            return string.IsNullOrWhiteSpace(txtma.Text) || string.IsNullOrWhiteSpace(txtmodel.Text) || string.IsNullOrWhiteSpace(txtgia.Text) || string.IsNullOrWhiteSpace(txttt.Text) || string.IsNullOrWhiteSpace(txtaddinf.Text);
        }

        private void Setrong()
        {
            txtma.Clear();
            txtmodel.Clear();
            txtgia.Clear();
            txttt.Clear();
            txtaddinf.Clear();
            txtten.Clear();
        }
    }
}
