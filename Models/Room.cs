
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetHotelApplication.Models;
namespace PetHotelApplication.Models
{
    public class Room
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string RoomNumber { get; set; }

        public string RoomType { get; set; }

        public bool IsOccupied { get; set; }
        public string Description { get; set; }

        // Navigation property
        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<ListRoom> ListRooms { get; set; }
    }
}
