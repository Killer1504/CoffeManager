using CoffeeManager.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeManager.DAL
{
    public class BillInforDAL
    {
        private static BillInforDAL instance;

        public static BillInforDAL Instance 
        {
            get 
            {
                if (instance == null)
                    instance = new BillInforDAL();
                return instance; 
            }
            private set => instance = value; 
        }

        private BillInforDAL() { }

        public List<BillInforDTO> LoadBillInforByIdBill(int idBill)
        {
            List<BillInforDTO> billInforDTOs = new List<BillInforDTO>();
            string query = "SELECT * FROM dbo.BillInfo WHERE idBill = " + idBill.ToString();

            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            if(data.Rows.Count > 0)
            {
                foreach (DataRow item in data.Rows)
                {
                    BillInforDTO billInforDTO = new BillInforDTO(item);
                    billInforDTOs.Add(billInforDTO);
                }
            }
            return billInforDTOs;
        }

        public bool InserBillInfor(int idBill, int idFood, int countFood)
        {
            int nResult;
            string query = "EXECUTE dbo.USP_InserBillInfor @idBill , @idFood , @countFood ";
            nResult = DataProvider.Instance.ExecuteNoneQuery(query, new object[] { idBill, idFood, countFood });
            return nResult > 0;
        }

    }
}
