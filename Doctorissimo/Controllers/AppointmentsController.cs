using System.Collections.Generic;
using System.Linq;
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
        private readonly IMapper _mapper;

        public AppointmentsController(IAppointmentService appointmentService, IPatientService patientService, IDoctorService doctorService, IRoomService roomService, IMapper mapper)
        {
            _appointmentService = appointmentService;
            _patientService = patientService;
            _doctorService = doctorService;
            _roomService = roomService;
            _mapper = mapper;
        }

        //GET: Appointments
        public async Task<IActionResult> Index()
        {
            var appointmentDtos = await _appointmentService.GetAllAppointmentsAsync();
            var appointmentsListViewModels = appointmentDtos
                .Select(a => new AppointmentsListViewModel
                {
                    AppointmentStatus = a.AppointmentStatus,
                    AppointmentTime = a.AppointmentTime,
                    RoomId = a.RoomDto.Id,
                    PatientId = a.PatientDto.Id,
                    DoctorId = a.DoctorDto.Id,
                    DoctorFullName = a.DoctorDto.FullName,
                    Id = a.Id,
                    RoomName = a.RoomDto.Name,
                    PatientFullName = a.PatientDto.FullName
                }).ToList();

            return View(appointmentsListViewModels);
        } 

        // GET: Appointments/Details/5
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
            var appointment = _mapper.Map<AppointmentDto,Appointment>(appointmentDto);
            appointment.Room = _mapper.Map<RoomDto, Room>(roomDto);
            return View(appointment);
        }

        // GET: Appointments/Create
        public async Task<IActionResult> Create()
        {
            var doctorDtos = await _doctorService.GetAllDoctorsAsync();
            var roomDtos = await _roomService.GetAllRoomsAsync();
            var doctors = _mapper.Map<List<DoctorDto>, List<Doctor>>(doctorDtos);
            var rooms = _mapper.Map<List<RoomDto>, List<Room>>(roomDtos);

            var createAppointmentViewModel = new CreateAppointmentViewModel { Doctors = doctors, Rooms = rooms };
            return View(createAppointmentViewModel);
        }

        //POST: Appointments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateAppointmentViewModel createAppointmentViewModel)
        {
            if (!ModelState.IsValid) return View(createAppointmentViewModel);
            //_appointmentService.PopulateAppointmentModel(createAppointmentViewModel);

            var appointment = createAppointmentViewModel.Appointment;
            appointment.AppointmentStatus = AppointmentStatus.Available;
            appointment.DoctorId = createAppointmentViewModel.SelectedDoctorId;
            appointment.RoomId = createAppointmentViewModel.SelectedRoomId;
            appointment.PatientId = null;

            var appointmentDto = _mapper.Map<Appointment, AppointmentDto>(appointment);

            await _appointmentService.CreateAsync(appointmentDto);
            return RedirectToAction(nameof(Index));
        }
        // GET: Appointments/Edit/5
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
            var appointment = _mapper.Map<AppointmentDto,Appointment>(appointmentDto);
            return View(appointment);
        }

        // POST: Appointments/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DoctorEdit(int id, AppointmentDto appointmentDto)
        {
            if (id != appointmentDto.Id)
            {
                return NotFound();
            }
            var appointment = _mapper.Map<AppointmentDto,Appointment>(appointmentDto);
            if (!ModelState.IsValid) return View(appointment);
            await _appointmentService.UpdateAsync(id, appointmentDto);
            return RedirectToAction(nameof(Index));
        }

        // GET: Appointments/Edit/5
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

            var appointment = _mapper.Map<AppointmentDto,Appointment>(appointmentDto);
            var patients = _mapper.Map<List<PatientDto>, List<Patient>>(patientDtos);
            var doctors = _mapper.Map<List<DoctorDto>, List<Doctor>>(doctorDtos);
            var rooms = _mapper.Map<List<RoomDto>, List<Room>>(roomDtos);
            var selectedDoctor = _mapper.Map<DoctorDto, Doctor>(doctorDto);
            var selectedPatient = _mapper.Map<PatientDto, Patient>(patientDto);
            var selectedRoom = _mapper.Map<RoomDto, Room>(roomDto);

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

        // POST: Appointments/Edit/5
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

        // GET: Appointments/Delete/5
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
            var appointment = _mapper.Map<AppointmentDto, Appointment>(appointmentDto);
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
                var doctorDto = await _doctorService.GetDoctorByIdAsync(doctorId);
                if (doctorDto == null)
                {
                    return NotFound();
                }
                var roomDto = await _roomService.GetRoomByIdAsync(roomId);
                if (roomDto == null)
                {
                    return NotFound();
                }

                var appointment = _mapper.Map<AppointmentDto,Appointment>(appointmentDto);
                var patients = _mapper.Map<List<PatientDto>, List<Patient>>(patientDtos);
                var doctor = _mapper.Map<DoctorDto, Doctor>(doctorDto);
                var room = _mapper.Map<RoomDto, Room>(roomDto);
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
