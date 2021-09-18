using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTO;
using BLL.IServices;
using DAL.Enums;
using DAL.Models;
using Doctorissimo.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Doctorissimo.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IPatientService _patientService;
        private readonly IDoctorService _doctorService;
        private readonly IRoomService _roomService;
        private readonly IMappingService _mappingService;
        private readonly IMapper _mapper;

        public AppointmentsController(IAppointmentService appointmentService, IPatientService patientService, IDoctorService doctorService, IRoomService roomService, IMapper mapper, IMappingService mappingService)
        {
            _appointmentService = appointmentService;
            _patientService = patientService;
            _doctorService = doctorService;
            _roomService = roomService;
            _mapper = mapper;
            _mappingService = mappingService;
        }

        public async Task<IActionResult> Index()
        {
            var appointmentDtos = await _appointmentService.GetAllAppointmentsAsync();
            var appointmentsListViewModels =  _mapper.Map<List<AppointmentDto>,List<AppointmentsListViewModel>>(appointmentDtos);
            //var appointmentsListViewModels = appointmentDtos
            //    .Select(a => new AppointmentsListViewModel
            //    {      
            //        AppointmentStatus = a.AppointmentStatus,
            //        AppointmentTime = a.AppointmentTime,
            //        RoomId = a.RoomDto.Id,
            //        PatientId = a.PatientDto.Id,
            //        DoctorId = a.DoctorDto.Id,
            //        DoctorFullName = a.DoctorDto.FullName,
            //        Id = a.Id,
            //        RoomName = a.RoomDto.Name,
            //        PatientFullName = a.PatientDto.FullName ?? string.Empty
            //    }).ToList();

            return View(appointmentsListViewModels);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointmentDto = await _appointmentService.GetByIdAsync(id);
            if (appointmentDto == null)
            {
                return NotFound();
            }
            var roomDto = await _roomService.GetRoomByIdAsync(appointmentDto.RoomId);
            var appointment = _mappingService.MapAppointmentDtoToAppointment(appointmentDto);
            appointment.Room = _mappingService.MapRoomDtoToRoom(roomDto);
            return View(appointment);
        }

        public async Task<IActionResult> Create()
        {
            var doctorDtos = await _doctorService.GetAllDoctorsAsync();
            var roomDtos = await _roomService.GetAllRoomsAsync();
            var doctors = _mappingService.MapDoctorDtosToDoctorsList(doctorDtos);
            var rooms = _mappingService.MapRoomDtosToRoomsList(roomDtos);

            var createAppointmentViewModel = new CreateAppointmentViewModel { Doctors = doctors, Rooms = rooms };
            return View(createAppointmentViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateAppointmentViewModel createAppointmentViewModel)
        {
            if (!ModelState.IsValid)
            {
                var doctorDtos = await _doctorService.GetAllDoctorsAsync();
                var roomDtos = await _roomService.GetAllRoomsAsync();
                var doctors = _mappingService.MapDoctorDtosToDoctorsList(doctorDtos);
                var rooms = _mappingService.MapRoomDtosToRoomsList(roomDtos);
                createAppointmentViewModel.Doctors = doctors;
                createAppointmentViewModel.Rooms = rooms;
                return View(createAppointmentViewModel);
            }

            var appointment = createAppointmentViewModel.Appointment;
            appointment.DoctorId = createAppointmentViewModel.SelectedDoctorId;
            appointment.RoomId = createAppointmentViewModel.SelectedRoomId;
            var appointmentDto = _mappingService.MapAppointmentToAppointmentDto(appointment);

            await _appointmentService.CreateAsync(appointmentDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DoctorEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointmentDto = await _appointmentService.GetByIdAsync(id);

            if (appointmentDto == null)
            {
                return NotFound();
            }

            var appointment = _mappingService.MapAppointmentDtoToAppointment(appointmentDto);
            return View(appointment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DoctorEdit(int id, AppointmentDto appointmentDto)
        {
            if (id != appointmentDto.Id)
            {
                return NotFound();
            }
            var appointment = _mappingService.MapAppointmentDtoToAppointment(appointmentDto);
            if (!ModelState.IsValid) return View(appointment);
            await _appointmentService.UpdateAsync(id, appointmentDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> AdminEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointmentDto = await _appointmentService.GetByIdAsync(id);
            if (appointmentDto == null)
            {
                return NotFound();
            }

            var doctorDtos = await _doctorService.GetAllDoctorsAsync();
            var patientDtos = await _patientService.GetAllPatientsAsync();
            var roomDtos = await _roomService.GetAllRoomsAsync();
            var doctorDto = await _doctorService.GetDoctorByIdAsync(appointmentDto.DoctorDto.Id);
            var roomDto = await _roomService.GetRoomByIdAsync(appointmentDto.RoomDto.Id);
            var patientDto = await _patientService.GetPatientByIdAsync(appointmentDto.PatientDto.Id);

            var appointment = _mappingService.MapAppointmentDtoToAppointment(appointmentDto);
            var patients = _mappingService.MapPatientDtosToPatientsList(patientDtos);
            var doctors = _mappingService.MapDoctorDtosToDoctorsList(doctorDtos);
            var rooms = _mappingService.MapRoomDtosToRoomsList(roomDtos);
            var selectedDoctor = _mappingService.MapDoctorDtoToDoctor(doctorDto);
            var selectedPatient = _mappingService.MapPatientDtoToPatient(patientDto);
            var selectedRoom = _mappingService.MapRoomDtoToRoom(roomDto);
            var adminEditAppointmentViewModel = new AdminEditAppointmentViewModel
            {
                Appointment = appointment,
                Room = selectedRoom,
                Doctors = doctors,
                Rooms = rooms,
                Doctor = selectedDoctor,
                Patient = selectedPatient,
                Patients = patients
            };
            return View(adminEditAppointmentViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AdminEdit(int id, AdminEditAppointmentViewModel adminEditAppointmentViewModel)
        {
            var appointment = adminEditAppointmentViewModel.Appointment;
            var appointmentDto = _mapper.Map<Appointment, AppointmentDto>(appointment);
            try
            {
                await _appointmentService.UpdateAsync(id, appointmentDto);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_appointmentService.CheckIfExists(appointmentDto.Id))
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

            var appointmentDto = await _appointmentService.GetByIdAsync(id);
            if (appointmentDto == null)
            {
                return NotFound();
            }
            var appointment = _mappingService.MapAppointmentDtoToAppointment(appointmentDto);
            return View(appointment);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _appointmentService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> BookAppointment(int id, int doctorId, int roomId)
        {
            {
                var appointmentDto = await _appointmentService.GetByIdAsync(id);
                if (appointmentDto == null)
                {
                    return NotFound();
                }
                var patientDtos = await _patientService.GetAllPatientsAsync();
                if (patientDtos == null)
                {
                    return NotFound();
                }

                var appointment = _mappingService.MapAppointmentDtoToAppointment(appointmentDto);
                var patients = _mappingService.MapPatientDtosToPatientsList(patientDtos);
                BookAppointmentViewModel bookAppointmentViewModel = new()
                {
                    Appointment = appointment,
                    Patients = patients,
                    
                };
                return View(bookAppointmentViewModel);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BookAppointment(BookAppointmentViewModel bookAppointmentViewModel)
        {
            var appointmentBooked =
                _appointmentService.CheckIfAppointmentIsBooked(bookAppointmentViewModel.Appointment.Id);
            if (!ModelState.IsValid || appointmentBooked)
            {
                var patientDtos = await _patientService.GetAllPatientsAsync();
                var patients = _mappingService.MapPatientDtosToPatientsList(patientDtos);
                bookAppointmentViewModel.Patients = patients;
                ViewBag.AppointmentStatus = AppointmentStatus.Booked;
                return View(bookAppointmentViewModel);
            }

            var appointment = bookAppointmentViewModel.Appointment;
            await _appointmentService.AssignPatientToAppointment(appointment.Id, bookAppointmentViewModel.SelectedPatientId);
            return RedirectToAction(nameof(Index));
        }
    }
}
