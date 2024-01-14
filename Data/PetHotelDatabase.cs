using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetHotelApplication.Models;

namespace PetHotelApplication.Data
{
    public class PetHotelDatabasedb
    {
        readonly SQLiteAsyncConnection _database;

        public PetHotelDatabasedb(string dbPath)
        {
            try
            {
                _database = new SQLiteAsyncConnection(dbPath);
                _database.CreateTableAsync<Room>().Wait();

                _database.CreateTableAsync<ListRoom>().Wait();
                _database.CreateTableAsync<Reservation>().Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error initializing database: {ex}");
                throw;
            }
        }

        // CRUD operations for Room
        public Task<List<Room>> GetRoomsAsync()
        {
            return _database.Table<Room>().ToListAsync();
        }

        public Task<Room> GetRoomAsync(int id)
        {
            return _database.Table<Room>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveRoomAsync(Room room)
        {
            if (room.ID != 0)
            {
                return _database.UpdateAsync(room);
            }
            else
            {
                return _database.InsertAsync(room);
            }
        }

        public Task<int> DeleteRoomAsync(Room room)
        {
            return _database.DeleteAsync(room);
        }

        // CRUD operations for Reservation
        public Task<List<Reservation>> GetReservationsAsync()
        {
            return _database.Table<Reservation>().ToListAsync();
        }

        public Task<Reservation> GetReservationAsync(int id)
        {
            return _database.Table<Reservation>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveReservationAsync(Reservation reservation)
        {
            if (reservation.ID != 0)
            {
                return _database.UpdateAsync(reservation);
            }
            else
            {
                return _database.InsertAsync(reservation);
            }
        }

        public Task<int> DeleteReservationAsync(Reservation reservation)
        {
            return _database.DeleteAsync(reservation);
        }

        public Task<int> SaveListRoomAsync(ListRoom listr)
        {
            if (listr.ID != 0)
            {
                return _database.UpdateAsync(listr);
            }
            else
            {
                return _database.InsertAsync(listr);
            }
        }

        public Task<List<Room>> GetListRoomsAsync(int reservationid)
        {
            return _database.QueryAsync<Room>(
                "select R.ID, R.Description from Room R"
                + " inner join ListRoom LR"
                + " on R.ID = LR.RoomID where LR.ReservationID = ?",
                reservationid);
        }
        public Task<int> DeleteAllRoomsAsync()
        {
            return _database.ExecuteAsync("DELETE FROM Room");
        }
    }
}
