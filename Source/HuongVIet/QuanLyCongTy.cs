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
    public partial class QuanLyCongTy : Form
    {
        public QuanLyCongTy()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ThemMon f = new ThemMon();
            this.Hide();
            f.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CapNhatMon f = new CapNhatMon();
            this.Hide();
            f.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ThongKeCongTy f = new ThongKeCongTy();
            this.Hide();
            f.ShowDialog();
        }

        private void dangxuat_Click(object sender, EventArgs e)
        {
            TrangChuChuaDN f = new TrangChuChuaDN();
            this.Hide();
            f.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            XoaMon f = new XoaMon();
            this.Hide();
            f.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ThemLoaiMon f = new ThemLoaiMon();
            this.Hide();
            f.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            XoaLoaiMon f = new XoaLoaiMon();
            this.Hide();
            f.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ThemXoaThucDoncs f = new ThemXoaThucDoncs();
            this.Hide();
            f.ShowDialog();
        }
    }
}
