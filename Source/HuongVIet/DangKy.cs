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
    public partial class DangKy : Form
    {
        public DangKy()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (hoten.Text == "" || pass.Text == ""|| cmnd.Text=="" || email.Text == "" || diachi.Text == "" || cndk.Text == "")
                MessageBox.Show("(*) là bắt buộc, vui lòng nhập đầy đủ");
            else
            {
                string query = "EXEC sp_THEMTHANHVIENonl @TENTV , @MATKHAU , @CMND , @NGSINH , @CHINHANHDK , @DIACHI , @EMAIL";
                DataProvider provider = new DataProvider();
                int data = 0;
                data = provider.ExecuteNonQuery(query, new object[] { hoten.Text, pass.Text, cmnd.Text, ngaysinh.Value, cndk.Text, diachi.Text, email.Text });
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
