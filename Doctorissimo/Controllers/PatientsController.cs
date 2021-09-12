using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTO;
using BLL.IServices;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Doctorissimo.Controllers
{
    public class PatientsController : Controller
    {
        private readonly IPatientService _patientService;
        private readonly IMapper _mapper;

        public PatientsController(IPatientService patientService, IMapper mapper)
        {
            _patientService = patientService;
            _mapper = mapper;
        }

        //GET: patients
        public async Task<IActionResult> Index()
        {
            var patientDtos = await _patientService.GetAllPatientsAsync();
            var patients = _mapper.Map<List<PatientDto>, List<Patient>>(patientDtos);
            return View(patients);
        }

        //GET: patients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientDto = await _patientService.GetPatientByIdAsync(id);
            var patient = _mapper.Map<PatientDto, Patient>(patientDto);
            if (patientDto == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        // GET: patients/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: patients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,DateOfBirth,MailAddress,Address")] Patient patient)
        {
            if (!ModelState.IsValid) return View(patient);
            var newPatientMail = patient.MailAddress;
            if (await _patientService.PatientWithProvidedEmailExists(newPatientMail))
            {
                ViewBag.ErrorMessage = "A user with the provided e-mail address already exists in the database.\n " +
                                       "Please try again or contact the administration.";
                return View();
            }
            var patientDto = _mapper.Map<Patient, PatientDto>(patient);
            await _patientService.AddNewPatientAsync(patientDto);
            return RedirectToAction(nameof(Index));
        }

        // GET: patients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientDto = await _patientService.GetPatientByIdAsync(id);
            var patient = _mapper.Map<PatientDto, Patient>(patientDto);
            if (patientDto == null)
            {
                return NotFound();
            }
            return View(patient);
        }

        // POST: patients/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,DateOfBirth,MailAddress,Address,Appointments,Prescriptions")] Patient patient)
        {
            if (id != patient.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid) return View(patient);
            try
            {
                var patientDto = _mapper.Map<Patient, PatientDto>(patient);
                await _patientService.UpdatePatientAsync(id, patientDto);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_patientService.CheckIfPatientExists(id))
                {
                    return NotFound();
                }

                throw;
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: patients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientDto = await _patientService.GetPatientByIdAsync(id);
            var patient = _mapper.Map<PatientDto, Patient>(patientDto);
            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        // POST: patients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _patientService.DeletePatientAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
