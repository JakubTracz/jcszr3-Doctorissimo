using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTO;
using BLL.IServices;
using DAL.IRepositories;
using DAL.Models;

namespace BLL.Services
{
    public class RoomService:IRoomService
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IMapper _mapper;

        public RoomService(IRoomRepository roomRepository, IMapper mapper)
        {
            _roomRepository = roomRepository;
            _mapper = mapper;
        }

        public async Task<List<RoomDto>> GetAllRoomsAsync()
        {
            var rooms = await _roomRepository.GetAllRoomsAsync();
            return rooms.Select(r => new RoomDto
            {
                Id = r.Id,
                Name = r.Name
            }).ToList();
        }

        public async Task<RoomDto> GetRoomByIdAsync(int? id)
        {
            var room = await _roomRepository.GetRoomByIdAsync(id);
            return new RoomDto
            {
                Id = room.Id,
                Name = room.Name
            };
        }

        public Task AddNewRoomAsync(RoomDto roomDto)
        {
            var room = new Room
            {
                Name = roomDto.Name,
                Id = roomDto.Id
            };
            return _roomRepository.CreateNewRoomAsync(room);
        }

        public Task DeleteRoomAsync(int id)
        {
            return _roomRepository.DeleteRoomAsync(id);
        }

        public Task UpdateRoomAsync(int id, RoomDto roomDto)
        {
            var room = new Room
            {
                Name = roomDto.Name,
                Id = roomDto.Id
            };
            return _roomRepository.UpdateRoomAsync(id, room);
        }

        public bool CheckIfRoomExists(int? id)
        {
            return _roomRepository.CheckIfRoomExists(id);
        }

        public async Task<List<AppointmentDto>> GetAllAppointmentsInSelectedRoom(int? id)
        {
            var rooms =  await _roomRepository.GetAllAppointmentsInSelectedRoom(id);
            return rooms.Select(a => new AppointmentDto
            {
                Id = a.Id,
                AppointmentStatus = a.AppointmentStatus,
                AppointmentTime = a.AppointmentTime,
                DoctorDto = new DoctorDto
                {
                    LastName = a.Doctor.LastName,
                    FirstName = a.Doctor.FirstName,
                    Specialty = a.Doctor.Specialty
                }
            }).ToList();
        }
    }
}
