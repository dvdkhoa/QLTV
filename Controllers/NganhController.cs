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
    public class NganhController : Controller
    {
        private readonly AppDbContext _context;

        public NganhController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Nganh
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Nganh.Include(n => n.BoMon);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Nganh/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nganh = await _context.Nganh
                .Include(n => n.BoMon)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nganh == null)
            {
                return NotFound();
            }

            return View(nganh);
        }

        // GET: Nganh/Create
        public IActionResult Create()
        {
            ViewData["BoMon_Id"] = new SelectList(_context.BoMon, "Id", "TenBoMon");
            return View();
        }

        // POST: Nganh/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MaNganh,TenNganh,BoMon_Id")] Nganh nganh)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nganh);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BoMon_Id"] = new SelectList(_context.BoMon, "Id", "TenBoMon");
            return View(nganh);
        }

        // GET: Nganh/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nganh = await _context.Nganh.FindAsync(id);
            if (nganh == null)
            {
                return NotFound();
            }
            ViewData["BoMon_Id"] = new SelectList(_context.BoMon, "Id", "TenBoMon", nganh.BoMon_Id);
            return View(nganh);
        }

        // POST: Nganh/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MaNganh,TenNganh,BoMon_Id")] Nganh nganh)
        {
            if (id != nganh.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nganh);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NganhExists(nganh.Id))
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
            ViewData["BoMon_Id"] = new SelectList(_context.BoMon, "Id", "MaBoMon", nganh.BoMon_Id);
            return View(nganh);
        }

        // GET: Nganh/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nganh = await _context.Nganh
                .Include(n => n.BoMon)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nganh == null)
            {
                return NotFound();
            }

            return View(nganh);
        }

        // POST: Nganh/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nganh = await _context.Nganh.FindAsync(id);
            _context.Nganh.Remove(nganh);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NganhExists(int id)
        {
            return _context.Nganh.Any(e => e.Id == id);
        }
    }
}
