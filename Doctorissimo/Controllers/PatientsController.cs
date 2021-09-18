using System.Threading.Tasks;
using BLL.IServices;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Doctorissimo.Controllers
{
    public class PatientsController : Controller
    {
        private readonly IPatientService _patientService;
        private readonly IMappingService _mappingService;

        public PatientsController(IPatientService patientService, IMappingService mappingService)
        {
            _patientService = patientService;
            _mappingService = mappingService;
        }

        public async Task<IActionResult> Index()
        {
            var patientDtos = await _patientService.GetAllPatientsAsync();
            var patients = _mappingService.MapPatientDtosToPatientsList(patientDtos);
            return View(patients);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientDto = await _patientService.GetPatientByIdAsync(id);
            var patient = _mappingService.MapPatientDtoToPatient(patientDto);
            if (patientDto == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        public IActionResult Create()
        {
            return View();
        }

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
            var patientDto = _mappingService.MapPatientToPatientDto(patient);
            await _patientService.AddNewPatientAsync(patientDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientDto = await _patientService.GetPatientByIdAsync(id);
            var patient = _mappingService.MapPatientDtoToPatient(patientDto);
            if (patientDto == null)
            {
                return NotFound();
            }
            return View(patient);
        }

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
                var patientDto = _mappingService.MapPatientToPatientDto(patient);
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

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientDto = await _patientService.GetPatientByIdAsync(id);
            var patient = _mappingService.MapPatientDtoToPatient(patientDto);
            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _patientService.DeletePatientAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
