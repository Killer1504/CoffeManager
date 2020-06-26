using CoffeeManager.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeManager.DAL
{
    public class CategoryDAL
    {
        private static CategoryDAL instance;

        public static CategoryDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new CategoryDAL();
                return instance;
            }
            private set => instance = value;
        }

        private CategoryDAL() { }

        public List<CategoryDTO> LoadCategory()
        {
            List<CategoryDTO> categoryDTOs = new List<CategoryDTO>();
            string query = "SELECT * FROM dbo.FoodCategory";
            DataTable dataTable = DataProvider.Instance.ExecuteQuery(query);
            if(dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    CategoryDTO categoryDTO = new CategoryDTO(row);
                    categoryDTOs.Add(categoryDTO);
                }
            }
            return categoryDTOs;
        }
    }
}
