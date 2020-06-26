using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeManager.DTO
{
    public class BillMenuDTO
    {
        private string nameFood;
        private int count;
        private float totalPrice;
        private float price;

        public BillMenuDTO(string nameFood, int count, float price, float totalPrice)
        {
            this.NameFood = nameFood;
            this.Count = count;
            this.Price = price;
            this.TotalPrice = totalPrice;
        }
        public BillMenuDTO(DataRow row)
        {
            this.NameFood = row["name"].ToString();
            this.Count = (int)row["count"];
            this.Price = (float)Convert.ToDouble(row["Price"].ToString());
            this.totalPrice = (float)Convert.ToDouble(row["totalPrice"].ToString());
        }
        

        public string NameFood { get => nameFood; set => nameFood = value; }
        public int Count { get => count; set => count = value; }
        public float TotalPrice { get => totalPrice; set => totalPrice = value; }
        public float Price { get => price; set => price = value; }
    }
}
