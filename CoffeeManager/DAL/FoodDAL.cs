using CoffeeManager.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeManager.DAL
{
    public class FoodDAL
    {
        private static FoodDAL instance;

        public static FoodDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new FoodDAL();
                return instance;
            }
            private set => instance = value;
        }

        private FoodDAL() { }

        public List<FoodDTO> LoadFoodByIDCategory(int idCategory)
        {
            List<FoodDTO> foodDTOs = new List<FoodDTO>();
            string query = "SELECT * FROM dbo.Food WHERE idCategory = " + idCategory;

            DataTable dataTable = DataProvider.Instance.ExecuteQuery(query);
            if(dataTable.Rows.Count > 0)
            {
                foreach (DataRow item in dataTable.Rows)
                {
                    FoodDTO foodDTO = new FoodDTO(item);
                    foodDTOs.Add(foodDTO);
                }
            }
            return foodDTOs;
        }
    }
}
