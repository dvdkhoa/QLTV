using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QLTV.AppMVC.Models;
using QLTV.AppMVC.Models.Entities;

namespace QLTV.AppMVC.Controllers
{
    [Authorize(Roles = "Admin,Librarian")]
    public class KeSachController : Controller
    {
        private readonly AppDbContext _context;

        [TempData]
        public string StatusMessage { get; set; }

        public KeSachController(AppDbContext context)
        {
            _context = context;
        }

        // GET: KeSach
        public async Task<IActionResult> Index()
        {
            return View(await _context.KeSach.ToListAsync());
        }

        // GET: KeSach/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var keSach = await _context.KeSach
                .FirstOrDefaultAsync(m => m.Id == id);
            if (keSach == null)
            {
                return NotFound();
            }

            return View(keSach);
        }

        // GET: KeSach/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: KeSach/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TenKeSach")] KeSach keSach)
        {
            if (ModelState.IsValid)
            {
                _context.Add(keSach);
                await _context.SaveChangesAsync();
                StatusMessage = $"Tạo thành công kệ sách: {keSach.TenKeSach}";
                return RedirectToAction(nameof(Index));
            }
            return View(keSach);
        }

        // GET: KeSach/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var keSach = await _context.KeSach.FindAsync(id);
            if (keSach == null)
            {
                return NotFound();
            }
            return View(keSach);
        }

        // POST: KeSach/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TenKeSach")] KeSach keSach)
        {
            if (id != keSach.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(keSach);
                    await _context.SaveChangesAsync();
                    StatusMessage = $"Cập nhật thành công kệ sách: {keSach.TenKeSach}";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KeSachExists(keSach.Id))
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
            return View(keSach);
        }

        // GET: KeSach/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var keSach = await _context.KeSach
                .FirstOrDefaultAsync(m => m.Id == id);
            if (keSach == null)
            {
                return NotFound();
            }

            return View(keSach);
        }

        // POST: KeSach/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var keSach = await _context.KeSach.FindAsync(id);
            bool exists = await _context.DauSach.AnyAsync(s => s.KeSach_Id == keSach.Id);
            if (exists)
            {
                StatusMessage = "Error: Không thể xóa kệ này!!";
                return RedirectToAction("Delete");
            }

            _context.KeSach.Remove(keSach);
            await _context.SaveChangesAsync();
            StatusMessage = $"Xóa thành công kệ sách: {keSach.TenKeSach}";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("/api/KeSach/GetAll")]
        public IEnumerable<KeSach> GetAll() => _context.KeSach.ToList();

        private bool KeSachExists(int id)
        {
            return _context.KeSach.Any(e => e.Id == id);
        }
    }
}
