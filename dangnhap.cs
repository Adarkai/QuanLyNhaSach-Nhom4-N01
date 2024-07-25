using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp2
{
    public partial class Formtrangchu : Form
    {
        public Formtrangchu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Navigate to the new form
            trangchu dangnhaptcForm = new trangchu();
            dangnhaptcForm.Show();

            // Optionally, close the current form
            this.Hide();
        }

        private void dangnhaptxt_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dangkyBtn_Click(object sender, EventArgs e)
        {
           

            // Navigate to the new form
            
        }

        private void dangkyBtn_Click_1(object sender, EventArgs e)
        {
            FormDangky dangkyForm = new FormDangky();
            dangkyForm.Show();

            // Optionally, close the current form
            this.Hide();
        }
    }
}
