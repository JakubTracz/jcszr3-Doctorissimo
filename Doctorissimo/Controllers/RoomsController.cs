using System.Threading.Tasks;
using BLL.IServices;
using DAL.Models;
using DAL.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Doctorissimo.Controllers
{
    public class RoomsController : Controller
    {
        private readonly IRoomService _roomService;

        public RoomsController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        // GET: rooms
        public async Task<IActionResult> Index()
        {
            return View(await _roomService.GetAllRoomsAsync());
        }

        // GET: rooms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await _roomService.GetRoomByIdAsync(id);
            if (room == null)
            {
                return NotFound();
            }

            var appointments = await _roomService.GetAllAppointmentsInSelectedRoom(id);
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
            await _roomService.AddNewRoomAsync(room);
            return RedirectToAction(nameof(Index));
        }

        // GET: rooms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await _roomService.GetRoomByIdAsync(id);
            if (room == null)
            {
                return NotFound();
            }
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

            if (!ModelState.IsValid) return View(room);
            try
            {
                await _roomService.UpdateRoomAsync(id,room);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_roomService.CheckIfRoomExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
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

            var room = await _roomService.GetRoomByIdAsync(id);
            if (room == null)
            {
                return NotFound();
            }

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