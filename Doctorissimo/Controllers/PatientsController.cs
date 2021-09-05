using System.Threading.Tasks;
using BLL.IServices;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Doctorissimo.Controllers
{
    public class PatientsController : Controller
    {
        private readonly IPatientService _patientService;

        public PatientsController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        // GET: patients
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _patientService.GetAllPatientsAsync());
        //}

        // GET: patients/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var patient = await _patientService.GetPatientByIdAsync(id);
        //    if (patient == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(patient);
        //}

        //// GET: patients/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: patients/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,DateOfBirth,MailAddress,Address,Appointments,Prescriptions")] Patient patient)
        //{
        //    if (!ModelState.IsValid) return View(patient);
        //    await _patientService.AddNewPatientAsync(patient);
        //    return RedirectToAction(nameof(Index));
        //}

        //// GET: patients/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var patient = await _patientService.GetPatientByIdAsync(id);
        //    if (patient == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(patient);
        //}

        //// POST: patients/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,DateOfBirth,MailAddress,Address,Appointments,Prescriptions")] Patient patient)
        //{
        //    if (id != patient.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (!ModelState.IsValid) return View(patient);
        //    try
        //    {
        //        await _patientService.UpdatePatientAsync(id,patient);
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!_patientService.CheckIfPatientExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }
        //    return RedirectToAction(nameof(Index));
        //}

        //// GET: patients/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var patient = await _patientService.GetPatientByIdAsync(id);
        //    if (patient == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(patient);
        //}

        //// POST: patients/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    await _patientService.DeletePatientAsync(id);
        //    return RedirectToAction(nameof(Index));
        //}
    }
}
