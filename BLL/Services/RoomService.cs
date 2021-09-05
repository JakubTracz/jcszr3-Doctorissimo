using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.DTO;
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

        public Task<List<RoomDTO>> GetAllRoomsAsync()
        {
            return _roomRepository.GetAllRoomsAsync();
        }

        public Task<RoomDTO> GetRoomByIdAsync(int? id)
        {
            return _roomRepository.GetRoomByIdAsync(id);
        }

        public Task AddNewRoomAsync(RoomDTO roomDto)
        {
            return _roomRepository.CreateNewRoomAsync(roomDto);
        }

        public Task DeleteRoomAsync(int id)
        {
            return _roomRepository.DeleteRoomAsync(id);
        }

        public Task UpdateRoomAsync(int id, RoomDTO roomDto)
        {
            return _roomRepository.UpdateRoomAsync(id, roomDto);
        }

        public bool CheckIfRoomExists(int? id)
        {
            return _roomRepository.CheckIfRoomExists(id);
        }

        public Task<List<AppointmentDTO>> GetAllAppointmentsInSelectedRoom(int? id)
        {
            return _roomRepository.GetAllAppointmentsInSelectedRoom(id);
        }
    }
}
