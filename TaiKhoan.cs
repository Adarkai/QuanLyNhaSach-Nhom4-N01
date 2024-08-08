using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using WindowsFormsApp2;

namespace QuanLyNhaSach_Nhom4_N01
{
    public partial class TaiKhoan : Form
    {
        public TaiKhoan()
        {
            InitializeComponent();
            dataGridView4.CellClick += dataGridView4_CellContentClick;
            dataGridView1.CellClick += dataGridView1_CellContentClick;
        }

        private void TaiKhoan_Load(object sender, EventArgs e)
        {
            LoadData1();
            LoadData2();
        }

        private void LoadData1()
        {
            string connectionString = "server=localhost;user=root;database=nhasach01;port=3306;password=";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT maKH, tenKH, diachi, sdt FROM khach";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataTable.Columns["maKH"].ColumnName = "Mã Khách";
                    dataTable.Columns["tenKH"].ColumnName = "Tên khách hàng";
                    dataTable.Columns["diachi"].ColumnName = "Địa chỉ";
                    dataTable.Columns["sdt"].ColumnName = "SĐT";


                    dataGridView4.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi kết nối đến cơ sở dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadData2()
        {
            string connectionString = "server=localhost;user=root;database=nhasach01;port=3306;password=";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT manv, tennv, sdt, chucvu, luong FROM nhanvien";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataTable.Columns["manv"].ColumnName = "Mã nhân viên";
                    dataTable.Columns["tennv"].ColumnName = "Tên nhân viên";
                    dataTable.Columns["sdt"].ColumnName = "SĐT";
                    dataTable.Columns["chucvu"].ColumnName = "Chức vụ";
                    dataTable.Columns["luong"].ColumnName = "Lương nhân viên";


                    dataGridView1.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi kết nối đến cơ sở dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tabPhieuNhap_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string connectionString = "server=localhost;user=root;database=nhasach01;port=3306;password=";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO khach (maKH, tenKH, diachi, sdt) VALUES (@maKH, @tenKH, @diachi, @sdt)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@maKH", textBox6.Text);
                        cmd.Parameters.AddWithValue("@tenKH", textBox8.Text);
                        cmd.Parameters.AddWithValue("@diachi", textBox2.Text);
                        cmd.Parameters.AddWithValue("@sdt", textBox7.Text);


                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Thêm thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData1(); // Refresh the DataGridView
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
                    string query = "UPDATE khach SET tenKH = @tenKH, diachi = @diachi, sdt = @sdt WHERE maKH = @maKH";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@maKH", textBox6.Text);
                        cmd.Parameters.AddWithValue("@tenKH", textBox8.Text);
                        cmd.Parameters.AddWithValue("@diachi", textBox2.Text);
                        cmd.Parameters.AddWithValue("@sdt", textBox7.Text);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData1(); // Refresh the DataGridView
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi kết nối đến cơ sở dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "server=localhost;user=root;database=nhasach01;port=3306;password=";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "DELETE FROM khach WHERE maKH = @maKH";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@maKH", textBox6.Text);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Xóa thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData1(); // Refresh the DataGridView
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi kết nối đến cơ sở dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void searchKHtxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void searchData1(string searchText)
        {
            string connectionString = "server=localhost;user=root;database=nhasach01;port=3306;password=";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT maKH, tenKH, diachi, sdt FROM khach WHERE maKH LIKE @search OR tenKH LIKE @search";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@search", "%" + searchText + "%");
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        if (dataTable.Rows.Count == 0)
                        {
                            MessageBox.Show("Không có thông tin nào trùng khớp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData1(); // Load lại dữ liệu ban đầu nếu không có kết quả tìm kiếm
                        }
                        else
                        {
                            dataTable.Columns["maKH"].ColumnName = "Mã khách hàng";
                            dataTable.Columns["tenKH"].ColumnName = "Tên khách hàng";
                            dataTable.Columns["diachi"].ColumnName = "Địa chỉ";
                            dataTable.Columns["sdt"].ColumnName = "SĐT";

                            dataGridView4.DataSource = dataTable;
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
            string searchText1 = searchKHtxt.Text.Trim();
            if (!string.IsNullOrEmpty(searchText1))
            {
                searchData1(searchText1);
            }
            else
            {
                LoadData1();
            }
        }

        private void themnvbtn_Click(object sender, EventArgs e)
        {
            string connectionString = "server=localhost;user=root;database=nhasach01;port=3306;password=";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO nhanvien (manv, tennv, sdt, chucvu, luong) VALUES (@manv, @tennv, @sdt, @chucvu, @luong)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@manv", manvtxt.Text);
                        cmd.Parameters.AddWithValue("@tennv", tennvtxt.Text);
                        cmd.Parameters.AddWithValue("@sdt", sdtnvtxt.Text);
                        cmd.Parameters.AddWithValue("@chucvu", chucvutxt.Text);
                        cmd.Parameters.AddWithValue("@luong", luongtxt.Text);


                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Thêm thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData2(); // Refresh the DataGridView
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi kết nối đến cơ sở dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void suanvbtn_Click(object sender, EventArgs e)
        {
            string connectionString = "server=localhost;user=root;database=nhasach01;port=3306;password=";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE nhanvien SET tennv = @tennv, sdt = @sdt, chucvu = @chucvu, luong = @luong WHERE manv = @manv";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@manv", manvtxt.Text);
                        cmd.Parameters.AddWithValue("@tennv", tennvtxt.Text);
                        cmd.Parameters.AddWithValue("@sdt", sdtnvtxt.Text);
                        cmd.Parameters.AddWithValue("@chucvu", chucvutxt.Text);
                        cmd.Parameters.AddWithValue("@luong", luongtxt.Text);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData2(); // Refresh the DataGridView
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi kết nối đến cơ sở dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void xoanvbtn_Click(object sender, EventArgs e)
        {
            string connectionString = "server=localhost;user=root;database=nhasach01;port=3306;password=";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "DELETE FROM nhanvien WHERE manv = @manv";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@manv", manvtxt.Text);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Xóa thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData2(); // Refresh the DataGridView
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi kết nối đến cơ sở dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void searchData2(string searchText)
        {
            string connectionString = "server=localhost;user=root;database=nhasach01;port=3306;password=";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT manv, tennv, sdt, chucvu, luong FROM nhanvien WHERE manv LIKE @search OR tennv LIKE @search";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@search", "%" + searchText + "%");
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        if (dataTable.Rows.Count == 0)
                        {
                            MessageBox.Show("Không có thông tin nào trùng khớp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData1(); // Load lại dữ liệu ban đầu nếu không có kết quả tìm kiếm
                        }
                        else
                        {
                            dataTable.Columns["manv"].ColumnName = "Mã nhân viên";
                            dataTable.Columns["tennv"].ColumnName = "Tên nhân viên";
                            dataTable.Columns["sdt"].ColumnName = "SĐT";
                            dataTable.Columns["chucvu"].ColumnName = "Chức vụ";
                            dataTable.Columns["luong"].ColumnName = "Lương";

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

        private void searchnvbtn_Click(object sender, EventArgs e)
        {
            string searchText1 = searchnvtxt.Text.Trim();
            if (!string.IsNullOrEmpty(searchText1))
            {
                searchData2(searchText1);
            }
            else
            {
                LoadData2();
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                manvtxt.Text = row.Cells["Mã nhân viên"].Value.ToString();
                tennvtxt.Text = row.Cells["Tên nhân viên"].Value.ToString();
                sdtnvtxt.Text = row.Cells["SĐT"].Value.ToString();
                chucvutxt.Text = row.Cells["Chức vụ"].Value.ToString();
                luongtxt.Text = row.Cells["Lương nhân viên"].Value.ToString();
            }
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView4.Rows[e.RowIndex];
                textBox6.Text = row.Cells["Mã Khách"].Value.ToString();
                textBox8.Text = row.Cells["Tên khách hàng"].Value.ToString();
                textBox2.Text = row.Cells["Địa chỉ"].Value.ToString();
                textBox7.Text = row.Cells["SĐT"].Value.ToString();
            }
        }

        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn muốn đăng xuất?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
        
            // Navigate to the new form
            Formtrangchu dangnhapForm = new Formtrangchu();
            dangnhapForm.Show();

            // Optionally, close the current form
            this.Close();
        }

        private void buttonBookList_Click(object sender, EventArgs e)
        {
            thongtinSach ttsForm = new thongtinSach();
            ttsForm.Show();


            this.Hide();
        }

        private void back1btn_Click(object sender, EventArgs e)
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
