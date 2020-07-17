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
    public partial class XoaLoaiMon : Form
    {
        public XoaLoaiMon()
        {
            InitializeComponent();
            string query = "select * from loaimon";
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
            if (textBox1.Text == "")
                MessageBox.Show("(*) là bắt buộc, vui lòng nhập đầy đủ");
            else
            {
                string query = "EXEC sp_XoaLoaiMon @MALOAI";
                DataProvider provider = new DataProvider();
                int data = 0;
                data = provider.ExecuteNonQuery(query, new object[] { textBox1.Text });
                if (data > 0)
                {
                    MessageBox.Show("Xóa thành công.");
                }
                else
                    MessageBox.Show("Xóa không thành công.");
                query = "select * from loaimon";
                provider = new DataProvider();
                dataGridView1.DataSource = provider.ExecuteQuery(query, new object[] { });
            }
        }
    }
}
