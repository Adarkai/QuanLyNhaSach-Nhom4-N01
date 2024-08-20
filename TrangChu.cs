using MySql.Data.MySqlClient;
using QuanLyNhaSach_Nhom4_N01;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class trangchuform : Form
    {
        private List<PictureBox> pictureBoxes = new List<PictureBox>();
        public trangchuform()
        {
            InitializeComponent();
            pictureBoxes.Add(pictureBox2);
            pictureBoxes.Add(pictureBox3);
            pictureBoxes.Add(pictureBox4);
            pictureBoxes.Add(pictureBox5);
            pictureBoxes.Add(pictureBox6);
            pictureBoxes.Add(pictureBox7);
            pictureBoxes.Add(pictureBox8);
            pictureBoxes.Add(pictureBox9);
            pictureBoxes.Add(pictureBox10);
            pictureBoxes.Add(pictureBox11);
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
                    string query = "SELECT masach, tensach, tacgia, nhaxb, soluong, theloai, gia, images FROM db_sach";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Gán dữ liệu cho các PictureBox từ pictureBox3 đến pictureBox12
                    for (int i = 0; i < pictureBoxes.Count && i < dataTable.Rows.Count; i++)
                    {
                        DataRow row = dataTable.Rows[i];
                        pictureBoxes[i].Tag = row; // Lưu dòng dữ liệu vào Tag của PictureBox

                        byte[] imageData = row["images"] as byte[];
                        if (imageData != null && imageData.Length > 0)
                        {
                            using (MemoryStream ms = new MemoryStream(imageData))
                            {
                                pictureBoxes[i].Image = Image.FromStream(ms);
                                pictureBoxes[i].SizeMode = PictureBoxSizeMode.StretchImage;
                            }
                        }

                        pictureBoxes[i].Click -= PictureBox_Click; // Đảm bảo không gán sự kiện nhiều lần
                        pictureBoxes[i].Click += PictureBox_Click; // Gán sự kiện Click cho PictureBox
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi kết nối đến cơ sở dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            DataRow bookRow = pb.Tag as DataRow;

            if (bookRow != null)
            {
                // Hiển thị thông tin sách trong DataGridView
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("Mã sách");
                dataTable.Columns.Add("Tên sách");
                dataTable.Columns.Add("Tác giả");
                dataTable.Columns.Add("NXB");
                dataTable.Columns.Add("Số lượng");
                dataTable.Columns.Add("Thể loại");
                dataTable.Columns.Add("Giá");

                DataRow row = dataTable.NewRow();
                row["Mã sách"] = bookRow["masach"];
                row["Tên sách"] = bookRow["tensach"];
                row["Tác giả"] = bookRow["tacgia"];
                row["NXB"] = bookRow["nhaxb"];
                row["Số lượng"] = bookRow["soluong"];
                row["Thể loại"] = bookRow["theloai"];
                row["Giá"] = bookRow["gia"];
                dataTable.Rows.Add(row);

                dataGridView1.DataSource = dataTable;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn muốn đăng xuất?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            // Navigate to the new form
            Formtrangchu dangnhapForm = new Formtrangchu();
            dangnhapForm.Show();

            // Optionally, close the current form
            this.Hide();
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
         private void SearchData(string searchText)
        {
            string connectionString = "server=localhost;user=root;database=nhasach01;port=3306;password=";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT masach, tensach, tacgia, nhaxb, soluong, theloai, gia FROM db_sach WHERE masach LIKE @search OR tensach LIKE @search OR tacgia LIKE @search";
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
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi kết nối đến cơ sở dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string searchText = textBox1.Text.Trim();
            if (!string.IsNullOrEmpty(searchText))
            {
                SearchData(searchText);
            }
            else
            {
               
                DataLoad();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonTTDonHang_Click(object sender, EventArgs e)
        {
            TTDonHang f = new TTDonHang();
            f.Show();

            this.Hide();
        }
    }
}
