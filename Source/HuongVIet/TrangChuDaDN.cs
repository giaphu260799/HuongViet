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
    public partial class TrangChuDaDN : Form
    {
        public TrangChuDaDN(string TenTK)
        {
            InitializeComponent();
            matv.Text = TenTK;
            if(matv.Text.Length>=10)
            {
                button2.Visible = false;
                button3.Visible = false;
            }
        }

        private void dangxuat_Click(object sender, EventArgs e)
        {
            TrangChuChuaDN f = new TrangChuChuaDN();
            this.Hide();
            f.ShowDialog();
        }

        private void dathang_Click(object sender, EventArgs e)
        {
            DatHang f = new DatHang(matv.Text);
            f.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DonHangCaNhan f = new DonHangCaNhan(matv.Text);
            this.Hide();
            f.ShowDialog();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = "exec sp_XemThucDon @MACN , @Ngay";
            DataProvider provider = new DataProvider();
            dataGridView1.DataSource = provider.ExecuteQuery(query, new object[] { comboBox1.Text, dateTimePicker1.Value });
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CapNhatThongTin f = new CapNhatThongTin(matv.Text);
            this.Hide();
            f.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DoiMatKhau f = new DoiMatKhau(matv.Text);
            this.Hide();
            f.ShowDialog();
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
