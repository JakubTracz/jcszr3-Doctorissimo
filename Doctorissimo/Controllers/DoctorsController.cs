using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTO;
using BLL.IServices;
using DAL.Models;
using Doctorissimo.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Doctorissimo.Controllers
{
    public class DoctorsController : Controller
    {
        private readonly IDoctorService _doctorService;
        private readonly IMapper _mapper;

        public DoctorsController(IDoctorService doctorService, IMapper mapper)
        {
            _doctorService = doctorService;
            _mapper = mapper;
        }

        // GET: doctors
        public async Task<IActionResult> Index()
        {
            var doctorDtos = await _doctorService.GetAllDoctorsAsync();
            var doctors = _mapper.Map<List<DoctorDto>, List<Doctor>>(doctorDtos);
            return View(doctors);
        }
        public async Task<IActionResult> PatientsViewIndex(Doctor doctor)
        {
            var doctorDtos = await _doctorService.GetDoctorsBySpecialtyAsync(doctor.Specialty);
            var doctors = _mapper.Map<List<DoctorDto>, List<Doctor>>(doctorDtos);
            var patientSearchDoctorsViewModel = new PatientSearchDoctorsViewModel()
            {
                DoctorSpecialty = doctor.Specialty,
                Doctors = doctors
            };
            return View(patientSearchDoctorsViewModel);
        }

        // GET: doctors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctorDto = await _doctorService.GetDoctorByIdAsync(id);
            var doctor = _mapper.Map<DoctorDto, Doctor>(doctorDto);
            if (doctorDto == null)
            {
                return NotFound();
            }

            return View(doctor);
        }

        // GET: doctors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: doctors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Specialty")] Doctor doctor)
        {
            if (!ModelState.IsValid) return View(doctor);
            var doctorDto = _mapper.Map<Doctor, DoctorDto>(doctor);
            await _doctorService.AddNewDoctorAsync(doctorDto);
            return RedirectToAction(nameof(Index));
        }

        // GET: doctors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctorDto = await _doctorService.GetDoctorByIdAsync(id);
            if (doctorDto == null)
            {
                return NotFound();
            }
            var doctor = _mapper.Map<DoctorDto, Doctor>(doctorDto);
            return View(doctor);
        }

        // POST: doctors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Specialty")] Doctor doctor)
        {
            if (id != doctor.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid) return View(doctor);
            try
            {
                var doctorDto = _mapper.Map<Doctor, DoctorDto>(doctor);
                await _doctorService.UpdateDoctorAsync(id, doctorDto);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_doctorService.CheckIfDoctorExists(id))
                {
                    return NotFound();
                }

                throw;
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: doctors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctorDto = await _doctorService.GetDoctorByIdAsync(id);
            if (doctorDto == null)
            {
                return NotFound();
            }
            var doctor = _mapper.Map<DoctorDto, Doctor>(doctorDto);
            return View(doctor);
        }

        // POST: doctors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _doctorService.DeleteDoctorAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult PatientSearchDoctors()
        {
            return View();
        }
        public async Task<IActionResult> PatientSearchDoctorsResult(Doctor doctor)
        {
            var doctorDtos = await _doctorService.GetDoctorsBySpecialtyAsync(doctor.Specialty);
            var doctors = _mapper.Map<List<DoctorDto>, List<Doctor>>(doctorDtos);
            var patientSearchDoctorsViewModel = new PatientSearchDoctorsViewModel()
            {
                DoctorSpecialty = doctor.Specialty,
                Doctors = doctors
            };
            return View(patientSearchDoctorsViewModel);
        }
    }
}
