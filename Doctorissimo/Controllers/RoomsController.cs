using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTO;
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
        private readonly IMapper _mapper;

        public RoomsController(IRoomService roomService, IMapper mapper)
        {
            _roomService = roomService;
            _mapper = mapper;
        }

        // GET: rooms
        public async Task<IActionResult> Index()
        {
            var roomDtos = await _roomService.GetAllRoomsAsync();
            var rooms = _mapper.Map<List<RoomDto>, List<Room>>(roomDtos);
            return View(rooms);
        }

        // GET: rooms/Details/5
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
            var room = _mapper.Map<RoomDto, Room>(roomDto);
            var appointmentDtos = await _roomService.GetAllAppointmentsInSelectedRoom(id);
            var appointments = _mapper.Map<List<AppointmentDto>, List<Appointment>>(appointmentDtos);
            var roomDetailsViewModel = new RoomDetailsViewModel()
            {
                Id = room.Id,
                Appointments = appointments,
                Name = room.Name
            };
            return View(roomDetailsViewModel);
        }

        // GET: rooms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: rooms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Room room)
        {
            if (!ModelState.IsValid) return View(room);
            var roomDto = _mapper.Map<Room, RoomDto>(room);
            await _roomService.AddNewRoomAsync(roomDto);
            return RedirectToAction(nameof(Index));
        }

        // GET: rooms/Edit/5
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
            var room = _mapper.Map<RoomDto, Room>(roomDto);
            return View(room);
        }

        // POST: rooms/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Room room)
        {
            if (id != room.Id)
            {
                return NotFound();
            }
            var roomDto = _mapper.Map<Room, RoomDto>(room);
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

        // GET: rooms/Delete/5
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
            var room = _mapper.Map<RoomDto, Room>(roomDto);
            return View(room);
        }

        // POST: rooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _roomService.DeleteRoomAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}