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
    public partial class XacNhanGiaoHang : Form
    {
        public XacNhanGiaoHang(string MADH)
        {
            InitializeComponent();
            madh.Text = MADH;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (hoten.Text == "" ||  sdt.Text == "" || sonha.Text == "" || quan.Text == "" || phuong.Text == "" || tp.Text == "")
                MessageBox.Show("(*) là bắt buộc, vui lòng nhập đầy đủ");
            else
            {
                string query = "EXEC sp_InDHTT @MADH , @TENKH , @SDT , @SONHA , @PHUONG , @QUAN_HUYEN , @TINH_TP";
                DataProvider provider = new DataProvider();
                int data = 0;
                data = provider.ExecuteNonQuery(query, new object[] { madh.Text,hoten.Text, sdt.Text, sonha.Text, phuong.Text, quan.Text, tp.Text });
                if (data > 0)
                {
                    MessageBox.Show("Xác nhận đơn thành công.");
                    this.Hide();
                }
                else
                    MessageBox.Show("Xác nhận đơn không thành công.");
            }
        }
    }
}
