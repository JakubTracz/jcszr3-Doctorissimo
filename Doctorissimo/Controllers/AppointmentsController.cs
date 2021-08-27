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
        private readonly IDoctorService _doctorService;
        private readonly IRoomService _roomService;

        public AppointmentsController(IAppointmentService appointmentService, IPatientService patientService, IDoctorService doctorService, IRoomService roomService)
        {
            _appointmentService = appointmentService;
            _patientService = patientService;
            _doctorService = doctorService;
            _roomService = roomService;
        }

        // GET: Appointments
        public async Task<IActionResult> Index()
        {
            return View(await _appointmentService.GetAppointmentsWithDoctorsAsync());
        }

        // GET: Appointments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _appointmentService.GetByIdAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // GET: Appointments/Create
        public async Task<IActionResult> Create()
        {
            var doctors = await _doctorService.GetAllDoctorsAsync();
            var rooms = await _roomService.GetAllRoomsAsync();
            var createAppointmentViewModel = new CreateAppointmentViewModel { Doctors = doctors, Rooms = rooms };
            return View(createAppointmentViewModel);
        }

        //POST: Appointments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateAppointmentViewModel createAppointmentViewModel)
        {
            if (!ModelState.IsValid) return View(createAppointmentViewModel);
            var appointment = _appointmentService.PopulateAppointmentModel(createAppointmentViewModel);
            await _appointmentService.CreateAsync(appointment);
            return RedirectToAction(nameof(Index));
        }
        // GET: Appointments/Edit/5
        public async Task<IActionResult> DoctorEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _appointmentService.GetByIdAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }
            return View(appointment);
        }

        // POST: Appointments/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DoctorEdit(int id, [Bind("Id,AppointmentStatus,Recommendations")] Appointment appointment)
        {
            if (id != appointment.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid) return View(appointment);
            try
            {
                await _appointmentService.UpdateAsync(id, appointment);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_appointmentService.CheckIfExists(appointment.Id))
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

            var appointment = await _appointmentService.GetByIdAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }

            var doctors = await _doctorService.GetAllDoctorsAsync();
            var rooms = await _roomService.GetAllRoomsAsync();
            var selectedDoctor = await _doctorService.GetDoctorByIdAsync(appointment.DoctorId);
            var selectedRoom = await _roomService.GetRoomByIdAsync(appointment.RoomId);
            var adminEditAppointmentViewModel = new AdminEditAppointmentViewModel()
            {
                Appointment = appointment,
                Room = selectedRoom,
                Doctor = selectedDoctor,
                Doctors = doctors,
                Rooms = rooms
            };
            return View(adminEditAppointmentViewModel);
        }

        // POST: Appointments/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AdminEdit(int id, [Bind("Id,AppointmentStatus,Doctor,Patient,AppointmentTime,Room")] AdminEditAppointmentViewModel adminEditAppointmentViewModel)
        {
            var appointment = adminEditAppointmentViewModel.Appointment;
            if (id != appointment.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid) return View(adminEditAppointmentViewModel);
            try
            {
                await _appointmentService.UpdateAsync(id, appointment);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_appointmentService.CheckIfExists(appointment.Id))
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

            var appointment = await _appointmentService.GetByIdAsync(id);
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
            await _appointmentService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> BookAppointment(int id,int doctorId,int roomId)
        {
            {
                var appointment = await _appointmentService.GetByIdAsync(id);
                if (appointment == null)
                {
                    return NotFound();
                }
                var patients = await _patientService.GetAllPatientsAsync();
                if (patients == null)
                {
                    return NotFound();
                }
                var doctor = await _doctorService.GetDoctorByIdAsync(doctorId);
                if (doctor == null)
                {
                    return NotFound();
                }
                var room = await _roomService.GetRoomByIdAsync(roomId);
                if (room == null)
                {
                    return NotFound();
                }

                BookAppointmentViewModel bookAppointmentViewModel = new()
                {
                    Appointment = appointment,
                    Doctor = doctor,
                    Patients = patients,
                    Room = room
                };
                return View(bookAppointmentViewModel);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BookAppointment(BookAppointmentViewModel bookAppointmentViewModel)
        {
            if (!ModelState.IsValid) return View(bookAppointmentViewModel);
            var appointment = bookAppointmentViewModel.Appointment;
            await _appointmentService.AssignPatientToAppointment(appointment.Id, bookAppointmentViewModel.SelectedPatientId);
            return RedirectToAction(nameof(Index));
        }
    }
}
