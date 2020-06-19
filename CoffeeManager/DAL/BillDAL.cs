using CoffeeManager.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeManager.DAL
{
    public class BillDAL
    {
        private static BillDAL instance;

        public static BillDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new BillDAL();
                return instance;
            }
            private set => instance = value;
        }

        private BillDAL() { }
        
        /// <summary>
        /// when status = 0: chua thanh toan
        /// </summary>
        public List<BillDTO> LoadListBillByIDTable(int idTable)
        {
            List<BillDTO> listBills = new List<BillDTO>();

            string query = "SELECT * FROM dbo.Bill WHERE status = 0 and idTable = " + idTable.ToString();
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            if(data.Rows.Count > 0)
            {
                foreach (DataRow item in data.Rows)
                {
                    BillDTO billDTO = new BillDTO(item);
                    listBills.Add(billDTO);
                }
            }

            return listBills;
        }
    }
}
