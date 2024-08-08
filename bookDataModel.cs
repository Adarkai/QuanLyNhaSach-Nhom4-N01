using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaSach_Nhom4_N01
{
    public class bookDataModel
    {
        public string masach { get; set; }
        public string tensach { get; set; }
        public string tacgia { get; set; }
        public string nhaxb { get; set; }
        public string theloai { get; set; }
        public string gia { get; set; }

        private void LoadBookData()
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
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi kết nối đến cơ sở dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
