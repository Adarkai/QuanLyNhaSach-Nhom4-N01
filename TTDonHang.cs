using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2;

namespace QuanLyNhaSach_Nhom4_N01
{
    public partial class TTDonHang : Form
    {
        public TTDonHang()
        {
            InitializeComponent();
        }

        private void TTDonHang_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void backbtn_Click(object sender, EventArgs e)
        {
            trangchuform tcForm = new trangchuform();
            tcForm.Show();
            this.Hide();
        }
        private void LoadData()
        {
            string connectionString = "server=localhost;user=root;database=nhasach01;port=3306;password=";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT madon,tenKH,tensach, soluong,diachi, sdt,trangthai,ghicu FROM donhang";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataTable.Columns["madon"].ColumnName = "Mã đơn";
                    dataTable.Columns["tenKH"].ColumnName = "Tên khách hàng";
                    dataTable.Columns["diachi"].ColumnName = "Địa chỉ";
                    dataTable.Columns["sdt"].ColumnName = "SĐT";
                    dataTable.Columns["tensach"].ColumnName = "Tên sách";
                    dataTable.Columns["soluong"].ColumnName = "Số lượng";
                    dataTable.Columns["trangthai"].ColumnName = "Trạng thái đơn";
                    dataTable.Columns["ghichu"].ColumnName = "Ghi chú";

                    dataGridView1.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi kết nối đến cơ sở dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonThongKe_Click(object sender, EventArgs e)
        {
            ThongKeForm f = new ThongKeForm();
            f.Show();

            this.Hide();
        }

        private void buttonQLTaiKhoan_Click(object sender, EventArgs e)
        {
            TaiKhoan tkForm = new TaiKhoan();
            tkForm.Show();

            // Optionally, close the current form
            this.Hide();
        }

        private void buttonBookList_Click(object sender, EventArgs e)
        {
            thongtinSach tcForm = new thongtinSach();
            tcForm.Show();

            this.Hide();
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells["Mã đơn"].Value.ToString();
                textBox2.Text = row.Cells["Trạng thái"].Value.ToString();
                textBox3.Text = row.Cells["Ghi chú"].Value.ToString();

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
                LoadData();
            }

        }
        private void SearchData(string searchText)
        {
            string connectionString = "server=localhost;user=root;database=nhasach01;port=3306;password=";
            using (MySqlConnection conn = new MySqlConnection(connectionString))

                try
                {
                    conn.Open();
                    string query = "SELECT madon,tenKH,tensach, soluong,diachi, sdt,trangthai,ghichu FROM donhang WHERE madon LIKE @search";
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
                            dataTable.Columns["madon"].ColumnName = "Mã đơn";
                            dataTable.Columns["tenKH"].ColumnName = "Tên khách hàng";
                            dataTable.Columns["diachi"].ColumnName = "Địa chỉ";
                            dataTable.Columns["sdt"].ColumnName = "SĐT";
                            dataTable.Columns["tensach"].ColumnName = "Tên sách";
                            dataTable.Columns["soluong"].ColumnName = "Số lượng";
                            dataTable.Columns["trangthai"].ColumnName = "Trạng thái đơn";
                            dataTable.Columns["ghichu"].ColumnName = "Ghi chú";

                            dataGridView1.DataSource = dataTable;
                        }
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi kết nối đến cơ sở dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

