using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuongViet.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance
        {
            get { if (instance == null) instance = new AccountDAO(); return instance; }
            private set { instance = value; }
        }

        private AccountDAO() { }

        public bool Login(string user, string pass)
        {
            string query = "EXEC SP_DangNhap @user , @pass";
            DataProvider provider = new DataProvider();
            System.Data.DataTable data = provider.ExecuteQuery(query, new object[] { user, pass });
            if (data.Rows.Count > 0)
                return true;
            return false;
        }
    }
}
