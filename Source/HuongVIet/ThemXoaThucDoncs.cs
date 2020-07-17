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
    public partial class ThemXoaThucDoncs : Form
    {
        public ThemXoaThucDoncs()
        {
            InitializeComponent();
            string query = "select * from thucdon order by ngay desc,macn asc";
            DataProvider provider = new DataProvider();
            dataGridView1.DataSource = provider.ExecuteQuery(query, new object[] { });
        }

        private void back_Click(object sender, EventArgs e)
        {
            QuanLyCongTy f = new QuanLyCongTy();
            this.Hide();
            f.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (mamon.Text == "" || soluong.Text == "" || chinhanh.Text == "")
                MessageBox.Show("(*) là bắt buộc, vui lòng nhập đầy đủ");
            else
            {
                string query = "EXEC sp_ThemMonThucDon @MACN , @MAMON , @NGAY , @SOLUONG , @SL_CON";
                DataProvider provider = new DataProvider();
                int data = 0;
                data = provider.ExecuteNonQuery(query, new object[] { chinhanh.Text, mamon.Text, dateTimePicker1.Value, soluong.Text, soluong.Text });
                if (data > 0)
                {
                    MessageBox.Show("Thêm thành công.");
                    query = "select * from thucdon order by ngay desc,macn asc";
                    provider = new DataProvider();
                    dataGridView1.DataSource = provider.ExecuteQuery(query, new object[] { });
                }
                else
                    MessageBox.Show("Thêm không thành công.");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (mamon.Text == "" || chinhanh.Text == "")
                MessageBox.Show("(*) là bắt buộc, vui lòng nhập đầy đủ");
            else
            {
                string query = "EXEC sp_XoaMonThucDon @MACN , @MAMON , @NGAY";
                DataProvider provider = new DataProvider();
                int data = 0;
                data = provider.ExecuteNonQuery(query, new object[] { chinhanh.Text, mamon.Text, dateTimePicker1.Value});
                if (data > 0)
                {
                    MessageBox.Show("Xóa thành công.");
                    query = "select * from thucdon order by ngay desc,macn asc";
                    provider = new DataProvider();
                    dataGridView1.DataSource = provider.ExecuteQuery(query, new object[] { });
                }
                else
                    MessageBox.Show("Xóa không thành công.");
            }
        }
    }
}
