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
    public partial class QuanLyChiNhanh : Form
    {
        public QuanLyChiNhanh()
        {
            InitializeComponent();
        }

        private void dangxuat_Click(object sender, EventArgs e)
        {
            TrangChuChuaDN f = new TrangChuChuaDN();
            this.Hide();
            f.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CapNhatSoPhanAn f = new CapNhatSoPhanAn();
            this.Hide();
            f.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            QuanLyThanhVien f = new QuanLyThanhVien();
            this.Hide();
            f.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ThongKeChiNhanh f = new ThongKeChiNhanh();
            this.Hide();
            f.ShowDialog();
        }
    }
}