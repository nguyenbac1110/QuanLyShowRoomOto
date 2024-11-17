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
    public partial class frmManufactory : Form
    {
        private Manufactory manufactory;
        public frmManufactory()
        {
            InitializeComponent();
            manufactory = new Manufactory();
        }

        private void frmManufactory_Load(object sender, EventArgs e)
        {
            LoadData();
           
        }
        private void LoadData()
        {
            dgv.DataSource = manufactory.LayDSManufactory();
        }

        private void SetRong()
        {
            txtMa.Enabled = false;
            txtTen.Enabled = false;
            txtDiaChi.Enabled = false;
            txtSDT.Enabled = false;
            txtTTBS.Enabled = false;
        }
        private bool KtraMa(string ManufactoryID)
        {
            return manufactory.KtraMa(ManufactoryID);
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            if (KiemTraRong())
            {
                MessageBox.Show("Xin hãy vui lòng nhập đầy đủ thông tin!");
                return;
            }
            if (KtraMa(txtMa.Text))
            {
                MessageBox.Show("Mã nhà cung cấp đã tồn tại!");
                return;
            }
            try
            {
                manufactory.CreateManufactory(txtMa.Text, txtTen.Text, txtDiaChi.Text, txtSDT.Text, txtTTBS.Text);
                LoadData();
                SetRong();
                MessageBox.Show("Thêm cung cấp thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm mã nhà cung cấp: " + ex.Message);
            }
        }
        private bool KiemTraRong()
        {
            return string.IsNullOrWhiteSpace(txtMa.Text) || string.IsNullOrWhiteSpace(txtTen.Text) || string.IsNullOrWhiteSpace(txtDiaChi.Text) || string.IsNullOrWhiteSpace(txtSDT.Text) || string.IsNullOrWhiteSpace(txtTTBS.Text);
        }
        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMa.Text))
            {
                MessageBox.Show("Vui lòng nhập mã nhà cung cấp cần xóa!");
                return;
            }

            if (!KtraMa(txtMa.Text))
            {
                MessageBox.Show("Mã nhà cung cấp không tồn tại!");
                return;
            }
            try
            {
                manufactory.DeleteManufactory(txtMa.Text);
                LoadData();
                SetRong();
                MessageBox.Show("Xóa nhà cung cấp thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa nhà cung cấp: " + ex.Message);
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            txtMa.Enabled = false;
            pnlluu_boqua.Visible = true;
            pnlthem_sua.Visible = false;
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            if (KiemTraRong())
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
                return;
            }

            if (!KtraMa(txtMa.Text))
            {
                MessageBox.Show("Mã khách hàng không tồn tại!");
                return;
            }
            try
            {
                manufactory.UpdateManufactory(txtMa.Text, txtTen.Text, txtDiaChi.Text, txtSDT.Text, txtTTBS.Text);
                LoadData();
                SetRong();
                MessageBox.Show("Cập nhật khách hàng thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật khách hàng: " + ex.Message);
            }
            txtMa.Enabled = true;
        }

        private void btnboqua_Click(object sender, EventArgs e)
        {
            pnlluu_boqua.Visible = false;
            pnlthem_sua.Visible = true;
            txtMa.Enabled = true;
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
    }
}
