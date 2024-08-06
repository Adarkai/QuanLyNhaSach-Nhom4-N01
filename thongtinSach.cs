using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using WindowsFormsApp2;

namespace QuanLyNhaSach_Nhom4_N01
{
    public partial class thongtinSach : Form
    {
        public thongtinSach()
        {
            InitializeComponent();
            dataGridView1.CellClick += dataGridView1_CellContentClick;
        }

        private void thongtinSach_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                masachtxt.Text = row.Cells["Mã sách"].Value.ToString();
                tensachtxt.Text = row.Cells["Tên sách"].Value.ToString();
                tacgiatxt.Text = row.Cells["Tác giả"].Value.ToString();
                nxbtxt.Text = row.Cells["NXB"].Value.ToString();
                theloaitxt.Text = row.Cells["Thể loại"].Value.ToString();
                giatxt.Text = row.Cells["Giá"].Value.ToString();
            }
        }

        

        private void LoadData()
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

        private void masachtxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void tensachtxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void tacgiatxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void nxbtxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void theloaitxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void giatxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void thembtn_Click(object sender, EventArgs e)
        {
            string connectionString = "server=localhost;user=root;database=nhasach01;port=3306;password=";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO db_sach (masach, tensach, tacgia, nhaxb, theloai, gia) VALUES (@masach, @tensach, @tacgia, @nhaxb, @theloai, @gia)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@masach", masachtxt.Text);
                        cmd.Parameters.AddWithValue("@tensach", tensachtxt.Text);
                        cmd.Parameters.AddWithValue("@tacgia", tacgiatxt.Text);
                        cmd.Parameters.AddWithValue("@nhaxb", nxbtxt.Text);
                        cmd.Parameters.AddWithValue("@theloai", theloaitxt.Text);
                        cmd.Parameters.AddWithValue("@gia", giatxt.Text);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Thêm sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData(); // Refresh the DataGridView
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi kết nối đến cơ sở dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string connectionString = "server=localhost;user=root;database=nhasach01;port=3306;password=";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE db_sach SET tensach = @tensach, tacgia = @tacgia, nhaxb = @nhaxb, theloai = @theloai, gia = @gia WHERE masach = @masach";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@masach", masachtxt.Text);
                        cmd.Parameters.AddWithValue("@tensach", tensachtxt.Text);
                        cmd.Parameters.AddWithValue("@tacgia", tacgiatxt.Text);
                        cmd.Parameters.AddWithValue("@nhaxb", nxbtxt.Text);
                        cmd.Parameters.AddWithValue("@theloai", theloaitxt.Text);
                        cmd.Parameters.AddWithValue("@gia", giatxt.Text);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Cập nhật sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData(); // Refresh the DataGridView
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi kết nối đến cơ sở dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
               }
            }
        private void deletebtn_Click(object sender, EventArgs e)
        {
            string connectionString = "server=localhost;user=root;database=nhasach01;port=3306;password=";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "DELETE FROM db_sach WHERE masach = @masach";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@masach", masachtxt.Text);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Xóa sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData(); // Refresh the DataGridView
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi kết nối đến cơ sở dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void SearchData(string searchText)
        {
            string connectionString = "server=localhost;user=root;database=nhasach01;port=3306;password=";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT masach, tensach, tacgia, nhaxb, theloai, gia FROM db_sach WHERE masach LIKE @search OR tensach LIKE @search OR tacgia LIKE @search";
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
                            dataTable.Columns["nhaxb"].ColumnName = "NXB";
                            dataTable.Columns["theloai"].ColumnName = "Thể loại";
                            dataTable.Columns["gia"].ColumnName = "Giá";

                            dataGridView1.DataSource = dataTable;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi kết nối đến cơ sở dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void searchtxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void Searchbtn_Click(object sender, EventArgs e)
        {
            string searchText = searchtxt.Text.Trim();
            if (!string.IsNullOrEmpty(searchText))
            {
                SearchData(searchText);
            }
            else
            {
               
                LoadData();
            }
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

        private void buttonQLTaiKhoan_Click(object sender, EventArgs e)
        {
            TaiKhoan tkForm = new TaiKhoan();
            tkForm.Show();

            this.Hide();
        }

        private void backbtn_Click(object sender, EventArgs e)
        {
            trangchuform tcForm = new trangchuform();
            tcForm.Show();


            this.Hide();
        }

        private void buttonThongKe_Click(object sender, EventArgs e)
        {
            ThongKeForm f = new ThongKeForm();
            f.Show();

            this.Hide();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Formtrangchu dangnhapForm = new Formtrangchu();
            dangnhapForm.Show();
            this.Hide();
        }
    }
}
    

