using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using WindowsFormsApp2;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLyNhaSach_Nhom4_N01
{
    public partial class giohang : Form
    {
        public string TenSach { get; set; }
        public string SoLuong { get; set; }
        public string MaSach { get; set; }

        // Connection string to connect to the MySQL database
        private string connectionString = "server=localhost;user=root;database=nhasach01;port=3306;";

        public giohang()
        {
            InitializeComponent();
            LoadData(); // Load data when the form initializes
        }

        private void LoadData()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM giohang";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    giohangdtg.DataSource = dataTable; // Bind the DataTable to the DataGridView
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra khi kết nối đến cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void giohangdtg_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = giohangdtg.Rows[e.RowIndex];
                textBox1.Text = row.Cells["Mã sách"].Value.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TrangChuKhach trangChuKhachForm = new TrangChuKhach();
            trangChuKhachForm.Show();
            this.Hide();
        }

        private void SearchData(string searchText)
        {
            string connectionString = "server=localhost;user=root;database=nhasach01;port=3306;password=";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT masach, tensach,tacgia FROM giohang WHERE masach LIKE @search OR tensach LIKE @search OR tacgia LIKE @search";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@search", "%" + searchText + "%");
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        if (dataTable.Rows.Count == 0)
                        {
                            MessageBox.Show("Không có thông tin nào trùng khớp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            dataTable.Columns["masach"].ColumnName = "Mã sách";
                            dataTable.Columns["tensach"].ColumnName = "Tên sách";
                            dataTable.Columns["tacgia"].ColumnName = "Tác giả";
                            dataTable.Columns["soluong"].ColumnName = "Số lượng";
                            //dataTable.Columns["gia"].ColumnName = "Giá";

                            giohangdtg.DataSource = dataTable;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi kết nối đến cơ sở dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Searchbtn_Click(object sender, EventArgs e)
        {
            string searchText = textBox1.Text.Trim();
            if (!string.IsNullOrEmpty(searchText))
            {
                SearchData(searchText);
            }
            else
            {

                LoadData();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Bạn muốn đăng xuất?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            // Navigate to the new form
            Formtrangchu dangnhapForm = new Formtrangchu();
            dangnhapForm.Show();

            // Optionally, close the current form
            this.Hide();
        }

        private void buttonThanhToan_Click(object sender, EventArgs e)
        {
            formdathang f= new formdathang();
            f.Show();
            // Hide the current form
            this.Hide();
        }

        private void giohang_Load(object sender, EventArgs e)
        {

        }
    }
}
