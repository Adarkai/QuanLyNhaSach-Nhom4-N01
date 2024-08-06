using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using WindowsFormsApp2;

namespace QuanLyNhaSach_Nhom4_N01
{
    public partial class ThongKeForm : Form
    {
        public ThongKeForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadDataHoaDon();
            LoadDataPhieuXuat();
            LoadDataPhieuNhap();
        }

        private void LoadDataHoaDon()
        {
            string connectionString = "server=localhost;user=root;database=nhasach01;port=3306;password=";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT maHD, masach, ngaylap, dongia FROM hoadon";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataTable.Columns["maHD"].ColumnName = "Mã hóa đơn";
                    dataTable.Columns["masach"].ColumnName = "Mã sách";
                    dataTable.Columns["ngaylap"].ColumnName = "Ngày lập";
                    dataTable.Columns["dongia"].ColumnName = "Đơn giá";


                    dataGridView3.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi kết nối đến cơ sở dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void LoadDataPhieuXuat()
        {
            string connectionString = "server=localhost;user=root;database=nhasach01;port=3306;password=";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT maphieuxuat, masach, ngaytao, soluong, dongia FROM phieuxuat";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataTable.Columns["maphieuxuat"].ColumnName = "Mã phiếu xuất";
                    dataTable.Columns["masach"].ColumnName = "Mã sách";
                    dataTable.Columns["soluong"].ColumnName = "Số lượng";
                    dataTable.Columns["ngaytao"].ColumnName = "Ngày lập";
                    dataTable.Columns["dongia"].ColumnName = "Đơn giá";


                    dataGridView1.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi kết nối đến cơ sở dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void LoadDataPhieuNhap()
        {
            string connectionString = "server=localhost;user=root;database=nhasach01;port=3306;password=";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT maphieunhap, masach, ngaytao, soluong, dongia FROM phieunhap";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataTable.Columns["maphieunhap"].ColumnName = "Mã phiếu nhập";
                    dataTable.Columns["masach"].ColumnName = "Mã sách";
                    dataTable.Columns["soluong"].ColumnName = "Số lượng";
                    dataTable.Columns["ngaytao"].ColumnName = "Ngày lập";
                    dataTable.Columns["dongia"].ColumnName = "Đơn giá";


                    dataGridView1.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi kết nối đến cơ sở dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void buttonThongKe_Click(object sender, EventArgs e)
        {

        }

        private void buttonTonKho_Click(object sender, EventArgs e)
        {

        }

        private void buttonBanChay_Click(object sender, EventArgs e)
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

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void buttonBookList_Click(object sender, EventArgs e)
        {
            thongtinSach ttsForm = new thongtinSach();
            ttsForm.Show();


            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }


        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void tabPhieuNhap_Click(object sender, EventArgs e)
        {

        }

        private void tabPhieuXuat_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void buttonThongKe_Click_1(object sender, EventArgs e)
        {

        }

        private void buttonTonKho_Click_1(object sender, EventArgs e)
        {

        }

        private void buttonBanChay_Click_1(object sender, EventArgs e)
        {

        }

        private void buttonQLTaiKhoan_Click(object sender, EventArgs e)
        {
            TaiKhoan tkForm = new TaiKhoan();
            tkForm.Show();

            this.Hide();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //13-10-11-9
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView3.Rows[e.RowIndex];
                textBox13.Text = row.Cells["Mã sách"].Value.ToString();
                textBox11.Text = row.Cells["Ngày lập"].Value.ToString();
                textBox10.Text = row.Cells["Số lượng"].Value.ToString();
                textBox9.Text = row.Cells["Đơn giá"].Value.ToString();

            }
        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView3.Rows[e.RowIndex];
                textBox1.Text = row.Cells["Mã sách"].Value.ToString();
                textBox3.Text = row.Cells["Ngày lập"].Value.ToString();
                textBox4.Text = row.Cells["Đơn giá"].Value.ToString();

            }
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonNewHoadDon_Click(object sender, EventArgs e)
        {
            string connectionString = "server=localhost;user=root;database=nhasach01;port=3306;password=";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO hoadon (masach, ngaylap, dongia) VALUES (@masach, @ngaylap, @dongia)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        //1-3-4
                        cmd.Parameters.AddWithValue("@masach", textBox1.Text);
                        cmd.Parameters.AddWithValue("@tensach", textBox3.Text);
                        cmd.Parameters.AddWithValue("@dongia", textBox4.Text);


                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Thêm hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataHoaDon(); // Refresh the DataGridView
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi kết nối đến cơ sở dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonNewPhieuNhap_Click(object sender, EventArgs e)
        {
            string connectionString = "server=localhost;user=root;database=nhasach01;port=3306;password=";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO phieunhap (masach, ngaytao, soluong,dongia) VALUES (@masach, @ngaytao, @soluong,@dongia)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        //6-2-8-7
                        cmd.Parameters.AddWithValue("@masach", textBox6.Text);
                        cmd.Parameters.AddWithValue("@ngaytao", textBox2.Text);
                        cmd.Parameters.AddWithValue("@soluong", textBox8.Text);
                        cmd.Parameters.AddWithValue("@dongia", textBox7.Text);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Thêm phiếu nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataPhieuNhap(); // Refresh the DataGridView
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi kết nối đến cơ sở dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonNewPhieuXuat_Click(object sender, EventArgs e)
        {
            string connectionString = "server=localhost;user=root;database=nhasach01;port=3306;password=";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO phieuxuat (masach, ngaytao, soluong,dongia) VALUES (@masach, @ngaytao, @soluong,@dongia)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        //6-2-8-7
                        cmd.Parameters.AddWithValue("@masach", textBox6.Text);
                        cmd.Parameters.AddWithValue("@ngaytao", textBox2.Text);
                        cmd.Parameters.AddWithValue("@soluong", textBox8.Text);
                        cmd.Parameters.AddWithValue("@dongia", textBox7.Text);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Thêm phiếu xuất thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataPhieuNhap(); // Refresh the DataGridView
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi kết nối đến cơ sở dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
