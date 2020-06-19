using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeManager.DTO
{
    public class FoodDTO
    {
        private int id;
        private string name;
        private int idCategory;
        private float price;

        public FoodDTO(int _id, string _name, int _idCategory, float _price)
        {
            this.Id = _id;
            this.Name = _name;
            this.IdCategory = _idCategory;
            this.Price = _price;
        }
        public FoodDTO(DataRow row)
        {
            this.Id = (int)row["id"];
            this.Name = row["name"].ToString();
            this.IdCategory = (int)row["idCategory"];
            this.Price = (float)Convert.ToDouble(row["price"].ToString());

        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int IdCategory { get => idCategory; set => idCategory = value; }
        public float Price { get => price; set => price = value; }
    }
}
