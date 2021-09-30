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
    public class PhieuMuonController : Controller
    {
        private readonly AppDbContext _context;

        public PhieuMuonController(AppDbContext context)
        {
            _context = context;
        }

        // GET: PhieuMuon
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.PhieuMuon.Include(p => p.SinhVien);
            return View(await appDbContext.ToListAsync());
        }

        // GET: PhieuMuon/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phieuMuon = await _context.PhieuMuon
                .Include(p => p.SinhVien)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (phieuMuon == null)
            {
                return NotFound();
            }

            return View(phieuMuon);
        }

        // GET: PhieuMuon/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PhieuMuon/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string masv)
        {
            if (ModelState.IsValid)
            {
                var sv =  _context.SinhVien.Where(sv => sv.MaSV == masv)
                                                .FirstOrDefault();
                if (sv == null)
                {
                    ModelState.AddModelError(string.Empty, "Sinh viên không tồn tại");
                    return View();
                }

                var exists = await _context.PhieuMuon.AnyAsync(pm => pm.SinhVien_Id == sv.Id);

                if(exists)
                {
                    ModelState.AddModelError(string.Empty, "Sinh viên này đã có phiếu mượn");
                    return View();
                }    

                PhieuMuon pm = new PhieuMuon();
                pm.SinhVien = sv;
                pm.SinhVien_Id = sv.Id;

                _context.Add(pm);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: PhieuMuon/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phieuMuon = await _context.PhieuMuon.FindAsync(id);
            if (phieuMuon == null)
            {
                return NotFound();
            }
            ViewData["SinhVien_Id"] = new SelectList(_context.SinhVien, "Id", "GioiTinh", phieuMuon.SinhVien_Id);
            return View(phieuMuon);
        }

        // POST: PhieuMuon/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SinhVien_Id")] PhieuMuon phieuMuon)
        {
            if (id != phieuMuon.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phieuMuon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhieuMuonExists(phieuMuon.Id))
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
            ViewData["SinhVien_Id"] = new SelectList(_context.SinhVien, "Id", "GioiTinh", phieuMuon.SinhVien_Id);
            return View(phieuMuon);
        }

        // GET: PhieuMuon/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phieuMuon = await _context.PhieuMuon
                .Include(p => p.SinhVien)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (phieuMuon == null)
            {
                return NotFound();
            }

            return View(phieuMuon);
        }

        // POST: PhieuMuon/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var phieuMuon = await _context.PhieuMuon.FindAsync(id);
            _context.PhieuMuon.Remove(phieuMuon);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhieuMuonExists(int id)
        {
            return _context.PhieuMuon.Any(e => e.Id == id);
        }
    }
}
