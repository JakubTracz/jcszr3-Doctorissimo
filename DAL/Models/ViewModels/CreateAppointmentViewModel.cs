﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Models.ViewModels
{
    public class CreateAppointmentViewModel
    {
        public List<Doctor> Doctors { get; set; }
        public int SelectedDoctorId { get; set; }
        public Appointment Appointment { get; init; }
    }
}