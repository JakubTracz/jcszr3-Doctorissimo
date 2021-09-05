using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using DAL.Entities;
using DAL.Enums;

namespace BLL.DTO
{
    public class AppointmentDTO
    {
        public AppointmentDTO()
        {
            AppointmentStatus = AppointmentStatus.Available;
        }
        public int Id { get; set; }
        public AppointmentStatus AppointmentStatus { get; set; }
        public DateTime AppointmentTime { get; set; }
        public PatientDTO PatientDto { get; set; }
        public DoctorDTO DoctorDto { get; set; }
        public RoomDTO RoomDto { get; set; }
    }
}
