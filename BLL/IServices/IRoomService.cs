using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.DTO;
using DAL.Models;

namespace BLL.IServices
{
    public interface IRoomService
    {
        public Task<List<RoomDTO>> GetAllRoomsAsync();
        public Task<RoomDTO> GetRoomByIdAsync(int? id);
        public Task AddNewRoomAsync(RoomDTO roomDto);
        public Task DeleteRoomAsync(int id);
        public Task UpdateRoomAsync(int id, RoomDTO roomDto);
        public bool CheckIfRoomExists(int? id);
        public Task<List<AppointmentDTO>> GetAllAppointmentsInSelectedRoom(int? id);
    }
}
