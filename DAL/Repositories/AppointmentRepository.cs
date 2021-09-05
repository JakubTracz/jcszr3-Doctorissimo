using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Data;
using DAL.IRepositories;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(DoctorissimoContext dbContext) : base(dbContext)
        {
        }
        public Task<Appointment> GetAppointmentByIdAsync(int? id) => GetByIdAsync(id);
        public Task CreateNewAppointmentAsync(Appointment appointment) => CreateAsync(appointment);
        public Task DeleteAppointmentAsync(int id) => DeleteAsync(id);
        public Task UpdateAppointmentAsync(int id, Appointment appointment) => UpdateAsync(id, appointment);
        public bool CheckIfAppointmentExists(int? id) => CheckIfExists(id);
        public Task<List<Appointment>> GetAllAppointmentsAsync() =>
            GetAll()
            .Select(a => new Appointment()
            {
                Doctor = a.Doctor,
                DoctorId = a.DoctorId,
                Id = a.Id,
                Patient = a.Patient,
                PatientId = a.PatientId,
                Room = a.Room,
                RoomId = a.RoomId,
                AppointmentStatus = a.AppointmentStatus,
                AppointmentTime = a.AppointmentTime,
            })
            .OrderBy(a => a.Id)
            .ToListAsync();
    }
}
