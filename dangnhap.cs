using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using QuanLyNhaSach_Nhom4_N01;

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
            if (string.IsNullOrWhiteSpace(taikhoantxt.Text) ||
                string.IsNullOrWhiteSpace(matkhautxt.Text))
            {
                MessageBox.Show("Vui lòng nhập tài khoản và mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check credentials in the database
            string connectionString = "server=localhost;user=root;database=nhasach01;port=3306;password=";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT role, tendangnhap FROM taikhoan WHERE tendangnhap = @tendangnhap AND matkhau = @matkhau";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@tendangnhap", taikhoantxt.Text);
                        cmd.Parameters.AddWithValue("@matkhau", matkhautxt.Text);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int role = reader.GetInt32("role");
                                string tendangnhap = reader.GetString("tendangnhap");

                                if (role == 0)
                                {
                                    MessageBox.Show("Chào mừng admin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    // Navigate to the Admin form
                                    trangchuform adminForm = new trangchuform();
                                    adminForm.Show();
                                }
                                else
                                {
                                    MessageBox.Show($"Chào mừng {tendangnhap}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    // Navigate to the User form
                                    TrangChuKhach userForm = new TrangChuKhach();
                                    userForm.Show();
                                }

                                // Optionally, close the current form
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Sai tài khoản hoặc mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi kết nối đến cơ sở dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dangnhaptxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dangkyBtn_Click(object sender, EventArgs e)
        {

        }

        private void dangkyBtn_Click_1(object sender, EventArgs e)
        {
            FormDangky dangkyForm = new FormDangky();
            dangkyForm.Show();

            // Optionally, close the current form
            this.Hide();
        }

        private void Formtrangchu_Load(object sender, EventArgs e)
        {

        }
    }
}
