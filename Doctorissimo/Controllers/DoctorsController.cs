using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using BLL.IServices;
using DAL.Enums;
using DAL.Models;
using Doctorissimo.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Doctorissimo.Controllers
{
    public class DoctorsController : Controller
    {
        private readonly IDoctorService _doctorService;

        public DoctorsController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        //// GET: doctors
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _doctorService.GetAllDoctorsAsync());
        //}
        //public async Task<IActionResult> PatientsViewIndex(Doctor doctor)
        //{
        //    var doctors = await _doctorService.GetDoctorsBySpecialtyAsync(doctor.Specialty);
        //    var patientSearchDoctorsViewModel = new PatientSearchDoctorsViewModel()
        //    {
        //        DoctorSpecialty = doctor.Specialty,
        //        Doctors = doctors
        //    };
        //    return View(patientSearchDoctorsViewModel);
        //}

        //// GET: doctors/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var doctor = await _doctorService.GetDoctorByIdAsync(id);
        //    if (doctor == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(doctor);
        //}

        //// GET: doctors/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: doctors/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Specialty")] Doctor doctor)
        //{
        //    if (!ModelState.IsValid) return View(doctor);
        //    await _doctorService.AddNewDoctorAsync(doctor);
        //    return RedirectToAction(nameof(Index));
        //}

        //// GET: doctors/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var doctor = await _doctorService.GetDoctorByIdAsync(id);
        //    if (doctor == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(doctor);
        //}

        //// POST: doctors/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Specialty")] Doctor doctor)
        //{
        //    if (id != doctor.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (!ModelState.IsValid) return View(doctor);
        //    try
        //    {
        //        await _doctorService.UpdateDoctorAsync(id,doctor);
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!_doctorService.CheckIfDoctorExists(id))
        //        {
        //            return NotFound();
        //        }

        //        throw;
        //    }
        //    return RedirectToAction(nameof(Index));
        //}

        //// GET: doctors/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var doctor = await _doctorService.GetDoctorByIdAsync(id);
        //    if (doctor == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(doctor);
        //}

        //// POST: doctors/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    await _doctorService.DeleteDoctorAsync(id);
        //    return RedirectToAction(nameof(Index));
        //}

        //public IActionResult PatientSearchDoctors()
        //{
        //    return View();
        //}
        //public async Task<IActionResult> PatientSearchDoctorsResult(Doctor doctor)
        //{
        //    var doctors = await _doctorService.GetDoctorsBySpecialtyAsync(doctor.Specialty);
        //    var patientSearchDoctorsViewModel = new PatientSearchDoctorsViewModel()
        //    {
        //        DoctorSpecialty = doctor.Specialty,
        //        Doctors = doctors
        //    };
        //    return View(patientSearchDoctorsViewModel);
        //}
    }
}
