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
    public partial class ThongKeCongTy : Form
    {
        public ThongKeCongTy()
        {
            InitializeComponent();
            string query = "exec sp_ThongKeTheoNgayTong";
            DataProvider provider = new DataProvider();
            ngay.DataSource = provider.ExecuteQuery(query, new object[] {});
            query = "exec sp_ThongKeTheoThangTong";
            thang.DataSource = provider.ExecuteQuery(query, new object[] {});
            query = "exec sp_ThongKeTheoNamTong";
            nam.DataSource = provider.ExecuteQuery(query, new object[] {});
            query = "exec sp_ThongKeTheoMonTong";
            mon.DataSource = provider.ExecuteQuery(query, new object[] {});
            query = "exec sp_ThongKeTheoLoaiMonTong";
            loaimon.DataSource = provider.ExecuteQuery(query, new object[] {});
            query = "exec sp_TheoKenhDatHangTong";
            kenh.DataSource = provider.ExecuteQuery(query, new object[] {});
            query = "exec sp_ThongKeTheoLoaiKhachHangTong";
            loaikh.DataSource = provider.ExecuteQuery(query, new object[] {});
            query = "exec sp_TiLeHuyDonTheoLoaiKHTong";
            huytheoloai.DataSource = provider.ExecuteQuery(query, new object[] {});
            query = "exec sp_TiLeHuyDonTheoKenhTong";
            huytheokenh.DataSource = provider.ExecuteQuery(query, new object[] { });
        }

        private void back_Click(object sender, EventArgs e)
        {
            QuanLyCongTy f = new QuanLyCongTy();
            this.Hide();
            f.ShowDialog();
        }
    }
}
