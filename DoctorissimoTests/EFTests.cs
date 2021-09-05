using BLL.IServices;
using DAL.Data;
using DAL.Repositories;
using FluentAssertions;
using BLL.Services;
using DAL.IRepositories;
using Microsoft.EntityFrameworkCore;
using Xunit;
using AutoMapper;
using BLL.DTO;

namespace DoctorissimoTests
{
    [Trait("Category", "Patient")]
    public class EfTests
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IMapper _mapper;
        public EfTests(IAppointmentService appointmentService, IAppointmentRepository appointmentRepository, IMapper mapper)
        {
            _appointmentService = appointmentService;
            _appointmentRepository = appointmentRepository;
            _mapper = mapper;
        }
        [Fact]
        public async void GetPatientByMail()
        {
            await using var context = new DoctorissimoContext(new DbContextOptions<DoctorissimoContext>());
            var patientsRepository = new PatientRepository(context);
            var patient = patientsRepository.GetPatientEmailByEmail("JKuB@MAIL.COM");
            patient.Should().Be(false);
        }
        //[Fact]
        //public async void EditAppointment()
        //{
        //    //await using var context = new DoctorissimoContext(new DbContextOptions<DoctorissimoContext>())
        //    var a = await _appointmentService.GetByIdAsync(5);
        //    var app = _mapper.Map(<AppointmentDto,Appointment>)
        //}
    }
}
