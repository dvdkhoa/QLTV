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
    public class NgonNguController : Controller
    {
        private readonly AppDbContext _context;

        public NgonNguController(AppDbContext context)
        {
            _context = context;
        }

        // GET: NgonNgu
        public async Task<IActionResult> Index()
        {
            return View(await _context.NgonNgu.ToListAsync());
        }

        // GET: NgonNgu/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ngonNgu = await _context.NgonNgu
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ngonNgu == null)
            {
                return NotFound();
            }

            return View(ngonNgu);
        }

        // GET: NgonNgu/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NgonNgu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MaNN,TenNN")] NgonNgu ngonNgu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ngonNgu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ngonNgu);
        }

        // GET: NgonNgu/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ngonNgu = await _context.NgonNgu.FindAsync(id);
            if (ngonNgu == null)
            {
                return NotFound();
            }
            return View(ngonNgu);
        }

        // POST: NgonNgu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MaNN,TenNN")] NgonNgu ngonNgu)
        {
            if (id != ngonNgu.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ngonNgu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NgonNguExists(ngonNgu.Id))
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
            return View(ngonNgu);
        }

        // GET: NgonNgu/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ngonNgu = await _context.NgonNgu
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ngonNgu == null)
            {
                return NotFound();
            }

            return View(ngonNgu);
        }

        // POST: NgonNgu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ngonNgu = await _context.NgonNgu.FindAsync(id);
            _context.NgonNgu.Remove(ngonNgu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NgonNguExists(int id)
        {
            return _context.NgonNgu.Any(e => e.Id == id);
        }
    }
}
