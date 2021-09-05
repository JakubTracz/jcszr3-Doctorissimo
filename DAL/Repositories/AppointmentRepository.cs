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

        public Task<Appointment> GetAppointmentByIdAsync(int? id)
        {
            return GetByIdAsync(id);
        }

        public Task CreateNewAppointmentAsync(Appointment appointment)
        {
            return CreateAsync(appointment);
        }

        public Task DeleteAppointmentAsync(int id)
        {
            return DeleteAsync(id);
        }

        public Task UpdateAppointmentAsync(int id, Appointment appointment)
        {
            return UpdateAsync(id, appointment);
        }

        public bool CheckIfAppointmentExists(int? id)
        {
            return CheckIfExists(id);
        }

        public Task<List<Appointment>> GetAllAppointments()=> DbContext.Appointments
                .OrderBy(a => a.Id)
                .ToListAsync();
        //public AppointmentsListViewModel GetRoomAndDoctor(int id)
        //{
        //    var result = DbContext.Appointments
        //        .Where(a => a.Id == id)
        //        .Select(a => new AppointmentsListViewModel
        //        {
        //            Room = a.Room.Name,
        //            DoctorFullName = a.Doctor.FullName,
        //        });
        //    return result;
        //}
        public Task<List<Appointment>> GetAllAppointmentsAsync()
        {
            return GetAll().OrderBy(a => a.Id).ToListAsync();
        }
    }
}
