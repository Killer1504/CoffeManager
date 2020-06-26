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

        public int GetUncheckBillByIdTable(int idTable)
        {
            int idBill = -1;
            string query = "SELECT * FROM dbo.Bill WHERE status = 0 AND idTable = " + idTable;
            DataTable dataTable = DataProvider.Instance.ExecuteQuery(query);

            if(dataTable.Rows.Count > 0)
            {
                BillDTO billDTO = new BillDTO(dataTable.Rows[0]);
                return billDTO.Id;
            }
            return idBill;
        }

        public bool InsertBill(int idTable)
        {
            string query = "EXEC dbo.USP_InsertBill @idTable ";
            int nResult = DataProvider.Instance.ExecuteNoneQuery(query, new object[] { idTable });
            return nResult > 0;
        }
        public int GetMaxIdBill()
        {
            int idBill = -1;
            string query = "SELECT MAX(id) FROM dbo.Bill";
            try
            {
                idBill = (int)DataProvider.Instance.ExecuteScalar(query);

            }
            catch (Exception)
            {

                idBill = 1;
            }
            return idBill;
        }
    }
}
