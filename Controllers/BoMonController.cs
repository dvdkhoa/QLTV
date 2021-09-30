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
    public class BoMonController : Controller
    {
        private readonly AppDbContext _context;

        public BoMonController(AppDbContext context)
        {
            _context = context;
        }

        // GET: BoMon
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.BoMon.Include(b => b.Khoa);
            return View(await appDbContext.ToListAsync());
        }

        // GET: BoMon/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boMon = await _context.BoMon
                .Include(b => b.Khoa)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (boMon == null)
            {
                return NotFound();
            }

            return View(boMon);
        }

        // GET: BoMon/Create
        public IActionResult Create()
        {

            ViewData["Khoa_Id"] = new SelectList(_context.Khoa, "Id", "TenKhoa");
            return View();
        }

        // POST: BoMon/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MaBoMon,TenBoMon,Khoa_Id")] BoMon boMon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(boMon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Khoa_Id"] = new SelectList(_context.Khoa, "Id", "TenKhoa", boMon.Khoa_Id);
            return View(boMon);
        }

        // GET: BoMon/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boMon = await _context.BoMon.FindAsync(id);
            if (boMon == null)
            {
                return NotFound();
            }
            ViewData["Khoa_Id"] = new SelectList(_context.Khoa, "Id", "TenKhoa", boMon.Khoa_Id);
            return View(boMon);
        }

        // POST: BoMon/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MaBoMon,TenBoMon,Khoa_Id")] BoMon boMon)
        {
            if (id != boMon.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(boMon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BoMonExists(boMon.Id))
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
            ViewData["Khoa_Id"] = new SelectList(_context.Khoa, "Id", "Id", boMon.Khoa_Id);
            return View(boMon);
        }

        // GET: BoMon/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boMon = await _context.BoMon
                .Include(b => b.Khoa)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (boMon == null)
            {
                return NotFound();
            }

            return View(boMon);
        }

        // POST: BoMon/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var boMon = await _context.BoMon.FindAsync(id);
            _context.BoMon.Remove(boMon);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BoMonExists(int id)
        {
            return _context.BoMon.Any(e => e.Id == id);
        }
    }
}
