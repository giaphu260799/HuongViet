using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HuongVIet
{
    public partial class PhucVu_LeTan : Form
    {
        public PhucVu_LeTan()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            QuanLyDonHang f = new QuanLyDonHang();
            this.Hide();
            f.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DangKyThanhVien f = new DangKyThanhVien();
            f.ShowDialog();
        }

        private void dangxuat_Click(object sender, EventArgs e)
        {
            TrangChuChuaDN f = new TrangChuChuaDN();
            this.Hide();
            f.ShowDialog();
        }
    }
}
