using QuanLyNhaSach_Nhom4_N01;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class trangchuform : Form
    {
        public trangchuform()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void buttonBookList_Click(object sender, EventArgs e)
        {
            thongtinSach tcForm = new thongtinSach();
            tcForm.Show();

            this.Hide();
        }

        private void buttonQLTaiKhoan_Click(object sender, EventArgs e)
        {
            TaiKhoan tkForm = new TaiKhoan();
            tkForm.Show();

            // Optionally, close the current form
            this.Hide();
        }

        private void trangchuform_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn muốn đăng xuất?", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Navigate to the new form
            Formtrangchu dangnhapForm = new Formtrangchu();
            dangnhapForm.Show();

            // Optionally, close the current form
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void buttonThongKe_Click(object sender, EventArgs e)
        {
            ThongKeForm f = new ThongKeForm();
            f.Show();

            this.Hide();
        }
    }
}
