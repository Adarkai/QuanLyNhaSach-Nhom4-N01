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
    public partial class TTDHKhach : Form
    {
        public TTDHKhach()
        {
            InitializeComponent();
        }

        private void TTDHKhach_Load(object sender, EventArgs e)
        {

        }

        private void backbtn_Click(object sender, EventArgs e)
        {
            TrangChuKhach tcForm = new TrangChuKhach();
            tcForm.Show();


            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
