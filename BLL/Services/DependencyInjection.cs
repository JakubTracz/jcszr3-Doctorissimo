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
            services.AddTransient<IAppointmentRepository,AppointmentRepository>();
            services.AddTransient<IPatientRepository,PatientRepository>();
            services.AddTransient<IDoctorRepository,DoctorRepository>();
            services.AddTransient<IAppointmentService, AppointmentService>();
            services.AddTransient<IPatientService, PatientService>();
            services.AddTransient<IDoctorService, DoctorService>();

            return services;
        }
    }
}
