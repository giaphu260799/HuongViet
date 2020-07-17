namespace HuongVIet
{
    partial class KhachVangLai
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
            this.label2 = new System.Windows.Forms.Label();
            this.sdt = new System.Windows.Forms.TextBox();
            this.dathang = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(104, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "Nhập SĐT (*)";
            // 
            // sdt
            // 
            this.sdt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sdt.Location = new System.Drawing.Point(238, 100);
            this.sdt.Name = "sdt";
            this.sdt.Size = new System.Drawing.Size(168, 27);
            this.sdt.TabIndex = 9;
            // 
            // dathang
            // 
            this.dathang.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dathang.Location = new System.Drawing.Point(202, 203);
            this.dathang.Name = "dathang";
            this.dathang.Size = new System.Drawing.Size(135, 52);
            this.dathang.TabIndex = 17;
            this.dathang.Text = "Xác nhận";
            this.dathang.UseVisualStyleBackColor = true;
            this.dathang.Click += new System.EventHandler(this.dathang_Click);
            // 
            // KhachVangLai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 304);
            this.Controls.Add(this.dathang);
            this.Controls.Add(this.sdt);
            this.Controls.Add(this.label2);
            this.Name = "KhachVangLai";
            this.Text = "Cung cấp thông tin đặt hàng khách vãng lai";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox sdt;
        private System.Windows.Forms.Button dathang;
    }
}