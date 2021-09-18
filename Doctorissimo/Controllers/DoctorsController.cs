using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using BLL.IServices;
using DAL.Models;
using Doctorissimo.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Doctorissimo.Controllers
{
    public class DoctorsController : Controller
    {
        private readonly IDoctorService _doctorService;
        private readonly IMappingService _mappingService;

        public DoctorsController(IDoctorService doctorService,IMappingService mappingService)
        {
            _doctorService = doctorService;
            _mappingService = mappingService;
        }

        public async Task<IActionResult> Index()
        {
            var doctorDtos = await _doctorService.GetAllDoctorsAsync();
            var doctors = _mappingService.MapDoctorDtosToDoctorsList(doctorDtos);
            return View(doctors);
        }
        public async Task<IActionResult> PatientsViewIndex(Doctor doctor)
        {
            var doctorDtos = await _doctorService.GetDoctorsBySpecialtyAsync(doctor.Specialty);
            var doctors = _mappingService.MapDoctorDtosToDoctorsList(doctorDtos);
            var patientSearchDoctorsViewModel = new PatientSearchDoctorsViewModel()
            {
                DoctorSpecialty = doctor.Specialty,
                Doctors = doctors
            };
            return View(patientSearchDoctorsViewModel);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctorDto = await _doctorService.GetDoctorByIdAsync(id);
            var doctor = _mappingService.MapDoctorDtoToDoctor(doctorDto);
            if (doctorDto == null)
            {
                return NotFound();
            }

            return View(doctor);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Specialty")] Doctor doctor)
        {
            if (!ModelState.IsValid) return View(doctor);
            var doctorDto = _mappingService.MapDoctorToDoctorDto(doctor);
            await _doctorService.AddNewDoctorAsync(doctorDto);
            return RedirectToAction(nameof(Index));
        }

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
            var doctor = _mappingService.MapDoctorDtoToDoctor(doctorDto);
            return View(doctor);
        }

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
                var doctorDto = _mappingService.MapDoctorToDoctorDto(doctor);
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
            var doctor = _mappingService.MapDoctorDtoToDoctor(doctorDto);
            return View(doctor);
        }

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
            var doctors = _mappingService.MapDoctorDtosToDoctorsList(doctorDtos);
            var patientSearchDoctorsViewModel = new PatientSearchDoctorsViewModel()
            {
                DoctorSpecialty = doctor.Specialty,
                Doctors = doctors
            };
            return View(patientSearchDoctorsViewModel);
        }
    }
}
