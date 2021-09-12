using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Models;

namespace BLL.IServices
{
    public interface IRoomService
    {
        public Task<List<Room>> GetAllRoomsAsync();
        public Task<Room> GetRoomByIdAsync(int? id);
        public Task AddNewRoomAsync(Room room);
        public Task DeleteRoomAsync(int id);
        public Task UpdateRoomAsync(int id, Room room);
        public bool CheckIfRoomExists(int? id);
        public Task<List<Appointment>> GetAllAppointmentsInSelectedRoom(int? id);
    }
}
