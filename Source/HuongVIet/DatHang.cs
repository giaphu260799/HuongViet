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
    public partial class DatHang : Form
    {
        
        public DatHang(string TenTK)
        {
            InitializeComponent();
            ten.Text = TenTK;
            string query = "exec sp_HienGio @matk";
            DataProvider provider = new DataProvider();
            dataGridView1.DataSource = provider.ExecuteQuery(query, new object[] {ten.Text});
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (chinhanh.Text == "" || mamon.Text == "" || soluong.Text == "")
                MessageBox.Show("(*) là bắt buộc, vui lòng nhập đầy đủ");
            else
            {
                string query = "exec sp_XoaGio @id , @ma_sach , @sl";
                DataProvider provider = new DataProvider();
                int data = 0;
                data = provider.ExecuteNonQuery(query, new object[] { ten.Text, mamon.Text, soluong.Text });
                if (data > 0)
                    MessageBox.Show("Xóa khỏi giỏ thành công.");
                else
                    MessageBox.Show("Xóa khỏi giỏ không thành công.");
                query = "exec sp_HienGio @matk";
                dataGridView1.DataSource = provider.ExecuteQuery(query, new object[] { ten.Text });
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (chinhanh.Text == "" || mamon.Text == "" || soluong.Text == "")
                MessageBox.Show("(*) là bắt buộc, vui lòng nhập đầy đủ");
            else
            {
                string query = "exec sp_ThemGio @matk , @ma_mon , @ma_cn , @sl";
                DataProvider provider = new DataProvider();
                int data = 0;
                data = provider.ExecuteNonQuery(query, new object[] { ten.Text, mamon.Text, chinhanh.Text, soluong.Text });
                if (data > 0)
                    MessageBox.Show("Thêm vào giỏ thành công.");
                else
                    MessageBox.Show("Thêm vào giỏ không thành công.");
                query = "exec sp_HienGio @matk";
                dataGridView1.DataSource = provider.ExecuteQuery(query, new object[] { ten.Text });
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (chinhanh.Text == "" )
                MessageBox.Show("(*) chưa chọn chi nhánh");
            else
            {
                XacNhanDonHang f = new XacNhanDonHang(ten.Text, chinhanh.Text);
                f.ShowDialog();
            }
        }
    }
}
