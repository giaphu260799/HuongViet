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
    public partial class CapNhatSoPhanAn : Form
    {
        public CapNhatSoPhanAn()
        {
            InitializeComponent();
            string query = "select * from thucdon order by ngay desc,macn asc";
            DataProvider provider = new DataProvider();
            dataGridView1.DataSource = provider.ExecuteQuery(query, new object[] {});
        }

        private void back_Click(object sender, EventArgs e)
        {
            QuanLyChiNhanh f = new QuanLyChiNhanh();
            this.Hide();
            f.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "" || textBox1.Text == "" || textBox2.Text == "")
                MessageBox.Show("(*) là bắt buộc, vui lòng nhập đầy đủ");
            else
            {
                string query = "EXEC sp_CapNhatSoPhanAn @MACN , @MAMON , @NGAY , @SOLUONG , @SL_CON";
                DataProvider provider = new DataProvider();
                int data = 0;
                data = provider.ExecuteNonQuery(query, new object[] { comboBox1.Text, textBox1.Text, dateTimePicker1.Value, textBox2.Text, textBox2.Text });
                if (data > 0)
                {
                    MessageBox.Show("Cập nhật thành công.");
                }
                else
                    MessageBox.Show("Cập nhật không thành công.");
                query = "select * from thucdon order by ngay desc,macn asc";
                provider = new DataProvider();
                dataGridView1.DataSource = provider.ExecuteQuery(query, new object[] { });
            }
        }
    }
}
