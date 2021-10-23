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
    [Authorize]
    public class LoaiSachController : Controller
    {
        private readonly AppDbContext _context;

        public LoaiSachController(AppDbContext context)
        {
            _context = context;
        }

        // GET: LoaiSach
        public async Task<IActionResult> Index()
        {
            return View(await _context.LoaiSach.ToListAsync());
        }

        // GET: LoaiSach/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiSach = await _context.LoaiSach
                .FirstOrDefaultAsync(m => m.Id == id);
            if (loaiSach == null)
            {
                return NotFound();
            }

            return View(loaiSach);
        }

        // GET: LoaiSach/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LoaiSach/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MaLoaiSach,TenLoaiSach")] LoaiSach loaiSach)
        {
            if (ModelState.IsValid)
            {
                _context.Add(loaiSach);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(loaiSach);
        }

        // GET: LoaiSach/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiSach = await _context.LoaiSach.FindAsync(id);
            if (loaiSach == null)
            {
                return NotFound();
            }
            return View(loaiSach);
        }

        // POST: LoaiSach/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MaLoaiSach,TenLoaiSach")] LoaiSach loaiSach)
        {
            if (id != loaiSach.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loaiSach);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoaiSachExists(loaiSach.Id))
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
            return View(loaiSach);
        }

        // GET: LoaiSach/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiSach = await _context.LoaiSach
                .FirstOrDefaultAsync(m => m.Id == id);
            if (loaiSach == null)
            {
                return NotFound();
            }

            return View(loaiSach);
        }

        // POST: LoaiSach/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var loaiSach = await _context.LoaiSach.FindAsync(id);
            _context.LoaiSach.Remove(loaiSach);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoaiSachExists(int id)
        {
            return _context.LoaiSach.Any(e => e.Id == id);
        }


        [HttpGet("/api/LoaiSach/GetAll")]
        public IEnumerable<LoaiSach> GetAll() => _context.LoaiSach.ToList();
    }
}
