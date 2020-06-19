using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeManager.DTO
{
    public class CategoryDTO
    {
        private int iD;
        private string name;

        public CategoryDTO(int _id, string _name)
        {
            this.ID = _id;
            this.Name = _name;
        }

        public CategoryDTO(DataRow row)
        {
            this.ID = (int)row["id"];
            this.Name = row["name"].ToString();
        }

        public int ID { get => iD; set => iD = value; }
        public string Name { get => name; set => name = value; }
    }
}
