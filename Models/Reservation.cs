using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PetHotelApplication.Models
{
    public class Reservation
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Description { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }

        // Foreign keys
        [ForeignKey(typeof(Room))]
        public int RoomID { get; set; }

      
        public string OwnerName { get; set; }
        public string PetName { get; set; }
        public string PetBreed { get; set; }
        public string PetGender { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

 
        [ManyToOne]
        public Room Room { get; set; }
        public Reservation()
        {
            CheckInDate = new DateTime(2024, 1, 1);
            CheckOutDate=new DateTime(2024, 1, 1);
        }

    }
}
