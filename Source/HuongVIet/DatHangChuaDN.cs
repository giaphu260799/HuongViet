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
    public partial class DatHangChuaDN : Form
    {
        public DatHangChuaDN()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DangNhap f = new DangNhap();
            this.Hide();
            f.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            KhachVangLai f = new KhachVangLai();
            this.Hide();
            f.ShowDialog();
        }
    }
}
