using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetHotelApplication.Models
{
    public class Client
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }

        // Navigation property
        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Animal> Animals { get; set; }
    }
}
