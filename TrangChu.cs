﻿using MySql.Data.MySqlClient;
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
            DataLoad();
        }

        private void DataLoad()
        {
            string connectionString = "server=localhost;user=root;database=nhasach01;port=3306;password=";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT masach, tensach, tacgia, nhaxb, theloai, gia FROM db_sach";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataTable.Columns["masach"].ColumnName = "Mã sách";
                    dataTable.Columns["tensach"].ColumnName = "Tên sách";
                    dataTable.Columns["tacgia"].ColumnName = "Tác giả";
                    dataTable.Columns["nhaxb"].ColumnName = "NXB";
                    dataTable.Columns["theloai"].ColumnName = "Thể loại";
                    dataTable.Columns["gia"].ColumnName = "Giá";

                    dataGridView1.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi kết nối đến cơ sở dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn muốn đăng xuất?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

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

        private void buttonSearch_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
