using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.IRepositories
{
    public interface IRoomRepository:IGenericRepository<Room>
    {
        Task<List<Room>> GetAllRoomsAsync();
        Task<Room> GetRoomByIdAsync(int? id);
        public Task CreateNewRoomAsync(Room room);
        public Task DeleteRoomAsync(int id);
        public Task UpdateRoomAsync(int id,Room room);
        public bool CheckIfRoomExists(int? id);
        public Task<List<Appointment>> GetAllAppointmentsInSelectedRoom(int? id);
    }
}
