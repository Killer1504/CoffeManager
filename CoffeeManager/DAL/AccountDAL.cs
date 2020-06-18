using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeManager.DAL
{
    public class AccountDAL
    {
        private static AccountDAL instance;

        public static AccountDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new AccountDAL();
                return instance;
            }
            private set => instance = value;
        }

        private AccountDAL()
        { }

        public bool Login(string userName, string password)
        {
            string query = "EXECUTE dbo.USP_Login @userName , @password";
            System.Data.DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { userName, password });
            return result.Rows.Count > 0;
        }
    }
}
