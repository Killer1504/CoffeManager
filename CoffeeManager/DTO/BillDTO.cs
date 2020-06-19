using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeManager.DTO
{
    public class BillDTO
    {
        private int id;
        private DateTime? dateCheckIn;
        private DateTime? dateCheckOut;
        private int idTable;
        private int status;

        public BillDTO(int _id, DateTime? _dateCheckIn, DateTime? _dateCheckOut, int _idTable, int _status)
        {
            this.Id = _id;
            this.DateCheckIn = _dateCheckIn;
            this.DateCheckOut = _dateCheckOut;
            this.IdTable = _idTable;
            this.Status = _status;
        }

        public BillDTO(DataRow row)
        {
            this.Id = (int)row["id"];
            this.DateCheckIn = (DateTime)row["dateCheckIn"];
            var _dateCheckOut = row["dateCheckOut"];
            if (_dateCheckOut.ToString() != "")
                this.DateCheckOut = (DateTime)_dateCheckOut;
            this.IdTable = (int)row["idTable"];
            this.Status = (int)row["status"];
        }

        public int Id { get => id; set => id = value; }
        public DateTime? DateCheckIn { get => dateCheckIn; set => dateCheckIn = value; }
        public DateTime? DateCheckOut { get => dateCheckOut; set => dateCheckOut = value; }
        public int IdTable { get => idTable; set => idTable = value; }
        public int Status { get => status; set => status = value; }
    }
}
