using System.Threading.Tasks;
using BLL.IServices;
using DAL.Models;
using Doctorissimo.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Doctorissimo.Controllers
{
    public class RoomsController : Controller
    {
        private readonly IRoomService _roomService;
        private readonly IMappingService _mappingService;

        public RoomsController(IRoomService roomService, IMappingService mappingService)
        {
            _roomService = roomService;
            _mappingService = mappingService;
        }

        public async Task<IActionResult> Index()
        {
            var roomDtos = await _roomService.GetAllRoomsAsync();
            var rooms = _mappingService.MapRoomDtosToRoomsList(roomDtos);
            return View(rooms);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomDto = await _roomService.GetRoomByIdAsync(id);
            if (roomDto == null)
            {
                return NotFound();
            }
            var room = _mappingService.MapRoomDtoToRoom(roomDto);
            var appointmentDtos = await _roomService.GetAllAppointmentsInSelectedRoom(id);
            var appointments = _mappingService.MapAppointmentDtosToAppointmentsList(appointmentDtos);
            var roomDetailsViewModel = new RoomDetailsViewModel()
            {
                Id = room.Id,
                Appointments = appointments,
                Name = room.Name
            };
            return View(roomDetailsViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Room room)
        {
            if (!ModelState.IsValid) return View(room);
            var roomDto = _mappingService.MapRoomToRoomDto(room);
            await _roomService.AddNewRoomAsync(roomDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomDto = await _roomService.GetRoomByIdAsync(id);
            if (roomDto == null)
            {
                return NotFound();
            }
            var room = _mappingService.MapRoomDtoToRoom(roomDto);
            return View(room);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Room room)
        {
            if (id != room.Id)
            {
                return NotFound();
            }
            var roomDto = _mappingService.MapRoomToRoomDto(room);
            if (!ModelState.IsValid) return View(room);
            try
            {
                await _roomService.UpdateRoomAsync(id, roomDto);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_roomService.CheckIfRoomExists(id))
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

            var roomDto = await _roomService.GetRoomByIdAsync(id);
            if (roomDto == null)
            {
                return NotFound();
            }
            var room = _mappingService.MapRoomDtoToRoom(roomDto);
            return View(room);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _roomService.DeleteRoomAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}