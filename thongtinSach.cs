using System;
using System.Data;
using System.Drawing;
using System.IO;
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
            dataGridView1.DataError += dataGridView1_DataError;
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            
            MessageBox.Show("Hãy thêm ảnh.", " hiển thị", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            e.ThrowException = false; 
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
                soluongtxt.Text = row.Cells["soluong"].Value.ToString();
                theloaitxt.Text = row.Cells["Thể loại"].Value.ToString();
                giatxt.Text = row.Cells["Giá"].Value.ToString();

                // Kiểm tra và hiển thị hình ảnh trong PictureBox nếu có
                if (row.Cells["images"].Value != DBNull.Value)
                {
                    byte[] imageData = row.Cells["images"].Value as byte[];
                    if (imageData != null && imageData.Length > 0)
                    {
                        try
                        {
                            using (MemoryStream ms = new MemoryStream(imageData))
                            {
                                pictureBox1.Image = Image.FromStream(ms);
                                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                            }
                        }
                        catch (ArgumentException ex)
                        {
                            MessageBox.Show($"Lỗi khi hiển thị hình ảnh (ArgumentException): {ex.Message}", "Lỗi hiển thị", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            pictureBox1.Image = null;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Lỗi không xác định khi hiển thị hình ảnh: {ex.Message}", "Lỗi hiển thị", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            pictureBox1.Image = null;
                        }
                    }
                    else
                    {
                        pictureBox1.Image = null;
                    }
                }
                else
                {
                    pictureBox1.Image = null;
                }
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
                    string query = "SELECT masach, tensach, tacgia, nhaxb, soluong, theloai, gia, images FROM db_sach";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataTable.Columns["masach"].ColumnName = "Mã sách";
                    dataTable.Columns["tensach"].ColumnName = "Tên sách";
                    dataTable.Columns["tacgia"].ColumnName = "Tác giả";
                    dataTable.Columns["nhaxb"].ColumnName = "NXB";
                    dataTable.Columns["soluong"].ColumnName = "Số lượng";
                    dataTable.Columns["theloai"].ColumnName = "Thể loại";
                    dataTable.Columns["gia"].ColumnName = "Giá";

                    dataGridView1.DataSource = dataTable;

                    // Điều chỉnh hiển thị cho cột hình ảnh trong DataGridView
                    if (dataGridView1.Columns["images"] is DataGridViewImageColumn)
                    {
                        ((DataGridViewImageColumn)dataGridView1.Columns["images"]).ImageLayout = DataGridViewImageCellLayout.Stretch;
                    }
                    else
                    {
                        DataGridViewImageColumn imgCol = new DataGridViewImageColumn();
                        imgCol.Name = "images";
                        imgCol.HeaderText = "images";
                        imgCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
                        dataGridView1.Columns.Add(imgCol);
                    }
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
                    string query = "INSERT INTO db_sach (masach, tensach, tacgia, nhaxb, soluong, theloai, gia) VALUES (@masach, @tensach, @tacgia, @nhaxb, @theloai, @gia)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@masach", masachtxt.Text);
                        cmd.Parameters.AddWithValue("@tensach", tensachtxt.Text);
                        cmd.Parameters.AddWithValue("@tacgia", tacgiatxt.Text);
                        cmd.Parameters.AddWithValue("@nhaxb", nxbtxt.Text);
                        cmd.Parameters.AddWithValue("@soluong", soluongtxt.Text);
                        cmd.Parameters.AddWithValue("@theloai", theloaitxt.Text);
                        cmd.Parameters.AddWithValue("@gia", giatxt.Text);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Thêm sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
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
                    string query = "UPDATE db_sach SET tensach = @tensach, tacgia = @tacgia, nhaxb = @nhaxb,soluong = @soluong, theloai = @theloai, gia = @gia WHERE masach = @masach";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@masach", masachtxt.Text);
                        cmd.Parameters.AddWithValue("@tensach", tensachtxt.Text);
                        cmd.Parameters.AddWithValue("@tacgia", tacgiatxt.Text);
                        cmd.Parameters.AddWithValue("@nhaxb", nxbtxt.Text);
                        cmd.Parameters.AddWithValue("soluong", soluongtxt.Text);
                        cmd.Parameters.AddWithValue("@theloai", theloaitxt.Text);
                        cmd.Parameters.AddWithValue("@gia", giatxt.Text);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Cập nhật sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
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
                    LoadData();
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
                    string query = "SELECT masach, tensach, tacgia, nhaxb, soluong, theloai, gia, images FROM db_sach WHERE masach LIKE @search OR tensach LIKE @search OR tacgia LIKE @search";
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
                            dataTable.Columns["soluong"].ColumnName = "Số lượng";
                            dataTable.Columns["theloai"].ColumnName = "Thể loại";
                            dataTable.Columns["gia"].ColumnName = "Giá";

                            dataGridView1.DataSource = dataTable;

                            // Điều chỉnh hiển thị cho cột hình ảnh trong DataGridView
                            if (dataGridView1.Columns["images"] is DataGridViewImageColumn)
                            {
                                ((DataGridViewImageColumn)dataGridView1.Columns["images"]).ImageLayout = DataGridViewImageCellLayout.Stretch;
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

        private void searchtxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void Searchbtn_Click(object sender, EventArgs e)
        {
            string searchText = masachtxt.Text.Trim();
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
            MessageBox.Show("Bạn muốn đăng xuất?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

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

        private void anhbtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                openFileDialog.Title = "Chọn một hình ảnh";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Lấy đường dẫn tệp ảnh đã chọn
                    string filePath = openFileDialog.FileName;

                    // Đọc ảnh thành mảng byte
                    byte[] imageData = File.ReadAllBytes(filePath);

                    // Lưu ảnh vào cơ sở dữ liệu
                    string connectionString = "server=localhost;user=root;database=nhasach01;port=3306;password=";
                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        try
                        {
                            conn.Open();
                            string query = "UPDATE db_sach SET images = @images WHERE masach = @masach";
                            using (MySqlCommand cmd = new MySqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@images", imageData);
                                cmd.Parameters.AddWithValue("@masach", masachtxt.Text);

                                cmd.ExecuteNonQuery();
                            }

                            MessageBox.Show("Cập nhật ảnh thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Lỗi khi kết nối đến cơ sở dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void buttonTTDonHang_Click(object sender, EventArgs e)
        {
            TTDonHang f = new TTDonHang();
            f.Show();

            this.Hide();
        }
    }
}
    

