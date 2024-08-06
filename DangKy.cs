using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp2
{
    public partial class FormDangky : Form
    {
        public FormDangky()
        {
            InitializeComponent();
        }

        private void dangkybtn_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(hotendntxt.Text) ||
                string.IsNullOrWhiteSpace(tendnltxt.Text) ||
                string.IsNullOrWhiteSpace(emailtxt.Text) ||
                string.IsNullOrWhiteSpace(sdttxt.Text) ||
                string.IsNullOrWhiteSpace(passtxt.Text) ||
                string.IsNullOrWhiteSpace(retrypasstxt.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin của bạn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Ensure passwords match
            if (passtxt.Text != retrypasstxt.Text)
            {
                MessageBox.Show("Mật khẩu không khớp. Vui lòng thử lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Default role: 1 for User
            int role = 1;

            // Insert into database
            string connectionString = "server=localhost;user=root;database=nhasach01;port=3306;password=";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO taikhoan (hoten, tendangnhap, email, sdt, matkhau, role) VALUES (@hoten, @tendangnhap, @email, @sdt, @matkhau, @role)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@hoten", hotendntxt.Text);
                        cmd.Parameters.AddWithValue("@tendangnhap", tendnltxt.Text);
                        cmd.Parameters.AddWithValue("@email", emailtxt.Text);
                        cmd.Parameters.AddWithValue("@sdt", sdttxt.Text);
                        cmd.Parameters.AddWithValue("@matkhau", passtxt.Text);
                        cmd.Parameters.AddWithValue("@role", role);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Đăng ký thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Navigate to the new form
                    Formtrangchu dangnhapForm = new Formtrangchu();
                    dangnhapForm.Show();

                    // Optionally, close the current form
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi kết nối đến cơ sở dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void FormDangky_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Formtrangchu dangnhapForm = new Formtrangchu();
            dangnhapForm.Show();

            // Optionally, close the current form
            this.Hide();
        }
    }
}
