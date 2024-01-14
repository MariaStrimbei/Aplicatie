using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetHotelApplication.Models
{
    public class ListRoom
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [ForeignKey(typeof(Reservation))]
        public int ReservationID { get; set; }
     
        public int RoomID { get; set; }

        public string Description { get; set; }
    }
}
