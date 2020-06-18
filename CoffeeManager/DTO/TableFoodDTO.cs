using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeManager.DTO
{
    public class TableFoodDTO
    {
        private int iD;
        private string name;
        private string status;

        private static int tableWidth = 80;
        private static int tableHeight = 50;

        public TableFoodDTO(int _id, string _name, string _status)
        {
            ID = _id;
            Name = _name;
            Status = _status;
        }

        public TableFoodDTO(DataRow row)
        {
            this.ID = (int)row["id"];
            this.Name = (string)row["name"];
            this.Status = (string)row["status"];
        }

        public int ID { get => iD; set => iD = value; }
        public string Name { get => name; set => name = value; }
        public string Status { get => status; set => status = value; }
        public static int TableWidth { get => tableWidth; set => tableWidth = value; }
        public static int TableHeight { get => tableHeight; set => tableHeight = value; }
    }
}
