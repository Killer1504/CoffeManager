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

        public List<BillMenu> LoadBillMenuByIDTable(int idTable)
        {
            List<BillMenu> billMenus = new List<BillMenu>();

            //
            List<BillDTO> billDTOs = DAL.BillDAL.Instance.LoadListBillByIDTable(idTable);
            if (billDTOs.Count > 0)
            {
                foreach (BillDTO item in billDTOs)
                {
                    int idBill = item.Id;
                    List<BillInforDTO> billInforDTOs = new List<BillInforDTO>();
                    
                }
            }
            return billMenus;
        }
    }
}
