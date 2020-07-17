namespace HuongVIet
{
    partial class PhucVu_LeTan
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
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dangxuat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(240, 302);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(326, 40);
            this.button2.TabIndex = 27;
            this.button2.Text = "Đăng ký thành viên";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(240, 220);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(326, 40);
            this.button1.TabIndex = 26;
            this.button1.Text = "Quản lý đơn hàng";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dangxuat
            // 
            this.dangxuat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dangxuat.Location = new System.Drawing.Point(332, 84);
            this.dangxuat.Name = "dangxuat";
            this.dangxuat.Size = new System.Drawing.Size(122, 52);
            this.dangxuat.TabIndex = 25;
            this.dangxuat.Text = "Đăng xuất";
            this.dangxuat.UseVisualStyleBackColor = true;
            this.dangxuat.Click += new System.EventHandler(this.dangxuat_Click);
            // 
            // PhucVu_LeTan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dangxuat);
            this.Name = "PhucVu_LeTan";
            this.Text = "Phục vụ / Lễ tân";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button dangxuat;
    }
}