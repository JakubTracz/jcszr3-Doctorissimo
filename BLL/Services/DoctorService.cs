using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTO;
using BLL.IServices;
using DAL.Enums;
using DAL.IRepositories;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IMapper _mapper;

        public DoctorService(IDoctorRepository doctorRepository, IMapper mapper)
        {
            _doctorRepository = doctorRepository;
            _mapper = mapper;
        }

        public async Task<List<DoctorDto>> GetAllDoctorsAsync() => 
            await _doctorRepository.GetAll().Select(d => new DoctorDto
            {
                LastName = d.LastName,
                Specialty = d.Specialty,
                FirstName = d.FirstName,
                Id = d.Id
            }).ToListAsync();

        public async Task<DoctorDto> GetDoctorByIdAsync(int? id)
        {
            var doctor = await _doctorRepository.GetDoctorByIdAsyncTask(id);
            return new DoctorDto
            {
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                Specialty = doctor.Specialty,
                Id = doctor.Id
            };
        }

        public Task AddNewDoctorAsync(DoctorDto doctorDto)
        {
            var doctor = new Doctor
            {
                FirstName = doctorDto.FirstName,
                LastName = doctorDto.LastName,
                Specialty = doctorDto.Specialty,
            };
            return _doctorRepository.CreateNewDoctorAsync(doctor);
        }

        public Task DeleteDoctorAsync(int id) => _doctorRepository.DeleteDoctorAsync(id);
        public Task UpdateDoctorAsync(int id, DoctorDto doctorDto)
        {
            var doctor = new Doctor
            {
                FirstName = doctorDto.FirstName,
                Id = doctorDto.Id,
                LastName = doctorDto.LastName,
                Specialty = doctorDto.Specialty
            };
            return _doctorRepository.UpdateDoctorAsync(id, doctor);
        }
        public bool CheckIfDoctorExists(int? id) => _doctorRepository.CheckIfDoctorExists(id);
        public async Task<List<DoctorDto>> GetDoctorsBySpecialtyAsync(DoctorSpecialty doctorSpecialty)
        {
            var doctors = await _doctorRepository.GetDoctorsBySpecialtyAsync(doctorSpecialty);
            return doctors.Select(d => new DoctorDto
            {
                Specialty = d.Specialty,
                FirstName = d.FirstName,
                Id = d.Id,
                LastName = d.LastName
            }).ToList();
        }

    }
}
