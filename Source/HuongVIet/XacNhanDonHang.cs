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
    public partial class XacNhanDonHang : Form
    {
        public XacNhanDonHang(string TenTK, string ChiNhanh)
        {
            InitializeComponent();
            ten.Text = TenTK;
            chinhanh.Text = ChiNhanh;
            if (ten.Text.Length == 10)
            {
                sdt.Text = ten.Text;
                sdt.ReadOnly = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (hoten.Text == "" || chinhanh.Text == "" || sdt.Text == "" || sonha.Text == "" || quan.Text == "" || phuong.Text == "" 
                || tp.Text == "" || pttt.Text == "")
                MessageBox.Show("(*) là bắt buộc, vui lòng nhập đầy đủ");
            else if(tp.Text != "tp.hcm")
                MessageBox.Show("Chỉ giao ở TP.HCM");
            else
            {
                string query;
                DataProvider provider = new DataProvider();
                int data = 0;
                if (sdt.Text.Length >= 10)
                {
                    query = "EXEC sp_ThemDonHangOnline NULL , @MACN , @PTTT , @TENKH , @SDT , @SONHA , @PHUONG , @QUAN_HUYEN , @TINH_TP";
                    data = provider.ExecuteNonQuery(query, new object[] { chinhanh.Text, pttt.Text, hoten.Text, sdt.Text, sonha.Text, phuong.Text, quan.Text, tp.Text });
                }
                else
                {
                    query = "EXEC sp_ThemDonHangOnline @MATV , @MACN , @PTTT , @TENKH , @SDT , @SONHA , @PHUONG , @QUAN_HUYEN , @TINH_TP";
                    data = provider.ExecuteNonQuery(query, new object[] { ten.Text, chinhanh.Text, pttt.Text, hoten.Text, sdt.Text, sonha.Text, phuong.Text, quan.Text, tp.Text });
                }
                if (data > 0)
                {
                    MessageBox.Show("Xác nhận đơn thành công.");
                    TrangChuDaDN f = new TrangChuDaDN(ten.Text);
                    this.Hide();
                    f.ShowDialog();
                }
                else
                    MessageBox.Show("Xác nhận đơn không thành công.");
            }
        }
    }
}
