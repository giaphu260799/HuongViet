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
    public partial class TrangChuChuaDN : Form
    {
        public TrangChuChuaDN()
        {
            InitializeComponent();
        }

        private void dangnhap_Click(object sender, EventArgs e)
        {
            DangNhap f = new DangNhap();
            this.Hide();
            f.ShowDialog();
        }

        private void dangky_Click(object sender, EventArgs e)
        {
            DangKy f = new DangKy();
            f.ShowDialog();
        }

        private void dathang_Click(object sender, EventArgs e)
        {
            DatHangChuaDN f = new DatHangChuaDN();
            this.Hide();
            f.ShowDialog();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = "exec sp_XemThucDon @MACN , @Ngay";
            DataProvider provider = new DataProvider();
            dataGridView1.DataSource = provider.ExecuteQuery(query, new object[] { comboBox1.Text, dateTimePicker1.Value });
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
                MessageBox.Show("(*) là bắt buộc, vui lòng nhập đầy đủ");
            else
            {
                string query = "exec sp_XemThucDon @MACN , @Ngay";
                DataProvider provider = new DataProvider();
                dataGridView1.DataSource = provider.ExecuteQuery(query, new object[] { comboBox1.Text, dateTimePicker1.Value });
            }
        }
    }
}
