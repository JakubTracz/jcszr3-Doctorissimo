using System;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using BLL.DTO;
using BLL.IServices;
using DAL.Enums;
using Doctorissimo.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace Doctorissimo.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IPatientService _patientService;
        private readonly IDoctorService _doctorService;
        private readonly IRoomService _roomService;

        public AppointmentsController(
            IAppointmentService appointmentService,
            IPatientService patientService,
            IDoctorService doctorService,
            IRoomService roomService,
            IMappingService mappingService)
        {
            _appointmentService = appointmentService;
            _patientService = patientService;
            _doctorService = doctorService;
            _roomService = roomService;
        }

        public async Task<IActionResult> Index(string sortOrder, string currentSort, string currentFilter, string searchString, int? page)
        {
            ViewBag.currentSort = sortOrder;
            ViewBag.dateSortOrder = sortOrder == "date_desc" ? "date" : "date_desc";
            ViewBag.patientSortOrder = sortOrder == "patient_desc" ? "patient" : "patient_desc";
            ViewBag.doctorSortOrder = sortOrder == "doctor_desc" ? "doctor" : "doctor_desc";
            ViewBag.roomSortOrder = sortOrder == "room_desc" ? "room" : "room_desc";

            var pageNumber = page ?? 1;
            const int pageSize = 10;
            var appointmentDtos = await _appointmentService.GetAllAppointmentsAsync();
            switch (sortOrder)
            {
                case "date":
                    appointmentDtos = await appointmentDtos.OrderBy(a => a.AppointmentTime).ToListAsync();
                    break;
                case "date_desc":
                    appointmentDtos = await appointmentDtos.OrderByDescending(a => a.AppointmentTime).ToListAsync();
                    break;
                case "doctor":
                    appointmentDtos = await appointmentDtos.OrderBy(a => a.DoctorDto.FullName).ToListAsync();
                    break;
                case "doctor_desc":
                    appointmentDtos = await appointmentDtos.OrderByDescending(a => a.DoctorDto.FullName).ToListAsync();
                    break;
                case "patient":
                    appointmentDtos = await appointmentDtos.OrderBy(a => a.PatientDto?.FullName).ToListAsync();
                    break;
                case "patient_desc":
                    appointmentDtos = await appointmentDtos.OrderByDescending(a => a.PatientDto?.FullName).ToListAsync();
                    break;
                case "room":
                    appointmentDtos = await appointmentDtos.OrderBy(a => a.RoomDto.Name).ToListAsync();
                    break;
                case "room_desc":
                    appointmentDtos = await appointmentDtos.OrderByDescending(a => a.RoomDto.Name).ToListAsync();
                    break;
            };

            var models = appointmentDtos
                .Select(a => new AppointmentsListViewModel
                {
                    AppointmentStatus = a.AppointmentStatus,
                    AppointmentTime = a.AppointmentTime,
                    RoomId = a.RoomDto.Id,
                    PatientId = a.PatientDto?.Id,
                    DoctorId = a.DoctorDto.Id,
                    DoctorFullName = a.DoctorDto.FullName,
                    Id = a.Id,
                    RoomName = a.RoomDto.Name,
                    PatientFullName = a.PatientDto?.FullName ?? string.Empty
                }).ToList();

            return View(models.ToPagedList(pageNumber, pageSize));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return BadRequest();
            var appointmentDto = await _appointmentService.GetByIdAsync(id);
            if (appointmentDto == null) return NotFound();
            return View(appointmentDto);
        }

        public async Task<IActionResult> Create(int selectedDoctorId, int selectedRoomId, DateTime selectedAppointmentDate)
        {
            var doctorDtos = await _doctorService.GetAllDoctorsAsync();
            var roomDtos = await _roomService.GetAllRoomsAsync();

            if (selectedAppointmentDate == default) selectedAppointmentDate = DateTime.Now;

            var model = new CreateAppointmentViewModel
            {
                Doctors = doctorDtos,
                Rooms = roomDtos,
                SelectedRoomId = selectedRoomId,
                SelectedDoctorId = selectedDoctorId,
                Appointment = new AppointmentDto { AppointmentTime = selectedAppointmentDate }
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateAppointmentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Create), new
                {
                    selectedDoctorId = model.SelectedDoctorId,
                    selectedRoomId = model.SelectedRoomId,
                    selectedAppointmentDate = model.Appointment.AppointmentTime
                });
            }

            var appointmentDto = model.Appointment;
            appointmentDto.DoctorId = model.SelectedDoctorId;
            appointmentDto.RoomId = model.SelectedRoomId;
            await _appointmentService.CreateAsync(appointmentDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DoctorEdit(int? id)
        {
            if (id == null) return BadRequest();

            var appointmentDto = await _appointmentService.GetByIdAsync(id);

            if (appointmentDto == null) return NotFound();

            return View(appointmentDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DoctorEdit(int id, AppointmentDto appointmentDto)
        {
            if (id != appointmentDto.Id) return BadRequest();
            if (!ModelState.IsValid) return View(appointmentDto);

            await _appointmentService.UpdateAsync(id, appointmentDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> AdminEdit(int? id)
        {
            if (id == null) return BadRequest();

            var appointmentDto = await _appointmentService.GetByIdAsync(id);

            if (appointmentDto == null) return NotFound();

            var doctorDtos = await _doctorService.GetAllDoctorsAsync();
            var patientDtos = await _patientService.GetAllPatientsAsync();
            var roomDtos = await _roomService.GetAllRoomsAsync();
            var doctorDto = await _doctorService.GetDoctorByIdAsync(appointmentDto.DoctorDto.Id);
            var roomDto = await _roomService.GetRoomByIdAsync(appointmentDto.RoomDto.Id);
            var patientDto = await _patientService.GetPatientByIdAsync(appointmentDto.PatientDto.Id);

            var model = new AdminEditAppointmentViewModel
            {
                Appointment = appointmentDto,
                Room = roomDto,
                Doctors = doctorDtos,
                Rooms = roomDtos,
                Doctor = doctorDto,
                Patient = patientDto,
                Patients = patientDtos
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AdminEdit(int id, AdminEditAppointmentViewModel model)
        {
            var appointmentDto = model.Appointment;
            try
            {
                await _appointmentService.UpdateAsync(id, appointmentDto);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_appointmentService.CheckIfExists(appointmentDto.Id)) return NotFound();
                throw;
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return BadRequest();

            var appointmentDto = await _appointmentService.GetByIdAsync(id);

            if (appointmentDto == null) return NotFound();

            return View(appointmentDto);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _appointmentService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> BookAppointment(int id)
        {
            var appointmentDto = await _appointmentService.GetByIdAsync(id);
            var patientDtos = await _patientService.GetAllPatientsAsync();

            if (appointmentDto == null || patientDtos == null) return NotFound();

            BookAppointmentViewModel bookAppointmentViewModel = new()
            {
                Appointment = appointmentDto,
                Patients = patientDtos,
            };
            return View(bookAppointmentViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BookAppointment(BookAppointmentViewModel model)
        {
            var appointmentBooked = _appointmentService.CheckIfAppointmentIsBooked(model.Appointment.Id);
            if (!ModelState.IsValid || appointmentBooked)
            {
                var patientDtos = await _patientService.GetAllPatientsAsync();
                model.Patients = patientDtos;
                ViewBag.AppointmentStatus = AppointmentStatus.Booked;
                return View(model);
                //return RedirectToAction(nameof(BookAppointment()));
            }

            var appointment = model.Appointment;
            await _appointmentService.AssignPatientToAppointment(appointment.Id, model.SelectedPatientId);
            return RedirectToAction(nameof(Index));
        }
    }
}
