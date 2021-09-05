using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Data;
using DAL.IRepositories;
using DAL.Models;
using DAL.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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

        public async Task<List<AppointmentsListViewModel>> GetAllAppointments()
        {
            var result = await DbContext.Appointments.Select(a =>
                    new AppointmentsListViewModel
                    {
                        Id = a.Id,
                        AppointmentStatus = a.AppointmentStatus,
                        AppointmentTime = a.AppointmentTime,
                        RoomName = a.Room.Name,
                        DoctorFullName = a.Doctor.FullName,
                        PatientFullName = a.Patient.FullName ?? string.Empty,
                        DoctorId = a.DoctorId,
                        RoomId = a.RoomId,
                        PatientId = a.PatientId

                    })
                .OrderBy(a => a.Id)
                .ToListAsync();
            return result;
        }
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
