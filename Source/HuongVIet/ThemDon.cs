using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using HuongViet.DAO;
namespace HuongVIet
{
    public partial class ThemDon : Form
    {
        public ThemDon()
        {
            InitializeComponent();
        }

        private void back_Click(object sender, EventArgs e)
        {
            QuanLyDonHang f = new QuanLyDonHang();
            this.Hide();
            f.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //tt
            if (textBox1.Text == "" || cn.Text == "" || pttt.Text == "")
                MessageBox.Show("(*) là bắt buộc, vui lòng nhập đầy đủ");
            else
            {
                string query;
                DataProvider provider = new DataProvider();
                int data = 0;
                if (textBox2.Text == "")
                {
                    query = "EXEC sp_InDH @MANV , NULL , @MACN , N'Trực tiếp' , @PTTT";
                    data = provider.ExecuteNonQuery(query, new object[] { textBox1.Text, cn.Text,pttt.Text });
                }
                else
                {
                    query = "EXEC sp_InDH @MANV , @MATV , @MACN , N'Trực tiếp' , @PTTT";
                    data = provider.ExecuteNonQuery(query, new object[] { textBox1.Text, textBox2.Text, cn.Text,pttt.Text });
                }
                if (data > 0)
                {
                    MessageBox.Show("Tạo thành công.");
                    button1.Visible = false;
                    button2.Visible = false;
                    button3.Visible = false;
                    label1.Visible = false;
                    label2.Visible = false;
                    label3.Visible = false;
                    textBox1.Visible = false;
                    textBox2.Visible = false;
                    cn.Visible = false;
                    button4.Visible = true;
                    button5.Visible = true;
                    button7.Visible = true;
                    label5.Visible = true;
                    label6.Visible = true;
                    textBox3.Visible = true;
                    textBox4.Visible = true;
                    label7.Visible = false;
                    pttt.Visible = false;
                    query = "select max(MADH) from DONHANG";
                    using (SqlConnection conn = new SqlConnection(provider.ConnectionSTR))
                    {
                        SqlCommand cmd = new SqlCommand(query, conn);
                        conn.Open();
                        label4.Text = ((int)cmd.ExecuteScalar()).ToString();
                    }
                }
                else
                    MessageBox.Show("Tạo không thành công.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //online
            if (textBox1.Text == "" || cn.Text == "" || pttt.Text == "")
                MessageBox.Show("(*) là bắt buộc, vui lòng nhập đầy đủ");
            else
            {
                string query;
                DataProvider provider = new DataProvider();
                int data = 0;
                if (textBox2.Text == "")
                {
                    query = "EXEC sp_InDH @MANV , NULL , @MACN , N'Online' , @PTTT";
                    data = provider.ExecuteNonQuery(query, new object[] { textBox1.Text, cn.Text, pttt.Text });
                }
                else
                {
                    query = "EXEC sp_InDH @MANV , @MATV , @MACN , N'Online' , @PTTT";
                    data = provider.ExecuteNonQuery(query, new object[] {textBox1.Text,textBox2.Text, cn.Text, pttt.Text });
                }
                if (data > 0)
                {
                    MessageBox.Show("Tạo thành công.");
                    button1.Visible = false;
                    button2.Visible = false;
                    button3.Visible = false;
                    label1.Visible = false;
                    label2.Visible = false;
                    label3.Visible = false;
                    textBox1.Visible = false;
                    textBox2.Visible = false;
                    button4.Visible = true;
                    button6.Visible = true;
                    button7.Visible = true;
                    cn.Visible = false;
                    label5.Visible = true;
                    label6.Visible = true;
                    textBox3.Visible = true;
                    textBox4.Visible = true;
                    label7.Visible = false;
                    pttt.Visible = false;
                    query = "select max(MADH) from DONHANG";
                    using (SqlConnection conn = new SqlConnection(provider.ConnectionSTR))
                    {
                        SqlCommand cmd = new SqlCommand(query, conn);
                        conn.Open();
                        label4.Text = ((int)cmd.ExecuteScalar()).ToString();
                    }
                }
                else
                    MessageBox.Show("Tạo không thành công.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //dt
            if (textBox1.Text == "" || cn.Text == "" || pttt.Text == "")
                MessageBox.Show("(*) là bắt buộc, vui lòng nhập đầy đủ");
            else
            {
                string query;
                DataProvider provider = new DataProvider();
                int data = 0;
                if (textBox2.Text == "")
                {
                    query = "EXEC sp_InDH @MANV , NULL , @MACN , N'Điện thoại' , @PTTT";
                    data = provider.ExecuteNonQuery(query, new object[] { textBox1.Text, cn.Text, pttt.Text });
                }
                else
                {
                    query = "EXEC sp_InDH @MANV , @MATV , @MACN , N'Điện thoại' , @PTTT";
                    data = provider.ExecuteNonQuery(query, new object[] { textBox1.Text, textBox2.Text, cn.Text, pttt.Text });
                }
                if (data > 0)
                {
                    MessageBox.Show("Tạo thành công.");
                    button1.Visible = false;
                    button2.Visible = false;
                    button3.Visible = false;
                    label1.Visible = false;
                    label2.Visible = false;
                    label3.Visible = false;
                    textBox1.Visible = false;
                    textBox2.Visible = false;
                    button4.Visible = true;
                    button6.Visible = true;
                    button7.Visible = true;
                    cn.Visible = false;
                    label5.Visible = true;
                    label6.Visible = true;
                    textBox3.Visible = true;
                    textBox4.Visible = true;
                    label7.Visible = false;
                    pttt.Visible = false;
                    query = "select max(MADH) from DONHANG";
                    using (SqlConnection conn = new SqlConnection(provider.ConnectionSTR))
                    {
                        SqlCommand cmd = new SqlCommand(query, conn);
                        conn.Open();
                        label4.Text = ((int)cmd.ExecuteScalar()).ToString();
                    }
                }
                else
                    MessageBox.Show("Tạo không thành công.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "" || textBox4.Text == "")
                MessageBox.Show("(*) là bắt buộc, vui lòng nhập đầy đủ");
            else
            {
                string query = "EXEC sp_InCTDH @MADH , @MAMON , @SL";
                DataProvider provider = new DataProvider();
                int data = 0;
                data = provider.ExecuteNonQuery(query, new object[] { label4.Text,textBox3.Text, textBox4.Text});
                if (data > 0)
                {
                    MessageBox.Show("Thêm thành công.");
                    query = "select C.*,M.TENMON from CHITIETDONHANG C, MONAN M where C.MAMON=M.MAMON AND C.MADH = @MADH";
                    provider = new DataProvider();
                    dataGridView1.DataSource = provider.ExecuteQuery(query, new object[] { label4.Text });
                }
                else
                    MessageBox.Show("Thêm không thành công.");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Đã tiếp nhận đơn");
            ThemDon f = new ThemDon();
            this.Hide();
            f.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            XacNhanGiaoHang f = new XacNhanGiaoHang(label4.Text);
            f.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
                MessageBox.Show("(*) là bắt buộc, vui lòng nhập đầy đủ");
            else
            {
                string query = "EXEC sp_DelCTDH @MADH , @MAMON";
                DataProvider provider = new DataProvider();
                int data = 0;
                data = provider.ExecuteNonQuery(query, new object[] { label4.Text, textBox3.Text});
                if (data > 0)
                {
                    MessageBox.Show("Xóa thành công.");
                    query = "select C.*,M.TENMON from CHITIETDONHANG C, MONAN M where C.MAMON=M.MAMON AND C.MADH = @MADH";
                    provider = new DataProvider();
                    dataGridView1.DataSource = provider.ExecuteQuery(query, new object[] { label4.Text });
                }
                else
                    MessageBox.Show("Xóa không thành công.");
            }
        }
    }
}
