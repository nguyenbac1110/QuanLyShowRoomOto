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
    public partial class frmTimKiem_a : Form
    {
        TimKiem_a tk = new TimKiem_a();
        public frmTimKiem_a()
        {
            InitializeComponent();
        }

        private void btnkq_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cbxbang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxbang.SelectedItem != null)
            {
                string selectedTable = cbxbang.SelectedItem.ToString();
                DataTable dtColumns = tk.LayDanhSachCot(selectedTable); 

                if (dtColumns != null && dtColumns.Rows.Count > 0)
                {
                    cbxcot.DataSource = dtColumns;
                    cbxcot.DisplayMember = "COLUMN_NAME";
                    cbxcot.ValueMember = "COLUMN_NAME";

                    cbxdl.DataSource = null;
                }
                else
                {
                    MessageBox.Show("Không có cột nào trong bảng đã chọn.");
                }
            }
        }

        private void cbxcot_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbxcot.SelectedValue != null)
            {
                string selectedTable = cbxbang.SelectedItem.ToString();
                string selectedColumn = string.Empty;

                if (cbxcot.SelectedItem is DataRowView selectedRow)
                {
                     selectedColumn = selectedRow["COLUMN_NAME"].ToString();
                }
                 DataTable dtData = tk.LayDuLieu(selectedTable, selectedColumn);
                if (dtData != null && dtData.Rows.Count > 0)
                {
                    cbxdl.DataSource = null;
                    cbxdl.DataSource = dtData;
                    cbxdl.DisplayMember = selectedColumn;
                    cbxdl.ValueMember = selectedColumn;
                }
               else
               {
                    MessageBox.Show("Không có dữ liệu nào cho cột đã chọn.");
               }
                
            }
        }

        private void cbxdl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxdl.SelectedItem is DataRowView selectedRow && cbxbang.SelectedItem != null && cbxcot.SelectedValue != null)
            {
                string selectedTable = cbxbang.SelectedItem.ToString();
                string selectedColumn = cbxcot.SelectedValue.ToString();
                string selectedValue = selectedRow[selectedColumn].ToString();

                try
                {
                    DataTable dtResult = tk.TimKiemDuLieu(selectedTable, selectedColumn, selectedValue);

                    if (dtResult != null && dtResult.Rows.Count > 0)
                    {
                        dgv.DataSource = dtResult;
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy kết quả nào.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi tìm kiếm: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn giá trị, bảng và cột hợp lệ.");
            }
        }

        private void frmTimKiem_a_Load(object sender, EventArgs e)
        {
           
            
        }
    }
}
