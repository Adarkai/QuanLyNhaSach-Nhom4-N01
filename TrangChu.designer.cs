namespace WindowsFormsApp2
{
    partial class trangchuform
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(trangchuform));
            this.buttonBookList = new System.Windows.Forms.Button();
            this.buttonQLTaiKhoan = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.buttonThongKe = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonTTDonHang = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonBookList
            // 
            this.buttonBookList.Location = new System.Drawing.Point(12, 363);
            this.buttonBookList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonBookList.Name = "buttonBookList";
            this.buttonBookList.Size = new System.Drawing.Size(101, 66);
            this.buttonBookList.TabIndex = 24;
            this.buttonBookList.Text = "Danh sách thông tin sách\r\n\r\n";
            this.buttonBookList.UseVisualStyleBackColor = true;
            this.buttonBookList.Click += new System.EventHandler(this.buttonBookList_Click);
            // 
            // buttonQLTaiKhoan
            // 
            this.buttonQLTaiKhoan.Location = new System.Drawing.Point(12, 284);
            this.buttonQLTaiKhoan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonQLTaiKhoan.Name = "buttonQLTaiKhoan";
            this.buttonQLTaiKhoan.Size = new System.Drawing.Size(101, 66);
            this.buttonQLTaiKhoan.TabIndex = 23;
            this.buttonQLTaiKhoan.Text = "Danh sách tài khoản";
            this.buttonQLTaiKhoan.UseVisualStyleBackColor = true;
            this.buttonQLTaiKhoan.Click += new System.EventHandler(this.buttonQLTaiKhoan_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 594);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 46);
            this.button1.TabIndex = 25;
            this.button1.Text = "Đăng Xuất";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(319, 12);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(443, 61);
            this.textBox1.TabIndex = 26;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(779, 12);
            this.buttonSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(104, 62);
            this.buttonSearch.TabIndex = 27;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // buttonThongKe
            // 
            this.buttonThongKe.Location = new System.Drawing.Point(12, 192);
            this.buttonThongKe.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonThongKe.Name = "buttonThongKe";
            this.buttonThongKe.Size = new System.Drawing.Size(101, 66);
            this.buttonThongKe.TabIndex = 54;
            this.buttonThongKe.Text = "Thống kê";
            this.buttonThongKe.UseVisualStyleBackColor = true;
            this.buttonThongKe.Click += new System.EventHandler(this.buttonThongKe_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(185, 126);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(984, 516);
            this.dataGridView1.TabIndex = 70;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 11);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(78, 79);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 55;
            this.pictureBox1.TabStop = false;
            // 
            // buttonTTDonHang
            // 
            this.buttonTTDonHang.Location = new System.Drawing.Point(12, 126);
            this.buttonTTDonHang.Name = "buttonTTDonHang";
            this.buttonTTDonHang.Size = new System.Drawing.Size(101, 52);
            this.buttonTTDonHang.TabIndex = 71;
            this.buttonTTDonHang.Text = "Thông tin đơn hàng";
            this.buttonTTDonHang.UseVisualStyleBackColor = true;
            this.buttonTTDonHang.Click += new System.EventHandler(this.buttonTTDonHang_Click);
            // 
            // trangchuform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1181, 654);
            this.Controls.Add(this.buttonTTDonHang);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonThongKe);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonBookList);
            this.Controls.Add(this.buttonQLTaiKhoan);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "trangchuform";
            this.Text = "Trang chủ";
            this.Load += new System.EventHandler(this.trangchuform_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonBookList;
        private System.Windows.Forms.Button buttonQLTaiKhoan;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Button buttonThongKe;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonTTDonHang;
    }
}