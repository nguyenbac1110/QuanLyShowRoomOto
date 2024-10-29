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
        public frmain(string role)
        {
            InitializeComponent();
            if (role == "Admin")
            {
               
            }
            else if (role == "Employee")
            {
               btnemployee.Visible = false;
                
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

        private void btnservice_Click(object sender, EventArgs e)
        {
            loadform(new frmService());
        }

        private void frmain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
