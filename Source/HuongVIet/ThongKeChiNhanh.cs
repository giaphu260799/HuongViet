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
    public partial class ThongKeChiNhanh : Form
    {
        public ThongKeChiNhanh()
        {
            InitializeComponent();
        }

        private void back_Click(object sender, EventArgs e)
        {
            QuanLyChiNhanh f = new QuanLyChiNhanh();
            this.Hide();
            f.ShowDialog();
        }
        private void macn_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = "exec sp_ThongKeTheoNgayCN @MACN";
            DataProvider provider = new DataProvider();
            ngay.DataSource = provider.ExecuteQuery(query, new object[] { macn.Text });
            query = "exec sp_ThongKeTheoThangCN @MACN";
            thang.DataSource = provider.ExecuteQuery(query, new object[] { macn.Text });
            query = "exec sp_ThongKeTheoNamCN @MACN";
            nam.DataSource = provider.ExecuteQuery(query, new object[] { macn.Text });
            query = "exec sp_ThongKeTheoMonCN @MACN";
            mon.DataSource = provider.ExecuteQuery(query, new object[] { macn.Text });
            query = "exec sp_ThongKeTheoLoaiMonCN @MACN";
            loaimon.DataSource = provider.ExecuteQuery(query, new object[] { macn.Text });
            query = "exec sp_TheoKenhDatHangCN @MACN";
            kenh.DataSource = provider.ExecuteQuery(query, new object[] { macn.Text });
            query = "exec sp_ThongKeTheoLoaiKhachHangCN @MACN";
            loaikh.DataSource = provider.ExecuteQuery(query, new object[] { macn.Text });
            query = "exec sp_TiLeHuyDonTheoLoaiKH @MACN";
            huytheoloai.DataSource = provider.ExecuteQuery(query, new object[] { macn.Text });
            query = "exec sp_TiLeHuyDonTheoKenh @MACN";
            huytheokenh.DataSource = provider.ExecuteQuery(query, new object[] { macn.Text });
        }
    }
}
