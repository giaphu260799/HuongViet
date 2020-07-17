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
    public partial class CapNhatThanhVien : Form
    {
        public CapNhatThanhVien()
        {
            InitializeComponent();
        }

        private void back_Click(object sender, EventArgs e)
        {
            QuanLyThanhVien f = new QuanLyThanhVien();
            this.Hide();
            f.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (hoten.Text == "" || matv.Text == "" || cmnd.Text == "" || email.Text == "" || diachi.Text == "" || cndk.Text == "")
                MessageBox.Show("(*) là bắt buộc, vui lòng nhập đầy đủ");
            else
            {
                string query = "EXEC sp_SuaKhach @matv , @tentv , @cmnd , @ngay_sinh , @dia_chi , @chinhanhdk , @email";
                DataProvider provider = new DataProvider();
                int data = 0;
                data = provider.ExecuteNonQuery(query, new object[] { matv.Text, hoten.Text, cmnd.Text, ngaysinh.Value, diachi.Text, cndk.Text, email.Text });
                if (data > 0)
                {
                    MessageBox.Show("Cập nhật thành công.");
                }
                else
                    MessageBox.Show("Cập nhật không thành công.");
            }
        }
    }
}
