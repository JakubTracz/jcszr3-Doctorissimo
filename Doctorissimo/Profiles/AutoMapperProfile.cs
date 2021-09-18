using AutoMapper;
using BLL.DTO;
using DAL.Models;
using Doctorissimo.ViewModels;

namespace Doctorissimo.Profiles
{
    public class AppointmentProfile:Profile
    {
        public AppointmentProfile()
        {
            CreateMap<AppointmentDto, Appointment>()
                .ForMember(d =>d.Doctor,
                    opt 
                        => opt.MapFrom(s=>s.DoctorDto))
                .ForMember(d=>d.Patient,
                    opt 
                        =>opt.MapFrom(s =>s.PatientDto))
                .ForMember(d=>d.Room,
                    opt 
                        =>opt.MapFrom(s =>s.RoomDto))
                .ReverseMap()
                .ForAllMembers(opts 
                    => opts.Condition((src,dest,srcMember) => srcMember != null));


            CreateMap<AppointmentDto,AppointmentsListViewModel >()
                .ReverseMap()
                .ForAllMembers(opts
                    => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<DoctorDto, Doctor>().ReverseMap();
            CreateMap<PatientDto, Patient>().ReverseMap()
                .ForAllMembers(opts 
                    => opts.Condition((src,dest,srcMember) => srcMember != null));
            CreateMap<RoomDto, Room>().ReverseMap();
        }
    }
}
