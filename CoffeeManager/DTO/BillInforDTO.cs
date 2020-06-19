using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeManager.DTO
{
    public class BillInforDTO
    {
        private int id;
        private int idBill;
        private int idFood;
        private int count;


        public BillInforDTO(int _id, int _idBill, int _idFood, int _cout)
        {
            this.Id = _id;
            this.IdBill = _idBill;
            this.IdFood = _idFood;
            this.Count = _cout;
        }
        public BillInforDTO(DataRow row)
        {
            this.Id = (int)row["id"];
            this.IdBill = (int)row["idBill"];
            this.IdFood = (int)row["idFood"];
            this.Count = (int)row["count"];
        }


        public int Id { get => id; set => id = value; }
        public int IdBill { get => idBill; set => idBill = value; }
        public int IdFood { get => idFood; set => idFood = value; }
        public int Count { get => count; set => count = value; }
    }
}
