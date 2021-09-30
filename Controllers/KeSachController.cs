using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QLTV.AppMVC.Models;
using QLTV.AppMVC.Models.Entities;

namespace QLTV.AppMVC.Controllers
{
    public class KeSachController : Controller
    {
        private readonly AppDbContext _context;

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
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TenKeSach")] KeSach keSach)
        {
            if (ModelState.IsValid)
            {
                _context.Add(keSach);
                await _context.SaveChangesAsync();
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
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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
            _context.KeSach.Remove(keSach);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KeSachExists(int id)
        {
            return _context.KeSach.Any(e => e.Id == id);
        }
    }
}
