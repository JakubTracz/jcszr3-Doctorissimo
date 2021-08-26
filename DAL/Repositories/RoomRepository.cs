using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Data;
using DAL.IRepositories;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class RoomRepository:GenericRepository<Room>,IRoomRepository
    {
        public RoomRepository(DoctorissimoContext dbContext) : base(dbContext)
        {
        }

        public Task<List<Room>> GetAllRoomsAsync()
        {
            return GetAll().OrderBy(d =>d.Name).ToListAsync(); 
        }

        public Task<Room> GetRoomByIdAsync(int? id)
        {
            return GetByIdAsync(id);
        }

        public Task CreateNewRoomAsync(Room room)
        {
            return CreateAsync(room);
        }

        public Task DeleteRoomAsync(int id)
        {
            return DeleteAsync(id);
        }

        public Task UpdateRoomAsync(int id, Room room)
        {
            return UpdateAsync(id, room);
        }

        public bool CheckIfRoomExists(int? id)
        {
            return CheckIfExists(id);
        }

        public async Task<List<Appointment>> GetAllAppointmentsInSelectedRoom(int? id)
        {
            return await DbContext.Appointments.Select(a => a)
                .Where(r => r.RoomId == id)
                .OrderBy(a => a.AppointmentTime)
                .ToListAsync();
        }
    }
}
