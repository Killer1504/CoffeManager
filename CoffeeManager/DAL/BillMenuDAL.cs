using CoffeeManager.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeManager.DAL
{
    public class BillMenuDAL
    {
        private static BillMenuDAL instance;

        public static BillMenuDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new BillMenuDAL();
                return instance;
            }
            private set => instance = value;
        }

        private BillMenuDAL() { }

        public List<BillMenuDTO> LoadListBillMenuByTable(int idTable)
        {
            List<BillMenuDTO> billMenuDTOs = new List<BillMenuDTO>();

            string query = "SELECT f.name , bi.count,  f.price , bi.count * f.price AS 'totalPrice' "
                            + " FROM dbo.Bill AS B, dbo.BillInfo AS Bi, dbo.Food AS F "
                            + " WHERE Bi.idBill = B.id "
                            + " AND Bi.idFood = F.id "
                            + " AND B.status = 0 "
                            + " AND b.idTable = " + idTable.ToString();
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            if(data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    BillMenuDTO billMenu = new BillMenuDTO(row);
                    billMenuDTOs.Add(billMenu);
                }
            }
            return billMenuDTOs;
        }
    }
}
