using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using COMExcel = Microsoft.Office.Interop.Excel;
namespace QuanLyShowRoomOto
{
    public partial class frmOrder : Form
    {
        public frmOrder()
        {
            InitializeComponent();
            LoadDataGridView();
        }
        private Order order = new Order();

        private void btnthem_Click(object sender, EventArgs e)
        {
            btnhuy.Enabled = true;
            btnluu.Enabled = true;
            btnin.Enabled = true;
            if (int.TryParse(txtsl.Text, out int quantity) && float.TryParse(txtgiatien.Text, out float price))
            {
                float totalPrice = quantity * price; 
                dgv.Rows.Add(cbxmaxe.SelectedValue, txttenxe.Text, quantity, totalPrice);
                CapNhapThanhTien();
            }
            else
            {
                MessageBox.Show("Số lượng hoặc giá tiền không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CapNhapThanhTien()
        {
            float total = dgv.Rows.Cast<DataGridViewRow>().Sum(row => Convert.ToSingle(row.Cells[3].Value)); 
            txttongtien.Text = total.ToString("F2");
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            string orderId = txtmadonhang.Text;
            string customerId = cbxmakhachhang.SelectedValue.ToString();
            string employeeId = cbxmanhanvien.SelectedValue.ToString();
            DateTime date = dtpngaytao.Value;
            string request = txtyeucau.Text;
            decimal total = 0;
            if (!decimal.TryParse(txttongtien.Text, out total))
            {
                MessageBox.Show("Giá trị tổng tiền không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            order.AddOrder(orderId, customerId, employeeId, date, request, total);

            foreach (DataGridViewRow row in dgv.Rows)
            {
                string carId = row.Cells[0].Value.ToString(); 
                int quantity = Convert.ToInt32(row.Cells[2].Value); 
                decimal price = Convert.ToDecimal(row.Cells[3].Value); 
                order.AddOrderDetail(orderId, carId, quantity, price);
            }

            MessageBox.Show("Thêm đơn hàng thành công!");
        }

        private void btnhuy_Click(object sender, EventArgs e)
        {
            btnthem.Enabled = false;
            btnin.Enabled = false;
            dgv.Rows.Clear();
        }

        private void btnin_Click(object sender, EventArgs e)
        {
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            COMExcel.Worksheet exSheet = exBook.Worksheets[1];
            COMExcel.Range exRange;

            exRange = exSheet.Cells[1, 1];
            exRange.Range["A1:D1"].MergeCells = true;
            exRange.Range["A1:D1"].Font.Size = 16;
            exRange.Range["A1:D1"].Font.Bold = true;
            exRange.Range["A1:D1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A1:D1"].Value = "HÓA ĐƠN BÁN HÀNG";

            exRange.Range["A2"].Value = "Khách hàng: " + cbxmakhachhang.Text;
            exRange.Range["A3"].Value = "Nhân viên: " + cbxmanhanvien.Text;
            exRange.Range["A4"].Value = "Ngày: " + dtpngaytao.Value.ToString("dd/MM/yyyy");

            exRange.Range["A6"].Value = "Mã xe";
            exRange.Range["B6"].Value = "Tên xe";
            exRange.Range["C6"].Value = "Số lượng";
            exRange.Range["D6"].Value = "Thành tiền";
            exRange.Range["A6:D6"].Font.Bold = true;
            exRange.Range["A6:D6"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;

            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                exSheet.Cells[i + 7, 1] = dgv.Rows[i].Cells[0].Value; 
                exSheet.Cells[i + 7, 2] = dgv.Rows[i].Cells[1].Value; 
                exSheet.Cells[i + 7, 3] = dgv.Rows[i].Cells[2].Value; 
                exSheet.Cells[i + 7, 4] = dgv.Rows[i].Cells[3].Value; 
            }

            exRange = exSheet.Cells[dgv.Rows.Count + 8, 3];
            exRange.Font.Bold = true;
            exRange.Value = "Tổng tiền:";
            exRange = exSheet.Cells[dgv.Rows.Count + 8, 4];
            exRange.Font.Bold = true;
            exRange.Value = txttongtien.Text;

            exSheet.Columns["A:D"].AutoFit();

            exApp.Visible = true;
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {

        }

        private void frmOrder_Load(object sender, EventArgs e)
        {
            cbxmakhachhang.DataSource = order.GetCustomers();
            cbxmakhachhang.DisplayMember = "CustomerName";
            cbxmakhachhang.ValueMember = "CustomerID";

            cbxmanhanvien.DataSource = order.GetEmployees();
            cbxmanhanvien.DisplayMember = "EmployeeName";
            cbxmanhanvien.ValueMember = "EmployeeID";

            cbxmaxe.DataSource = order.GetCars();
            cbxmaxe.DisplayMember = "CarID";
            cbxmaxe.ValueMember = "CarID";
        }

        private void cbxmaxe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxmaxe.SelectedValue != null)
            {
                if (cbxmaxe.SelectedValue is int selectedCarID)
                {
                    CarInfo carInfo = order.GetCarInfoByID(selectedCarID);
                    if (carInfo != null)
                    {
                        txttenxe.Text = carInfo.Name;
                        txtgiatien.Text = carInfo.Price.ToString("F2"); 
                    }
                }
                else if (cbxmaxe.SelectedValue is DataRowView rowView)
                {
                    selectedCarID = Convert.ToInt32(rowView["CarID"]);
                    CarInfo carInfo = order.GetCarInfoByID(selectedCarID);
                    if (carInfo != null)
                    {
                        txttenxe.Text = carInfo.Name;
                        txtgiatien.Text = carInfo.Price.ToString("F2");
                    }
                }
            }
        }
        private void LoadDataGridView()
        {
            dgv.Columns.Clear(); 

            dgv.Columns.Add("Mã xe", "Mã xe");
            dgv.Columns.Add("Tên xe", "Tên xe");
            dgv.Columns.Add("Số lượng", "Số lượng");
            dgv.Columns.Add("Thành tiền", "Thành Tiền");

            dgv.Columns[0].Width = 100;
            dgv.Columns[1].Width = 100;
            dgv.Columns[2].Width = 100;
            dgv.Columns[3].Width = 100;
            dgv.AllowUserToAddRows = false;
            dgv.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
