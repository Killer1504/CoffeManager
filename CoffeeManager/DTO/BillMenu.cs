using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeManager.DTO
{
    public class BillMenu
    {
        private string nameFood;
        private int count;
        private float totalPrice;

        public BillMenu(string nameFood, int count, float totalPrice)
        {
            this.NameFood = nameFood;
            this.Count = count;
            this.TotalPrice = totalPrice;
        }
        public BillMenu(DataRow row)
        {
            this.NameFood = row["name"].ToString();
            this.Count = (int)row["count"];
            this.totalPrice = (float)Convert.ToDouble(row["totalPrice"].ToString());
        }
        

        public string NameFood { get => nameFood; set => nameFood = value; }
        public int Count { get => count; set => count = value; }
        public float TotalPrice { get => totalPrice; set => totalPrice = value; }
    }
}
