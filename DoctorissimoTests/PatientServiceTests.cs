using BLL.IServices;
using FluentAssertions;
using DAL.IRepositories;
using Xunit;
using AutoMapper;

namespace DoctorissimoTests
{
    [Trait("Category", "Patient")]
    public class PatientServiceTests
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IPatientRepository _patientRepository;
        private readonly IPatientService _patientService;
        private readonly IMapper _mapper;
        public PatientServiceTests(IAppointmentService appointmentService, IAppointmentRepository appointmentRepository, IMapper mapper, IPatientRepository patientRepository, IPatientService patientService)
        {
            _appointmentService = appointmentService;
            _appointmentRepository = appointmentRepository;
            _mapper = mapper;
            _patientRepository = patientRepository;
            _patientService = patientService;
        }
        [Fact]
        public async void GetPatientByMail()
        {
            //var patientService = new PatientService();
            var patient = await _patientService.PatientWithProvidedEmailExists("JKuB@MAIL.COM");
            patient.Should().Be(false);
        }
    }
}
