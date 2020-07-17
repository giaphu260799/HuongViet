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
    public partial class DonHangCaNhan : Form
    {
        public DonHangCaNhan(string MaTK)
        {
            InitializeComponent();
            matv.Text = MaTK;
            string query = "exec sp_DonHangCaNhan @MATV";
            DataProvider provider = new DataProvider();
            dataGridView1.DataSource = provider.ExecuteQuery(query, new object[] {MaTK});
        }

        private void back_Click(object sender, EventArgs e)
        {
            TrangChuDaDN f = new TrangChuDaDN(matv.Text);
            this.Hide();
            f.ShowDialog();
        }
    }
}
