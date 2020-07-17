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
    public partial class KhachVangLai : Form
    {
        public KhachVangLai()
        {
            InitializeComponent();
        }

        private void dathang_Click(object sender, EventArgs e)
        {
            if (sdt.Text == "")
                MessageBox.Show("(*) là bắt buộc, vui lòng nhập đầy đủ");
            else if (sdt.Text.Length != 10)
                MessageBox.Show("Số điện thoại gồm 10 số");
            else
            {
                TrangChuDaDN f = new TrangChuDaDN(sdt.Text);
                this.Hide();
                f.ShowDialog();
            }
        }
    }
}
