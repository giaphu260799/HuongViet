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
    public partial class QuanLyDonHang : Form
    {
        public QuanLyDonHang()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CapNhatDon f = new CapNhatDon();
            this.Hide();
            f.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ThemDon f = new ThemDon();
            this.Hide();
            f.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            XoaDon f = new XoaDon();
            this.Hide();
            f.ShowDialog();
        }

        private void back_Click(object sender, EventArgs e)
        {
            PhucVu_LeTan f = new PhucVu_LeTan();
            this.Hide();
            f.ShowDialog();
        }
    }
}
