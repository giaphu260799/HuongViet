using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HuongViet.DAO;
namespace HuongVIet
{
    public partial class DangKyThanhVien : Form
    {
        public DangKyThanhVien()
        {
            InitializeComponent();
        }

        private void back_Click(object sender, EventArgs e)
        {
            PhucVu_LeTan f = new PhucVu_LeTan();
            this.Hide();
            f.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (hoten.Text == "" || pass.Text == "" || cmnd.Text == "" || email.Text == "" || diachi.Text == "" || cndk.Text == "")
                MessageBox.Show("(*) là bắt buộc, vui lòng nhập đầy đủ");
            else
            {
                string query = "EXEC sp_Khach @tentv , @cmnd , @ngay_sinh , @dia_chi , @chinhanhdk , @email , @pass";
                DataProvider provider = new DataProvider();
                int data = 0;
                data = provider.ExecuteNonQuery(query, new object[] { hoten.Text, cmnd.Text, ngaysinh.Value, diachi.Text, cndk.Text, email.Text, pass.Text });
                if (data > 0)
                {
                    MessageBox.Show("Đăng ký thành công.");
                    this.Hide();

                }
                else
                    MessageBox.Show("Đăng ký không thành công.");
            }
        }
    }
}
