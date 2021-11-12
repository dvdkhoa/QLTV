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
    public class LopController : Controller
    {
        private readonly AppDbContext _context;

        public LopController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Lop
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpGet("/api/lop/getall")]
        public List<Lop> getAll()
        {
            return _context.Lop.ToList();
        }

        // GET: Lop/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lop = await _context.Lop
                .Include(l => l.Nganh)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lop == null)
            {
                return NotFound();
            }

            return View(lop);
        }

        // GET: Lop/Create
        public IActionResult Create()
        {
            ViewData["Nganh_Id"] = new SelectList(_context.Nganh, "Id", "TenNganh");
            return View();
        }

        // POST: Lop/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MaLop,Nganh_Id")] Lop lop)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lop);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Nganh_Id"] = new SelectList(_context.Nganh, "Id", "Id", lop.Nganh_Id);
            return View(lop);
        }

        // GET: Lop/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lop = await _context.Lop.FindAsync(id);
            if (lop == null)
            {
                return NotFound();
            }
            ViewData["Nganh_Id"] = new SelectList(_context.Nganh, "Id", "TenNganh", lop.Nganh_Id);
            return View(lop);
        }

        // POST: Lop/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MaLop,Nganh_Id")] Lop lop)
        {
            if (id != lop.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lop);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LopExists(lop.Id))
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
            ViewData["Nganh_Id"] = new SelectList(_context.Nganh, "Id", "Id", lop.Nganh_Id);
            return View(lop);
        }

        // GET: Lop/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lop = await _context.Lop
                .Include(l => l.Nganh)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lop == null)
            {
                return NotFound();
            }

            return View(lop);
        }

        // POST: Lop/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lop = await _context.Lop.FindAsync(id);
            _context.Lop.Remove(lop);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LopExists(int id)
        {
            return _context.Lop.Any(e => e.Id == id);
        }
    }
}
