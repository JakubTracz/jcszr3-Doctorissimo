using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTO;
using BLL.IServices;
using DAL.IRepositories;
using DAL.Models;

namespace BLL.Services
{
    public class PatientService :IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper;
        public PatientService(IPatientRepository patientRepository, IMapper mapper)
        {
            _patientRepository = patientRepository;
            _mapper = mapper;
        }

        public async Task<List<PatientDto>> GetAllPatientsAsync()
        {
            var patients = await _patientRepository.GetAllPatientsAsync();
            return patients.Select(p => new PatientDto
            {
                FirstName = p.FirstName,
                Id = p.Id,
                Address = p.Address,
                DateOfBirth = p.DateOfBirth,
                LastName = p.LastName,
                MailAddress = p.MailAddress
            }).ToList();
        }

        public async Task<PatientDto> GetPatientByIdAsync(int? id)
        {
            var patient = await _patientRepository.GetPatientByIdAsync(id);
            return new PatientDto
            {
                Address = patient.Address,
                DateOfBirth = patient.DateOfBirth,
                Id = patient.Id,
                LastName = patient.LastName,
                MailAddress = patient.MailAddress,
                FirstName = patient.FirstName
            };
        }

        public Task AddNewPatientAsync(PatientDto patientDto)
        {
            var patient = new Patient
            {
                DateOfBirth = patientDto.DateOfBirth,
                LastName = patientDto.LastName,
                MailAddress = patientDto.MailAddress,
                FirstName = patientDto.FirstName,
                Address = patientDto.Address,
            };
            return _patientRepository.CreateNewPatientAsync(patient);
        }

        public Task DeletePatientAsync(int id)
        {
            return _patientRepository.DeletePatientAsync(id);
        }

        public Task UpdatePatientAsync(int id, PatientDto patientDto)
        {
            var patient = new Patient
            {
                MailAddress = patientDto.MailAddress,
                Address = patientDto.Address,
                DateOfBirth = patientDto.DateOfBirth,
                FirstName = patientDto.FirstName,
                LastName = patientDto.LastName,
                Id = patientDto.Id
            };
            return _patientRepository.UpdatePatientAsync(id, patient);
        }
        public bool CheckIfPatientExists(int? id) => _patientRepository.CheckIfPatientExists(id);
        public Task<bool> PatientWithProvidedEmailExists(string mail) => _patientRepository.CheckIfPatientWithProvidedEmailExists(mail);
    }
}
