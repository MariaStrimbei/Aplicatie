using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetHotelApplication.Models
{
    public class Animal
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Name { get; set; }
        public string Species { get; set; }

        // Foreign key
        [ForeignKey(typeof(Client))]
        public int ClientID { get; set; }

        // Navigation property
        [ManyToOne]
        public Client Client { get; set; }

        // Additional attribute
        public bool HasSpecialNeeds { get; set; }
    }
}
