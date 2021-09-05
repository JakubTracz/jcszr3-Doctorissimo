using AutoMapper;
using BLL.DTO;
using DAL.Models;

namespace Doctorissimo.Profiles
{
    public class AppointmentProfile:Profile
    {
        public AppointmentProfile()
        {
            CreateMap<AppointmentDto, Appointment>().ReverseMap();
            CreateMap<DoctorDto, Doctor>().ReverseMap();
            CreateMap<PatientDto, Patient>().ReverseMap()
                .ForAllMembers(opts 
                    => opts.Condition((src,dest,srcMember) => srcMember != null));
            CreateMap<RoomDto, Room>().ReverseMap();
        }
    }
}
