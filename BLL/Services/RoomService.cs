using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.IServices;
using DAL.IRepositories;
using DAL.Models;

namespace BLL.Services
{
    public class RoomService:IRoomService
    {
        private readonly IRoomRepository _roomRepository;

        public RoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public Task<List<Room>> GetAllRoomsAsync()
        {
            return _roomRepository.GetAllRoomsAsync();
        }

        public Task<Room> GetRoomByIdAsync(int? id)
        {
            return _roomRepository.GetRoomByIdAsync(id);
        }

        public Task AddNewRoomAsync(Room room)
        {
            return _roomRepository.CreateNewRoomAsync(room);
        }

        public Task DeleteRoomAsync(int id)
        {
            return _roomRepository.DeleteRoomAsync(id);
        }

        public Task UpdateRoomAsync(int id, Room room)
        {
            return _roomRepository.UpdateRoomAsync(id, room);
        }

        public bool CheckIfRoomExists(int? id)
        {
            return _roomRepository.CheckIfRoomExists(id);
        }

        public Task<List<Appointment>> GetAllAppointmentsInSelectedRoom(int? id)
        {
            return _roomRepository.GetAllAppointmentsInSelectedRoom(id);
        }
    }
}
