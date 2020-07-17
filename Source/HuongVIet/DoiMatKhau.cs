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
    public partial class DoiMatKhau : Form
    {
        public DoiMatKhau(string TenTK)
        {
            InitializeComponent();
            matv.Text = TenTK;
        }

        private void back_Click(object sender, EventArgs e)
        {
            TrangChuDaDN f = new TrangChuDaDN(passcu.Text);
            this.Hide();
            f.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (passcu.Text == "" || passmoi.Text == "")
                MessageBox.Show("(*) là bắt buộc, vui lòng nhập đầy đủ");
            else
            {
                string query = "EXEC sp_UPTHETV3 @MATV , @MATKHAU , @MATKHAUMOI";
                DataProvider provider = new DataProvider();
                int data = 0;
                data = provider.ExecuteNonQuery(query, new object[] { matv.Text, passcu.Text, passmoi.Text });
                if (data > 0)
                {
                    MessageBox.Show("Đổi thành công.");
                }
                else
                    MessageBox.Show("Đổi không thành công.");
            }
        }
    }
}
