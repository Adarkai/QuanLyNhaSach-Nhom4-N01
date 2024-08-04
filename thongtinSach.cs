﻿using System;
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
    public partial class thongtinSach : Form
    {
        public thongtinSach()
        {
            InitializeComponent();
        }

        private void thongtinSach_Load(object sender, EventArgs e)
        {

        }

        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn muốn đăng xuất?", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Navigate to the new form
            Formtrangchu dangnhapForm = new Formtrangchu();
            dangnhapForm.Show();

            // Optionally, close the current form
            this.Close();
        }

        private void buttonMainPage_Click(object sender, EventArgs e)
        {
            // Navigate to the new form
            trangchuform f = new trangchuform();
            f.Show();

            // Optionally, close the current form
            this.Close();
        }

        private void buttonQLTaiKhoan_Click(object sender, EventArgs e)
        {
            // Navigate to the new form
            TaiKhoan f = new TaiKhoan();
            f.Show();

            // Optionally, close the current form
            this.Close();
        }

        private void buttonBookList_Click(object sender, EventArgs e)
        {
            // Navigate to the new form
            thongtinSach f = new thongtinSach();
            f.Show();

            // Optionally, close the current form
            this.Close();
        }
    }
}
