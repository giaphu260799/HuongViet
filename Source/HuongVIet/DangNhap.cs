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
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (matv.Text == "" || pass.Text == "")
                MessageBox.Show("(*) là bắt buộc, vui lòng nhập đầy đủ");
            else if (matv.Text.CompareTo("letan")==0 && pass.Text.CompareTo("1") == 0)
            {
                PhucVu_LeTan f = new PhucVu_LeTan();
                this.Hide();
                f.ShowDialog();
            }
            else if (matv.Text.CompareTo("quanlycn") == 0 && pass.Text.CompareTo("1") == 0)
            {
                QuanLyChiNhanh f = new QuanLyChiNhanh();
                this.Hide();
                f.ShowDialog();
            }
            else if (matv.Text.CompareTo("quanlychung") == 0 && pass.Text.CompareTo("1") == 0)
            {
                QuanLyCongTy f = new QuanLyCongTy();
                this.Hide();
                f.ShowDialog();
            }
            else if (Login(matv.Text, pass.Text))
            {
                TrangChuDaDN f = new TrangChuDaDN(matv.Text);
                this.Hide();
                f.ShowDialog();
            }
            else
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DangKy f = new DangKy();
            f.ShowDialog();
        }

        private void back_Click(object sender, EventArgs e)
        {
            TrangChuChuaDN f = new TrangChuChuaDN();
            this.Hide();
            f.ShowDialog();
        }
        bool Login(string user, string pass)
        {
            return AccountDAO.Instance.Login(user, pass);
        }
    }
}
