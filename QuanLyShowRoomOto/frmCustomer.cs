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
    public partial class frmCustomer : Form
    {
        public Customer customer;
        public frmCustomer()
        {
            InitializeComponent();
            customer = new Customer();
        }
        private bool KtraMa(string CustomerID)
        {
            return customer.KtraMa(CustomerID);
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
                MessageBox.Show("Mã khách hàng đã tồn tại!");
                return;
            }
            try
            {
                customer.InsertCustomer(txtma.Text, txtfiname.Text, txtlaname.Text,cbxgt.Text, dtpNs.Value, txtdiachi.Text, txtsdt.Text);
                LoadData();
                Setrong();
                MessageBox.Show("Thêm khách hàng thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm khách hàng: " + ex.Message);
            }
        }
        private bool KiemTraRong()
        {
            return string.IsNullOrWhiteSpace(txtma.Text) || string.IsNullOrWhiteSpace(txtfiname.Text) || string.IsNullOrWhiteSpace(txtlaname.Text) || string.IsNullOrWhiteSpace(txtdiachi.Text) || string.IsNullOrWhiteSpace(txtsdt.Text);
        }
        private void Setrong()
        {
            txtma.Clear();
            txtfiname.Clear();
            txtlaname.Clear();
            txtdiachi.Clear();
            txtsdt.Clear();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtma.Text))
            {
                MessageBox.Show("Vui lòng nhập mã khách hàng cần xóa!");
                return;
            }

            if (!KtraMa(txtma.Text))
            {
                MessageBox.Show("Mã khách hàng không tồn tại!");
                return;
            }
            try
            {
                customer.DeleteCustomer(txtma.Text);
                LoadData();
                Setrong();
                MessageBox.Show("Xóa khách hàng thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa khách hàng: " + ex.Message);
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            txtma.Enabled = false;
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

            if (!KtraMa(txtma.Text))
            {
                MessageBox.Show("Mã khách hàng không tồn tại!");
                return;
            }
            try
            {
                customer.UpdateCustomer(txtma.Text, txtfiname.Text, txtlaname.Text,cbxgt.Text, dtpNs.Value, txtdiachi.Text, txtsdt.Text);
                LoadData();
                Setrong();
                MessageBox.Show("Cập nhật khách hàng thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật khách hàng: " + ex.Message);
            }
            txtma.Enabled = true;
        }

        private void btnboqua_Click(object sender, EventArgs e)
        {
            pnlluu_boqua.Visible = false;
            pnlthem_sua.Visible = true;
            txtma.Enabled = true;
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
                cbxgt.Text = dgv.Rows[i].Cells[3].Value.ToString();
                dtpNs.Text = dgv.Rows[i].Cells[4].Value.ToString();
                txtdiachi.Text = dgv.Rows[i].Cells[5].Value.ToString();
                txtsdt.Text = dgv.Rows[i].Cells[6].Value.ToString();
            }
        }

        private void frmCustomer_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            dgv.DataSource = customer.GetAllCustomers();
            dgv.AutoResizeColumns();
        }

    }
}
