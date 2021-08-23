using System.Threading.Tasks;
using BLL.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL.Models;
using DAL.Models.ViewModels;

namespace Doctorissimo.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IPatientService _patientService;
        public AppointmentsController(IAppointmentService appointmentService, IPatientService patientService)
        {
            _appointmentService = appointmentService;
            _patientService = patientService;
        }

        // GET: Appointments
        public async Task<IActionResult> Index()
        {
            return View(await _appointmentService.GetAllAppointments());
        }

        // GET: Appointments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _appointmentService.GetAppointmentByIdAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // GET: Appointments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Appointments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AppointmentStatus,Doctor,AppointmentTime,Room")] Appointment appointment)
        {
            if (!ModelState.IsValid) return View(appointment);
            await _appointmentService.AddNewAppointmentAsync(appointment);
            return RedirectToAction(nameof(Index));
        }
        // GET: Appointments/Edit/5
        public async Task<IActionResult> DoctorEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _appointmentService.GetAppointmentByIdAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }
            return View(appointment);
        }

        // POST: Appointments/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DoctorEdit(int id, [Bind("Id,Doctor,Patient,AppointmentTime,Room")] Appointment appointment)
        {
            if (id != appointment.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid) return View(appointment);
            try
            {
                await _appointmentService.UpdateAppointmentAsync(id, appointment);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_appointmentService.CheckIfAppointmentExists(appointment.Id))
                {
                    return NotFound();
                }

                throw;
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Appointments/Edit/5
        public async Task<IActionResult> AdminEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _appointmentService.GetAppointmentByIdAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }
            return View(appointment);
        }

        // POST: Appointments/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AdminEdit(int id, [Bind("Id,Doctor,Patient,AppointmentTime,Room")] Appointment appointment)
        {
            if (id != appointment.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid) return View(appointment);
            try
            {
                await _appointmentService.UpdateAppointmentAsync(id, appointment);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_appointmentService.CheckIfAppointmentExists(appointment.Id))
                {
                    return NotFound();
                }

                throw;
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Appointments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _appointmentService.GetAppointmentByIdAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // POST: Appointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _appointmentService.DeleteAppointmentAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> BookAppointment(int id)
        {
            {
                var appointment = await _appointmentService.GetAppointmentByIdAsync(id);
                if (appointment == null)
                {
                    return NotFound();
                }

                BookAppointmentViewModel bookAppointmentViewModel = new(appointment);
                var patients = await _patientService.GetAllPatientsAsync();
                if (patients == null)
                {
                    return NotFound();
                }

                bookAppointmentViewModel.Patients = patients;
                return View(bookAppointmentViewModel);
            }
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> BookAppointment(int id, [Bind("Patient")] Appointment appointment)
        //{
        //    if (id != appointment.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (!ModelState.IsValid) return View(appointment);
        //    try
        //    {
        //        await _appointmentService.UpdateAppointment(id, appointment);
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!_appointmentService.CheckIfAppointmentExists(appointment.Id))
        //        {
        //            return NotFound();
        //        }

        //        throw;
        //    }
        //    return RedirectToAction(nameof(Index));
        //}
    }
}
