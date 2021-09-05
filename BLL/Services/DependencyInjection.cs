using System;
using BLL.IServices;
using Microsoft.Extensions.DependencyInjection;
using DAL.IRepositories;
using DAL.Repositories;

namespace BLL.Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServicesCollection(this IServiceCollection services)
        {
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IAppointmentRepository,AppointmentRepository>();
            services.AddTransient<IPatientRepository,PatientRepository>();
            services.AddTransient<IDoctorRepository,DoctorRepository>();
            services.AddTransient<IRoomRepository, RoomRepository>();
            services.AddTransient<IAppointmentService, AppointmentService>();
            services.AddTransient<IPatientService, PatientService>();
            services.AddTransient<IDoctorService, DoctorService>();
            services.AddTransient<IRoomService, RoomService>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            return services;
        }
    }
}
