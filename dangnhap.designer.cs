namespace WindowsFormsApp2
{
    partial class Formtrangchu
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
            System.Windows.Forms.Button dangnhapBtn;
            System.Windows.Forms.Button dangkyBtn;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Formtrangchu));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.matkhautxt = new System.Windows.Forms.TextBox();
            this.taikhoantxt = new System.Windows.Forms.TextBox();
            this.banner = new System.Windows.Forms.Label();
            this.taikhoanlb = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            dangnhapBtn = new System.Windows.Forms.Button();
            dangkyBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dangnhapBtn
            // 
            dangnhapBtn.BackColor = System.Drawing.SystemColors.InactiveCaption;
            dangnhapBtn.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dangnhapBtn.Location = new System.Drawing.Point(689, 322);
            dangnhapBtn.Name = "dangnhapBtn";
            dangnhapBtn.Size = new System.Drawing.Size(166, 40);
            dangnhapBtn.TabIndex = 1;
            dangnhapBtn.Text = "Đăng nhập";
            dangnhapBtn.UseVisualStyleBackColor = false;
            dangnhapBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // dangkyBtn
            // 
            dangkyBtn.BackColor = System.Drawing.SystemColors.InactiveCaption;
            dangkyBtn.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dangkyBtn.Location = new System.Drawing.Point(689, 392);
            dangkyBtn.Name = "dangkyBtn";
            dangkyBtn.Size = new System.Drawing.Size(166, 41);
            dangkyBtn.TabIndex = 2;
            dangkyBtn.Text = "Đăng ký";
            dangkyBtn.UseVisualStyleBackColor = false;
            dangkyBtn.Click += new System.EventHandler(this.dangkyBtn_Click_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(2, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(537, 534);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // matkhautxt
            // 
            this.matkhautxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.matkhautxt.Location = new System.Drawing.Point(662, 237);
            this.matkhautxt.Multiline = true;
            this.matkhautxt.Name = "matkhautxt";
            this.matkhautxt.PasswordChar = '*';
            this.matkhautxt.Size = new System.Drawing.Size(281, 44);
            this.matkhautxt.TabIndex = 3;
            this.matkhautxt.TextChanged += new System.EventHandler(this.dangnhaptxt_TextChanged);
            // 
            // taikhoantxt
            // 
            this.taikhoantxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.taikhoantxt.Location = new System.Drawing.Point(662, 148);
            this.taikhoantxt.Multiline = true;
            this.taikhoantxt.Name = "taikhoantxt";
            this.taikhoantxt.Size = new System.Drawing.Size(281, 45);
            this.taikhoantxt.TabIndex = 4;
            // 
            // banner
            // 
            this.banner.AutoSize = true;
            this.banner.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.banner.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.banner.Location = new System.Drawing.Point(573, 43);
            this.banner.Name = "banner";
            this.banner.Size = new System.Drawing.Size(384, 33);
            this.banner.TabIndex = 5;
            this.banner.Text = "Phần mềm quản lý nhà sách";
            // 
            // taikhoanlb
            // 
            this.taikhoanlb.AutoSize = true;
            this.taikhoanlb.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.taikhoanlb.Location = new System.Drawing.Point(549, 156);
            this.taikhoanlb.Name = "taikhoanlb";
            this.taikhoanlb.Size = new System.Drawing.Size(107, 25);
            this.taikhoanlb.TabIndex = 6;
            this.taikhoanlb.Text = "Tài khoản";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(555, 246);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "Mật khẩu";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Formtrangchu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ClientSize = new System.Drawing.Size(959, 534);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.taikhoanlb);
            this.Controls.Add(this.banner);
            this.Controls.Add(this.taikhoantxt);
            this.Controls.Add(this.matkhautxt);
            this.Controls.Add(dangkyBtn);
            this.Controls.Add(dangnhapBtn);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Formtrangchu";
            this.Text = "Đăng nhập";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox matkhautxt;
        private System.Windows.Forms.TextBox taikhoantxt;
        private System.Windows.Forms.Label banner;
        private System.Windows.Forms.Label taikhoanlb;
        private System.Windows.Forms.Label label1;
    }
}

