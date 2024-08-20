using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace QuanLyNhaSach_Nhom4_N01
{
    public partial class formdathang : Form
    {
        // Properties to receive data from previous form
        public string TenSach { get; set; }
        public string SoLuong { get; set; }

        // Connection string to connect to the MySQL database
        private string connectionString = "server=localhost;user=root;database=nhasach01;port=3306";

        public formdathang()
        {
            InitializeComponent();
        }

        // Load event to populate text boxes with the selected data
        private void formdathang_Load(object sender, EventArgs e)
        {
            Sanphamtxt.Text = TenSach;
            soluongtxt.Text = SoLuong;
        }

        // Event handler for the "Trở lại" button
        private void button1_Click(object sender, EventArgs e)
        {
            TrangChuKhach trangChuKhachForm = new TrangChuKhach();
            trangChuKhachForm.Show();
            this.Hide();
        }

        // Event handler for the "Đặt hàng" button
        private void dathangbtn_Click(object sender, EventArgs e)
        {
            // Get the input values from the text boxes
            string tenKH = tenKHtxt.Text.Trim();
            string diachi = diachitxt.Text.Trim();
            string sdt = sdttxt.Text.Trim();
            string tensach = Sanphamtxt.Text.Trim();
            string soLuong = soluongtxt.Text.Trim();
            string maKH, masach;

            // Check if any of the required fields are empty
            if (string.IsNullOrEmpty(tenKH) || string.IsNullOrEmpty(diachi) || string.IsNullOrEmpty(sdt) || string.IsNullOrEmpty(tensach) || string.IsNullOrEmpty(soLuong))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Establish connection to the database
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // SQL query to insert data into the donhang table
                    string query = "INSERT INTO donhang (hoten, diachi, sdt, tensach, soluong) VALUES (@tenKH, @diachi, @sdt, @tensach, @soLuong)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        // Add parameters to the SQL query
                        cmd.Parameters.AddWithValue("@tenKH", tenKH);
                        cmd.Parameters.AddWithValue("@diaChi", diachi);
                        cmd.Parameters.AddWithValue("@sdt", sdt);
                        cmd.Parameters.AddWithValue("@masach", tensach);
                        cmd.Parameters.AddWithValue("@soLuong", soLuong);

                        // Execute the query to insert data
                        cmd.ExecuteNonQuery();
                    }
                    string query1 = "INSERT INTO donhang (maKH, masach) SELECT kh.maKH, s.masach FROM donhang d INNER JOIN khach kh ON d.tenKH = kh.tenKH INNER JOIN dbsach s ON d.tensach = s.tensach;";
                    using (MySqlCommand cmd = new MySqlCommand(query1, conn))
                    {
                        // Execute the query to insert data
                        //cmd.Parameters.AddWithValue("@maKH", maKH);
                        //cmd.Parameters.AddWithValue("@masach", masach);
                        cmd.ExecuteNonQuery();
                    }
                }

                // Show a success message
                MessageBox.Show("Đặt hàng thành công! Vui lòng kiểm tra giỏ hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Navigate back to the TrangChuKhach form
                TrangChuKhach trangChuKhachForm = new TrangChuKhach();
                trangChuKhachForm.Show();

                // Hide the current form
                this.Hide();
            }
            catch (Exception ex)
            {
                // Show an error message if something goes wrong
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void totalPriceDisplay_Click(object sender, EventArgs e)
        {

        }
    }
}
