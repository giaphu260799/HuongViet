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
    public partial class CapNhatDon : Form
    {
        public CapNhatDon()
        {
            InitializeComponent();
            string query = "exec sp_TinhTrangDon";
            DataProvider provider = new DataProvider();
            dataGridView1.DataSource = provider.ExecuteQuery(query, new object[] {});
        }

        private void back_Click(object sender, EventArgs e)
        {
            QuanLyDonHang f = new QuanLyDonHang();
            this.Hide();
            f.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "" || comboBox1.Text == "")
            {
                MessageBox.Show("(*) là bắt buộc, vui lòng nhập đầy đủ");
            }
            else
            {
                string query = "EXEC sp_UpDH @MADH , @TRANGTHAI";
                DataProvider provider = new DataProvider();
                int data = 0;
                data = provider.ExecuteNonQuery(query, new object[] { textBox3.Text, comboBox1.Text });
                if (data > 0)
                {
                    MessageBox.Show("Cập nhật thành công.");
                }
                else
                    MessageBox.Show("Cập nhật không thành công.");
                query = "exec sp_TinhTrangDon";
                provider = new DataProvider();
                dataGridView1.DataSource = provider.ExecuteQuery(query, new object[] { });
            }
        }
    }
}
