using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.DTO;

namespace BLL.IServices
{
    public interface IRoomService
    {
        public Task<List<RoomDto>> GetAllRoomsAsync();
        public Task<RoomDto> GetRoomByIdAsync(int? id);
        public Task AddNewRoomAsync(RoomDto roomDto);
        public Task DeleteRoomAsync(int id);
        public Task UpdateRoomAsync(int id, RoomDto roomDto);
        public bool CheckIfRoomExists(int? id);
        public Task<List<AppointmentDto>> GetAllAppointmentsInSelectedRoom(int? id);
    }
}
