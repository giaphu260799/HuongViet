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
    public partial class QuanLyThanhVien : Form
    {
        public QuanLyThanhVien()
        {
            InitializeComponent();
        }

        private void back_Click(object sender, EventArgs e)
        {
            QuanLyChiNhanh f = new QuanLyChiNhanh();
            this.Hide();
            f.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ThemThanhVien f = new ThemThanhVien();
            this.Hide();
            f.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            XoaThanhVien f = new XoaThanhVien();
            this.Hide();
            f.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CapNhatThanhVien f = new CapNhatThanhVien();
            this.Hide();
            f.ShowDialog();
        }
    }
}
