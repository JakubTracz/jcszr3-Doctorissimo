using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Data;
using DAL.IRepositories;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class RoomRepository : GenericRepository<Room>, IRoomRepository
    {
        public RoomRepository(DoctorissimoContext dbContext) : base(dbContext)
        {
        }

        public Task<List<Room>> GetAllRoomsAsync() => GetAll().OrderBy(d => d.Name).ToListAsync();
        public Task<Room> GetRoomByIdAsync(int? id) => GetByIdAsync(id);
        public Task CreateNewRoomAsync(Room room) => CreateAsync(room);
        public Task DeleteRoomAsync(int id) => DeleteAsync(id);
        public Task UpdateRoomAsync(int id, Room room) => UpdateAsync(id, room);
        public bool CheckIfRoomExists(int? id) => CheckIfExists(id);
        public async Task<List<Appointment>> GetAllAppointmentsInSelectedRoom(int? id) =>
            await DbContext.Appointments.Select(a => new Appointment
            {
                Id = a.Id,
                RoomId = a.RoomId,
                Doctor = a.Doctor,
                Room = a.Room,
                AppointmentStatus = a.AppointmentStatus,
                AppointmentTime = a.AppointmentTime,
                Patient = a.Patient,
                DoctorId = a.DoctorId,
                PatientId = a.PatientId

            })
                .Where(r => r.RoomId == id)
                .OrderBy(a => a.AppointmentTime)
                .ToListAsync();
    }
}
