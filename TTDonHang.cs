using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2;

namespace QuanLyNhaSach_Nhom4_N01
{
    public partial class TTDonHang : Form
    {
        public TTDonHang()
        {
            InitializeComponent();
        }

        private void TTDonHang_Load(object sender, EventArgs e)
        {

        }

        private void backbtn_Click(object sender, EventArgs e)
        {
            trangchuform tcForm = new trangchuform();
            tcForm.Show();


            this.Hide();
        }
    }
}
