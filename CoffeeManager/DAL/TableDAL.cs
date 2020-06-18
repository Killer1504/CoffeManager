using CoffeeManager.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeManager.DAL
{
    public class TableDAL
    {
        private static TableDAL instance;

        public static TableDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new TableDAL();
                return instance;
            }
            private set => instance = value;
        }

        private TableDAL()
        { }

        public List<TableFoodDTO> LoadTableList()
        {
            List<TableFoodDTO> tableFoodList = new List<TableFoodDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("dbo.USP_GetTableList");
            foreach (DataRow item in data.Rows)
            {
                TableFoodDTO tableFood = new TableFoodDTO(item);
                tableFoodList.Add(tableFood);

            }
            return tableFoodList;
        }
    }
}
